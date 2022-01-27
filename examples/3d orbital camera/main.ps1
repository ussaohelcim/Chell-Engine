Add-Type -Path '.\engine.dll'

if(!(Test-Path -Path ".\raul.glb"))
{
    $link = "https://github.com/ca3games/Godot/raw/3.4.2/Raul%20mission%203D/3D/Raul/raul.glb"

    Invoke-WebRequest -Uri $link -OutFile ".\raul.glb"
}

$engine = New-Object engine.Functions 

$engine.CreateWindow(600,400,"3D model orbital camera")

$cam = [engine.Cam3D]::GetNew(80)

$cam.camera.projection = 0
$cam.camera.up = $engine.GetNewVector3(0,1,0)
$cam.camera.target = $engine.GetNewVector3(0,0,0)
$cam.camera.position = $engine.GetNewVector3(200,200,200)
$cam.camera.fovy = 50

[Raylib_cs.Raylib]::SetCameraMode($cam.camera,[Raylib_cs.CameraMode]::CAMERA_ORBITAL)

$modelo = [Raylib_cs.Raylib]::LoadModel(".\raul.glb")

$pos = $engine.GetNewVector3(0,0,0)
$branco = $engine.GetNewColor(254,254,254,254)

while(!$engine.IsAskingToCloseWindow()) {
    Start-Sleep -Milliseconds 20

    $engine.CameraUpdate($cam)

    $engine.DrawFrame();
    $engine.ClearFrameBackground();

    $engine.StartMode3D($cam)

        if($engine.IsHoldingKey('w'))
        {
            [Raylib_cs.Raylib]::DrawModelWires($modelo,$pos,1,$branco)
        }
        else {
            [Raylib_cs.Raylib]::DrawModel($modelo,$pos,1,$branco)
        }

    $engine.FinishMode3D()
    
    $cam.camera.position
    $engine.ClearFrame();
}

$engine.CloseWindow();
