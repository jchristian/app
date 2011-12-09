using System;

namespace app.infrastructure.containers.basic
{
  public class SingleDependencyFactory : ICreateASingleDependency
  {
    IMatchADependencyType type_specification;
    ICreateAnDependency real_factory;

    public SingleDependencyFactory(IMatchADependencyType type_specification, ICreateAnDependency real_factory)
    {
      this.type_specification = type_specification;
      this.real_factory = real_factory;
    }

    public object create()
    {
      return real_factory.create();
    }

    public bool can_create(Type type)
    {
      return type_specification.matches(type);
    }
  }
}