using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class Cs2XmlTreeView : System.Windows.Forms.TreeView
    {

        public delegate void TreeViewAfterSelect(string xpath,TreeNode oTreeNode);
        public TreeViewAfterSelect TreeViewAfterSelected;

        private XPathUtilities _XPathUtilities;

        public XPathUtilities XPathUtilities
        {
            get { return _XPathUtilities; }
            set { _XPathUtilities = value; }
        }

        private string _CurrentXPath;

        public string CurrentXPath
        {
            get { return _CurrentXPath; }
            set { _CurrentXPath = value; }
        }

        private string _MemoryFullPath;

        public string MemoryFullPath
        {
            get { return _MemoryFullPath; }
            set { _MemoryFullPath = value; }
        }

        private bool _Updated;

        public bool Updated
        {
            get { return _Updated; }
            set { _Updated = value; }
        }

        public Cs2XmlTreeView()
        {
            InitializeComponent();
            XPathUtilities = new XPathUtilities();
        }

        public Cs2XmlTreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            XPathUtilities = new XPathUtilities();
        }
        
        // Events
        private void Cs2XmlTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CurrentXPath = XPathUtilities.GetSelectedNodeXpath(this, this.SelectedNode);
            MemoryFullPath = this.SelectedNode.FullPath;
            if (TreeViewAfterSelected != null)
                TreeViewAfterSelected(CurrentXPath,this.SelectedNode);

        }

        // Methods

        public void Load(System.Xml.XmlDocument oXmlDocument)
        {
            this.Nodes.Clear();
            this.Nodes.AddRange(ConvertXmlToTreeNodes(oXmlDocument));
            Updated = false;
        }

        public XmlElementTreeNode CreateElement(System.Xml.XmlNode oXmlNode)
        {
            XmlElementTreeNode oXmlElementTreeNode = new XmlElementTreeNode();
            try
            {
                switch (oXmlNode.NodeType)
                {
                    case System.Xml.XmlNodeType.Document:
                        break;
                    case System.Xml.XmlNodeType.Element:
                        oXmlElementTreeNode.Name = oXmlNode.Name;
                        oXmlElementTreeNode.Text = oXmlNode.Name;

                        if (oXmlNode.Attributes != null)
                        {
                            if (oXmlNode.Attributes.Count > 0)
                            {
                                foreach (System.Xml.XmlAttribute oXmlAttribute in oXmlNode.Attributes)
                                {
                                    XmlAttributeTreeNode oXmlAttributeTreeNode = new XmlAttributeTreeNode(oXmlAttribute.Name, oXmlAttribute.Name, oXmlAttribute.Name, 1, 1);
                                    oXmlAttributeTreeNode.Nodes.Add(
                                        new XmlTextTreeNode(oXmlAttribute.Value, 2, 2));
                                    oXmlElementTreeNode.Nodes.Add(oXmlAttributeTreeNode);
                                }
                            }
                        }


                        if (oXmlNode.ChildNodes.Count == 1 && oXmlNode.FirstChild.NodeType == System.Xml.XmlNodeType.Text)
                        {
                            oXmlElementTreeNode.ForeColor = System.Drawing.Color.DarkKhaki;
                            oXmlElementTreeNode.Nodes.Add(new XmlTextTreeNode(oXmlNode.InnerText, 2, 2));
                        }
                        else if (oXmlNode.ChildNodes.Count == 0)
                            oXmlElementTreeNode.ForeColor = System.Drawing.Color.DarkKhaki;



                        break;
                    case System.Xml.XmlNodeType.Text:
                        // 
                        break;

                }

                foreach (System.Xml.XmlNode ChildNode in oXmlNode.ChildNodes)
                {
                    if (ChildNode.NodeType == System.Xml.XmlNodeType.Comment)
                        oXmlElementTreeNode.Nodes.Add(new XmlCommentTreeNode(ChildNode.Value, 4, 4));

                    if (ChildNode.NodeType != System.Xml.XmlNodeType.Text && ChildNode.NodeType != System.Xml.XmlNodeType.Comment)
                    {
                        XmlElementTreeNode El = CreateElement(ChildNode);
                        oXmlElementTreeNode.Nodes.Add(El);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oXmlElementTreeNode;
        }

        #region Declaration

        public System.Windows.Forms.TreeNode[] ConvertXmlToTreeNodes(System.Xml.XmlNode oXmlNode)
        {
            List<System.Windows.Forms.TreeNode> oTreenodes = new List<System.Windows.Forms.TreeNode>();

            foreach (System.Xml.XmlNode x in oXmlNode.ChildNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.XmlDeclaration)
                    oTreenodes.Add(new XmlDeclarationTreeNode(x.Name, x.Name + " " + x.InnerText, 5, 5));
                if (x.NodeType == System.Xml.XmlNodeType.ProcessingInstruction)
                    oTreenodes.Add(new XmlProcessingInstructionTreeNode(x.Name, x.Name + " " + x.InnerText, 5, 5));
                if (x.NodeType == System.Xml.XmlNodeType.Comment)
                    oTreenodes.Add(new XmlCommentTreeNode(x.Value, 4, 4));
                if (x.NodeType == System.Xml.XmlNodeType.Element)
                    oTreenodes.Add(CreateElement(x));
            }
            Updated = true;
            return oTreenodes.ToArray();
        }
        public void CreateDocument(System.Xml.XmlDocument oXmlDocument)
        {
            if (this.Nodes.Count == 0)
            {
                this.Nodes.AddRange(ConvertXmlToTreeNodes(oXmlDocument));
                Updated = true;
            }
        }
        public TreeNode CreateDocumentForXpath(System.Xml.XmlDocument oXmlDocument)
        {
            TreeNode oTreeNode = new TreeNode();
            if (this.Nodes.Count == 0)
            {
                oTreeNode.Nodes.AddRange(ConvertXmlToTreeNodes(oXmlDocument));
                Updated = true;
            }
            return oTreeNode;
        }

        #endregion

        #region Element

        public void AddRoot(TreeNode oTreeNode)
        {
            this.Nodes.Add(oTreeNode);
            this.SelectedNode.ForeColor = System.Drawing.Color.Black;
            this.SelectedNode = oTreeNode;
            Updated = true;
        }
        public void AddElement(TreeNode oTreeNode)
        {
            this.SelectedNode.Nodes.Add(oTreeNode);
            this.SelectedNode.ForeColor = System.Drawing.Color.Black;
            this.SelectedNode = oTreeNode;
            Updated = true;
        }
        public void InsertElementBeforeElement(TreeNode oTreeNode)
        {
            this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index, oTreeNode);
            this.SelectedNode = oTreeNode;
            Updated = true;
        }
        public void InsertElementAfterElement(TreeNode oTreeNode)
        {
            this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index + 1, oTreeNode);
            this.SelectedNode = oTreeNode;
            Updated = true;
        }

        public void UpdateElement(TreeNode NewTreeNode)
        {
            TreeNode select = this.SelectedNode;
            if (this.SelectedNode.Parent == null)
                this.Nodes.Insert(this.SelectedNode.Index, NewTreeNode);
            else
                this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index, NewTreeNode);
            this.Nodes.Remove(select);
            this.SelectedNode = NewTreeNode;
            Updated = true;
        }
      
        public void RemoveElement()
        {
            TreeNode oTreeNode = new TreeNode();

            if (this.SelectedNode.Parent != null)
                oTreeNode = this.SelectedNode.Parent;

            this.SelectedNode.Remove();
            if (oTreeNode != null)
                if ((oTreeNode.Nodes.Count == 1 && oTreeNode.FirstNode is XmlTextTreeNode) || oTreeNode.Nodes.Count == 0)
                    oTreeNode.ForeColor = System.Drawing.Color.DarkKhaki;
            Updated = true;
        }

        #endregion

        #region Attribute

        public TreeNode GetTreeNodeBaseForAttribute()
        {
            TreeNode oTreeNodeBase = null;
            int nPosition = 0;
            foreach (TreeNode oTreeNode in this.SelectedNode.Nodes)
            {
                if (oTreeNode is XmlElementTreeNode || oTreeNode is XmlCommentTreeNode || oTreeNode is XmlTextTreeNode)
                    if (nPosition == 0)
                    {
                        oTreeNodeBase = oTreeNode;
                        nPosition += 1;
                    }
            }
            return oTreeNodeBase;
        }
        public XmlAttributeTreeNode CreateAttribute(System.Xml.XmlAttribute oXmlAttribute)
        {
            XmlAttributeTreeNode oXmlAttributeTreeNode = new XmlAttributeTreeNode(oXmlAttribute.Name, oXmlAttribute.Name, oXmlAttribute.Value, 1, 1);
            oXmlAttributeTreeNode.Nodes.Add(new XmlTextTreeNode(oXmlAttribute.Value, 2, 2));
            return oXmlAttributeTreeNode;
        }

        public void AddAttribute(XmlAttributeTreeNode oNewTreeNode)
        {
            TreeNode oTreeNodeBase = GetTreeNodeBaseForAttribute();
            if (oTreeNodeBase != null)
                this.SelectedNode.Nodes.Insert(oTreeNodeBase.Index, oNewTreeNode);
            else
                this.SelectedNode.Nodes.Add(oNewTreeNode);

            this.SelectedNode = oNewTreeNode;
            Updated = true;
        }

        public void InsertAttributeBefore(XmlAttributeTreeNode oNewTreeNode)
        {
            if (this.SelectedNode is XmlAttributeTreeNode || this.SelectedNode is XmlTextTreeNode)
            {
                if (this.SelectedNode is XmlAttributeTreeNode)
                    this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index, oNewTreeNode);
                else if (this.SelectedNode is XmlTextTreeNode)
                    this.SelectedNode.Parent.Parent.Nodes.Insert(this.SelectedNode.Index, oNewTreeNode);
                this.SelectedNode = oNewTreeNode;
                Updated = true;
            }
        }
        public void InsertAttributeAfter(XmlAttributeTreeNode oNewTreeNode)
        {
            if (this.SelectedNode is XmlAttributeTreeNode || this.SelectedNode is XmlTextTreeNode)
            {
                if (this.SelectedNode is XmlAttributeTreeNode)
                    this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index + 1, oNewTreeNode);
                else if (this.SelectedNode is XmlTextTreeNode)
                    this.SelectedNode.Parent.Parent.Nodes.Insert(this.SelectedNode.Index + 1, oNewTreeNode);
                this.SelectedNode = oNewTreeNode;
                Updated = true;
            }
        }
        public void UpdateAttribute(XmlAttributeTreeNode oNewTreeNode)
        {
            if (this.SelectedNode is XmlAttributeTreeNode || this.SelectedNode is XmlTextTreeNode)
            {
                if (this.SelectedNode is XmlAttributeTreeNode)
                {
                    TreeNode select = this.SelectedNode;
                    this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index, oNewTreeNode);
                    this.Nodes.Remove(select);
                    this.SelectedNode = oNewTreeNode;
                    Updated = true;
                }
                else if (this.SelectedNode is XmlTextTreeNode)
                {
                    TreeNode select = this.SelectedNode.Parent;
                    this.SelectedNode.Parent.Parent.Nodes.Insert(this.SelectedNode.Parent.Index, oNewTreeNode);
                    this.Nodes.Remove(select);
                    this.SelectedNode = oNewTreeNode;
                    Updated = true;
                }

            }
        }
        public void RemoveAttribute()
        {
            if (this.SelectedNode is XmlAttributeTreeNode || this.SelectedNode is XmlTextTreeNode)
            {
                if (this.SelectedNode is XmlAttributeTreeNode)
                    this.SelectedNode.Nodes.Remove(this.SelectedNode);
                else if (this.SelectedNode is XmlTextTreeNode)
                    this.SelectedNode.Nodes.Remove(this.SelectedNode.Parent);
                Updated = true;
            }
        }

        #endregion

        #region Comment

        public bool HasXmlElementTreeNode()
        {
            bool HasElement = false;
            foreach (System.Windows.Forms.TreeNode t in this.Nodes)
            {
                if (t is XmlElementTreeNode)
                    HasElement = true;
            }
            return HasElement;
        }
        public System.Windows.Forms.TreeNode GetXmlElementTreeNode()
        {
            System.Windows.Forms.TreeNode oTreeNodeBase = null;
            foreach (System.Windows.Forms.TreeNode oTreeNode in this.Nodes)
            {
                if (oTreeNode is XmlElementTreeNode)
                    oTreeNodeBase = oTreeNode;
            }
            return oTreeNodeBase;
        }
        public XmlCommentTreeNode CreateComment(string Value)
        {
            XmlCommentTreeNode oXmlCommentTreeNode = new XmlCommentTreeNode(Value, 4, 4);
            return oXmlCommentTreeNode;
        }
        
        public void AddComment(XmlCommentTreeNode oNewXmlCommentTreeNode)
        {
            int nI = 0;
            TreeNode tselected = null;
            foreach (TreeNode t in this.SelectedNode.Nodes)
            {
                if (t is XmlElementTreeNode)
                {
                    if (nI == 0)
                    {
                        tselected = t;
                        nI += 1;
                    }
                }
            }
            if (tselected != null)
            {
                this.SelectedNode.Nodes.Insert(tselected.Index, oNewXmlCommentTreeNode);
                this.SelectedNode = oNewXmlCommentTreeNode;
            }
            else
            {
                this.SelectedNode.Nodes.Add(oNewXmlCommentTreeNode);
                this.SelectedNode = oNewXmlCommentTreeNode;
            }
            Updated = true;
        }

        public void InsertCommentBefore(XmlCommentTreeNode oNewXmlCommentTreeNode)
        {
            if (this.SelectedNode is XmlCommentTreeNode)
            {
                if (this.SelectedNode.Parent == null)
                    this.Nodes.Insert(this.SelectedNode.Index, oNewXmlCommentTreeNode);
                else
                    this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index, oNewXmlCommentTreeNode);
                this.SelectedNode = oNewXmlCommentTreeNode;
            }
            if (this.SelectedNode is XmlElementTreeNode)
            {
                if (this.SelectedNode.Level == 0)
                {
                    // insertbefore element
                    if (HasXmlElementTreeNode())
                    {
                        TreeNode oTreeNodeBase = GetXmlElementTreeNode();
                        if (oTreeNodeBase != null)
                            this.Nodes.Insert(oTreeNodeBase.Index, oNewXmlCommentTreeNode);
                        this.SelectedNode = oNewXmlCommentTreeNode;
                    }
                    else
                    {
                        this.Nodes.Add(oNewXmlCommentTreeNode);
                        this.SelectedNode = oNewXmlCommentTreeNode;
                    }
                }
                else
                {
                    this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index, oNewXmlCommentTreeNode);
                    this.SelectedNode = oNewXmlCommentTreeNode;
                }
            }
            Updated = true;
        }

        public void InsertCommentAfter(XmlCommentTreeNode oNewXmlCommentTreeNode)
        {
            if (this.SelectedNode is XmlCommentTreeNode)
            {
                if (this.SelectedNode.Parent == null)
                    this.Nodes.Insert(this.SelectedNode.Index + 1, oNewXmlCommentTreeNode);
                else
                    this.SelectedNode.Parent.Nodes.Insert(this.SelectedNode.Index + 1, oNewXmlCommentTreeNode);
                this.SelectedNode = oNewXmlCommentTreeNode;
            }
            if (this.SelectedNode is XmlElementTreeNode || this.SelectedNode is XmlDeclarationTreeNode)
            {
                if (this.SelectedNode.Level == 0)
                {
                    // insertbefore element
                    if (HasXmlElementTreeNode())
                    {
                        TreeNode oTreeNodeBase = GetXmlElementTreeNode();
                        if (oTreeNodeBase != null)
                        {
                            this.Nodes.Insert(oTreeNodeBase.Index, oNewXmlCommentTreeNode);
                            this.SelectedNode = oNewXmlCommentTreeNode;

                        }
                    }
                    else
                    {
                        this.Nodes.Add(oNewXmlCommentTreeNode);
                        this.SelectedNode = oNewXmlCommentTreeNode;
                    }

                }
                else
                {
                    TreeNode oTreeNodeBase = GetXmlElementTreeNode();
                    if (oTreeNodeBase != null)
                        this.SelectedNode.Nodes.Insert(oTreeNodeBase.Index + 1, oNewXmlCommentTreeNode);
                    else
                        this.SelectedNode.Nodes.Insert(this.SelectedNode.FirstNode.Index, oNewXmlCommentTreeNode);
                    this.SelectedNode = oNewXmlCommentTreeNode;
                }
            }
            Updated = true;
        }

        public void UpdateComment(string Text)
        {
            this.SelectedNode.Text = Text;
            Updated = true;
        }
        public void RemoveComment()
        {
            this.SelectedNode.Remove();
            Updated = true;
        }

        #endregion

        public void GetSelectedNodeByFullPath()
        {
            System.Windows.Forms.TreeNode oTreeNode = new System.Windows.Forms.TreeNode();
            foreach (System.Windows.Forms.TreeNode t in this.Nodes)
            {
                if (t is XmlElementTreeNode)
                    oTreeNode = t;
            }
            GetSelectedNodeByFullPath(oTreeNode);
        }
        private void GetSelectedNodeByFullPath(System.Windows.Forms.TreeNode oTreeNode)
        {
            if (oTreeNode.FullPath == MemoryFullPath)
            {
                this.SelectedNode = oTreeNode;
            }
            foreach (System.Windows.Forms.TreeNode t in oTreeNode.Nodes)
            {
                GetSelectedNodeByFullPath(t);
            }
        }

        

    }
    /// <summary>
    /// TreeNode Pour XmlDocument
    /// </summary>
    public class XmlDocumentTreeNode : System.Windows.Forms.TreeNode
    {
        public XmlDocumentTreeNode()
        {
        }
    }
    /// <summary>
    /// Treenode pour XmlDeclaration
    /// </summary>
    public class XmlDeclarationTreeNode : System.Windows.Forms.TreeNode
    {

        public XmlDeclarationTreeNode()
        {
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Text = string.Empty;
            this.ImageIndex = 5;
            this.SelectedImageIndex = 5;
        }
        public XmlDeclarationTreeNode(string Name, string Text, int ImageIndex, int SelectedImageIndex)
        {
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = Name;
            this.Text = Text;
            this.ImageIndex = ImageIndex;
            this.SelectedImageIndex = SelectedImageIndex;

        }
    }
    /// <summary>
    /// Treenode pour XmlProcessingInstruction
    /// </summary>
    public class XmlProcessingInstructionTreeNode : System.Windows.Forms.TreeNode
    {

        public XmlProcessingInstructionTreeNode()
        {
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Text = string.Empty;
            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;
        }
        public XmlProcessingInstructionTreeNode(string Name, string Text, int ImageIndex, int SelectedImageIndex)
        {
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = Name;
            this.Text = Text;
            this.ImageIndex = ImageIndex;
            this.SelectedImageIndex = SelectedImageIndex;

        }
    }
    /// <summary>
    /// Treenode pour XmlComment
    /// </summary>
    public class XmlCommentTreeNode : System.Windows.Forms.TreeNode
    {
        public XmlCommentTreeNode()
        {
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Text = string.Empty;
            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;
        }
        public XmlCommentTreeNode(string Text, int ImageIndex, int SelectedImageIndex)
        {
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Text = Text;
            this.ImageIndex = ImageIndex;
            this.SelectedImageIndex = SelectedImageIndex;
        }
    }
    /// <summary>
    /// Treenode pour XmlElement
    /// </summary>
    public class XmlElementTreeNode : System.Windows.Forms.TreeNode
    {
        private string _Value;

        public XmlElementTreeNode()
        {
            this.Name = string.Empty;
            this.Text = string.Empty;
            this._Value = string.Empty;
            this.ImageIndex = 0;
            this.SelectedImageIndex = 0;
        }
        public XmlElementTreeNode(string Name, string Text, string Value, int ImageIndex, int SelectedImageIndex)
        {
            this.Name = Name;
            this.Text = Text;
            this._Value = Value;
            this.ImageIndex = ImageIndex;
            this.SelectedImageIndex = SelectedImageIndex;

        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
    /// <summary>
    /// Treenode pour XmlAttribute
    /// </summary>
    public class XmlAttributeTreeNode : System.Windows.Forms.TreeNode
    {
        private string _Value;

        public XmlAttributeTreeNode()
        {
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.Name = string.Empty;
            this.Text = string.Empty;
            this._Value = string.Empty;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
        }
        public XmlAttributeTreeNode(string Name, string Text, string Value, int ImageIndex, int SelectedImageIndex)
        {
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.Name = Name;
            this._Value = Value;
            this.Text = Text;
            this._Value = string.Empty;
            this.ImageIndex = ImageIndex;
            this.SelectedImageIndex = SelectedImageIndex;

        }
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
    /// <summary>
    /// Treenode pour XmlText
    /// </summary>
    public class XmlTextTreeNode : System.Windows.Forms.TreeNode
    {
        public XmlTextTreeNode()
        {
            this.ForeColor = System.Drawing.Color.Gray;
            this.Text = string.Empty;
            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;
        }
        public XmlTextTreeNode(string Text, int ImageIndex, int SelectedImageIndex)
        {
            this.ForeColor = System.Drawing.Color.Gray;
            this.Text = Text;
            this.ImageIndex = ImageIndex;
            this.SelectedImageIndex = SelectedImageIndex;
        }
    }
    public class XPathUtilities
    {

        private List<string> XPathPreparelist;

        public XPathUtilities()
        {
            XPathPreparelist = new List<string>();
        }

        /// <summary>
        /// construit l'expression xpath correpsondant au TreeNode
        /// </summary>
        /// <param name="oTreeNode"></param>
        /// <returns></returns>
        public string GetSelectedNodeXpath(System.Windows.Forms.TreeView oTreeView, System.Windows.Forms.TreeNode oTreeNode)
        {
            string sResult = string.Empty;
            XPathPreparelist.Clear();

            if (oTreeNode is XmlDeclarationTreeNode)
            {
                sResult = "/";
            }
            if (oTreeNode is XmlProcessingInstructionTreeNode)
            {
                sResult = "/child::node()[" + oTreeNode.Index.ToString() + "]";
            }
            if (oTreeNode is XmlElementTreeNode || oTreeNode is XmlCommentTreeNode)
            {
                this.IterateTreeNode(oTreeView, oTreeNode);
                XPathPreparelist.Reverse();
                foreach (string s in XPathPreparelist)
                {
                    sResult += s;
                }
            }
            if (oTreeNode is XmlTextTreeNode)
            {
                if (oTreeNode.Parent is XmlElementTreeNode)
                {
                    this.IterateTreeNode(oTreeView, oTreeNode);
                    XPathPreparelist.Reverse();
                    foreach (string s in XPathPreparelist)
                    {
                        sResult += s;
                    }
                }
                if (oTreeNode.Parent is XmlAttributeTreeNode)
                {
                    XPathPreparelist.Add("/@" + oTreeNode.Parent.Text);
                    this.IterateTreeNode(oTreeView, oTreeNode.Parent.Parent);
                    XPathPreparelist.Reverse();
                    foreach (string s in XPathPreparelist)
                    {
                        sResult += s;
                    }
                }
            }
            if (oTreeNode is XmlAttributeTreeNode)
            {
                XPathPreparelist.Add("/@" + oTreeNode.Text);
                this.IterateTreeNode(oTreeView, oTreeNode.Parent);
                XPathPreparelist.Reverse();
                foreach (string s in XPathPreparelist)
                {
                    sResult += s;
                }
            }

            return sResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oTreeNode"></param>
        private void IterateTreeNode(System.Windows.Forms.TreeView oTreeView, System.Windows.Forms.TreeNode oTreeNode)
        {
            int nLess = 0;

            if (oTreeNode != null)
            {
                if (oTreeNode.Parent != null)
                {
                    foreach (System.Windows.Forms.TreeNode t in oTreeNode.Parent.Nodes)
                    {
                        if (t is XmlElementTreeNode || t is XmlTextTreeNode || t is XmlCommentTreeNode)
                        {
                        }
                        else
                            nLess += 1;
                    }
                }
                else
                {
                    foreach (System.Windows.Forms.TreeNode t in oTreeView.Nodes)
                    {
                        if (t is XmlElementTreeNode || t is XmlProcessingInstructionTreeNode || t is XmlTextTreeNode || t is XmlCommentTreeNode)
                        {
                        }
                        else
                            nLess += 1;
                    }
                }

                int nIndex = (oTreeNode.Index + 1) - nLess;
                XPathPreparelist.Add("/child::node()[" + nIndex.ToString() + "]");

                if (oTreeNode.Parent != null)
                {
                    System.Windows.Forms.TreeNode Parent = oTreeNode.Parent;
                    IterateTreeNode(oTreeView, Parent);
                }
            }
        }
    }
}
