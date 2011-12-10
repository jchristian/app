using System;
using System.Collections.Generic;
using System.Linq;
using app.infrastructure;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_retrieving_the_first_item_that_matches_a_condition : concern
    {
      public class and_it_has_the_item
      {
        Establish c = () =>
        {
          numbers = Enumerable.Range(1, 10).ToList();
        };
        Because b = () =>
          result = EnumerableExtensions.first_or_throw(numbers, x => x > 3,null);

        It should_return_the_first_item_matching_the_condition = () =>
          result.ShouldEqual(4);

        static int result;
        static int first_number;
        static IList<int> numbers;
      }
      public class and_it_does_not_have_the_item
      {
        Establish c = () =>
        {
          numbers = Enumerable.Range(1, 10).ToList();
          the_exception = new Exception();
        };

        Because b = () =>
          spec.catch_exception(() => EnumerableExtensions.first_or_throw(numbers, x => x < 0, the_exception));

        It should_throw_the_exception_provided = () =>
          spec.exception_thrown.ShouldEqual(the_exception);

        static int result;
        static int first_number;
        static IList<int> numbers;
        static Exception the_exception;
      }
        
    }
  }
}
