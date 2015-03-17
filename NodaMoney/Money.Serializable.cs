﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace NodaMoney
{
    /// <summary>Represents Money, an amount defined in a specific Currency.</summary>
    public partial struct Money : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Money")
            {
                Amount = decimal.Parse(reader["Amount"], CultureInfo.InvariantCulture);
                Currency = Currency.FromCode(reader["Currency"]);
                
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Amount", Amount.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("Currency", Currency.Code);
        }
    }
}
