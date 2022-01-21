param($rot, $distancia)
Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

$engine.CreateWindow(600,600,"drawing")

$PI = 3.14159
$TAU = $PI * 2

[System.Collections.ArrayList]$lista = @()

while(!$engine.IsAskingToCloseWindow()) {
   
    Start-Sleep -Milliseconds 10

	if($engine.IsHoldingKey('s')){
		$null = $lista.Add(
			[engine.Rectangle2D]::GetNew($engine.MousePosX()-10,$engine.MousePosY()-10,20,20,0,0,0,254)
		)
	}
         
    $engine.DrawFrame();
    $engine.ClearFrameBackground();

	for ($i = 0; $i -lt $lista.Count; $i++) {
		
		if($null -ne $lista[$i])
		{
			$lista[$i].Draw()
		}
		
	}
    $engine.ClearFrame();
}

$engine.CloseWindow();


$jayson = ($lista | ConvertTo-Json)

return $jayson