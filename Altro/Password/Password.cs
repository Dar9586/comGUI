using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace comGUI {
    public partial class Password : Form {
        public Password() {
            InitializeComponent();
         this.FormClosing += back;
        }
         void saveFileDialog1_FileOk(object sender, CancelEventArgs e) {
            path.Text=saveFileDialog1.FileName;
        }
         void textBox2_TextChanged(object sender, EventArgs e) {
            List<char>cha=new List<char>(len.Text.ToCharArray());
            List<char> allo=new List<char>("0123456789".ToCharArray());
            bool pass=true;
            for(int a=0;a<cha.Count;a++) {if(!allo.Contains(cha[a])||cha[a]==' ') {pass=false;break;} }
            if(pass) {olds=len.Text; }
            else{len.Text=olds; }
        }
         void how_TextChanged(object sender, EventArgs e) {
            List<char>cha=new List<char>(how.Text.ToCharArray());
            List<char> allo=new List<char>("0123456789".ToCharArray());
            bool pass=true;
            for(int a=0;a<cha.Count;a++) {if(!allo.Contains(cha[a])||cha[a]==' ') {pass=false;break;} }
            if(pass) {olds1=how.Text; }
            else{how.Text=olds1; }
        }
         void button1_Click(object sender, EventArgs e) {
            saveFileDialog1.ShowDialog();
        }
        #pragma warning disable 2202
         void button2_Click(object sender, EventArgs e) {
            if(len.Text.Length>0&&how.Text.Length>0) {
                int le=int.Parse(len.Text);
                int ho=int.Parse(how.Text);
                s.richTextBox1.Text="";
                s.Close();
                s=new PasswordResult();
                s.Show();
               for(int b=0;b<ho;b++) {
                    s.richTextBox1.SelectionColor=Color.Cyan;
                    string init=(b+1).ToString();
                    while(init.Length<ho.ToString().Length) {init="0"+init; }
                    s.richTextBox1.AppendText(init+" ");
                    s.richTextBox1.SelectionColor=Color.White;
                    string pass="";
                    while(pass.Length<le) {
                        int k=rnd.Next(5);
                        if(k==0&&num.Checked) {pass+=nume.ToCharArray()[rnd.Next(10)].ToString(); }
                        else if(k==1&&upp.Checked) {pass+=uppe.ToCharArray()[rnd.Next(26)].ToString(); }
                        else if(k==2&&low.Checked) {pass+=lowe.ToCharArray()[rnd.Next(26)].ToString(); }
                        else if(k==3&&spe.Checked) {pass +=spec.ToCharArray()[rnd.Next(31)].ToString(); }
                        else if(k==4&&use.TextLength>0) {pass+=use.Text.ToCharArray()[rnd.Next(use.TextLength)].ToString(); }
                        else { pass+="";}
                    }
                     if(save.Checked&&path.Text!="") {{try{
					using (StreamWriter sw = File.AppendText(path.Text))
					{
                                     if(b+1<ho) { sw.WriteLine(init+" : "+pass);}
                                     else {sw.Write(init+" : "+pass); }
						sw.WriteLine(init+" : "+pass);
					    sw.Dispose();
						}
                            } catch(Exception){}
				}
                }
                    s.richTextBox1.AppendText(pass);
                    if(b+1<ho) {s.richTextBox1.AppendText("\n"); }
                }
            }
        }
        Random rnd=new Random(Environment.TickCount);
         void timer1_Tick(object sender, EventArgs e) {
            if(use.Text.Length==0&&!upp.Checked&&!low.Checked&&!spe.Checked) {num.Checked=true;num.Enabled=false; }
            else {num.Enabled=true; }
            if(save.Checked) {path.Visible=true;button1.Visible=true; }
            else {path.Visible=false;button1.Visible=false; }
            rnd.Next(10);
        }
         void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        
         string spec = "!#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";
		 string uppe = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	     string lowe = "abcdefghijklmnopqrstuvwxyz";
		 string nume = "0123456789";
         PasswordResult s=new PasswordResult();
        
         string olds1="";
         string olds="";

        public object sw { get;  set; }
    }
}
