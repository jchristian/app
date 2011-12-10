using System;
using System.Reflection;
using Machine.Specifications;
using app.infrastructure.containers;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(GreedyConstructorPicker))]
  public class GreedyConstructorPickerSpecs
  {
    public abstract class concern : Observes<IPickTheConstructorForAType,
                                      GreedyConstructorPicker>
    {
    }

    public class when_selecting_the_constructor_with_the_most_parameters : concern
    {
      Establish c = () =>
      {
        ctor_with_most_parameters = fake.an<ConstructorInfo>();
        ctor_with_most_parameters.setup(x => x.GetParameters()).Return(new[] {fake.an<ParameterInfo>()});

        var constructor_info_with_no_parameters = fake.an<ConstructorInfo>();
        constructor_info_with_no_parameters.setup(x => x.GetParameters()).Return(new ParameterInfo[] { });

        the_type = fake.an<Type>();
        the_type.setup(x => x.GetConstructors()).Return(new[] {constructor_info_with_no_parameters, ctor_with_most_parameters});
      };

      Because of = () =>
        ctor_info = sut.get_the_applicable_ctor_for(the_type);

      It should_return_the_constructor_info_with_the_most_parameters = () =>
        ctor_info.ShouldEqual(ctor_with_most_parameters);

      static ConstructorInfo ctor_with_most_parameters;
      static ConstructorInfo ctor_info;
      static Type the_type;
    }
  }
}