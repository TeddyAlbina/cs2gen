namespace Cs2GenLinqToXml.Gui
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Cs2GenLinqToXml.Gui.XPathUtilities xPathUtilities1 = new Cs2GenLinqToXml.Gui.XPathUtilities();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cs2TabControl1 = new Cs2GenLinqToXml.Gui.Cs2TabControl(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cs2XmlTreeView1 = new Cs2GenLinqToXml.Gui.Cs2XmlTreeView(this.components);
            this.TreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractFromTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeclarationOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommentOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertBeforeCommentOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertAfterCommentOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.updateCommentOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.removeCommentOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElementOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertBeforeElementOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertAfterElementOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.updateElementOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.removeElementOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAttributeOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertBeforeAttributeOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertAfterAttributeOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.updateAttributeOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.removeAttributeOfTreeToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.cutOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.generateClassAndVarOfTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDataAccessWithVarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withCreateMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.postDataInDatagridviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cs2XmlEditor1 = new Cs2GenLinqToXml.Gui.Cs2XmlEditor(this.components);
            this.XmlEditorcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cs2DatagridView1 = new Cs2GenLinqToXml.Gui.Cs2DatagridView(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.propertyInfo = new System.Windows.Forms.PropertyGrid();
            this.cs2LinqToXmlEditor1 = new Cs2GenLinqToXml.Gui.Cs2LinqToXmlEditor(this.components);
            this.LinqToXmlEditorcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAndCopyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLineColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSelectAndCopy = new System.Windows.Forms.ToolStripButton();
            this.tsQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsGenerateClasses = new System.Windows.Forms.ToolStripSplitButton();
            this.xPathVisualizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.businessObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessDataAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSaveAs = new System.Windows.Forms.ToolStripSplitButton();
            this.saveXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.saveLinqToXmlGeneratedAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControlcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cs2TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TreeViewContextMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.XmlEditorcontextMenuStrip.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cs2DatagridView1)).BeginInit();
            this.LinqToXmlEditorcontextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.TabControlcontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cs2LinqToXmlEditor1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 519);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cs2TabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyInfo);
            this.splitContainer2.Size = new System.Drawing.Size(792, 261);
            this.splitContainer2.SplitterDistance = 585;
            this.splitContainer2.TabIndex = 0;
            // 
            // cs2TabControl1
            // 
            this.cs2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.cs2TabControl1.AllowDrop = true;
            this.cs2TabControl1.Controls.Add(this.tabPage1);
            this.cs2TabControl1.Controls.Add(this.tabPage2);
            this.cs2TabControl1.Controls.Add(this.tabPage3);
            this.cs2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cs2TabControl1.ImageList = this.imageList1;
            this.cs2TabControl1.Location = new System.Drawing.Point(0, 0);
            this.cs2TabControl1.Name = "cs2TabControl1";
            this.cs2TabControl1.SelectedIndex = 0;
            this.cs2TabControl1.Size = new System.Drawing.Size(585, 261);
            this.cs2TabControl1.TabIndex = 1;
            this.cs2TabControl1.SelectedIndexChanged += new System.EventHandler(this.cs2TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cs2XmlTreeView1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cs2XmlTreeView1
            // 
            this.cs2XmlTreeView1.ContextMenuStrip = this.TreeViewContextMenu;
            this.cs2XmlTreeView1.CurrentXPath = null;
            this.cs2XmlTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cs2XmlTreeView1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cs2XmlTreeView1.ImageIndex = 0;
            this.cs2XmlTreeView1.LineColor = System.Drawing.Color.Silver;
            this.cs2XmlTreeView1.Location = new System.Drawing.Point(3, 3);
            this.cs2XmlTreeView1.MemoryFullPath = null;
            this.cs2XmlTreeView1.Name = "cs2XmlTreeView1";
            this.cs2XmlTreeView1.SelectedImageIndex = 0;
            this.cs2XmlTreeView1.ShowNodeToolTips = true;
            this.cs2XmlTreeView1.Size = new System.Drawing.Size(571, 228);
            this.cs2XmlTreeView1.TabIndex = 0;
            this.cs2XmlTreeView1.Updated = false;
            this.cs2XmlTreeView1.XPathUtilities = xPathUtilities1;
            this.cs2XmlTreeView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cs2XmlTreeView1_KeyPress);
            this.cs2XmlTreeView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cs2XmlTreeView1_KeyUp);
            // 
            // TreeViewContextMenu
            // 
            this.TreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractFromTreeToolStripMenuItem,
            this.toolStripSeparator7,
            this.documentToolStripMenuItem,
            this.commentToolStripMenuItem,
            this.elementToolStripMenuItem,
            this.attributeToolStripMenuItem,
            this.toolStripSeparator14,
            this.cutOfTreeToolStripMenuItem,
            this.copyOfTreeToolStripMenuItem,
            this.pasteOfTreeToolStripMenuItem,
            this.removeOfTreeToolStripMenuItem,
            this.toolStripSeparator16,
            this.generateClassAndVarOfTreeToolStripMenuItem,
            this.generateDataAccessWithVarsToolStripMenuItem,
            this.toolStripSeparator20,
            this.postDataInDatagridviewToolStripMenuItem});
            this.TreeViewContextMenu.Name = "TreeViewContextMenu";
            this.TreeViewContextMenu.Size = new System.Drawing.Size(208, 292);
            this.TreeViewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TreeViewContextMenu_Opening);
            // 
            // extractFromTreeToolStripMenuItem
            // 
            this.extractFromTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("extractFromTreeToolStripMenuItem.Image")));
            this.extractFromTreeToolStripMenuItem.Name = "extractFromTreeToolStripMenuItem";
            this.extractFromTreeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.extractFromTreeToolStripMenuItem.Text = "Extract ..";
            this.extractFromTreeToolStripMenuItem.Click += new System.EventHandler(this.extractFromTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(204, 6);
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeclarationOfTreeToolStripMenuItem});
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.documentToolStripMenuItem.Text = "Document";
            // 
            // addDeclarationOfTreeToolStripMenuItem
            // 
            this.addDeclarationOfTreeToolStripMenuItem.Name = "addDeclarationOfTreeToolStripMenuItem";
            this.addDeclarationOfTreeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.addDeclarationOfTreeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addDeclarationOfTreeToolStripMenuItem.Text = "Add";
            this.addDeclarationOfTreeToolStripMenuItem.Click += new System.EventHandler(this.addDeclarationOfTreeToolStripMenuItem_Click);
            // 
            // commentToolStripMenuItem
            // 
            this.commentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCommentOfTreeToolstripMenuItem,
            this.insertBeforeCommentOfTreeToolstripMenuItem,
            this.insertAfterCommentOfTreeToolstripMenuItem,
            this.toolStripSeparator12,
            this.updateCommentOfTreeToolstripMenuItem,
            this.toolStripSeparator13,
            this.removeCommentOfTreeToolstripMenuItem});
            this.commentToolStripMenuItem.Name = "commentToolStripMenuItem";
            this.commentToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.commentToolStripMenuItem.Text = "Comment";
            // 
            // addCommentOfTreeToolstripMenuItem
            // 
            this.addCommentOfTreeToolstripMenuItem.Name = "addCommentOfTreeToolstripMenuItem";
            this.addCommentOfTreeToolstripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.addCommentOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addCommentOfTreeToolstripMenuItem.Text = "Add";
            this.addCommentOfTreeToolstripMenuItem.Click += new System.EventHandler(this.addCommentOfTreeToolstripMenuItem_Click);
            // 
            // insertBeforeCommentOfTreeToolstripMenuItem
            // 
            this.insertBeforeCommentOfTreeToolstripMenuItem.Name = "insertBeforeCommentOfTreeToolstripMenuItem";
            this.insertBeforeCommentOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertBeforeCommentOfTreeToolstripMenuItem.Text = "Insert before";
            this.insertBeforeCommentOfTreeToolstripMenuItem.Click += new System.EventHandler(this.insertBeforeCommentOfTreeToolstripMenuItem_Click);
            // 
            // insertAfterCommentOfTreeToolstripMenuItem
            // 
            this.insertAfterCommentOfTreeToolstripMenuItem.Name = "insertAfterCommentOfTreeToolstripMenuItem";
            this.insertAfterCommentOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertAfterCommentOfTreeToolstripMenuItem.Text = "Insert after";
            this.insertAfterCommentOfTreeToolstripMenuItem.Click += new System.EventHandler(this.insertAfterCommentOfTreeToolstripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(146, 6);
            // 
            // updateCommentOfTreeToolstripMenuItem
            // 
            this.updateCommentOfTreeToolstripMenuItem.Name = "updateCommentOfTreeToolstripMenuItem";
            this.updateCommentOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.updateCommentOfTreeToolstripMenuItem.Text = "Update";
            this.updateCommentOfTreeToolstripMenuItem.Click += new System.EventHandler(this.updateCommentOfTreeToolstripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(146, 6);
            // 
            // removeCommentOfTreeToolstripMenuItem
            // 
            this.removeCommentOfTreeToolstripMenuItem.Name = "removeCommentOfTreeToolstripMenuItem";
            this.removeCommentOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeCommentOfTreeToolstripMenuItem.Text = "Remove";
            this.removeCommentOfTreeToolstripMenuItem.Click += new System.EventHandler(this.removeCommentOfTreeToolstripMenuItem_Click);
            // 
            // elementToolStripMenuItem
            // 
            this.elementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addElementOfTreeToolStripMenuItem,
            this.insertBeforeElementOfTreeToolStripMenuItem,
            this.insertAfterElementOfTreeToolStripMenuItem,
            this.toolStripSeparator8,
            this.updateElementOfTreeToolStripMenuItem,
            this.toolStripSeparator9,
            this.removeElementOfTreeToolStripMenuItem});
            this.elementToolStripMenuItem.Name = "elementToolStripMenuItem";
            this.elementToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.elementToolStripMenuItem.Text = "Element";
            // 
            // addElementOfTreeToolStripMenuItem
            // 
            this.addElementOfTreeToolStripMenuItem.Name = "addElementOfTreeToolStripMenuItem";
            this.addElementOfTreeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.addElementOfTreeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addElementOfTreeToolStripMenuItem.Text = "Add";
            this.addElementOfTreeToolStripMenuItem.Click += new System.EventHandler(this.addElementOfTreeToolStripMenuItem_Click);
            // 
            // insertBeforeElementOfTreeToolStripMenuItem
            // 
            this.insertBeforeElementOfTreeToolStripMenuItem.Name = "insertBeforeElementOfTreeToolStripMenuItem";
            this.insertBeforeElementOfTreeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertBeforeElementOfTreeToolStripMenuItem.Text = "Insert before";
            this.insertBeforeElementOfTreeToolStripMenuItem.Click += new System.EventHandler(this.insertBeforeElementOfTreeToolStripMenuItem_Click);
            // 
            // insertAfterElementOfTreeToolStripMenuItem
            // 
            this.insertAfterElementOfTreeToolStripMenuItem.Name = "insertAfterElementOfTreeToolStripMenuItem";
            this.insertAfterElementOfTreeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertAfterElementOfTreeToolStripMenuItem.Text = "Insert after";
            this.insertAfterElementOfTreeToolStripMenuItem.Click += new System.EventHandler(this.insertAfterElementOfTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(146, 6);
            // 
            // updateElementOfTreeToolStripMenuItem
            // 
            this.updateElementOfTreeToolStripMenuItem.Name = "updateElementOfTreeToolStripMenuItem";
            this.updateElementOfTreeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.updateElementOfTreeToolStripMenuItem.Text = "Update";
            this.updateElementOfTreeToolStripMenuItem.Click += new System.EventHandler(this.updateElementOfTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(146, 6);
            // 
            // removeElementOfTreeToolStripMenuItem
            // 
            this.removeElementOfTreeToolStripMenuItem.Name = "removeElementOfTreeToolStripMenuItem";
            this.removeElementOfTreeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeElementOfTreeToolStripMenuItem.Text = "Remove";
            this.removeElementOfTreeToolStripMenuItem.Click += new System.EventHandler(this.removeElementOfTreeToolStripMenuItem_Click);
            // 
            // attributeToolStripMenuItem
            // 
            this.attributeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAttributeOfTreeToolstripMenuItem,
            this.insertBeforeAttributeOfTreeToolstripMenuItem,
            this.insertAfterAttributeOfTreeToolstripMenuItem,
            this.toolStripSeparator10,
            this.updateAttributeOfTreeToolstripMenuItem,
            this.toolStripSeparator11,
            this.removeAttributeOfTreeToolstripMenuItem});
            this.attributeToolStripMenuItem.Name = "attributeToolStripMenuItem";
            this.attributeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.attributeToolStripMenuItem.Text = "Attribute";
            // 
            // AddAttributeOfTreeToolstripMenuItem
            // 
            this.AddAttributeOfTreeToolstripMenuItem.Name = "AddAttributeOfTreeToolstripMenuItem";
            this.AddAttributeOfTreeToolstripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddAttributeOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.AddAttributeOfTreeToolstripMenuItem.Text = "Add";
            this.AddAttributeOfTreeToolstripMenuItem.Click += new System.EventHandler(this.AddAttributeOfTreeToolstripMenuItem_Click);
            // 
            // insertBeforeAttributeOfTreeToolstripMenuItem
            // 
            this.insertBeforeAttributeOfTreeToolstripMenuItem.Name = "insertBeforeAttributeOfTreeToolstripMenuItem";
            this.insertBeforeAttributeOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertBeforeAttributeOfTreeToolstripMenuItem.Text = "Insert before";
            this.insertBeforeAttributeOfTreeToolstripMenuItem.Click += new System.EventHandler(this.insertBeforeAttributeOfTreeToolstripMenuItem_Click);
            // 
            // insertAfterAttributeOfTreeToolstripMenuItem
            // 
            this.insertAfterAttributeOfTreeToolstripMenuItem.Name = "insertAfterAttributeOfTreeToolstripMenuItem";
            this.insertAfterAttributeOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.insertAfterAttributeOfTreeToolstripMenuItem.Text = "Insert after";
            this.insertAfterAttributeOfTreeToolstripMenuItem.Click += new System.EventHandler(this.insertAfterAttributeOfTreeToolstripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(146, 6);
            // 
            // updateAttributeOfTreeToolstripMenuItem
            // 
            this.updateAttributeOfTreeToolstripMenuItem.Name = "updateAttributeOfTreeToolstripMenuItem";
            this.updateAttributeOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.updateAttributeOfTreeToolstripMenuItem.Text = "Update";
            this.updateAttributeOfTreeToolstripMenuItem.Click += new System.EventHandler(this.updateAttributeOfTreeToolstripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(146, 6);
            // 
            // removeAttributeOfTreeToolstripMenuItem
            // 
            this.removeAttributeOfTreeToolstripMenuItem.Name = "removeAttributeOfTreeToolstripMenuItem";
            this.removeAttributeOfTreeToolstripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeAttributeOfTreeToolstripMenuItem.Text = "Remove";
            this.removeAttributeOfTreeToolstripMenuItem.Click += new System.EventHandler(this.removeAttributeOfTreeToolstripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(204, 6);
            // 
            // cutOfTreeToolStripMenuItem
            // 
            this.cutOfTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutOfTreeToolStripMenuItem.Image")));
            this.cutOfTreeToolStripMenuItem.Name = "cutOfTreeToolStripMenuItem";
            this.cutOfTreeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.cutOfTreeToolStripMenuItem.Text = "Cut";
            this.cutOfTreeToolStripMenuItem.Click += new System.EventHandler(this.cutOfTreeToolStripMenuItem_Click);
            // 
            // copyOfTreeToolStripMenuItem
            // 
            this.copyOfTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyOfTreeToolStripMenuItem.Image")));
            this.copyOfTreeToolStripMenuItem.Name = "copyOfTreeToolStripMenuItem";
            this.copyOfTreeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.copyOfTreeToolStripMenuItem.Text = "Copy";
            this.copyOfTreeToolStripMenuItem.Click += new System.EventHandler(this.copyOfTreeToolStripMenuItem_Click);
            // 
            // pasteOfTreeToolStripMenuItem
            // 
            this.pasteOfTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteOfTreeToolStripMenuItem.Image")));
            this.pasteOfTreeToolStripMenuItem.Name = "pasteOfTreeToolStripMenuItem";
            this.pasteOfTreeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pasteOfTreeToolStripMenuItem.Text = "Paste";
            this.pasteOfTreeToolStripMenuItem.Click += new System.EventHandler(this.pasteOfTreeToolStripMenuItem_Click);
            // 
            // removeOfTreeToolStripMenuItem
            // 
            this.removeOfTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeOfTreeToolStripMenuItem.Image")));
            this.removeOfTreeToolStripMenuItem.Name = "removeOfTreeToolStripMenuItem";
            this.removeOfTreeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.removeOfTreeToolStripMenuItem.Text = "Remove";
            this.removeOfTreeToolStripMenuItem.Click += new System.EventHandler(this.removeOfTreeToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(204, 6);
            // 
            // generateClassAndVarOfTreeToolStripMenuItem
            // 
            this.generateClassAndVarOfTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generateClassAndVarOfTreeToolStripMenuItem.Image")));
            this.generateClassAndVarOfTreeToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.generateClassAndVarOfTreeToolStripMenuItem.Name = "generateClassAndVarOfTreeToolStripMenuItem";
            this.generateClassAndVarOfTreeToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.generateClassAndVarOfTreeToolStripMenuItem.Text = "Generate classes ..";
            this.generateClassAndVarOfTreeToolStripMenuItem.Click += new System.EventHandler(this.generateClassAndVarOfTreeToolStripMenuItem_Click);
            // 
            // generateDataAccessWithVarsToolStripMenuItem
            // 
            this.generateDataAccessWithVarsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withObjectToolStripMenuItem,
            this.withCreateMethodToolStripMenuItem});
            this.generateDataAccessWithVarsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generateDataAccessWithVarsToolStripMenuItem.Image")));
            this.generateDataAccessWithVarsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.generateDataAccessWithVarsToolStripMenuItem.Name = "generateDataAccessWithVarsToolStripMenuItem";
            this.generateDataAccessWithVarsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.generateDataAccessWithVarsToolStripMenuItem.Text = "Generate data access";
            // 
            // withObjectToolStripMenuItem
            // 
            this.withObjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("withObjectToolStripMenuItem.Image")));
            this.withObjectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.withObjectToolStripMenuItem.Name = "withObjectToolStripMenuItem";
            this.withObjectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.withObjectToolStripMenuItem.Text = "with object";
            this.withObjectToolStripMenuItem.Click += new System.EventHandler(this.withObjectToolStripMenuItem_Click);
            // 
            // withCreateMethodToolStripMenuItem
            // 
            this.withCreateMethodToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("withCreateMethodToolStripMenuItem.Image")));
            this.withCreateMethodToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.withCreateMethodToolStripMenuItem.Name = "withCreateMethodToolStripMenuItem";
            this.withCreateMethodToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.withCreateMethodToolStripMenuItem.Text = "with create method";
            this.withCreateMethodToolStripMenuItem.Click += new System.EventHandler(this.withCreateMethodToolStripMenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(204, 6);
            // 
            // postDataInDatagridviewToolStripMenuItem
            // 
            this.postDataInDatagridviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("postDataInDatagridviewToolStripMenuItem.Image")));
            this.postDataInDatagridviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.postDataInDatagridviewToolStripMenuItem.Name = "postDataInDatagridviewToolStripMenuItem";
            this.postDataInDatagridviewToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.postDataInDatagridviewToolStripMenuItem.Text = "Post data in datagridview";
            this.postDataInDatagridviewToolStripMenuItem.Click += new System.EventHandler(this.postDataInDatagridviewToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cs2XmlEditor1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Text ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cs2XmlEditor1
            // 
            this.cs2XmlEditor1.AcceptsTab = true;
            this.cs2XmlEditor1.AutoWordSelection = true;
            this.cs2XmlEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cs2XmlEditor1.Column = 0;
            this.cs2XmlEditor1.ContextMenuStrip = this.XmlEditorcontextMenuStrip;
            this.cs2XmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cs2XmlEditor1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cs2XmlEditor1.IsXmlWellFormed = false;
            this.cs2XmlEditor1.Line = 0;
            this.cs2XmlEditor1.Location = new System.Drawing.Point(3, 3);
            this.cs2XmlEditor1.Name = "cs2XmlEditor1";
            this.cs2XmlEditor1.Size = new System.Drawing.Size(571, 228);
            this.cs2XmlEditor1.TabIndex = 0;
            this.cs2XmlEditor1.Text = "";
            this.cs2XmlEditor1.Updated = false;
            this.cs2XmlEditor1.WordWrap = false;
            // 
            // XmlEditorcontextMenuStrip
            // 
            this.XmlEditorcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator18,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem1,
            this.toolStripSeparator17,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator21,
            this.selectAllToolStripMenuItem});
            this.XmlEditorcontextMenuStrip.Name = "TreeViewContextMenu";
            this.XmlEditorcontextMenuStrip.Size = new System.Drawing.Size(132, 176);
            this.XmlEditorcontextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.XmlEditorcontextMenuStrip_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem1.Text = "Extract ..";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(128, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem1.Image")));
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(128, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(128, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cs2DatagridView1);
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(577, 234);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cs2DatagridView1
            // 
            this.cs2DatagridView1.AllowUserToAddRows = false;
            this.cs2DatagridView1.AllowUserToDeleteRows = false;
            this.cs2DatagridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.cs2DatagridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cs2DatagridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cs2DatagridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cs2DatagridView1.Location = new System.Drawing.Point(3, 3);
            this.cs2DatagridView1.Name = "cs2DatagridView1";
            this.cs2DatagridView1.ReadOnly = true;
            this.cs2DatagridView1.Size = new System.Drawing.Size(571, 228);
            this.cs2DatagridView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "treeview.jpg");
            this.imageList1.Images.SetKeyName(1, "textview2.jpg");
            this.imageList1.Images.SetKeyName(2, "textview.jpg");
            this.imageList1.Images.SetKeyName(3, "Webcontrol_Gridview.bmp");
            this.imageList1.Images.SetKeyName(4, "Filter2HS.png");
            // 
            // propertyInfo
            // 
            this.propertyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyInfo.Location = new System.Drawing.Point(0, 0);
            this.propertyInfo.Name = "propertyInfo";
            this.propertyInfo.Size = new System.Drawing.Size(203, 261);
            this.propertyInfo.TabIndex = 6;
            this.propertyInfo.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyInfo_PropertyValueChanged);
            // 
            // cs2LinqToXmlEditor1
            // 
            this.cs2LinqToXmlEditor1.AcceptsTab = true;
            this.cs2LinqToXmlEditor1.ContextMenuStrip = this.LinqToXmlEditorcontextMenuStrip;
            this.cs2LinqToXmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cs2LinqToXmlEditor1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cs2LinqToXmlEditor1.LinqNamespace = null;
            this.cs2LinqToXmlEditor1.Location = new System.Drawing.Point(0, 0);
            this.cs2LinqToXmlEditor1.Name = "cs2LinqToXmlEditor1";
            this.cs2LinqToXmlEditor1.Size = new System.Drawing.Size(792, 254);
            this.cs2LinqToXmlEditor1.TabIndex = 0;
            this.cs2LinqToXmlEditor1.Text = "";
            this.cs2LinqToXmlEditor1.WordWrap = false;
            this.cs2LinqToXmlEditor1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cs2LinqToXmlEditor1_KeyUp);
            // 
            // LinqToXmlEditorcontextMenuStrip
            // 
            this.LinqToXmlEditorcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAndCopyAllToolStripMenuItem});
            this.LinqToXmlEditorcontextMenuStrip.Name = "TreeViewContextMenu";
            this.LinqToXmlEditorcontextMenuStrip.Size = new System.Drawing.Size(175, 54);
            this.LinqToXmlEditorcontextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.LinqToXmlEditorcontextMenuStrip_Opening);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(171, 6);
            // 
            // selectAndCopyAllToolStripMenuItem
            // 
            this.selectAndCopyAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAndCopyAllToolStripMenuItem.Image")));
            this.selectAndCopyAllToolStripMenuItem.Name = "selectAndCopyAllToolStripMenuItem";
            this.selectAndCopyAllToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.selectAndCopyAllToolStripMenuItem.Text = "Select and copy all";
            this.selectAndCopyAllToolStripMenuItem.Click += new System.EventHandler(this.selectAndCopyAllToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMessage,
            this.toolStripStatusLabel1,
            this.tsLineColumn,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsMessage
            // 
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(592, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsLineColumn
            // 
            this.tsLineColumn.Name = "tsLineColumn";
            this.tsLineColumn.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 50;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsOpen,
            this.toolStripSeparator6,
            this.tsPaste,
            this.toolStripSeparator1,
            this.tsSelectAndCopy,
            this.tsQuit,
            this.toolStripSeparator2,
            this.tsOptions,
            this.toolStripSeparator3,
            this.toolStripSeparator5,
            this.tsGenerateClasses,
            this.toolStripSeparator19,
            this.tsSaveAs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsNew
            // 
            this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(81, 22);
            this.tsNew.Text = "New / clear";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsOpen
            // 
            this.tsOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsOpen.Image")));
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(89, 22);
            this.tsOpen.Text = "Open Xml file";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsPaste
            // 
            this.tsPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsPaste.Image")));
            this.tsPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPaste.Name = "tsPaste";
            this.tsPaste.Size = new System.Drawing.Size(73, 22);
            this.tsPaste.Text = "Paste Xml";
            this.tsPaste.Click += new System.EventHandler(this.tsPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSelectAndCopy
            // 
            this.tsSelectAndCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsSelectAndCopy.Image")));
            this.tsSelectAndCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSelectAndCopy.Name = "tsSelectAndCopy";
            this.tsSelectAndCopy.Size = new System.Drawing.Size(116, 22);
            this.tsSelectAndCopy.Text = "Select and copy all";
            this.tsSelectAndCopy.Click += new System.EventHandler(this.tsSelectAndCopy_Click);
            // 
            // tsQuit
            // 
            this.tsQuit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsQuit.AutoSize = false;
            this.tsQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsQuit.Image")));
            this.tsQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsQuit.Name = "tsQuit";
            this.tsQuit.Size = new System.Drawing.Size(60, 22);
            this.tsQuit.Text = "Quit";
            this.tsQuit.Click += new System.EventHandler(this.tsQuit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsOptions
            // 
            this.tsOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsOptions.AutoSize = false;
            this.tsOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsOptions.Image")));
            this.tsOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(60, 22);
            this.tsOptions.Text = "Options";
            this.tsOptions.Click += new System.EventHandler(this.tsOptions_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsGenerateClasses
            // 
            this.tsGenerateClasses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xPathVisualizerToolStripMenuItem,
            this.toolStripSeparator22,
            this.businessObjectsToolStripMenuItem,
            this.businessDataAccessToolStripMenuItem});
            this.tsGenerateClasses.Image = ((System.Drawing.Image)(resources.GetObject("tsGenerateClasses.Image")));
            this.tsGenerateClasses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGenerateClasses.Name = "tsGenerateClasses";
            this.tsGenerateClasses.Size = new System.Drawing.Size(80, 22);
            this.tsGenerateClasses.Text = "Business";
            // 
            // xPathVisualizerToolStripMenuItem
            // 
            this.xPathVisualizerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xPathVisualizerToolStripMenuItem.Image")));
            this.xPathVisualizerToolStripMenuItem.Name = "xPathVisualizerToolStripMenuItem";
            this.xPathVisualizerToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.xPathVisualizerToolStripMenuItem.Text = "XPath visualizer";
            this.xPathVisualizerToolStripMenuItem.Click += new System.EventHandler(this.xPathVisualizerToolStripMenuItem_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(187, 6);
            // 
            // businessObjectsToolStripMenuItem
            // 
            this.businessObjectsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("businessObjectsToolStripMenuItem.Image")));
            this.businessObjectsToolStripMenuItem.Name = "businessObjectsToolStripMenuItem";
            this.businessObjectsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.businessObjectsToolStripMenuItem.Text = "Business objects";
            this.businessObjectsToolStripMenuItem.Click += new System.EventHandler(this.businessObjectsToolStripMenuItem_Click);
            // 
            // businessDataAccessToolStripMenuItem
            // 
            this.businessDataAccessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.businessDataAccessToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("businessDataAccessToolStripMenuItem.Image")));
            this.businessDataAccessToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.businessDataAccessToolStripMenuItem.Name = "businessDataAccessToolStripMenuItem";
            this.businessDataAccessToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.businessDataAccessToolStripMenuItem.Text = "Generate data access";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem2.Text = "with object";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem3.Text = "with create method";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSaveAs
            // 
            this.tsSaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveXmlToolStripMenuItem,
            this.toolStripSeparator15,
            this.saveLinqToXmlGeneratedAsToolStripMenuItem});
            this.tsSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tsSaveAs.Image")));
            this.tsSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaveAs.Name = "tsSaveAs";
            this.tsSaveAs.Size = new System.Drawing.Size(63, 22);
            this.tsSaveAs.Text = "Save";
            // 
            // saveXmlToolStripMenuItem
            // 
            this.saveXmlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveXmlToolStripMenuItem.Image")));
            this.saveXmlToolStripMenuItem.Name = "saveXmlToolStripMenuItem";
            this.saveXmlToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.saveXmlToolStripMenuItem.Text = "Save Xml as ..";
            this.saveXmlToolStripMenuItem.Click += new System.EventHandler(this.saveXmlToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(240, 6);
            // 
            // saveLinqToXmlGeneratedAsToolStripMenuItem
            // 
            this.saveLinqToXmlGeneratedAsToolStripMenuItem.Name = "saveLinqToXmlGeneratedAsToolStripMenuItem";
            this.saveLinqToXmlGeneratedAsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.saveLinqToXmlGeneratedAsToolStripMenuItem.Text = "Save Linq To Xml generated as ..";
            this.saveLinqToXmlGeneratedAsToolStripMenuItem.Click += new System.EventHandler(this.saveLinqToXmlGeneratedAsToolStripMenuItem_Click);
            // 
            // TabControlcontextMenuStrip
            // 
            this.TabControlcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.TabControlcontextMenuStrip.Name = "contextMenuStrip1";
            this.TabControlcontextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TabControlcontextMenuStrip.Size = new System.Drawing.Size(112, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cs2GenLinqToXml - [ Linq To Xml code generator ]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.cs2TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.TreeViewContextMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.XmlEditorcontextMenuStrip.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cs2DatagridView1)).EndInit();
            this.LinqToXmlEditorcontextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TabControlcontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid propertyInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsLineColumn;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsSelectAndCopy;
        private System.Windows.Forms.ToolStripButton tsQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton tsGenerateClasses;
        private System.Windows.Forms.ToolStripMenuItem businessObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessDataAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripSplitButton tsSaveAs;
        private System.Windows.Forms.ToolStripMenuItem saveXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem saveLinqToXmlGeneratedAsToolStripMenuItem;
        private Cs2TabControl cs2TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Cs2XmlTreeView cs2XmlTreeView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem extractFromTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeclarationOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommentOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertBeforeCommentOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertAfterCommentOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem updateCommentOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem removeCommentOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addElementOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertBeforeElementOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertAfterElementOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem updateElementOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem removeElementOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddAttributeOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertBeforeAttributeOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertAfterAttributeOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem updateAttributeOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem removeAttributeOfTreeToolstripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem cutOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem generateClassAndVarOfTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateDataAccessWithVarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withCreateMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem postDataInDatagridviewToolStripMenuItem;
        private Cs2XmlEditor cs2XmlEditor1;
        private System.Windows.Forms.ContextMenuStrip TabControlcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        internal System.Windows.Forms.ImageList imageList1;
        private Cs2DatagridView cs2DatagridView1;
        private Cs2LinqToXmlEditor cs2LinqToXmlEditor1;
        private System.Windows.Forms.ContextMenuStrip XmlEditorcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip LinqToXmlEditorcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAndCopyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xPathVisualizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
    }
}

