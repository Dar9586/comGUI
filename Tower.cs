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
    public partial class Tower : Form {
        public Tower() {
            InitializeComponent();
        FormClosing += back;
        }
         void back(object sender, EventArgs e) {
            Cursor.Show();
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }
        bool buttonActive=true,onRight=true;
        int score=0;
        Color col;
        Rectangle rect=new Rectangle(0,0,250,25),lastRect=new Rectangle(108,577,250,25);
        Random rnd=new Random(Environment.TickCount);
        Bitmap im1=new Bitmap(465,602),im2=new Bitmap(465,25);
        Graphics img1,img2;
        void restart() {
            lastRect=new Rectangle(108,577,250,25);
            rect=new Rectangle(0,0,250,25);
            pictureBox2.Visible=false;
            buttonActive=true;
            drawButton(false);
            score=0;
            updatePictureBox1();
        }
        void setCol() {
            do {col=Color.FromArgb(rnd.Next(256),rnd.Next(256),rnd.Next(256));
                } while ((col.R+col.G+col.B)/3<100);
            Console.WriteLine(col);
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            Console.WriteLine(pictureBox1.PointToClient(Cursor.Position));
            if (buttonActive&&new Rectangle(10,60,445,60).Contains(pictureBox1.PointToClient(Cursor.Position)) ) {
                img1.Clear(Color.Black);
                setCol();
                img1.FillRectangle(new SolidBrush(col),lastRect);
                setCol();
                pictureBox2.Location=new Point(0,552);
                timer1.Enabled=true;
                pictureBox2.Visible=true;
                buttonActive=false;
                updateScore();
                updatePictureBox1();
            }else if(timer1.Enabled) {

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData){
            if (keyData == Keys.Enter||keyData==Keys.Space){
                if(!buttonActive) {
                    timer1.Stop();
                    if(rect.Left<lastRect.Left)   {rect.Size=new Size(rect.Width-lastRect.Left+rect.Left,25);rect.Location=new Point(lastRect.Left,0); }
                    if(rect.Right>lastRect.Right) {rect.Size=new Size(rect.Width-rect.Right+lastRect.Right,25); }
                    if(rect.Width>0){
                        score++;
                        updateScore();
                        lastRect=new Rectangle(rect.Left,pictureBox2.Location.Y,rect.Width,25);
                        rect = new Rectangle(0,0,lastRect.Width,25);
                        img1.FillRectangle(new SolidBrush(col),lastRect);
                        updatePictureBox1();
                        if(pictureBox2.Location.Y-25>=202) { 
                        pictureBox2.Location=new Point(0,pictureBox2.Location.Y-25);}
                        else {
                            Bitmap s=im1.Clone(new Rectangle(108,202,250,375),im1.PixelFormat);
                            img1.FillRectangle(Brushes.Black,lastRect);
                            img1.DrawImage(s,108,227);
                        }
                        updatePictureBox1();
                        setCol();
                        img2.Clear(Color.Black);
                        Console.WriteLine(pictureBox2.Location);
                        timer1.Start();
                    }else {restart(); } 
                }
                else{
                    
                }
        }
        return base.ProcessCmdKey(ref msg, keyData);
        }

        private void updateScore() {
            img1.FillRectangle(Brushes.Black,0,0,465,100);
            img1.DrawString(score.ToString(),new Font("Arial", 30),new SolidBrush(Color.Cyan),new Point(0,0));
        }

        private void timer1_Tick(object sender, EventArgs e) {
            img2.FillRectangle(new SolidBrush(Color.Black),rect);
            rect.Location=new Point(rect.Left+(onRight?3:-3),rect.Top);
            //Console.WriteLine($"{rect.Left} + {rect.Width} = {rect.Right}");
            if(rect.Left<=0) {onRight=true; }
            else if(rect.Right>=465) {onRight=false; }
            img2.FillRectangle(new SolidBrush(col),rect);
            updatePictureBox2();
        }
        void updatePictureBox1() {pictureBox1.Image=im1; }
        void updatePictureBox2() {pictureBox2.Image=im2; }
        void drawButton(bool isStart) {
            img1.DrawRectangle(new Pen(isStart?Color.Cyan:Color.Red,1),10,60,445,60);
            img1.DrawString(isStart?"Inizia":"Restart",new Font("Microsoft Sans Serif",20F,FontStyle.Regular,GraphicsUnit.Point, 0),new SolidBrush(isStart?Color.Cyan:Color.Red),new Point(180,73));
            updatePictureBox1();
        }
        private void Tower_Load(object sender, EventArgs e) {
            img1=Graphics.FromImage(im1);
            img1.Clear(Color.Black);
            img2=Graphics.FromImage(im2);
            img2.Clear(Color.Black);
            drawButton(true);
        }
    }
}
