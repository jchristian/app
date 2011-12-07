using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> requests_processors;

    public CommandRegistry(IEnumerable<IProcessOneRequest> requests_processors)
    {
      this.requests_processors = requests_processors;
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsForACommand request)
    {
      return requests_processors.Single(x => x.can_handle(request));
    }
  }
}