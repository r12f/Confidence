function Update-BuildRevisionVersion()
{
    $buildConfigFolder = $PSScriptRoot

    $versionFilePath = "$buildConfigFolder\config\version.txt"
    Write-Host "Version file path: $versionFilePath"

    $versionFileContent = Get-Content $versionFilePath
    $versionFileContent = $versionFileContent.Trim("\r\n ")
    Write-Host "Current version read: $versionFileContent"

    $versionParts = $versionFileContent.Split('.')
    $versionParts[2] = ([System.Convert]::ToInt32($versionParts[2]) + 1).ToString();
    $newVersion = $versionParts -join "."

    Write-Host "Updating version to: $newVersion"
    $encoding = New-Object System.Text.UTF8Encoding $False
    [System.IO.File]::WriteAllLines($versionFilePath, $newVersion, $encoding)

    cd "$buildConfigFolder\.."
    & git add . 
    & git commit -m "Increase version number to $newVersion."
}

Update-BuildRevisionVersion