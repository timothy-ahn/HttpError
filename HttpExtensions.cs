using ErrorOr;

namespace ConsoleApp1;

public static class HttpExtensions
{
  public static async Task<ErrorOr<HttpResponseMessage>> SendAsync(
		HttpClient httpClient, 
		CancellationToken cancellationToken = default)
  {
		try
		{
			return await httpClient.SendAsync(new HttpRequestMessage(), cancellationToken);
		}
		catch (HttpRequestException)
		{
			return HttpErrors.ConnectionError;
		}
		catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
		{
			return HttpErrors.TimeoutError;
		}
		catch (TaskCanceledException)
		{
			return HttpErrors.CancelError;
		}
		catch
		{
			return Error.Unexpected();
		}
  }
}
