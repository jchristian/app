using System;
using System.Linq;

namespace app.infrastructure.containers.basic
{
  public class AutomaticDependencyFactory:ICreateAnDependency
  {
    IPickTheConstructorForAType constructor_picker;
    IFetchDependencies dependency_registry;
    Type creation_type;

    public AutomaticDependencyFactory(IPickTheConstructorForAType constructor_picker, IFetchDependencies dependency_registry, Type creation_type)
    {
      this.constructor_picker = constructor_picker;
      this.dependency_registry = dependency_registry;
      this.creation_type = creation_type;
    }

    public object create()
    {
      var the_applicable_ctor = constructor_picker.get_the_applicable_ctor_for(creation_type);
      var parameters = the_applicable_ctor.GetParameters().Select(x => dependency_registry.a(x.ParameterType)).ToArray();

      return the_applicable_ctor.Invoke(parameters);
    }
  }
}