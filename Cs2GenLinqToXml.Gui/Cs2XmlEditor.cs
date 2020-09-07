using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Cs2GenLinqToXml.Gui
{
    public partial class Cs2XmlEditor : System.Windows.Forms.RichTextBox
    {
        public delegate void ColumnLineChangedHandler(int Line,int Column,string Message);
        public delegate void ParsedXmlHandler(string Message,bool isXmlWellFormed);
        public ColumnLineChangedHandler ColumnLineChanged;
        public ParsedXmlHandler ParsedXml;

        private int _Line;

        public int Line
        {
            get { return _Line; }
            set { _Line = value; }
        }

        private int _Column;

        public int Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

        private bool _isXmlWellFormed;

        public bool IsXmlWellFormed
        {
            get { return _isXmlWellFormed; }
            set { _isXmlWellFormed = value; }
        }

        private bool _Updated;

        public bool Updated
        {
            get { return _Updated; }
            set { _Updated = value; }
        }


        public Cs2XmlEditor()
        {
            InitializeComponent();
        }

        public Cs2XmlEditor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        // Events
        private void Cs2XmlEditor_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                GetLineAndColumn();
                if (ColumnLineChanged != null)
                    ColumnLineChanged(Line, Column, GetLineAndColumnMessage());

                if (e.KeyValue == 226 && (e.Modifiers == Keys.Shift || e.Modifiers == Keys.Capital))
                    CompleteTag();
              
                if (e.KeyValue == 187 && (e.Modifiers != Keys.Shift || e.Modifiers != Keys.Capital))
                    CompleteAttribute();

                Updated = true;
            }
            catch
            { }
        }

        private void Cs2XmlEditor_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                GetLineAndColumn();
                if (ColumnLineChanged != null)
                    ColumnLineChanged(Line, Column, GetLineAndColumnMessage());
            }
            catch
            { }
        }

        private void Cs2XmlEditor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Options.ParseXml)
                {
                    ParseXml();
                    IsXmlWellFormed = true;
                    if (ParsedXml != null)
                        ParsedXml("Ready", IsXmlWellFormed);
                    this.ForeColor = System.Drawing.SystemColors.WindowText;
                }
            }
            catch (Exception ex)
            {
                IsXmlWellFormed = false;
                if (ParsedXml != null)
                    ParsedXml(ex.Message, IsXmlWellFormed);
                this.ForeColor = Options.ErrorColor;
            }
        }

        // Methods

        /// <summary>
        /// convertit un XmlDocument en texte
        /// </summary>
        /// <param name="oXmlDocument"></param>
        /// <returns></returns>
        public void ConvertXmlToText(System.Xml.XmlDocument oXmlDocument)
        {
            System.Xml.XPath.XPathNavigator oXPathNavigator = oXmlDocument.CreateNavigator();
            this.Text = oXmlDocument.FirstChild.OuterXml + "\r" + oXPathNavigator.InnerXml;
            Updated = false;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public string BuildEndTag(string ReceivedTag)
        {
            string Endtag = string.Empty;
            System.Text.RegularExpressions.Regex RegexBad = new System.Text.RegularExpressions.Regex(@"<\?.*\??>$|<!--.*-->$|<\/.*>$|<.*\/>$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex RegexAttribute = new System.Text.RegularExpressions.Regex(@"\s[a-z-0-9]+=\""[^\""]*""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (!RegexBad.IsMatch(ReceivedTag))
            {
                if (HasText(ReceivedTag))
                {
                    Endtag = RegexAttribute.Replace(ReceivedTag, string.Empty);
                    Endtag = Endtag.Replace("<", "</");
                }
            }

            return Endtag;
        }
        /// <summary>
        /// vérifie la validité d'une chaine passée
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public bool HasText(string Text)
        {
            bool bResult = false;
            foreach (char cWork in Text)
            {
                if (char.IsLetter(cWork))
                    bResult = true;
            }
            return bResult;
        }
        public void GetLineAndColumn()
        {
            Line = this.GetLineFromCharIndex(this.GetFirstCharIndexOfCurrentLine());
            int Sum = 0;
            System.Collections.IEnumerator oEnum = this.Lines.GetEnumerator();
            int Count = 0;
            while (Count < Line)
            {
                oEnum.MoveNext();
                if (Count < Line)
                {
                    Sum += oEnum.Current.ToString().Length + 1;
                }
                Count += 1;
            }
          
            Column = this.SelectionStart - Sum;
        }
        public string GetLineAndColumnMessage()
        {
            return "Ln " + (Line + 1).ToString() + " Col " + (Column + 1).ToString();
        }
        private void ParseXml()
        {
            System.Xml.XmlTextReader oXmlTextReader;
            oXmlTextReader = new System.Xml.XmlTextReader(this.Text, System.Xml.XmlNodeType.Document, null);
            while (oXmlTextReader.Read())
            {
            
            }
        }
        private void CompleteTag()
        {
            int OpenTag = this.Text.Substring(0, this.SelectionStart).LastIndexOf("<");
            if (OpenTag != -1)
            {
                string input = this.Text.Substring(OpenTag, this.SelectionStart - OpenTag);
                string Tag = BuildEndTag(input);
                if (!string.IsNullOrEmpty(Tag))
                {
                    int EndTagExist = this.Text.Substring(this.SelectionStart, this.TextLength - this.SelectionStart).IndexOf(Tag);
                    int StartTagJustAfter = this.Text.Substring(this.SelectionStart, this.TextLength - this.SelectionStart).IndexOf(input);

                    if (StartTagJustAfter == -1 && EndTagExist == -1)
                    {
                        int index = this.SelectionStart;
                        this.SelectedText += Tag;
                        this.Select(index, 0);
                    }
                    else if (StartTagJustAfter == -1 && EndTagExist != -1)
                    { }
                    else if (StartTagJustAfter != -1 && EndTagExist == -1)
                    {
                        int index = this.SelectionStart;
                        this.SelectedText += Tag;
                        this.Select(index, 0);
                    }
                    else if (StartTagJustAfter != -1 && EndTagExist != -1 && EndTagExist < StartTagJustAfter)
                    { }
                    else if (StartTagJustAfter != -1 && EndTagExist != -1 && EndTagExist > StartTagJustAfter)
                    {
                        int index = this.SelectionStart;
                        this.SelectedText += Tag;
                        this.Select(index, 0);
                    }
                }
            }
        }

        private void CompleteAttribute()
        {
            int OpenTag = this.Text.Substring(0, this.SelectionStart).LastIndexOf("<");
            int EndTag = this.Text.Substring(0, this.SelectionStart).LastIndexOf(">");

            if (OpenTag == -1)
            { }
            else if (OpenTag != -1 && EndTag == -1)
            {
                // >
                if (this.Text.Substring(OpenTag + 1, 1) != "/")
                {
                    int space = this.Text.Substring(OpenTag, this.SelectionStart - OpenTag).LastIndexOf(" ");

                    if (this.TextLength > this.SelectionStart)
                    {
                        int OpenValue = this.Text.Substring(this.SelectionStart, 1).LastIndexOf("\"");
                        if (space != -1 && OpenValue == -1 && space != this.SelectionStart - 1)
                        {
                            int index = this.SelectionStart;
                            this.SelectedText += "\"\"";
                            this.Select(index + 1, 0);
                        }
                    }
                    else
                    {
                        if (space != -1 && space != this.SelectionStart - 1)
                        {
                            int index = this.SelectionStart;
                            this.SelectedText += "\"\"";
                            this.Select(index + 1, 0);
                        }
                    }
                }
            }
            else if (OpenTag != -1 && EndTag != -1 && EndTag > OpenTag)
            { }
            else if (OpenTag != -1 && EndTag != -1 && EndTag < OpenTag)
            {
                // >
                if (this.Text.Substring(OpenTag + 1, 1) != "/")
                {
                    int space = this.Text.Substring(OpenTag, this.SelectionStart - OpenTag).LastIndexOf(" ");

                    if (this.TextLength > this.SelectionStart)
                    {
                        int OpenValue = this.Text.Substring(this.SelectionStart, 1).LastIndexOf("\"");
                        if (space != -1 && OpenValue == -1 && space != this.SelectionStart - 1)
                        {
                            int index = this.SelectionStart;
                            this.SelectedText += "\"\"";
                            this.Select(index + 1, 0);
                        }
                    }
                    else
                    {
                        if (space != -1 && space != this.SelectionStart - 1)
                        {
                            int index = this.SelectionStart;
                            this.SelectedText += "\"\"";
                            this.Select(index + 1, 0);
                        }
                    }
                }
            }
        }
        public void RefreshForecolor()
        {
            if (IsXmlWellFormed)
                this.ForeColor = System.Drawing.SystemColors.WindowText;
            else
                this.ForeColor = Options.ErrorColor;
        }

  


    }
}
