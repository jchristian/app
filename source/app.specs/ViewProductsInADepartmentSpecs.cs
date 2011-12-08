using System;
using System.Collections.Generic;
using app.web.application;
using app.web.application.models;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewProductsInADepartment))]
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      static IDisplayReports display_engine;
      static IProvideDetailsForACommand request;
      static ProductItem product_item;

      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        var product_repository = depends.on<IFindStoreInformation>();
        department_item = fake.an<DepartmentItem>();

        request = fake.an<IProvideDetailsForACommand>();
        request.setup(x => x.map<DepartmentItem>()).Return(department_item);
        product_list = new List<ProductItem> {new ProductItem()};

        product_repository.setup(x => x.all_products_in(department_item)).Return(product_list);
      };

      Because of = () => sut.run(request);

      It should_display_the_products_for_the_department = () =>
        display_engine.received(x => x.display(product_list));

      static DepartmentItem department_item;
      static IEnumerable<ProductItem> product_list;
    }
  }

  public class ViewStoreInformationSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewStoreInformation<InformationStub>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        query_executer = depends.on<IExecuteQueries<InformationStub>>();
        display_engine = depends.on<IDisplayReports>();
        var query = depends.on<Func<IFindStoreInformation, InformationStub>>();

        information = fake.an<InformationStub>();

        request = fake.an<IProvideDetailsForACommand>();
        query_executer.setup(x => x.execute(query, request)).Return(information);

        new ViewStoreInformation<IEnumerable<ProductItem>>(display_engine, query_executer, x => x.all_products_in())
      };
      
      Because of = () =>
        sut.run(request);

      It should_display_the_requested_information = () =>
        display_engine.received(x => x.display(information));

      static IDisplayReports display_engine;
      static InformationStub information;
      static IProvideDetailsForACommand request;
      static IExecuteQueries<InformationStub> query_executer;
    }
  }

  public class InformationStub
  {
  }

  public interface IExecuteQueries<InformationType>
  {
    InformationType execute(Func<IFindStoreInformation, InformationType> query, IProvideDetailsForACommand request);
  }

  public class ExecuteQueries<InformationType> : IExecuteQueries<InformationType>
  {
    IFindStoreInformation store_repository;

    public ExecuteQueries(IFindStoreInformation store_repository)
    {
      this.store_repository = store_repository;
    }

    public InformationType execute(Func<IFindStoreInformation, InformationType> query, IProvideDetailsForACommand request)
    {
      return query(store_repository);
    }
  }

  public class ViewStoreInformation<InformationType> : ISupportAStory
  {
    IDisplayReports display_engine;
    IExecuteQueries<InformationType> information_getter;
    Func<IFindStoreInformation, InformationType> query;

    public ViewStoreInformation(IDisplayReports display_engine, IExecuteQueries<InformationType> information_getter, Func<IFindStoreInformation, InformationType> query)
    {
      this.display_engine = display_engine;
      this.information_getter = information_getter;
      this.query = query;
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(information_getter.execute(query, request));
    }
  }
}