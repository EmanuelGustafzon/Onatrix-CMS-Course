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
            var contaienr = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "callBackFormSubmissions");
            if (contaienr is null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {viewModel.Name}";
            var req = _contentService.Create(requestName, contaienr, "callBackRequest");

            req.SetValue("callBackRequestName", viewModel.Name);
            req.SetValue("callBackRequestEmail", viewModel.Email);
            req.SetValue("callBackRequestPhone", viewModel.PhoneNumber);
            req.SetValue("callBackRequestOption", viewModel.SelectOption);

            var saveResult = _contentService.Save(req);

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
            var contaienr = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "questionFormSubmissions");
            if (contaienr is null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {viewModel.Name}";
            var req = _contentService.Create(requestName, contaienr, "questionRequest");

            req.SetValue("questionRequestName", viewModel.Name);
            req.SetValue("questionRequestEmail", viewModel.Email);
            req.SetValue("questionRequestPhone", viewModel.Message);

            var saveResult = _contentService.Save(req);

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
            var contaienr = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "supportFormSubmissions");
            if (contaienr is null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {viewModel.Email}";
            var req = _contentService.Create(requestName, contaienr, "supportRequest");

            req.SetValue("supportRequestEmail", viewModel.Email);

            var saveResult = _contentService.Save(req);

            return saveResult.Success;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

}
