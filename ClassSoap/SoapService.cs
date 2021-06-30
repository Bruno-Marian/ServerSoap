using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassSoap
{
    public class SoapService
    {
        public static async Task<string> CalculaTaxa(double vlCarta, double taxa, int meses)
        {
            var body = new StringBuilder();
            body.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            body.AppendLine(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">");
            body.AppendLine(@"<soap:Body>");
            body.AppendLine(@"<CalcTaxa xmlns=""http://tempuri.org/"">");
            body.AppendLine($@"<pValorCarta>{vlCarta}</pValorCarta>");
            body.AppendLine($@"<pTaxa>{taxa}</pTaxa>");
            body.AppendLine($@"<pPrazo>{meses}</pPrazo>");
            body.AppendLine(@"</CalcTaxa>");
            body.AppendLine(@"</soap:Body>");
            body.AppendLine(@"</soap:Envelope>");

            var request = new HttpClient();
            var bodyStr = body.ToString();
            var response = await request.PostAsync("http://localhost:5000/mathservice.asmx", new StringContent(bodyStr, Encoding.UTF8, "application/xml"));

            var responseData = await response.Content.ReadAsStringAsync();

            var document = new XmlDocument();
            document.LoadXml(responseData);

            return document.InnerText;
        }
    }
}
