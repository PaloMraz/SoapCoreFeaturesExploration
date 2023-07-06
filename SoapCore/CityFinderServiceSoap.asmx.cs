using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml.Serialization;

namespace SoapCoreApp
{
  [ServiceContract(Namespace = ServiceContracts.Globals.PublicApiCityFinderServiceNamespace)]
  public class CityFinderServiceSoap
  {
    /// <summary>
    [OperationContract]
    [return: XmlArray("findCitiesResponse")]
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
