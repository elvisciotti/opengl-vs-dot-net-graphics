namespace taotest
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
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.buttonDis = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonreset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonvram = new System.Windows.Forms.Button();
            this.buttondraw = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonN = new System.Windows.Forms.Button();
            this.buttonS = new System.Windows.Forms.Button();
            this.buttonE = new System.Windows.Forms.Button();
            this.buttonO = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_principale = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxPolPieni = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_principale)).BeginInit();
            this.SuspendLayout();
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
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(178, 12);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(600, 260);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            // 
            // buttonDis
            // 
            this.buttonDis.Location = new System.Drawing.Point(9, 67);
            this.buttonDis.Name = "buttonDis";
            this.buttonDis.Size = new System.Drawing.Size(162, 23);
            this.buttonDis.TabIndex = 1;
            this.buttonDis.Text = "disegna direttamente";
            this.buttonDis.UseVisualStyleBackColor = true;
            this.buttonDis.Click += new System.EventHandler(this.button1Dis);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 271);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(152, 108);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonreset
            // 
            this.buttonreset.Location = new System.Drawing.Point(10, 385);
            this.buttonreset.Name = "buttonreset";
            this.buttonreset.Size = new System.Drawing.Size(143, 23);
            this.buttonreset.TabIndex = 4;
            this.buttonreset.Text = "reset e refresh controllo";
            this.buttonreset.UseVisualStyleBackColor = true;
            this.buttonreset.Click += new System.EventHandler(this.buttonReset);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "n.lin";
            // 
            // buttonvram
            // 
            this.buttonvram.Location = new System.Drawing.Point(9, 127);
            this.buttonvram.Name = "buttonvram";
            this.buttonvram.Size = new System.Drawing.Size(78, 23);
            this.buttonvram.TabIndex = 7;
            this.buttonvram.Text = "genera buffer";
            this.buttonvram.UseVisualStyleBackColor = true;
            this.buttonvram.Click += new System.EventHandler(this.buttonGenVRAM);
            // 
            // buttondraw
            // 
            this.buttondraw.Location = new System.Drawing.Point(90, 127);
            this.buttondraw.Name = "buttondraw";
            this.buttondraw.Size = new System.Drawing.Size(75, 23);
            this.buttondraw.TabIndex = 8;
            this.buttondraw.Text = "disegna";
            this.buttondraw.UseVisualStyleBackColor = true;
            this.buttondraw.Click += new System.EventHandler(this.buttonDrawVBO);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "test linee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonN
            // 
            this.buttonN.Location = new System.Drawing.Point(55, 212);
            this.buttonN.Name = "buttonN";
            this.buttonN.Size = new System.Drawing.Size(56, 23);
            this.buttonN.TabIndex = 11;
            this.buttonN.Text = "^";
            this.buttonN.UseVisualStyleBackColor = true;
            this.buttonN.Click += new System.EventHandler(this.buttonN_Click);
            // 
            // buttonS
            // 
            this.buttonS.Location = new System.Drawing.Point(55, 242);
            this.buttonS.Name = "buttonS";
            this.buttonS.Size = new System.Drawing.Size(56, 23);
            this.buttonS.TabIndex = 12;
            this.buttonS.Text = "v";
            this.buttonS.UseVisualStyleBackColor = true;
            this.buttonS.Click += new System.EventHandler(this.buttonS_Click);
            // 
            // buttonE
            // 
            this.buttonE.Location = new System.Drawing.Point(118, 227);
            this.buttonE.Name = "buttonE";
            this.buttonE.Size = new System.Drawing.Size(43, 23);
            this.buttonE.TabIndex = 13;
            this.buttonE.Text = ">";
            this.buttonE.UseVisualStyleBackColor = true;
            this.buttonE.Click += new System.EventHandler(this.buttonE_Click);
            // 
            // buttonO
            // 
            this.buttonO.Location = new System.Drawing.Point(7, 227);
            this.buttonO.Name = "buttonO";
            this.buttonO.Size = new System.Drawing.Size(42, 23);
            this.buttonO.TabIndex = 14;
            this.buttonO.Text = "<";
            this.buttonO.UseVisualStyleBackColor = true;
            this.buttonO.Click += new System.EventHandler(this.buttonO_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(83, 414);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "test cerchi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "traslazione viewport e ridisegno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Chiamate OpenGL dirette";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "VBO";
            // 
            // pictureBox_principale
            // 
            this.pictureBox_principale.Location = new System.Drawing.Point(179, 281);
            this.pictureBox_principale.Name = "pictureBox_principale";
            this.pictureBox_principale.Size = new System.Drawing.Size(599, 260);
            this.pictureBox_principale.TabIndex = 18;
            this.pictureBox_principale.TabStop = false;
            this.pictureBox_principale.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_principale_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "pictBox";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "poligoni";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 472);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "openGL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxPolPieni
            // 
            this.checkBoxPolPieni.AutoSize = true;
            this.checkBoxPolPieni.Location = new System.Drawing.Point(14, 501);
            this.checkBoxPolPieni.Name = "checkBoxPolPieni";
            this.checkBoxPolPieni.Size = new System.Drawing.Size(87, 17);
            this.checkBoxPolPieni.TabIndex = 22;
            this.checkBoxPolPieni.Text = "poligoni pieni";
            this.checkBoxPolPieni.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 531);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 23);
            this.button6.TabIndex = 24;
            this.button6.Text = "stop timer";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.checkBoxPolPieni);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox_principale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonO);
            this.Controls.Add(this.buttonE);
            this.Controls.Add(this.buttonS);
            this.Controls.Add(this.buttonN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttondraw);
            this.Controls.Add(this.buttonvram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonreset);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDis);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_principale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Button buttonDis;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonreset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonvram;
        private System.Windows.Forms.Button buttondraw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonN;
        private System.Windows.Forms.Button buttonS;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonO;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox_principale;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBoxPolPieni;
        private System.Windows.Forms.Button button6;
    }
}

