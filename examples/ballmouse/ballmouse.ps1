Add-Type -Path ".\GameEngine.dll"

#$caminhoCSC = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
#$argumentos = "/target:library"

function Setup {
	#set things like fps, textures, 
}

function GameLoop {

}


$engine = New-Object GameEngine.Funcoes

$bola = [GameEngine.Bola2D]::GetNew(0,0,10,200,0,0,250)
$bola2 = [GameEngine.Bola2D]::GetNew(0,33,10,200,0,0,250)
$bola3 = [GameEngine.Bola2D]::GetNew(0,60,10,200,0,0,250)
$bola4 = [GameEngine.Bola2D]::GetNew(0,0,10,200,200,0,250)

#$engine.AdicionarBolaNaMemoria($bola)

$engine.AbrirJanela(400,400,"BUCETA")

while ( !($engine.PediuPraFechar()) ) {
	Start-Sleep -Milliseconds 16
	$engine.DesenharQuadro()
	#$engine.DesenharTodasBolas()
	$bola.Draw()
	$bola2.Draw()
	$bola3.Draw()

	$bola4.Draw()

	$bola4.posX = $engine.MousePosX()
	$bola4.posY = $engine.MousePosY()

	$engine.LimparFundoQuadro()
	$engine.ApagarQuadro()

	$bola.Move(1,0)
	$bola2.Move(1,0)
	$bola3.Move(1,0)
}
$engine.FecharJanela()