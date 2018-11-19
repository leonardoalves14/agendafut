using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace SocietyAgendor.UI.Service
{
    public static class ModelStateInvalidError
    {
        public static string Message(ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            foreach (var item in modelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    errors.Add(item.Key + ": " + item.Value.Errors[0].ErrorMessage);
                }
            }

            return string.Join(", ", errors.ToArray());
        }
    }
}
