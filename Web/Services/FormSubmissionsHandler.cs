using System.Diagnostics;
using Umbraco.Cms.Core.Services;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services;

public class FormSubmissionsHandler(IContentService ContentService, IEmailhandler emailHandler)
{
    private readonly IContentService _contentService = ContentService;
    private readonly IEmailhandler _emailHandler = emailHandler;
    public bool SaveCallBackRequest(CallBackFormViewModel viewModel)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "callBackFormSubmissions");
            if (container is null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {viewModel.Name}";
            var req = _contentService.Create(requestName, container, "callBackRequest");

            req.SetValue("callBackRequestName", viewModel.Name);
            req.SetValue("callBackRequestEmail", viewModel.Email);
            req.SetValue("callBackRequestPhone", viewModel.PhoneNumber);
            req.SetValue("callBackRequestOption", viewModel.SelectOption);

            var saveResult = _contentService.Save(req);

            _emailHandler.SendEmailConfirmation(viewModel.Email);

            return saveResult.Success;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool SaveQuestionRequest(QuestionFormViewModel viewModel)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "questionFormSubmissions");
            if (container is null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {viewModel.Name}";
            var req = _contentService.Create(requestName, container, "questionRequest");

            req.SetValue("questionRequestName", viewModel.Name);
            req.SetValue("questionRequestEmail", viewModel.Email);
            req.SetValue("questionRequestMessage", viewModel.Message);

            var saveResult = _contentService.Save(req);

            _emailHandler.SendEmailConfirmation(viewModel.Email);

            return saveResult.Success;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public bool SaveSupportRequest(SupportFormViewModel viewModel)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "supportFormSubmissions");
            if (container is null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {viewModel.Email}";
            var req = _contentService.Create(requestName, container, "supportRequest");

            req.SetValue("supportRequestEmail", viewModel.Email);

            var saveResult = _contentService.Save(req);

            _emailHandler.SendEmailConfirmation(viewModel.Email);

            return saveResult.Success;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }
}
