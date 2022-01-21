param($rot, $distancia)
Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

$engine.CreateWindow(600,600,"trignometria")

$bola = [engine.ball2D]::GetNew(0,0,20,0,0,0,254)

$PI = 3.14159
$TAU = $PI * 2

[System.Collections.ArrayList]$lista = @()

$null = $lista.Add(
    @{
        quadrado = [engine.Rectangle2D]::GetNew(0,0,20,20,250,0,0,254)
        rotacao = 0
        distancia = 0
    }

)
while(!$engine.IsAskingToCloseWindow()) {

    if($engine.IsHoldingKey('w')) {$distancia++}
    elseif($engine.IsHoldingKey('s')) {$distancia--}
    elseif($engine.IsHoldingKey('a')) {$rot++}
    elseif($engine.IsHoldingKey('d')) {$rot--}
   
    Start-Sleep -Milliseconds 20

    $null = $lista.Add(
        @{
            quadrado = [engine.Rectangle2D]::GetNew($engine.MousePosX(),$engine.MousePosY(),20,20,((0..254)|Get-Random),((0..254)|Get-Random),((0..254)|Get-Random),254)
            rotacao = 0
            distancia = 0
        })

    $engine.DrawFrame();
    $engine.ClearFrameBackground();

    $posMouse = $engine.GetNewVector2($engine.MousePosX(),$engine.MousePosY())
    $bola.posX = $posMouse.X
    $bola.posY = $posMouse.Y
    $bola.DrawLine()  


for ($i = 0; $i -lt $lista.Count; $i++) {
    
    if($null -ne $lista[$i])
    {
        $lista[$i].rotacao += [Raylib_cs.Raylib]::GetFrameTime() * $rot
        $lista[$i].distancia+= [Raylib_cs.Raylib]::GetFrameTime() * $distancia

        if($lista[$i].rotacao -ge 360)
        {
            $lista[$i].rotacao = 0
        }
        $ponto = $engine.AngleToNormalizedVector($lista[$i].rotacao) * $lista[$i].distancia
        
        $lista[$i].quadrado.Draw()

        $lista[$i].quadrado.PosY = $posMouse.Y + $ponto.Y - $lista[$i].quadrado.height/2 
        $lista[$i].quadrado.PosX = $posMouse.X + $ponto.X - $lista[$i].quadrado.width /2

        if($lista[$i].distancia -ge 600)
        {
            $lista[$i] = $null
        }
    }
    
}
    $engine.ClearFrame();
}

$engine.CloseWindow();
