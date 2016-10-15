/* Name: Naga Rimmalapudi
 * Student #: 200277598
 * Date: Oct 10 2016
 * This is a simple splash form
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_F2016_Assignment2
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashFormTimer_Tick(object sender, EventArgs e)
        {
            SplashFormTimer.Enabled = false;

            autoCentreForm AutoCentreForm = new autoCentreForm();
            AutoCentreForm.Show();
            this.Hide();
        }
    }
}
