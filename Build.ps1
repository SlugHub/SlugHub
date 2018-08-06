function Exec
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)][scriptblock]$cmd,
        [Parameter(Position=1,Mandatory=0)][string]$errorMessage = ($msgs.error_bad_command -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

if(Test-Path .\src\SlugHub\artifacts) { Remove-Item .\src\SlugHub\artifacts -Force -Recurse }

$branch = @{ $true = $env:APPVEYOR_REPO_BRANCH; $false = $(git symbolic-ref --short -q HEAD) }[$env:APPVEYOR_REPO_BRANCH -ne $NULL];
$revision = @{ $true = "{0:00000}" -f [convert]::ToInt32("0" + $env:APPVEYOR_BUILD_NUMBER, 10); $false = "local" }[$env:APPVEYOR_BUILD_NUMBER -ne $NULL];
$suffix = @{ $true = ""; $false = "$($branch.Substring(0, [math]::Min(10,$branch.Length)))-$revision"}[$branch -eq "master" -and $revision -ne "local"]
$commitHash = $(git rev-parse --short HEAD)
$buildSuffix = @{ $true = "$($suffix)-$($commitHash)"; $false = "$($branch)-$($commitHash)" }[$suffix -ne ""]
$versionSuffix = @{ $true = "--version-suffix=$($suffix)"; $false = ""}[$suffix -ne ""]

echo "build: Package version suffix is $suffix"
echo "build: Build version suffix is $buildSuffix" 

exec { & dotnet build SlugHub.sln -c Release --version-suffix=$buildSuffix }

Push-Location -Path .\tests\SlugHub.Tests

try {
    exec { & dotnet test -c Release --no-build }
} finally {
    Pop-Location
}

Pop-Location

exec { & dotnet pack .\src\SlugHub.csproj -c Release -o .\artifacts --include-symbols --no-build $versionSuffix }