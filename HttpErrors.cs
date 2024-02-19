using ErrorOr;

namespace ConsoleApp1;

public static class HttpErrors
{
  public static Error TimeoutError => Error.Failure("Http.Timeout", "Http connection timeout");
  public static Error ConnectionError => Error.Failure("Http.Connection", "Http connection failed");
  public static Error CancelError => Error.Failure("Http.Cancel", "Http cancel");
  public static Error ParsingError => Error.Failure("Http.Parsing");
  
}
