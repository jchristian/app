using System;

namespace app.infrastructure.containers.basic
{
  public interface ICreateASingleDependency:ICreateAnDependency
  {
    bool can_create(Type type);
  }
}