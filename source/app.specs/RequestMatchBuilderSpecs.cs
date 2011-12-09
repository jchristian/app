using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{

  [Subject(typeof(RequestMatchBuilder))]
  public class RequestMatchBuilderSpecs
  {
    public abstract class concern : Observes<IBuildRequestMatches, RequestMatchBuilder>
    {
    }

    public class when_building_a_request_matcher_for_a_request : concern
    {
      Establish c = () =>
      {
        request_matcher = fake.an<RequestMatcher>();

        var request_matcher_registry = depends.on<IFindARequestMatcher>();
        request_matcher_registry.setup(x => x.find_a_request_for<OurRequest>()).Return(request_matcher);
      };

      Because of = () =>
        results = sut.made_for<OurRequest>();

      It should_return_the_right_request_matcher = () =>
        results.ShouldEqual(request_matcher);

      static RequestMatcher results;
      static RequestMatcher request_matcher;
    }
  }

  class OurRequest
  {
  }
}