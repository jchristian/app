using System.Data;
using System.Reflection;
using app.infrastructure.containers;
using app.infrastructure.containers.basic;
using app.specs.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(AutomaticDependencyFactory))]
  public class AutomaticDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateAnDependency,
                                      AutomaticDependencyFactory>
    {
    }

    public class when_creating_an_item : concern
    {
      Establish c = () =>
      {
        constructor_selection_strategy = depends.on<IPickTheConstructorForAType>();
        container = depends.on<IFetchDependencies>();
        depends.on(typeof(OurItemWithLotsOfDependencies));

        the_reader = fake.an<IDataReader>();
        the_connection = fake.an<IDbConnection>();
        the_other = fake.an<Other>();

        the_greediest_ctor = ObjectFactory.expressions.to_target<OurItemWithLotsOfDependencies>()
          .get_ctor(() => new OurItemWithLotsOfDependencies(null, null, null));

        constructor_selection_strategy.setup(x => x.get_the_applicable_ctor_for(typeof(OurItemWithLotsOfDependencies)))
          .Return(the_greediest_ctor);

        container.setup(x => x.a(typeof(IDbConnection))).Return(the_connection);
        container.setup(x => x.a(typeof(IDataReader))).Return(the_reader);
        container.setup(x => x.a(typeof(Other))).Return(the_other);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_with_all_of_its_dependencies_satisfied = () =>
      {
        var item = result.ShouldBeAn<OurItemWithLotsOfDependencies>();
        item.reader.ShouldEqual(the_reader);
        item.connection.ShouldEqual(the_connection);
        item.other.ShouldEqual(the_other);
      };

      static object result;
      static IDataReader the_reader;
      static IDbConnection the_connection;
      static Other the_other;
      static IFetchDependencies container;
      static IPickTheConstructorForAType constructor_selection_strategy;
      static ConstructorInfo the_greediest_ctor;
    }

    public class OurItemWithLotsOfDependencies
    {
      public IDataReader reader;
      public IDbConnection connection;

      public OurItemWithLotsOfDependencies(IDataReader reader, IDbConnection connection, Other other)
      {
        this.reader = reader;
        this.connection = connection;
        this.other = other;
      }

      public Other other;

      public OurItemWithLotsOfDependencies(IDataReader reader, IDbConnection connection)
      {
        this.reader = reader;
        this.connection = connection;
      }

      public OurItemWithLotsOfDependencies(IDataReader reader)
      {
        this.reader = reader;
      }
    }

    public class Other
    {
    }
  }
}