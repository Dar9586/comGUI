using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace comGUI {
    public partial class Sudoku : Form {
        public Sudoku() {
            InitializeComponent();
        this.FormClosing += back;
        }

        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }

        private static List<int> create()
		{
			Random rnd = new Random();
			int k = 0;
			List<int> list = new List<int>();
			list.Add(0);

			while (list.Contains(0))
			{
				list.Clear();
				bool restart = false;
				for (int a = 0; a < 81; a++)
				{
					list.Add(0);
				}
				for (int a = 1; a < 10; a++)
				{
					List<int> rig1 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
					List<int> rig2 = new List<int> { 9, 10, 11, 12, 13, 14, 15, 16, 17 };
					List<int> rig3 = new List<int> { 18, 19, 20, 21, 22, 23, 24, 25, 26 };
					List<int> rig4 = new List<int> { 27, 28, 29, 30, 31, 32, 33, 34, 35 };
					List<int> rig5 = new List<int> { 36, 37, 38, 39, 40, 41, 42, 43, 44 };
					List<int> rig6 = new List<int> { 45, 46, 47, 48, 49, 50, 51, 52, 53 };
					List<int> rig7 = new List<int> { 54, 55, 56, 57, 58, 59, 60, 61, 62 };
					List<int> rig8 = new List<int> { 63, 64, 65, 66, 67, 68, 69, 70, 71 };
					List<int> rig9 = new List<int> { 72, 73, 74, 75, 76, 77, 78, 79, 80 };

					List<int> col1 = new List<int> { 0, 9, 18, 27, 36, 45, 54, 63, 72 };
					List<int> col2 = new List<int> { 1, 10, 19, 28, 37, 46, 55, 64, 73 };
					List<int> col3 = new List<int> { 2, 11, 20, 29, 38, 47, 56, 65, 74 };
					List<int> col4 = new List<int> { 3, 12, 21, 30, 39, 48, 57, 66, 75 };
					List<int> col5 = new List<int> { 4, 13, 22, 31, 40, 49, 58, 67, 76 };
					List<int> col6 = new List<int> { 5, 14, 23, 32, 41, 50, 59, 68, 77 };
					List<int> col7 = new List<int> { 6, 15, 24, 33, 42, 51, 60, 69, 78 };
					List<int> col8 = new List<int> { 7, 16, 25, 34, 43, 52, 61, 70, 79 };
					List<int> col9 = new List<int> { 8, 17, 26, 35, 44, 53, 62, 71, 80 };

					List<int> squ1 = new List<int> { 0, 1, 2, 9, 10, 11, 18, 19, 20 };
					List<int> squ2 = new List<int> { 3, 4, 5, 12, 13, 14, 21, 22, 23 };
					List<int> squ3 = new List<int> { 6, 7, 8, 15, 16, 17, 24, 25, 26 };
					List<int> squ4 = new List<int> { 27, 28, 29, 36, 37, 38, 45, 46, 47 };
					List<int> squ5 = new List<int> { 30, 31, 32, 39, 40, 41, 48, 49, 50 };
					List<int> squ6 = new List<int> { 33, 34, 35, 42, 43, 44, 51, 52, 53 };
					List<int> squ7 = new List<int> { 54, 55, 56, 63, 64, 65, 72, 73, 74 };
					List<int> squ8 = new List<int> { 57, 58, 59, 66, 67, 68, 75, 76, 77 };
					List<int> squ9 = new List<int> { 60, 61, 62, 69, 70, 71, 78, 79, 80 };
					for (int c = 0; c < 9; c++)
					{
						bool o = false;
						List<int> usable = new List<int>();
						for (int k1 = 0; k1 < 81; k1++)
						{
							if (list[k1] == 0)
							{
								if (rig1.Contains(k1) || rig2.Contains(k1) || rig3.Contains(k1) || rig4.Contains(k1) || rig5.Contains(k1) || rig6.Contains(k1) || rig7.Contains(k1) || rig8.Contains(k1) || rig9.Contains(k1))
								{
									if (col1.Contains(k1) || col2.Contains(k1) || col3.Contains(k1) || col4.Contains(k1) || col5.Contains(k1) || col6.Contains(k1) || col7.Contains(k1) || col8.Contains(k1) || col9.Contains(k1))
									{
										if (squ1.Contains(k1) || squ2.Contains(k1) || squ3.Contains(k1) || squ4.Contains(k1) || squ5.Contains(k1) || squ6.Contains(k1) || squ7.Contains(k1) || squ8.Contains(k1) || squ9.Contains(k1))
										{
											usable.Add(k1);
											o = true;
										}
									}
								}
							}
						}
						if (o)
						{
							k = usable[rnd.Next(usable.Count)];
						}
						else { restart = true; }
						if (!restart)
						{
							list[k] = a;
							if (rig1.Contains(k)) { rig1.Clear(); }
							else if (rig2.Contains(k)) { rig2.Clear(); }
							else if (rig3.Contains(k)) { rig3.Clear(); }
							else if (rig4.Contains(k)) { rig4.Clear(); }
							else if (rig5.Contains(k)) { rig5.Clear(); }
							else if (rig6.Contains(k)) { rig6.Clear(); }
							else if (rig7.Contains(k)) { rig7.Clear(); }
							else if (rig8.Contains(k)) { rig8.Clear(); }
							else if (rig9.Contains(k)) { rig9.Clear(); }
							if (col1.Contains(k)) { col1.Clear(); }
							else if (col2.Contains(k)) { col2.Clear(); }
							else if (col3.Contains(k)) { col3.Clear(); }
							else if (col4.Contains(k)) { col4.Clear(); }
							else if (col5.Contains(k)) { col5.Clear(); }
							else if (col6.Contains(k)) { col6.Clear(); }
							else if (col7.Contains(k)) { col7.Clear(); }
							else if (col8.Contains(k)) { col8.Clear(); }
							else if (col9.Contains(k)) { col9.Clear(); }
							if (squ1.Contains(k)) { squ1.Clear(); }
							else if (squ2.Contains(k)) { squ2.Clear(); }
							else if (squ3.Contains(k)) { squ3.Clear(); }
							else if (squ4.Contains(k)) { squ4.Clear(); }
							else if (squ5.Contains(k)) { squ5.Clear(); }
							else if (squ6.Contains(k)) { squ6.Clear(); }
							else if (squ7.Contains(k)) { squ7.Clear(); }
							else if (squ8.Contains(k)) { squ8.Clear(); }
							else if (squ9.Contains(k)) { squ9.Clear(); }
						}
						if (restart) { break; }
					}
					if (restart) { break; }
				}
			}
			return list;
		}

        private void createButton(int x,int y) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(24, 24);
            s.BackColor=Color.Black;
            s.ForeColor=Color.Cyan;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.Click += new EventHandler(buttonClick);
            s.MouseEnter +=new EventHandler(mouseHover);
            s.MouseUp +=new MouseEventHandler(buttonMouseclick);
            s.MouseLeave +=new EventHandler(mouseLeave);
            Controls.Add(s);
            col.Add(Color.Cyan);
            list.Add(s);
            
        }

        private void mouseLeave(object sender, EventArgs e) {
           try { if(!timer1.Enabled) { for(int a=0;a<81;a++) {list[a].ForeColor=col[a]; }}}catch(Exception) { }
        }

        private void mouseHover(object sender, EventArgs e) {
            if(label2.Text!="Generazione in Corso..."&&!timer1.Enabled) { 
            int j=list.IndexOf((sender as Button));
             for(int a=0;a<81;a++) {
                    list[a].ForeColor=col[a]; 
                    } 
            int k=(int)(j/9);
                if(checkBox1.ForeColor==Color.Lime) { 
                 for(int b=0;b<9;b++) {list[k*9+b].ForeColor=Color.Navy;}
            }
            List<int> h = new List<int> { 0, 9, 18, 27, 36, 45, 54, 63, 72 };
                if(checkBox2.ForeColor==Color.Lime) { 
            for (int a = 0; a < 9; a++) {
                if (h.Contains(j)) { for (int b = 0; b < 9; b++) { list[h[b]].ForeColor = Color.Navy; }break; }
                else {for (int b = 0; b < 9; b++) { h[b] = h[b] + 1; }} 
            }}
                if(checkBox3.ForeColor==Color.Lime) { 
           h.Clear();
            h=new List<int> {0,1,2,9,10,11,18,19,20};
            for(int a=0;a<9;a++) {
                if (h.Contains(j)) { for (int b = 0; b < 9; b++) { list[h[b]].ForeColor = Color.Navy; } }
                if((a+1)%3!=0) {for (int b = 0; b < 9; b++) { h[b] = h[b] + 3; } }
                else {for (int b = 0; b < 9; b++) { h[b] = h[b] + 21; } }
            }}
            list[j].ForeColor=Color.Lime; 
                 }   
        }

        private void buttonMouseclick(object sender, MouseEventArgs e) {
            int sen=list.IndexOf((sender as Button));
           if(col[sen]!=Color.Violet) { 
            if(e.Button.ToString()=="Right") {
                if(list[sen].ForeColor==Color.Cyan) {list[sen].ForeColor=Color.Yellow;col[sen]=Color.Yellow;}
                else if(list[sen].ForeColor==Color.Yellow) {list[sen].ForeColor=Color.Red;col[sen]=Color.Red;}
                else if(list[sen].ForeColor==Color.Red) {list[sen].ForeColor=Color.Cyan;col[sen]=Color.Cyan;}
            }
            if(e.Button.ToString()=="Left") {selected=sen; }
            }
        }
        
        private void buttonClick(object sender, EventArgs e) {
            if (col[list.IndexOf((sender as Button))]!=Color.Violet) {
                selected =list.IndexOf((sender as Button));}
        }
        List<string> schemed=new List<string>(Properties.Resources.SudokuScheme.ToString().Split('\n'));
        private async void Sudoku_Load(object sender, EventArgs e) {
            generate2();
            List<int> s=new List<int> {12,42,72,112,142,172,212,242,272 };
            for(int b=0;b<81;b++) {
                    user.Add(0);
                }
            for(int a=0;a<9;a++) {
                for(int b=0;b<9;b++) {
                    createButton(s[b],s[a]);
                }
            }
            s.Clear();
            await Task.Delay(500);
            /*string o="5 7 4 3 1 2 9 6 8 1 3 6 8 9 7 5 2 4 9 8 2 5 4 6 3 7 1 4 2 3 1 8 5 6 9 7 7 9 5 6 2 4 1 8 3 8 6 1 7 3 9 4 5 2 6 5 8 4 7 3 2 1 9 2 4 7 9 5 1 8 3 6 3 1 9 2 6 8 7 4 5";
                List<string> oo=new List<string>(o.Split(' '));
            for(int a=0;a<81;a++) {scheme.Add(int.Parse(oo[a])); }*/
            
           int gh=comGUI.Menu.rnd.Next(schemed.Count);
            string c=schemed[gh];
            
            List<int>h=new List<int>();
                    for(int a=0;a<81;a++) {h.Add(int.Parse(c.ToCharArray()[adapter[a]].ToString())); }
                    scheme=h;

           //Properties.Settings.Default.a
           // for(int a=0;a<x.Length;a++) {Debug.WriteLine(x[a]); }Debug.WriteLine("");
          
            //using (StreamWriter writer = new StreamWriter(x)) { writer.Write(Properties.Resources.SudokuScheme.Remove(81 * gh, 81)); writer.Close(); }
            //scheme=create();
             label2.Visible=false;
            label2.Text="";
             label1.Visible=true;
             radioButton1.Visible=true;
             radioButton2.Visible=true;
             radioButton3.Visible=true;
             radioButton4.Visible=true;
             button1.Visible=true;
            BackgroundWorker bw=new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerAsync();
        }

        List<int>adapter=new List<int> {0,1,2,9,10,11,18,19,20,
            3,4,5,12,13,14,21,22,23,6,7,8,15,16,17,24,25,26,27,
            28,29,36,37,38,45,46,47,30,31,32,39,40,41,48,49,50,
            33,34,35,42,43,44,51,52,53,54,55,56,63,64,65,72,73,
            74,57,58,59,66,67,68,75,76,77,60,61,62,69,70,71,78,79,80 };

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true) { 
            List<int> o=new List<int>(create());
            string s="";
            for(int a=0;a<81;a++) {s+=o[a].ToString(); }
            created.Add(s);
                }
        }
        List<string> created=new List<string>();
        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            radioButton1.Checked=true;
            radioButton2.Checked=false;
            radioButton3.Checked=false;
            radioButton4.Checked=false;
            numericUpDown1.Visible=false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            radioButton1.Checked=false;
            radioButton2.Checked=true;
            radioButton3.Checked=false;
            radioButton4.Checked=false;
            numericUpDown1.Visible=false;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            radioButton3.Checked=true;
            radioButton4.Checked=false;
            numericUpDown1.Visible=false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            radioButton3.Checked=false;
            radioButton4.Checked=true;
            numericUpDown1.Visible=true;
        }
        
        private async void button1_Click(object sender, EventArgs e) {
            
                if(button1.Text=="Reset") {
                label4.Visible=false;
                label4.Text="00 : 00";
                time=0;
                    for(int a=0;a<se.Count;a++) {se[a].Visible=false; }
                    for(int a=0;a<list.Count;a++) {list[a].Text="";list[a].ForeColor=Color.Cyan; }
                    label1.Visible=true;
             radioButton1.Visible=true;
             radioButton2.Visible=true;
             radioButton3.Visible=true;
             radioButton4.Visible=true;
             button1.Visible=true;
                 user.Clear();
            scheme.Clear();
            col.Clear();
                timer1.Stop();
            label2.Text="Generazione in Corso...";
                label2.ForeColor=Color.Cyan;
            await Task.Delay(500);

                /*string o="5 7 4 3 1 2 9 6 8 1 3 6 8 9 7 5 2 4 9 8 2 5 4 6 3 7 1 4 2 3 1 8 5 6 9 7 7 9 5 6 2 4 1 8 3 8 6 1 7 3 9 4 5 2 6 5 8 4 7 3 2 1 9 2 4 7 9 5 1 8 3 6 3 1 9 2 6 8 7 4 5";
                List<string> oo=new List<string>(o.Split(' '));
            for(int a=0;a<81;a++) {scheme.Add(int.Parse(oo[a])); }
            */
            if(created.Count<1){
                 int gh=comGUI.Menu.rnd.Next(schemed.Count);
            string c=schemed[gh];
            
            List<int>h=new List<int>();
                    for(int a=0;a<81;a++) {h.Add(int.Parse(c.ToCharArray()[adapter[a]].ToString())); }
                    scheme=h; }
            else {
                    int k=comGUI.Menu.rnd.Next(created.Count);
                    List<int>h=new List<int>();
                    for(int a=0;a<81;a++) {h.Add(int.Parse(created[k].ToCharArray()[a].ToString())); }
                    scheme=h;
                    created.RemoveAt(k);
                }
                label2.Text="";label2.Visible=false;
                button1.Text="Inizia";
            col.Clear();for(int a=0;a<81;a++) {user.Add(0);col.Add(Color.Cyan);list[a].Text=""; }
            }
              
            else if(button1.Text=="Inizia") { 
            int j=0;
            if(radioButton3.Checked) {j=comGUI.Menu.rnd.Next(15,25); }
            else if(radioButton2.Checked) {j=comGUI.Menu.rnd.Next(25,35); }
            else if(radioButton1.Checked) {j=comGUI.Menu.rnd.Next(35,45); }
            else if(radioButton4.Checked) {j=(int)numericUpDown1.Value;}
            
            if(j!=-1) {
                for(int a=0;a<se.Count;a++) {se[a].Visible=true; }
                radioButton1.Visible=false;
                radioButton2.Visible=false;
                radioButton3.Visible=false;
                radioButton4.Visible=false;
                label1.Visible=false;
                numericUpDown1.Visible=false;
                button1.Visible=false;
                for(int a=0;a<j;a++) {
                    int h=comGUI.Menu.rnd.Next(81);
                    string h1=scheme[h].ToString();
                    if(list[h].Text=="") { 
                    list[h].Text=h1;
                    user[h]=int.Parse(h1);
                    list[h].ForeColor=Color.Violet;col[h]=Color.Violet;}
                    else{a--; }
                }
                timer3.Start();
                    label4.Visible=true;
                }
            }
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData){
            if (keyData == Keys.D0||keyData == Keys.NumPad0||keyData == Keys.Back )  {keyd=0;}
            else if (keyData == Keys.D1||keyData == Keys.NumPad1 )  {keyd=1;}
            else if (keyData == Keys.D2||keyData == Keys.NumPad2 )  {keyd=2;}
            else if (keyData == Keys.D3||keyData == Keys.NumPad3 )  {keyd=3;}
            else if (keyData == Keys.D4||keyData == Keys.NumPad4 )  {keyd=4;}
            else if (keyData == Keys.D5||keyData == Keys.NumPad5 )  {keyd=5;}
            else if (keyData == Keys.D6||keyData == Keys.NumPad6 )  {keyd=6;}
            else if (keyData == Keys.D7||keyData == Keys.NumPad7 )  {keyd=7;}
            else if (keyData == Keys.D8||keyData == Keys.NumPad8 )  {keyd=8;}
            else if (keyData == Keys.D9||keyData == Keys.NumPad9 )  {keyd=9;}
            //Debug.WriteLine(selected);
        if(selected!=-1) { 
                if(keyData==Keys.Up && user[selected]!=9) {keyd=user[selected]+1; }
                if(keyData==Keys.Down && user[selected]!=0) {keyd=user[selected]-1; }
         if(keyd==0) { list[selected].Text="";}
         else {list[selected].Text=keyd.ToString(); }
         user[selected]=keyd;
                bool winner=true;
                for(int a=0;a<81;a++) {if(user[a]!=scheme[a]) {winner=false;} }//Debug.WriteLine(winner);
                if(winner) {win(true); }
        }
            return true;
        }
        
        private void win(bool end) {
            timer3.Stop();
            se[se.Count-1].Visible=false;
            for(int a=0;a<81;a++) {list[a].ForeColor=Color.Violet;col[a]=Color.Violet;list[a].Text=scheme[a].ToString();user[a]=scheme[a];}
            
            winn=true;
            radioButton1.Checked=true;
            radioButton2.Checked=false;
            radioButton3.Checked=false;
            radioButton4.Checked=false;
            label2.Visible=true;
            if(end) { 
            label2.Text="Hai vinto";
            label2.ForeColor=Color.Lime;}
            else {label2.Text="Hai perso";
            label2.ForeColor=Color.Red;} 
             button1.Visible=true;
            selected=-1;
            button1.Text="Reset";
        }
        
        private void generate2() {
            List<int> i=new List<int> { 403,433,463};
            List<int> ii=new List<int> {100,130,160};
            for(int a=0;a<3;a++) {for(int b=0;b<3;b++) {Button x= createButton2(i[b],ii[a]);x.Text=(3*a+b+1).ToString();se.Add(x); } }
            Button x1= createButton2(403,190);
            x1.Size=new Size(84,24);x1.Text="Fine";se.Add(x1);
            Button x2=createButton2(403,30);x2.Size=new Size(84,24);
            x2.Text="Resa";x2.ForeColor=Color.Red;se.Add(x2);
        }

        private Button createButton2(int x,int y) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(24, 24);
            s.Visible=false;
            s.BackColor=Color.Black;
            s.ForeColor=Color.Cyan;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.Click += new EventHandler(buttonClick2);
            Controls.Add(s);
            col.Add(Color.Cyan);
            return s;
        }

        private void buttonClick2(object sender, EventArgs e) {
            Button x=(sender as Button);
            if(x.Text=="Fine") {for(int a=0;a<81;a++) {timer1.Stop(); list[a].ForeColor=col[a]; }label3.Text=""; }
            else if(x.Text=="Resa") {for(int a=0;a<81;a++) {list[a].ForeColor=Color.Violet;col[a]=Color.Violet;list[a].Text=scheme[a].ToString(); }win(false); }
            else {tim=int.Parse(x.Text);timer1.Start(); }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            List<int>col1=new List<int>();
            for(int a=0;a<81;a++) {
                    list[a].ForeColor=Color.Cyan; 
                    } 

            for(int a=0;a<9;a++) {
                    int p=0;
                if(user.GetRange(9*a,9).Contains(tim)) {for(int b=0;b<9;b++) {if(user.GetRange(9*a,9)[b]==tim) {p++;} }
                 if (p==1) {if(checkBox1.ForeColor==Color.Lime) { for(int b=0;b<9;b++) {list[a*9+b].ForeColor=Color.Navy;}}}
                else {for(int b=0;b<9;b++) {col1.Add(a*9+b); } }
                    }
            }

            List<int> h = new List<int> { 0, 9, 18, 27, 36, 45, 54, 63, 72 };

            for (int a = 0; a < 9; a++) {
                List<int> tru = new List<int>();
                tru.Clear();
                    int p=0;
                for (int b = 0; b < 9; b++) { tru.Add(user[h[b]]);if(user[h[b]]==tim){p++;} }
                if (tru.Contains(tim)) {
                        if(p==1) { 
                        for (int b = 0; b < 9; b++) {if(checkBox2.ForeColor==Color.Lime) { list[h[b]].ForeColor = Color.Navy;} }}
                        else {for (int b = 0; b < 9; b++) {col1.Add(h[b]);  } }
                    }
                for (int b = 0; b < 9; b++) { h[b] = h[b] + 1; }
            }

            h.Clear();
            h=new List<int> {0,1,2,9,10,11,18,19,20};
            for(int a=0;a<9;a++) {
                List<int> tru = new List<int>();
                    int p=0;
                tru.Clear();
                for (int b = 0; b < 9; b++) { tru.Add(user[h[b]]);if(user[h[b]]==tim){p++;} }

                if (tru.Contains(tim)) {if(p==1) {if(checkBox3.ForeColor==Color.Lime) { for (int b = 0; b < 9; b++) { list[h[b]].ForeColor = Color.Navy;} }}
                        else {for (int b = 0; b < 9; b++) {col1.Add(h[b]);  } } }
                
                if((a+1)%3!=0) {for (int b = 0; b < 9; b++) { h[b] = h[b] + 3; } }
                else {for (int b = 0; b < 9; b++) { h[b] = h[b] + 21; } }
            }

            int g=0;
            for(int a=0;a<81;a++) {
                    if(list[a].Text==tim.ToString()) {if(!col1.Contains(a)){ list[a].ForeColor=Color.Lime;}else {list[a].ForeColor=Color.Maroon;} g++; }
                    } 
            label3.ForeColor=g>9?Color.Red:Color.Lime;
            label3.Text="Usati "+g+" su 9";
        }

        private void timer2_Tick(object sender, EventArgs e) {
            if(label2.Visible&&label2.Text=="Generazione in Corso...") {checkBox1.Visible=false;checkBox2.Visible=false;checkBox3.Visible=false; }
            else {checkBox1.Visible=true;checkBox2.Visible=true;checkBox3.Visible=true; }
            label3.Visible=!radioButton1.Visible;
        }

        private void checkBox1_Click(object sender, EventArgs e) {
            checkBox1.ForeColor=checkBox1.ForeColor==Color.Lime?Color.Red:Color.Lime;
        }

        private void checkBox2_Click(object sender, EventArgs e) {
        checkBox2.ForeColor=checkBox2.ForeColor==Color.Lime?Color.Red:Color.Lime;
        }

        private void checkBox3_Click(object sender, EventArgs e) {
        checkBox3.ForeColor=checkBox3.ForeColor==Color.Lime?Color.Red:Color.Lime;
        }

        private void timer3_Tick(object sender, EventArgs e) {
            if(time<5999) {time+=1; }
            string s="";
            s+=(time/60)<10? "0"+((int)(time/60)).ToString():((int)(time/60)).ToString();
            s+=" : ";
            s+=(time%60)<10? "0"+(time%60).ToString():(time%60).ToString();
            label4.Text=s;
        }

        int selected=-1,time=0,keyd=0,tim=0;
        bool winn=false;
        List<Button> list=new List<Button>(),se=new List<Button>();
        List<int> scheme=new List<int>(),user=new List<int>();
        List<Color> col=new List<Color>();
    }
}
