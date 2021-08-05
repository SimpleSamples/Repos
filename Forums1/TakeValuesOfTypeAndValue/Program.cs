using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


// take the values of <type> and <value>
// https://social.msdn.microsoft.com/Forums/en-US/76b15d14-cde9-4896-a337-5583fedddf3a/i-have-this-xml-file-and-i-want-to-take-the-values-of-lttypegt-and-ltvaluegt-and-print-them?forum=csharpgeneral

namespace TakeValuesOfTypeAndValue
{
    class Program
    {
        static void Main(string[] args)
        {
            const String filename = "properties.xml";
            XmlDocument Document = new XmlDocument();
            FileInfo fi = new FileInfo(filename);
            if (!fi.Exists)
            {
                return;
            }
            //Document.PreserveWhitespace = true;
            try { Document.Load(filename); }
            catch (Exception ex)
            {
                Console.WriteLine("Exception reading: {0}", ex.Message);
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(properties));
        }
    }

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class properties
    {

        private propertiesProperties[] properties1Field;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("properties")]
        public propertiesProperties[] properties1
        {
            get
            {
                return this.properties1Field;
            }
            set
            {
                this.properties1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class propertiesProperties
    {

        private propertiesPropertiesProperties[] propertiesField;

        private propertiesPropertiesProperty[] propertyField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("properties")]
        public propertiesPropertiesProperties[] properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("property")]
        public propertiesPropertiesProperty[] property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class propertiesPropertiesProperties
    {

        private propertiesPropertiesPropertiesProperty propertyField;

        private string nameField;

        /// <remarks/>
        public propertiesPropertiesPropertiesProperty property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class propertiesPropertiesPropertiesProperty
    {

        private byte typeField;

        private byte dataTypeField;

        private string keyField;

        private ushort valueField;

        private byte readOnlyField;

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte dataType
        {
            get
            {
                return this.dataTypeField;
            }
            set
            {
                this.dataTypeField = value;
            }
        }

        /// <remarks/>
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public ushort value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public byte readOnly
        {
            get
            {
                return this.readOnlyField;
            }
            set
            {
                this.readOnlyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class propertiesPropertiesProperty
    {

        private byte typeField;

        private byte dataTypeField;

        private string keyField;

        private string valueField;

        private byte readOnlyField;

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte dataType
        {
            get
            {
                return this.dataTypeField;
            }
            set
            {
                this.dataTypeField = value;
            }
        }

        /// <remarks/>
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public byte readOnly
        {
            get
            {
                return this.readOnlyField;
            }
            set
            {
                this.readOnlyField = value;
            }
        }
    }


}
