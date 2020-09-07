using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Cs2GenLinqToXml.Gui
{
    public partial class Cs2LinqToXmlEditor : System.Windows.Forms.RichTextBox
    {

        private string _LinqNamespace;

        public string LinqNamespace
        {
            get { return _LinqNamespace; }
            set { _LinqNamespace = value; }
        }
      
        private static Dictionary<string, string> _Namespaces = new Dictionary<string, string>();

        public static Dictionary<string, string> Namespaces
        {
            get { return _Namespaces; }
            set { _Namespaces = value; }
        }

        private string currentNamespacePrefix;

        public Cs2LinqToXmlEditor()
        {
            InitializeComponent();
        }

        public Cs2LinqToXmlEditor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ConvertToLinqToXml(System.Xml.XmlDocument oXmlDocument)
        {
            this.Text = GetLinqToXml(oXmlDocument);
        }
        public void ConvertToLinqToXml(System.Xml.XmlNode oXmlNode)
        {
            this.Text = GetLinqToXml(oXmlNode);
        }

        /// <summary>
        /// convertit un XmlDocument en code Linq To Xml
        /// </summary>
        /// <param name="oXmlDocument"></param>
        /// <returns></returns>
        private string GetLinqToXml(System.Xml.XmlDocument oXmlDocument)
        {
            string result = string.Empty;
            //
            Namespaces.Clear();
            GetNamespaces(oXmlDocument);

            if (!Options.IncludeLinqCompletePathNamespace)
                LinqNamespace = string.Empty;
            else
                LinqNamespace = "System.Xml.Linq.";

            currentNamespacePrefix = string.Empty;

            int nCount = 1;
            foreach (string Key in Namespaces.Keys)
            {
                result += LinqNamespace + "XNamespace " + Namespaces[Key] + " = \"" + Key + "\";" + Environment.NewLine;
                nCount += 1;
            }

            foreach (System.Xml.XmlNode x in oXmlDocument.ChildNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.Comment)
                    result += LinqNamespace + "XComment oXComment = new " + LinqNamespace + "XComment(\"" + x.Value + "\");\r";
                if (x.NodeType == System.Xml.XmlNodeType.Element)
                {
                    result += LinqNamespace + "XElement oXElement = \r";
                    result += BuildElement(x, "\t\t\t");
                    result += "\r\t\t\t);\r";
                }
            }
            return result;
        }

        /// <summary>
        /// Convertit un XmlNode en Linq To Xml
        /// </summary>
        /// <param name="oXmlNode"></param>
        /// <returns></returns>
        private string GetLinqToXml(System.Xml.XmlNode oXmlNode)
        {
            string result = string.Empty;
            //
            string LinqToXmlGenerated = string.Empty;

            if (!Options.IncludeLinqCompletePathNamespace)
            {
                LinqNamespace = string.Empty;
            }
            else
            {
                LinqNamespace = "System.Xml.Linq.";
            }
            currentNamespacePrefix = string.Empty;

            switch (oXmlNode.NodeType)
            {
                case System.Xml.XmlNodeType.Document:
                    System.Xml.XmlDeclaration oXmlDeclaration = (System.Xml.XmlDeclaration)oXmlNode.FirstChild;
                    result += LinqNamespace + "XDocument oXDocument = new " + LinqNamespace + "XDocument(new " + LinqNamespace + "XDeclaration(\"" + oXmlDeclaration.Version + "\",\"" + oXmlDeclaration.Encoding + "\",\"" + oXmlDeclaration.Standalone + "\"));\r";
                    break;
                case System.Xml.XmlNodeType.ProcessingInstruction:
                    System.Xml.XmlProcessingInstruction oXmlProcessingInstruction = (System.Xml.XmlProcessingInstruction)oXmlNode;
                    result += LinqNamespace + "XProcessingInstruction oXProcessingInstruction = new " + LinqNamespace + "XProcessingInstruction(\"" + oXmlProcessingInstruction.Name + "\", \"" + oXmlProcessingInstruction.Value + "\");\r";
                    break;
                case System.Xml.XmlNodeType.Comment:
                    result += LinqNamespace + "XComment oXComment = new " + LinqNamespace + "XComment(\"" + oXmlNode.Value + "\");\r";
                    break;
                case System.Xml.XmlNodeType.Element:

                    int nCount = 1;
                    foreach (string Key in Namespaces.Keys)
                    {
                        result += LinqNamespace + "XNamespace " + Namespaces[Key] + " = \"" + Key + "\";" + Environment.NewLine;
                        nCount += 1;
                    }

                    result += LinqNamespace + "XElement oXElement = \r";
                    result += BuildElement(oXmlNode,"\t\t\t");
                    result += "\r\t\t\t);\r";

                    break;
                case System.Xml.XmlNodeType.Attribute:
                    result += LinqNamespace + "XAttribute oXAttribute = new " + LinqNamespace + "XAttribute(\"" + oXmlNode.Name + "\",\"" + oXmlNode.Value + "\");\r";
                    break;
                case System.Xml.XmlNodeType.Text:
                    result += LinqNamespace + "XText oXText = new " + LinqNamespace + "XText(\"" + oXmlNode.Value + "\");\r";
                    break;
            }

            return result;
        }
        /// <summary>
        /// récupère les namespaces de XmlNode
        /// </summary>
        /// <param name="oXmlNode"></param>
        public void GetNamespaces(System.Xml.XmlNode oXmlNode)
        {
            switch (oXmlNode.NodeType)
            {
                case System.Xml.XmlNodeType.Comment:
                    break;
                case System.Xml.XmlNodeType.Document:
                    break;
                case System.Xml.XmlNodeType.Element:
                    // attributs
                    if (oXmlNode.Attributes.Count > 0)
                    {
                        foreach (System.Xml.XmlAttribute oXmlAttribute in oXmlNode.Attributes)
                        {
                            if (!string.IsNullOrEmpty(oXmlAttribute.NamespaceURI))
                            {
                                // Add to cache
                                if (!Namespaces.ContainsKey(oXmlAttribute.Value))
                                {
                                    string Value = "oXNamespace" + Namespaces.Count.ToString();
                                    Namespaces.Add(oXmlAttribute.Value, Value);
                                }
                            }
                        }
                    }
                    break;
            }
            foreach (System.Xml.XmlNode ChildNode in oXmlNode.ChildNodes)
            {
                GetNamespaces(ChildNode);
            }
        }
        /// <summary>
        /// construit chaque XElement de la conversion
        /// </summary>
        /// <param name="oXmlNode"></param>
        /// <param name="Namespace"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        private string BuildElement(System.Xml.XmlNode oXmlNode, string indent)
        {
            string sResult = string.Empty;

            switch (oXmlNode.NodeType)
            {
                case System.Xml.XmlNodeType.Comment:
                    break;
                case System.Xml.XmlNodeType.Document:
                    break;
                case System.Xml.XmlNodeType.Element:

                    sResult += indent + "new " + LinqNamespace + "XElement(";

                    if (oXmlNode.ChildNodes.Count == 1 && oXmlNode.FirstChild.NodeType == System.Xml.XmlNodeType.Text)
                    {
                        if (!string.IsNullOrEmpty(oXmlNode.NamespaceURI))
                        {
                            sResult += Namespaces[oXmlNode.NamespaceURI] + "+";
                            if (!string.IsNullOrEmpty(oXmlNode.Prefix))
                                sResult += "\"" + oXmlNode.LocalName + "\",\"" + oXmlNode.InnerText + "\"";
                            else
                                sResult += "\"" + oXmlNode.Name + "\",\"" + oXmlNode.InnerText + "\"";
                        }
                        else
                        {
                            sResult += "\"" + oXmlNode.Name + "\",\"" + oXmlNode.InnerText + "\"";
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(oXmlNode.NamespaceURI))
                        {
                            sResult += Namespaces[oXmlNode.NamespaceURI] + "+";
                            if (!string.IsNullOrEmpty(oXmlNode.Prefix))
                                sResult += "\"" + oXmlNode.LocalName + "\"";
                            else
                                sResult += "\"" + oXmlNode.Name + "\"";
                        }
                        else
                        {
                            sResult += "\"" + oXmlNode.Name + "\"";
                        }
                    }

                    if (oXmlNode.Attributes.Count > 0)
                    {
                        foreach (System.Xml.XmlAttribute oXmlAttribute in oXmlNode.Attributes)
                        {
                            if (string.IsNullOrEmpty(oXmlAttribute.NamespaceURI))
                            {
                                // attribut
                                if (oXmlAttribute.LocalName != "xmlns")
                                    sResult += ",\r\t" + indent + "new " + LinqNamespace + "XAttribute(\"" + oXmlAttribute.Name + "\",\"" + oXmlAttribute.Value + "\")";
                            }
                            else
                            {
                                if (oXmlAttribute.NamespaceURI != currentNamespacePrefix)
                                {
                                    // LinqNamespace 
                                    if (!string.IsNullOrEmpty(oXmlNode.Prefix))
                                    {
                                        if (oXmlAttribute.Value != oXmlNode.GetNamespaceOfPrefix(oXmlNode.Prefix))
                                        {
                                            sResult += ",\r\t" + indent + "new " + LinqNamespace + "XAttribute(System.Xml.Linq.XNamespace.Xmlns + \"" + oXmlAttribute.LocalName + "\", \"" + oXmlAttribute.Value + "\")";
                                        }
                                    }
                                    else
                                    {
                                        if (oXmlAttribute.LocalName != "xmlns")
                                            sResult += ",\r\t" + indent + "new " + LinqNamespace + "XAttribute(System.Xml.Linq.XNamespace.Xmlns + \"" + oXmlAttribute.LocalName + "\", \"" + oXmlAttribute.Value + "\")";
                                    }
                                }
                            }
                        }
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(oXmlNode.Prefix))
            {
                if (oXmlNode.GetNamespaceOfPrefix(oXmlNode.Prefix) != currentNamespacePrefix)
                {
                    sResult += ",\r\t" + indent + "new " + LinqNamespace + "XAttribute(System.Xml.Linq.XNamespace.Xmlns + \"" + oXmlNode.Prefix + "\", " + Namespaces[oXmlNode.GetNamespaceOfPrefix(oXmlNode.Prefix)] + ")";
                    currentNamespacePrefix = oXmlNode.GetNamespaceOfPrefix(oXmlNode.Prefix);
                }
            }
            foreach (System.Xml.XmlNode ChildElement in oXmlNode.ChildNodes)
            {
                if (Options.IncludeXComment)
                {
                    if (ChildElement.NodeType == System.Xml.XmlNodeType.Comment)
                        sResult += ",\r\t" + indent + "new " + LinqNamespace + "XComment(\"" + ChildElement.Value + "\")";
                }
                if (ChildElement.NodeType == System.Xml.XmlNodeType.Element)
                {
                    sResult += "," + Environment.NewLine;
                    sResult += BuildElement(ChildElement,indent + "\t");
                    sResult += "\r" + indent + "\t)";
                }
            }
            return sResult;
        }

        /// <summary>
        /// crée un code Linq To Xml avec variables
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <param name="Namespace"></param>
        /// <returns></returns>
        public void CreateDirectElement(System.Xml.XmlElement oXmlElement)
        {
            if (!Options.IncludeLinqCompletePathNamespace)
                LinqNamespace = string.Empty;
            else
                LinqNamespace = "System.Xml.Linq.";

            string result = "\t" + oXmlElement.Name + " o" + oXmlElement.Name + " = new " + oXmlElement.Name + "();\r";
            result += "\t" + LinqNamespace + "XElement oXElement" + oXmlElement.Name + " = new " + LinqNamespace + "XElement(\"" + oXmlElement.Name + "\");\r";
            result += CreateElementsOfElement(oXmlElement, oXmlElement.ChildNodes, true, "\t");

            this.Text = result;
        }
        /// <summary>
        /// crée un code Linq To Xml dans une methode avec variables
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <param name="Namespace"></param>
        /// <returns></returns>
        public void CreateCreateMethod(System.Xml.XmlElement oXmlElement)
        {
            if (!Options.IncludeLinqCompletePathNamespace)
                LinqNamespace = string.Empty;
            else
                LinqNamespace = "System.Xml.Linq.";

            string result = "public  " + LinqNamespace + "XElement Create" + oXmlElement.Name + "(" + oXmlElement.Name + " o" + oXmlElement.Name + ")";
            result += "\r{";

            if (HasText(oXmlElement))
            {
                result += "\r\t" + LinqNamespace + "XElement oXElement" + oXmlElement.Name + " = new " + LinqNamespace + "XElement(\"" + oXmlElement.Name + "\",o" + oXmlElement.Name + "." + oXmlElement.Name;
                foreach (System.Xml.XmlAttribute oXmlAttribute in oXmlElement.Attributes)
                {
                    result += ",\r\t\tnew " + LinqNamespace + "XAttribute(\"" + oXmlAttribute.Name + "\",o" + oXmlElement.Name + "." + oXmlAttribute.Name + ")";
                }
                result += "\r\t);";
            }
            else
            {
                result += "\r\t" + LinqNamespace + "XElement oXElement" + oXmlElement.Name + " = new " + LinqNamespace + "XElement(\"" + oXmlElement.Name + "\");\r";
                result += CreateElementsOfElement(oXmlElement, oXmlElement.ChildNodes, true, "\t\t");
            }

            result += "\r\treturn oXElement" + oXmlElement.Name + ";";
            result += "\r}";

            this.Text = result;
        }
        /// <summary>
        /// crée les sous elements de l'element
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="Namespace"></param>
        /// <param name="oXmlElement"></param>
        /// <param name="properties"></param>
        /// <param name="FirstStep"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        public string CreateElementsOfElement(System.Xml.XmlElement oXmlElement, System.Xml.XmlNodeList properties, bool FirstStep, string indent)
        {
            string result = string.Empty;
            List<string> finished = new List<string>();
            foreach (System.Xml.XmlAttribute oXmlAttribute in oXmlElement.Attributes)
            {
                // property
                if (FirstStep)
                    result += "\r" + indent + "oXElement" + oXmlElement.Name + ".Add(new " + LinqNamespace + "XAttribute(\"" + oXmlAttribute.Name + "\",o" + oXmlElement.Name + "." + oXmlAttribute.Name + ");";
                else
                    result += ",\r" + indent + "\t\tnew " + LinqNamespace + "XAttribute(\"" + oXmlAttribute.Name + "\",o" + oXmlElement.Name + "." + oXmlAttribute.Name + ")";
            }
            foreach (System.Xml.XmlNode oXmlNode in properties)
            {
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    if (!finished.Contains(oXmlNode.Name))
                    {
                        finished.Add(oXmlNode.Name);

                        // collection , class or property ?
                        if (isProperty((System.Xml.XmlElement)oXmlNode))
                        {
                            // property
                            if (FirstStep)
                                result += "\r" + indent + "oXElement" + oXmlElement.Name + ".Add(new " + LinqNamespace + "XElement(\"" + oXmlNode.Name + "\",o" + oXmlElement.Name + "." + oXmlNode.Name + ");";
                            else
                                result += ",\r" + indent + "\t\tnew " + LinqNamespace + "XElement(\"" + oXmlNode.Name + "\",o" + oXmlElement.Name + "." + oXmlNode.Name + ")";
                        }
                        else
                        {
                            if (isCollectionInParentElement((System.Xml.XmlElement)oXmlNode))
                            {
                                if (!FirstStep)
                                {
                                    result += "\r" + indent + ");\r";
                                    result += "\r" + indent + "foreach(" + oXmlNode.Name + " o" + oXmlNode.Name + " in o" + oXmlElement.Name + "s)\r";
                                }
                                else
                                    result += "\r" + indent + "foreach(" + oXmlNode.Name + " o" + oXmlNode.Name + " in o" + oXmlElement.Name + "." + oXmlNode.Name + "s)\r";

                                result += indent + "{\r";
                                result += indent + "\t" + LinqNamespace + "XElement oXElement" + oXmlNode.Name + " = new " + LinqNamespace + "XElement(\"" + oXmlNode.Name + "\"";
                                result += CreateElementsOfElement((System.Xml.XmlElement)oXmlNode, oXmlNode.ChildNodes, false, indent + "\t");

                                //

                                if (!ElementsOfElementHaveElements((System.Xml.XmlElement)oXmlNode))
                                    result += "\r" + indent + "\t);\r";

                                result += "\r" + indent + "\toXElement" + oXmlNode.ParentNode.Name + ".Add(oXElement" + oXmlNode.Name + ");";
                                result += "\r" + indent + "}\r";

                            }
                            else
                            {
                                // class
                                if (!FirstStep)
                                {
                                    result += "\r" + indent + ");\r";
                                }
                                result += "\r" + indent + "\t" + LinqNamespace + "XElement oXElement" + oXmlNode.Name + " = new " + LinqNamespace + "XElement(\"" + oXmlNode.Name + "\"";
                                result += CreateElementsOfElement( (System.Xml.XmlElement)oXmlNode, oXmlNode.ChildNodes, false, indent + "\t");
                                if (!ElementsOfElementHaveElements((System.Xml.XmlElement)oXmlNode))
                                    result += "\r" + indent + "\t);";

                                result += "\r" + indent + "\toXElement" + oXmlNode.ParentNode.Name + ".Add(oXElement" + oXmlNode.Name + ");";

                            }
                        }
                    }

                }
            }

            return result;
        }

        
        /// <summary>
        /// determine si le XmlElement se repete plusieurs fois dans le XmlElement parent
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <returns></returns>
        private bool isCollectionInParentElement(System.Xml.XmlElement oXmlElement)
        {
            bool result = false;
            int nCount = 0;

            if (oXmlElement.ParentNode != null)
            {
                if (oXmlElement.ParentNode != oXmlElement.OwnerDocument)
                {
                    foreach (System.Xml.XmlNode x in oXmlElement.ParentNode.ChildNodes)
                    {
                        if (x.NodeType == System.Xml.XmlNodeType.Element)
                        {
                            if (x.Name == oXmlElement.Name)
                                nCount += 1;
                        }
                    }
                }
            }
            if (nCount > 1)
                result = true;

            return result;
        }
        /// <summary>
        /// determine si le XmlElement sera converti en property en CSharp
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <returns></returns>
        public bool isProperty(System.Xml.XmlElement oXmlElement)
        {
            int nCount = 0;
            bool result = true;
            foreach (System.Xml.XmlNode oXmlNode in oXmlElement.ChildNodes)
            {
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element || oXmlNode.NodeType == System.Xml.XmlNodeType.Attribute)
                    nCount += 1;
            }
            if (nCount > 0)
                result = false;

            return result;
        }
        /// <summary>
        /// détermine si le XmlElement a des des XmlElements qui eux memes ont des XmlElements
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <returns></returns>
        public bool HasCollections(System.Xml.XmlElement oXmlElement)
        {
            bool result = false;
            int nCount = 0;
            foreach (System.Xml.XmlNode x in oXmlElement.ChildNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.Element)
                {
                    foreach (System.Xml.XmlNode xn in x.ChildNodes)
                    {
                        if (xn.NodeType == System.Xml.XmlNodeType.Element)
                            nCount += 1;
                    }
                }
            }
            if (nCount > 1)
                result = true;

            return result;
        }
        public bool ElementsOfElementHaveElements(System.Xml.XmlElement oXmlElement)
        {
            bool result = false;
            int nCount = 0;
            foreach (System.Xml.XmlNode x in oXmlElement.ChildNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.Element)
                {
                    foreach (System.Xml.XmlNode xn in x.ChildNodes)
                    {
                        if (xn.NodeType == System.Xml.XmlNodeType.Element)
                            nCount += 1;
                    }
                }
            }
            if (nCount >= 1)
                result = true;

            return result;
        }
        public int CountElementsOfElements(System.Xml.XmlElement oXmlElement)
        {
            int result = 0;
            foreach (System.Xml.XmlNode x in oXmlElement.ChildNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.Element)
                {
                    foreach (System.Xml.XmlNode xn in x.ChildNodes)
                    {
                        if (xn.NodeType == System.Xml.XmlNodeType.Element)
                            result += 1;
                    }
                }
            }
            return result;
           
        }
        public bool HasText(System.Xml.XmlElement oXmlElement)
        {
            bool result = false;
            foreach (System.Xml.XmlNode x in oXmlElement.ChildNodes)
            {
                if (x.NodeType == System.Xml.XmlNodeType.Text)
                {
                    result = true;
                }
            }
            return result;

        }
    }
}
