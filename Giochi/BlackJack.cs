using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comGUI {
    public partial class BlackJack : Form {
        public BlackJack() {
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
        Random rnd=new Random(Environment.TickCount);
        List<Cards>deck;
        List<int>used=new List<int> {};
        List<int>data=new List<int> {0,0};
        List<PictureBox>boxes=new List<PictureBox> {};
         void BlackJack_Load(object sender, EventArgs e) {
            deck=Deck.FrenchDeck;deck.AddRange(deck);
            boxes=new List<PictureBox> {pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,
                pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10};
        }
         void button1_Click(object sender, EventArgs e) {
            rewrite(0);
            button1.Visible=false;
            button2.Visible=true;
            button3.Visible=true;
            used.Clear();data.Clear();data=new List<int>{0,0};
            deck[0].Value=11;deck[13].Value=11;deck[26].Value=11;deck[39].Value=11;
            for (int a=0;a<10;a++) {int h=rnd.Next(104);if(!used.Contains(h)) {used.Add(h); }else {a--; } }
            boxes[0].Image=deck[used[0]].Image;
            boxes[1].Image=deck[used[1]].Image;
            boxes[2].Image=null;
            boxes[3].Image=null;
            boxes[4].Image=null;
            boxes[5].Image=deck[used[5]].Image;
            boxes[6].Image=Utility.ResizeImage((rnd.Next(2)==1?Properties.Resources.red_back:Properties.Resources.black_back),new Size(75,100));
            boxes[7].Image=null;
            boxes[8].Image=null;
            boxes[9].Image=null;
            sum(true);sum(false);
        }

         void button2_Click(object sender, EventArgs e) {
            switch(data[0]++) {
                case 0:boxes[2].Image=deck[used[2]].Image;break;
                case 1:boxes[3].Image=deck[used[3]].Image;break;
                case 2:boxes[4].Image=deck[used[4]].Image;button2.Visible=false;button3.Visible=false;boxes[6].Image=deck[used[6]].Image;AI();break; }
            if(sum(true)==21) {button1.Visible=false;button2.Visible=false;button3.Visible=false;boxes[6].Image=deck[used[6]].Image;
            AI(); }
            sum(true);sum(false);if(sum(true)>21) {rewrite(2); }
        }
         void rewrite(int x) {
            button2.Visible=false;button3.Visible=false;button1.Visible=true;
            if(x==0) {label1.Text=""; }
            if(x==1) {label1.Text="Hai Vinto!";label1.ForeColor=Color.Green; }
            if(x==2) {label1.Text="Hai Perso!";label1.ForeColor=Color.Red; }
            if(x==3) {label1.Text="Pareggio!";label1.ForeColor=Color.Blue; }
        }
         void button3_Click(object sender, EventArgs e) {
            button1.Visible=false;button2.Visible=false;button3.Visible=false;
            boxes[6].Image=deck[used[6]].Image;
            AI();
            sum(true);sum(false);
        }

         async void AI() {
            int h=sum(true);
            for(int a=0;a<3;a++) {
                if(sum(false)>h) {break; }
                if(sum(false)==h&&data[0]>data[1]) {break; }
                if(sum(false)>=21) {break; }
                await Task.Delay(1000);
                switch (a) {
                case 0:boxes[7].Image=deck[used[7]].Image;break;
                case 1:boxes[8].Image=deck[used[8]].Image;break;
                case 2:boxes[9].Image=deck[used[9]].Image;break; }
                data[1]=a;
            }
            if(sum(false)>21) {rewrite(1);return; }
            if(sum(false)>h) {rewrite(2);return; }
            else if(sum(false)<h) {rewrite(1);return; }
            else if(sum(false)==h) {
                if(data[0]<data[1]) {rewrite(1); }
                else if(data[0]>data[1]) {rewrite(2); }
                else if(data[0]==data[1]) {rewrite(3); }
            }
        }
         void pictureBox_Click(object sender, EventArgs e) {
            int h=boxes.IndexOf(sender as PictureBox);
            
            try { textBox3.Text=deck[used[h]].Image==boxes[h].Image?deck[used[h]].Value.ToString():"??"; }catch(ArgumentOutOfRangeException) { }
            textBox3.Location=new Point(boxes[h].Location.X,h<5?93:229);
            if(textBox3.Location.X==boxes[h].Location.X) {
                if((h<5&&textBox3.Location.Y==93)||(h>4&&textBox3.Location.Y==229)) {textBox3.Visible=!textBox3.Visible; }
            }
            try { textBox3.Visible=deck[used[h]].Image==boxes[h].Image; }catch(ArgumentOutOfRangeException) { }
        }
         int sum(bool isPlayer)
        {
            int s=isPlayer?0:5;
            List<int>num=new List<int>();
            for(int a=0;a<5;a++) {
                if(boxes[a+s].Image==deck[used[a+s]].Image) {num.Add((int)deck[used[a+s]].Value); }
            }
            int fin=0;
            foreach(int o in num) {fin+=o; }
            if(fin>21) {
                for(int a=0;a<5;a++) {if(used[s+a]%13==0&&deck[(int)used[s+a]].Value==11) {deck[used[s+a]].Value=1;fin-=10;if(fin<=21) {break; } } }
            }
            if(isPlayer) {textBox1.Text=fin.ToString(); }
            else{textBox2.Text=fin.ToString(); }
            return fin;
        }
    }
}
