using System;
using System.Collections.Generic;

namespace app.infrastructure.containers.basic
{
  public class DependencyFactoryRegistry : IFindDependencyFactories
  {
    IEnumerable<ICreateASingleDependency> factories;
    MissingDependencyFactoryException exception_factory;

    public DependencyFactoryRegistry(IEnumerable<ICreateASingleDependency> factories,
                                     MissingDependencyFactoryException exception_factory)
    {
      this.factories = factories;
      this.exception_factory = exception_factory;
    }

    public ICreateASingleDependency get_factory_that_can_create(Type dependency)
    {
      return factories.first_or_throw(x => x.can_create(dependency), exception_factory(dependency));
    }
  }
}