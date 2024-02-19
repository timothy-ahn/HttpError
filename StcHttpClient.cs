using ErrorOr;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsoleApp1;

public class StcHttpClient
{
  private readonly HttpClient _httpClient;

  public StcHttpClient(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<ErrorOr<TransactionResponse>> RechargeAsync()
  {
    var result = await HttpExtensions.SendAsync(_httpClient);

    if (result.IsError) return result.Errors;

    try
    {
      var data = await result.Value.Content.ReadFromJsonAsync<TransactionResponse>();
      if (data is null) 
        return JsonErrors.ParseError;

      if (data.Status == "success") return data;

      

      return data;
    }
    catch (JsonException)
    {
      return JsonErrors.ParseError;
    }
    catch
    {
      return Error.Unexpected();
    }
  }

  
}

public class TransactionResponse
{
  public string Status { get; set; }
  public string Error  { get; set; }
}