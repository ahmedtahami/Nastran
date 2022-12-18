using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Nastran.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class ValidationError
    {

        public string PropertyName = "";
        public string[] ErrorList = null;

        public static List<ValidationError> GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = (from m in modelState
                          select
                             new ValidationError
                             {
                                 PropertyName = m.Key,
                                 ErrorList = (from msg in m.Value.Errors
                                              select msg.ErrorMessage).ToArray()
                             })
                                .ToList();
            return errors;
        }
    }
}