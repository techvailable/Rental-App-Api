using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebAppApi.Exceptions
{
    public class ExceptionHandler
    {
        public static string GetExceptionMessage(System.Exception exception)
        {
            try
            {
                if (exception == null)
                    throw new ArgumentNullException("ex");

                StringBuilder sb = new StringBuilder();

                while (exception != null)
                {
                    if (!string.IsNullOrEmpty(exception.Message))
                    {
                        if (sb.Length > 0)
                            sb.AppendLine();

                        sb.Append(exception.Message);
                    }

                    exception = exception.InnerException;
                }

                return sb.ToString();
            }
            catch (System.Exception ex)
            {
                return ex.Message;//don't change it
            }
        }

        public static string GetFluentValidationErrorDetails(ValidationResult validationResult)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (var error in validationResult.Errors)
                {
                    sb.Append(error);
                    sb.Append("<br/>");
                }
                return sb.ToString();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
