namespace comGUI {
    partial class Squash {
        /// <summary>
        /// Required designer variable.
        /// </summary>
         System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
         void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playerBar = new System.Windows.Forms.PictureBox();
            this.computerBar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::comGUI.Properties.Resources.Pongscheme;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Cyan;
            this.button1.Location = new System.Drawing.Point(533, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playerBar
            // 
            this.playerBar.BackColor = System.Drawing.Color.Transparent;
            this.playerBar.Location = new System.Drawing.Point(58, 33);
            this.playerBar.Name = "playerBar";
            this.playerBar.Size = new System.Drawing.Size(25, 460);
            this.playerBar.TabIndex = 2;
            this.playerBar.TabStop = false;
            this.playerBar.Paint += new System.Windows.Forms.PaintEventHandler(this.playerBar_Paint);
            this.playerBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playerBar_MouseMove);
            // 
            // computerBar
            // 
            this.computerBar.Location = new System.Drawing.Point(688, 33);
            this.computerBar.Name = "computerBar";
            this.computerBar.Size = new System.Drawing.Size(25, 460);
            this.computerBar.TabIndex = 3;
            this.computerBar.TabStop = false;
            this.computerBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(13, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 69);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // Pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(775, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.computerBar);
            this.Controls.Add(this.playerBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Squash";
            this.Text = "Squash";
            this.Load += new System.EventHandler(this.Squash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.PictureBox pictureBox1;
         System.Windows.Forms.Button button1;
         System.Windows.Forms.Timer timer1;
         System.Windows.Forms.PictureBox playerBar;
         System.Windows.Forms.PictureBox computerBar;
         System.Windows.Forms.Label label1;
    }
}