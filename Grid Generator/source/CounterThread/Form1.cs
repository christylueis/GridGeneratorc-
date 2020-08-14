using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CounterThread
{
    public partial class Form1 : Form
    {
        public int m_width; //Width of the grid cell

        public int m_Height; // The height of the Cell

        public int m_NoOfRows; // The Number Of Rows

        public int m_NoOfCols; // The Number Of Columns

        public int m_XOffset; //Offset from which drawing start
        public int m_YOffset;
        public int m_iIndex;
        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 50;
        public const int DEFAULT_NO_ROWS = 3;
        public const int DEFAULT_NO_COLS = 3;
        public const int DEFAULT_WIDTH = 40;
        public const int DEFAULT_HEIGHT = 40;

        public Form1()
        {
            Initialize();
            InitializeComponent();
            bThreadStatus = false;
        }


       

        public void Initialize()
        {
            //Put all the default values
            m_NoOfRows = DEFAULT_NO_ROWS;
            m_NoOfCols = DEFAULT_NO_COLS;
            m_width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_XOffset = DEFAULT_X_OFFSET;
            m_YOffset = DEFAULT_Y_OFFSET;

        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();//starts the thread
            bThreadStatus = true;

        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread.Suspend();//Pauses the thread
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread.Resume(); //Resumes the thread
        }




        public void ThreadCounter()
        {
          
            try
            {
                while (true)
                {
                   
                    DrawGrid();
                  
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show("exception occured");

            }

        }
      
        private void DrawGrid()
        {
           
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Blue);
            layoutPen.Width = 2;
            
            for (m_iIndex = 1; m_iIndex <= m_NoOfRows; m_iIndex++)
            {
               
                int X = DEFAULT_X_OFFSET;
                int Y = DEFAULT_Y_OFFSET;
                //Draw The rows
                for (int i = 0; i <= m_iIndex; i++)
                {
                    boardLayout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_iIndex, Y);
                    Y = Y + m_Height;
                }

                //Draw The Cols
                X = DEFAULT_X_OFFSET;
                Y = DEFAULT_Y_OFFSET;
                for (int j = 0; j <= m_iIndex; j++)
                {
                    boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_iIndex);
                    X = X + this.m_width;
                }
                Thread.Sleep(500);
                Invalidate();
            }
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            m_NoOfRows = 4;
           // m_NoOfCols = 4;
            this.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            m_NoOfRows = 5;
           // m_NoOfCols = 5;
            this.Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            m_NoOfRows = 6;
           // m_NoOfCols = 6;
            this.Refresh();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            m_NoOfRows = 7;
          //  m_NoOfCols = 7;
            this.Refresh();
        }
    }
}

