using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Cs2GenLinqToXml.Gui
{
    public partial class FOptions : Form
    {
        public FOptions()
        {
            InitializeComponent();
        }
        public bool Reload = false;

        private void FOptions_Load(object sender, EventArgs e)
        {
            try
            {
                chkCompleteNamespaces.Checked = Options.IncludeLinqCompletePathNamespace;
                chkIncludeXComment.Checked = Options.IncludeXComment;
                chkParseXml.Checked = Options.ParseXml;
                txtCsNamespace.Text = Options.NamespaceForCSharpFiles;
                panel1.BackColor = Options.ErrorColor;
                this.labelProductName.Text = AssemblyProduct;
                this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
                this.labelCopyright.Text = AssemblyCopyright;
                this.textBoxDescription.Text = AssemblyDescription;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Caution .. ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
 
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.IncludeLinqCompletePathNamespace = chkCompleteNamespaces.Checked;
                Properties.Settings.Default.IncludeXComment = chkIncludeXComment.Checked;
                Properties.Settings.Default.ParseXml = chkParseXml.Checked;
                if (!string.IsNullOrEmpty(txtCsNamespace.Text))
                    Properties.Settings.Default.NamespaceForCSharpFiles = txtCsNamespace.Text;
                Properties.Settings.Default.ErrorColor = panel1.BackColor;
                Properties.Settings.Default.Save();
                Reload = true;
                lblResult.Text = "settings saved .";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Caution .. ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        #region Accesseurs d'attribut de l'assembly


        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                    return string.Empty;
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                    return string.Empty;
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                    return string.Empty;
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion

        private void btnErrorColorEditor_Click(object sender, EventArgs e)
        {
            ColorDialog oColorDialog = new ColorDialog();
            oColorDialog.Color = panel1.BackColor;
            if (oColorDialog.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = oColorDialog.Color;
            }
        }

        private void btnReinit_Click(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }
    }
}