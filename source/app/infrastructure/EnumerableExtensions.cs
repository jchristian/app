using System;
using System.Collections.Generic;
using System.Linq;

namespace app.infrastructure
{
  public static class EnumerableExtensions
  {
    public static Item first_or_throw<Item>(this IEnumerable<Item> items,Func<Item,bool> condition ,Exception to_throw)
    {
      try
      {
        return items.First(condition);
      }
      catch
      {
        throw to_throw;
      }
    }
  }
}