using System;
using app.web.core;

namespace app
{
    public class IncomingRequest
    {
        public static RequestResolver request_match_resolver = () =>
        {
          throw new NotImplementedException("This needs to be configured by a startup process");
        };

        public static IBuildRequestMatches was
        {
            get { return request_match_resolver.Invoke(); }
        }
    }

    public delegate IBuildRequestMatches RequestResolver();
}