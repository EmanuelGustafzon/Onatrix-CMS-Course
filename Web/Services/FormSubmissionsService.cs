using System.Diagnostics;
using Umbraco.Cms.Core.Services;
using Web.ViewModels;

namespace Web.Services;

public class FormSubmissionsService(IContentService ContentService)
{
    private readonly IContentService _contentService = ContentService;
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
        
}
