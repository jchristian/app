using System;

namespace app.infrastructure.containers.basic
{
  public interface IMatchADependencyType
  {
    bool matches(Type type);
  }
}