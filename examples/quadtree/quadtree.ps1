Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

# you can run $engine | Get-Member to help with intelissense in vscode

# make your code here :]

#[Jitter.Collision.CollisionSystemSAP] $cs = $engine.GetNewCollisionSystem()
#[Jitter.World]$world = $engine.GetNewWolrd($cs)
# $cs.Detect($true)

#$engine.EnableAudioDevice() #need to enable this to be enable to load sounds
$w = 600
$h = 600
$engine.CreateWindow($w,$h,"title")

#[Raylib_cs.Sound]$sound = $engine.LoadSoundFromFile("assets\sounds\sfx.wav")
$vermelho = $engine.GetNewColor(255,0,0,255)
$azul = $engine.GetNewColor(0,0,255,255)
$quadtree = $engine.GetNewQuadTree( $engine.GetNewRectangle2D(0,0,$w,$h,$azul),4,4)

$jogador = $engine.GetNewBall2D($engine.GetNewVector2(299,300),10,$vermelho)

$quadtree.Insert($jogador.position)

function Debug-QuadTree { param ([engine.QuadTree]$qt )
    if($qt.subdivisions.Count -gt 0)
    {
        foreach ($quadtree in $qt.subdivisions) {
            Debug-QuadTree -qt $quadtree
        }
        
    }
    else {
        [Raylib_cs.Raylib]::DrawRectangleLines(
            $qt.rectangle.position.X,
            $qt.rectangle.position.Y,
            $qt.rectangle.width,
            $qt.rectangle.height,
            $vermelho
        )
        foreach($point in $qt.points)
        {
            [Raylib_cs.Raylib]::DrawCircleV($point,2,$vermelho)
        }
    }
    
}

$tempo = 0

[System.Collections.ArrayList]$inimigos = @()

while(!$engine.IsAskingToCloseWindow()) {
# $world.Step(1.0/100.0,$true)
    Start-Sleep -Milliseconds 16
    $tempo += $engine.DeltaTime()
    $engine.DrawFrame();
    
    if($engine.MouseLeftPressed())
    {
        $pos = [Raylib_cs.Raylib]::GetMousePosition() 

        $quadtree.Insert($pos)
    }
    elseif($engine.MouseRightPressed())
    {
        $pos = [Raylib_cs.Raylib]::GetMousePosition()
        #$quadtree.Insert($pos)
        $qt = $quadtree.GetQuadTreeWithThisPoint($pos)
        $qt.points.Clear()
    }
    elseif ($engine.ApertouEspaco()) {

        $qt = $quadtree.GetQuadTreeWithThisPoint($jogador.position)
        $qt.points.Clear()
        
        
        [Raylib_cs.Raylib]::DrawRectangle(
            $qt.rectangle.position.X,
            $qt.rectangle.position.Y,
            $qt.rectangle.width,
            $qt.rectangle.height,
            $vermelho
        )

    }
    elseif($engine.IsHoldingKey('f'))
    {
        $points = $quadtree.GetQuadTreeWithThisPoint($jogador.position).points
        foreach($p in $points)
        {
            [Raylib_cs.Raylib]::DrawLineV($jogador.position,$p,$azul)
        }

    }
    
    $novaPos = $engine.GetNewVector2(
        $engine.IsHoldingKey('a') ? -3 : $engine.IsHoldingKey('d') ? 3 : 0,
        $engine.IsHoldingKey('w') ? -3 : $engine.IsHoldingKey('s') ? 3 : 0
    )
    $old = $jogador.position
    
    $jogador.Move($novaPos.X,$novaPos.Y)
    $jogador.Draw()
    $quadtree.UpdatePoint($old,$jogador.position,$quadtree)

    if($tempo -gt 5)
    {
        $quadtree.Refresh()
        $tempo = 0
    }

    Debug-QuadTree -qt $quadtree

    $engine.ClearFrameBackground();
    
    $engine.DrawText("- WASD to move`n- left mouse to add point`n- right mouse inside a quad to remove all points`n- space to remove all points inside the`nquad where you are`n- hold F to draw a line to all points inside`nthe quad where you are`nevery 5 seconds the quadtree will be refreshed`nremoving all empty subdivisions",20,5,0)
    $engine.ClearFrame();
}

$engine.CloseWindow();
