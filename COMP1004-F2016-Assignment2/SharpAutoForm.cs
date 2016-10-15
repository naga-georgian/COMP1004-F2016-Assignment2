/* Name: Naga Rimmalapudi
 * Student #: 200277598
 * Date: Oct 10 2016
 * This application shows us the details about the new or used car
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMP1004_F2016_Assignment2.Properties;

namespace COMP1004_F2016_Assignment2
{
    public partial class autoCentreForm : Form
    {

        // Constant Variables
        const decimal TAX_RATE_Decimal = .13m;
        // Accessories
        const decimal STEREO_SYSTEM_Decimal = 425.76m;
        const decimal LEATHER_INTERIOR_Decimal = 987.41m;
        const decimal COMPUTER_NAVIGATION_Decimal = 1741.23m;
        // Exterior Finish
        const decimal STANDARD_Decimal = 0.00m;
        const decimal PERALIZED_Decimal = 345.72m;
        const decimal CUSTOMIZED_DETAILING_Decimal = 599.99m;

        private RadioButton selectedRadioButton = null;
        public autoCentreForm()
        {
            InitializeComponent();

        }

        /**
       * This method will load the initial values into each textbox.
       */
        private void autoCentreForm_Load(object sender, EventArgs e)
        {
            // These are the defaults, that the form will begin with when it is initialized
            standardRadioButton.Checked = true;
            tradeInAllowanceTextBox.Text = "0.00";
            carSalesPriceTextBox.Select();
            carSalesPriceTextBox.Focus();
        }
    }
}
