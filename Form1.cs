using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Conversion_App
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            tbxInput.Text = "1";
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Declare variables
            float iConvertFrom = 1;
            float iConvertTo = 1;
            string sCurrencyFrom = "EUR";
            string sCurrencyTo = "ZAR";
            string sUpdatedTagFrom = "";
            string sUpdatedTagTo = "";
            int iAmount = 1;

            //Validate required Input
            if (tbxInput.Text == "" || cbxFrom.SelectedIndex < -1 || cbxTo.SelectedIndex < -1)
            {
                MessageBox.Show("Please select a currency to convert from, convert to or type in a amount in the textbox.");
                return;
            }

            double dInput;
            bool isDouble = Double.TryParse(tbxInput.Text, out dInput);
            if (!isDouble)
            {
                MessageBox.Show("Please insert a numeric value.");
                return;
            }

            iConvertFrom = (float)Convert.ToDouble(tbxInput.Text);
            sCurrencyFrom = cbxFrom.Text;
            sCurrencyTo = cbxTo.Text;

            // Convert to tag that will be used by api
            clsCurrencyTag convertTagFrom = new clsCurrencyTag(sCurrencyFrom);
            sUpdatedTagFrom = convertTagFrom.GetCurrencyTag();
            clsCurrencyTag convertTagTo = new clsCurrencyTag(sCurrencyTo);
            sUpdatedTagTo = convertTagTo.GetCurrencyTag();

            float exchangeRate = clsCurrencyConverter.GetExchangeRate(sUpdatedTagFrom, sUpdatedTagTo, iAmount);

            // Calculate exchange rate
            //exchangeRate = (float)Math.Round(exchangeRate, 2);           
            iConvertTo = iConvertFrom * exchangeRate;
            iConvertTo = (float)Math.Round(iConvertTo, 2);

            //Provide converted exchange rate as output
            tbxOutput.Text = Convert.ToString(iConvertTo);
        }
    }
}
