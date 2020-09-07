using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class FElement : Form
    {
        public FElement()
        {
            InitializeComponent();
        }

        public bool bValidate=false;
        public string ElementName;
        public string ElementValue;
        public bool CanGetValue=true;

        private void FElement_Load(object sender, EventArgs e)
        {
            txtName.Text = ElementName;
            if (CanGetValue)
            {
                txtValue.Text = ElementValue;
                txtValue.Enabled = true;
            }
            else
                txtValue.Enabled = false;
        }
        public void GiveElement(string ElementName,string ElementValue, bool CanGetValue)
        {
            this.ElementName = ElementName;
            this.ElementValue = ElementValue;
            this.CanGetValue = CanGetValue;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidateElement();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateElement();
            }
        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateElement();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bValidate = false;
            this.Close();
        }
        private void ValidateElement()
        {
            if (verifyBeforeValidate())
            {
                ElementName = txtName.Text;
                ElementValue = txtValue.Text;
                bValidate = true;
                this.Close();
            }
        }
        public bool verifyBeforeValidate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "name required");
                result = false;
            }
            if (txtName.Text.IndexOf(" ") != -1)
            {
                errorProvider1.SetError(txtName, "no spaces in name");
                result = false;
            }

            return result;
        }
    }
}