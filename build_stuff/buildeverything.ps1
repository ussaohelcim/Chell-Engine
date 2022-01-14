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

#$engine.EnableAudioDevice() #need to enable this to be enable to load sounds

#$engine.CreateWindow(width,height,"title")

#[Raylib_cs.Sound]$sound = $engine.LoadSoundFromFile("assets\sounds\sfx.wav")

#while(!$engine.IsAskingToCloseWindow()) {

#$engine.DrawFrame();

    #draw objects

#$engine.ClearFrameBackground();

#$engine.ClearFrame();
#}

#$engine.CloseWindow();
'@

Set-Content ".\ChellEngine\main.ps1" $shit