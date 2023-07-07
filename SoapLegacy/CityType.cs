using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace SoapLegacyApp
{
  /// <summary>
  /// The city type with city, zip code and town.
  /// </summary>
  [Serializable]
  [XmlType(Namespace = ServiceContracts.Globals.CityFinderServiceNamespace, TypeName = "city")]
  [DataContract]
  public class CityType
  {

    /// <summary>
    /// The country code in ISO-A2 format.
    /// </summary>
    [DataMember(Name = "country")]
    [XmlElement("country")]
    [MaxLength(2)]
    public string Country { get; set; }

    /// <summary>
    /// Country number in ISO-Num3 format (e.g. Germany = 276).
    /// MinInclusive: 0
    /// MaxInclusive: 999
    /// </summary>
    [DataMember(Name = "countryNum")]
    [XmlElement("countryNum")]
    public int CountryNum { get; set; }

    /// <summary>
    /// The zip code of the city.
    /// </summary>
    [DataMember(Name = "zipCode")]
    [XmlElement("zipCode")]
    public string ZipCode { get; set; }

    /// <summary>
    /// The name of the city.
    /// </summary>
    [DataMember(Name = "name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    /// The town of the city.
    /// </summary>
    [DataMember(Name = "town")]
    [XmlElement("town")]
    public string Town { get; set; }
  }
}
