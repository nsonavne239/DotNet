using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceCustomer;
using FactoryCustomer;

namespace WinFormCustomer
{
    public partial class frmCustomer : Form
    {
        private ICustomer cust = null;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void SetCustomer()
        {
            cust.CustomerName = txtCustomerName.Text;
            cust.PhoneNumber = textNumber.Text;
            cust.BillDate = Convert.ToDateTime(textBillDate.Text);
            cust.BillAmount = Convert.ToDecimal(textBillAmount.Text);
            cust.Address = textAddress.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                cust.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cust = Factory.Create(comboBox1.Text);
        }
    }
}
