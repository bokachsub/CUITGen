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
        int dragStartedAtX = 0;
        int dragStartedAtY = 0;

        public fmScreen()
        {            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;            
            
            StreamWriter file = new StreamWriter("GeneratedCode.txt",false);            
            file.WriteLine("//[TestMethod][Timeout(TestTimeout.Infinite)]");
            file.WriteLine("//Playback.PlaybackSettings.ContinueOnError = true;");
            file.WriteLine("int oneSecond = 1000, twoSeconds = 2000, threeSeconds = 3000, fiveSeconds = 5000, sevenSeconds = 7000, tenSeconds = 10000, twoMinutes = 120000;");
            file.WriteLine("int sleepTimeBetweenActions = oneSecond;");
            file.WriteLine("int stopRequested = twoMinutes;");
            file.WriteLine("System.Threading.Thread.Sleep(sevenSeconds);"); 
            file.Close();
        }

        private void fmScreen_DoubleClick(object sender, EventArgs e)
        {
            // dbl_click will record a CLICK
            // ALT + dbl_click will record COMMENTED CLICK 

            // SHIFT + dbl_click will record STARTDRAGGING
            // CTRL + dbl_click will record STOPDRAGGING            

            //Take screenshot - needs implementation

            StreamWriter file = new StreamWriter("GeneratedCode.txt", true);            

            if (ModifierKeys.HasFlag(Keys.Shift))
            {
                file.WriteLine(); 
                file.WriteLine("Mouse.StartDragging(null, new Point({0}, {1}));", Cursor.Position.X, Cursor.Position.Y);
                dragStartedAtX = Cursor.Position.X;
                dragStartedAtY = Cursor.Position.Y; 
            }
            else if (ModifierKeys.HasFlag(Keys.Control))
            {
                int distanceX = Cursor.Position.X - dragStartedAtX;
                int distanceY = Cursor.Position.Y - dragStartedAtY;                
                file.WriteLine("Mouse.StopDragging(null, {0}, {1}); System.Threading.Thread.Sleep(sleepTimeBetweenActions);", distanceX, distanceY);
                file.WriteLine("if ((System.Windows.Forms.Control.ModifierKeys & System.Windows.Forms.Keys.Shift) != 0) System.Threading.Thread.Sleep(stopRequested);");
                file.WriteLine();
            }
            else if (ModifierKeys.HasFlag(Keys.Alt))
            {
                file.WriteLine("//Mouse.Click(new Point({0}, {1})); System.Threading.Thread.Sleep(sleepTimeBetweenActions);", Cursor.Position.X, Cursor.Position.Y);                
            }
            else 
            {
                file.WriteLine(); 
                file.WriteLine("Mouse.Click(new Point({0}, {1})); System.Threading.Thread.Sleep(sleepTimeBetweenActions);", Cursor.Position.X, Cursor.Position.Y);
                file.WriteLine("if ((System.Windows.Forms.Control.ModifierKeys & System.Windows.Forms.Keys.Shift) != 0) System.Threading.Thread.Sleep(stopRequested);");
                file.WriteLine(); 
            }
            
            //MessageBox.Show("x: "+Cursor.Position.X.ToString()+" \n"+ "y: "+Cursor.Position.Y.ToString());            
                        
            file.Close();
        }

        private void fmScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "GeneratedCode.txt");
        }


    }
}
