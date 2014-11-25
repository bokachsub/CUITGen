using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointFinder
{
    public partial class fmScreen : Form
    {
        public fmScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;            

            //to be implemented: if Alt key is down then cleaning txt file 
            //to be implemented: double-clicking and holding a button (to be put in comments)

            StreamWriter file = new StreamWriter("GeneratedCode.txt", true);
            file.WriteLine("//[TestMethod][Timeout(TestTimeout.Infinite)]");
            file.WriteLine("//Playback.PlaybackSettings.ContinueOnError = true;");                        
            file.Close();
        }

        private void fmScreen_DoubleClick(object sender, EventArgs e)
        {
            //MessageBox.Show("x: "+Cursor.Position.X.ToString()+" \n"+ "y: "+Cursor.Position.Y.ToString());
            StreamWriter file = new StreamWriter("GeneratedCode.txt",true);
            file.WriteLine("Mouse.Click(new Point({0}, {1})); Thread.Sleep(sTime);", Cursor.Position.X, Cursor.Position.Y);
            file.WriteLine("if ((Control.ModifierKeys & Keys.Shift) != 0) Thread.Sleep(1500000);");
            file.Close();

        }


    }
}
