using app.web.core;

namespace app
{
  public class RequestMatchBuilder : IBuildRequestMatches
  {
    IFindARequestMatcher request_matcher_registry;

    public RequestMatchBuilder(IFindARequestMatcher request_matcher_registry)
    {
      this.request_matcher_registry = request_matcher_registry;
    }

    public RequestMatcher made_for<T>()
    {
      return request_matcher_registry.find_a_request_for<T>();
    }
  }
}