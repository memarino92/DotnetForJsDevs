#:sdk Microsoft.NET.Sdk.Web

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/hello", (HttpContext ctx) =>
    Results.Json(
        new HelloResponse { Message = "Hello, world!" },
        HelloResponseJsonContext.Default.HelloResponse
    )
);

app.Run();

public class HelloResponse
{
    public required string Message { get; set; }
}

[JsonSerializable(typeof(HelloResponse))]
public partial class HelloResponseJsonContext : JsonSerializerContext
{
}
