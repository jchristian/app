using Machine.Specifications;
using app.infrastructure;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(EnumerableExtensions))]
  public class StringExtensionSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_formatting_a_string : concern
    {
      Because of = () =>
        formatted_string = "test {0}".format("this");

      It should_format_the_string_with_the_arguments = () =>
        formatted_string.ShouldEqual("test this");

      static string formatted_string;
    }
  }
}