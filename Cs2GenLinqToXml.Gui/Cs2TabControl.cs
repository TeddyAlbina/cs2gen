using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Cs2GenLinqToXml.Gui
{
    public partial class Cs2TabControl : System.Windows.Forms.TabControl
    {
        public delegate void TabPageRemovedHandler();
        public delegate void TabPageRemovingHandler(TabPage oTabPage);
        public delegate void TabPageSelectedHandler(Point oPoint,TabPage oTabPage);
        public TabPageRemovedHandler TabPageRemoved;
        public TabPageRemovingHandler TabPageRemoving;
        public TabPageSelectedHandler TabPageSelected;
        public bool isInDragDrop;

        public Cs2TabControl()
        {
            InitializeComponent();
        }

        public Cs2TabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        // Events
        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                base.OnMouseDown(e);

                 // context menu
                if (isOnCurrentTab(e.Location))
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (TabPageSelected != null)
                            TabPageSelected(e.Location, this.SelectedTab);
                    }
                }
                 // drag drop
                Point oPoint = new Point(e.X, e.Y);
                TabPage oTabPage = GetTabPage(oPoint);
                if (oTabPage != null)
                    DoDragDrop(oTabPage, DragDropEffects.All);
            }
            catch
            { }
        }
        private void Cs2TabControl_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                isInDragDrop = true;
                Point oPoint = new Point(e.X, e.Y);
                oPoint = PointToClient(oPoint);

                TabPage oSelectedTabPage = GetTabPage(oPoint);

                if (oSelectedTabPage != null)
                {
                    if (e.Data.GetDataPresent(typeof(TabPage)))
                    {
                        e.Effect = DragDropEffects.Move;
                        TabPage oTabPageToDrag = (TabPage)e.Data.GetData(typeof(TabPage));

                        int nOriginTabPage = FindTabPageIndex(oTabPageToDrag);
                        int nIndexTargetDrop = FindTabPageIndex(oSelectedTabPage);

                        if (nOriginTabPage != nIndexTargetDrop)
                        {
                            List<TabPage> OtherPages = new List<TabPage>();
                            for (int nCount = 0; nCount < this.TabPages.Count; nCount++)
                            {
                                if (nCount != nOriginTabPage)
                                    OtherPages.Add(this.TabPages[nCount]);
                            }
                            OtherPages.Insert(nIndexTargetDrop, oTabPageToDrag);
                            this.TabPages.Clear();

                            this.TabPages.AddRange(OtherPages.ToArray());
                            this.SelectedTab = oTabPageToDrag;
                        }
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
                isInDragDrop = false;
            }
            catch
            { }
        }

        // Methods
        public TabPage CreateTabPage(string TabPageName, string TabPageText, int imageIndex, Control oControl)
        {
            TabPage oTabPage = new TabPage(TabPageText);
            oTabPage.Name = TabPageName;
            oTabPage.ImageIndex = imageIndex;

            oTabPage.Controls.Add(oControl);

            return oTabPage;
        }
        public void AddTabPage(string Text)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Text = Text;
            oTabPage.UseVisualStyleBackColor = true;

            this.TabPages.Add(oTabPage);
            this.SelectedIndex = this.TabPages.Count - 1;
        }
        public void AddTabPage(string Name, string Text)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Name = Name;
            oTabPage.Text = Text;
            oTabPage.UseVisualStyleBackColor = true;

            this.TabPages.Add(oTabPage);
            this.SelectedIndex = this.TabPages.Count - 1;
        }
        public void AddTabPage(string Name, string Text, int ImageIndex)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Name = Name;
            oTabPage.Text = Text;
            oTabPage.ImageIndex = ImageIndex;
            oTabPage.UseVisualStyleBackColor = true;

            this.TabPages.Add(oTabPage);
            this.SelectedIndex = this.TabPages.Count - 1;
        }
        public void AddTabPage(string Name, string Text, int ImageIndex, Control oControl)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Name = Name;
            oTabPage.Text = Text;
            oTabPage.ImageIndex = ImageIndex;
            oTabPage.UseVisualStyleBackColor = true;

            oControl.Dock = DockStyle.Fill;
            oTabPage.Controls.Add(oControl);
            this.TabPages.Add(oTabPage);
            this.SelectedIndex = this.TabPages.Count - 1;
        }
        public void InsertTabPage(TabPage oTabPage)
        {
            if (this.TabPages.Count == 0)
                this.TabPages.Add(oTabPage);
            else
                this.TabPages.Insert(this.SelectedIndex + 1, oTabPage);
            this.SelectedTab = oTabPage;
        }
        public void InsertTabPage(string Text)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Text = Text;
            oTabPage.UseVisualStyleBackColor = true;
            if (this.TabPages.Count == 0)
                this.TabPages.Add(oTabPage);
            else
                this.TabPages.Insert(this.SelectedIndex + 1, oTabPage);
            this.SelectedTab = oTabPage;
        }
        public void InsertTabPage(string Name, string Text)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Name = Name;
            oTabPage.Text = Text;
            oTabPage.UseVisualStyleBackColor = true;

            if (this.TabPages.Count == 0)
                this.TabPages.Add(oTabPage);
            else
                this.TabPages.Insert(this.SelectedIndex + 1, oTabPage);
            this.SelectedTab = oTabPage;
        }
        public void InsertTabPage(string Name, string Text, int ImageIndex)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Name = Name;
            oTabPage.Text = Text;
            oTabPage.ImageIndex = ImageIndex;
            oTabPage.UseVisualStyleBackColor = true;

            if (this.TabPages.Count == 0)
                this.TabPages.Add(oTabPage);
            else
                this.TabPages.Insert(this.SelectedIndex + 1, oTabPage);
            this.SelectedTab = oTabPage;
        }
        public void InsertTabPage(string Name, string Text, int ImageIndex, Control oControl)
        {
            TabPage oTabPage = new TabPage();
            oTabPage.Name = Name;
            oTabPage.Text = Text;
            oTabPage.ImageIndex = ImageIndex;
            oTabPage.UseVisualStyleBackColor = true;

            oControl.Dock = DockStyle.Fill;
            oTabPage.Controls.Add(oControl);
            if (this.TabPages.Count == 0)
                this.TabPages.Add(oTabPage);
            else
                this.TabPages.Insert(this.SelectedIndex + 1, oTabPage);
            this.SelectedTab = oTabPage;
        }

        public void AddControlToTabPage(System.Windows.Forms.DockStyle DockStyle, Control oControl)
        {
            if (this.TabPages.Count > 0)
            {
                int nCurrentTabPage = this.SelectedIndex;
                TabPage oTabPage = this.TabPages[nCurrentTabPage];
                oControl.Dock = DockStyle;
                oTabPage.Controls.Add(oControl);
            }
        }
        public void AddTabPages(TabPage[] oTabPages)
        {
            this.TabPages.AddRange(oTabPages);
            this.SelectedIndex = this.TabPages.Count - 1;
        }
        public void UpdateTabPage(string NewText)
        {
            int nCurrentTabPage = this.SelectedIndex;
            TabPage oTabPage = this.TabPages[nCurrentTabPage];
            oTabPage.Text = NewText;
        }
        public void UpdateTabPage(int NewImageIndex)
        {
            int nCurrentTabPage = this.SelectedIndex;
            TabPage oTabPage = this.TabPages[nCurrentTabPage];
            oTabPage.ImageIndex = NewImageIndex;
        }
        public void SelectTabPage(int nIndex)
        {
            if (this.TabPages.Count > 0 & nIndex <= this.TabPages.Count - 1)
                this.SelectedIndex = nIndex;
        }
        public void RemoveTabPage()
        {
            int nCurrentTabPage = this.SelectedIndex;
            if (TabPageRemoving != null)
                TabPageRemoving(this.TabPages[nCurrentTabPage]);
            this.TabPages.RemoveAt(nCurrentTabPage);
            if (nCurrentTabPage > 0)
                this.SelectedIndex = nCurrentTabPage - 1;
            if (TabPageRemoved != null)
                TabPageRemoved();


        }
        public void RemoveTabPage(TabPage oTabPage)
        {
            if (TabPageRemoving != null)
                TabPageRemoving(oTabPage);
            this.TabPages.Remove(oTabPage);
            if (TabPageRemoved != null)
                TabPageRemoved();
        }
        public void RemoveTabPages(int[] nTabs)
        {
            foreach (int nTab in nTabs)
            {
                if (this.TabPages.Count > 0 & nTab <= this.TabPages.Count - 1)
                {
                    if (TabPageRemoving != null)
                        TabPageRemoving(this.TabPages[nTab]);
                    this.TabPages.RemoveAt(nTab);
                    if (TabPageRemoved != null)
                        TabPageRemoved();
                }
            }
            if (this.TabPages.Count > 0)
                this.SelectedIndex = this.TabPages.Count - 1;
        }
        private bool isOnCurrentTab(Point oPoint)
        {
            bool bResult = false;
            int CurrentTabpage = this.SelectedIndex;
            if (this.GetTabRect(CurrentTabpage).Contains(oPoint))
                bResult = true;

            return bResult;
        }

        private TabPage GetTabPage(Point oPoint)
        {
            TabPage oTabPage = null;
            for (int nCount = 0; nCount <= this.TabPages.Count - 1; nCount++)
            {
                if (this.GetTabRect(nCount).Contains(oPoint))
                {
                    oTabPage = this.TabPages[nCount];
                }
            }
            return oTabPage;
        }


        private int FindTabPageIndex(TabPage oTabPage)
        {
            int nResult = -1;
            for (int nCount = 0; nCount <= this.TabPages.Count - 1; nCount++)
            {
                if (this.TabPages[nCount] == oTabPage)
                    nResult = nCount;
            }

            return nResult;
        }
    }
}
