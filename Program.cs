using ConsoleApp1;
using ErrorOr;


var httpClient = new HttpClient();

var result = await HttpExtensions.SendAsync(httpClient);;
var error = result.FirstError;

if (error == HttpErrors.TimeoutError)
{
  // provider unavailable
}

if (error == HttpErrors.CancelError)
{
  //
}

if (error == HttpErrors.ParsingError)
{
  // Provider invalid response
}

public partial class Program;
