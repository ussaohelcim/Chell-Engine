#dotnet publish -r linux-x64

dotnet publish "..\engine\" --output ".\temp\"

Write-Host "Creating ChellEngine folder..."
New-Item "ChellEngine" -ItemType Directory

Copy-Item "..\raylib\raylib.dll" -Destination ".\ChellEngine\"
Copy-Item ".\temp\engine.dll" -Destination ".\ChellEngine\"
Copy-Item ".\temp\Raylib-cs.dll" -Destination ".\ChellEngine\"

Remove-Item ".\temp\" -Force -Recurse

$shit = @'
Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

# you can run $engine | Get-Member to help with intelissense in vscode

# make your code here :]

'@

Set-Content ".\ChellEngine\main.ps1" $shit