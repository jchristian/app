namespace app.infrastructure.containers.basic
{
  public class DependencyContainer :IFetchDependencies
  {
    IFindDependencyFactories dependency_factory_registry;

    public DependencyContainer(IFindDependencyFactories dependency_factory_registry)
    {
      this.dependency_factory_registry = dependency_factory_registry;
    }

    public Dependency a<Dependency>()
    {
      return (Dependency)dependency_factory_registry.get_factory_that_can_create(typeof(Dependency)).create();
    }
  }
}