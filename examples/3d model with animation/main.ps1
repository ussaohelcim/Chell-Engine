Add-Type -Path '.\engine.dll'

if(!(Test-Path -Path ".\BoxAnimated.glb"))
{
    $link = "https://github.com/ChrisDill/Raylib-cs-Examples/raw/master/Examples/resources/gltf/BoxAnimated.glb"

    Invoke-WebRequest -Uri $link -OutFile ".\BoxAnimated.glb"
}

$engine = New-Object engine.Functions 

$engine.CreateWindow(800,600,"3D animation")

$cam = [engine.Cam3D]::GetNew(100)

$cam.camera.projection = 0
$cam.camera.up = $engine.GetNewVector3(0,1,0)

$cam.camera.fovy = 50

[Raylib_cs.Raylib]::SetCameraMode($cam.camera,[Raylib_cs.CameraMode]::CAMERA_CUSTOM)

$pos = $engine.GetNewVector3(0,0,0)
$branco = $engine.GetNewColor(254,254,254,254)

$obj = $engine.GetNewObject3D(".\BoxAnimated.glb")
#$obj = $engine.GetNewObject3D(".\raul.glb")

$animNum = 0

$animaFrameCounter = 0

$cam.Move($obj.position.X,$obj.position.Y,$obj.position.Z+10)


$mov = $engine.GetNewVector3(0,0,0)
$rot = @{
    x = 0
    y = 0
    z = 0
}
$engine.SetMaxFPS(60)
while(!$engine.IsAskingToCloseWindow()) {
    # Start-Sleep -Milliseconds 20

    if($engine.IsHoldingKey('p'))
    {
        #[Raylib_cs.Raylib]::UpdateModelAnimation($obj.model,$obj.animations[0],$animaFrameCounter)
        $obj.Animate(0,$animaFrameCounter)
        $animaFrameCounter++
        if($animaFrameCounter -ge 5040 ) {$animaFrameCounter = 0}
    }

    $obj.animsCount


    $engine.CameraUpdate($cam)

    $engine.DrawFrame();
    $engine.ClearFrameBackground();

    $engine.StartMode3D($cam)

        if($engine.IsHoldingKey('w')) {$mov.z = -0.2}
        elseif($engine.IsHoldingKey('s')){ $mov.z = 0.2 }
        elseif($engine.IsHoldingKey('a')){ $mov.x = -0.2}
        elseif($engine.IsHoldingKey('d')){ $mov.x = 0.2 }
        elseif($engine.IsHoldingKey('z')){ $mov.y = 0.2 }
        elseif($engine.IsHoldingKey('x')) {$mov.y = -0.2}
        else {
            $mov.x = 0
            $mov.Z = 0
            $mov.y = 0
        }

        if($engine.IsHoldingKey('e')) {$rot.z += 3}
        elseif($engine.IsHoldingKey('q')) {$rot.z -= 3}

        $rot.y += 2

        $obj.position += $mov
        $obj.Rotate($rot.x,$rot.y,$rot.z)
        #$cam.Move($obj.position.x,$obj.position.Y,0)# =  + $engine.GetNewVector3(0,0,10)
        $obj.Draw()
        #[Raylib_cs.Raylib]::DrawModelEx($obj.model,$engine.GetNewVector3(0,0,0),$engine.GetNewVector3(0,1,0),30,$engine.GetNewVector3(5,5,5),$engine.GetNewColor(254,254,254,254))
        $obj.DrawWire()

        [Raylib_cs.Raylib]::DrawGrid(20,20)

    $engine.FinishMode3D()

    $engine.DrawText("Hold P to animate the cubes.`nQ or E to rotate on z axis`nwasd to move object`nzx updown",20,2,0)
    
    $engine.ClearFrame();
}

$engine.CloseWindow();
