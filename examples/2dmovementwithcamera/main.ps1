Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

# you can run $engine | Get-Member to help with intelissense in vscode

# make your code here :]

#$engine.EnableAudioDevice() #need to enable this to be enable to load sounds

$engine.CreateWindow(600,400,"title")
$chao = [engine.Rectangle2D]::GetNew(0,380,600,20,250,0,0,250)
$boneco = [engine.Rectangle2D]::GetNew(200,0,20,20,00,250,0,250)

$zoom = -1
$p = $engine.GetNewVector2(300,200)
$camera = [engine.Cam2D]::GetNew($p, $engine.GetNewVector2(300,200),$zoom,0)
#$camera = New-Object [engine.Cam2D]::GetNew(,$engine.GetNewVector2(0,0),$zoom,0)
#[Raylib_cs.Sound]$sound = $engine.LoadSoundFromFile("assets\sounds\sfx.wav")
$bonecoStuff = @{
    velX = 0
    velY = 0
    nochao = $false
}

#$camera.UpdateTarget($boneco.PosX,$boneco.PosY)
#$camera.camera.offset = $engine.GetNewVector2(300,200)
$camera.UpdateOffset(300,200)
$camera.UpdateZoom(1)
$camera.UpdateTarget($p)
$camera.UpdateRotation(0)

[System.Collections.ArrayList]$fase = @()
$fase.Add([engine.Rectangle2D]::GetNew(0,380,600,20,250,0,0,250))
$fase.Add([engine.Rectangle2D]::GetNew(300,580,600,20,250,0,0,250))
$fase.Add([engine.Rectangle2D]::GetNew(-300,880,300,20,250,0,0,250))
$fase.Add([engine.Rectangle2D]::GetNew(0,1080,200,20,250,0,0,250))

while(!$engine.IsAskingToCloseWindow()) {
    Write-Host 'target ' $camera.camera.target ' offset ' $camera.camera.offset ' zoom ' $camera.camera.zoom

    Start-Sleep -Milliseconds 20


    $v = $engine.GetNewVector2($boneco.PosX,$boneco.PosY)
    $camera.UpdateTarget($v)
    #if($engine.SegurandoA())
    #if($engine.ApertouCima()){ $camera.UpdateOffset()}
    if($engine.IsHoldingKey('A'))
    {
        $bonecoStuff.velX = -5
    }
    elseif ($engine.IsHoldingKey('D')) {
        $bonecoStuff.velX = 5
        
    }
    else {
        $bonecoStuff.velX = 0
        
    }   

    if($boneco.IsCollidingWithRectangle2D($chao)) {$bonecoStuff.nochao = $true} else {$bonecoStuff.nochao = $false}
    
    
    $bonecoStuff.velY = if($bonecoStuff.nochao) {0} else {5}

    $boneco.Move($bonecoStuff.velX,$bonecoStuff.velY)

    $engine.DrawFrame();

        $engine.StartMode2D($camera)

            $engine.ClearFrameBackground();


            $chao.Draw()
            $boneco.Draw()

        #draw objects
        $engine.FinishMode2D()


    $engine.ClearFrame();
}

$engine.CloseWindow();
