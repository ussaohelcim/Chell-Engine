Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

# you can run $engine | Get-Member to help with intelissense in vscode

# make your code here :]

#$engine.EnableAudioDevice() #need to enable this to be enable to load sounds

$w = 600
$h = 600

$engine.CreateWindow($w,$h,"FPS")

# [Raylib_cs.Sound]$sound = $engine.LoadSoundFromFile("assets\sounds\sfx.wav")

$chao = $engine.GetNewObject3D(".\chao.glb")
$predios = $engine.GetNewObject3D(".\predios.glb")
$arma = $engine.GetNewSprite(".\mp40.png")

$arma.rectangle.position = $engine.GetNewVector2($w - $arma.textura.width , $h - $arma.textura.height) 

[System.Collections.ArrayList]$tiros = @()

$cam = $engine.GetCam3D()

[Raylib_cs.Raylib]::SetCameraMode($cam.camera,[Raylib_cs.CameraMode]::CAMERA_CUSTOM)

$azulCeu = $engine.GetNewColor(1,187,254,254)


$cam.camera.target = $engine.GetNewVector3(0,0,0)

$cam.UpdatePosition($engine.GetNewVector3(0,2,0))
$PI = 3.14159
$TAU = $PI * 2

$rot = $engine.GetNewVector3(0,0,10)

$foward = $engine.GetNewVector3(0,0,1)

$vel = $engine.GetNewVector3(0,0,0) + $cam.camera.position

$tempoAnimacaoTiro = 0.1
$atirou = $false

$velMovement = 0.5
$vermelho = $engine.GetNewColor(254,0,0,254)
$preto = $engine.GetNewColor(0,0,0,255)

$mira = $engine.GetNewBall2D($engine.GetNewVector2($w/2,$h/2),10,$engine.GetNewColor(254,254,254,254))

$mousePos = $engine.GetNewVector2(0,0)

[Raylib_cs.Raylib]::HideCursor()


while(!$engine.IsAskingToCloseWindow()) {

    # Start-Sleep -Milliseconds 16

    if(!$atirou)
    {
        if([Raylib_cs.Raylib]::IsMouseButtonDown([Raylib_cs.MouseButton]::MOUSE_LEFT_BUTTON))
        {
            $atirou = $true

            $frente = $engine.GetNewVector3(0,0,1)

            $rotX = (( $rot.x / 360) * $TAU)
            $rotY = (( $rot.y / 360) * $TAU)

            $q = [Raylib_cs.Raymath]::QuaternionFromEuler($rotX,$rotY,0)

            $v = [Raylib_cs.Raymath]::Vector3RotateByQuaternion($frente,$q)

            $ray = $engine.GetNewRay($cam.camera.position,$v)
           
            $colisao = [Raylib_cs.Raylib]::GetCollisionRayModel($ray,$predios.model)

            if($colisao.hit)
            {
                $null = $tiros.Add(
                    @{
                        shape = $engine.GetNewPoint3D($colisao.position)
                    }
                )
            }
            $colisao = [Raylib_cs.Raylib]::GetCollisionRayModel($ray,$chao.model)
            if($colisao.hit)
            {
                $null = $tiros.Add(
                    @{
                        shape = $engine.GetNewPoint3D($colisao.position)
                    }
                )
            }
        }
    }
    else {
        $tempoAnimacaoTiro -= $engine.DeltaTime()
        if($tempoAnimacaoTiro -le 0) {
            $tempoAnimacaoTiro = 0.1
            $atirou = $false
        }
    }

    $mousePos = [Raylib_cs.Raylib]::GetMousePosition() - $engine.GetNewVector2($w/2,$h/2)

    $rot.Y -= $mousePos.X
    $rot.X += $mousePos.Y
    
    [Raylib_cs.Raylib]::SetMousePosition($w/2,$h/2)

    $velMovement = [Raylib_cs.Raylib]::IsKeyDown([Raylib_cs.KeyboardKey]::KEY_LEFT_SHIFT) ? 0.5 : 0.3
    
    $vel.x = $engine.IsHoldingKey('a') ? $velMovement * $engine.DeltaTime() *20 : $engine.IsHoldingKey('d') ? -$velMovement * $engine.DeltaTime() *20 : 0
    $vel.z = $engine.IsHoldingKey('w') ? $velMovement * $engine.DeltaTime() *20 : $engine.IsHoldingKey('s') ? -$velMovement * $engine.DeltaTime() *20 : 0
    $vel.y = 0

    $rotX = (( $rot.x / 360) * $TAU)
    $rotY = (( $rot.y / 360) * $TAU)

    $q = [Raylib_cs.Raymath]::QuaternionFromEuler(0,$rotY,0)
    $v =  [Raylib_cs.Raymath]::Vector3RotateByQuaternion($foward,$q) 
    
    $cam.Move($v,$vel.z)
    $cam.Rotate($rotY,$rotX,0)
    
    $engine.CameraUpdate($cam)

    $engine.DrawFrame();

    [Raylib_cs.Raylib]::ClearBackground($azulCeu)

    $engine.StartMode3D($cam)
    #start drawing 3D stuff
    if($tiros.Count -gt 0)
    {
        foreach ($bala in $tiros) {
            [Raylib_cs.Raylib]::DrawCube($bala.shape.position,0.3,0.3,0.3,$preto)
        }
    }

    $predios.Draw()
    $chao.Draw()
            
    $engine.FinishMode3D()

    $arma.Draw()
    [Raylib_cs.Raylib]::DrawCircleLines($mira.position.x,$mira.position.Y,[System.Numerics.Vector3]::Distance($cam.camera.position,$cam.camera.target),$mira.cor)

    $engine.DrawText("Mouse to look`nLeft mouse to shoot`nW to move forward",20,10,30)
    [Raylib_cs.Raylib]::DrawFPS(0,0)

    $engine.ClearFrame();

}

$engine.CloseWindow();
