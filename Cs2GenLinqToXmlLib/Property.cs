using System;
using System.Collections.Generic;
using System.Text;

namespace Cs2GenLinqToXmlLib
{
    public class Property
    {
        private string _PropertyType;

        public string PropertyType
        {
            get { return _PropertyType; }
            set { _PropertyType = value; }
        }
        private string _PropertyName;

        public string PropertyName
        {
            get { return _PropertyName; }
            set { _PropertyName = value; }
        }
        private bool _isCollection;

        public bool IsCollection
        {
            get { return _isCollection; }
            set { _isCollection = value; }
        }

        private bool _HasValue;

        public bool HasValue
        {
            get { return _HasValue; }
            set { _HasValue = value; }
        }

        public Property()
        { }
        public Property(string PropertyName, string PropertyType,bool IsCollection)
        {
            this.PropertyName = PropertyName;
            this.PropertyType = PropertyType;
            this.IsCollection = IsCollection;
        }
    }
}
