using System;
using System.Windows.Forms;

namespace comGUI {
    public partial class Browser : Form {
        public Browser() {
            InitializeComponent();
            FormClosing += back;
        }
         void back(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
            if(Program.start.Visible==false) { 
            Program.start.Show();}
            else { 
                 Dispose();
               }
        }

        private void button4_Click(object sender, EventArgs e) {
            webBrowser1.Refresh();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
        }

        private void button1_Click(object sender, EventArgs e) {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e) {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e) {
            webBrowser1.GoHome();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e) {
            textBox1.Text=webBrowser1.Url.ToString();
        }

        private void button5_Click(object sender, EventArgs e) {
            if(textBox1.Text.Contains("http://")||textBox1.Text.Contains("https://")) {webBrowser1.Navigate(textBox1.Text); }
               else {webBrowser1.Navigate("http://"+textBox1.Text); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyData==Keys.Enter) {
               if(textBox1.Text.Contains("http://")||textBox1.Text.Contains("https://")) {webBrowser1.Navigate(textBox1.Text); }
               else {webBrowser1.Navigate("http://"+textBox1.Text); }
                
            }
        }
    }
}
