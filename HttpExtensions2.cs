using OneOf;

namespace ConsoleApp1;

public static class HttpExtensions2
{
  public static async
    Task<OneOf<HttpResponseMessage, ConnectionError, TimeoutError, CancelError, UnknownError>>
    SendAsync(HttpClient http, CancellationToken cancellationToken = default)
  {
		try
		{
      return await http.SendAsync(new(), cancellationToken);
		}
    catch (HttpRequestException)
    {
      return new ConnectionError();
    }
    catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
    {
      return new TimeoutError();
    }
    catch (TaskCanceledException)
    {
      return new CancelError();
    }
    catch (Exception)
		{
      return new UnknownError();
		}
  }
}

public record CancelError();
public record TimeoutError();
public record ConnectionError();
public record UnknownError();
