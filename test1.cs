using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class test1 : Form {
        public test1() {
            InitializeComponent();
            this.FormClosing += back;
        }
        private void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            oooo.Show();}
            else { 
                 Dispose();
               }
        }

        List<Button>list=new List<Button>();
        List<Color>col=new List<Color>();
        List<List<List<int>>>boat=new List<List<List<int>>>();
        public BattagliaSetting oooo;
        public List<int>numBoat=new List<int>();
        public int hei,bas;
        int gen=5;
        bool align=false,ok=false;

        private bool place(int x,int gen) {
            if(align) { 
            if(gen==1) {
                    if(list[x].ForeColor==Color.Cyan) {list[x].ForeColor=Color.Lime; }
                    else {list[x].ForeColor=Color.Red; }
                }
            else if(gen==2) {
                    try { 
                    if(x%bas!=0) {
                        list[x-1].ForeColor=list[x].ForeColor=Color.Lime;
                    }
                    else {list[x].ForeColor=Color.Red; }
                }catch(ArgumentOutOfRangeException) {list[x].ForeColor=Color.Red;} }
            else if(gen==3) {
                    if((x+1)==list.Count) {list[x].ForeColor=list[x-1].ForeColor=Color.Red; }
                    else if((x-1)==-1) {list[x].ForeColor=list[x+1].ForeColor=Color.Red; }
                    else {

                        if(x%bas==0) {
                        list[x].ForeColor=list[x+1].ForeColor=Color.Red;
                        }
                        else if((x+1)%bas==0) {
                        list[x].ForeColor=list[x-1].ForeColor=Color.Red;
                        }
                        else {
                            list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=Color.Lime;
                        }
                    }
                }
            else if(gen==4) {
                    if((x+1)==list.Count) {list[x].ForeColor=list[x-1].ForeColor=list[x-2].ForeColor=Color.Red; }
                    else if((x-1)==-1) {list[x].ForeColor=list[x+1].ForeColor=Color.Red; }
                    else if((x-2)==-1) {list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=Color.Red; }
                    else {

                        if(x%bas==0) {
                        list[x].ForeColor=list[x+1].ForeColor=Color.Red;
                        }
                        else if((x-1)%bas==0) {
                        list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=Color.Red;
                        }
                        else if((x+1)%bas==0) {
                        list[x].ForeColor=list[x-1].ForeColor=list[x-2].ForeColor=Color.Red;
                        }
                        else {
                            list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=list[x-2].ForeColor=Color.Lime;
                        }
                    }
                }
            else if(gen==5) {
                    if((x+1)==list.Count) {list[x].ForeColor=list[x-1].ForeColor=list[x-2].ForeColor=Color.Red; }
                    else if((x+2)==list.Count) {list[x].ForeColor=list[x-1].ForeColor=list[x-2].ForeColor=list[x+1].ForeColor=Color.Red; }
                    else if((x-1)==-1) {list[x].ForeColor=list[x+1].ForeColor=list[x+2].ForeColor=Color.Red; }
                    else if((x-2)==-1) {list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=list[x+2].ForeColor=Color.Red; }
                    else {

                        if(x%bas==0) {
                        list[x].ForeColor=list[x+1].ForeColor=list[x+2].ForeColor=Color.Red;
                        }
                        else if((x-1)%bas==0) {
                        list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=list[x+2].ForeColor=Color.Red;
                        }
                        else if((x+1)%bas==0) {
                        list[x].ForeColor=list[x-1].ForeColor=list[x-2].ForeColor=Color.Red;
                        }
                        else if((x+2)%bas==0) {
                        list[x].ForeColor=list[x-1].ForeColor=list[x-2].ForeColor=list[x+1].ForeColor=Color.Red;
                        }
                        else {
                            list[x].ForeColor=list[x-1].ForeColor=list[x+1].ForeColor=list[x-2].ForeColor=list[x+2].ForeColor=Color.Lime;
                        }
                    }
                }
            }
        else {
               if(gen==1) {
                    if(list[x].ForeColor==Color.Cyan) {list[x].ForeColor=Color.Lime; }
                    else {list[x].ForeColor=Color.Red; }
                }
            else if(gen==2) {
                    if((x-bas)<0) {list[x].ForeColor=Color.Red;}
                    else {list[x].ForeColor=list[x-bas].ForeColor=Color.Lime; }
                        }
            else if(gen==3) {
                    if((x+bas)>=list.Count) {list[x].ForeColor=list[x-bas].ForeColor=Color.Red; }
                    else if((x-bas)<=-1) {list[x].ForeColor=list[x+bas].ForeColor=Color.Red; }
                    else {
                            list[x].ForeColor=list[x-bas].ForeColor=list[x+bas].ForeColor=Color.Lime;
                        
                    }
                }
            else if(gen==4) {
                    if((x+bas)>=list.Count) {list[x].ForeColor=list[x-bas].ForeColor=list[x-bas-bas].ForeColor=Color.Red; }
                    else if((x-bas)<=-1) {list[x].ForeColor=list[x+bas].ForeColor=Color.Red; }
                    else if((x-bas-bas)<=-1) {list[x].ForeColor=list[x-bas].ForeColor=list[x+bas].ForeColor=Color.Red; }
                    else {
                        
                            list[x].ForeColor=list[x-bas].ForeColor=list[x+bas].ForeColor=list[x-bas-bas].ForeColor=Color.Lime;
                        
                    }
                }
            else if(gen==5) {
                    if((x+bas)>=list.Count) {list[x].ForeColor=list[x-bas].ForeColor=list[x-bas-bas].ForeColor=Color.Red; }
                    else if((x+bas+bas)>=list.Count) {list[x].ForeColor=list[x-bas].ForeColor=list[x-bas-bas].ForeColor=list[x+bas].ForeColor=Color.Red; }
                    else if((x-bas)<=-1) {list[x].ForeColor=list[x+bas].ForeColor=list[x+bas+bas].ForeColor=Color.Red; }
                    else if((x-bas-bas)<=-1) {list[x].ForeColor=list[x-bas].ForeColor=list[x+bas].ForeColor=list[x+bas+bas].ForeColor=Color.Red; }
                    else {

                            list[x].ForeColor=list[x-bas].ForeColor=list[x+bas].ForeColor=list[x-bas-bas].ForeColor=list[x+bas+bas].ForeColor=Color.Lime;
                        
                    }
                }
            }
             List<int>h=new List<int>();
             for(int a=0;a<list.Count;a++) {if(list[a].ForeColor==Color.Lime) {h.Add(a);} }
             for(int a=0;a<h.Count;a++) {if(col[h[a]]!=Color.Cyan) {
                    for(int b=0;b<h.Count;b++) {list[h[b]].ForeColor=Color.Red; }
                } }
            return list[x].ForeColor==Color.Lime?true:false;
        }

        private void createButton(int x,int y) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(20, 20);
            s.BackColor=Color.Black;
            s.ForeColor=Color.Cyan;
            s.FlatStyle = FlatStyle.Flat;
            s.FlatAppearance.BorderSize = 3;
            s.UseVisualStyleBackColor = true;
            s.MouseUp += new MouseEventHandler(buttonClick);
            s.MouseEnter+=new EventHandler(buttonEnter);
            s.MouseLeave+=new EventHandler(buttonLeave);
            Controls.Add(s);
            col.Add(Color.Cyan);
            list.Add(s);
        }

        private void buttonLeave(object sender, EventArgs e) {
            for(int a=0;a<list.Count;a++) {list[a].ForeColor=col[a]; }
        }

        private void buttonClick(object sender, MouseEventArgs e) {
            if(e.Button.ToString()=="Left") {

            if(button2.ForeColor==Color.Lime) {
                    int k=list.IndexOf(sender as Button);
                    if(list[k].ForeColor!=Color.Cyan) {
                        Color c=list[k].ForeColor;
                        int h=-1;
                        for(int a=0;a<list.Count;a++) {if(col[a]==c) {list[a].ForeColor=Color.Cyan;col[a]=Color.Cyan;h++;}
                        }
                        numBoat[h]=numBoat[h]+1;
                        gen=h+1;button1.Text=(h+1).ToString();
                        for(int a=0;a<boat[h].Count;a++) {if(boat[h][a].Contains(k)) {boat[h].RemoveAt(a);break; } }
                    }
                }
            else { 
                if(button1.Text!="") { 
            if(ok) {
                List<int>h=new List<int>();
                for(int a=0;a<list.Count;a++) {if(list[a].ForeColor==Color.Lime) {h.Add(a);} }
                Debug.WriteLine(h.Count);
                    Random rnd=comGUI.Menu.rnd;
                    Color kk=Color.FromArgb(rnd.Next(256),rnd.Next(256),rnd.Next(256));
                for(int a=0;a<h.Count;a++) {col[h[a]]=kk; }
                if(h.Count>0) { boat[gen-1].Add(h);}
                for(int a=0;a<list.Count;a++) {list[a].ForeColor=col[a]; }
                ok=place(list.IndexOf(sender as Button),gen);
                    numBoat[gen-1]=numBoat[gen-1]-1;
                    label1.Text=numBoat[gen-1].ToString();
                    if(numBoat[gen-1]==0) {
                        if(numBoat[0]>0) {gen=1;label1.Text=numBoat[0].ToString();button1.Text="1"; }
                        else if(numBoat[1]>0) {gen=2;label1.Text=numBoat[0].ToString();button1.Text="2"; }
                        else if(numBoat[2]>0) {gen=3;label1.Text=numBoat[0].ToString();button1.Text="3"; }
                        else if(numBoat[3]>0) {gen=4;label1.Text=numBoat[0].ToString();button1.Text="4"; }
                        else if(numBoat[4]>0) {gen=5;label1.Text=numBoat[0].ToString();button1.Text="5"; }
                        else {button1.Text="";gen=0; }
                    }
                        }
            
                    }
           
                }
            }
            if(e.Button.ToString()=="Right") {
                align=!align;
                for(int a=0;a<list.Count;a++) {list[a].ForeColor=col[a]; }
                ok=place(list.IndexOf(sender as Button),gen);
            }

        }
        
        private void button1_Click(object sender, EventArgs e) {
            if(button1.Text!="") { 
            int j=int.Parse(button1.Text);
            List<int>k=new List<int>();
            for(int a=0;a<5;a++) {
                if(numBoat[a]!=0) {k.Add(a+1); }
            }
           try { if(k[0]==j) {button1.Text=k[k.Count-1].ToString(); }
            else {button1.Text=k[k.IndexOf(j)-1].ToString(); }}catch(ArgumentOutOfRangeException) { }
            gen=int.Parse(button1.Text);
            label1.Text=numBoat[gen-1].ToString();
        }
        }

        private void button2_Click(object sender, EventArgs e) {
            button2.ForeColor=button2.ForeColor==Color.Red?Color.Lime:Color.Red;
        }

        private void buttonEnter(object sender, EventArgs e) {
            if(button2.ForeColor==Color.Red) { 
            ok=place(list.IndexOf(sender as Button),gen);
            }
        }


        
        private void Battaglia_Load(object sender, EventArgs e) {
            for(int a=0;a<5;a++) {boat.Add(new List<List<int>>()); }
            if(numBoat[4]!=0) {button1.Text="5";gen=5;}
            else if(numBoat[3]!=0) {button1.Text="4";gen=4; }
            else if(numBoat[2]!=0) {button1.Text="3";gen=3; }
            else if(numBoat[1]!=0) {button1.Text="2";gen=2; }
            else if(numBoat[0]!=0) {button1.Text="1";gen=1; }
            label1.Text=numBoat[gen-1].ToString();
            List<int>pos1=new List<int>();
            List<int>pos2=new List<int>();
            int j=5;
            for(int a=0;a<bas;a++) {
                pos1.Add(j);
                j+=25;
            }
            j=5;
            for (int a=0;a<hei;a++) {
                pos2.Add(j);
                j+=25;
                
            }
            for(int b=0;b<pos2.Count;b++) {
                for (int a=0;a<pos1.Count;a++) {createButton(pos1[a],pos2[b]);}
            }
        }
        
    }
}
