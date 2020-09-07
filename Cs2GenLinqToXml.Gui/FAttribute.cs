using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class FAttribute : Form
    {
        public FAttribute()
        {
            InitializeComponent();
        }
        public bool bValidate;
        public string AttributeName;
        public string AttributeValue;

        private void FAttribut_Load(object sender, EventArgs e)
        {
            txtName.Text = AttributeName;
            txtValue.Text = AttributeValue;
        }       

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateAttribute();
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateAttribute();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidateAttribute();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bValidate = false;
            this.Close();
        }
        private void ValidateAttribute()
        {
            if (verifyBeforeValidate())
            {
                AttributeName = txtName.Text;
                AttributeValue = txtValue.Text;
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