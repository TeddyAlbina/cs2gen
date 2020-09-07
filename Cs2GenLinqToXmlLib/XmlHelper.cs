using System;
using System.Collections.Generic;
using System.Text;

namespace Cs2GenLinqToXmlLib
{
    /// <summary>
    /// this class allows an access to the files xml 
    /// </summary>
    public class XmlHelper
    {
        private System.Xml.XmlDocument _XmlDocument;

        public System.Xml.XmlDocument XmlDocument
        {
            get { return _XmlDocument; }
            set { _XmlDocument = value; }
        }

        #region document

        public void CreateDocument()
        {
            XmlDocument = new System.Xml.XmlDocument();
        }
        public void LoadFile(string path)
        {
            XmlDocument = new System.Xml.XmlDocument();
            XmlDocument.Load(path);
        }
        public void LoadXml(string Xml)
        {
            XmlDocument = new System.Xml.XmlDocument();
            XmlDocument.LoadXml(Xml);
        }

        #endregion

        #region declaration

        public System.Xml.XmlDeclaration CreateDeclaration()
        {
            System.Xml.XmlDeclaration oXmlDeclaration = XmlDocument.CreateXmlDeclaration("1.0", "utf-8", "yes");
            return oXmlDeclaration;
        }
        public System.Xml.XmlDeclaration CreateDeclaration(string version, string encoding, string standalone)
        {
            System.Xml.XmlDeclaration oXmlDeclaration = XmlDocument.CreateXmlDeclaration(version, encoding, standalone);
            return oXmlDeclaration;
        }
        public void AddDeclaration(System.Xml.XmlDeclaration oXmlDeclaration)
        {
            XmlDocument.AppendChild(oXmlDeclaration);
        }

        #endregion

        #region comment 

        public System.Xml.XmlComment CreateComment(string Value)
        {
            System.Xml.XmlComment oXmlComment = XmlDocument.CreateComment(Value);
            return oXmlComment;
        }
        public void AddComment(System.Xml.XmlNode Parent, System.Xml.XmlComment oXmlComment)
        {
            int nI = 0;
            System.Xml.XmlNode selected = null;
            foreach (System.Xml.XmlNode oXmlNode in Parent.ChildNodes)
            {
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element || oXmlNode.NodeType == System.Xml.XmlNodeType.Attribute)
                {
                    if (nI == 0)
                    {
                        selected = oXmlNode;
                        nI += 1;
                    }
                }
            }
            if (nI > 0)
            {
                Parent.InsertBefore(oXmlComment, selected);
            }
            else
            {
                Parent.AppendChild(oXmlComment);
            }
        }
        public void AddComment(string xpath, System.Xml.XmlComment oXmlComment)
        {
            System.Xml.XmlNode Parent = XmlDocument.SelectSingleNode(xpath);
            int nI = 0;
            System.Xml.XmlNode selected = null;
            foreach (System.Xml.XmlNode oXmlNode in Parent.ChildNodes)
            {
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element || oXmlNode.NodeType == System.Xml.XmlNodeType.Attribute)
                {
                    if (nI == 0)
                    {
                        selected = oXmlNode;
                        nI += 1;
                    }
                }
            }
            if (nI > 0)
            {
                Parent.InsertBefore(oXmlComment, selected);
            }
            else
            {
                Parent.AppendChild(oXmlComment);
            }
            //System.Xml.XmlNode oXmlNode = XmlDocument.SelectSingleNode(xpath);
            //oXmlNode.AppendChild(oXmlComment);
        }
        public void InsertCommentBefore(System.Xml.XmlNode oXmlNoderef, System.Xml.XmlComment oXmlComment)
        {
            if (oXmlNoderef.ParentNode == null)
                XmlDocument.InsertBefore(oXmlComment, oXmlNoderef);
            else
                oXmlNoderef.ParentNode.InsertBefore(oXmlComment, oXmlNoderef);
        }
        public void InsertCommentAfter(System.Xml.XmlNode oXmlNoderef, System.Xml.XmlComment oXmlComment)
        {
            if (oXmlNoderef.ParentNode == null)
                XmlDocument.InsertAfter(oXmlComment, oXmlNoderef);
            else
                oXmlNoderef.ParentNode.InsertAfter(oXmlComment, oXmlNoderef);
           
        }
        public void UpdateComment(string xpath, string value)
        {
            System.Xml.XmlComment oXmlComment = (System.Xml.XmlComment)XmlDocument.SelectSingleNode(xpath);
            oXmlComment.Value = value;
        }
        public void UpdateComment(System.Xml.XmlComment oXmlComment, string value)
        {
            oXmlComment.Value = value;
        }
        public void RemoveComment(string xpath)
        {
            System.Xml.XmlComment oXmlComment = (System.Xml.XmlComment)XmlDocument.SelectSingleNode(xpath);
            if (oXmlComment.ParentNode == null)
                XmlDocument.RemoveChild(oXmlComment);
            else
                oXmlComment.ParentNode.RemoveChild(oXmlComment);
        }
        public void RemoveComment(System.Xml.XmlComment oXmlComment)
        {
            if (oXmlComment.ParentNode == null)
                XmlDocument.RemoveChild(oXmlComment);
            else
                oXmlComment.ParentNode.RemoveChild(oXmlComment);
        }
        public System.Xml.XmlComment GetComment(string xpath)
        {
            return (System.Xml.XmlComment)XmlDocument.SelectSingleNode(xpath);
        }

        #endregion

        #region element

        public System.Xml.XmlElement CreateElement(string Name)
        {
            System.Xml.XmlElement oXmlElement = XmlDocument.CreateElement(Name);
            return oXmlElement;
        }
        public System.Xml.XmlElement CreateElement(string Name, string Value)
        {
            System.Xml.XmlElement oXmlElement = XmlDocument.CreateElement(Name);
            System.Xml.XmlText oXmlText = XmlDocument.CreateTextNode(Value);
            oXmlElement.AppendChild(oXmlText);
            return oXmlElement;
        }
        public void AddRoot(System.Xml.XmlElement oXmlElement)
        {
            XmlDocument.AppendChild(oXmlElement);
        }
        public void AddElement(string xpath, System.Xml.XmlElement oXmlElement)
        {
            System.Xml.XmlElement selected = GetElement(xpath);
            if (ContainsElement(selected, oXmlElement))
                throw new Exception("Element already exist");
            selected.AppendChild(oXmlElement);
        }
        public void AddElement(System.Xml.XmlElement selected, System.Xml.XmlElement oXmlElement)
        {
            if (ContainsElement(selected, oXmlElement))
                throw new Exception("Element already exist");
            selected.AppendChild(oXmlElement);
        }
        public void InsertElementBeforeElement(string xpath, System.Xml.XmlElement oXmlElement)
        {
            System.Xml.XmlElement selected = GetElement(xpath);
            if (ContainsElement((System.Xml.XmlElement)selected.ParentNode, oXmlElement))
                throw new Exception("Element already exist");
            else
                selected.ParentNode.InsertBefore(oXmlElement, selected);
        }
        public void InsertElementBeforeElement(System.Xml.XmlElement selected, System.Xml.XmlElement oXmlElement)
        {
            if (ContainsElement((System.Xml.XmlElement)selected.ParentNode, oXmlElement))
                throw new Exception("Element already exist");
            else
                selected.ParentNode.InsertBefore(oXmlElement, selected);
        }
        public void InsertElementAfterElement(string xpath, System.Xml.XmlElement oXmlElement)
        {
            System.Xml.XmlElement selected = GetElement(xpath);
            if (ContainsElement((System.Xml.XmlElement)selected.ParentNode, oXmlElement))
                throw new Exception("Element already exist");
            selected.ParentNode.InsertAfter(oXmlElement, selected);
        }
        public void InsertElementAfterElement(System.Xml.XmlElement selected, System.Xml.XmlElement oXmlElement)
        {
            if (ContainsElement((System.Xml.XmlElement)selected.ParentNode, oXmlElement))
                throw new Exception("Element already exist");
            selected.ParentNode.InsertAfter(oXmlElement, selected);
        }
        public void UpdateElement(System.Xml.XmlElement oXmlElementToUpdate, System.Xml.XmlElement NewXmlElement)
        {
            foreach (System.Xml.XmlNode oXmlNode in oXmlElementToUpdate.Attributes)
            {
                System.Xml.XmlNode xClone = oXmlNode.CloneNode(true);
                NewXmlElement.Attributes.Append((System.Xml.XmlAttribute)xClone);
            }
            foreach (System.Xml.XmlNode oXmlNode in oXmlElementToUpdate.ChildNodes)
            {
                if (oXmlNode.NodeType != System.Xml.XmlNodeType.Text)
                {
                    System.Xml.XmlNode xClone = oXmlNode.CloneNode(true);
                    NewXmlElement.AppendChild(xClone);
                }
            }

            if (oXmlElementToUpdate.ParentNode == null)
                XmlDocument.ReplaceChild(NewXmlElement, oXmlElementToUpdate);
            else
                oXmlElementToUpdate.ParentNode.ReplaceChild(NewXmlElement, oXmlElementToUpdate);

        }
        public bool RemoveElement(string xpath)
        {
            bool bResult = false;
            System.Xml.XmlNode oXmlNode = _XmlDocument.SelectSingleNode(xpath);
            if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
            {
                System.Xml.XmlNode Parent = oXmlNode.ParentNode;
                Parent.RemoveChild(oXmlNode);
                bResult = true;
            }

            return bResult;
        }
        public System.Xml.XmlElement[] GetElements(string xpath)
        {
            try
            {
                List<System.Xml.XmlElement> oXmlElements = new List<System.Xml.XmlElement>();
                System.Xml.XmlNodeList oXmlNodes = _XmlDocument.SelectNodes(xpath);
                foreach (System.Xml.XmlNode oXmlNode in oXmlNodes)
                {
                    if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        System.Xml.XmlElement oReturnXmlElement = (System.Xml.XmlElement)oXmlNode;
                        oXmlElements.Add(oReturnXmlElement);
                    }
                }
                return oXmlElements.ToArray();
            }
            catch (System.Xml.XPath.XPathException ex)
            {
                throw ex;
            }
        }

        public System.Xml.XmlElement[] GetElementsOfElement(System.Xml.XmlElement oXmlElement)
        {
            try
            {
                List<System.Xml.XmlElement> oXmlElements = new List<System.Xml.XmlElement>();
                System.Xml.XmlNodeList oXmlNodes = oXmlElement.ChildNodes;
                foreach (System.Xml.XmlNode oXmlNode in oXmlNodes)
                {
                    if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        System.Xml.XmlElement oReturnXmlElement = (System.Xml.XmlElement)oXmlNode;
                        oXmlElements.Add(oReturnXmlElement);
                    }
                }
                return oXmlElements.ToArray();
            }
            catch (System.Xml.XPath.XPathException ex)
            {
                throw ex;
            }
        }


        public System.Xml.XmlElement GetRootElement()
        {
            System.Xml.XmlElement oXmlElement = null;
            foreach (System.Xml.XmlNode oXmlNode in XmlDocument.ChildNodes)
            {
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
                    oXmlElement = (System.Xml.XmlElement)oXmlNode;
            }
            return oXmlElement;
        }
        public System.Xml.XmlElement GetElement(string xpath)
        {
            System.Xml.XmlElement oXmlElement = null;
            System.Xml.XmlNode oXmlNode = _XmlDocument.SelectSingleNode(xpath);
            if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
            {
                oXmlElement = (System.Xml.XmlElement)oXmlNode;
            }
            return oXmlElement;
        }
        public bool ContainsElement(System.Xml.XmlElement parent, System.Xml.XmlElement oXmlElement)
        {
            bool result = false;
            foreach (System.Xml.XmlNode oCurrent in parent.ChildNodes)
            {
                if (oCurrent.NodeType == System.Xml.XmlNodeType.Element)
                {
                    if ((oCurrent.ChildNodes.Count == 1 && oCurrent.FirstChild.NodeType == System.Xml.XmlNodeType.Text) || oCurrent.ChildNodes.Count == 0)
                    {
                        if (oCurrent.Name.ToLower() == oXmlElement.Name.ToLower())
                            result = true;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Attribute

        public System.Xml.XmlAttribute CreateAttribute(string Name, string Value,string namespaceURI)
        {
            System.Xml.XmlAttribute oXmlAttribute = XmlDocument.CreateAttribute(Name,namespaceURI);
            oXmlAttribute.Value = Value;
            return oXmlAttribute;
        }
        public System.Xml.XmlAttribute CreateAttribute(string Name,string Value)
        {
            System.Xml.XmlAttribute oXmlAttribute = XmlDocument.CreateAttribute(Name);
            oXmlAttribute.Value = Value;
            return oXmlAttribute;
        }
        public void AddAttribute(string xpath, System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)XmlDocument.SelectSingleNode(xpath);
            if (ContainsAttribute(oXmlAttribute, oXmlElement))
                throw new Exception("Attribute already exist");
            oXmlElement.Attributes.Append(oXmlAttribute);
        }
        public void AddAttribute(System.Xml.XmlElement oXmlElement, System.Xml.XmlAttribute oXmlAttribute)
        {
            if (ContainsAttribute(oXmlAttribute, oXmlElement))
                throw new Exception("Attribute already exist");
            oXmlElement.Attributes.Append(oXmlAttribute);
        }
        public void InsertAttributeBeforeAttribute(string xpath, System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlAttribute selected = (System.Xml.XmlAttribute)XmlDocument.SelectSingleNode(xpath);
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)selected.OwnerElement;
            if (ContainsAttribute(oXmlAttribute, oXmlElement))
                throw new Exception("Attribute already exist");
            oXmlElement.Attributes.InsertBefore(oXmlAttribute, selected);
        }
        public void InsertAttributeBeforeAttribute(System.Xml.XmlAttribute selected , System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)selected.OwnerElement;
            if (ContainsAttribute(oXmlAttribute, oXmlElement))
                throw new Exception("Attribute already exist");
            oXmlElement.Attributes.InsertBefore(oXmlAttribute, selected);
        }
        public void InsertAttributeAfterAttribute(string xpath, System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlAttribute selected = (System.Xml.XmlAttribute)XmlDocument.SelectSingleNode(xpath);
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)selected.OwnerElement;
            if (ContainsAttribute(oXmlAttribute, oXmlElement))
                throw new Exception("Attribute already exist");
            oXmlElement.Attributes.InsertAfter(oXmlAttribute, selected);
        }
        public void InsertAttributeAfterAttribute(System.Xml.XmlAttribute selected, System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)selected.OwnerElement;
            if (ContainsAttribute(oXmlAttribute, oXmlElement))
                throw new Exception("Attribute already exist");
            oXmlElement.Attributes.InsertAfter(oXmlAttribute, selected);
        }
        public void UpdateAttribute(string xpath, System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlAttribute oNewXmlAttribute =(System.Xml.XmlAttribute) XmlDocument.SelectSingleNode(xpath);
            oXmlAttribute.OwnerElement.Attributes.InsertBefore(oNewXmlAttribute, oXmlAttribute);

            if (oXmlAttribute.OwnerElement != null)
                oXmlAttribute.OwnerElement.RemoveAttribute(oXmlAttribute.Name);

        }
        public void UpdateAttribute(System.Xml.XmlAttribute oXmlAttribute,System.Xml.XmlAttribute oNewXmlAttribute)
        {
            oXmlAttribute.OwnerElement.Attributes.InsertBefore(oNewXmlAttribute, oXmlAttribute);

            if (oXmlAttribute.OwnerElement != null)
                oXmlAttribute.OwnerElement.RemoveAttribute(oXmlAttribute.Name);

        }
        public void RemoveAttribute(string xpath)
        {
            System.Xml.XmlAttribute oXmlAttribute = (System.Xml.XmlAttribute)XmlDocument.SelectSingleNode(xpath);
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)oXmlAttribute.OwnerElement;
            oXmlElement.Attributes.Remove(oXmlAttribute);
        }
        public void RemoveAttribute(System.Xml.XmlAttribute oXmlAttribute)
        {
            System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)oXmlAttribute.OwnerElement;
            oXmlElement.Attributes.Remove(oXmlAttribute);
        }
        public bool ContainsAttribute(System.Xml.XmlAttribute oXmlAttribute, System.Xml.XmlElement oXmlElement)
        {
            bool result = false;
            foreach (System.Xml.XmlAttribute oCurrentXmlAttribute in oXmlElement.Attributes)
            {
                if (oXmlAttribute.Name.ToLower() == oCurrentXmlAttribute.Name.ToLower())
                    result = true;
            }

            return result;
        }
        public System.Xml.XmlAttribute GetAttribute(string xpath)
        {
            return (System.Xml.XmlAttribute)XmlDocument.SelectSingleNode(xpath);
        }

        #endregion

        #region node

        public System.Xml.XmlNodeList GetNodes(string xpath)
        {
            return XmlDocument.SelectNodes(xpath);
        }
        public System.Xml.XmlNode GetNode(string xpath)
        {
            return (System.Xml.XmlNode)XmlDocument.SelectSingleNode(xpath);
        }
        public void AddNode(string xpath, System.Xml.XmlNode oXmlNode)
        {
            XmlDocument.SelectSingleNode(xpath).AppendChild(oXmlNode);
        }
        public System.Xml.XmlNode CreateNode(string xml)
        {
            System.Xml.XmlNode oXmlNode = XmlDocument.CreateNode("element", "extractnode", string.Empty);
            oXmlNode.InnerXml = xml;
            return oXmlNode;
        }

        public System.Xml.XmlNode CutNode(string xpath)
        {
            System.Xml.XmlNode oXmlNode = XmlDocument.SelectSingleNode(xpath);
            System.Xml.XmlNode oXmlNodeCut = oXmlNode.Clone();
            if (oXmlNode.ParentNode == null)
                XmlDocument.RemoveChild(oXmlNode);
            else
                oXmlNode.ParentNode.RemoveChild(oXmlNode);

            return oXmlNodeCut;
        }
        public void PasteNode(string xpath, System.Xml.XmlNode oXmlNode)
        {
            System.Xml.XmlElement Parent = (System.Xml.XmlElement)XmlDocument.SelectSingleNode(xpath);
            if (Parent.NodeType != System.Xml.XmlNodeType.Element)
            {
                throw new Exception("selected node can't received this stick node");
            }
            else
            {
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    System.Xml.XmlElement oXmlElement = (System.Xml.XmlElement)oXmlNode.Clone();
                    if (ContainsElement(Parent, oXmlElement))
                        throw new Exception("Element already exist");
                    else
                        if (Parent.ChildNodes.Count == 1 && Parent.FirstChild.NodeType == System.Xml.XmlNodeType.Text )
                            throw new Exception("Element has text");
                        else
                            Parent.AppendChild(oXmlElement);
                }
                if (oXmlNode.NodeType == System.Xml.XmlNodeType.Attribute)
                {
                    System.Xml.XmlAttribute oXmlAttribute = (System.Xml.XmlAttribute)oXmlNode.Clone();
                    if (ContainsAttribute(oXmlAttribute, Parent))
                        throw new Exception("Attribute already exist");
                    else
                        Parent.Attributes.Append(oXmlAttribute);
                }
            }
        }

        #endregion

       
    }
}
