using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace SoapLegacyApp
{
  [WebService(Namespace = ServiceContracts.Globals.CityFinderServiceNamespace)]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.SoapAction)]
  public class CityFinderServiceSoap : WebService
  {
    /// <summary>
    [WebMethod]
    [return: XmlArray("findCitiesResponse")]
    [SoapDocumentMethod(
      Action = ServiceContracts.Globals.CityFinderServiceFindCitiesActionBare,
      Use = System.Web.Services.Description.SoapBindingUse.Literal,
      ParameterStyle = SoapParameterStyle.Bare)]
    public List<CityType> FindCitiesBare(
      [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = ServiceContracts.Globals.CityFinderServiceNamespace)]
      FindCities findCities)
    {
      return Enumerable.Range(1, 5)
        .Select(i => new CityType()
        {
          Country = $"US{i}",
          CountryNum = i,
          Name = $"US{i}",
          Town = $"Town{i}",
          ZipCode = $"9000{i}"
        }).ToList();
    }

    [WebMethod]
    [return: XmlArray("findCitiesResponse")]
    [SoapDocumentMethod(
      Action = ServiceContracts.Globals.CityFinderServiceFindCitiesActionDefault,
      Use = System.Web.Services.Description.SoapBindingUse.Literal,
      ParameterStyle = SoapParameterStyle.Default)]
    public List<CityType> FindCitiesDefault(
  [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = ServiceContracts.Globals.CityFinderServiceNamespace)]
      FindCities findCities)
    {
      return Enumerable.Range(1, 5)
        .Select(i => new CityType()
        {
          Country = $"US{i}",
          CountryNum = i,
          Name = $"US{i}",
          Town = $"Town{i}",
          ZipCode = $"9000{i}"
        }).ToList();
    }

  }
}
