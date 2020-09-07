using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class MainForm : Form
    {
        // Fields
        private delegate void LoadFromFileHandler(string FilePath);
        private delegate void LoadFromPasteXmlHandler(string xml);
        private delegate void PostProgressHandler(bool isVisible, string Message);
        private delegate void ExtractDataHandler();
        private delegate void PostExtractDataHandler(System.Xml.XmlNode oXmlNode);
        private delegate void PostLoadDataEventHandler(System.Xml.XmlDocument oXmlDocument);
        private LoadFromFileHandler LoadFromFile;
        private LoadFromPasteXmlHandler LoadPasteXml;
        private ExtractDataHandler ExtractData;
        private Cs2GenLinqToXmlLib.XmlHelper oXmlHelper;
        private System.Xml.XmlNode oXmlNodeCopy;

        public MainForm()
        {
            InitializeComponent();
        }

        // Events
        #region load and close

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            oXmlHelper = null;
            oXmlNodeCopy = null;
            LoadFromFile = null;
            LoadPasteXml = null;
            ExtractData = null;
            this.Dispose();
        }

        #endregion load and close

        #region toolstrip

        private void tsNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAndNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void tsPaste_Click(object sender, EventArgs e)
        {
            try
            {
                LoadXml(Clipboard.GetText());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsSelectAndCopy_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAndCopyAllLinqToXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void businessObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateBusinessObjects();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDirectElement();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCreateMethod();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }
        private void saveXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveXmlDocument();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void saveLinqToXmlGeneratedAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveLinqToXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void tsOptions_Click(object sender, EventArgs e)
        {
            try
            {
                ManageOptions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsQuit_Click(object sender, EventArgs e)
        {
            try
            {
                ExitApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion toolstrip

        #region context menu treeview

        private void TreeViewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (cs2XmlTreeView1.Nodes.Count == 0)
                    ContextMenuTreeViewManager(false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
                else if (cs2XmlTreeView1.SelectedNode == null)
                    ContextMenuTreeViewManager(false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            }
            catch
            { }
        }

        private void extractFromTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExtractData.BeginInvoke(null, null);
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void addDeclarationOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddDeclaration();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void addCommentOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddComment();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void insertBeforeCommentOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommentBefore();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void insertAfterCommentOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InsertCommentAfter();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void updateCommentOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateComment();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void removeCommentOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveComment();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void addElementOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddElement();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void insertBeforeElementOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InsertElementBefore();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void insertAfterElementOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InsertElementAfter();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void updateElementOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateElement();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void removeElementOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveElement();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void AddAttributeOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddAttribute();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void insertBeforeAttributeOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAttributeBefore();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void insertAfterAttributeOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InsertAttributeAfter();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void updateAttributeOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateAttribute();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void removeAttributeOfTreeToolstripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveAttribute();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }
        private void cutOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                oXmlNodeCopy = oXmlHelper.CutNode(cs2XmlTreeView1.CurrentXPath);
                cs2XmlTreeView1.SelectedNode.Remove();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void copyOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                    oXmlNodeCopy = oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath);

                if (cs2XmlTreeView1.SelectedNode is XmlAttributeTreeNode)
                    oXmlNodeCopy = oXmlHelper.GetAttribute(cs2XmlTreeView1.CurrentXPath);
                
                if (cs2XmlTreeView1.SelectedNode is XmlCommentTreeNode)
                    oXmlNodeCopy = oXmlHelper.GetComment(cs2XmlTreeView1.CurrentXPath);

            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void pasteOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oXmlNodeCopy != null)
                {
                    switch (oXmlNodeCopy.NodeType)
                    {
                        case System.Xml.XmlNodeType.Element:
                            if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                            {
                                oXmlHelper.AddElement(cs2XmlTreeView1.CurrentXPath,(System.Xml.XmlElement) oXmlNodeCopy.Clone());
                                cs2XmlTreeView1.AddElement(cs2XmlTreeView1.CreateElement(oXmlNodeCopy));
                            }
                            break;
                        case System.Xml.XmlNodeType.Text:

                            break;
                        case System.Xml.XmlNodeType.Attribute:
                            if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                            {
                                oXmlHelper.AddAttribute(cs2XmlTreeView1.CurrentXPath, (System.Xml.XmlAttribute)oXmlNodeCopy.Clone());
                                cs2XmlTreeView1.AddAttribute(cs2XmlTreeView1.CreateAttribute((System.Xml.XmlAttribute)oXmlNodeCopy));
                            }
                            break;
                        case System.Xml.XmlNodeType.Comment:
                            if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                            {
                                oXmlHelper.AddComment(cs2XmlTreeView1.CurrentXPath, (System.Xml.XmlComment)oXmlNodeCopy.Clone());
                                cs2XmlTreeView1.AddComment(cs2XmlTreeView1.CreateComment(oXmlNodeCopy.InnerText));
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void removeOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cs2XmlTreeView1.SelectedNode != null)
                {
                    if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                    {
                        RemoveElement();
                    }
                    if (cs2XmlTreeView1.SelectedNode is XmlAttributeTreeNode)
                    {
                        RemoveAttribute();
                    }
                    if (cs2XmlTreeView1.SelectedNode is XmlCommentTreeNode)
                    {
                        RemoveComment();
                    }
                }
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, true);
            }
        }

        private void generateClassAndVarOfTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateBusinessObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void withObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDirectElement();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void withCreateMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCreateMethod();
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }      

        private void postDataInDatagridviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PostDataInDatagridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion context menu treeview

        #region context menu XmlEditor

        private void XmlEditorcontextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cs2XmlEditor1.SelectedText))
                {
                    toolStripMenuItem1.Enabled = false;
                    cutToolStripMenuItem.Enabled = false;
                    copyToolStripMenuItem.Enabled = false;
                }
                else
                {
                    toolStripMenuItem1.Enabled = true;
                    cutToolStripMenuItem.Enabled = true;
                    copyToolStripMenuItem.Enabled = true;
                }
                if (string.IsNullOrEmpty(Clipboard.GetText()))
                    pasteToolStripMenuItem1.Enabled = false;
                else
                    pasteToolStripMenuItem1.Enabled = true;
                undoToolStripMenuItem.Enabled = cs2XmlEditor1.CanUndo;
                redoToolStripMenuItem.Enabled = cs2XmlEditor1.CanRedo;
                if (string.IsNullOrEmpty(cs2XmlEditor1.Text))
                    selectAllToolStripMenuItem.Enabled = false;
                else
                    selectAllToolStripMenuItem.Enabled = true;
            }
            catch
            { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Xml.XmlNode oXmlNode = oXmlHelper.CreateNode(cs2XmlEditor1.SelectedText);
                cs2LinqToXmlEditor1.ConvertToLinqToXml(oXmlNode);
                PostMessage("Ready", true);
            }
            catch (Exception ex)
            {
                PostMessage(ex.Message, false);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cs2XmlEditor1.Cut();
            }
            catch
            { }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cs2XmlEditor1.Copy();
            }
            catch
            { }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                cs2XmlEditor1.Paste();
            }
            catch
            { }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cs2XmlEditor1.Undo();
            }
            catch
            { }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cs2XmlEditor1.Redo();
            }
            catch
            { }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                cs2XmlEditor1.SelectAll();
            }
            catch
            { }
        }

        #endregion context menu XmlEditor

        #region context menu Linq To Xml

        private void LinqToXmlEditorcontextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Clipboard.GetText()))
                    pasteToolStripMenuItem.Enabled = false;
                else
                    pasteToolStripMenuItem.Enabled = true;
                if (string.IsNullOrEmpty(cs2LinqToXmlEditor1.Text))
                {
                    selectAndCopyAllToolStripMenuItem.Enabled = false;
                }
                else
                {
                    selectAndCopyAllToolStripMenuItem.Enabled = true;
                }
            }
            catch
            { }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadXml(Clipboard.GetText());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void selectAndCopyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectAndCopyAllLinqToXml();
            }
            catch
            { }
        }

        #endregion context menu Linq To Xml

        #region context menu tabcontrol

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cs2TabControl1.RemoveTabPage(cs2TabControl1.SelectedTab);
        }

        #endregion context menu tabcontrol

        #region treeview

        private void cs2XmlTreeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (cs2XmlTreeView1.SelectedNode != null)
                    {
                        if (cs2XmlTreeView1.SelectedNode is XmlCommentTreeNode)
                            UpdateComment();
                        if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                            UpdateElement();
                        if (cs2XmlTreeView1.SelectedNode is XmlAttributeTreeNode)
                            UpdateAttribute();
                    }
                }
            }
            catch
            { }
        }
        private void cs2XmlTreeView1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {               
                if (e.KeyCode == Keys.Delete)
                {
                    if (cs2XmlTreeView1.SelectedNode != null)
                    {
                        if (cs2XmlTreeView1.SelectedNode is XmlCommentTreeNode)
                            RemoveComment();
                        if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                            RemoveElement();
                        if (cs2XmlTreeView1.SelectedNode is XmlAttributeTreeNode)
                            RemoveAttribute();
                    }
                }
            }
            catch
            { }
        }

        #endregion treeview

        #region linq to xml editor

        private void cs2LinqToXmlEditor1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
                {
                    LoadXml(Clipboard.GetText());
                }
                if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
                {
                    cs2LinqToXmlEditor1.Undo();
                }
                if (e.KeyCode == Keys.Y && e.Modifiers == Keys.Control)
                {
                    cs2LinqToXmlEditor1.Redo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion linq to xml editor

        #region tabcontrol

        private void cs2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Xml.XmlDocument oXmlDocumentInMemory = null;
            try
            {
                if (!cs2TabControl1.isInDragDrop)
                {
                    oXmlDocumentInMemory = oXmlHelper.XmlDocument;
                    RefreshTreeView();
                    RefreshXmlEditor();
                }
            }
            catch (Exception ex)
            {
                if (oXmlDocumentInMemory != null && oXmlHelper.XmlDocument != null)
                    oXmlHelper.XmlDocument = oXmlDocumentInMemory;
                PostMessage(ex.Message, false);
            }
        }

        #endregion tabcontrol

        #region propertygrid

        private void propertyInfo_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            System.Xml.XmlDocument oXmlDocumentInMemory = oXmlHelper.XmlDocument;
            try
            {
                RefreshAll();
            }
            catch (Exception ex)
            {
                if (oXmlDocumentInMemory != null)
                    oXmlHelper.XmlDocument = oXmlDocumentInMemory;
                PostMessage(ex.Message, false);
            }
        }

        #endregion propertygrid

        // Methods
        #region load and close

        public void Init()
        {
            LoadOptions();
            oXmlHelper = new Cs2GenLinqToXmlLib.XmlHelper();
            oXmlHelper.CreateDocument();
            cs2TabControl1.TabPageSelected += new Cs2TabControl.TabPageSelectedHandler(TabPageSelected);
            cs2XmlTreeView1.TreeViewAfterSelected += new Cs2XmlTreeView.TreeViewAfterSelect(TreeViewAfterSelect);
            cs2XmlEditor1.ColumnLineChanged += new Cs2XmlEditor.ColumnLineChangedHandler(PostLineAndColumnOfXmlEditor);
            cs2XmlEditor1.ParsedXml += new Cs2XmlEditor.ParsedXmlHandler(PostMessage);
            LoadFromFile = new LoadFromFileHandler(GetDocumentFromFile);
            LoadPasteXml = new LoadFromPasteXmlHandler(GetDocumentFromPasteXml);
            ExtractData = new ExtractDataHandler(ExtractXmlFromTree);
            PostMessage("Ready", true);
        }
        public void LoadOptions()
        {
            Options.ErrorColor = Properties.Settings.Default.ErrorColor;
            Options.IncludeLinqCompletePathNamespace = Properties.Settings.Default.IncludeLinqCompletePathNamespace;
            Options.IncludeXComment = Properties.Settings.Default.IncludeXComment;
            Options.NamespaceForCSharpFiles = Properties.Settings.Default.NamespaceForCSharpFiles;
            Options.ParseXml = Properties.Settings.Default.ParseXml;
        }
        private void ClearAndNew()
        {
            ClearAll();
            oXmlHelper.CreateDocument();
            PostMessage("Ready", true);
        }
        public void OpenFile()
        {
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Xml files (*.xml)|*.xml| Xsd files (*.xsd)|*.xsd|Xsl files (*.xsl)|*.xdl|All files (*.*)|*.*";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFromFile.BeginInvoke(oOpenFileDialog.FileName, null, null);
            }
        }
        public void LoadXml(string xml)
        {
            LoadPasteXml.BeginInvoke(xml, null, null);
        }
        public void GetDocumentFromFile(string FilePath)
        {
            try
            {
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), true, "Loading " + FilePath + " ..");
                oXmlHelper.LoadFile(FilePath);
                this.Invoke(new PostLoadDataEventHandler(PostLoadData), oXmlHelper.XmlDocument);
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), false, "Ready");
            }
            catch (Exception ex)
            {
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), false, "Ready");
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void GetDocumentFromPasteXml(string Xml)
        {
            try
            {
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), true, "Loading from clipboard ..");
                oXmlHelper.LoadXml(Xml);
                this.Invoke(new PostLoadDataEventHandler(PostLoadData), oXmlHelper.XmlDocument);
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), false, "Ready");
            }
            catch (Exception ex)
            {
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), false, "Ready");
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void ExtractXmlFromTree()
        {
            try
            {
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), true, "Extract ..");
                this.Invoke(new PostExtractDataHandler(PostExtractData), oXmlHelper.GetNode(cs2XmlTreeView1.CurrentXPath));
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), false, "Ready");
            }
            catch (Exception ex)
            {
                this.Invoke(new PostProgressHandler(PostProgressAndMessage), false, "Ready");
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void PostLoadData(System.Xml.XmlDocument oXmlDocument)
        {
            try
            {
                cs2XmlTreeView1.Load(oXmlDocument);
                cs2XmlEditor1.ConvertXmlToText(oXmlDocument);
                cs2LinqToXmlEditor1.ConvertToLinqToXml(oXmlDocument);
                propertyInfo.SelectedObject = null;
                if (cs2TabControl1.TabPages.ContainsKey("tabPage3"))
                {
                    TabPage oTabPage = cs2TabControl1.TabPages["tabPage3"];
                    DataGridView oDatagridView = oTabPage.Controls["cs2DatagridView1"] as DataGridView;
                    oDatagridView.DataSource = null;
                }
                if (cs2TabControl1.TabPages.ContainsKey("tabPage4"))
                {
                    TabPage oTabPage = cs2TabControl1.TabPages["tabPage4"];
                    XPathVisualizer oXPathVisualizer = oTabPage.Controls["xPathVisualizer1"] as XPathVisualizer;
                    oXPathVisualizer.LoadDocument(oXmlHelper.XmlDocument);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void PostExtractData(System.Xml.XmlNode oXmlNode)
        {
            try
            {
                cs2LinqToXmlEditor1.ConvertToLinqToXml(oXmlNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Caution .. ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void PostProgressAndMessage(bool isVisible, string Message)
        {
            toolStripProgressBar1.Visible = isVisible;
            tsMessage.Text = Message;
            tsMessage.ForeColor = System.Drawing.SystemColors.WindowText;
        }
        private static void ExitApplication()
        {
            Application.Exit();
        }

        #endregion load and close

        #region declaration

        private void AddDeclaration()
        {
            oXmlHelper.AddDeclaration(oXmlHelper.CreateDeclaration());
            cs2XmlTreeView1.CreateDocument(oXmlHelper.XmlDocument);
            PostMessage("Ready", true);
        }

        #endregion

        #region comment

        private void AddComment()
        {
            FComment oFComment = new FComment();
            oFComment.ShowDialog();
            if (oFComment.bValidate)
            {
                oXmlHelper.AddComment(cs2XmlTreeView1.CurrentXPath,oXmlHelper.CreateComment(oFComment.Comment));
                cs2XmlTreeView1.AddComment(cs2XmlTreeView1.CreateComment(oFComment.Comment));
                PostMessage("Ready",false);
            }
        }
        private void InsertCommentBefore()
        {
            FComment oFComment = new FComment();
            oFComment.ShowDialog();
            if (oFComment.bValidate)
            {
                oXmlHelper.InsertCommentBefore(oXmlHelper.GetNode(cs2XmlTreeView1.CurrentXPath), oXmlHelper.CreateComment(oFComment.Comment));
                cs2XmlTreeView1.InsertCommentBefore(cs2XmlTreeView1.CreateComment(oFComment.Comment));
                PostMessage("Ready",false);
            }
        }
        private void InsertCommentAfter()
        {
            FComment oFComment = new FComment();
            oFComment.ShowDialog();
            if (oFComment.bValidate)
            {
                if (cs2XmlTreeView1.SelectedNode is XmlDeclarationTreeNode)
                {
                    oXmlHelper.AddComment(oXmlHelper.XmlDocument, oXmlHelper.CreateComment(oFComment.Comment));
                }
                else
                {
                    oXmlHelper.InsertCommentAfter(oXmlHelper.GetNode(cs2XmlTreeView1.CurrentXPath), oXmlHelper.CreateComment(oFComment.Comment));
                }
            
                cs2XmlTreeView1.InsertCommentAfter(cs2XmlTreeView1.CreateComment(oFComment.Comment));
                PostMessage("Ready",false);
            }
        }
        private void UpdateComment()
        {
            FComment oFComment = new FComment();
            oFComment.Comment = oXmlHelper.GetComment(cs2XmlTreeView1.CurrentXPath).Value;
            oFComment.ShowDialog();
            if (oFComment.bValidate)
            {
                oXmlHelper.UpdateComment(oXmlHelper.GetComment(cs2XmlTreeView1.CurrentXPath),oFComment.Comment);
                cs2XmlTreeView1.UpdateComment(oFComment.Comment);
                PostMessage("Ready",false);
            }
        }
        private void RemoveComment()
        {
            oXmlHelper.RemoveComment(oXmlHelper.GetComment(cs2XmlTreeView1.CurrentXPath));
            cs2XmlTreeView1.RemoveComment();
            PostMessage("Ready",false);
        }

        #endregion comment

        #region element

        private void AddElement()
        {
            FElement oFElement = new FElement();
            oFElement.CanGetValue = true;
            oFElement.ShowDialog();
            if (oFElement.bValidate)
            {
                System.Xml.XmlElement oXmlElement = null;
                if (string.IsNullOrEmpty(oFElement.ElementValue))
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName);
                    if (cs2XmlTreeView1.SelectedNode is XmlDeclarationTreeNode)
                         oXmlHelper.AddRoot(oXmlElement);
                    else
                         oXmlHelper.AddElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }
                else
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName, oFElement.ElementValue);
                    if (cs2XmlTreeView1.SelectedNode is XmlDeclarationTreeNode)
                        oXmlHelper.AddRoot(oXmlElement);
                    else
                        oXmlHelper.AddElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }

                if (cs2XmlTreeView1.SelectedNode is XmlDeclarationTreeNode)
                    cs2XmlTreeView1.AddRoot(cs2XmlTreeView1.CreateElement(oXmlElement));
                else
                    cs2XmlTreeView1.AddElement(cs2XmlTreeView1.CreateElement(oXmlElement));

                PostMessage("Ready", true);
            }
        }
        private void InsertElementBefore()
        {
             FElement oFElement = new FElement();
            oFElement.CanGetValue = true;
            oFElement.ShowDialog();
            if (oFElement.bValidate)
            {
                System.Xml.XmlElement oXmlElement = null;
                if (string.IsNullOrEmpty(oFElement.ElementValue))
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName);
                    oXmlHelper.InsertElementBeforeElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }
                else
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName, oFElement.ElementValue);
                    oXmlHelper.InsertElementBeforeElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }
                cs2XmlTreeView1.InsertElementBeforeElement(cs2XmlTreeView1.CreateElement(oXmlElement));
                PostMessage("Ready", true);
            }
        }

        private void InsertElementAfter()
        {
             FElement oFElement = new FElement();
            oFElement.CanGetValue = true;
            oFElement.ShowDialog();
            if (oFElement.bValidate)
            {
                System.Xml.XmlElement oXmlElement = null;
                if (string.IsNullOrEmpty(oFElement.ElementValue))
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName);
                    oXmlHelper.InsertElementAfterElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }
                else
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName, oFElement.ElementValue);
                    oXmlHelper.InsertElementAfterElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }
                cs2XmlTreeView1.InsertElementAfterElement(cs2XmlTreeView1.CreateElement(oXmlElement));
                PostMessage("Ready", true);
            }
        }
        private void UpdateElement()
        {
            
            FElement oFElement = new FElement();
            System.Xml.XmlElement oXmlElementToUpdate = oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath);
            if ((oXmlElementToUpdate.ChildNodes.Count == 1 && oXmlElementToUpdate.FirstChild.NodeType == System.Xml.XmlNodeType.Text) || oXmlElementToUpdate.ChildNodes.Count == 0)
                oFElement.GiveElement(oXmlElementToUpdate.Name, oXmlElementToUpdate.InnerText, true);
            else
                oFElement.GiveElement(oXmlElementToUpdate.Name, string.Empty, false);

            oFElement.ShowDialog();
            if (oFElement.bValidate)
            {
                System.Xml.XmlElement oXmlElement = null;
                if (string.IsNullOrEmpty(oFElement.ElementValue))
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName);
                    oXmlHelper.UpdateElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }
                else
                {
                    oXmlElement = oXmlHelper.CreateElement(oFElement.ElementName, oFElement.ElementValue);
                    oXmlHelper.UpdateElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlElement);
                }

                cs2XmlTreeView1.UpdateElement(cs2XmlTreeView1.CreateElement(oXmlElement));
                PostMessage("Ready", true);
            }
        }

        private void RemoveElement()
        {
            oXmlHelper.RemoveElement(cs2XmlTreeView1.CurrentXPath);
            cs2XmlTreeView1.RemoveElement();
            PostMessage("Ready", true);
        }

        #endregion element

        #region Attribute

        private void AddAttribute()
        {
            FAttribute oFAttribute = new FAttribute();
            oFAttribute.ShowDialog();
            if (oFAttribute.bValidate)
            {
                System.Xml.XmlAttribute oXmlAttribute = oXmlHelper.CreateAttribute(oFAttribute.AttributeName, oFAttribute.AttributeValue);
                oXmlHelper.AddAttribute(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), oXmlAttribute);
                cs2XmlTreeView1.AddAttribute(cs2XmlTreeView1.CreateAttribute(oXmlAttribute));
                PostMessage("Ready", true);
            }
        }
        private void InsertAttributeBefore()
        {
            FAttribute oFAttribute = new FAttribute();
            oFAttribute.ShowDialog();
            if (oFAttribute.bValidate)
            {
                System.Xml.XmlAttribute oXmlAttribute = oXmlHelper.CreateAttribute(oFAttribute.AttributeName, oFAttribute.AttributeValue);
                oXmlHelper.InsertAttributeBeforeAttribute(oXmlHelper.GetAttribute(cs2XmlTreeView1.CurrentXPath), oXmlAttribute);
                cs2XmlTreeView1.InsertAttributeBefore(cs2XmlTreeView1.CreateAttribute(oXmlAttribute));
                PostMessage("Ready", true);
            }
        }
        private void InsertAttributeAfter()
        {
            FAttribute oFAttribute = new FAttribute();
            oFAttribute.ShowDialog();
            if (oFAttribute.bValidate)
            {
                System.Xml.XmlAttribute oXmlAttribute = oXmlHelper.CreateAttribute(oFAttribute.AttributeName, oFAttribute.AttributeValue);
                oXmlHelper.InsertAttributeAfterAttribute(oXmlHelper.GetAttribute(cs2XmlTreeView1.CurrentXPath), oXmlAttribute);
                cs2XmlTreeView1.InsertAttributeAfter(cs2XmlTreeView1.CreateAttribute(oXmlAttribute));
                PostMessage("Ready", true);
            }
        }
        private void UpdateAttribute()
        {
            FAttribute oFAttribute = new FAttribute();
            System.Xml.XmlAttribute oXmlAttributeref = oXmlHelper.GetAttribute(cs2XmlTreeView1.CurrentXPath);
            oFAttribute.AttributeName = oXmlAttributeref.Name;
            oFAttribute.AttributeValue = oXmlAttributeref.Value;
            oFAttribute.ShowDialog();
            if (oFAttribute.bValidate)
            {
                System.Xml.XmlAttribute oXmlAttribute = oXmlHelper.CreateAttribute(oFAttribute.AttributeName, oFAttribute.AttributeValue);
                oXmlHelper.UpdateAttribute(oXmlHelper.GetAttribute(cs2XmlTreeView1.CurrentXPath), oXmlAttribute);
                cs2XmlTreeView1.UpdateAttribute(cs2XmlTreeView1.CreateAttribute(oXmlAttribute));
                PostMessage("Ready", true);
            }
        }
        private void RemoveAttribute()
        {
            oXmlHelper.RemoveAttribute(oXmlHelper.GetAttribute(cs2XmlTreeView1.CurrentXPath));
            cs2XmlTreeView1.RemoveAttribute();
            PostMessage("Ready", true);
        }


        #endregion Attribute

        #region treeview 

        public void TreeViewAfterSelectedMethod(string xpath, TreeNode oTreeNode)
        {
            propertyInfo.SelectedObject = oXmlHelper.GetNode(xpath);
        }

        public void TreeViewAfterSelect(string xpath, TreeNode oTreeNode)
        {
            try
            {
                if (oTreeNode != null)
                {
                    // declaration 
                    if (oTreeNode is XmlDeclarationTreeNode)
                        if (cs2XmlTreeView1.HasXmlElementTreeNode())
                            ContextMenuTreeViewManager(true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, false, false, false);
                        else
                            ContextMenuTreeViewManager(true, false, false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, false, true, true);
                    // ProcessingInstruction
                    if (oTreeNode is XmlProcessingInstructionTreeNode)
                        ContextMenuTreeViewManager(true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
                    // Comment
                    if (oTreeNode is XmlCommentTreeNode)
                        ContextMenuTreeViewManager(true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, true, true, true, true, false, true);

                    // element
                    if (oTreeNode is XmlElementTreeNode)
                    {
                        if (oTreeNode.Level == 0)
                        {
                            if (cs2XmlTreeView1.HasXmlElementTreeNode())
                                ContextMenuTreeViewManager(true, true, false, false, true, true, false, false, true, true, true, true, false, false, false, false, true, true, true, false, false, false, true, true, true, true);
                            else
                                ContextMenuTreeViewManager(true, true, false, false, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true, false, false, false, true, true, false, true);
                        }
                        else
                            ContextMenuTreeViewManager(true, true, false, false, true, true, true, true, true, true, true, true, false, false, false, false, true, true, true, false, false, false, true, true, true, true);
                        if (oTreeNode.Nodes.Count == 1 && oTreeNode.FirstNode is XmlTextTreeNode)
                            if (oXmlNodeCopy != null)
                                if (oXmlNodeCopy.NodeType != System.Xml.XmlNodeType.Attribute)
                                {
                                    pasteOfTreeToolStripMenuItem.Enabled = false;
                                }
                    }
                    // attribute
                    if (oTreeNode is XmlAttributeTreeNode)
                        ContextMenuTreeViewManager(true, false, false, false, false, false, false, false, false, false, true, false, true, true, true, true, false, false, false, false, false, false, true, true, true, true);
                    // text
                    if (oTreeNode is XmlTextTreeNode)
                        ContextMenuTreeViewManager(true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
                    propertyInfo.SelectedObject = oXmlHelper.XmlDocument.SelectSingleNode(xpath);
                }
            }
            catch
            { }
        }

        #endregion treeview

        #region post message

        public void PostMessage(string Message,bool IsXmlWellFormed)
        {
            Message = Message.Replace("\r", " ");
            tsMessage.Text = Message;
            if (!IsXmlWellFormed)
                tsMessage.ForeColor = Options.ErrorColor;
            else
                tsMessage.ForeColor = System.Drawing.SystemColors.WindowText;
            if (tsMessage.Text.IndexOf("\0'") != -1)
                tsMessage.Text = "wait ..";
            if (statusStrip1.Height > 22)
                statusStrip1.Height = 22;
        }
        public void PostLineAndColumnOfXmlEditor(int Line, int Column, string Message)
        {
            tsLineColumn.Text = Message;
        }
        public void TabPageSelected(Point oPoint, TabPage oTabPage)
        {
            if (oTabPage.Name == "tabPage3" || oTabPage.Name == "tabPage4")
            {
                TabControlcontextMenuStrip.Show(oTabPage, oPoint);
            }
        }
        private void PostDataInDatagridView()
        {
            System.Xml.XmlNode oXmlNode = oXmlHelper.GetNode(cs2XmlTreeView1.CurrentXPath);

            System.IO.StringReader oStringReader = new System.IO.StringReader(oXmlNode.OuterXml);
            DataSet oDataSet = new DataSet();
            oDataSet.ReadXml(oStringReader, XmlReadMode.Auto);

            if (!cs2TabControl1.TabPages.ContainsKey("tabPage3"))
            {
                Cs2DatagridView oDatagridView = new Cs2DatagridView("cs2DatagridView1", false, false, true, System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader);
                oDatagridView.DataSource = oDataSet.Tables[0];
                cs2TabControl1.TabPages.Add(cs2TabControl1.CreateTabPage("tabPage3", "Data", 3, oDatagridView));
            }
            else
            {
                TabPage oTabPage = cs2TabControl1.TabPages["tabPage3"];
                Cs2DatagridView oDatagridView = oTabPage.Controls["cs2DatagridView1"] as Cs2DatagridView;
                oDatagridView.DataSource = oDataSet.Tables[0];
            }
            cs2TabControl1.SelectedTab = cs2TabControl1.TabPages["tabPage3"];
        }

        #endregion post message

        #region refresh

        private void RefreshXmlEditor()
        {
            if (cs2TabControl1.SelectedTab.Name == "tabPage2")
            {
                if (cs2XmlTreeView1.Updated)
                {
                    cs2XmlEditor1.ConvertXmlToText(oXmlHelper.XmlDocument);
                    cs2XmlTreeView1.Updated = false;
                    PostMessage("Ready", true);
                }
            }
        }

        private void RefreshTreeView()
        {
            if (cs2TabControl1.SelectedTab.Name == "tabPage1")
            {
                if (cs2XmlEditor1.Updated)
                {
                    oXmlHelper.LoadXml(cs2XmlEditor1.Text);
                    cs2XmlTreeView1.Load(oXmlHelper.XmlDocument);
                    cs2XmlTreeView1.GetSelectedNodeByFullPath();
                    cs2XmlEditor1.Updated = false;
                    PostMessage("Ready", true);
                }
            }
        }
        private void RefreshAll()
        {
            cs2XmlEditor1.ConvertXmlToText(oXmlHelper.XmlDocument);
            cs2XmlTreeView1.Updated = false;
            oXmlHelper.LoadXml(cs2XmlEditor1.Text);
            cs2XmlTreeView1.Load(oXmlHelper.XmlDocument);
            cs2XmlTreeView1.GetSelectedNodeByFullPath();
            cs2XmlEditor1.Updated = false;
            if (cs2TabControl1.TabPages.ContainsKey("tabPage3"))
            {
                TabPage oTabPage = cs2TabControl1.TabPages["tabPage3"];
                DataGridView oDatagridView = oTabPage.Controls["cs2DatagridView1"] as DataGridView;
                oDatagridView.DataSource = null;
            }
            PostMessage("Ready", true);
        }

        #endregion

        #region utilities

        private void ClearAll()
        {
            cs2XmlTreeView1.Nodes.Clear();
            cs2XmlEditor1.Text = string.Empty;
            cs2LinqToXmlEditor1.Text = string.Empty;
            propertyInfo.SelectedObject = null;
            oXmlHelper.XmlDocument = null;

            if (cs2TabControl1.TabPages.ContainsKey("tabPage3"))
            {
                TabPage oTabPage = cs2TabControl1.TabPages["tabPage3"];
                DataGridView oDatagridView = oTabPage.Controls["cs2DatagridView1"] as DataGridView;
                oDatagridView.DataSource = null;
            }
            if (cs2TabControl1.TabPages.ContainsKey("tabPage4"))
            {
                TabPage oTabPage = cs2TabControl1.TabPages["tabPage4"];
                XPathVisualizer oXPathVisualizer = oTabPage.Controls["xPathVisualizer1"] as XPathVisualizer;
                oXPathVisualizer.ClearAll();
            }
        }
        private void SelectAndCopyAllLinqToXml()
        {
            cs2LinqToXmlEditor1.SelectAll();
            cs2LinqToXmlEditor1.Copy();
        }
        private void SaveXmlDocument()
        {
            SaveFileDialog oSaveFileDialog = new SaveFileDialog();
            oSaveFileDialog.Filter = "Xml files (*.xml)|*.xml| Xsd files (*.xsd)|*.xsd|Xsl files (*.xsl)|*.xdl|All files (*.*)|*.*";
            if (cs2XmlEditor1.Updated)
            {
                System.Xml.XmlDocument MemoryXmlDocument = oXmlHelper.XmlDocument;
                try
                {
                    oXmlHelper.LoadXml(cs2XmlEditor1.Text);
                    cs2XmlEditor1.Updated = false;
                }
                catch
                {
                    oXmlHelper.XmlDocument = MemoryXmlDocument;
                }
            }
            if (oXmlHelper.XmlDocument != null)
                if (oSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    oXmlHelper.XmlDocument.Save(oSaveFileDialog.FileName);
                    PostMessage("Item saved", true);
                }
            oSaveFileDialog.Dispose();
        }
        private void SaveLinqToXml()
        {
            SaveFileDialog oSaveFileDialog = new SaveFileDialog();
            oSaveFileDialog.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (!string.IsNullOrEmpty(cs2LinqToXmlEditor1.Text))
                if (oSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    cs2LinqToXmlEditor1.SaveFile(oSaveFileDialog.FileName, RichTextBoxStreamType.TextTextOleObjs);
                    PostMessage("Item saved", true);
                }
            oSaveFileDialog.Dispose();
        }
        public void ContextMenuTreeViewManager(
          bool extract,
          bool generateClassAndVariables,
          bool document,
          bool addDocument,
          bool element,
          bool addelement,
          bool insertBeforeelement,
          bool insertAfterelement,
          bool updateelement,
          bool removeelement,
          bool attribute,
          bool addattribute,
          bool insertBeforeattribute,
          bool insertAfterattribute,
          bool updateattribute,
          bool removeattribute,
          bool comment,
          bool addComment,
          bool insertBeforeComment,
          bool insertAfterComment,
          bool updateComment,
          bool removeComment,
          bool canCut,
          bool canCopy,
          bool canPaste,
          bool canRemove
      )
        {
            // Declaration
            extractFromTreeToolStripMenuItem.Enabled = extract;
            generateClassAndVarOfTreeToolStripMenuItem.Enabled = generateClassAndVariables;
            generateDataAccessWithVarsToolStripMenuItem.Enabled = generateClassAndVariables;
            postDataInDatagridviewToolStripMenuItem.Enabled = generateClassAndVariables;
            withObjectToolStripMenuItem.Enabled = generateClassAndVariables;
            withCreateMethodToolStripMenuItem.Enabled = generateClassAndVariables;
            documentToolStripMenuItem.Enabled = document;
            addCommentOfTreeToolstripMenuItem.Enabled = addDocument;
            // element
            elementToolStripMenuItem.Enabled = element;
            addElementOfTreeToolStripMenuItem.Enabled = addelement;
            insertBeforeElementOfTreeToolStripMenuItem.Enabled = insertBeforeelement;
            insertAfterElementOfTreeToolStripMenuItem.Enabled = insertAfterelement;
            updateElementOfTreeToolStripMenuItem.Enabled = updateelement;
            removeElementOfTreeToolStripMenuItem.Enabled = removeelement;
            // attribut
            attributeToolStripMenuItem.Enabled = attribute;
            AddAttributeOfTreeToolstripMenuItem.Enabled = addattribute;
            insertBeforeAttributeOfTreeToolstripMenuItem.Enabled = insertBeforeattribute;
            insertAfterAttributeOfTreeToolstripMenuItem.Enabled = insertAfterattribute;
            updateAttributeOfTreeToolstripMenuItem.Enabled = updateattribute;
            removeAttributeOfTreeToolstripMenuItem.Enabled = removeattribute;
            // comment
            commentToolStripMenuItem.Enabled = comment;
            addCommentOfTreeToolstripMenuItem.Enabled = addComment;
            insertAfterCommentOfTreeToolstripMenuItem.Enabled = insertAfterComment;
            insertBeforeCommentOfTreeToolstripMenuItem.Enabled = insertBeforeComment;
            updateCommentOfTreeToolstripMenuItem.Enabled = updateComment;
            removeCommentOfTreeToolstripMenuItem.Enabled = removeComment;
            //
            cutOfTreeToolStripMenuItem.Enabled = canCut;
            copyOfTreeToolStripMenuItem.Enabled = canCopy;
            pasteOfTreeToolStripMenuItem.Enabled = canPaste;
            removeOfTreeToolStripMenuItem.Enabled = canRemove;
        }

        #endregion utilities

        #region business

        private void GenerateBusinessObjects()
        {
            if (oXmlHelper.XmlDocument != null && cs2XmlTreeView1.SelectedNode != null)
            {
                if (cs2XmlTreeView1.SelectedNode is XmlElementTreeNode)
                {
                    FolderBrowserDialog oFolderBrowserDialog = new FolderBrowserDialog();
                    oFolderBrowserDialog.ShowNewFolderButton = true;
                    if (oFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        List<Cs2GenLinqToXmlLib.GeneratedClass> oGenerateClasses = Cs2GenLinqToXmlLib.XmlToCSharp.GetBusinessObjectsClasses(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath), Options.NamespaceForCSharpFiles);
                        Cs2GenLinqToXmlLib.IOManager.SaveGeneratedClasses(oGenerateClasses, oFolderBrowserDialog.SelectedPath, Application.StartupPath, Options.NamespaceForCSharpFiles);
                        PostMessage("Ready", true);
                        System.Diagnostics.Process.Start(oFolderBrowserDialog.SelectedPath);
                    }
                }
            }
        }
        private void CreateDirectElement()
        {
            cs2LinqToXmlEditor1.CreateDirectElement(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath));
            PostMessage("Ready", true);
        }
        private void CreateCreateMethod()
        {
            cs2LinqToXmlEditor1.CreateCreateMethod(oXmlHelper.GetElement(cs2XmlTreeView1.CurrentXPath));
            PostMessage("Ready",true);
        }

        #endregion business

        #region options

        private void ManageOptions()
        {
            FOptions oFOptions = new FOptions();
            oFOptions.ShowDialog();
            if (oFOptions.Reload && oXmlHelper.XmlDocument != null)
            {
                LoadOptions();
                if (!string.IsNullOrEmpty(cs2LinqToXmlEditor1.Text))
                    cs2LinqToXmlEditor1.ConvertToLinqToXml(oXmlHelper.XmlDocument);

                if (!cs2XmlEditor1.IsXmlWellFormed)
                    cs2XmlEditor1.RefreshForecolor();
            }
            oFOptions.Dispose();
        }

        #endregion

        private void xPathVisualizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenXPathVisualizer();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenXPathVisualizer()
        {
            if (oXmlHelper.XmlDocument != null && !string.IsNullOrEmpty(oXmlHelper.XmlDocument.InnerText))
            {
                if (!cs2TabControl1.TabPages.ContainsKey("tabPage4"))
                {
                    XPathVisualizer oXPathVisualizer = new XPathVisualizer();
                    oXPathVisualizer.Name = "xPathVisualizer1";
                    oXPathVisualizer.Dock = DockStyle.Fill;
                    oXPathVisualizer.LoadDocument(oXmlHelper.XmlDocument);
                    cs2TabControl1.TabPages.Add(cs2TabControl1.CreateTabPage("tabPage4", "XPath visualizer", 4, oXPathVisualizer));
                }
                else
                {
                    TabPage oTabPage = cs2TabControl1.TabPages["tabPage4"];
                    XPathVisualizer oXPathVisualizer = oTabPage.Controls["xPathVisualizer1"] as XPathVisualizer;
                    oXPathVisualizer.LoadDocument(oXmlHelper.XmlDocument);
                }
                cs2TabControl1.SelectedTab = cs2TabControl1.TabPages["tabPage4"];
            }
        }

    }
}