// See https://aka.ms/new-console-template for more information
using SlowStreaming;
using System.Diagnostics;
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");

SlowStream stream = new SlowStream("C:\\Users\\NBGCT87\\Downloads\\BingWallpaper.exe");

using HttpClient client = new HttpClient();

//using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7250/Requests");
using var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7250/Requests/Stream");

var streamContent = new StreamContent(stream);
streamContent.Headers.ContentType = new("application/octet-stream");

var stringContent = new StringContent("Hier");
stringContent.Headers.ContentType = new("application/json");

var content = new MultipartFormDataContent
{
      {new StreamContent(stream), "data", "fileName.exe" },
      {new StringContent("Hier"), "Municipality"},
};
request.Content = content;
Console.WriteLine("Starting send");
var result = await client.SendAsync(request);

Debug.WriteLine("done, press any key to exit");
Console.Read();