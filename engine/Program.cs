using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
namespace engine
{
    using static Raylib;
    public class Functions 
    {
        
        Random r = new Random();
        
        public Functions() {}

        public void CreateWindow(int largura, int altura, string tiulo)
        {
            Raylib.InitWindow(largura, altura, tiulo);
            
        }
        public void SetMaxFPS(int fps)
        {
            SetTargetFPS(fps);
        }
        public bool IsAskingToCloseWindow()
        {
            return Raylib.WindowShouldClose();
        }
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }
        public void DrawFrame()
        {
            Raylib.BeginDrawing();
        }
        public void ClearFrameBackground()
        {
            Raylib.ClearBackground(Color.WHITE);
        }
        public void ClearFrame()
        {
            Raylib.EndDrawing();
        }
               
        public int MousePosY()
        {
            return GetMouseY();
        }
        public int MousePosX()
        {
            return GetMouseX();
        }
        public bool MouseLeftPressed()
        {
            return IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);
        }
        public bool MouseRightPressed()
        {
            return IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON);
        }
        
        public bool SegurandoW()
        {
            return IsKeyDown(KeyboardKey.KEY_W);
        }
        public bool SegurandoS()
        {
            return IsKeyDown(KeyboardKey.KEY_S);
        }
        public bool SegurandoCima()
        {
            return IsKeyDown(KeyboardKey.KEY_UP);

        }
        public bool SegurandoBaixo()
        {
            return IsKeyDown(KeyboardKey.KEY_DOWN);
        }
        public void DrawTextUpLeft(string txt, int textSize)
        {
            Raylib.DrawText(txt,0,0,textSize,Color.BLACK);
        }
        public void DrawTextCenter(string txt, int textSize)
        {
            Raylib.DrawText(txt,Raylib.GetScreenWidth()/2,0,textSize,Color.BLACK);

        }
        public void DrawText(string txt, int textSize, int x, int y)
        {
            Raylib.DrawText(txt,x,y,textSize,Color.BLACK);
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
        public bool ApertouBaixo()
        {
            return IsKeyPressed(KeyboardKey.KEY_DOWN);
        }
        public bool ApertouCima()
        {
            return IsKeyPressed(KeyboardKey.KEY_UP);
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
            // Functions engine = new Functions();

            // Ball2D bola = new Ball2D(200,150,10,200,0,0,250);

            // Rectangle2D raqueteEsquerda = new Rectangle2D(380,150,20,50,0,254,0,254);
            // Rectangle2D raqueteDireita = new Rectangle2D(0,150, 20,50,0,0,254,254);

            // engine.CreateWindow(400,300,"Pong");

            // while(!engine.IsAskingToCloseWindow())
            // {
            //     engine.DrawFrame();

            //     bola.Draw();
            //     raqueteDireita.Draw();
            //     raqueteEsquerda.Draw();

            //     bola.posX = engine.MousePosX();
            //     bola.posY = engine.MousePosY();

                

            //     engine.ClearFrameBackground();

            //     engine.ClearFrame();
            // }
            // engine.CloseWindow();
        }
    }
    public class Point2D : IPosicoes2D
    {
        public int PosX { get; set; }
		public int PosY { get; set; }

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
    public class Ball2D : IControle
    {
        public int posX, posY, radius;
        public Vector2 center;
        
        public Color cor; //public Color(int r, int g, int b, int a);
       

        public Ball2D(int x, int y, int radius, int r, int g, int b, int a )
        {
            posX = x;
            posY = y;
            this.radius = radius;
            center = new Vector2(x,y);
            cor = new Color(r,g,b,a);
        }
        public void Draw()
        {
            Raylib.DrawCircle(posX,posY,radius,cor);
        }

        public void Move(int x, int y)
        {
            posX += x;
            posY += y;
            center.X = posX;
            center.Y = posY;
            //center = new Vector2(posX,posY);
        }
        public void Destroy()
        {
            
        }
        public bool IsCollidingWithBall2D(Ball2D ball)
        {
            //Vector2 centro = new Vector2(posX,posY);
            return Raylib.CheckCollisionCircles(this.center,this.radius,ball.center,ball.radius);
        }
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
        {
            // if( this.posX + this.radius >= rectangle.PosX &&
            //     this.posX + this.radius <= rectangle.PosX + rectangle.largura &&
            //     this.posY + this.radius >= rectangle.PosY &&
            //     this.posY + this.radius <= rectangle.PosY + rectangle.altura
            // )
            // {
            //     return true;
            // }
            // return false;
            // Vector2 centro = new Vector2(posX,posY);
            if(Raylib.CheckCollisionCircleRec(this.center,this.radius,rectangle.rect))
            {
                DrawRectangleLinesEx(rectangle.rect,5,Color.GREEN);
                return true;
            }
            return false;
        }
        static public Ball2D GetNew(int x, int y, int radius, int r, int g, int b, int a )
        {
            Ball2D bolinha = new Ball2D(x,y,radius,r,g,b,a);
            return bolinha;
        }
    }

	public class Rectangle2D : IControle, IPosicoes2D
	{
        
		public int PosX { get; set; }
		public int PosY { get; set; }
        public int largura, altura;
        Color cor;
        public Rectangle rect;
        public Rectangle2D(int largura, int altura, int r, int g, int b, int a )
        {
            this.largura = largura;
            this.altura = altura;
            PosY = 0;
            PosX = 0;
            
            rect = new Rectangle(PosX,PosY,largura,altura);
            cor = new Color(r,g,b,a);
        }
        public Rectangle2D(int x, int y,int largura, int altura, int r, int g, int b, int a )
        {
            PosX = x;
            PosY = y;
            this.largura = largura;
            this.altura = altura;
            cor = new Color(r,g,b,a);
        }
        public bool IsCollidingWithBall2D(Ball2D ball)
        {
            return Raylib.CheckCollisionCircleRec(ball.center,ball.radius,this.rect);
        }
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
        {
            if( this.PosX + this.largura >= rectangle.PosX &&
                this.PosX <= rectangle.PosX + rectangle.largura &&
                this.PosY + this.altura >= rectangle.PosY &&
                this.PosY <= rectangle.PosY + rectangle.altura
            )
            {
                return true;
            }
            return false;
        }

		public void Destroy()
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
			DrawRectangle(PosX,PosY,largura,altura,cor);
            DrawRectangleLinesEx(this.rect,10,Color.GREEN);
		}

		public void Move(int x, int y)
		{
			PosX += x;
            PosY += y;
            rect.x = PosX;
            rect.y = PosY;
		}
        public static Rectangle2D GetNew(int x, int y,int largura, int altura, int r, int g, int b, int a )
        {
            return new Rectangle2D(x,y,largura,altura,r,g,b,a);
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

    public interface IColisions2D
    {
        public bool IsCollidingWithBall2D(Ball2D ball);
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle);
    }
        
}
//salve