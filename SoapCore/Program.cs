using SoapCore;

namespace SoapCoreApp;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
      .AddSoapCore()
      .AddHttpContextAccessor()
      .AddScoped<CityFinderServiceSoap>();


    var app = builder.Build();
    (app as IApplicationBuilder)
      .UseSoapEndpoint<CityFinderServiceSoap>(options =>
      {
        options.Path = "/CityFinderServiceSoap.asmx";
        options.EncoderOptions = new SoapEncoderOptions[]
        {
          new SoapEncoderOptions()
        };
        options.SoapSerializer = SoapSerializer.XmlSerializer;
        options.CaseInsensitivePath = true;
        options.WsdlFileOptions = null;
        options.IndentXml = true;
        options.OmitXmlDeclaration = false;
      });

    app.Run();
  }
}
