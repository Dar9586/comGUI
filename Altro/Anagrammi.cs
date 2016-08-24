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
    public partial class Anagrammi : Form {
        public Anagrammi() {
            InitializeComponent();
        this.FormClosing += back;
        }
         void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }

        List<char> ch=new List<char>();
        List<int> rip=new List<int>();
         int fact(int x) {
            int l=1;
            for(int a=1;a<x+1;a++) {l*=a; }
            return l;
        }
         void met1() {
            List<char>s=new List<char>(textBox1.Text.ToCharArray());
            int pos=0;
            ch.Clear();rip.Clear();
            for(int a=0;a<s.Count;a++) {
                if(!ch.Contains(s[a])) {ch.Add(s[a]);rip.Add(1); }
                else {rip[ch.IndexOf(s[a])]=rip[ch.IndexOf(s[a])]+1; }
                int l=fact(s.Count);
                int k=1;
                for(int b=0;b<rip.Count;b++) {
                    k*=fact(rip[b]);
                }
                pos=l/k;
            }
            List<string>final=new List<string>();
            while(true) {
                List<char> i=new List<char>(textBox1.Text.ToCharArray());
                string h="";
                while(i.Count!=0) {int j=rnd.Next(i.Count); h+=i[j];i.RemoveAt(j); }
                if(!final.Contains(h)) {final.Add(h); }
                if(final.Count==pos) {break; }
            }
                final.Sort();
            for(int a=0;a<final.Count;a++) {richTextBox1.Text+=final[a];if(a+1<final.Count) { richTextBox1.Text+="\n";} }
        }
        Random rnd=new Random(Environment.TickCount);
        List<string> final2=new List<string>();
         void comb(Tuple<List<char>, string> z) {
           List<char> x=z.Item1;
           string y=z.Item2;
            if (x.Count!=0){ 
            for(int a=0;a<x.Count;a++) {
                List<char>cac=new List<char>(x);
                string o=y+cac[a].ToString();
                cac.RemoveAt(a);
                Tuple<List<char>, string> tuple =new Tuple<List<char>, string>(cac,o);
                comb(tuple);
                }
            }
            else {if(!final2.Contains(y)){ final2.Add(y);richTextBox1.Text+="\n"+y;} }
        }

         async void met2() {
            final2.Clear();
            List<char>start2=new List<char>(textBox1.Text.ToCharArray());
            List<char>start=new List<char>();
            final2.Add(textBox1.Text);
            button1.Text="Generando...";
            button1.ForeColor=Color.Lime;
            await Task.Delay(50);
            richTextBox1.Text+=textBox1.Text;
            for(int a=0;a<start2.Count;a++) {if(!start.Contains(start2[a])) {start.Add(start2[a]);} }
            for(int a=0;a<start.Count;a++) {
                List<char>cac2=new List<char>(start);
                List<char>cac=new List<char>(start2);
                string o=cac2[a].ToString();
                cac.RemoveAt(start2.IndexOf(start[a]));
                Tuple<List<char>, string> tuple =new Tuple<List<char>, string>(cac,o);
                comb(tuple);
            }
            button1.Text="Genera";
            button1.ForeColor=Color.Cyan;
        }


         void textBox1_TextChanged(object sender, EventArgs e) {
            if(textBox1.Text.Length>6) {label2.Visible=true;label1.Visible=true; }
            else{label2.Visible=false;label1.Visible=false; }
        }

         void button1_Click(object sender, EventArgs e) {
            if(textBox1.Text.Length>0&&button1.Text=="Genera") { 
                richTextBox1.Text="";
              //  met1();
              met2();
            }
            else {richTextBox1.Text=""; }
        }
    }
}
