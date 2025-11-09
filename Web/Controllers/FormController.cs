using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers;

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, 
    IUmbracoDatabaseFactory databaseFactory, 
    ServiceContext services, 
    AppCaches appCaches, 
    IProfilingLogger profilingLogger, 
    IPublishedUrlProvider publishedUrlProvider, 
    FormSubmissionsHandler formSubmissionsHandler) 
    : SurfaceController(umbracoContextAccessor, 
        databaseFactory, 
        services, 
        appCaches, 
        profilingLogger, 
        publishedUrlProvider)
{
    private readonly FormSubmissionsHandler _formSubmissionsHandler = formSubmissionsHandler;

    public IActionResult HandleCallBackForm(CallBackFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();
        try
        {
            var result = _formSubmissionsHandler.SaveCallBackRequest(viewModel);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong while submitting your request, Please try again later";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you for your request, we will reach out to you soon!";
            return RedirectToCurrentUmbracoPage();

        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            TempData["FormError"] = "Something went wrong while submitting your request, Please try again later";
            return CurrentUmbracoPage();
        }
    }
    
    public IActionResult HandleQuestionForm(QuestionFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();
        try
        {
            var result = _formSubmissionsHandler.SaveQuestionRequest(viewModel);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong while submitting your request, Please try again later";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you for your request, we will reach out to you soon!";
            return RedirectToCurrentUmbracoPage();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            TempData["FormError"] = "Something went wrong while submitting your request, Please try again later";
            return CurrentUmbracoPage();
        }
    }

    public IActionResult HandleSupportForm(SupportFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return CurrentUmbracoPage();
        try
        {
            var result = _formSubmissionsHandler.SaveSupportRequest(viewModel);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong while submitting your request, Please try again later";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you for your request, we will reach out to you soon!";
            return RedirectToCurrentUmbracoPage();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            TempData["FormError"] = "Something went wrong while submitting your request, Please try again later";
            return CurrentUmbracoPage();
        }
    }
}
