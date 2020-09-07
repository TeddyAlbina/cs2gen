using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class XPathVisualizer : UserControl
    {
        public XPathVisualizer()
        {
            InitializeComponent();
        }

        private System.Xml.XmlDocument _XmlDocument;

        public System.Xml.XmlDocument XmlDocument
        {
            get { return _XmlDocument; }
            set { _XmlDocument = value; }
        }

        private List<string> AllXPaths;

        // Events
        private void XPathVisualizer_Load(object sender, EventArgs e)
        {
            
        }
     
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (CanCompileXpathExpression(txtXPath.Text))
                {
                    txtXPath.ForeColor = System.Drawing.SystemColors.WindowText;
                    GetNodesOfXpath();
                }
                else
                    txtXPath.ForeColor = Options.ErrorColor;
            }
            catch
            {
                txtXPath.ForeColor = Options.ErrorColor;
            }
        }
       
        private void txtXPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAuto.Checked)
                {
                    if (CanCompileXpathExpression(txtXPath.Text))
                    {
                        txtXPath.ForeColor = System.Drawing.SystemColors.WindowText;
                        GetNodesOfXpath();
                    }
                    else
                        txtXPath.ForeColor = Options.ErrorColor;
                }
            }
            catch
            {
                txtXPath.ForeColor = Options.ErrorColor;
            }

                
            }
      
        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAuto.Checked)
                {
                    if (CanCompileXpathExpression(txtXPath.Text))
                    {
                        txtXPath.ForeColor = System.Drawing.SystemColors.WindowText;
                        GetNodesOfXpath();
                    }
                    else
                        txtXPath.ForeColor = Options.ErrorColor;
                }
            }
            catch
            {
                txtXPath.ForeColor = Options.ErrorColor;
            }

        }

        private void tvXPath_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                AutoCompleteXpathExpression();
            }
            catch
            { }
        }

        // Methods
        #region load document

        public void LoadDocument(System.Xml.XmlDocument oXmlDocument)
        {
            XmlDocument = (System.Xml.XmlDocument) oXmlDocument.Clone();
            chkAuto.Checked = true; 
            txtXPath.Text = string.Empty;
            tvXPath.Nodes.Clear();
            txtXPath.AutoCompleteCustomSource.Clear();
            txtXPath.AutoCompleteCustomSource.AddRange(GetAllXPathsOfNode(CreateDocumentTreeNode(XmlDocument)));
        }
        public void ClearAll()
        {
            XmlDocument = null;
            txtXPath.Text = string.Empty;
            tvXPath.Nodes.Clear();
            txtXPath.AutoCompleteCustomSource.Clear();
        }

        #endregion load document

        #region auto complete source

        private string[] GetAllXPathsOfNode(TreeNode oTreeNode)
        {
            AllXPaths = new List<string>();
            foreach (TreeNode t in oTreeNode.Nodes)
                GetXPathsOfTreeNode(t, string.Empty);

            return AllXPaths.ToArray();
        }

        private string GetXPathsOfTreeNode(System.Windows.Forms.TreeNode oTreeNode, string path)
        {
            string result = string.Empty;

            if (oTreeNode is XmlElementTreeNode)
                result += path + "/" + oTreeNode.Text;

            if (oTreeNode is XmlAttributeTreeNode)
                result += path + "/@" + oTreeNode.Text;

            if (oTreeNode is XmlTextTreeNode)
                result += path + "/text()";

            if (!AllXPaths.Contains(result))
                AllXPaths.Add(result);

            foreach (System.Windows.Forms.TreeNode t in oTreeNode.Nodes)
            {
                if (t is XmlElementTreeNode || t is XmlAttributeTreeNode || (t is XmlTextTreeNode && t.Parent is XmlElementTreeNode))
                    GetXPathsOfTreeNode(t, result);
            }

            return result;
        }

        #endregion auto complete source

        #region compile xpath

        private bool CanCompileXpathExpression(string xpath)
        {
            bool result = false;
            try
            {
                System.Xml.XPath.XPathExpression oXPathExpression = System.Xml.XPath.XPathExpression.Compile(txtXPath.Text);
                result = true;
            }
            catch 
            {
                result = false;
            }
            return result;
        }

        #endregion compile xpath

        #region document treenode

        public TreeNode CreateDocumentTreeNode(System.Xml.XmlDocument oXmlDocument)
        {
            TreeNode oTreeNode = new TreeNode();
            if (tvXPath.Nodes.Count == 0)
            {
                oTreeNode.Nodes.AddRange(ConvertXmlToTreeNodes(oXmlDocument));
            }
            return oTreeNode;
        }
       
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
            return oTreenodes.ToArray();
        }
       
        #endregion document treenode

        #region evaluate xpath

        private void GetNodesOfXpath()
        {
            System.Xml.XmlNodeList oXmlNodes = XmlDocument.SelectNodes(txtXPath.Text);
            ConvertXmlToTreeNodes(oXmlNodes);
            lblCount.Text = tvXPath.Nodes.Count.ToString() + " node(s)";
        }
        public void ConvertXmlToTreeNodes(System.Xml.XmlNodeList oXmlNodes)
        {
            tvXPath.Nodes.Clear();
            foreach (System.Xml.XmlNode x in oXmlNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.Element)
                    tvXPath.Nodes.Add(CreateElement(x));
                if (x.NodeType == System.Xml.XmlNodeType.Attribute)
                    tvXPath.Nodes.Add(CreateAttribute((System.Xml.XmlAttribute)x));
                if (x.NodeType == System.Xml.XmlNodeType.Text)
                    tvXPath.Nodes.Add(new XmlTextTreeNode(x.InnerText, 2, 2));
            }
        }

        public XmlElementTreeNode CreateElement(System.Xml.XmlNode oXmlNode)
        {
            XmlElementTreeNode oXmlElementTreeNode = new XmlElementTreeNode();
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
            return oXmlElementTreeNode;
        }

        public XmlAttributeTreeNode CreateAttribute(System.Xml.XmlAttribute oXmlAttribute)
        {
            XmlAttributeTreeNode oXmlAttributeTreeNode = new XmlAttributeTreeNode(oXmlAttribute.Name, oXmlAttribute.Name, oXmlAttribute.Value, 1, 1);
            oXmlAttributeTreeNode.Nodes.Add(new XmlTextTreeNode(oXmlAttribute.Value, 2, 2));
            return oXmlAttributeTreeNode;
        }

        #endregion

        #region auto completion 

        private void AutoCompleteXpathExpression()
        {
            if (tvXPath.SelectedNode is XmlElementTreeNode)
                txtXPath.SelectedText = "/" + tvXPath.SelectedNode.Text;
            if (tvXPath.SelectedNode is XmlAttributeTreeNode)
                txtXPath.SelectedText = "/@" + tvXPath.SelectedNode.Text;
            if (tvXPath.SelectedNode is XmlTextTreeNode && tvXPath.SelectedNode.Parent is XmlElementTreeNode)
                txtXPath.SelectedText = "/text()";
        }

        #endregion

    }
}
