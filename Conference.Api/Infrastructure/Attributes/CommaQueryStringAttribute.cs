using Conference.Api.Infrastructure.ValueProviders;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Conference.Api.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class CommaQueryStringAttribute : Attribute, IResourceFilter
{
    private readonly CommaQueryStringValueProviderFactory factory;

    public CommaQueryStringAttribute()
    {
        factory = new CommaQueryStringValueProviderFactory();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // will be implemented
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.ValueProviderFactories.Insert(0, factory);
    }
}