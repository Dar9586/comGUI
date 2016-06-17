using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace comGUI {
    public partial class Notazione : Form {
        public Notazione() {
            InitializeComponent();
        this.FormClosing += back;
        }
         void textBox1_TextChanged(object sender, EventArgs e) {
            bool ok=true;
            bool used=false;
            List<char> zer=new List<char>();
            List<char> list=new List<char>(textBox1.Text.ToCharArray());
            List<char> allow=new List<char>(".0123456789".ToCharArray());
            for(int a=0;a<list.Count;a++) {
                if(!allow.Contains(list[a])) {ok=false;break; }
                if(list[a]=='.'&&allow.Contains('.')) {allow.Remove('.');used=true; }
            }
            if(ok) {
                try { 
                while(true) {
                    if(list[0]=='0') {list.RemoveAt(0); }else {break; }
                } }catch(ArgumentOutOfRangeException) { }
                if(list.Count>0) { 
                if(!used ) {
                     
                    while(true) {
                    if(list[list.Count-1]=='0') {list.RemoveAt(list.Count-1);zer.Add('0'); }else {break; }
                } 
                    if(list.Count>1) {list.Insert(1,'.');
                        for(int a=0;a<list.Count-2;a++) {zer.Add('0'); }
                    }
                    if(list.Count>7) {list=list.GetRange(0,5);
                        for(int a=0;a<3;a++) {list.Add('/'); }
                    }
                string lists="";
                string zers="1";
                for(int a=0;a<list.Count;a++) {lists+=list[a].ToString(); }
                for(int a=0;a<zer.Count;a++) { zers+=zer[a].ToString();}
                label1.Text="";
                if(zer.Count==0) { label1.Text=lists ;}
                else if(zer.Count<=5) {label1.Text=lists+" * "+zers;}
                else { 
                label1.Text=lists+" * 10 ^ "+zer.Count.ToString();}
                }
                else if(list[0]=='.'&&list.Count>0){
                    list.RemoveAt(0);
                    for(int a=0;a<list.Count-1;a++) {zer.Add('0'); }
                    try { while(list[0]=='0') {list.RemoveAt(0);}}catch(ArgumentOutOfRangeException) { }
                    if(list.Count>1) { list.Insert(1,'.');}
                string lists="";
                string zers="1";
                        if(list.Count>7) {list=list.GetRange(0,5);
                        for(int a=0;a<3;a++) {list.Add('/'); }
                    }
                for(int a=0;a<list.Count;a++) {lists+=list[a].ToString(); }
                for(int a=0;a<zer.Count;a++) { zers+=zer[a].ToString();}
                label1.Text="";
                if(zer.Count==0) { label1.Text=lists ;}
                else if(zer.Count<=5) {label1.Text=lists+" * (1/"+zers+")";}
                else { 
                label1.Text=lists+" * 10 ^ -"+zer.Count.ToString();}
                }
                else {
                    string lists="";
                        int n=12;
                        if(used) {n++; }
                        if(list.Count>n) {list=list.GetRange(0,10);list.Add('/');list.Add('/');list.Add('/'); }
                for(int a=0;a<list.Count;a++) {lists+=list[a].ToString(); }
                label1.Text=lists+" * 1";
                }
                }
            }
            else {label1.Text=""; }
            if(ok) {olds=textBox1.Text; }else {textBox1.Text=olds; }
            if(textBox1.Text=="") {label1.Text=""; }
        }
         void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
         string olds="";
    }
}
