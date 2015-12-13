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
    public partial class Ruffini : Form {
        public Ruffini() {
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
        private bool assign(bool where,string s){
            if(where) { 
                    if (s!=""&&s!="-") { num.Add(int.Parse(s));}
                    else if (s=="-") {s+="1"; num.Add(int.Parse(s));}
                    }
                    else {
                    if (s!=""&&s!="-") {Debug.WriteLine(s); esp.Add(int.Parse(s));where=true;}
                    else {esp.Add(1);where=true; }
                    }
            return where;
        }
        List<int>num=new List<int>();
        List<int>esp=new List<int>();
        List<string>listfinal=new List<string>();
        List<char>allownum=new List<char>("0123456789".ToCharArray());
        List<char>allowsym=new List<char>("+-^".ToCharArray());
        private void button1_Click(object sender, EventArgs e) {
            string o=numb.Text;
            string oo=expo.Text;
            if(o==""&&oo=="") { }
            else { 
            string sym="+";
            int j1=0,j2=0;
            if(o!="") {j1=int.Parse(o); }else {j1=1; }
            if(button5.Text=="-") {j1*=-1; sym="-";}
            if(oo!="") {j2=int.Parse(oo); }else {j2=0; }
            if(!esp.Contains(j2)) { 
            if(final.Text!=""||sym=="-") {final.Text+=sym; }
            if(j2>1) { final.Text+=o+var.Text+"^"+oo;}
            else if(j2==1) { final.Text+=o+var.Text;}
            else if(j2==0) { final.Text+=o;}
            esp.Add(j2);
            num.Add(j1);
            listfinal.Add(final.Text);
            }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if(var.Text.Length==1) { 
                var.Visible=false;
                button2.Visible=false;
                numb.Visible=true;
                expo.Visible=true;
                final.Visible=true;
                button1.Visible=true;
                button3.Visible=true;
                button4.Visible=true;
                button5.Visible=true;
                button6.Visible=true;
                button7.Visible=true;
                textBox1.Visible=true;
                textBox2.Visible=true;
                textBox3.Visible=true;
                label1.Visible=true;
                label2.Visible=true;
                label3.Visible=true;
                label4.Visible=true;
                label5.Visible=true;
                label6.Visible=true;
                label4.Text=var.Text+" ^";
                label1.Text="("+var.Text+"                    )";
            
            }
        }

        private void button3_Click(object sender, EventArgs e) {
                var.Visible=true;
                button2.Visible=true;
                numb.Visible=false;
                expo.Visible=false;
                final.Visible=false;
                button1.Visible=false;
                button3.Visible=false;
                button4.Visible=false;
                button5.Visible=false;
                button6.Visible=false;
                button7.Visible=false;
                textBox1.Visible=false;
                textBox2.Visible=false;
                textBox3.Visible=false;
                label1.Visible=false;
                label2.Visible=false;
                label3.Visible=false;
                label4.Visible=false;
                label5.Visible=false;
                label6.Visible=false;
            esp.Clear();
            num.Clear();
            listfinal.Clear();
            solnumb=oldexpo=oldte=numb.Text=expo.Text=textBox1.Text=textBox2.Text=textBox3.Text=final.Text="";
            
        }
        string solnumb="";
        private void numb_TextChanged(object sender, EventArgs e) {
            List<char>allowed=new List<char>("0123456789".ToCharArray());
            bool pass=true;
            for(int a=0;a<numb.Text.Length;a++) {if(!allowed.Contains(numb.Text[a])) {pass=false;break; } }
            if(pass) {solnumb=numb.Text; }
            else {numb.Text=solnumb; }
        }
        string oldexpo="";
        private void expo_TextChanged(object sender, EventArgs e) {
            List<char>allowed=new List<char>("0123456789".ToCharArray());
            bool pass=true;
            for(int a=0;a<expo.Text.Length;a++) {if(!allowed.Contains(expo.Text[a])) {pass=false;break; } }
            if(pass) {oldexpo=expo.Text; }
            else {expo.Text=oldexpo; }
        }

        private void button4_Click(object sender, EventArgs e) {
            textBox2.Text=textBox3.Text="";
            if(textBox1.Text=="") {textBox1.Text="1"; }
            List<int>newnum=new List<int>();
            List<int>newesp=new List<int>();
            List<int>oldesp=new List<int>(esp);
            int k=oldesp.Max();
            for(int a=0;a<k;a++) {
                if(oldesp.Contains(a)) {
                    int h=oldesp.IndexOf(a);
                    newesp.Add(esp[h]);
                    newnum.Add(num[h]);
                }else {
                    newesp.Add(a);
                    newnum.Add(0);
                }
            }
             int h1=oldesp.IndexOf(oldesp.Max());
                    newesp.Add(esp[h1]);
                    newnum.Add(num[h1]);
            newnum.Reverse();
            newesp.Reverse();
          //  for(int a=0;a<newesp.Count;a++) {textBox2.Text+=newnum[a]+" ";textBox3.Text+=newesp[a]+" "; }
            int sec=int.Parse(button6.Text+textBox1.Text)*-1;
            if(sec!=0) { 
            calc(newnum,sec);
                }
        }

        private void calc(List<int>fir,int s) {
            int h=esp.Max()-1;
            int y=0;
            for(int a=0;a<fir.Count;a++) {
                string l=(fir[a]+y).ToString();
                if(h!=esp.Max()-1) { 
                if(l[0]!='-') {l="+"+l; }}
                if(l=="-1") {l="-"; }
                else if(l=="+1") {l="+"; }
                else if(l=="1") {l=""; }
                if(h!=-1){
                if(l!="+0"&&l!="-0"&&l!="0") { 
                if(h>0) {l+=var.Text; }
                if(h>1) {l+="^"+h.ToString(); }
                }else {l=""; }
                textBox2.Text+=l;
                }
                else{if(l=="+0"||l=="-0") {textBox3.Text+="0";}else {  textBox3.Text+=l;} }
                y=(fir[a]+y)*s;
                h--;
            }

        }

        private void button5_Click(object sender, EventArgs e) {
            button5.Text=button5.Text=="+"?"-":"+";
        }

        private void button6_Click(object sender, EventArgs e) {
            button6.Text=button6.Text=="+"?"-":"+";
        }
        string oldte="";
        private void textBox1_TextChanged(object sender, EventArgs e) {
            List<char>allowed=new List<char>("0123456789".ToCharArray());
            bool pass=true;
            for(int a=0;a<textBox1.Text.Length;a++) {if(!allowed.Contains(textBox1.Text[a])) {pass=false;break; } }
            if(pass) {oldte=textBox1.Text; }
            else {textBox1.Text=oldte; }
        }

        private void button7_Click(object sender, EventArgs e) {
            if(esp.Count>0) { 
             esp.RemoveAt(esp.Count-1);
            num.RemoveAt(num.Count-1);
            listfinal.RemoveAt(listfinal.Count-1);
           try { final.Text=listfinal[listfinal.Count-1];}catch(ArgumentOutOfRangeException) {final.Text=""; }
                }
        }

        private void final_MouseEnter(object sender, EventArgs e) {

        }

        private void var_TextChanged(object sender, EventArgs e) {
            List<char>allowed=new List<char>("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            try { if(!allowed.Contains(var.Text[0])) {var.Text=""; }}catch(IndexOutOfRangeException) {}
        }
    }
}
