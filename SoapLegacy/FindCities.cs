using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoapLegacyApp
{
  [Serializable]
  [XmlType(Namespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace, TypeName = "findCities")]
  [XmlRoot(Namespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace, ElementName = "findCities")]
  public class FindCities
  {
    [XmlElement("country", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [MinLength(1)]
    [MaxLength(3)]
    public string Country { get; set; }

    [XmlElement("zipCode", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [MaxLength(9)]
    public string ZipCode { get; set; }

    [XmlElement("city", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [MaxLength(100)]
    public string City { get; set; }

    [XmlElement("limit", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int Limit { get; set; }

    [XmlElement("order", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Order { get; set; }
  }
}
