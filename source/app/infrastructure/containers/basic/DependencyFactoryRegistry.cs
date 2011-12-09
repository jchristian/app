using System;
using System.Collections.Generic;
using System.Linq;

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
      var matching_factory = factories.FirstOrDefault(x => x.can_create(dependency));
      if (matching_factory == null)
      {
        throw exception_factory(dependency);
      }
      return matching_factory;
    }
  }
}