using CA.MVC.Contracts;
using System.Net.Http.Headers;

namespace CA.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected ResponseApi<Guid> ConvertApiExceptions<Guid>(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new ResponseApi<Guid>() { Message = "Validation Errors have occured", ValidationErrors = exception.Response, Success = false };
            }
            else if (exception.StatusCode == 404)
            {
                return new ResponseApi<Guid>() { Message = "Not found", Success = false };
            }

            return new ResponseApi<Guid>() { Message = "Something went wrong, try again...", Success = false };
        }
        protected void AddBearerToken()
        {
            if (_localStorageService.Exist("token"))
            {
                // Bearer bayad hatman va hatman bashad
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
