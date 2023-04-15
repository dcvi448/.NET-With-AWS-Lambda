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
    public async Task<string> FunctionHandler(ILambdaContext context)
    {
       //await to do something
       return string.Empty;
    }

}
