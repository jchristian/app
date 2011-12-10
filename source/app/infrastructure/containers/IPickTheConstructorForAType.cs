﻿using System;
using System.Linq;
using System.Reflection;

namespace app.infrastructure.containers
{
  public interface IPickTheConstructorForAType
  {
    ConstructorInfo get_the_applicable_ctor_for(Type type);
  }

  public class GreedyConstructorPicker : IPickTheConstructorForAType
  {
    public ConstructorInfo get_the_applicable_ctor_for(Type type)
    {
      return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
    }
  }
}