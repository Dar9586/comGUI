using System;
using System.Windows.Forms;

namespace comGUI {
    
    static class Program {

        public static Menu start=new Menu();
        /// <summary>
        /// Main application access point.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
          //  Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(start);
        }
    }
}
