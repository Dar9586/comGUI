namespace comGUI {
    partial class Password {
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
            this.upp = new System.Windows.Forms.CheckBox();
            this.low = new System.Windows.Forms.CheckBox();
            this.spe = new System.Windows.Forms.CheckBox();
            this.num = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.use = new System.Windows.Forms.TextBox();
            this.len = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.path = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.how = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // upp
            // 
            this.upp.AutoSize = true;
            this.upp.BackColor = System.Drawing.Color.Black;
            this.upp.ForeColor = System.Drawing.Color.Cyan;
            this.upp.Location = new System.Drawing.Point(12, 44);
            this.upp.Name = "upp";
            this.upp.Size = new System.Drawing.Size(110, 17);
            this.upp.TabIndex = 0;
            this.upp.Text = "Lettere Maiuscole";
            this.upp.UseVisualStyleBackColor = false;
            // 
            // low
            // 
            this.low.AutoSize = true;
            this.low.BackColor = System.Drawing.Color.Black;
            this.low.ForeColor = System.Drawing.Color.Cyan;
            this.low.Location = new System.Drawing.Point(162, 44);
            this.low.Name = "low";
            this.low.Size = new System.Drawing.Size(110, 17);
            this.low.TabIndex = 1;
            this.low.Text = "Lettere Minuscole";
            this.low.UseVisualStyleBackColor = false;
            // 
            // spe
            // 
            this.spe.AutoSize = true;
            this.spe.BackColor = System.Drawing.Color.Black;
            this.spe.ForeColor = System.Drawing.Color.Cyan;
            this.spe.Location = new System.Drawing.Point(162, 12);
            this.spe.Name = "spe";
            this.spe.Size = new System.Drawing.Size(103, 17);
            this.spe.TabIndex = 2;
            this.spe.Text = "Caratteri speciali";
            this.spe.UseVisualStyleBackColor = false;
            // 
            // num
            // 
            this.num.AutoSize = true;
            this.num.BackColor = System.Drawing.Color.Black;
            this.num.ForeColor = System.Drawing.Color.Cyan;
            this.num.Location = new System.Drawing.Point(12, 12);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(59, 17);
            this.num.TabIndex = 3;
            this.num.Text = "Numeri";
            this.num.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(14, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Caratteri addizionali";
            // 
            // use
            // 
            this.use.BackColor = System.Drawing.Color.Black;
            this.use.ForeColor = System.Drawing.Color.Cyan;
            this.use.Location = new System.Drawing.Point(12, 97);
            this.use.MaxLength = 25;
            this.use.Name = "use";
            this.use.Size = new System.Drawing.Size(100, 20);
            this.use.TabIndex = 5;
            this.use.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // len
            // 
            this.len.BackColor = System.Drawing.Color.Black;
            this.len.ForeColor = System.Drawing.Color.Cyan;
            this.len.Location = new System.Drawing.Point(118, 97);
            this.len.MaxLength = 4;
            this.len.Name = "len";
            this.len.Size = new System.Drawing.Size(59, 20);
            this.len.TabIndex = 7;
            this.len.Text = "3";
            this.len.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.len.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(118, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lunghezza";
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.BackColor = System.Drawing.Color.Black;
            this.save.ForeColor = System.Drawing.Color.Cyan;
            this.save.Location = new System.Drawing.Point(12, 139);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(86, 17);
            this.save.TabIndex = 8;
            this.save.Text = "Salvare i File";
            this.save.UseVisualStyleBackColor = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Testo Normale|*.txt|Tutti i File|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.Color.Black;
            this.path.ForeColor = System.Drawing.Color.Cyan;
            this.path.Location = new System.Drawing.Point(12, 162);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(229, 20);
            this.path.TabIndex = 9;
            this.path.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.Color.Cyan;
            this.button1.Location = new System.Drawing.Point(247, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Cyan;
            this.button2.Location = new System.Drawing.Point(12, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 46);
            this.button2.TabIndex = 11;
            this.button2.Text = "Fine";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // how
            // 
            this.how.BackColor = System.Drawing.Color.Black;
            this.how.ForeColor = System.Drawing.Color.Cyan;
            this.how.Location = new System.Drawing.Point(206, 97);
            this.how.MaxLength = 4;
            this.how.Name = "how";
            this.how.Size = new System.Drawing.Size(59, 20);
            this.how.TabIndex = 13;
            this.how.Text = "1";
            this.how.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.how.TextChanged += new System.EventHandler(this.how_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(186, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quante Password";
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.how);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.path);
            this.Controls.Add(this.save);
            this.Controls.Add(this.len);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.use);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num);
            this.Controls.Add(this.spe);
            this.Controls.Add(this.low);
            this.Controls.Add(this.upp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
            this.Name = "Password";
            this.Text = "Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         System.Windows.Forms.CheckBox upp;
         System.Windows.Forms.CheckBox low;
         System.Windows.Forms.CheckBox spe;
         System.Windows.Forms.CheckBox num;
         System.Windows.Forms.Label label1;
         System.Windows.Forms.TextBox use;
         System.Windows.Forms.TextBox len;
         System.Windows.Forms.Label label2;
         System.Windows.Forms.CheckBox save;
         System.Windows.Forms.SaveFileDialog saveFileDialog1;
         System.Windows.Forms.TextBox path;
         System.Windows.Forms.Button button1;
         System.Windows.Forms.Timer timer1;
         System.Windows.Forms.Button button2;
         System.Windows.Forms.TextBox how;
         System.Windows.Forms.Label label3;
    }
}