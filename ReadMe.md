## SoapCoreFeaturesExploration.sln

The solution demonstrates different behavior of legacy `.asmx`-based SOAP service 
methods depending on the value of the [SoapDocumentMethodAttribute.ParameterStyle](https://learn.microsoft.com/en-us/dotnet/api/system.web.services.protocols.soapdocumentmethodattribute.parameterstyle?view=netframework-4.8.1) property and the corresponding `SoapCore`-based SOAP services ported to .NET7.

The `SoapLegacyApp.csproj` project is a .NET Framework 4.6.1. web service tha implements the `CityFinderServiceSoap.asmx` web service
with two web methods that differ only on the the value of the [SoapDocumentMethodAttribute.ParameterStyle](https://learn.microsoft.com/en-us/dotnet/api/system.web.services.protocols.soapparameterstyle?view=netframework-4.8.1) property:

* `FindCitiesBare` with `SoapParameterStyle.Bare`
* `FindCitiesDefault` with `SoapParameterStyle.Default`

The `FindCitiesBare` service method produces the response XML payload directly under the SOAP `Body`:

````
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <soap:Body>
    <findCitiesResponse xmlns="http://example.com/CityFinderService">
      <city>
        <country>US1</country>
        <countryNum>1</countryNum>
        <zipCode>90001</zipCode>
        <name>US1</name>
        <town>Town1</town>
      </city>
      ...
````

The `FindCitiesDefault` wraps the response payload into additional `FindCitiesDefaultResponse` XML element:

````
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <soap:Body>
    <FindCitiesDefaultResponse xmlns="http://example.com/CityFinderService">
      <findCitiesResponse>
        <city>
          <country>US1</country>
          <countryNum>1</countryNum>
          <zipCode>90001</zipCode>
          <name>US1</name>
          <town>Town1</town>
        </city>
        ...
````

The `SoapCoreApp.csproj` project is an .NET 7 web service that implements the `CityFinderServiceSoap.asmx.cs` web service
using the [SoapCore](https://github.com/DigDes/SoapCore)-provided middleware. `SoapCore` does not support the `SoapDocumentMethodAttribute` so the
services exposes just one method `FindCities` that produces response payload similar to the legacy `FindCitiesDefault`
web method; i.e. wrapped in additional `FindCitiesResult` XML element:

````
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <s:Body>
    <FindCitiesResponse xmlns="http://example.com/CityFinderService">
      <FindCitiesResult>
        <city>
          <country>US1</country>
          <countryNum>1</countryNum>
          <zipCode>90001</zipCode>
          <name>US1</name>
          <town>Town1</town>
        </city>
        ...
````

I was not able to find any way to "persuade" the `SoapCore` middleware to generate responses __without__ the additional
XML wrapper element just like the legacy `FindCitiesBare` web method does.
