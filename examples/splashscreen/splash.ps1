Add-Type -Path '.\engine.dll'

$engine = New-Object engine.Functions 

$engine.CreateWindow(600,600,"splashcreen")
function ShowSplashScreen {

    $logo = $engine.GetNewSprite(".\logo.png")
    #You need adminstration privilegies to open files.
	
    $logo.UpdatePosition(0,0)

    $engine.DrawFrame();

    $engine.ClearFrameBackground();

    $logo.Draw()

    $engine.ClearFrame();

    Start-Sleep -Seconds 2
    
}

ShowSplashScreen

$engine.CloseWindow();#