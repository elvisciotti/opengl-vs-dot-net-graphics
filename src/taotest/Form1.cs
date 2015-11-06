using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Tao.OpenGl;
using Tao.Platform;

namespace taotest
{
    public partial class Form1 : Form
    {
        int WIN_WIDTH = 600; //pari
        int WIN_HEIGHT = 260; //dispari
        int N_LINEE;
        int[] buffers = new int[2];
        //int nBuffer;
        int[] vertici;
        int STARTX = 0;
        int STARTY = 0;

        private Bitmap DrawingArea;

        Pen arcpen = new Pen(Color.Black, 1);
        SolidBrush sfondoBrush = new SolidBrush(Color.White);
        SolidBrush poligBrush = new SolidBrush(Color.Black);
        Graphics g;

        Point[] points = new Point[4];
        DateTime startTime;


        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            //resetMatrice();
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            simpleOpenGlControl1.Refresh();
            GlExtensionLoader.LoadExtension("ATI_draw_buffers");
            bool vboSupported = GlExtensionLoader.LoadExtension("GL_ARB_vertex_buffer_object");
            if (!vboSupported)
                textBox2.AppendText("VBO non supportata !\r\n");
            N_LINEE = Convert.ToInt32(textBox1.Text);

            //GlExtensionLoader.LoadAllExtensions();



            DrawingArea = new Bitmap(
                   this.pictureBox_principale.ClientRectangle.Width,
                   this.pictureBox_principale.ClientRectangle.Height,
                   System.Drawing.Imaging.PixelFormat.Format24bppRgb
                   );

            Random rnd = new Random();

            if (false)
            {
                points[0] = new Point(5, 5);
                points[1] = new Point(WIN_WIDTH - 5, 5);
                points[2] = new Point(WIN_WIDTH - 5, WIN_HEIGHT - 5);
                points[3] = new Point(5, WIN_HEIGHT - 5);
            }
            if (true)
            {
                points[0] = new Point(5, 5);
                points[1] = new Point(25, 5);
                points[2] = new Point(25, 25);
                points[3] = new Point(5, 25);
            }


        }

        

        void resetMatrice()
        {
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);

            //Gl.glViewport(-WIN_WIDTH / 2, -WIN_HEIGHT / 2, WIN_WIDTH*2, WIN_HEIGHT*2);
            Gl.glLoadIdentity();
            Gl.glOrtho(STARTX, WIN_WIDTH + STARTX, STARTY, WIN_HEIGHT + STARTY, -1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
        }


        void rosso()
        {
            Gl.glColor3f(1.0f, 0.0f, 0.0f);//vertici
        }


        void disegnaCroceRossa()
        {
            rosso();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2i(10, 10);
            Gl.glVertex2d(WIN_WIDTH - 10, WIN_HEIGHT - 10);
            Gl.glVertex2d(WIN_WIDTH - 10, 10);
            Gl.glVertex2d(10, WIN_HEIGHT - 10);
            Gl.glEnd();
            Gl.glFlush();
            simpleOpenGlControl1.Refresh();
        }

        private void button1Dis(object sender, EventArgs e)
        {
            disegnaSenzaVBO();
        }

        void disegnaSenzaVBO()
        {
            N_LINEE = Convert.ToInt32(textBox1.Text); 
            
            resetMatrice();
            rosso();

            DateTime startTime = DateTime.Now;

            Gl.glBegin(Gl.GL_LINES);
            for (int j = 0; j < N_LINEE; j++)
            {
                Gl.glVertex2i(0, 0);
                Gl.glVertex2i(WIN_WIDTH, j /*% WIN_HEIGHT*/);
            }
            Gl.glEnd();
            Gl.glFlush();
            simpleOpenGlControl1.Refresh();

            //DateTime startTime = DateTime.Now;
            TimeSpan span = DateTime.Now - startTime;
            textBox2.AppendText("Disegnato (Senza VBO) in " + span.Milliseconds + " ms\r\n");

        }


        private void buttonReset(object sender, EventArgs e)
        {
            resetMatrice();
            Gl.glFlush();
            simpleOpenGlControl1.Refresh();
            N_LINEE = Convert.ToInt32(textBox1.Text);
            textBox2.Text = "";
            g = Graphics.FromImage(DrawingArea);
            g.FillRectangle(sfondoBrush, 0, 0, WIN_WIDTH, WIN_HEIGHT);
            g.Dispose();
            this.pictureBox_principale.Invalidate();//cancello quello che c'era prima
            

        }


        private void buttonGenVRAM(object sender, EventArgs e)
        {
            
            DateTime startTime = DateTime.Now;

            N_LINEE = Convert.ToInt32(textBox1.Text);

            vertici = new int[N_LINEE * 4];

            int indCorr = 0;
            for (int j = 0; j < N_LINEE; j++)
            {
                vertici[indCorr++] = 10;
                vertici[indCorr++] = 10;
                vertici[indCorr++] = WIN_WIDTH-10;
                vertici[indCorr++] = j;
            }

            Gl.glDeleteBuffers(1, buffers);
            textBox2.AppendText("VRAM svuotata !\r\n");

            Gl.glGenBuffers(1, buffers);
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, buffers[0]);

            int dataSize = (indCorr * sizeof(int));
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)dataSize, vertici, Gl.GL_STATIC_DRAW);

            TimeSpan span = DateTime.Now - startTime;
            textBox2.AppendText("VRAM riempita in " + span.Milliseconds + " ms\r\n");
            
        }


        private void buttonDrawVBO(object sender, EventArgs e)
        {
            drawVBO();
        }


        void drawVBO()
        {
            resetMatrice();
            DateTime startTime = DateTime.Now;

            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER/*Gl.GL_ELEMENT_ARRAY_BUFFER*/, buffers[0]);
            rosso();
            Gl.glEnable(Gl.GL_VERTEX_ARRAY);
            //Gl.glDrawElements(Gl.GL_LINES, N_LINEE, Gl.GL_INT, 0); //GL_FLOAT || GL_UNSIGNED_INT
            Gl.glVertexPointer(2, Gl.GL_INT, 0, (IntPtr)0);
            DateTime startTimeInt = DateTime.Now;
            Gl.glDrawArrays(Gl.GL_LINES, 0, N_LINEE);
            TimeSpan spanInt = DateTime.Now - startTimeInt;
            Gl.glDisable(Gl.GL_VERTEX_ARRAY);

            TimeSpan span = DateTime.Now - startTime;
            //Gl.glFlush();
            simpleOpenGlControl1.Refresh();

            textBox2.AppendText("Disegno da VRAM in " + span.Seconds + " " +  span.Milliseconds +" ms(" + spanInt.Milliseconds + " int)\r\n");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            disegnaCroceRossa();
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ScrollToCaret();
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            STARTY += 10;
            drawVBO();
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            STARTY -= 10;
            drawVBO();
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            STARTX -= 10;
            drawVBO();
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            STARTX += 10;
            drawVBO();
        }


        void ngon(int n, double cx, double cy, double raggio, bool isPoligono)
        {
	        int i;
            double x, y;
	        double angolo;
        	
	        double pigreco = 3.14159265;
        	
	        if(n<3) return;

	        
	        if (isPoligono)
		        Gl.glBegin(Gl.GL_POLYGON);
	        else
                Gl.glBegin(Gl.GL_LINE_LOOP);
	        for(i=0;i<n;i++)
	        {
		        
                x= cx + raggio * Math.Cos(2 * pigreco * i / n);
                y = cy + raggio * Math.Sin(2 * pigreco * i / n );
		        Gl.glVertex2d(x,y);
	        }
            Gl.glEnd();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetMatrice();
            rosso();

            DateTime startTime = DateTime.Now;
            int max = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < max; i++ )
                ngon(20, i % 500, i % 500, 10, false);

            Gl.glFlush();
            simpleOpenGlControl1.Refresh();
            
            TimeSpan span = DateTime.Now - startTime;

            textBox2.AppendText("" + span.Milliseconds + " ms\r\n");
            

        }

        private void pictureBox_principale_Paint(object sender, PaintEventArgs e)
        {
            Graphics oGraphics;

            oGraphics = e.Graphics;

            oGraphics.DrawImage(DrawingArea,
                                 0, 0,
                                 DrawingArea.Width,
                                 DrawingArea.Height);
        }

        //poly picture
        private void button2_Click_1(object sender, EventArgs e)
        {
            g = Graphics.FromImage(DrawingArea);
            g.FillRectangle(sfondoBrush, 0, 0, WIN_WIDTH, WIN_HEIGHT);

            N_LINEE = Convert.ToInt32(textBox1.Text);

            bool pieni = checkBoxPolPieni.Checked;
            startTime = DateTime.Now;
            
            for (int i=0; i<N_LINEE; i++)
            {
                if (pieni)
                    g.FillPolygon(poligBrush, points);
                else
                    g.DrawPolygon(arcpen, points);

            }
            
            g.Dispose();
            this.pictureBox_principale.Invalidate();//cancello quello che c'era prima
            
            TimeSpan span = DateTime.Now - startTime;
            textBox2.AppendText("" + span.Seconds + " " + span.Milliseconds + " ms\r\n");
  
        }

        
        //GL
        private void button4_Click(object sender, EventArgs e)
        {
            N_LINEE = Convert.ToInt32(textBox1.Text);

            resetMatrice();

            bool pieni = checkBoxPolPieni.Checked;
            startTime = DateTime.Now;
            for (int i = 0; i < N_LINEE; i++)
            {
                rosso();

                if (pieni)
                    Gl.glBegin(Gl.GL_POLYGON);
                else
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                 Gl.glVertex2i(points[0].X, points[0].Y);
                 Gl.glVertex2i(points[1].X, points[1].Y);
                 Gl.glVertex2i(points[2].X, points[2].Y);
                 Gl.glVertex2i(points[3].X, points[3].Y);
                 if (!pieni)
                     Gl.glVertex2i(points[0].X, points[0].Y);
                Gl.glEnd();
            }

            Gl.glFlush();
            
            simpleOpenGlControl1.Refresh();
            TimeSpan span = DateTime.Now - startTime;
            textBox2.AppendText("" + span.Seconds + " " + span.Milliseconds + " ms\r\n");
        }


       



        private void button5_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TimeSpan span2 = DateTime.Now - startTime;
            textBox2.AppendText("[" + span2.Seconds + " " + span2.Milliseconds + " ms]\r\n");

            
        }


    }
}