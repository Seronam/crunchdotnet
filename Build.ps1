[CmdletBinding()]
param(
        [switch] $Build,
        [switch] $Package,
        [string] $Configuration = "Release"
     )

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