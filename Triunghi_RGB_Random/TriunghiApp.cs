using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK.Input;
using System.IO;
namespace Triunghi_RGB_Random
{   
    /// <summary>
    /// Laboratorul3_EGC,3133a
    /// </summary>
   class TriunghiApp:GameWindow
    {
        private List<Vector3> vertices;  //am declarat o lista de vector3 pentru varfuri
        private List<Color> vertexColors;
        private Randomizer rando;
        private float angleY; //unghiul Y
        private float angleX; //unghiul x;
        private KeyboardState previousKeyboard;
        private Color startColor ;   //declarare start culoare
       private Color endColor ;    //declarare sfarsit culoare
        private float globalFactor = 0.0f;
                   // Culoarea curentă a triunghiului
        private float alphaChannel;
        public TriunghiApp():base(800,600,new GraphicsMode(32, 8, 0, 24))
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
            this.startColor = Color.Red;
             this.endColor = Color.Blue;

           

            vertices = LoadVertices("Triunghiuri.txt");//varfuri care memoreaza date  din fisiere
            vertexColors = new List<Color>(vertices.Count);
            // Inițializare culori pentru fiecare vertex
            for (int i = 0; i < vertices.Count; i++)
            {
                vertexColors.Add(rando.GetRandomColor()); // Culoare aleatorie pentru fiecare vertex
            }

        }

  
        private List<Vector3> LoadVertices(string NumeFisier)
        {
            var vertices = new List<Vector3>();      // o lista de varfuri
            foreach (var line in File.ReadAllLines(NumeFisier))   //citeste datele din fisier
            {
                var parts = line.Split(' ');
                if(parts.Length==3)
                     vertices.Add(new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]))); //adaugarea varfurilor in fisierul de date
            }
            return vertices;
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState thisKeyboard = Keyboard.GetState();

            if (thisKeyboard[Key.Escape])
            { Exit(); }
            if (thisKeyboard[Key.W] && !previousKeyboard[Key.W])
            {
                Color gradientColor = rando.GetGradientColor(startColor, endColor, globalFactor);
               GL.ClearColor(new Color4(gradientColor.R, gradientColor.G, gradientColor.B, gradientColor.A));
                globalFactor += 0.1f;
                if (globalFactor > 1.0f) globalFactor = 0.0f;  //resetare globalFactor
                for (int i = 0; i < vertexColors.Count; i++)
                {
                   float vertexFactor = (float)i / (vertexColors.Count - 1);// Factorul cuprins in intervalul [0,1]
                    vertexColors[i] = rando.GetGradientColor(startColor, endColor, vertexFactor);
                    Console.WriteLine($"Vertex {i + 1} (Gradient) - R: {vertexColors[i].R}, G: {vertexColors[i].G}, B: {vertexColors[i].B}, A: {vertexColors[i].A}");
                }
            }
            if (thisKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                alphaChannel = alphaChannel == 1.0f ? 0.5f : 1.0f; // Alternează între opac și semi-transparent
                
            }
            if (thisKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
                DiscoMode();   //modifica culorile gradiente
            }
        
            if (thisKeyboard[Key.A] && !previousKeyboard[Key.A])
            {
                GL.ClearColor(rando.GetRandomColor());
                for (int i = 0; i < vertexColors.Count; i++)
                {
                    vertexColors[i] = rando.GetRandomColor();
                    Console.WriteLine($"Vertex {i + 1} - R: {vertexColors[i].R}, G: {vertexColors[i].G}, B: {vertexColors[i].B}");
                }
            }

            previousKeyboard=thisKeyboard;
        }
      
       public void DrawTriunghi()
        {
            GL.Begin(PrimitiveType.Triangles);
            for(int i = 0; i < vertices.Count; i++)   //Desenare triunghiuri cu culori per Vertex
            {
                // se aplica culoarea fiecarui varf
                //Deseneaza varful
                // Verifică dacă există suficiente vârfuri pentru un triunghi
                if (i < vertexColors.Count)
                {
                    Color color = vertexColors[i];
                    GL.Color4(color.R, color.G, color.B, (byte)(alphaChannel * 255)); // Aplică canalul alpha
                    GL.Vertex3(vertices[i]);
                }
            }
            GL.End();

        }
        public void DiscoMode()
        {
            for (int i = 0; i < vertexColors.Count; i++)
            {
                vertexColors[i] = rando.GetRandomColor();
            }
        }    //DiscoMode
        protected override void OnRenderFrame(FrameEventArgs e)   //Randarea
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            GL.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(angleY, 0.0f, 1.0f, 0.0f);
            DrawTriunghi();
            SwapBuffers();
        }
    }
}