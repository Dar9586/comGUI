using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class Memory : Form {
        public Memory() {
            InitializeComponent();
        this.FormClosing += back;
        }
        private async void buttonClick(object sender, EventArgs e) {
            m.memmen.timer1.Start();
            try { 
            if(m.memmen.timer1.Enabled==false) { m.memmen.timer1.Start();}
            int k=list.IndexOf((sender as Button));
            if(list[k].Text=="") { 
            list[k].Text=(string)list[k].Tag;
            if(f==9999) {
                f=k;
            }
            else {
                if(list[f].Text!=list[k].Text) {
                        list[f].ForeColor=Color.Red;
                        list[k].ForeColor=Color.Red;
                        await Task.Delay(500);
                        list[f].ForeColor=Color.Cyan;
                        list[k].ForeColor=Color.Cyan;
                        list[f].Text=""; list[k].Text="";
                    }
                else {
                        list[f].ForeColor=Color.Lime;
                        list[k].ForeColor=Color.Lime;
                        find++;
                    }
                f=9999;
            }
         }}catch(ArgumentOutOfRangeException) {list[list.IndexOf((sender as Button))].Text=""; }
            }
        private void create(int x,int y,string tag,int tab) {
            Button s=new Button();
            s.Location = new Point(x, y);
            s.Size = new Size(24, 24);
            s.TabIndex=tab;
            s.Font = new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            s.Tag=tag;
            s.BackColor=Color.Black;
            s.ForeColor=Color.Cyan;
            s.FlatStyle = FlatStyle.Flat;
            s.UseVisualStyleBackColor = true;
            s.Click += new EventHandler(buttonClick);
            Controls.Add(s);
            list.Add(s);
        }
        private void timer1_Tick(object sender, EventArgs e) {
            try { if(ooo) {m.memmen.Show(); }}catch(ObjectDisposedException) { }
            x=m.a*m.b/2;
            m.memmen.label2.Text="Completamento: "+find.ToString()+" / "+x.ToString();
            double ss1=find/x;
            double sss1=ss1*100;
            int g=(int)sss1;
            if(find==x) { m.memmen.label4.Visible=m.memmen.button2.Visible=true;m.memmen.button1.Visible=false;}
        }
        private void back(object sender, EventArgs e) {
           m.Show(); m.memmen.Dispose();
        }
        public void createscheme(int k) {
            
            for(int a=0;a<99999;a++) {comGUI.Menu.rnd.Next(1944465); }  
            List<char> li = new List<char> ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray());
            for(int b=0;b<1250;b++) {
               string s=li[comGUI.Menu.rnd.Next(li.Count)].ToString()+li[comGUI.Menu.rnd.Next(li.Count)].ToString();
                if(!lis.Contains(s)) {lis.Add(s); }else {b--; }
            }
             List<string> ca=new List<string>(lis.GetRange(0,k));
             int j=ca.Count;
                    for(int c=0;c<j;c++) {ca.Add(ca[c]); } 
                    j=ca.Count;
                while(ca.Count>0) { 
                int l=comGUI.Menu.rnd.Next(ca.Count);
                final.Add(ca[l]);ca.RemoveAt(l);
                 }
            int x=5,y=2,z=0;
            for(int b=0;b<m.a;b++) {
                for(int a=0;a<m.b;a++) {
                    int h=comGUI.Menu.rnd.Next(final.Count);
                    create(x,y,final[h],(z*m.a)+a);
                    final.RemoveAt(h);
                    x+=26;
                }
                z++;
                x=5;
                y+=26;
            }
            timer1.Start();
        }
        public void lose() {
            timer1.Stop();
            for (int a=0;a<list.Count;a++) {
                list[a].Text=(string)list[a].Tag;
            }
            m.memmen.label4.Text="Hai Perso!";
        }

        private List<string> final=new List<string>();
        private List<string> lis=new List<string>();
        List<Button> list=new List<Button>();
        public MemorySetting m;
        public bool ooo=false;
        public bool sw=false;
        private int f=9999;
        public int find=0;
        public int x=1;
    }
}
