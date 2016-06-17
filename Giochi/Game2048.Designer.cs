namespace comGUI {
    partial class Game2048 {
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
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.up = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Black;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.ForeColor = System.Drawing.Color.Cyan;
            this.start.Location = new System.Drawing.Point(321, 202);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 12;
            this.start.Text = "Inizia";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(318, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Punteggio:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(338, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "0";
            this.label2.Visible = false;
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.Black;
            this.up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.up.ForeColor = System.Drawing.Color.Cyan;
            this.up.Location = new System.Drawing.Point(332, 98);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(18, 23);
            this.up.TabIndex = 15;
            this.up.Text = "^";
            this.up.UseVisualStyleBackColor = false;
            this.up.Visible = false;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Black;
            this.left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.left.ForeColor = System.Drawing.Color.Cyan;
            this.left.Location = new System.Drawing.Point(308, 128);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(18, 23);
            this.left.TabIndex = 16;
            this.left.Text = "<";
            this.left.UseVisualStyleBackColor = false;
            this.left.Visible = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Black;
            this.right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.right.ForeColor = System.Drawing.Color.Cyan;
            this.right.Location = new System.Drawing.Point(358, 129);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(18, 23);
            this.right.TabIndex = 17;
            this.right.Text = ">";
            this.right.UseVisualStyleBackColor = false;
            this.right.Visible = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Black;
            this.down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.down.ForeColor = System.Drawing.Color.Cyan;
            this.down.Location = new System.Drawing.Point(333, 158);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(18, 23);
            this.down.TabIndex = 18;
            this.down.Text = "v";
            this.down.UseVisualStyleBackColor = false;
            this.down.Visible = false;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // Game2048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(436, 261);
            this.Controls.Add(this.down);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.up);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            this.Name = "Game2048";
            this.Text = "2048";
            this.Load += new System.EventHandler(this.Game2048_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
         System.Windows.Forms.Button start;
         System.Windows.Forms.Label label1;
         System.Windows.Forms.Label label2;
         System.Windows.Forms.Button up;
         System.Windows.Forms.Button left;
         System.Windows.Forms.Button right;
         System.Windows.Forms.Button down;
    }
}