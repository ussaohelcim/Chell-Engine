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
        public void DrawTextInsideBox(string txt, Rectangle2D rectangle, float sizeFont, float spacim, bool wordWrap, Color color)
        {
            Rectangle rect = new Rectangle(rectangle.position.X,rectangle.position.Y,rectangle.width,rectangle.height);
            Raylib.DrawTextRec(GetFontDefault(),txt,rect,sizeFont,spacim,wordWrap,color);
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
        public Rectangle2D GetNewRectangle2D(float x, float y, float width, float height, Color color)
        {
            return new Rectangle2D(x,y,width,height,color.r,color.g,color.b,color.a);
        }
        public Line2D GetNewLine2D(Vector2 p1, Vector2 p2)
        {
            return new Line2D(p1,p2);
        }
        public Point2D GetNewPoint2D(Vector2 pos)
        {
            return new Point2D(pos);
        }
        public Ball2D GetNewBall2D(Vector2 center, float radius, Color cor)
        {
            return new Ball2D(center.X,center.Y,radius,cor.r,cor.g,cor.b,cor.a);
        }
        public Triangle2D GetNewTriangle2D(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
        {
            return new Triangle2D(v1, v2, v3, color);
        }
        public Object3D GetNewObject3D(string modelPath)
        {
           // Model m = LoadModel(modelPath);
            return new Object3D(modelPath);
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
    public class Program { public static void Main() { Console.WriteLine("hahahahahaha?"); } }
    public unsafe class Object3D
    {
        public Model model;
        public ModelAnimation* animations;
        public int animsCount = 0;
        public Vector3 position;
        public Vector3 rotation;
        Texture2D texture;
        public float size;

        public Object3D(string modelPath)
        {
            this.model = LoadModel(modelPath);
            this.size = 1;
            this.position = new Vector3(0,0,0); 
            AdicionarAnimacoes(modelPath);
        }
        void AdicionarAnimacoes(string modelPath)
        {

            IntPtr animsPtr = LoadModelAnimations(modelPath, ref animsCount);
            animations = (ModelAnimation*)animsPtr.ToPointer();
            
        }
        public int GetAnimationFrameCount(int numAnimation)
        {
            return animations[numAnimation].frameCount;
        }
        public void Animate(int numAnimacao, int frame)
        {
            //if(frame >= animations->frameCount) frame = 0;
            
            UpdateModelAnimation(model,animations[numAnimacao],frame);
        }
        public Object3D(Model model,float scale, float x, float y, float z)
        {
            this.model = model;
            this.position = new Vector3(x,y,z);
        }
        public static Object3D GetNew(string modelPath)
        {
            return new Object3D(modelPath);
        }
        public void Draw()
        {
            Raylib.DrawModel(this.model, this.position, size, Color.WHITE);
        }
        public void DrawWire()
        {
            Raylib.DrawModelWires(this.model,this.position,this.size,Color.GREEN);
        }
        public void Rotate(Vector3 degrees)
        {

        }
        public void Rotate(float xDegrees, float yDegrees, float zDegrees)
        {
            rotation = new Vector3(xDegrees * DEG2RAD, yDegrees * DEG2RAD,zDegrees * DEG2RAD);
            model.transform = Raymath.MatrixRotateXYZ(rotation);
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
    public class Point2D : IControler, IColisions2D
    {
        public Vector2 position { get; set; } 
        public Point2D(Vector2 pos)
        {
            position = pos;
        }
        public void Move(float x, float y)
        {
            position += new Vector2(x,y);
        }
        public void Draw()
        {
            Raylib.DrawCircleV(position,2,Color.BLACK);
        }

		public bool IsCollidingWithBall2D(Ball2D ball)
		{
			throw new NotImplementedException();
		}

		public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
		{
            Rectangle rect = new Rectangle(rectangle.position.X, rectangle.position.Y, rectangle.width, rectangle.height);
            return Raylib.CheckCollisionPointRec(position, rect);
		}
	}
    public class Line2D
    {
        public Point2D p1, p2;

        public Line2D( Vector2 p1, Vector2 p2)
        {
            this.p1 = new Point2D(p1);
            this.p2 = new Point2D(p2);
        }
        public void Draw(Color color)
        {
            
            Raylib.DrawLineV( p1.position, p2.position, color);
        }
        public void DrawThick(Color color, float thick)
        {
            Raylib.DrawLineEx(p1.position, p2.position, thick, color);
        }
    }
    public class Sprite : IControler
    {
        public Texture2D textura;
        //Rectangle retangulo;
        public Rectangle2D rectangle;
        public float rotation=0, scale=1;
        public Vector2 position { get; set; } 

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
            // Vector2 pos = new Vector2(rectangle.PosX,rectangle.PosY);
			//DrawTexture(textura, , , Color.WHITE);
            Raylib.DrawTextureEx(textura, rectangle.position, rotation, scale, Color.WHITE);
		}
        public void UpdatePosition(int x, int y)
        {
            rectangle.position = new Vector2(x,y);
            // rectangle.PosX= x;
            // rectangle.PosY= y;
        }

		public void Move(float x, float y)
		{
            rectangle.position += new Vector2(x,y);
			// rectangle.PosX += x;
            // rectangle.PosY += y;
		}
	}
    public class Ball2D : IControler
    {
        public float radius;
        public Vector2 position { get; set; } 
        public Color cor; //public Color(int r, int g, int b, int a);
       

        public Ball2D(float x, float y, float radius, int r, int g, int b, int a )
        {
            this.radius = radius;
            position = new Vector2(x,y);
            cor = new Color(r,g,b,a);
        }
        public void Draw()
        {

            Raylib.DrawCircleV(position,radius,cor);
            //Raylib.DrawCircle()
 
        }
        // public void DrawLine()
        // {
        //     Raylib.DrawCircleLines(position.X,position.Y,radius,cor);
        //     Raylib.DrawCircle
            
        // }

        public void Move(float x, float y)
        {
            // posX += x;
            // posY += y;
            // center.X = posX;
            // center.Y = posY;
            position += new Vector2(x,y);
            //center = new Vector2(posX,posY);
        }
        public void Destroy()
        {
            
        }
        public bool IsCollidingWithBall2D(Ball2D ball)
        {
            //Vector2 centro = new Vector2(posX,posY);
            return Raylib.CheckCollisionCircles(this.position, this.radius, ball.position, ball.radius);
        }
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
        {
            Rectangle rect = new Rectangle(rectangle.position.X,rectangle.position.Y,rectangle.width,rectangle.height);
            return Raylib.CheckCollisionCircleRec(this.position, this.radius, rect);
        }
        static public Ball2D GetNew(int x, int y, int radius, int r, int g, int b, int a )
        {
            Ball2D bolinha = new Ball2D(x,y,radius,r,g,b,a);
            return bolinha;
        }
    }
    public class Triangle3D
    {
        public Vector3 origin;
        public Vector3 v1, v2, v3;
        public Color color;
        Model mode;
        Mesh a = GenMeshPoly(3,5);
        void Draw()
        {
            Raylib.DrawTriangle3D(v1,v2,v3,color);
        }
        void Rotate()
        {
            Quaternion q = Raymath.QuaternionFromEuler(5,0,0);
        }
    }

	public class Triangle2D : IColisions2D
	{
        public Vector2 pivot;
		public Vector2 p1 { get ; set ; }
		public Vector2 p3 { get ; set ; }
		public Vector2 p2 { get ; set ; }
        Color color;
        public Triangle2D(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
        {
            p1 = v1;
            p2 = v2;
            p3 = v3;
            this.color = color;
        }
		public void Draw()
		{
			Raylib.DrawTriangle(p1,p2,p3,color);
		}
		public void DrawLines()
		{
			Raylib.DrawTriangleLines(p1,p2,p3,color);
		}

		public bool IsCollidingWithBall2D(Ball2D ball)
		{
			throw new NotImplementedException();
		}

		public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
		{
			throw new NotImplementedException();
		}
        public bool colisao()
        {
            return false;
        }

		public void Move(float x, float y)
		{
			p1 += new Vector2(x,y);
			p2 += new Vector2(x,y);
			p3 += new Vector2(x,y);
		}
        public void Rotate(float degress)
        {
           // Raymath.Vector2Rotate()
        }
	}
	public class Rectangle2D : IControler
	{	
		public Vector2 position { get; set; } 
        public float width, height;
        Color cor;

        public Rectangle2D(float width, float height, int r, int g, int b, int a )
        {
            this.width = width;
            this.height = height;
            position = new Vector2(0,0);
             
            cor = new Color(r,g,b,a);
        }
        public Rectangle2D(float x, float y, float width, float height, int r, int g, int b, int a )
        {
            position = new Vector2(x,y);
            this.width = width;
            this.height = height;
            cor = new Color(r,g,b,a);
        }
        public bool IsCollidingWithBall2D(Ball2D ball)
        {
            Rectangle rect = new Rectangle(position.X,position.Y,width,height);
            return Raylib.CheckCollisionCircleRec( ball.position, ball.radius, rect);
        }
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle)
        {
            if( this.position.X + this.width >= rectangle.position.X &&
                this.position.X <= rectangle.position.X + rectangle.width &&
                this.position.Y + this.height >= rectangle.position.Y &&
                this.position.Y <= rectangle.position.Y + rectangle.height
            )
            {
                return true;
            }
            return false;
        }

		public void Draw()
		{
			//DrawRectangle(PosX,PosY,width,height,cor);
            DrawRectangleV(position,new Vector2(width,height),cor);

            //DrawRectangleLinesEx(this.rect,10,Color.GREEN);
		}
        public void DrawLines(int lineThick, Color color)
        {
            //DrawRectangleLines(PosX,PosY,width,height,color);
            //Draretang
            Rectangle rect = new Rectangle(position.X,position.Y,width,height);
            Raylib.DrawRectangleLinesEx(rect,lineThick,color);
            
        }   

		public void Move(float x, float y)
		{
            position += new Vector2(x,y);
			// PosX += x;
            // PosY += y;
		}
        public void MoveByMiddle(float x, float y)
        {
            position += new Vector2(x+width/2,y+height/2);
        }
        public static Rectangle2D GetNew(int x, int y,int largura, int altura, int r, int g, int b, int a )
        {
            return new Rectangle2D(x,y,largura,altura,r,g,b,a);
        }
	}
	public interface IControler
    {
        public Vector2 position {get;set;}
        public void Move(float x, float y);
        public void Draw();
        
    }
    public interface IColisions2D
    {
        public bool IsCollidingWithBall2D(Ball2D ball);
        public bool IsCollidingWithRectangle2D(Rectangle2D rectangle);
    
    }
    public interface IColisions3D
    {

    }
    public interface IVelocity2D
    {
		public Vector2 Velocity { get; set; }
	}
        
    public interface IGravity2D
    {
  
        public float G {get;set;}
        public void PuxarGravidade();
    }
}
//salve