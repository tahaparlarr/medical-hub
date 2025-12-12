using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MedicalHub.Helpers;

[HtmlTargetElement(Attributes = "is-active-route")]
public class ActiveRouteTagHelper : TagHelper
{
    [HtmlAttributeName("asp-controller")]
    public string? Controller { get; set; }

    [HtmlAttributeName("asp-action")]
    public string? Action { get; set; }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; } = null!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext == null) return;

        string? currentController = ViewContext.RouteData.Values["Controller"]?.ToString();
        string? currentAction = ViewContext.RouteData.Values["Action"]?.ToString();

        bool controllerMatch = string.Equals(currentController, Controller, StringComparison.OrdinalIgnoreCase);
        bool actionMatch = string.Equals(currentAction, Action, StringComparison.OrdinalIgnoreCase);

        bool match = string.IsNullOrEmpty(Action) ? controllerMatch : (controllerMatch && actionMatch);

        var existingClasses = output.Attributes["class"]?.Value?.ToString() ?? "";

        if (match)
        {
            string activeClasses = " bg-white text-dark";
            output.Attributes.SetAttribute("class", $"{existingClasses}{activeClasses}");
        }
    }
}