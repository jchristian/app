namespace app.web.core
{
  public class ProcessingCommand : IProcessOneRequest
  {
    RequestMatcher request_criteria;
    ISupportAStory feature;

    public ProcessingCommand(RequestMatcher request_criteria, ISupportAStory feature)
    {
      this.request_criteria = request_criteria;
      this.feature = feature;
    }

    public void run(IProvideDetailsForACommand request)
    {
      feature.run(request);
    }

    public bool can_handle(IProvideDetailsForACommand request)
    {
      return request_criteria(request);
    }
  }
}