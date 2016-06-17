using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace comGUI {

    public partial class MineSweeper : Form {

        public MineSweeper() {
            InitializeComponent();
            this.FormClosing += back;
        }

         void back(object sender, EventArgs e) {
            time = 0;
            if (Program.start.Visible == false) {
                Program.start.Show();
            }
            else {
                Dispose();
            }
        }

         void createButton(int x, int y, int z) {
            Button s = new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(24, 24);
            s.BackColor = Color.Black;
            s.ForeColor = Color.Cyan;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.TabIndex = z;
            s.MouseUp += new MouseEventHandler(mouseClick);
            Controls.Add(s);
            user.Add(s);
        }

         void mouseClick(object sender, MouseEventArgs e) {
            int pos = user.IndexOf((sender as Button));
            if (e.Button.ToString() == "Right") {
                if (user[pos].ForeColor == Color.Cyan) { user[pos].ForeColor = Color.Yellow; user[pos].Text = "?"; }
                else if (user[pos].ForeColor == Color.Yellow) { user[pos].ForeColor = Color.Red; user[pos].Text = "⚠"; }
                else if (user[pos].ForeColor == Color.Red) { user[pos].ForeColor = Color.Cyan; user[pos].Text = ""; }
            }
            if (e.Button.ToString() == "Left") {
                if (scheme.Count == 0) {
                    scheme = Enumerable.Repeat(0, (int)(numericUpDown1.Value * numericUpDown2.Value)).ToList();
                    generateScheme(pos);
                }
                updateUser(pos);
                int howLeft = 0;
                for (int a = 0; a < scheme.Count; a++) { if (user[a].Text == "") { howLeft++; } if (user[a].Text == "☠") { label4.Visible = true; label4.Text = "Hai Perso"; label4.ForeColor = Color.Red; seeall(); howLeft = 0; extra[0].Visible = false; timer1.Stop(); break; } }
                if (howLeft == numericUpDown3.Value) { label4.Visible = true; label4.Text = "Hai Vinto"; label4.ForeColor = Color.Green; extra[0].Visible = false; timer1.Stop(); seeall(); }
            }
        }

         void updateUser(int pos) {
            user[pos].MouseUp -= mouseClick;
            if (scheme[pos] != 0) {
                user[pos].Text = scheme[pos] == 9 ? "☠" : scheme[pos].ToString();
                switch (scheme[pos]) {
                    case 1: user[pos].ForeColor = Color.Blue; break;
                    case 2: user[pos].ForeColor = Color.Green; break;
                    case 3: user[pos].ForeColor = Color.Red; break;
                    case 4: user[pos].ForeColor = Color.DarkBlue; break;
                    case 5: user[pos].ForeColor = Color.DarkRed; break;
                    case 6: user[pos].ForeColor = Color.DarkCyan; break;
                    case 7: user[pos].ForeColor = Color.White; break;
                    case 8: user[pos].ForeColor = Color.DarkGray; break;
                    case 9: user[pos].ForeColor = Color.DarkMagenta; break;
                }
            }
            else if (user[pos].Text != "█") {
                user[pos].Text = "█"; user[pos].ForeColor = Color.Gray;
                int m1 = (int)numericUpDown1.Value;
                if (pos % m1 != 0 && pos >= m1) { updateUser(pos - m1 - 1); }
                if (pos >= m1) { updateUser(pos - m1); }
                if ((pos + 1) % m1 != 0 && pos >= m1) { updateUser(pos - m1 + 1); }
                if (pos % m1 != 0) { updateUser(pos - 1); }
                if ((pos + 1) % m1 != 0) { updateUser(pos + 1); }
                if (pos % m1 != 0 && pos < scheme.Count - m1) { updateUser(pos + m1 - 1); }
                if (pos < scheme.Count - m1) { updateUser(pos + m1); }
                if ((pos + 1) % m1 != 0 && pos < scheme.Count - m1) { updateUser(pos + m1 + 1); }
            }
        }

         void generateScheme(int i) {
            int m1 = (int)numericUpDown1.Value;
            for (int a = 0; a < numericUpDown3.Value; a++) {
                int h = rnd.Next(scheme.Count);
                if (scheme[h] == 0 && h != i) { scheme[h] = 9; } else { a--; }
            }
            for (int a = 0; a < scheme.Count; a++) {
                if (scheme[a] != 9) {
                    if (a % m1 != 0 && a >= m1 && scheme[a - m1 - 1] == 9) { scheme[a]++; }
                    if (a >= m1 && scheme[a - m1] == 9) { scheme[a]++; }
                    if ((a + 1) % m1 != 0 && a >= m1 && scheme[a - m1 + 1] == 9) { scheme[a]++; }
                    if (a % m1 != 0 && scheme[a - 1] == 9) { scheme[a]++; }
                    if ((a + 1) % m1 != 0 && scheme[a + 1] == 9) { scheme[a]++; }
                    if (a % m1 != 0 && a < scheme.Count - m1 && scheme[a + m1 - 1] == 9) { scheme[a]++; }
                    if (a < scheme.Count - m1 && scheme[a + m1] == 9) { scheme[a]++; }
                    if ((a + 1) % m1 != 0 && a < scheme.Count - m1 && scheme[a + m1 + 1] == 9) { scheme[a]++; }
                }
            }
        }

         static Random rnd = new Random(Environment.TickCount);
         static List<int> scheme = new List<int>();
         static List<Button> user = new List<Button>();
         static List<Button> extra = new List<Button>();

         void start_Click(object sender, EventArgs e) {
            createButton((int)numericUpDown1.Value * 24 - 83, (int)numericUpDown2.Value * 24 + 24, "Resa", Color.Red, numericUpDown1.Value * numericUpDown2.Value + 1);
            createButton((int)numericUpDown1.Value * 24 - 35, (int)numericUpDown2.Value * 24 + 24, "Reset", Color.Violet, numericUpDown1.Value * numericUpDown2.Value + 2);
            label4.Location = new Point(12, (int)numericUpDown2.Value * 24 + 24);
            label5.Location = new Point(12, (int)numericUpDown2.Value * 24 + 50);
            setLevel(false);
            Size = new Size((int)numericUpDown1.Value * 24 + 50, (int)numericUpDown2.Value * 24 + 150);
            for (int a = 0; a < numericUpDown2.Value; a++) {
                for (int b = 0; b < numericUpDown1.Value; b++) { createButton(b * 24 + 12, a * 24 + 12, (int)(a * numericUpDown2.Value + b)); }
            }
            label5.Text = "00 : 00";
            timer1.Start();
        }

         void createButton(int x, int y, string text, Color col, decimal gg) {
            Button s = new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(48, 24);
            s.BackColor = Color.Black;
            s.ForeColor = col;
            s.Text = text;
            s.TabIndex = (int)gg;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.Click += new EventHandler(extraClick);
            Controls.Add(s);
            extra.Add(s);
        }

         void seeall() {
            for (int a = 0; a < scheme.Count; a++) {
                if (user[a].Text == "") { user[a].MouseUp -= mouseClick; }
                switch (scheme[a]) {
                    case 9: user[a].Text = "☠"; break;
                    case 0: user[a].Text = "█"; break;
                    default: user[a].Text = scheme[a].ToString(); ; break;
                }
                switch (scheme[a]) {
                    case 0: user[a].ForeColor = Color.Gray; break;
                    case 1: user[a].ForeColor = Color.Blue; break;
                    case 2: user[a].ForeColor = Color.Green; break;
                    case 3: user[a].ForeColor = Color.Red; break;
                    case 4: user[a].ForeColor = Color.DarkBlue; break;
                    case 5: user[a].ForeColor = Color.DarkRed; break;
                    case 6: user[a].ForeColor = Color.DarkCyan; break;
                    case 7: user[a].ForeColor = Color.White; break;
                    case 8: user[a].ForeColor = Color.DarkGray; break;
                    case 9: user[a].ForeColor = Color.DarkMagenta; break;
                }
            }
        }

         void extraClick(object sender, EventArgs e) {
            label4.Visible = true; label4.Text = "Hai Perso"; label4.ForeColor = Color.Red;
            int pos = extra.IndexOf((sender as Button));
            timer1.Stop();
            if (extra[pos].Text == "Resa") {
                extra[0].Visible = false;
                if (scheme.Count == 0) {
                    scheme = Enumerable.Repeat(0, (int)(numericUpDown1.Value * numericUpDown2.Value)).ToList();
                    generateScheme(rnd.Next(user.Count));
                }
                seeall();
            }
            else {
                label4.Visible = false; label4.ForeColor = Color.Black;
                scheme.Clear(); time = 0;
                for (int a = 0; a < user.Count; a++) { Controls.Remove(user[a]); }
                user.Clear();
                for (int a = 0; a < 2; a++) { Controls.Remove(extra[a]); }
                extra.Clear();
                Size = new Size(300, 300);
                setLevel(true);
            }
        }

         void setLevel(bool x) {
            label1.Visible = x;
            label2.Visible = x;
            label3.Visible = x;
            numericUpDown1.Visible = x;
            numericUpDown2.Visible = x;
            numericUpDown3.Visible = x;
            start.Visible = x;
            label4.Visible = !x;
            label5.Visible = !x;
        }

         void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            decimal h = numericUpDown1.Value * numericUpDown2.Value - 1;
            if (numericUpDown3.Value > h) { numericUpDown3.Value = h; }
            numericUpDown3.Maximum = h;
        }

         static int time = 0;

         void MineSweeper_Load(object sender, EventArgs e) {
            scheme.Clear(); user.Clear();
            extra.Clear();
            numericUpDown1.Maximum = (Screen.PrimaryScreen.Bounds.Width - 50) / 24;
            numericUpDown2.Maximum = (Screen.PrimaryScreen.Bounds.Height - 150) / 24;
        }

         void timer1_Tick(object sender, EventArgs e) {
            time++;
            string h = time % 60 < 10 ? "0" + (time % 60).ToString() : (time % 60).ToString();
            string h1 = time / 60 < 10 ? "0" + ((int)(time / 60)).ToString() : ((int)(time / 60)).ToString();
            label5.Text = h1 + " : " + h;
        }
    }
}