using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class Sette_e_Mezzo : Form {
        public Sette_e_Mezzo() {
            InitializeComponent();
            FormClosing += back;
        }
        void back(object sender, EventArgs e) {
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        Random rnd=new Random();
        List<Cards>deck=Deck.NapoletanDeck;
        List<int>card=new List<int>();
        private void Sette_e_Mezzo_Load(object sender, EventArgs e) {
            panel1.HorizontalScroll.SmallChange=80;
            panel1.HorizontalScroll.LargeChange=80;
        }
        void addPicture(int x,Bitmap card,Panel pan) {
            PictureBox x1=new PictureBox();
            x1.Image=card;
            x1.Size=new Size(75,100);
            x1.BackColor=Color.White;
            x1.Location=new Point(x,0);
            (pan==panel1?pcbu:pcbc).Add(x1);
            pan.Controls.Add(x1);
        }
        float sum(bool isPlayer) {
            float num=0;
            for(int a=0;a<(isPlayer?data[0]:data[1])+1;a++) {num+=deck[card[a+(isPlayer?0:15)]].Value==0?0.5F:deck[card[a+(isPlayer?0:15)]].Value; }
            (isPlayer?textBox1:textBox2).Text=num.ToString();
            return num;
        }
        List<PictureBox>pcbu=new List<PictureBox>();
        List<PictureBox>pcbc=new List<PictureBox>();
        List<int>data=new List<int>();
        private void button1_Click(object sender, EventArgs e) {
            rewrite(0);
            deck[39].Value=0;
            card.Clear();panel1.Controls.Clear();panel2.Controls.Clear();data=new List<int> {0,0 };
            while(pcbu.Count!=0) {pcbu[0].Dispose();pcbu.RemoveAt(0); }
            while(pcbc.Count!=0) {pcbc[0].Dispose();pcbc.RemoveAt(0); }
            for(int a=0;a<30;a++) {int h=rnd.Next(40);if(!card.Contains(h)) {card.Add(h);}else {a--; } }
            for(int a=28;a<40;a++) {deck[a].Value=0; }
            addPicture(0,deck[card[0]].Image,panel1);
            addPicture(0,Utility.ResizeImage(Properties.Resources.Cover,new Size(75,100)),panel2);
            sum(true);textBox2.Text="???";
            button1.Visible=false;button2.Visible=true;button3.Visible=true;
        }
        void rewrite(int x) {
            if(x==0) {label1.Text=""; }
            if(x==1) {label1.Text="Hai Vinto!";label1.ForeColor=Color.Green; }
            if(x==2) {label1.Text="Hai Perso!";label1.ForeColor=Color.Red; }
            if(x==3) {label1.Text="Pareggio!";label1.ForeColor=Color.Blue; }
        }
        private void button2_Click(object sender, EventArgs e) {
            panel1.HorizontalScroll.Value=0;
            for(int a=0;a<pcbu.Count;a++) {pcbu[a].Location=new Point(pcbu[a].Location.X+80,0); }
            data[0]++;addPicture(0,deck[card[data[0]]].Image,panel1);
            if(card[data[0]]==39) {select10(true);}
            if (sum(true)>7.5F) {rewrite(2);button3.Visible=false;button2.Visible=false;button1.Visible=true; }
            else if (sum(true)==7.5F&&data[0]==1) {rewrite(1);button3.Visible=false;button2.Visible=false;button1.Visible=true;}
            else if (sum(true)==7.5F) {button3.Visible=false;button2.Visible=false;button1.Visible=false;
            pcbc[0].Image=deck[card[15]].Image; AI();}
        }
        async void AI() {
            float h=sum(true);
            for(int a=0;a<3;a++) {
                if(sum(false)>h) {break; }
                else if(sum(false)==h) {break; }
                else if(sum(false)>7.5F) {break; }
                await Task.Delay(1000);
                for(int b=0;b<pcbc.Count;b++) {pcbc[b].Location=new Point(pcbc[b].Location.X+80,0); }
                data[1]++;
                panel2.HorizontalScroll.Value=0;
                if (card[data[1]]==39) {deck[39].Value=(int)(7.5-sum(false));}
                addPicture(0,deck[card[data[1]+15]].Image,panel2);
            }
            button3.Visible=false;button2.Visible=false;button1.Visible=true;
            if(sum(false)>7.5F) {rewrite(1);return; }
            else if(sum(false)>h) {rewrite(2);return; }
            else if(sum(false)==h) {rewrite(2);return;}
            
        }

        private void button3_Click(object sender, EventArgs e) {
            pcbc[0].Image=deck[card[15]].Image;
            AI();
        }
        void select10(bool show) {
            comboBox1.Visible=show;
            button4.Visible=show;
            label4.Visible=show;
            button2.Visible=!show;
            button3.Visible=!show;
        }
        private void button4_Click(object sender, EventArgs e) {
            deck[39].Value=int.Parse(comboBox1.SelectedItem.ToString()[0].ToString());select10(false);
            if (sum(true)>7.5F) {rewrite(2);button3.Visible=false;button2.Visible=false;button1.Visible=true; }
            else if (sum(true)==7.5F&&data[0]==1) {rewrite(1);button3.Visible=false;button2.Visible=false;button1.Visible=true;}
        }

    }
}
