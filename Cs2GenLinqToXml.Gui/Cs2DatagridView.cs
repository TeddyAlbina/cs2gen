using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class Cs2DatagridView : System.Windows.Forms.DataGridView
    {
        public Cs2DatagridView()
        {
            InitializeComponent();
        }

        public Cs2DatagridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public Cs2DatagridView(string DatagridViewName, bool AllowUserToAddRows, bool AllowUserToDeleteRows, bool ReadOnly, System.Windows.Forms.DataGridViewAutoSizeColumnsMode SizeColumnMode)
        {
            InitializeComponent();

            this.Name = DatagridViewName;
            this.AllowUserToAddRows = AllowUserToAddRows;
            this.AllowUserToDeleteRows = AllowUserToDeleteRows;
            this.ReadOnly = ReadOnly;
            this.AutoSizeColumnsMode = SizeColumnMode;
            this.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Dock = DockStyle.Fill;
        }
        public void SetProperties(string DatagridViewName, bool AllowUserToAddRows, bool AllowUserToDeleteRows, bool ReadOnly, System.Windows.Forms.DataGridViewAutoSizeColumnsMode SizeColumnMode)
        {
            this.Name = DatagridViewName;
            this.AllowUserToAddRows = AllowUserToAddRows;
            this.AllowUserToDeleteRows = AllowUserToDeleteRows;
            this.ReadOnly = ReadOnly;
            this.AutoSizeColumnsMode = SizeColumnMode;
            this.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Dock = DockStyle.Fill;
        }

    }
}
