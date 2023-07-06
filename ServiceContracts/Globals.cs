namespace ServiceContracts;

public static class Globals
{
  public const string PublicApiSoapHeader = "Header";
  public const string PublicApiSoapBody = "Body";
  public const string PublicApiSoapEnvelopeNS = "http://schemas.xmlsoap.org/soap/envelope/";
  public const string PublicApiCityFinderServiceNamespace = "http://example.com/CityFinderService/";
  
  public const string PublicApiCityFinderServiceFindCitiesAction = "http://example.com/CityFinderService/findCitiesAction";
  public const string PublicApiCityFinderServiceFindCitiesResponseElementName = "findCitiesResponse";
}
