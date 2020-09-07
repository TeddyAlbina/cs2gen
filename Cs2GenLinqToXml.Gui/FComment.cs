using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class FComment : Form
    {
        public FComment()
        {
            InitializeComponent();
        }

        public string Comment;
        public bool bValidate;
        private void FComment_Load(object sender, EventArgs e)
        {
            txtComment.Text = Comment;
        }
        private void txtComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateComment();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ValidateComment();
        }

        private void ValidateComment()
        {
            Comment = txtComment.Text;
            bValidate = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bValidate = false;
            this.Close();
        }
       
    }
}