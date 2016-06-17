using System;
using System.Windows.Forms;

namespace comGUI {
    public partial class Calcolatrice : Form {
        public Calcolatrice() {
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
         void button1_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
          if(textBox1.Text!="∞") {  textBox1.Text+="7";}cl=true;
        }
         void button2_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
          if(textBox1.Text!="∞") {  textBox1.Text+="8";}cl=true;
        }
         void button3_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
          if(textBox1.Text!="∞") {  textBox1.Text+="9";}cl=true;
        }
         void button4_Click(object sender, EventArgs e) {
          num1=double.Parse(textBox1.Text);  textBox1.Text="0";
            op=3;cl=true;
        }
         void button5_Click(object sender, EventArgs e) {
        num1=double.Parse(textBox1.Text);  textBox1.Text="0";
            op=4;
            cl=true;
        }     
         void button6_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
            if(textBox1.Text!="∞") {textBox1.Text+="6";}cl=true;
        }
         void button7_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
          if(textBox1.Text!="∞") {  textBox1.Text+="5";}cl=true;
        }
         void button8_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
          if(textBox1.Text!="∞") {  textBox1.Text+="4";}cl=true;
        }
         void button9_Click(object sender, EventArgs e) {
            num1=double.Parse(textBox1.Text);
            textBox1.Text="0";
            op=1;cl=true;
        }
         void button10_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
            if(textBox1.Text!="∞") { textBox1.Text+="3";}cl=true;
        }
         void button11_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
            if(textBox1.Text!="∞") {textBox1.Text+="2";}cl=true;
        }
         void button12_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
           if(textBox1.Text!="∞") { textBox1.Text+="1";}cl=true;
        }
         void button13_Click(object sender, EventArgs e) {
         num1=double.Parse(textBox1.Text); textBox1.Text="0";
            op=2;cl=true;
        }
         void button14_Click(object sender, EventArgs e) {
            bool con=true;
            for(int a=0;a<textBox1.TextLength;a++) {if(textBox1.Text.ToCharArray()[a].ToString()==",") {con=false;} }
            if(con) {textBox1.Text+=","; }cl=true;
        }
         void button15_Click(object sender, EventArgs e) {
            if(textBox1.Text=="0") {textBox1.Text=""; }
            textBox1.Text+="0";cl=true;
        }  
         void button16_Click(object sender, EventArgs e) {
            if(textBox1.Text.ToCharArray()[0].ToString()=="-") {textBox1.Text=textBox1.Text.Substring(1); }
            else { textBox1.Text="-"+textBox1.Text;}cl=true;
        }
         void button17_Click(object sender, EventArgs e) {
            num1=num2=0;op=0;textBox1.Text="0";
        }
         void button18_Click(object sender, EventArgs e) {
            textBox1.Text="0";
        }
         void button19_Click(object sender, EventArgs e) {
            if(textBox1.Text.Length==1||(textBox1.Text.Length==2&&textBox1.Text.ToCharArray()[0].ToString()=="-")) {textBox1.Text="0"; }
            else {textBox1.Text=textBox1.Text.Substring(0,textBox1.Text.Length-1); }cl=true;
        }
         void button20_Click(object sender, EventArgs e) {
            if(cl) {cl=false;num2=double.Parse(textBox1.Text); }
            if(op==1) {  num1+=num2;textBox1.Text="0";}
            else if(op==2) {  num1-=num2;textBox1.Text="0";}
           else  if(op==3) {  num1*=num2;textBox1.Text="0";}
            else if(op==4) {  num1/=num2;textBox1.Text="0";}
            textBox1.Text=num1.ToString();
        }
        
         double op=0;
         double num1=0;
         double num2=0;
         bool cl=true;   
    }
}
