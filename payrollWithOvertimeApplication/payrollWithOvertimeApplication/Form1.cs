using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payrollWithOvertimeApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //named constants
                const decimal BASE_HOURS = 40m;
                const decimal OT_MULTIPLIER = 1.5m;

                //local variables
                decimal hoursWorked;
                decimal hourlyPayRate;
                decimal basePay;
                decimal overtimeHours;
                decimal overtimePay;
                decimal grossPay;

                //get the hours worked and the hourly pay rate.
                hoursWorked = decimal.Parse(hoursWorkedBox.Text);
                hourlyPayRate = decimal.Parse(hourlyPayRateBox.Text);

                //determine the gross pay.
                if (hoursWorked > BASE_HOURS)
                {
                    //CALCULATE THE BASE PAY (without overtime).
                    basePay = hourlyPayRate * BASE_HOURS;
                    //calculate the NUMBER OF HOURS worked overtime.
                    overtimeHours = hoursWorked - BASE_HOURS;
                    //calculate the overtime pay.
                    overtimePay = overtimeHours * hourlyPayRate * OT_MULTIPLIER;
                    //CALCULATE the gross pay.
                    grossPay = basePay + overtimePay;
                }
                    else
                    {
                        //calculate the gross pay.
                        grossPay = hoursWorked * hourlyPayRate;
                    }
                    //display the gross pay.
                    grossPayLabel.Text = grossPay.ToString("c");
                }
            
            catch(Exception ex)
            {
                //display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //clear the TextBoxes and gross pay label.
            hoursWorkedBox.Text = "";
            hourlyPayRateBox.Text = "";
            grossPayLabel.Text = "";

            //Reset the focus.
            hoursWorkedBox.Focus();
        }
    }
}
