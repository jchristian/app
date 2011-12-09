 using Machine.Specifications;
 using app.infrastructure.containers.basic;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(SingleDependencyFactory))]  
  public class SingleDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateASingleDependency,
                                      SingleDependencyFactory>
    {
        
    }

   
    public class when_creating_the_dependency : concern
    {
      Establish c = () =>
      {
        the_item =  new object();
        actual_factory = depends.on<ICreateAnDependency>();
        actual_factory.setup(x => x.create()).Return(the_item);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_created_by_the_actual_item_factory = () =>
        result.ShouldEqual(the_item);

      static object result;
      static object the_item;
      static ICreateAnDependency actual_factory;
    }
    public class when_determining_if_it_can_create_a_type : concern
    {
      Establish c = () =>
      {
        type_specification = depends.on<IMatchADependencyType>();
        type_specification.setup(x => x.matches(typeof(int))).Return(true);
      };

      Because b = () =>
        result = sut.can_create(typeof(int));

      It should_make_its_decision_by_using_its_type_criteria = () =>
        result.ShouldBeTrue();

      static bool result;
      static IMatchADependencyType type_specification;
    }
  }
}
