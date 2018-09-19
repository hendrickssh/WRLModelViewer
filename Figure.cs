/// Authors: Shane Hendricks and Kyle Hoffhein
/// Purpose: Defines a figure which stores vertex 
///          data to be displayed.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace Program2
{
    class Figure
    {
        private VertexData[] verts; /// Contains the vertices of the Figure
        private string name = null;
        private int vboHandle;
        private int vaoHandle;

        private Vector3 max;
        private Vector3 min;
        private Vector3 fixedPoint;
        private Vector3 translateAmount;
        private Matrix4 displayMatrix;

        /// <summary>
        /// Returns the file name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Returns the parsed file path with only the name remaining.
        /// </summary>
        /// <param name="file">The file path as a string</param>
        private void FileName(string file)
        {
            name = new System.IO.FileInfo(file).Name;
            name = name.Substring(0, name.IndexOf(".wrl"));
        }

        /// <summary>
        /// Populates verts with vertex data from a .wrl file fileName
        /// </summary>
        /// <param name="fileName">The .wrl file to provide vertex data</param>
        public void Load(string fileName)
        {
            VertexDataList list = new VertexDataList();
            FileName(fileName);
            list.LoadDataFromVRML(fileName);
            verts = list.VertexArray();
            CalculateFixedPoint();
            BindBuffers();
        }

        private void CalculateFixedPoint()
        {
            max = new Vector3(0, 0, 0);
            min = new Vector3(0, 0, 0);
            foreach(VertexData vertex in verts)
            {
                if (vertex.Position.X > max.X)
                    max.X = vertex.Position.X;
                if (vertex.Position.Y > max.Y)
                    max.Y = vertex.Position.Y;
                if (vertex.Position.Z > max.Z)
                    max.Z = vertex.Position.Z;

                if (vertex.Position.X < min.X)
                    min.X = vertex.Position.X;
                if (vertex.Position.Y < min.Y)
                    min.Y = vertex.Position.Y;
                if (vertex.Position.Z < min.Z)
                    min.Z = vertex.Position.Z;
            }

            fixedPoint.X = (max.X + min.X) / 2;
            fixedPoint.Y = (max.X + min.Y) / 2;
            fixedPoint.Z = (max.X + min.Z) / 2;
        }

        /// <summary>
        /// Creates the VBO and VAO and binds them to the cooresponding handles.
        /// </summary>
        private void BindBuffers()
        {
            GL.GenBuffers(1, out vboHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

            GL.GenVertexArrays(1, out vaoHandle);
            GL.BindVertexArray(vaoHandle);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)0);
            GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), (IntPtr)12);

            GL.BindVertexArray(0);
        }

        /// <summary>
        /// Displays the figure generated from the vertex data stored in verts
        /// </summary>
        public void ShowFigure(Matrix4 LookAtMatrix)
        {
            GL.BindVertexArray(vaoHandle);
            //GL.LoadMatrix(displayMatrix * Matrix4d.CreateTranslation());
            GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
            GL.BindVertexArray(0);
        }
    }
}
