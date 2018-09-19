using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace Program2
{
   public partial class Form1 : Form
   {
      private Matrix4 projMat;
      private Figure fig;

      public Form1()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called during the initial load and sets up the matrix and view
      /// </summary>
      /// <param name="sender">sender</param>
      /// <param name="e">eventarg</param>
      private void Form1_Load(object sender, EventArgs e)
      {
         GL.Enable(EnableCap.DepthTest);
         GL.MatrixMode(MatrixMode.Projection);
         projMat = Matrix4.CreateOrthographic(10.0f, 10.0f, 0.5f, 50.0f);
         GL.LoadMatrix(ref projMat);
      }

      /// <summary>
      /// Displays the axes and the figure if it is loaded
      /// </summary>
      private void ShowFigure()
      {
         GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
         projMat = Matrix4.LookAt(tbXEye.Value, tbYEye.Value, tbZEye.Value, 0, 0, 0, 0, 1, 0);
         GL.MatrixMode(MatrixMode.Modelview);
         GL.LoadMatrix(ref projMat);
         Axes.Instance.Show();
            if (fig != null)
            {
                fig.ShowFigure(projMat);
                lblCurrentFile.Text = "Current File: " + fig.Name;
            }
         glControl1.SwapBuffers();
      }

      /// <summary>
      /// Updates the view when figure is shown
      /// </summary>
      /// <param name="sender">sender</param>
      /// <param name="e">evenarg</param>
      private void Form1_Shown(object sender, EventArgs e)
      {
         ShowFigure();
      }

      /// <summary>
      /// Updates lblZVal and redraws graphics
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void trackBar3_Scroll(object sender, EventArgs e)
      {
         lblZVal.Text = "Z = " + tbZEye.Value.ToString();
         ShowFigure();
      }

      /// <summary>
      /// Updates lblXVal and redraws graphics
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void tbXEye_Scroll(object sender, EventArgs e)
      {
         lblXVal.Text = "X = " + tbXEye.Value.ToString();
         ShowFigure();
      }

      /// <summary>
      /// Updates lblYVal and redraws graphics
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void tbYEye_Scroll(object sender, EventArgs e)
      {
         lblYVal.Text = "Y = " + tbYEye.Value.ToString();
         ShowFigure();
      }

      /// <summary>
      /// Resets the tb(XYZ)Eye values to default of 5 and
      /// redraws graphics
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnResetView_Click(object sender, EventArgs e)
      {
         tbZEye.Value = 5;
         tbXEye.Value = 5;
         tbYEye.Value = 5;
         lblYVal.Text = "Y = " + tbYEye.Value.ToString();
         lblXVal.Text = "X = " + tbXEye.Value.ToString();
         lblZVal.Text = "Z = " + tbZEye.Value.ToString();
         ShowFigure();
      }

      /// <summary>
      /// Allows a file to be selected to be loaded
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void btnOpenFile_Click(object sender, EventArgs e)
      {
         if(openFile.ShowDialog() == DialogResult.OK)
         {
            fig = new Figure();
            fig.Load(openFile.FileName);
            ShowFigure();
         }

      }

      /// <summary>
      /// Redraws the graphics
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void Form1_Resize(object sender, EventArgs e)
      {
         ShowFigure();
      }
   }
}
