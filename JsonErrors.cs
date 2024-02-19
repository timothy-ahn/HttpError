using ErrorOr;

namespace ConsoleApp1;

public class JsonErrors
{
  public static Error ParseError => Error.Failure("JsonError.Parse");
}
