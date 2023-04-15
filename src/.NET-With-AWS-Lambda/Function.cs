using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using HtmlAgilityPack;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace _NET_With_AWS_Lambda;


public class Function
{

    private static readonly HttpClient _httpClient = new HttpClient();
    private const string _url = "";
    public async Task<string> FunctionHandler(ILambdaContext context)
    {
        var html = await _httpClient.GetStringAsync(_url);

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var tables = doc.DocumentNode.SelectNodes("//table//tbody");

        var result = new List<Dictionary<string, string>>();

        foreach (var table in tables)
        {
            var rows = table.SelectNodes("tr");

            foreach (var row in rows)
            {
                var cells = row.SelectNodes("td");

                if (cells != null && cells.Count > 1)
                {
                    var rowDict = new Dictionary<string, string>();
                    rowDict.Add(cells[0].InnerText.Trim(), cells[1].InnerText.Trim());
                    result.Add(rowDict);
                }
            }
        }

        return JsonConvert.SerializeObject(result);
    }

}
