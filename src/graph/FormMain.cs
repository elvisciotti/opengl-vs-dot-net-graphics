using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections; // per ArrayList !!!!!!!!!!!!!
using System.IO; //per scrivere su file
using System.Data.OleDb;
//using SharpGL;
using System.Drawing.Imaging;
using Tao.OpenGl;
using Tao.Platform;
using Tao.FreeGlut;
//using Tao.Sdl;
//using Tao.Externals;
//using ISE;

//using System.Timers;

namespace ase1
{
    // il nodo sta nel namespace;
    public struct nodo //struct: ha anche il costruttore e davanti alle vars di va public|private
    {
        public string name;
        public int p, d, expanded, x, y; //p è il predecessore, extended indica se è stato esteso.
        public nodo(string s1, int i1, int i2, int i3, int i4, int i5)
        {
            name = s1;
            p = i1;
            d = i2;
            expanded = i3;
            x = i4;
            y = i5;
        }
    }
    
    
    public partial class Form1 : Form //partial: accedibile da + files
    {
        static int WIN_WIDTH = 790; //pari
        static int WIN_HEIGHT = 316; //dispari
        int N_ARCHI;
        int N_NODI;
        int N_NODI_ARRAY;
        int[] buffers = new int[2];
        //int nBuffer;
        int[] ARCHI_ARRAY;
        int[] NODI_ARRAY;
        //int STARTX = 0;
        //int STARTY = 0;

        bool grafoCreato = false;
        bool startUp = false;
        
        

        private static int SIZE_NODO = 20; //numero pari

        //uint TIPO_TEXTURE = OpenGL.TEXTURE_2D; //TEXTURE_2D
        //  The texture identifier.
        uint[] textures = new uint[4];

        //  Storage for the texture itself.
        Bitmap textureImage;
        Bitmap textureImageCifre; 
        
        
        
        private bool IS_BITMAP = false;
        //private bool STAMPA_DEBUG = false;

        private float[] COLOR_RED = new float[] { 255, 0, 0, 0 };
        private float[] COLOR_BLACK = new float[] { 0, 0, 0, 0 };
        private float[] COLOR_BLUE = new float[] { 0, 0, 255, 0 };
        private float[] COLOR_WHITE = new float[] { 255, 255, 255, 0 };

        

        private double ORTHO_X1;
        private double ORTHO_Y1;

        private double ORTHO_X2;
        private double ORTHO_Y2;

        
        public static int FILE_TAB_SPACE = 15;
       // private const int MAXNODI = 100000; //dichiararlo const 

        private const int INF = Int32.MaxValue;

        //private int N_NODI;                         //numero nodi
        int DEG;
        private nodo[] nodi ; //= new nodo[MAXNODI];  //creo array di nodi
        double[] A; //= new double[MAXNODI]; //distanze del nodo corrente dagli altri nodi
        int[] ind;// = new int[MAXNODI]; //parallelo ad A.  ind[i] contiene nome nodo a distanza A[i]

        private int m; //#archi

        private Bitmap DrawingArea; 

        Graphics g; //oggetto che poi andrà in picturebox
        //pennello, lo faccio globale così nn lo istanzio ogni volta con la Draw Graph()
        SolidBrush newbrush = new SolidBrush(Color.White);
        Pen nodpen = new Pen(Color.Red, 5);
        Pen arcpen = new Pen(Color.Black, 1);
        Pen camminopen = new Pen(Color.Brown, 4);
        Font textfont = new Font("Arial", 10);
        SolidBrush textbrush = new SolidBrush(Color.Black);
        
        //le classi di sistema stanno tutte nel namespace system
        System.Random rnd; // = new Random(STARTX);    //il primo numero è il 550esimo, di solito i primi sono motlo poco casuali

        ArrayList[] archi ;//= new ArrayList[MAXNODI];
        ArrayList[] d ;//= new ArrayList[MAXNODI];

        double SCALA_GL = 1.0;
        double SCALA_GL_ORTHO = 1.0;
        //double SCALA_GL_PREC = 1.0;

        double W;
        double H;

        double TRANSL_X = 0.0;
        double TRANSL_Y = 0.0;

        private int MAX_ARCHI_E_NODI_DRAW = 1000;
        //private int MAX_NODI_DRAW = 500;

        int START_CLICK_X;
        int START_CLICK_Y;

        private Cursor handCursor;
        bool MOUSE_DOWN = false;

        int INITIAL_GL_LEFT;
        int INITIAL_GL_TOP;

        ISE.FTFont fondo;

        //int dx, dy;

        public Form1() //costruttore/generatore classe, chiamato ad ogni istanziazione oggetto
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            simpleOpenGlControl1.Refresh();
            GlExtensionLoader.LoadExtension("ATI_draw_buffers");
            bool vboSupported = GlExtensionLoader.LoadExtension("GL_ARB_vertex_buffer_object");
            if (!vboSupported)
                MessageBox.Show("VBO non supportata !\r\n");

            handCursor = new Cursor("hand.cur");
            
            
            DrawingArea = new Bitmap(
                   this.pictureBox_principale.ClientRectangle.Width,
                   this.pictureBox_principale.ClientRectangle.Height,
                   System.Drawing.Imaging.PixelFormat.Format24bppRgb
                   );

            //gl.PointSize(SIZE_NODO);
           /// gl.LineWidth(1);

            resetVarGlobaliTrasfGL();  
            caricaMatrGL();
            simpleOpenGlControl1.Refresh();
              
            inizializzaBitmap();

            //associo evento rotellina mouse
            simpleOpenGlControl1.MouseWheel += new MouseEventHandler(openGLControl1_MouseWheel);

            inizializzaFreeType();
            MOUSE_DOWN = false;
            
        }

        private void settaOrthoByScale(double clickX, double clickY)
        {

            if (SCALA_GL_ORTHO <= 0)
                SCALA_GL_ORTHO = 0.05;

            //finestra finale dimensioni
            W = WIN_WIDTH / SCALA_GL_ORTHO; // 680 600 500 400 ...
            H = WIN_HEIGHT / SCALA_GL_ORTHO;
            //definisci ortho

            ORTHO_X1 = clickX - W / 2;
            ORTHO_Y1 = clickY - H / 2;

            //
            ORTHO_X2 = clickX + W / 2;
            ORTHO_Y2 = clickY + H / 2;

            debugLabel();
        }

        //bottone Disegna
        private void buttonDG_Click(object sender, EventArgs e)
        {
            resetVarGlobaliTrasfGL();
            DrawGraph();
        }


        //disegna
        //crea grafo nella picture box leggendo nodi e archi da vettori nodi[] e archi[]
        void DrawGraph()
        {
            int i, x, y;
            
            //pictureBox
            if (radioButton1.Checked)
            {
                g = Graphics.FromImage(DrawingArea);

                DateTime startTime = DateTime.Now;
                DateTime stopTime; 
                g.FillRectangle(newbrush, 0, 0, WIN_WIDTH, WIN_HEIGHT);
                //leggo nodi e stampo
                for (i = 0; i < N_NODI; i++)
                {
                    x = nodi[i].x;
                    y = WIN_HEIGHT - nodi[i].y;

                    if (checkBoxNodiBMP.Checked)
                        g.DrawEllipse(nodpen, x, y, 5, 5);

                    //stampo etichetta nodo
                    if (checkBoxLabels.Checked)
                        g.DrawString(i.ToString(), textfont, textbrush, x+10, y-10);

                    if (checkBoxarchi.Checked)
                    {
                        for (int jjj = 0; jjj < archi[i].Count; jjj++)
                        {
                            Point p1 = new Point(nodi[i].x, WIN_HEIGHT - nodi[i].y);

                            int nodo_arr = Convert.ToInt32(archi[i][jjj]);
                            Point p2 = new Point(nodi[nodo_arr].x, WIN_HEIGHT - nodi[nodo_arr].y);
                            g.DrawLine(arcpen, p1, p2);
                        }
                    }
                }

                g.Dispose();
                this.pictureBox_principale.Invalidate();//cancello quello che c'era prima
               
                stopTime = DateTime.Now;
                TimeSpan duration = stopTime - startTime;
                txt_principale.AppendText("Grafo stampato in " + duration.Seconds + " " + Math.Round(duration.TotalMilliseconds) + " ms\r\n\r\n");
            }
            

            //senza VBO
            if (radioButton2.Checked)
            {
                if (!grafoCreato)
                {
                    MessageBox.Show("crea il grafo");
                    return;
                }
                
                caricaMatrGL();

                DateTime startTime = DateTime.Now;
                DateTime stopTime;

                //ciclo stampa nodi
                if (checkBoxNodiBMP.Checked)
                {
                    Gl.glColor3f(0.0f, 0.0f, 1.0f); //blu
                    
                    Gl.glPointSize(10.0f);
                    Gl.glBegin(Gl.GL_POINTS);
                    
                    for (i = 0; i < N_NODI; i++)
                    {
                        x = nodi[i].x;
                        y = nodi[i].y;

                        //nodiD++;
                        double newSizeNodo;
                        newSizeNodo = SIZE_NODO / SCALA_GL_ORTHO; //Convert.ToInt32(Math.Floor(
         
                        Gl.glVertex2i(x, y);
                    }
                    Gl.glEnd();
                   



                    //ngon( n,  cx,  cy,  raggio,  isPoligono);


                }


                //ciclo stampa nodi
                if (checkBoxNgoni.Checked)
                {
                    Gl.glColor3f(0.0f, 0.0f, 1.0f); //blu

                   
                    for (i = 0; i < N_NODI; i++)
                    {
                        x = nodi[i].x;
                        y = nodi[i].y;

                        ngon(Convert.ToInt32(textBoxLati.Text), x, y, 5, true );
                    }


                }

                //ciclo stampa labels
                if (checkBoxLabels.Checked)
                {

                    for (i = 0; i < N_NODI; i++)
                    {
                        x = nodi[i].x;
                        y = nodi[i].y;
                       
                        fondo.ftBeginFont();

                        Gl.glPushMatrix();
                        Gl.glColor3f(0f, 0f, 0f);
                        //Gl.glRasterPos2i(x , y );
                        Gl.glTranslatef(x, y, 0);

                        fondo.ftWrite(nodi[i].name);
                        fondo.ftEndFont();

                        Gl.glPopMatrix();

                    }
                    
                }

                // txt_principale.AppendText(" stampati: " + nodiD + " nodi(MAX= " + MAX_ARCHI_E_NODI_DRAW + ")\r\n");
                rnd = new Random();
                DEG = Convert.ToInt32(textBox_deg.Text);
                DEG = DEG != 0 ? DEG : 3;

                //ciclo stampa archi
                nero();

                if (checkBoxarchi.Checked)
                {
                    Gl.glBegin(Gl.GL_LINES);
                    //int numArchiStampati = 0;
                    for (i = 0; i < N_NODI; i++)
                    {
                        x = nodi[i].x;
                        y = nodi[i].y;


                        for (int jjj = 0; jjj < archi[i].Count; jjj++)
                        {
                            Point p1 = new Point(nodi[i].x, nodi[i].y);

                            int nodo_arr = Convert.ToInt32(archi[i][jjj]);
                            Point p2 = new Point(nodi[nodo_arr].x, nodi[nodo_arr].y);
                            //dafare controlla qua in mezzo se da stampare
                            Gl.glVertex2i(p1.X, p1.Y);
                            Gl.glVertex2i(p2.X, p2.Y);
                            // }
                        }
                        //}
                    }
                    Gl.glEnd();
                }

                Gl.glFlush();
                simpleOpenGlControl1.Refresh();

                stopTime = DateTime.Now;
                TimeSpan duration = stopTime - startTime;
                txt_principale.AppendText("Disegno senza VBO in " + duration.Seconds + " " + Math.Round(duration.TotalMilliseconds) + " ms\r\n\r\n");

            }


            //VBO. VRAM già riempita
            if (radioButton3.Checked)
            {
                if (!grafoCreato)
                {
                    MessageBox.Show("crea il grafo");
                    return;
                }

                if (!startUp)
                {
                    MessageBox.Show("fai startup");
                    return;
                } 
                
                drawVBO();
            }

            aggLabelScala();

            

        }


        void ngon(int n, double cx, double cy, double raggio, bool isPoligono)
        {
            int i;
            double x, y;
            double angolo;

            double pigreco = 3.14159265;

            if (n < 3) return;


            if (isPoligono)
                Gl.glBegin(Gl.GL_POLYGON);
            else
                Gl.glBegin(Gl.GL_LINE_LOOP);
            for (i = 0; i < n; i++)
            {

                x = cx + raggio * Math.Cos(2 * pigreco * i / n);
                y = cy + raggio * Math.Sin(2 * pigreco * i / n);
                Gl.glVertex2d(x, y);
            }
            Gl.glEnd();

        }


        private void debugLabel()
        {
            labelSCGL.Text = "Scala: " + Math.Round(SCALA_GL_ORTHO, 1) + " X1(" + Math.Round(ORTHO_X1) + ") Y1(" + Math.Round(ORTHO_Y1) + ") X2(" + Math.Round(ORTHO_X2) + ") Y2(" + Math.Round(ORTHO_Y2) + ")";

        }

        // rotellina mouse
        private void openGLControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            //openGLControl1.Cursor = new Cursor("risorse.zoom.cur");
            //SCALA_GL += 0.5;
            
            //double clickX = e.X;
            //double clickY = STARTY - e.Y;

            //se clicco in mezzo con scala=1
            //ORTHO_X1 = x - STARTX / 2;
            //ORTHO_Y1 = y - STARTY / 2;

            double delta = 120.0;
            double aggiunta = (Convert.ToDouble(e.Delta) / delta / 3);
            SCALA_GL_ORTHO += aggiunta; //zommando aumenta: 1 1.4 1.8 2.2 ...

            SCALA_GL_ORTHO *= (1 + aggiunta/20);

            settaOrthoByScale(e.X, WIN_HEIGHT - e.Y);

            DrawGraph();
          
            /*SCALA_GL_PREC = SCALA_GL;

            SCALA_GL = SCALA_GL + (e.Delta / 30.0 * 0.1);
            
            if (SCALA_GL <= 0)
                SCALA_GL = 0.05;

            double RAPP_SCALE = SCALA_GL / SCALA_GL_PREC;
            
            double x = Convert.ToDouble(e.X);
            double y = STARTY - e.Y;

            //TRANSL_X -= x / RAPP_SCALE;
            //TRANSL_Y -= y / RAPP_SCALE;

            TRANSL_X = -(x / SCALA_GL); //-x * 0.4;
            TRANSL_Y = -(y / SCALA_GL);//am -y * 0.4;

            DrawGraph(IS_BITMAP);
            aggiustaLabelTrasl();
            aggLabelScala();*/
        }

        //bottone crea grafo
        private void button1_Click(object sender, EventArgs e)
        {
            txt_principale.Clear();
            try
            {
                CreaGrafo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore : " + ex.Message, "Errore",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            grafoCreato = true;
            startUp = false;
            
            resetVarGlobaliTrasfGL();
        }




        

        private void buttonzoomtut_Click(object sender, EventArgs e)
        {
            /*
            openGLControl1.Refresh();
            DrawGraph(IS_BITMAP);*/

            resetVarGlobaliTrasfGL();
            DrawGraph();
        }

        private void test2_Click(object sender, EventArgs e)
        {
            txt_principale.Clear();
        }

        private void Dijkstra_button_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < n; i++)

            Dijkstra(0);

            //disegno connessioni nodi con i p

            for (int i = 0; i < N_NODI; i++)
            {
                int nodo_arr = nodi[i].p;

                if (nodo_arr < N_NODI)
                {
                    Point p1 = new Point(nodi[i].x, nodi[i].y);
                    Point p2 = new Point(nodi[nodo_arr].x, nodi[nodo_arr].y);

                    //if (nodi[nodo_arr].p != 0)
                    g.DrawLine(camminopen, p1, p2);
                }
            }

        }

        private void pictureBox_principale_Paint(object sender,
                                      System.Windows.Forms.PaintEventArgs e)
        {

            Graphics oGraphics;

            oGraphics = e.Graphics;

            oGraphics.DrawImage(DrawingArea,
                                 0, 0,
                                 DrawingArea.Width,
                                 DrawingArea.Height);


        }

        private void txt_principale_TextChanged(object sender, EventArgs e)
        {
            txt_principale.ScrollToCaret();
        }


        
        
        private void caricaMatrGL()
        {
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);

            //Gl.glViewport(-WIN_WIDTH / 2, -WIN_HEIGHT / 2, WIN_WIDTH*2, WIN_HEIGHT*2);
            Gl.glLoadIdentity();

            //Gl.glOrtho(STARTX, WIN_WIDTH + STARTX, STARTY, WIN_HEIGHT + STARTY, -100, 100);
            
            Gl.glOrtho(ORTHO_X1, ORTHO_X2, ORTHO_Y1, ORTHO_Y2, -100, 100);

             //Gl.glOrtho(0, 790, 0, 316, -100, 100);
            

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            simpleOpenGlControl1.Refresh();
            //Gl.Scale(SCALA_GL, SCALA_GL, 1.0);
        }

        /*void ridisegnaOpenGL()
        {
           //uint []vboId1;
           //gl.GenBuffersARB(1, 0);
           
            caricaMatrGL();

            DateTime startTime = DateTime.Now;

            drawVBO();

            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;

            txt_principale.AppendText("Grafo ridisegnato in " + Math.Round(duration.TotalMilliseconds) + " ms\r\n\r\n");

            //DrawGraph(IS_BITMAP);
            debugLabel();

        }*/

        void rosso()
        {
            Gl.glColor3f(1.0f, 0.0f, 0.0f);//vertici
        }

        void nero()
        {
            Gl.glColor3f(0.0f, 0.0f, 0.0f);//vertici
        }
        

        void drawVBO()
        {
            caricaMatrGL();
            
            
            //archi
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffers[0]);
            DateTime startTime = DateTime.Now;
            rosso();
            Gl.glEnable(Gl.GL_VERTEX_ARRAY);
            Gl.glVertexPointer(2, Gl.GL_INT, 0, (IntPtr)0);
            Gl.glDrawArrays(Gl.GL_LINES, 0, N_ARCHI);
            Gl.glDisable(Gl.GL_VERTEX_ARRAY);

            //nodi
            if (checkBoxNodiBMP.Checked)
            {
                //Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, buffers[0]);
                Gl.glColor3f(0.0f, 0.0f, 1.0f); //blu
                Gl.glPointSize(10.0f);
                Gl.glEnable(Gl.GL_VERTEX_ARRAY);
                Gl.glVertexPointer(1, Gl.GL_INT, 0, (IntPtr)0);
                Gl.glDrawArrays(Gl.GL_POINTS, N_ARCHI, N_NODI_ARRAY);
                
                Gl.glDisable(Gl.GL_VERTEX_ARRAY);
            }

            
            Gl.glFlush();
            simpleOpenGlControl1.Refresh();
            TimeSpan span = DateTime.Now - startTime;
            txt_principale.AppendText("Disegno da VRAM in " + span.Seconds + " " + span.Milliseconds + " ms\r\n");


        }

        //zooom
        private void buttonZoomIngrandisci_Click(object sender, EventArgs e)
        {
            //stampaBitmap(0, 0, STARTX, STARTY);
            //return;
            
            
            SCALA_GL_ORTHO *= 1 + Convert.ToDouble(textBoxIncZoom.Text) / 10;
            //zoom nel mezzo
            settaOrthoByScale(WIN_WIDTH / 2, WIN_HEIGHT / 2);

            DrawGraph();


            
        }

        private void buttonZoomRiduci_Click(object sender, EventArgs e)
        {
            SCALA_GL_ORTHO *= 1 - Convert.ToDouble(textBoxIncZoom.Text)/10;

            settaOrthoByScale(WIN_WIDTH / 2, WIN_HEIGHT / 2);

            /*ORTHO_X2 *= 1.2; ORTHO_Y2 *= 1.2;
            ORTHO_X1 *= 0.8; ORTHO_Y1 *= 0.8;*/

            DrawGraph();
        }


        


        private void buttonTrasNord(object sender, EventArgs e)
        {
            ORTHO_Y1 += Convert.ToInt32(textBoxTra.Text);
            ORTHO_Y2 += Convert.ToInt32(textBoxTra.Text);

            DrawGraph();

           
        }

        private void buttonTrasSud(object sender, EventArgs e)
        {
            ORTHO_Y1 -= Convert.ToInt32(textBoxTra.Text);
            ORTHO_Y2 -= Convert.ToInt32(textBoxTra.Text);

            DrawGraph();
        }

        private void buttonTrasEst(object sender, EventArgs e)
        {
            ORTHO_X1 += Convert.ToInt32(textBoxTra.Text);
            ORTHO_X2 += Convert.ToInt32(textBoxTra.Text);

            DrawGraph();
        }

        private void buttonTrasOvest(object sender, EventArgs e)
        {
            ORTHO_X1 -= Convert.ToInt32(textBoxTra.Text);
            ORTHO_X2 -= Convert.ToInt32(textBoxTra.Text);

            DrawGraph();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //leggiRisoluzione();
            DrawGraph();
        }

        
              

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            //labelSCGL.Text = e.X + " " + e.Y;
            if (MOUSE_DOWN)
            {
               
            }
            
        }



        


        private void button1_Click_2(object sender, EventArgs e)
        {
            salvaSuDb();

        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            caricaDaDb();
        }


        /// SALVA TXT
        private void button2_Click(object sender, EventArgs e)
        {
            SavetxtToFile();
        }




        private void load_button_Click(object sender, EventArgs e)
        {
            Loadtxt();
            grafoCreato = true;
            startUp = false;
            txt_principale.Clear();
            resetVarGlobaliTrasfGL();
        }

        private void buttonStartUP_Click(object sender, EventArgs e)
        {
            if (!grafoCreato)
            {
                MessageBox.Show("crea il grafo");
                return;
            }

            radioButton3.Checked = true;

            int x, y;
            startUp = true;


            DateTime startTime = DateTime.Now;

            List<int> archiList = new List<int>();
            List<int> nodiList = new List<int>();
             
            //riempio liste
            for (int i = 0; i < N_NODI; i++)
            {
                x = nodi[i].x;
                y = nodi[i].y;
                nodiList.Add(x);
                nodiList.Add(y);

                for (int jjj = 0; archi[i]!=null && jjj < archi[i].Count; jjj++)
                {
                    //numArchiStampati++;
                    Point p1 = new Point(nodi[i].x, nodi[i].y);

                    int nodo_arr = Convert.ToInt32(archi[i][jjj]);
                    Point p2 = new Point(nodi[nodo_arr].x, nodi[nodo_arr].y);
                    
                    archiList.Add(p1.X);
                    archiList.Add(p1.Y);

                    archiList.Add(p2.X);
                    archiList.Add(p2.Y);
                }
            }

            List<int> archiENodiList = new List<int>();
            archiENodiList.AddRange(archiList);
            archiENodiList.AddRange(nodiList);

            //buffer archi
            ARCHI_ARRAY = archiList.ToArray();
            N_ARCHI = ARCHI_ARRAY.Length / 2;

            NODI_ARRAY = nodiList.ToArray();
            N_NODI_ARRAY = NODI_ARRAY.Length / 2;
            
            Gl.glDeleteBuffers(1, buffers);

            txt_principale.AppendText("VRAM svuotata !\r\n");

            //genero buffer
            Gl.glGenBuffers(1, buffers);
            //attivo buffer
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, buffers[0]);
            
            //copio dati (archi e poi nodi) in buffer
            int[] ARRAY_ARCHI_E_NODI = archiENodiList.ToArray();
            Gl.glBufferData(
                    Gl.GL_ELEMENT_ARRAY_BUFFER,
                    (IntPtr)((ARRAY_ARCHI_E_NODI.Length) * sizeof(int)),
                    ARRAY_ARCHI_E_NODI, 
                    Gl.GL_STATIC_DRAW
                );

            TimeSpan span = DateTime.Now - startTime;
            txt_principale.AppendText("VRAM riempita in " + span.Seconds + " " + span.Milliseconds + " ms\r\n");
        }


       



        private void button7_Click(object sender, EventArgs e)
        {
            caricaMatrGL();
        }


        

        private void inizializzaBitmap()
        {
                /*



            Gl.Enable(OpenGL.TEXTURE_2D);
            //gl.AlphaFunc(OpenGL.LESS, 255);
            //gl.BlendFunc(OpenGL.LESS, 255);

            texture.Create(Gl, BMP_NODO);

            textureC.Create(Gl, BMP_CIFRE);


            */

            //            texture.Bind(gl);

        }


        private void bindTex(int n)
        {
            /*if (n == 0)
                texture.Bind(gl);
            else if (n == 1)
                textureC.Bind(gl);
            else if (n == 2)
                textureB.Bind(gl);*/
        }


       

        
        private void stampaBitmap(double startx, double starty, double w, double h)
        {
            //SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            //gl.Clear(OpenGL.COLOR_BUFFER_BIT | OpenGL.DEPTH_BUFFER_BIT);
            //gl.LoadIdentity();

            /*
            gl.Begin(OpenGL.QUADS);
            gl.LineWidth(0);
            gl.Color(COLOR_WHITE);

            gl.TexCoord(0.0f, 0.0f); gl.Vertex(startx, starty);	// Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(startx + w, starty);	// Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(startx + w, starty + h);		// Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(startx, starty + h);	// Top Left Of The Texture and Quad
            gl.End();*/

        }

        private void stampaNumero(double startx, double starty, double h, String numS)
        {

            /*Gl.Begin(OpenGL.QUADS);
            gl.LineWidth(0);
            gl.Color(COLOR_WHITE);


            double w = BMP_CIFRE_W * h / BMP_CIFRE_H;
            int n, n1;

            //String numS = Convert.ToString(numero);
            //txt_principale.AppendText(numS);
            foreach (char c in numS.ToCharArray())
            {
                n = Convert.ToInt32("" + c);
            */
                //n1 = n + 1;
                //gl.TexCoord(0.1f * n, 0.0f/*0.0f*/); gl.Vertex(startx, starty);	// Bottom Left Of The Texture and Quad
                //gl.TexCoord(0.1f * n1 , 0.0f/*0.0f*/); gl.Vertex(startx + w, starty);	// Bottom Right Of The Texture and Quad
                //gl.TexCoord(0.1f * n1, 1.0f/*1.0f*/); gl.Vertex(startx + w, starty + h);		// Top Right Of The Texture and Quad
                //gl.TexCoord(0.1f * n, 1.0f/*1.0f*/); gl.Vertex(startx, starty + h);	// Top Left Of The Texture and Quad
                //startx += w;
           // }
           // gl.End();

        }

        private void settaNnodi(int nNodi)
        {
            rnd = new Random();
            textBox_n.Text = "" + N_NODI;
            alloca(N_NODI);
        }

        private void alloca(int n)
        {
            nodi = new nodo[n + 1];

            archi = new ArrayList[n + 1];
            d = new ArrayList[n + 1];

            A = new double[n + 1];
            ind = new int[n + 1];
        }


        private void aggLabelScala()
        {
            labelScala.Text = "" + Math.Round(/*SCALA_GL*/SCALA_GL_ORTHO, 3);
        }


        





        private void resetVarGlobaliTrasfGL()
        {

            ORTHO_X1 = ORTHO_Y1  = 0;

            ORTHO_X2 = WIN_WIDTH;
            ORTHO_Y2 = WIN_HEIGHT;

            SCALA_GL = 1.0;
            SCALA_GL_ORTHO = 1.0;

            aggLabelScala();
        }

      

        private void simpleOpenGlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            MOUSE_DOWN = true;
            //openGLControl1.Invalidate();
            // COUNTER = 0;

            //labelSCGL.Text += "down";
            simpleOpenGlControl1.Cursor = handCursor;
            START_CLICK_X = e.X;
            START_CLICK_Y = WIN_HEIGHT - e.Y;
        }

        private void simpleOpenGlControl1_MouseUp(object sender, MouseEventArgs e)
        {
            MOUSE_DOWN = false;
            simpleOpenGlControl1.Cursor = System.Windows.Forms.Cursors.Default;


            int dx = e.X - START_CLICK_X;
            int dy = WIN_HEIGHT - e.Y - START_CLICK_Y;

            ORTHO_X1 -= dx;
            ORTHO_X2 -= dx;

            ORTHO_Y1 -= dy;
            ORTHO_Y2 -= dy;

            DrawGraph();
        }

        private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MOUSE_DOWN && checkBoxPANImmed.Checked)
            {
                //MOUSE_DOWN = false;
                simpleOpenGlControl1.Cursor = handCursor;
                //simpleOpenGlControl1.Cursor = System.Windows.Forms.Cursors.Default;


                int dx = e.X - START_CLICK_X;
                int dy = WIN_HEIGHT - e.Y - START_CLICK_Y;

                ORTHO_X1 -= dx / SCALA_GL_ORTHO;
                ORTHO_X2 -= dx / SCALA_GL_ORTHO;

                ORTHO_Y1 -= dy / SCALA_GL_ORTHO;
                ORTHO_Y2 -= dy / SCALA_GL_ORTHO;

                DrawGraph();

                //MOUSE_DOWN = true;
                //openGLControl1.Invalidate();
                // COUNTER = 0;

                //labelSCGL.Text += "down";
                
                START_CLICK_X = e.X;
                START_CLICK_Y = WIN_HEIGHT - e.Y;

            }
        }

        private void inizializzaFreeType()
        {
            //return;
            int s = 19;
            fondo = new ISE.FTFont("C:\\WINDOWS\\Fonts\\arial.ttf", out s);
            
            fondo.ftRenderToTexture(12, 72/*DPI*/);
            //fondo.FT_ALIGN = ISE.FTFontAlign.FT_ALIGN_LEFT;

           
        }

    }

}