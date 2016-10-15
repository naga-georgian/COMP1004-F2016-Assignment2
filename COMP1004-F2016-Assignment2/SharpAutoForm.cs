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

        /**
         * This method will activate when the calculate button is clicked, and total up all of the user inputted prices and features. 
         * Once it has totalled everything up, it will output the values into the textboxes for each value.
         */
        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculateFunction();
        }

        private void CalculateFunction()
        {
            // Local variables
            decimal carSalesPriceDecimal;
            decimal tradeInAllowanceDecimal;
            decimal accessoriesExteriorSubTotalDecimal = 0.00m;
            decimal subTotalDecimal;
            decimal totalDecimal;
            decimal salesTaxDecimal;
            decimal amountDueDecimal;
            try
            {
                carSalesPriceDecimal = decimal.Parse(carSalesPriceTextBox.Text);
                // Car sales price cannot be below or equal to 0
                if (carSalesPriceDecimal <= 0)
                {
                    MessageBox.Show("The value inputted in the Car Sale Price must be above zero.", "Value too small Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    carSalesPriceDecimal = 0.00m;
                    carSalesPriceTextBox.Select();
                    carSalesPriceTextBox.Focus();
                }
                else
                {
                    try
                    {
                        tradeInAllowanceDecimal = decimal.Parse(tradeInAllowanceTextBox.Text);
                        // Trade in value cannot be below 0
                        if (tradeInAllowanceDecimal < 0)
                        {
                            MessageBox.Show("The value inputted in Trade-On Allowance must not be a negative value.", "Value too small Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tradeInAllowanceDecimal = 0.00m;
                            tradeInAllowanceTextBox.Select();
                            tradeInAllowanceTextBox.Focus();
                        }
                        else
                        {
                            // Switch to check which radio button has been clicked
                            switch (selectedRadioButton.Name)
                            {
                                case "peralizedRadioButton":
                                    accessoriesExteriorSubTotalDecimal = PERALIZED_Decimal;
                                    break;
                                case "customizedDetailingRadioButton":
                                    accessoriesExteriorSubTotalDecimal = CUSTOMIZED_DETAILING_Decimal;
                                    break;
                                default:
                                    accessoriesExteriorSubTotalDecimal = STANDARD_Decimal;
                                    break;
                            }
                            // If check box is checked, add to subtotal
                            if (stereoSystemCheckBox.Checked)
                            {
                                accessoriesExteriorSubTotalDecimal += STEREO_SYSTEM_Decimal;
                            }
                            if (leatherInteriorCheckBox.Checked)
                            {
                                accessoriesExteriorSubTotalDecimal += LEATHER_INTERIOR_Decimal;
                            }
                            if (computerNavigationCheckBox.Checked)
                            {
                                accessoriesExteriorSubTotalDecimal += COMPUTER_NAVIGATION_Decimal;
                            }
                            // Calculations
                            subTotalDecimal = accessoriesExteriorSubTotalDecimal + carSalesPriceDecimal;
                            salesTaxDecimal = subTotalDecimal * TAX_RATE_Decimal;
                            totalDecimal = subTotalDecimal + salesTaxDecimal;
                            amountDueDecimal = totalDecimal - tradeInAllowanceDecimal;

                            // Add all variables to the TextBoxes
                            accessoriesFinishTextBox.Text = accessoriesExteriorSubTotalDecimal.ToString("c");
                            subtotalTextBox.Text = subTotalDecimal.ToString("c");
                            salesTaxTextBox.Text = salesTaxDecimal.ToString("c");
                            totalTextBox.Text = totalDecimal.ToString("c");
                            amountDueTextBox.Text = amountDueDecimal.ToString("c");


                        }
                    }
                    // Catch Format Exceptions
                    catch (FormatException tradeInAllowanceFormatException)
                    {
                        MessageBox.Show("The value inputted in Trade-In Allowance must be a numeric value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tradeInAllowanceTextBox.Select();
                        tradeInAllowanceTextBox.Focus();
                    }
                    // Catch Overflow Exceptions
                    catch (OverflowException tradeInAllowanceOverflowException)
                    {
                        MessageBox.Show("The value inputted in Trade-In Allowance is out of range.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tradeInAllowanceTextBox.Select();
                        tradeInAllowanceTextBox.Focus();
                    }
                    // Catch any exceptions that weren't caught previously
                    catch (Exception tradeInAllowanceGenericException)
                    {
                        MessageBox.Show("The value in Trade-In Allowance has caused an unknown error. Error: " + tradeInAllowanceGenericException.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tradeInAllowanceTextBox.Select();
                        tradeInAllowanceTextBox.Focus();
                    }
                }
            }
            // Catch Format Exceptions
            catch (FormatException carSalesFormatException)
            {
                MessageBox.Show("The value inputted in the Car Sale Price must be a numeric value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carSalesPriceTextBox.Select();
                carSalesPriceTextBox.Focus();
            }
            // Catch Overflow Exceptions
            catch (OverflowException carSalesOverflowException)
            {
                MessageBox.Show("The value inputted in the Car Sale Price is out of range.", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carSalesPriceTextBox.Select();
                carSalesPriceTextBox.Focus();
            }
            // Catch any exceptions that weren't caught previously
            catch (Exception carSalesGenericException)
            {
                MessageBox.Show("The value in the Car Sale Price has caused an unknown error. Error: " + carSalesGenericException.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                carSalesPriceTextBox.Select();
                carSalesPriceTextBox.Focus();
            }
        }
    }
}
