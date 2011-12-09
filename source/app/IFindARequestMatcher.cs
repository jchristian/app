using app.web.core;

namespace app
{
  public interface IFindARequestMatcher
  {
    RequestMatcher find_a_request_for<T>();
  }
}