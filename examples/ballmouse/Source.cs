using System;
using System.Collections.Generic;
using Raylib_cs;

namespace GameEngine
{
    using static Raylib;

    public class Funcoes
    {
        Random r = new Random();
        List<Sprite> sprites;
        List<Bola2D> bolas;

        
        public Funcoes() {}

        public void AbrirJanela(int largura, int altura, string tiulo)
        {
            Raylib.InitWindow(largura, altura, tiulo);
        }
        public void AdicionarSpriteNaMemoria(Sprite sprite)
        {
            sprites.Add(sprite);
        }
        public void AdicionarBolaNaMemoria(Bola2D bola)
        {
            bolas.Add(bola);
        }
        public void ForcarFPS(int fps)
        {
            SetTargetFPS(fps);
        }
        public bool PediuPraFechar()
        {
            return Raylib.WindowShouldClose();
        }
        public void FecharJanela()
        {
            Raylib.CloseWindow();
        }
        public void DesenharQuadro()
        {
            Raylib.BeginDrawing();
        }
        public void LimparFundoQuadro()
        {
            Raylib.ClearBackground(Color.WHITE);
        }
        public void ApagarQuadro()
        {
            Raylib.EndDrawing();
        }
        public void DesenharTodosSprites()
        {
            foreach (Sprite sprite in sprites)
            {
                sprite.Draw();
            }
        }
        public void DesenharTodasBolas()
        {
            foreach (Bola2D bola in bolas)
            {
                bola.Draw();
            }
        }

        public int MousePosY()
        {
            return GetMouseY();
        }
        public int MousePosX()
        {
            return GetMouseX();
        }
        public bool ApertouMouseLeft()
        {
            return IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);
        }
        public bool ApertouMouseRight()
        {
            return IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON);
        }

        public void Desenhar()
        {
            
            

            

            while (!Raylib.WindowShouldClose())
            {
                System.Numerics.Vector2 mousePos = GetMousePosition();
                Raylib.BeginDrawing();


                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                foreach (Bola2D bola in bolas)
                {
                    // if(Raylib.CheckCollisionPointCircle(mousePos,new System.Numerics.Vector2(bola.posX,bola.posY),bola.raio ))
                    // {

                    // }
                    bola.Draw();
                    //bola.Move()
                    

                    
                }
                DrawFPS(0,0);
                Raylib.ClearBackground(Color.WHITE);


                Raylib.EndDrawing();

            }

            Raylib.CloseWindow();
        }

        
        public bool TaSegurandoATecla(char letra)
        {
            int a = GetKeyPressed();
            return letra == a;
        }
        public bool ApertouW()
        {
            return IsKeyPressed(KeyboardKey.KEY_W);
        }
        public bool ApertouA()
        {
            return IsKeyPressed(KeyboardKey.KEY_A);
        }
        public bool ApertouS()
        {
            return IsKeyPressed(KeyboardKey.KEY_S);
        }
        public bool ApertouD()
        {
            return IsKeyPressed(KeyboardKey.KEY_D);
        }
        public bool ApertouEspaco()
        {
            return IsKeyPressed(KeyboardKey.KEY_SPACE);
        }
    }
    public class Program
    {
        public static void Main()
        {
            // Funcoes funcoes = new Funcoes();
            // funcoes.Desenhar();
        }
    }
    public class Sprite : IControle, IPosicoes2D
    {
        Texture2D textura;
        Rectangle retangulo;


        public Sprite(string path, int largula, int altura)
        {
            PosX = 0;
            PosY = 0;
            textura = LoadTexture(path);
            retangulo = new Rectangle(0,0,largula,altura);
        }
        

		public int PosX { get; set; }
		public int PosY { get; set; }

		public void Destroy()
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
			DrawTexture(textura, PosX, PosY, Color.WHITE);
		}

		public void Move(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
    public class Bola2D : IControle
    {
        public int posX, posY, raio;
        public Color cor; //public Color(int r, int g, int b, int a);

        public Bola2D(int x, int y, int radius, int r, int g, int b, int a )
        {
            posX = x;
            posY = y;
            raio = radius;
            cor = new Color(r,g,b,a);
        }
        public void Draw()
        {
            Raylib.DrawCircle(posX,posY,raio,cor);
        }

        public void Move(int x, int y)
        {
            posX += x;
            posY += y;
        }
        public void Destroy()
        {

        }
        static public Bola2D GetNew(int x, int y, int radius, int r, int g, int b, int a )
        {
            Bola2D bolinha = new Bola2D(x,y,radius,r,g,b,a);
            return bolinha;
        }
    }

	public class Retangulo2D : IControle, IPosicoes2D
	{
        
		public int PosX { get; set; }
		public int PosY { get; set; }
        public int largura, altura;
        Color cor;
        public Retangulo2D(int largura, int altura, int r, int g, int b, int a )
        {
            this.largura = largura;
            this.altura = altura;
            PosY = 0;
            PosX = 0;
            cor = new Color(r,g,b,a);
        }
        public Retangulo2D(int x, int y,int largura, int altura, int r, int g, int b, int a )
        {
            PosX = x;
            PosY = y;
            this.largura = largura;
            this.altura = altura;
            cor = new Color(r,g,b,a);
        }

		public void Destroy()
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
			DrawRectangle(PosX,PosY,largura,altura,cor);
		}

		public void Move(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
	public interface IControle
    {
        public void Move(int x, int y);
        public void Draw();
        public void Destroy();
    }
    public interface IPosicoes2D
    {
        public int PosX 
        {
            get;
            set;
        }
        public int PosY 
        {
            get;
            set;
        }
    }
}
