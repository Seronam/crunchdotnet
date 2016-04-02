[CmdletBinding()]
param(
        [switch] $Build,
        [switch] $Package,
        [string] $SemanticName = $null,
        [string] $Configuration = "Release"
     )

$describe = iex "git describe"

$versionSplit = $describe.Split('-')

$version = "$($versionSplit[0]).$($versionSplit[1])"

if($SemanticName)
{
    $semanticVersion = "$version-$SemanticName"
    $nugetVersion = "$($versionSplit[0])-$SemanticName"
}
else
{
    $semanticVersion = $version
    $nugetVersion = $versionSplit[0]
}

#region Set AssemblyInfo version if necessary
$assemblyVersionFile = "$PSScriptRoot\src\Crunch.DotNet\Properties\AssemblyInfo.cs"

$content = Get-Content -Path $assemblyVersionFile
$output = @()
$altered = $false

foreach($line in $content)
{
    if($line -match "^\[assembly: AssemblyVersion")
    {
        $assemblyVersion = "[assembly: AssemblyVersion(""$version"")]"

        if($line -ne $assemblyVersion)
        {
            $output += $assemblyVersion
            $altered = $true
        }
        else
        {
            $output += $line
        }
    }
    elseif($line -match "^\[assembly: AssemblyFileVersion")
    {
        $assemblyFileVersion = "[assembly: AssemblyFileVersion(""$version"")]"

        if($line -ne $assemblyFileVersion)
        {
            $output += $assemblyFileVersion
            $altered = $true
        }
        else
        {
            $output += $line
        }
    }
    elseif($line -match "^\[assembly: AssemblyInformationalVersion")
    {
        $assemblyInformationalVersion = "[assembly: AssemblyInformationalVersion(""$semanticVersion"")]"

        if($line -ne $assemblyInformationalVersion)
        {
            $output += $assemblyInformationalVersion
            $altered = $true
        }
        else
        {
            $output += $line
        }
    }
    else
    {
        $output += $line
    }
}

if($altered)
{
    Set-Content -Path $assemblyVersionFile -Value $output -Encoding UTF8
}
#endregion


if($Build)
{
    $solution = "$PSScriptRoot\src\Crunch.DotNet.sln"

    $dotNetVersion = "14.0"
    $regKey = "HKLM:\software\Microsoft\MSBuild\ToolsVersions\$dotNetVersion"
    $regProperty = "MSBuildToolsPath"

    $msbuildExe = join-path -path (Get-ItemProperty $regKey).$regProperty -childpath "msbuild.exe"

    &$msbuildExe $solution "/t:Clean,Rebuild" "/p:Configuration=$Configuration"
}

if($Package)
{
    $outputDirectory = "$PSScriptRoot\artifacts"

    if(-not (Test-Path -Path $outputDirectory))
    {
        New-Item -ItemType Directory -Force -Path $outputDirectory
    }

    $project = "$PSScriptRoot\src\Crunch.DotNet\Crunch.DotNet.csproj"

    $nuget = Get-ChildItem -Path $PSScriptRoot -Filter 'nuget.exe' -Recurse
    $packCommand = "$($nuget.FullName) pack ""$project"" -OutputDirectory ""$outputDirectory"" -Version $nugetVersion"

    #$packCommand
    iex $packCommand
}