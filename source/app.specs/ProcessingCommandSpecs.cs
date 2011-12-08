using System.Collections.Generic;
using app.web.application;
using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ProcessingCommand))]
  public class ProcessingCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      ProcessingCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsForACommand>();
        depends.on<RequestMatch>(x => true);
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_make_its_determination_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static IProvideDetailsForACommand request;
      static bool result;
      static bool expected;
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsForACommand>();
        application_feature = depends.on<ISupportAStory>();
      };

      Because b = () =>
        sut.run(request);

      It should_run_the_application_feature = () =>
        application_feature.received(x => x.run(request));

      static IProvideDetailsForACommand request;
      static ISupportAStory application_feature;
    }
  }

  [Subject(typeof(Create))]
  public class CreateSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_creating_a_stub_department_repository
    {
      Because b = () =>
        result = Create.a_stud_department_repository();

      It should_return_a_stub_department_repository = () =>
        result.ShouldBeOfType<StubDepartmentRepository>();

      static IFindDepartments result;
    }

    public class when_creating_a_stub_display_engine
    {
      Because b = () =>
        result = Create.a_stub_display_engine();

      It should_return_a_stub_department_repository = () =>
        result.ShouldBeOfType<StubDisplayEngine>();

      static IDisplayReports result;
    }

    public class when_creating_a_stub_missing_command
    {
      Because b = () =>
        result = Create.a_stub_missing_command();

      It should_return_a_stub_department_repository = () =>
        result.ShouldBeOfType<StubMissingCommand>();

      static IProcessOneRequest result;
    }

    public class when_creating_a_stub_request
    {
      Because b = () =>
        result = Create.a_stub_request_factory();

      It should_return_a_stub_department_repository = () =>
        result.ShouldBeOfType<StubRequestFactory>();

      static ICreateControllerRequests result;
    }

    public class when_creating_a_stub_set_of_commands
    {
      Because b = () =>
        result = Create.a_stub_set_of_commands();

      It should_return_a_stub_department_repository = () =>
        result.ShouldBeOfType<StubSetOfCommands>();

      static IEnumerable<IProcessOneRequest> result;
    }
  }
}