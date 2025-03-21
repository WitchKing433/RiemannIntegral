namespace RiemannIntegral
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            trackBar1 = new TrackBar();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBoxFunction = new TextBox();
            label3 = new Label();
            button1 = new Button();
            textBoxMaxX = new TextBox();
            textBoxMaxY = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBoxSupInt = new TextBox();
            textBoxInfInt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(37, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(724, 256);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.Resize += pictureBox1_Resize;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.Location = new Point(37, 324);
            trackBar1.Maximum = 300;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(724, 56);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(49, 366);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 44);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(303, 366);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 44);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(92, 366);
            label1.Name = "label1";
            label1.Size = new Size(186, 20);
            label1.TabIndex = 4;
            label1.Text = "Suma superior de Darboux";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(345, 369);
            label2.Name = "label2";
            label2.Size = new Size(180, 20);
            label2.TabIndex = 5;
            label2.Text = "Suma inferior de Darboux";
            // 
            // textBoxFunction
            // 
            textBoxFunction.Location = new Point(89, 14);
            textBoxFunction.Name = "textBoxFunction";
            textBoxFunction.Size = new Size(561, 27);
            textBoxFunction.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 14);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 7;
            label3.Text = "f(x) =";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(667, 14);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Graficar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxMaxX
            // 
            textBoxMaxX.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxMaxX.Location = new Point(636, 369);
            textBoxMaxX.Name = "textBoxMaxX";
            textBoxMaxX.Size = new Size(125, 27);
            textBoxMaxX.TabIndex = 9;
            textBoxMaxX.Text = "2 * PI";
            // 
            // textBoxMaxY
            // 
            textBoxMaxY.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBoxMaxY.Location = new Point(636, 402);
            textBoxMaxY.Name = "textBoxMaxY";
            textBoxMaxY.Size = new Size(125, 27);
            textBoxMaxY.TabIndex = 10;
            textBoxMaxY.Text = "10";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(566, 372);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 11;
            label4.Text = "Máx X =";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(566, 405);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 12;
            label5.Text = "Máx Y =";
            // 
            // textBoxSupInt
            // 
            textBoxSupInt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxSupInt.Location = new Point(92, 389);
            textBoxSupInt.Name = "textBoxSupInt";
            textBoxSupInt.Size = new Size(186, 27);
            textBoxSupInt.TabIndex = 13;
            textBoxSupInt.TextChanged += textBox1_TextChanged;
            // 
            // textBoxInfInt
            // 
            textBoxInfInt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxInfInt.Location = new Point(350, 389);
            textBoxInfInt.Name = "textBoxInfInt";
            textBoxInfInt.Size = new Size(175, 27);
            textBoxInfInt.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxInfInt);
            Controls.Add(textBoxSupInt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxMaxY);
            Controls.Add(textBoxMaxX);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBoxFunction);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(trackBar1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TrackBar trackBar1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private TextBox textBoxFunction;
        private Label label3;
        private Button button1;
        private TextBox textBoxMaxX;
        private TextBox textBoxMaxY;
        private Label label4;
        private Label label5;
        private TextBox textBoxSupInt;
        private TextBox textBoxInfInt;
    }
}
