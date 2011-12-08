using System.Collections.Generic;
using app.web.application;
using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app
{
  public class Create
  {
    public static IFindDepartments a_stud_department_repository()
    {
      return new StubDepartmentRepository();
    }

    public static IDisplayReports a_stub_display_engine()
    {
      return new StubDisplayEngine();
    }

    public static IProcessOneRequest a_stub_missing_command()
    {
      return new StubMissingCommand();
    }

    public static IEnumerable<IProcessOneRequest> a_stub_set_of_commands()
    {
      return new StubSetOfCommands();
    }

    public static ICreateControllerRequests a_stub_request_factory()
    {
      return new StubRequestFactory();
    }
  }
}