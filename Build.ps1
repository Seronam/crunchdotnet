[CmdletBinding()]
param(
        [switch] $Build,
        [switch] $Package,
        [string] $SemanticVersion = $null,
        [string] $Configuration = "Release"
     )

if($SemanticVersion)
{
    $assemblyVersionFile = "$PSScriptRoot\src\Crunch.DotNet\Properties\AssemblyInfo.cs"

    $content = Get-Content -Path $assemblyVersionFile
    $output = @()

    $version = $SemanticVersion.Split('-')[0]
    $altered = $false

    foreach($line in $content)
    {
        if($line -match "^\[assembly: AssemblyVersion")
        {
            $assemblyVersion = "[assembly: AssemblyVersion(""$version"")]"

            f($line -ne $assemblyVersion)
            {
                $output += $assemblyVersion
                $altered = $true
            }
        }
        elseif($line -match "^\[assembly: AssemblyFileVersion")
        {
            $assemblyFileVersion = "[assembly: AssemblyFileVersion(""$version"")]"

            f($line -ne $assemblyFileVersion)
            {
                $output += $assemblyFileVersion
                $altered = $true
            }
        }
        elseif($line -match "^\[assembly: AssemblyInformationalVersion")
        {
            $assemblyInformationalVersion = "[assembly: AssemblyInformationalVersion(""$SemanticVersion"")]"

            if($line -ne $assemblyInformationalVersion)
            {
                $output += $assemblyInformationalVersion
                $altered = $true
            }
        }
        else
        {
            $output += $line
        }
    }

    if($altered)
    {
        Set-Content -Path $assemblyVersionFile -Value $output
    }

}

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
    $packCommand = "$($nuget.FullName) pack ""$project"" -OutputDirectory ""$outputDirectory"""

    #$packCommand
    iex $packCommand
}