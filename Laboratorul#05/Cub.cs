﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Drawing;
using System.IO;
namespace Laboratorul_05
{
   class Cub
    {
        private List<Vector3> vertices;
      //  private List<Color4> faceColors;
        private List<Color4> vertexColors;
        private Randomizer rando;
        private List<Color4> paleteCulori;

        public Cub()
        {
            vertices = LoadVertices("cubulet.txt");
           // faceColors = new List<Color4>(6);
            vertexColors = new List<Color4>(vertices.Count);
            rando= new Randomizer();
             InitializarePaletei();
            for (int i = 0; i < vertices.Count; i++) {
                vertexColors.Add(rando.RandomColor());
            }
           /* for (int i = 0; i < 6; i++) { 
                
                faceColors.Add(rando.RandomColor());    
            }*/

        }
        private void InitializarePaletei()
        {
            paleteCulori = new List<Color4>() {
                new Color4(1.0f,0.0f,0.0f,1.0f),
                new Color4(0.0f,1.0f,0.0f,1.0f),
                new Color4(0.0f,0.0f,1.0f,1.0f),
                new Color4(1.0f,1.0f,0.0f,1.0f),
                new Color4(1.0f,0.0f,1.0f,1.0f),
                new Color4(0.0f,1.0f,1.0f,1.0f)
            };

        }
        private List<Vector3> LoadVertices(String NumeFisier)
        {
            var vertices = new List<Vector3>();
            var lines = File.ReadLines(NumeFisier)
               .Select(line => line.Trim())
               .Where(line => !string.IsNullOrWhiteSpace(line));  //problema sunt spatiile goale,si a fost necesar pentru a citi linie cu linie din fisier
            foreach (var line in  lines)   //citeste datele din fisier
            { 
               

                var parts = line.Split(' ');
                if (parts.Length == 3)
                    vertices.Add(new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]))); //adaugarea varfurilor in fisierul de date
            }
            return vertices;
        }
        public void SetVertexColor(int vertexIndex,Color4 color) //setare la varful culorilor
        {
            if(vertexIndex>=0 && vertexIndex < vertices.Count)
            {
                vertexColors[vertexIndex] = color;
                Console.WriteLine($"Vertex:{vertexIndex} RGB: R={color.R} G={color.G} B={color.B}");
            }
            else
            {
                Console.WriteLine($"Index {vertexIndex} este invalid pentru vertex");
            }

        }
       public void Disco()
        {
            for(int i=0;i<vertices.Count; i++)
            {
               vertexColors[i]=rando.RandomColor();
                Console.WriteLine($"Vertex {i} RGB: R = {vertexColors[i].R}, G = {vertexColors[i].G}, B = {vertexColors[i].B}");
            }
        }
        public void AplicarePaleteCulori()
        {
            for (int i = 0; i <vertices.Count; i++)
            {
                vertexColors[i] = paleteCulori[i % paleteCulori.Count];
            }
        }
       /* public void ChangeFaceColor(int facePos,Color4 color)
        {
           if(facePos>=0 && facePos < faceColors.Count)
            {
                faceColors[facePos] = color;
            }
        } */
        public void DrawCub()
        {
            //Pozitia fiecarei fetei a unui cub
            int[][] faceIndices = new int[][]
             {
            new int[] { 0, 1, 2, 3 }, // Fața 1
            new int[] { 4, 5, 6, 7 }, // Fața 2
            new int[] { 0, 1, 5, 4 }, // Fața 3
            new int[] { 2, 3, 7, 6 }, // Fața 4
            new int[] { 0, 3, 7, 4 }, // Fața 5
            new int[] { 1, 2, 6, 5 }  // Fața 6
             };



            GL.Begin(PrimitiveType.Quads);
            for (int i = 0; i < faceIndices.Length; i++)
            {
               
                for (int j= 0; j < faceIndices[i].Length;j++)
                {
                       int vertexIndex = faceIndices[i][j];
                        GL.Vertex3(vertices[vertexIndex]);
                        GL.Color4(vertexColors[vertexIndex]);
                }
            }
            GL.End();

           }
        }
}
