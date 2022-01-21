Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

$engine.CreateWindow(600,600,"title")

$linha = $engine.GetNewLine2D($engine.GetNewVector2(300,250),$engine.GetNewVector2(0,0))
$corPreto = $engine.GetNewColor(0,0,0,254)
$corVerde = $engine.GetNewColor(0,250,0,254)

$quadrado = $engine.GetNewRectangle2D(400,200,60,20,$engine.GetNewColor(250,0,0,254))

$lista = $null
$script:iniciou = $false
[System.Collections.ArrayList]$nova = @()

function AbrirOutraJanela {
    $engine.SetPositionWindow(100,100)
    Start-Job -FilePath .\desenho.ps1 -Name "desenho"
}
function PrintarFirulas {
    foreach ($quadrado in $nova) {
        $quadrado.Draw()
    }
}

function ConverterLista {

    $l = ($lista | ConvertFrom-Json)

    foreach($quadrado in $l)
    {
        $null = $nova.Add(
            $engine.GetNewRectangle2D($quadrado.position.X,$quadrado.position.Y,$quadrado.width, $quadrado.height,$engine.GetNewColor(0,0,0,254))

        )
    }
   
    $lista = $nova
}

while(!$engine.IsAskingToCloseWindow()) {
    if($iniciou)
    {
        (Get-Job -Name "desenho").State
        if((Get-Job -Name "desenho").State -eq "completed")
        {
            $lista = Receive-Job -Name "desenho"
            $iniciou = $false
            Write-Host "completou"
            $lista.count

            ConverterLista
        }
    }
    

    Start-Sleep -Milliseconds 20

    $engine.DrawFrame();

    $quadrado.Draw()

    $linha.p2.position = $engine.GetNewVector2($engine.MousePosX(),$engine.MousePosY())

    if($linha.p2.IsCollidingWithRectangle2D($quadrado)){
        $linha.Draw($corVerde)
        if($engine.MouseLeftPressed())
        {
            $iniciou = $true

            AbrirOutraJanela
        }
    }
    else {
        $linha.Draw($corPreto)
        
    }
    if($null -ne $lista) {PrintarFirulas}
    $linha.p2.Draw()
    $engine.ClearFrameBackground();

    $engine.ClearFrame();
}

$engine.CloseWindow();
Remove-Job *