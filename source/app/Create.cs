using app.web.application;

namespace app
{
  public class Create<StubType>
  {
    public static IFindDepartments a<StubType>() where StubType : new()
    {
      new StubType();
    }
  }
}