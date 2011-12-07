using System;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
            
        }

        public class when_attempting_to_add_a_negative_number : concern
        {
            Because of = () =>
                spec.catch_exception(() => sut.add(-2, 3));

            It should_throw_an_argument_exception = () =>
                spec.exception_thrown.ShouldBeAn<ArgumentException>();

            static int result;
        }

        public class when_adding_two_numbers : concern
        {
            Because of = () =>
                result = sut.add(2, 3);

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            static int result;
        }
    }
}
