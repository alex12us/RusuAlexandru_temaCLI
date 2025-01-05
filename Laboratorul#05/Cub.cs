using OpenTK;
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
        private List<Color4> vertexColors;
        private Randomizer rando;
        public Cub()
        {
            vertices = LoadVertices("cubulet.txt");
            vertexColors = new List<Color4>(vertices.Count);
            rando= new Randomizer();
            for (int i = 0; i < vertices.Count; i++) {
                vertexColors.Add(rando.RandomColor());
            }

        }
        private List<Vector3> LoadVertices(String NumeFisier)
        {
            var vertices = new List<Vector3>();
            foreach (var line in File.ReadAllLines(NumeFisier))   //citeste datele din fisier
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                    vertices.Add(new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]))); //adaugarea varfurilor in fisierul de date
            }
            return vertices;
        }
       public void Disco()
        {
            for(int i=0;i< vertices.Count; i++)
            {
                vertexColors[i]=rando.RandomColor();    
            }
        }
        public void DrawCub()
        {
            // Definirea triunghiurilor pentru cub
            int[][] triangles = new int[][]
            {
                new int[] { 0, 1, 2 }, new int[] { 0, 2, 3 },
                new int[] { 4, 5, 6 }, new int[] { 4, 6, 7 },
                new int[] { 0, 1, 5 }, new int[] { 0, 5, 4 },
                new int[] { 2, 3, 7 }, new int[] { 2, 7, 6 },
                new int[] { 0, 3, 7 }, new int[] { 0, 7, 4 },
                new int[] { 1, 2, 6 }, new int[] { 1, 6, 5 }
            };

            GL.Begin(PrimitiveType.Triangles);

            // Iterăm prin triunghiuri și desenăm fiecare vârf cu culoare corespunzătoare
            for (int triangleIndex = 0; triangleIndex < triangles.Length; triangleIndex++)
            {
                
                for (int i = 0; i < 3; i++)
                {
                    int vertexIndex = triangles[triangleIndex][i];
                    if (vertexIndex >= 0 && vertexIndex < vertices.Count)
                    {
                        

                        GL.Vertex3(vertices[vertexIndex]);
                        GL.Color4(vertexColors[vertexIndex]);

                        // Afișăm pe consolă coordonatele și culoarea vârfului pentru debugging
                        Console.WriteLine($"Vertex {vertexIndex}: Position {vertices[vertexIndex]}, Color {vertexColors[vertexIndex]}");
                    }

                    }
                }

            GL.End();
        }
    

    }
}
