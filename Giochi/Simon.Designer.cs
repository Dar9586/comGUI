namespace comGUI {
    partial class Simon {
        /// <summary>
        /// Required designer variable.
        /// </summary>
         System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be this.Disposed; otherwise, false.</param>
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
            this.cyan = new System.Windows.Forms.Button();
            this.yellow = new System.Windows.Forms.Button();
            this.green = new System.Windows.Forms.Button();
            this.red = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.point = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.col = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cyan
            // 
            this.cyan.BackColor = System.Drawing.Color.DarkCyan;
            this.cyan.Enabled = false;
            this.cyan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cyan.ForeColor = System.Drawing.Color.Navy;
            this.cyan.Location = new System.Drawing.Point(12, 12);
            this.cyan.Name = "cyan";
            this.cyan.Size = new System.Drawing.Size(125, 120);
            this.cyan.TabIndex = 0;
            this.cyan.UseVisualStyleBackColor = false;
            this.cyan.Click += new System.EventHandler(this.cyan_Click);
            // 
            // yellow
            // 
            this.yellow.BackColor = System.Drawing.Color.DarkOrange;
            this.yellow.Enabled = false;
            this.yellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellow.ForeColor = System.Drawing.Color.SaddleBrown;
            this.yellow.Location = new System.Drawing.Point(147, 12);
            this.yellow.Name = "yellow";
            this.yellow.Size = new System.Drawing.Size(125, 120);
            this.yellow.TabIndex = 1;
            this.yellow.UseVisualStyleBackColor = false;
            this.yellow.Click += new System.EventHandler(this.yellow_Click);
            // 
            // green
            // 
            this.green.BackColor = System.Drawing.Color.DarkGreen;
            this.green.Enabled = false;
            this.green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.green.ForeColor = System.Drawing.Color.Lime;
            this.green.Location = new System.Drawing.Point(147, 138);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(125, 120);
            this.green.TabIndex = 3;
            this.green.UseVisualStyleBackColor = false;
            this.green.Click += new System.EventHandler(this.green_Click);
            // 
            // red
            // 
            this.red.BackColor = System.Drawing.Color.DarkRed;
            this.red.Enabled = false;
            this.red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.red.ForeColor = System.Drawing.Color.Firebrick;
            this.red.Location = new System.Drawing.Point(12, 138);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(125, 120);
            this.red.TabIndex = 2;
            this.red.UseVisualStyleBackColor = false;
            this.red.Click += new System.EventHandler(this.red_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Black;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.ForeColor = System.Drawing.Color.Cyan;
            this.start.Location = new System.Drawing.Point(12, 333);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(260, 51);
            this.start.TabIndex = 4;
            this.start.Text = "Inizia";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // point
            // 
            this.point.AutoSize = true;
            this.point.BackColor = System.Drawing.Color.Black;
            this.point.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point.ForeColor = System.Drawing.Color.Cyan;
            this.point.Location = new System.Drawing.Point(124, 284);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(24, 25);
            this.point.TabIndex = 5;
            this.point.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // col
            // 
            this.col.Enabled = true;
            this.col.Interval = 1;
            this.col.Tick += new System.EventHandler(this.col_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(7, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Punteggio: ";
            // 
            // Simon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 396);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.point);
            this.Controls.Add(this.start);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.yellow);
            this.Controls.Add(this.cyan);
            this.ForeColor = System.Drawing.Color.Cyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            this.Name = "Simon";
            this.Text = "Simon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.Button cyan;
         System.Windows.Forms.Button yellow;
         System.Windows.Forms.Button green;
         System.Windows.Forms.Button red;
         System.Windows.Forms.Button start;
         System.Windows.Forms.Label point;
         System.Windows.Forms.Timer timer1;
         System.Windows.Forms.Timer col;
         System.Windows.Forms.Label label1;
    }
}