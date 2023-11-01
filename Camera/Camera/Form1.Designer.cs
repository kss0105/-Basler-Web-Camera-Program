namespace Camera
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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(394, 444);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 1;
            button1.Text = "On/Off";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BaslerOnOffBtnClick;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(81, 0);
            button2.Name = "button2";
            button2.Size = new Size(75, 25);
            button2.TabIndex = 2;
            button2.Text = "photo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BaslerPhotoBtnClick;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(162, 0);
            button3.Name = "button3";
            button3.Size = new Size(75, 25);
            button3.TabIndex = 3;
            button3.Text = "record";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BaslerRecordBtnClick;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(403, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(394, 444);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.Location = new Point(562, 0);
            button4.Name = "button4";
            button4.Size = new Size(75, 25);
            button4.TabIndex = 7;
            button4.Text = "record";
            button4.UseVisualStyleBackColor = true;
            button4.Click += WebRecordBtnClick;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.Location = new Point(481, 0);
            button5.Name = "button5";
            button5.Size = new Size(75, 25);
            button5.TabIndex = 6;
            button5.Text = "photo";
            button5.UseVisualStyleBackColor = true;
            button5.Click += WebPhotoBtnClick;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.None;
            button6.Location = new Point(400, 0);
            button6.Name = "button6";
            button6.Size = new Size(75, 25);
            button6.TabIndex = 5;
            button6.Text = "On/Off";
            button6.UseVisualStyleBackColor = true;
            button6.Click += WebOnOffBtnClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBox2, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion


        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox2;
        private Button button4;
        private Button button5;
        private Button button6;
        private TableLayoutPanel tableLayoutPanel1;
    }
}