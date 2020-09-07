using System;
using System.Collections.Generic;
using System.Text;

namespace Cs2GenLinqToXmlLib
{
    public class XmlToCSharp
    {       
        /// <summary>
        /// 
        /// </summary>
        private static List<Property> ListProperties;
        /// <summary>
        /// 
        /// </summary>
        private static List<GeneratedClass> ListGeneratedClasses;

        /// <summary>
        /// récupère la liste des classes à générer correspondante au XmlElement
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <param name="Namespace"></param>
        /// <returns></returns>
        public static List<GeneratedClass> GetBusinessObjectsClasses(System.Xml.XmlElement oXmlElement, string Namespace)
        {
            ListGeneratedClasses = new List<GeneratedClass>();
            if (GetElementsOfElement(oXmlElement).Length > 0)
                BuildBusinessObjectsClasses(oXmlElement,Namespace);
            ListGeneratedClasses.Add(new GeneratedClass(BuildSorterMode(), "SorterMode.cs"));

            return ListGeneratedClasses;
        }
       /// <summary>
       /// construit les classes collections et unitaires
       /// </summary>
       /// <param name="oXmlElement"></param>
       /// <param name="Namespace"></param>
        private static void BuildBusinessObjectsClasses(System.Xml.XmlElement oXmlElement, string Namespace)
        {
            string Result = string.Empty;
            ListProperties = new List<Property>();
            System.Xml.XmlElement[] properties = GetElementsOfElement(oXmlElement);
            stringPredicateHelper ostringPredicateHelper = new stringPredicateHelper(stringComparaison.Contains, "FileName", oXmlElement.Name + ".cs");
            if (ListGeneratedClasses.Find(ostringPredicateHelper.Predicate) == null)
            {
                if (isCollectionInParentElement(oXmlElement))
                    ListGeneratedClasses.Add(new GeneratedClass(BuildCollectionClass(utilities.Formatstring(oXmlElement.Name),Namespace), utilities.Formatstring(oXmlElement.Name) + "Collection.cs"));

                Result += BuildHeadOfUnitClass(utilities.Formatstring(oXmlElement.Name),Namespace);
                
                foreach (System.Xml.XmlElement property in properties)
                {
                    ostringPredicateHelper.SetProperties(stringComparaison.Contains, "PropertyName", utilities.Formatstring(property.Name));
                    if (ListProperties.Find(ostringPredicateHelper.Predicate) == null)
                    {

                        if (GetElementsOfElement(property).Length > 0)
                        {
                            // property collection
                            if (isCollectionInParentElement(property))
                            {
                                Result += BuildFieldAndPropertyCollectionOfUnitClass(utilities.Formatstring(property.Name), utilities.Formatstring(property.Name));
                                ListProperties.Add(new Property(utilities.Formatstring(property.Name) + "s", utilities.Formatstring(property.Name) + "Collection", true));
                            }
                            else
                            {
                                string PropertyType = GetPropertyType(property.InnerText);
                                Result += BuildFieldAndPropertyOfUnitClass(utilities.Formatstring(property.Name), PropertyType);
                                ListProperties.Add(new Property(utilities.Formatstring(property.Name), PropertyType, false));
                            }
                        }
                        else
                        {

                            string PropertyType = GetPropertyType(property.InnerText);
                            Result += BuildFieldAndPropertyOfUnitClass(utilities.Formatstring(property.Name), PropertyType);
                            ListProperties.Add(new Property(utilities.Formatstring(property.Name), PropertyType, false));
                        }
                    }
                }
                foreach (System.Xml.XmlAttribute oXmlAttribute in oXmlElement.Attributes)
                {
                    string PropertyType = GetPropertyType(oXmlAttribute.Value);
                    Result += BuildFieldAndPropertyOfUnitClass(utilities.Formatstring(utilities.Formatstring(oXmlAttribute.Name)),PropertyType);
                    ListProperties.Add(new Property(utilities.Formatstring(oXmlAttribute.Name),PropertyType,false));
                }
                // constructors
                Result += BuildConstructorsOfUnitClass(utilities.Formatstring(oXmlElement.Name));
                //
                ostringPredicateHelper.SetProperties(stringComparaison.Contains, "PropertyType", "string");
                if (ListProperties.Find(ostringPredicateHelper.Predicate) != null)
                    Result += BuildToStringOverrideOfUnitClass();
                // Comparers
                Result += BuildComparersOfUnitClass(utilities.Formatstring(oXmlElement.Name));

                // foot
                Result += BuildFootOfUnitClass();

                ListGeneratedClasses.Add(new GeneratedClass(Result,utilities.Formatstring(oXmlElement.Name) + ".cs"));
            }
            foreach (System.Xml.XmlElement Class in properties)
            {
                if (GetElementsOfElement(Class).Length > 0)
                    BuildBusinessObjectsClasses(Class,Namespace);
            }
        }
          /// <summary>
          /// construit une classe collection generique
          /// </summary>
          /// <param name="ClassName"></param>
          /// <param name="Namespace"></param>
          /// <returns></returns>
        private static string BuildCollectionClass(string ClassName, string Namespace)
        {
            string sCode = string.Empty;

            //1
            sCode += "using System;" + Environment.NewLine;
            sCode += "using System.Text;" + Environment.NewLine;
            sCode += Environment.NewLine;
            sCode += "namespace " + Namespace + Environment.NewLine;
            sCode += "{" + Environment.NewLine;
            sCode += "\t[Serializable]" + Environment.NewLine;
            sCode += "\tpublic class " + ClassName + "Collection : System.Collections.Generic.List<" + ClassName + ">" + Environment.NewLine;
            sCode += "\t{" + Environment.NewLine;
            sCode += "\t}" + Environment.NewLine;
            sCode += "}" + Environment.NewLine;

            return sCode;
        }
        /// <summary>
        /// construit l'en tête de la classe unitaire
        /// </summary>
        /// <param name="ClassName"></param>
        /// <param name="Namespace"></param>
        /// <returns></returns>
        private static string BuildHeadOfUnitClass(string ClassName, string Namespace)
        {
            string sCode = string.Empty;

            //1
            sCode += "using System;" + Environment.NewLine;
            sCode += "using System.Text;" + Environment.NewLine;
            sCode += Environment.NewLine;
            sCode += "namespace " + Namespace + Environment.NewLine;
            sCode += "{" + Environment.NewLine;
            sCode += "\t[Serializable]" + Environment.NewLine;
            sCode += "\tpublic class " + ClassName + Environment.NewLine;
            sCode += "\t{" + Environment.NewLine;

            return sCode;
        }
        /// <summary>
        /// construit les champs et propriétés de type collection de la classe unitaire
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="PropertyType"></param>
        /// <returns></returns>
        private static string BuildFieldAndPropertyCollectionOfUnitClass(string PropertyName, string PropertyType)
        {
            string sCode = string.Empty;

            sCode += "\t\tprivate " + PropertyType + "Collection _" + PropertyName + "s;" + Environment.NewLine;
            sCode += Environment.NewLine;
            sCode += "\t\t[System.ComponentModel.Browsable(true)]" + Environment.NewLine;
            sCode += "\t\tpublic " + PropertyType + "Collection " + PropertyName + "s" + Environment.NewLine;
            sCode += "\t\t{" + Environment.NewLine;
            sCode += "\t\t\tget { return _" + PropertyName + "s; }" + Environment.NewLine;
            sCode += "\t\t\tset { _" + PropertyName + "s = value; }" + Environment.NewLine;
            sCode += "\t\t}" + Environment.NewLine;

            sCode += Environment.NewLine;

            return sCode;
        }
        /// <summary>
        /// construit les champs et propriétés dont le type est soit une classe soit un type valeur de la classe unitaire
        /// </summary>
        /// <param name="PropertyName"></param>
        /// <param name="PropertyType"></param>
        /// <returns></returns>
        private static string BuildFieldAndPropertyOfUnitClass(string PropertyName, string PropertyType)
        {
            string sCode = string.Empty;

            sCode += "\t\tprivate " + PropertyType + " _" + PropertyName + ";" + Environment.NewLine;
            sCode += Environment.NewLine;
            sCode += "\t\t[System.ComponentModel.Browsable(true)]" + Environment.NewLine;
            sCode += "\t\tpublic " + PropertyType + " " + PropertyName + Environment.NewLine;
            sCode += "\t\t{" + Environment.NewLine;
            sCode += "\t\t\tget { return _" + PropertyName + "; }" + Environment.NewLine;
            sCode += "\t\t\tset { _" + PropertyName + " = value; }" + Environment.NewLine;
            sCode += "\t\t}" + Environment.NewLine;
            sCode += Environment.NewLine;

            return sCode;
        }
        /// <summary>
        /// permet de définir un type de données à partir d'une valeur
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetPropertyType(string Value)
        {
            string result = string.Empty;
            int intresult;
            bool boolresult;
            double doubleresult;
            DateTime DateTimeresult;

            if (int.TryParse(Value,out intresult))
            {
                result = "int";
            }
            else if (bool.TryParse(Value, out boolresult))
            {
                result = "bool";
            }
            else if (DateTime.TryParse(Value, out DateTimeresult))
            {
                result = "DateTime";
            }
            else if (double.TryParse(Value,out doubleresult))
            {
                result = "double";
            }
            else
            {
                result = "string";
            }

            return result;
        }
        /// <summary>
        /// construit les constructeurs de la classe unitaire
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        private static string BuildConstructorsOfUnitClass(string ClassName)
        {
            string sCode = string.Empty;
            int nPosition = 0;
            // Default
            sCode += "\t\tpublic " + ClassName + "()" + Environment.NewLine;
            sCode += "\t\t{" + Environment.NewLine;
            foreach (Property Property in ListProperties)
            {
                if (Property.IsCollection)
                {
                    sCode += "\t\t\tthis." + Property.PropertyName + " = new " + Property.PropertyName + "Collection();" + Environment.NewLine;
                }
            }
             sCode += "\t\t}" + Environment.NewLine;


            // Complete
            sCode += "\t\tpublic " + ClassName + "(";
            foreach (Property Property in ListProperties)
            {
                if (nPosition == 0)
                {
                    sCode += Property.PropertyType + " " + Property.PropertyName;
                    nPosition += 1;
                }
                else
                {
                    sCode += "," + Property.PropertyType + " " + Property.PropertyName;
                }
            }
            sCode += ")" + Environment.NewLine;
            sCode += "\t\t{" + Environment.NewLine;
            foreach (Property Property in ListProperties)
            {
                sCode += "\t\t\tthis." + Property.PropertyName + " = " + Property.PropertyName + ";" + Environment.NewLine;
            }
            sCode += "\t\t}" + Environment.NewLine;
            sCode += Environment.NewLine;

            return sCode;
        }
        /// <summary>
        /// construit la méthode dérivée ToString() de la classe unitaire
        /// </summary>
        /// <returns></returns>
        private static string BuildToStringOverrideOfUnitClass()
        {
            string sCode;
            sCode = string.Empty;

            sCode += "\t\tpublic override string ToString()" + Environment.NewLine;
            sCode += "\t\t{" + Environment.NewLine;
            sCode += "\t\t\treturn ";

            int nIndex = 0;
            foreach (Property Property in ListProperties)
            {
                if (Property.PropertyType == "string")
                {
                    if (nIndex == 0)
                    {
                        sCode += "this." + Property.PropertyName;
                        nIndex += 1;
                    }
                    else
                        sCode += " + \" \" + this." + Property.PropertyName;
                }
            }
            if (nIndex > 0)
                sCode += ";" + Environment.NewLine;
            sCode += "\t\t}" + Environment.NewLine;
            return sCode;
        }
        /// <summary>
        /// construit les classes de trie de la classe unitaire
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        private static string BuildComparersOfUnitClass(string ClassName)
        {
            string sCode;
            sCode = string.Empty;

            foreach (Property Property in ListProperties)
            {
                if (Property.PropertyType == "string")
                {
                    sCode += "\t\tpublic class " + Property.PropertyName + "Comparer : System.Collections.Generic.IComparer<" + ClassName + ">" + Environment.NewLine;
                    sCode += "\t\t{" + Environment.NewLine;
                    sCode += "\t\t\tpublic SorterMode SorterMode;" + Environment.NewLine;
                    sCode += "\t\t\tpublic " + Property.PropertyName + "Comparer()" + Environment.NewLine;
                    sCode += "\t\t\t{ }" + Environment.NewLine;
                    sCode += "\t\t\tpublic " + Property.PropertyName + "Comparer(SorterMode SorterMode)" + Environment.NewLine;
                    sCode += "\t\t\t{" + Environment.NewLine;
                    sCode += "\t\t\t\tthis.SorterMode = SorterMode;" + Environment.NewLine;
                    sCode += "\t\t\t}" + Environment.NewLine;
                    sCode += "\t\t\t#region IComparer<" + ClassName + "> Membres" + Environment.NewLine;
                    sCode += "\t\t\tint System.Collections.Generic.IComparer<" + ClassName + ">.Compare(" + ClassName + " x, " + ClassName + " y)" + Environment.NewLine;
                    sCode += "\t\t\t{" + Environment.NewLine;
                    sCode += "\t\t\t\tif (SorterMode == SorterMode.Ascending)" + Environment.NewLine;
                    sCode += "\t\t\t\t{" + Environment.NewLine;
                    sCode += "\t\t\t\t\treturn y." + Property.PropertyName + ".CompareTo(x." + Property.PropertyName + ");" + Environment.NewLine;
                    sCode += "\t\t\t\t}" + Environment.NewLine;
                    sCode += "\t\t\t\telse" + Environment.NewLine;
                    sCode += "\t\t\t\t{" + Environment.NewLine;
                    sCode += "\t\t\t\t\treturn x." + Property.PropertyName + ".CompareTo(y." + Property.PropertyName + ");" + Environment.NewLine;
                    sCode += "\t\t\t\t}" + Environment.NewLine;
                    sCode += "\t\t\t}" + Environment.NewLine;
                    sCode += "\t\t\t#endregion" + Environment.NewLine;
                    sCode += "\t\t}" + Environment.NewLine;
                }
            }
            return sCode;
        }
        /// <summary>
        /// construit le pied de la classe unitaire
        /// </summary>
        /// <returns></returns>
        private static string BuildFootOfUnitClass()
        {
            string sCode;
            sCode = string.Empty;

            sCode += "\t}" + Environment.NewLine;
            sCode += "}" + Environment.NewLine;

            return sCode;
        }
        /// <summary>
        /// construit la classe contenant l'enum utilisée par les méthodes de trie des classes unitaires 
        /// </summary>
        /// <returns></returns>
        private static string BuildSorterMode()
        {
            string sCode = string.Empty;
            sCode += "using System;" + Environment.NewLine;
            sCode += "using System.Text;" + Environment.NewLine;
            sCode += Environment.NewLine;
            sCode += "namespace NET2CsGenXLinq" + Environment.NewLine;
            sCode += "{" + Environment.NewLine;
            sCode += "\tpublic enum SorterMode" + Environment.NewLine;
            sCode += "\t{" + Environment.NewLine;
            sCode += "\t\tAscending," + Environment.NewLine;
            sCode += "\t\tDescending" + Environment.NewLine;
            sCode += "\t}" + Environment.NewLine;
            sCode += "}" + Environment.NewLine;

            return sCode;
        }
            
        /// <summary>
        /// récupère les XmlElements (et uniquement) du XmlElement
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <returns></returns>
        private static System.Xml.XmlElement[] GetElementsOfElement(System.Xml.XmlElement oXmlElement)
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
        /// <summary>
        /// determine si le XmlElement se repete plusieurs fois dans le XmlElement parent
        /// </summary>
        /// <param name="oXmlElement"></param>
        /// <returns></returns>
        private static bool isCollectionInParentElement(System.Xml.XmlElement oXmlElement)
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
       
    }
}
