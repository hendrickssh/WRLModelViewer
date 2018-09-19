// You finish verts and comment this file.
// It uses the Singleton pattern

using System;

using OpenTK;
using OpenTK.Graphics.OpenGL;


public class Axes
{
   private static Axes _instance = null; // Creates a static instance of this class
   private int vboHandle;
   private int vaoHandle;

   /// <summary>
   /// Defines the vertices of the Axes including position, color, and normal.
   /// </summary>
   private VertexData[] verts =
   {
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(200.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 200.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 200.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f))
   };

   /// <summary>
   /// Creates the static intance of this class.
   /// </summary>
   public static Axes Instance
   {
      get
      {
         if (_instance == null)
            _instance = new Axes();
         return _instance;
      }
   }

   /// <summary>
   /// Creates the VBO and VAO and binds them to the cooresponding handles.
   /// </summary>
   private Axes()
   {
      // Make the Vertex Buffer Object (VBO) and Vertex Array Object (VAO)
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
   /// Displays the axes
   /// </summary>
   public void Show()
   {
      GL.BindVertexArray(vaoHandle);
      GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
      GL.BindVertexArray(0);
   }
}
