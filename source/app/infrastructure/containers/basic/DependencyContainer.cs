using System;

namespace app.infrastructure.containers.basic
{
  public class DependencyContainer :IFetchDependencies
  {
    IFindDependencyFactories dependency_finder;

      public DependencyContainer(IFindDependencyFactories dependency_finder)
      {
          this.dependency_finder = dependency_finder;
      }

      public Dependency a<Dependency>()
      {
        Dependency dependency;

        try
        {
          dependency = (Dependency)dependency_finder.get_factory_that_can_create(typeof(Dependency)).create();
        }
        catch (Exception e)
        {
          throw new DependencyCreationException(e, typeof(Dependency));
        }
        return dependency;
      }
  }
}