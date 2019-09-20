param (
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $Version
)

function Update-BuildRevisionVersion()
{
    $buildConfigFolder = $PSScriptRoot

    $versionFilePath = "$buildConfigFolder\config\version.txt"
    Write-Host "Version file path: $versionFilePath"

    $newVersion = "$Version.0"
    Write-Host "Updating version to: $newVersion"

    $encoding = New-Object System.Text.UTF8Encoding $False
    [System.IO.File]::WriteAllLines($versionFilePath, $newVersion, $encoding)
}

Update-BuildRevisionVersion