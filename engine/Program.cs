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

        public void EnableAudioDevice()
        {
            Raylib.InitAudioDevice();
        }

        public Sound LoadSoundFromFile(string path)
        {
            return Raylib.LoadSound(path);
        }   
        public void PlayThisSound(Sound sound)
        {
            Raylib.PlaySound(sound);
        }

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
        public bool IsHoldingKey(char key)
        {
            char k = Char.ToUpper(key);
            return Raylib.IsKeyDown((KeyboardKey)k);
            //KeyboardKey k = KeyboardKey.KEY_K;
            //return false;
        }
        public bool KeyPressed(char key)
        {
            char k = Char.ToUpper(key);
            return Raylib.IsKeyPressed((KeyboardKey)k);
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
        public Model GetMesh(string path)
        {
            return LoadModel(path);
        }
        public void StartMode3D(Cam3D cam)
        {
            Raylib.BeginMode3D(cam.camera);
        }
        public void FinishMode3D()
        {
            Raylib.EndMode3D();
        }
        public void StartMode2D(Cam2D cam)
        {
            Raylib.BeginMode2D(cam.camera);
        }
        public void FinishMode2D()
        {
            Raylib.EndMode2D();
        }

        
        public void CameraUpdate(Cam3D cam)
        {
            UpdateCamera(ref cam.camera);
        }
        public void SetModeCamera(Cam3D cam)
        {
            Raylib.SetCameraMode(cam.camera,CameraMode.CAMERA_FREE);
            
        }
        public void ShowGrid()
        {
            Raylib.DrawGrid(20,10);
        }
        public void SetIcon(string iconPath)
        {
            Image img = LoadImage(iconPath);
            Raylib.SetWindowIcon(img);
            //Raylib.SetWindowState(Con)
        }
        public void SetTitleWindow(string txt)
        {
            Raylib.SetWindowTitle(txt);

        }
        public void SetPositionWindow(int x, int y)
        {
            Raylib.SetWindowPosition(x,y);
        }   
        public void SetWinSize(int width, int height)
        {
            Raylib.SetWindowSize(width,height);
        
        }
        public Color GetNewColor(int r, int g, int b, int a)
        {
            return new Color(r,g,b,a);
        }
        public Vector2 GetNewVector2(float x, float y)
        {
            return new Vector2(x,y);
        }
        public Vector3 GetNewVector3(float x, float y, float z)
        {
            return new Vector3(x,y,z);
        }
        public Sprite GetNewSprite(string path)
        {
            return new Sprite(path);
        }
        public Vector2 AngleToNormalizedVector(float angle)
        {
            return new Vector2(MathF.Cos(angle),MathF.Sin(angle));
        }
        public float NormalizedVectorToAngle(Vector2 normalizedVector)
        {
            return MathF.Atan2(normalizedVector.Y,normalizedVector.X);
        }
        public float DeltaTime()
        {
            return Raylib.GetFrameTime();
        }

    }
    public class Program
    {
        public static void Main() {  }
    }
    public class Object3D
    {
        public Model model;

        public Vector3 position;
        Vector3 rotation;
        Texture2D texture;
        public float size;

        public Object3D(Model model)
        {
            this.model = model;
            this.size = 1;
            this.position = new Vector3(0,0,0);
        }
        public Object3D(Model model,float scale, float x, float y, float z)
        {
            this.model = model;
            this.position = new Vector3(x,y,z);
        }
        public static Object3D GetNew(Model model,float scale, float x, float y, float z)
        {
            return new Object3D(model,scale,x,y,z);
        }
        public static Object3D GetNew(Model model)
        {
            return new Object3D(model);
        }
        public void Draw()
        {
            Raylib.DrawModel(this.model, this.position, size, Color.WHITE);
        }
        public void DrawWire()
        {
            Raylib.DrawModelWires(this.model,this.position,this.size,Color.GREEN);
        }
        public void Rotate(float x, float y, float z)
        {
            model.transform = Raymath.MatrixRotateXYZ(new Vector3(x * DEG2RAD, y* DEG2RAD,z* DEG2RAD));
        }
    }
    public class Cam3D
    {
        public Camera3D camera;
        public Cam3D(float fovY)
        {
            camera = new Camera3D();
            camera.fovy = 90;
            camera.up = Vector3.UnitY;
            camera.projection = CameraProjection.CAMERA_PERSPECTIVE;
            camera.target = Vector3.Zero;
        }
        public void Rotate(float x, float y, float z)
        {
            Quaternion q = Quaternion.CreateFromYawPitchRoll(x,y,z);
            //camera.position = Raymath.MatrixRotateXYZ(new Vector3(x * DEG2RAD, y* DEG2RAD,z* DEG2RAD)) * camera.position;
        }
        public void Move(float x, float y, float z)
        {
            camera.position += new Vector3(x,y,z);
        }
        public static Cam3D GetNew(float fovY)
        {
            return new Cam3D(fovY);
        }
    }
    public class Cam2D
    {
        public Camera2D camera;
        public Cam2D(Vector2 target, Vector2 offset,  float zoom, float rotation)
        {
        
            Camera2D a = new Camera2D();
            a.offset = offset;
            a.zoom = zoom;
            a.target = target;
            a.rotation = rotation;
        }

        public void MoveOffset(float x, float y)
        {
            camera.offset += new Vector2(x,y);
        }
        public void UpdateZoom(float zoom)
        {
            camera.zoom = zoom;
        }
        public void UpdateRotation(float rotation)
        {
            camera.rotation = rotation;
        }
        public void UpdateOffset(float x, float y)
        {
            camera.offset = new Vector2(x,y);
        }
        public void UpdateTarget(Vector2 target)
        {
            camera.target = target;
        }
        public static Cam2D GetNew(Vector2 target, Vector2 offset,  float zoom, float rotation)
        {
            return new Cam2D(target,offset,zoom,rotation);
        }
    }
    public class Point2D : IPosicoes2D
    {
        public int PosX { get; set; }
		public int PosY { get; set; }

    }
    public class Sprite : IControle
    {
        public Texture2D textura;
        //Rectangle retangulo;
        public Rectangle2D rectangle;


        public Sprite(string path)
        {
            Image img = LoadImage(path);
            textura = LoadTextureFromImage(img);
            UnloadImage(img);
            rectangle = new Rectangle2D(textura.width,textura.height,254,254,254,254);
            
        }
        
		public void Destroy()
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
            //DrawTextureEx(textura,)
			DrawTexture(textura, rectangle.PosX, rectangle.PosY, Color.WHITE);
		}
        public void UpdatePosition(int x, int y)
        {
            rectangle.PosX= x;
            rectangle.PosY= y;
        }

		public void Move(int x, int y)
		{
			rectangle.PosX += x;
            rectangle.PosY += y;
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
        public void DrawLine()
        {
            Raylib.DrawCircleLines(posX,posY,radius,cor);
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
        public int width, height;
        Color cor;
        public Rectangle rect;
        public Rectangle2D(int largura, int altura, int r, int g, int b, int a )
        {
            this.width = largura;
            this.height = altura;
            PosY = 0;
            PosX = 0;
            
            rect = new Rectangle(PosX,PosY,largura,altura);
            cor = new Color(r,g,b,a);
        }
        public Rectangle2D(int x, int y,int largura, int altura, int r, int g, int b, int a )
        {
            PosX = x;
            PosY = y;
            this.width = largura;
            this.height = altura;
            cor = new Color(r,g,b,a);
        }
        public bool IsCollidingWithBall2D(Ball2D ball)
        {
            return Raylib.CheckCollisionCircleRec(ball.center,ball.radius,this.rect);
        }
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
        {
            if( this.PosX + this.width >= rectangle.PosX &&
                this.PosX <= rectangle.PosX + rectangle.width &&
                this.PosY + this.height >= rectangle.PosY &&
                this.PosY <= rectangle.PosY + rectangle.height
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
			DrawRectangle(PosX,PosY,width,height,cor);
            
            //DrawRectangleLinesEx(this.rect,10,Color.GREEN);
		}
        public void DrawLines(Color color)
        {
            DrawRectangleLines(PosX,PosY,width,height,color);
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