using System;
using System.Reflection;

namespace app.infrastructure.containers
{
  public interface IPickTheConstructorForAType
  {
    ConstructorInfo get_the_applicable_ctor_for(Type type);
  }
}