using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace SoapLegacyApp
{
  [WebService(Namespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace)]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
  public class CityFinderServiceSoap : WebService
  {
    /// <summary>
    [WebMethod]
    [return: XmlArray("findCitiesResponse")]
    [SoapDocumentMethod(
      Action = ServiceContracts.Globals.PublicApiCityFinderServiceFindCitiesAction,
      RequestNamespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace,
      ResponseNamespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace,
      Use = System.Web.Services.Description.SoapBindingUse.Literal,
      ParameterStyle = SoapParameterStyle.Bare,
      ResponseElementName = ServiceContracts.Globals.PublicApiCityFinderServiceFindCitiesResponseElementName)]
    public List<CityType> findCities(
      [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace)]
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
