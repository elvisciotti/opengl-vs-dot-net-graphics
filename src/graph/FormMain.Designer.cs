namespace ase1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.creagrafo_button = new System.Windows.Forms.Button();
            this.txt_principale = new System.Windows.Forms.RichTextBox();
            this.pictureBox_principale = new System.Windows.Forms.PictureBox();
            this.textBox_n = new System.Windows.Forms.TextBox();
            this.textBox_deg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.salva_button = new System.Windows.Forms.Button();
            this.load_button = new System.Windows.Forms.Button();
            this.Dijkstra_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonDisGraf = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.testLinee = new System.Windows.Forms.Button();
            this.clearB = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.labelScala = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSpostaNord = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBoxTra = new System.Windows.Forms.TextBox();
            this.TRASLA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTras = new System.Windows.Forms.Label();
            this.buttonzoomtut = new System.Windows.Forms.Button();
            this.labelSCGL = new System.Windows.Forms.Label();
            this.testPuntiB = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBoxMin = new System.Windows.Forms.CheckBox();
            this.textBoxNTest = new System.Windows.Forms.TextBox();
            this.textBoxMaxNodi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxNodiBMP = new System.Windows.Forms.CheckBox();
            this.checkBoxLabels = new System.Windows.Forms.CheckBox();
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.buttonStartUP = new System.Windows.Forms.Button();
            this.textBoxIncZoom = new System.Windows.Forms.TextBox();
            this.checkBoxPANImmed = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxarchi = new System.Windows.Forms.CheckBox();
            this.checkBoxNgoni = new System.Windows.Forms.CheckBox();
            this.textBoxLati = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_principale)).BeginInit();
            this.SuspendLayout();
            // 
            // creagrafo_button
            // 
            this.creagrafo_button.Location = new System.Drawing.Point(136, 3);
            this.creagrafo_button.Name = "creagrafo_button";
            this.creagrafo_button.Size = new System.Drawing.Size(76, 26);
            this.creagrafo_button.TabIndex = 0;
            this.creagrafo_button.Text = "CreaGrafo()";
            this.creagrafo_button.UseVisualStyleBackColor = true;
            this.creagrafo_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_principale
            // 
            this.txt_principale.Location = new System.Drawing.Point(3, 430);
            this.txt_principale.Name = "txt_principale";
            this.txt_principale.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txt_principale.Size = new System.Drawing.Size(218, 114);
            this.txt_principale.TabIndex = 1;
            this.txt_principale.Text = "";
            this.txt_principale.TextChanged += new System.EventHandler(this.txt_principale_TextChanged);
            // 
            // pictureBox_principale
            // 
            this.pictureBox_principale.Location = new System.Drawing.Point(227, 330);
            this.pictureBox_principale.Name = "pictureBox_principale";
            this.pictureBox_principale.Size = new System.Drawing.Size(790, 316);
            this.pictureBox_principale.TabIndex = 2;
            this.pictureBox_principale.TabStop = false;
            this.pictureBox_principale.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_principale_Paint);
            // 
            // textBox_n
            // 
            this.textBox_n.Location = new System.Drawing.Point(78, 57);
            this.textBox_n.Name = "textBox_n";
            this.textBox_n.Size = new System.Drawing.Size(52, 20);
            this.textBox_n.TabIndex = 3;
            this.textBox_n.Text = "150";
            // 
            // textBox_deg
            // 
            this.textBox_deg.Location = new System.Drawing.Point(175, 57);
            this.textBox_deg.Name = "textBox_deg";
            this.textBox_deg.Size = new System.Drawing.Size(27, 20);
            this.textBox_deg.TabIndex = 5;
            this.textBox_deg.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "n=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "deg =";
            // 
            // salva_button
            // 
            this.salva_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.salva_button.Location = new System.Drawing.Point(2, 27);
            this.salva_button.Name = "salva_button";
            this.salva_button.Size = new System.Drawing.Size(101, 26);
            this.salva_button.TabIndex = 7;
            this.salva_button.Text = "Salva su txt";
            this.salva_button.UseVisualStyleBackColor = false;
            this.salva_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // load_button
            // 
            this.load_button.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.load_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load_button.Location = new System.Drawing.Point(3, 1);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(101, 26);
            this.load_button.TabIndex = 8;
            this.load_button.Text = "Load txt";
            this.load_button.UseVisualStyleBackColor = false;
            this.load_button.Click += new System.EventHandler(this.load_button_Click);
            // 
            // Dijkstra_button
            // 
            this.Dijkstra_button.Location = new System.Drawing.Point(93, 617);
            this.Dijkstra_button.Name = "Dijkstra_button";
            this.Dijkstra_button.Size = new System.Drawing.Size(45, 21);
            this.Dijkstra_button.TabIndex = 9;
            this.Dijkstra_button.Text = "Dijkstra";
            this.Dijkstra_button.UseVisualStyleBackColor = true;
            this.Dijkstra_button.Click += new System.EventHandler(this.Dijkstra_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 627);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 25);
            this.button1.TabIndex = 11;
            this.button1.Text = "Salva  su DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 602);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 25);
            this.button2.TabIndex = 12;
            this.button2.Text = "Carica da Db";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // buttonDisGraf
            // 
            this.buttonDisGraf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisGraf.Location = new System.Drawing.Point(6, 110);
            this.buttonDisGraf.Name = "buttonDisGraf";
            this.buttonDisGraf.Size = new System.Drawing.Size(79, 40);
            this.buttonDisGraf.TabIndex = 16;
            this.buttonDisGraf.Text = "Disegna";
            this.buttonDisGraf.UseVisualStyleBackColor = true;
            this.buttonDisGraf.Click += new System.EventHandler(this.buttonDG_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 550);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(208, 14);
            this.progressBar1.TabIndex = 17;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 178);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 17);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.Text = "Bitmap";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(72, 178);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(103, 17);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.Text = "TAO senza VBO";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // testLinee
            // 
            this.testLinee.Location = new System.Drawing.Point(143, 606);
            this.testLinee.Name = "testLinee";
            this.testLinee.Size = new System.Drawing.Size(69, 21);
            this.testLinee.TabIndex = 20;
            this.testLinee.Text = "test linee";
            this.testLinee.UseVisualStyleBackColor = true;
            // 
            // clearB
            // 
            this.clearB.Location = new System.Drawing.Point(166, 402);
            this.clearB.Name = "clearB";
            this.clearB.Size = new System.Drawing.Size(52, 22);
            this.clearB.TabIndex = 21;
            this.clearB.Text = "clear";
            this.clearB.UseVisualStyleBackColor = true;
            this.clearB.Click += new System.EventHandler(this.test2_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Location = new System.Drawing.Point(107, 252);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(23, 23);
            this.buttonZoomIn.TabIndex = 23;
            this.buttonZoomIn.Text = "++";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIngrandisci_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(185, 253);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(27, 23);
            this.buttonZoomOut.TabIndex = 24;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomRiduci_Click);
            // 
            // labelScala
            // 
            this.labelScala.AutoSize = true;
            this.labelScala.Location = new System.Drawing.Point(151, 278);
            this.labelScala.Name = "labelScala";
            this.labelScala.Size = new System.Drawing.Size(22, 13);
            this.labelScala.TabIndex = 25;
            this.labelScala.Text = "1.0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 21);
            this.button3.TabIndex = 28;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonTrasOvest);
            // 
            // buttonSpostaNord
            // 
            this.buttonSpostaNord.Location = new System.Drawing.Point(30, 255);
            this.buttonSpostaNord.Name = "buttonSpostaNord";
            this.buttonSpostaNord.Size = new System.Drawing.Size(44, 21);
            this.buttonSpostaNord.TabIndex = 29;
            this.buttonSpostaNord.Text = "^";
            this.buttonSpostaNord.UseVisualStyleBackColor = true;
            this.buttonSpostaNord.Click += new System.EventHandler(this.buttonTrasNord);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(73, 278);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 21);
            this.button5.TabIndex = 30;
            this.button5.Text = ">";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonTrasEst);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(31, 298);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(43, 21);
            this.button6.TabIndex = 31;
            this.button6.Text = "v";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonTrasSud);
            // 
            // textBoxTra
            // 
            this.textBoxTra.Location = new System.Drawing.Point(31, 278);
            this.textBoxTra.Name = "textBoxTra";
            this.textBoxTra.Size = new System.Drawing.Size(41, 20);
            this.textBoxTra.TabIndex = 32;
            this.textBoxTra.Text = "50";
            // 
            // TRASLA
            // 
            this.TRASLA.AutoSize = true;
            this.TRASLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TRASLA.Location = new System.Drawing.Point(23, 230);
            this.TRASLA.Name = "TRASLA";
            this.TRASLA.Size = new System.Drawing.Size(67, 16);
            this.TRASLA.TabIndex = 33;
            this.TRASLA.Text = "TRASLA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "ZOOM";
            // 
            // labelTras
            // 
            this.labelTras.AutoSize = true;
            this.labelTras.Location = new System.Drawing.Point(5, 328);
            this.labelTras.Name = "labelTras";
            this.labelTras.Size = new System.Drawing.Size(81, 13);
            this.labelTras.TabIndex = 35;
            this.labelTras.Text = "Trasl. corr = 0,0";
            // 
            // buttonzoomtut
            // 
            this.buttonzoomtut.Location = new System.Drawing.Point(131, 298);
            this.buttonzoomtut.Name = "buttonzoomtut";
            this.buttonzoomtut.Size = new System.Drawing.Size(75, 23);
            this.buttonzoomtut.TabIndex = 36;
            this.buttonzoomtut.Text = "Reset vista";
            this.buttonzoomtut.UseVisualStyleBackColor = true;
            this.buttonzoomtut.Click += new System.EventHandler(this.buttonzoomtut_Click);
            // 
            // labelSCGL
            // 
            this.labelSCGL.AutoSize = true;
            this.labelSCGL.Location = new System.Drawing.Point(3, 394);
            this.labelSCGL.Name = "labelSCGL";
            this.labelSCGL.Size = new System.Drawing.Size(57, 13);
            this.labelSCGL.TabIndex = 38;
            this.labelSCGL.Text = "labelSCGL";
            // 
            // testPuntiB
            // 
            this.testPuntiB.Location = new System.Drawing.Point(143, 628);
            this.testPuntiB.Name = "testPuntiB";
            this.testPuntiB.Size = new System.Drawing.Size(75, 23);
            this.testPuntiB.TabIndex = 39;
            this.testPuntiB.Text = "test punti";
            this.testPuntiB.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(158, 573);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(42, 23);
            this.button7.TabIndex = 40;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBoxMin
            // 
            this.checkBoxMin.AutoSize = true;
            this.checkBoxMin.Checked = true;
            this.checkBoxMin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMin.Location = new System.Drawing.Point(123, 36);
            this.checkBoxMin.Name = "checkBoxMin";
            this.checkBoxMin.Size = new System.Drawing.Size(99, 17);
            this.checkBoxMin.TabIndex = 41;
            this.checkBoxMin.Text = "archi nodi vicini";
            this.checkBoxMin.UseVisualStyleBackColor = true;
            // 
            // textBoxNTest
            // 
            this.textBoxNTest.Location = new System.Drawing.Point(12, 576);
            this.textBoxNTest.Name = "textBoxNTest";
            this.textBoxNTest.Size = new System.Drawing.Size(89, 20);
            this.textBoxNTest.TabIndex = 42;
            this.textBoxNTest.Text = "5000";
            // 
            // textBoxMaxNodi
            // 
            this.textBoxMaxNodi.Location = new System.Drawing.Point(107, 404);
            this.textBoxMaxNodi.Name = "textBoxMaxNodi";
            this.textBoxMaxNodi.Size = new System.Drawing.Size(58, 20);
            this.textBoxMaxNodi.TabIndex = 43;
            this.textBoxMaxNodi.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "maxNodi Ridisegno";
            // 
            // checkBoxNodiBMP
            // 
            this.checkBoxNodiBMP.AutoSize = true;
            this.checkBoxNodiBMP.Location = new System.Drawing.Point(107, 110);
            this.checkBoxNodiBMP.Name = "checkBoxNodiBMP";
            this.checkBoxNodiBMP.Size = new System.Drawing.Size(48, 17);
            this.checkBoxNodiBMP.TabIndex = 45;
            this.checkBoxNodiBMP.Text = "Nodi";
            this.checkBoxNodiBMP.UseVisualStyleBackColor = true;
            // 
            // checkBoxLabels
            // 
            this.checkBoxLabels.AutoSize = true;
            this.checkBoxLabels.Location = new System.Drawing.Point(106, 155);
            this.checkBoxLabels.Name = "checkBoxLabels";
            this.checkBoxLabels.Size = new System.Drawing.Size(67, 17);
            this.checkBoxLabels.TabIndex = 46;
            this.checkBoxLabels.Text = "etichette";
            this.checkBoxLabels.UseVisualStyleBackColor = true;
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(226, 3);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(790, 316);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 47;
            this.simpleOpenGlControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseDown);
            this.simpleOpenGlControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseMove);
            this.simpleOpenGlControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleOpenGlControl1_MouseUp);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.ForeColor = System.Drawing.Color.Red;
            this.radioButton3.Location = new System.Drawing.Point(8, 201);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(93, 17);
            this.radioButton3.TabIndex = 48;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "TAO con VBO";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // buttonStartUP
            // 
            this.buttonStartUP.ForeColor = System.Drawing.Color.Red;
            this.buttonStartUP.Location = new System.Drawing.Point(6, 83);
            this.buttonStartUP.Name = "buttonStartUP";
            this.buttonStartUP.Size = new System.Drawing.Size(97, 23);
            this.buttonStartUP.TabIndex = 49;
            this.buttonStartUP.Text = "STARTUP VBO";
            this.buttonStartUP.UseVisualStyleBackColor = true;
            this.buttonStartUP.Click += new System.EventHandler(this.buttonStartUP_Click);
            // 
            // textBoxIncZoom
            // 
            this.textBoxIncZoom.Location = new System.Drawing.Point(143, 254);
            this.textBoxIncZoom.Name = "textBoxIncZoom";
            this.textBoxIncZoom.Size = new System.Drawing.Size(36, 20);
            this.textBoxIncZoom.TabIndex = 1;
            this.textBoxIncZoom.Text = "1";
            // 
            // checkBoxPANImmed
            // 
            this.checkBoxPANImmed.AutoSize = true;
            this.checkBoxPANImmed.Checked = true;
            this.checkBoxPANImmed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPANImmed.Location = new System.Drawing.Point(6, 354);
            this.checkBoxPANImmed.Name = "checkBoxPANImmed";
            this.checkBoxPANImmed.Size = new System.Drawing.Size(99, 17);
            this.checkBoxPANImmed.TabIndex = 50;
            this.checkBoxPANImmed.Text = "PAN Immediato";
            this.checkBoxPANImmed.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(200, 198);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 23);
            this.button4.TabIndex = 51;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkBoxarchi
            // 
            this.checkBoxarchi.AutoSize = true;
            this.checkBoxarchi.Location = new System.Drawing.Point(127, 88);
            this.checkBoxarchi.Name = "checkBoxarchi";
            this.checkBoxarchi.Size = new System.Drawing.Size(49, 17);
            this.checkBoxarchi.TabIndex = 52;
            this.checkBoxarchi.Text = "archi";
            this.checkBoxarchi.UseVisualStyleBackColor = true;
            // 
            // checkBoxNgoni
            // 
            this.checkBoxNgoni.AutoSize = true;
            this.checkBoxNgoni.Location = new System.Drawing.Point(107, 132);
            this.checkBoxNgoni.Name = "checkBoxNgoni";
            this.checkBoxNgoni.Size = new System.Drawing.Size(52, 17);
            this.checkBoxNgoni.TabIndex = 53;
            this.checkBoxNgoni.Text = "ngoni";
            this.checkBoxNgoni.UseVisualStyleBackColor = true;
            // 
            // textBoxLati
            // 
            this.textBoxLati.Location = new System.Drawing.Point(158, 131);
            this.textBoxLati.Name = "textBoxLati";
            this.textBoxLati.Size = new System.Drawing.Size(42, 20);
            this.textBoxLati.TabIndex = 54;
            this.textBoxLati.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1016, 676);
            this.Controls.Add(this.textBoxLati);
            this.Controls.Add(this.checkBoxNgoni);
            this.Controls.Add(this.checkBoxarchi);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBoxPANImmed);
            this.Controls.Add(this.textBoxIncZoom);
            this.Controls.Add(this.buttonStartUP);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Controls.Add(this.checkBoxLabels);
            this.Controls.Add(this.checkBoxNodiBMP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMaxNodi);
            this.Controls.Add(this.textBoxNTest);
            this.Controls.Add(this.checkBoxMin);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.testPuntiB);
            this.Controls.Add(this.labelSCGL);
            this.Controls.Add(this.buttonzoomtut);
            this.Controls.Add(this.labelTras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TRASLA);
            this.Controls.Add(this.textBoxTra);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonSpostaNord);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelScala);
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.clearB);
            this.Controls.Add(this.testLinee);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonDisGraf);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Dijkstra_button);
            this.Controls.Add(this.load_button);
            this.Controls.Add(this.salva_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_deg);
            this.Controls.Add(this.textBox_n);
            this.Controls.Add(this.pictureBox_principale);
            this.Controls.Add(this.txt_principale);
            this.Controls.Add(this.creagrafo_button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_principale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button creagrafo_button;
        private System.Windows.Forms.RichTextBox txt_principale;
        private System.Windows.Forms.PictureBox pictureBox_principale;
        private System.Windows.Forms.TextBox textBox_n;
        private System.Windows.Forms.TextBox textBox_deg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button salva_button;
        private System.Windows.Forms.Button load_button;
        private System.Windows.Forms.Button Dijkstra_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonDisGraf;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button testLinee;
        private System.Windows.Forms.Button clearB;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Label labelScala;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSpostaNord;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBoxTra;
        private System.Windows.Forms.Label TRASLA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTras;
        private System.Windows.Forms.Button buttonzoomtut;
        private System.Windows.Forms.Label labelSCGL;
        private System.Windows.Forms.Button testPuntiB;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBoxMin;
        private System.Windows.Forms.TextBox textBoxNTest;
        private System.Windows.Forms.TextBox textBoxMaxNodi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxNodiBMP;
        private System.Windows.Forms.CheckBox checkBoxLabels;
        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button buttonStartUP;
        private System.Windows.Forms.TextBox textBoxIncZoom;
        private System.Windows.Forms.CheckBox checkBoxPANImmed;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBoxarchi;
        private System.Windows.Forms.CheckBox checkBoxNgoni;
        private System.Windows.Forms.TextBox textBoxLati;
    }
}

