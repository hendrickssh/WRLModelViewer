/// Authors: Shane Hendricks and Kyle Hoffhein
/// Purpose: Defines a vertex data list which reads 
///          information from .wrl files and saves the
///          data as vertexdata.

using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;



[StructLayout(LayoutKind.Sequential, Pack = 1)]

public struct VertexData
{
   public Vector3 Position;
   public Vector3 Color;
   public Vector3 Normal;

   /// <summary>
   /// Defines a vertex based on position, color, and normal
   /// </summary>
   /// <param name="pos">XYZ coordinate position</param>
   /// <param name="col">RGB defined color</param>
   /// <param name="norm">Nomral vector</param>
   public VertexData(Vector3 pos, Vector3 col, Vector3 norm)
   {
      Position = pos;
      Color = col;
      Normal = norm;
   }

   /// <summary>
   /// Defines a vertex based on position and color
   /// </summary>
   /// <param name="pos">XYZ coordinate position</param>
   /// <param name="col">RGB defined color</param>
   public VertexData(Vector3 pos, Vector3 col)
   {
      Position = pos;
      Color = col;
      Normal = new Vector3(0.0F, 0.0F, 0.0F);
   }
}

// Assumes VRML file is good and everything is decomposed into triangles
public class VertexDataList
{
   private List<VertexData> vertList = new List<VertexData>(100);
   private StreamReader infile;

   /// <summary>
   /// Reads file at fullPathFileName to define verList VertexData
   /// based on Position, Color, and Normal.
   /// </summary>
   /// <param name="fullPathFileName">File Path of .wrl file</param>
   /// <returns>If load was successful</returns>
   public bool LoadDataFromVRML(string fullPathFileName)
   {
      vertList.Clear();
      try
      {
         infile = new StreamReader(fullPathFileName);
         if (infile == null)
            return false;

         bool done = false;
         while (!done)
         {
            if (!LookForInVMRL("coord Coordinate { point ["))
               done = true;
            else
            {
               ReadVertsForShapeInVRML();
            }
         }

         if (vertList.Count == 0)
            return false;
         return true;
      }
      catch
      {
         // File not in the expected format
         if (infile != null)
            infile.Close();
         return false;
      }
   }

   /// <summary>
   /// Returns the VertexData as an array
   /// </summary>
   /// <returns>verList as an array</returns>
   public VertexData[] VertexArray()
   {
      return vertList.ToArray();
   }



   // Assumes file has everything right, else get bad results and/or an exception is thrown
   // Assumes read pointer is at the line after "coord Coordinate { point ["
   /// <summary>
   /// Generates necessary Lists for verticies, color, and indicies
   /// based off of the loaded .wrl file.
   /// </summary>
   private void ReadVertsForShapeInVRML()
   {
      List<Vector3> verts = new List<Vector3>();
      List<Vector3> colors = new List<Vector3>();
      List<ushort> vertIndices = new List<ushort>();
      List<ushort> colorIndices = new List<ushort>();

      // You fill this in to see if you understand this file and the XMRL file.
      // This should be exactly 7 lines of code, each one a call to a private method.
      ReadVectListFromVMRL(verts);
      LookForInVMRL("coordIndex [");
      ReadIndicesListFromVRL(vertIndices);
      LookForInVMRL("color [");
      ReadVectListFromVMRL(colors);
      LookForInVMRL("colorIndex [");
      ReadIndicesListFromVRL(colorIndices);


      for (int i = 0; i < vertIndices.Count; i++)
      {
         VertexData v = new VertexData(verts[vertIndices[i]], colors[colorIndices[i]]);
         vertList.Add(v);
      }

      CalculateNormals();
   }

   private void CalculateNormals()
   {
      // This will be completed in a future program
      // I will explain then why we don't want to use the normals the Wings3d exports.
      // This assumes that Wings3d exports faces in CC order.

      // After we cover this, you should be able to write this in a small number of lines using Vector3 operations.
      // Hint:  Loop through, processing 3 verts at a time.
      // Note that in C#, you can't do: vertList[i + 2].Normal = normal;
      // You need to do something like: vertList[i + 2] = new VertexData(vertList[i + 2].Position, vertList[i + 2].Color, normal);

   }

   /// <summary>
   /// Determines if string s is located within the .wrl file
   /// </summary>
   /// <param name="s">string to be found</param>
   /// <returns>if string was found</returns>
   private bool LookForInVMRL(string s)
   {
      string inLine;
      bool found = false;
      while (!found)
      {
         inLine = infile.ReadLine();
         if (inLine == null)     // returns null if EOF
            return false;
         if (inLine.IndexOf(s) >= 0)
            found = true;
      }
      return true;
   }

   /// <summary>
   /// Reads the lines until ']' character is found and saves the values 
   /// to the specified List<Vector3> separating by ',' character
   /// </summary>
   /// <param name="vecList">The list where the values are stored</param>
   private void ReadVectListFromVMRL(List<Vector3> vecList)
   {
      string inLine;
      bool done = false;
      while (!done)
      {
         inLine = infile.ReadLine();
         Vector3 vect = new Vector3();
         string[] tokens = inLine.TrimStart().Split(new Char[] { ' ', ',' });
         for (int i = 0; i < 3; i++)
            vect[i] = float.Parse(tokens[i]);
         vecList.Add(vect);
         if (inLine.IndexOf(']') >= 0)
            done = true;
      }
   }

   // Assumes 3 indices per line, i.e., everything is decomposed into triangles
   /// <summary>
   /// Reades the lines until ']' character is found and saves the values
   /// to the specified List<ushort> sparating by ',' character
   /// </summary>
   /// <param name="indexList">The list where the values are stored</param>
   private void ReadIndicesListFromVRL(List<ushort> indexList)
   {
      string inLine;
      bool done = false;
      while (!done)
      {
         inLine = infile.ReadLine();
         string[] tokens = inLine.TrimStart().Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
         for (int i = 0; i < 3; i++)
            indexList.Add(ushort.Parse(tokens[i]));
         if (inLine.IndexOf(']') >= 0)
            done = true;
      }
   }
}