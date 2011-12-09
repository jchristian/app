namespace app.web.core
{
    public interface IBuildRequestMatches
    {
        RequestMatcher made_for<T>();
    }
}