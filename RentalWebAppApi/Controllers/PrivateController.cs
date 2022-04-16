using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RentalWebAppApi.Exceptions;
using RentalWebService.DTOs;

namespace RentalWebAppApi.Controllers
{
    [EnableCors("AllowAllOrigins")]
    public class PrivateController : ControllerBase
    {

        [NonAction]
        public System.Security.Claims.ClaimsPrincipal CurrentUser()
        {
            return HttpContext.User;
        }

        [NonAction]
        public Int64? CompanyId()
        {
            var currentUser = CurrentUser();
            if (CurrentUser().HasClaim(c => c.Type == "companyId"))
            {
                return Convert.ToInt64(currentUser.Claims.FirstOrDefault(c => c.Type == "companyId").Value);
            }
            else return null;
        }

        [NonAction]
        public Int64? BranchId()
        {
            var currentUser = CurrentUser();
            if (currentUser.HasClaim(c => c.Type == "branchId"))
            {
                return Convert.ToInt64(currentUser.Claims.FirstOrDefault(c => c.Type == "companyId").Value);
            }
            else return null;
        }

        [NonAction]
        public Int64? UserId()
        {
            var currentUser = CurrentUser();
            if (currentUser.HasClaim(c => c.Type == "userId"))
            {
                return Convert.ToInt64(currentUser.Claims.FirstOrDefault(c => c.Type == "userId").Value);
            }
            else return null;
        }
        [NonAction]
        public string Ip()
        {
            return null;
        }

        [NonAction]
        public ResponseDto GetFluentValidationResponse(ValidationResult validationResult)
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = false;
            responseDto.Message = ExceptionHandler.GetFluentValidationErrorDetails(validationResult);
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetExeceptionResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = false;
            responseDto.Message = "An unexpected error occured";
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetNotFoundResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = false;
            responseDto.Message = "No record/s found";
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetAuthorizeResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = false;
            responseDto.Message = "Authentication failed";
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetNotSavedResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = false;
            responseDto.Message = "Unable to save record/s at this time";
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetSavedResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = true;
            responseDto.Message = "Record/s saved successfully";
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetUpdatedResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = true;
            responseDto.Message = "Record/s updated successfully";
            return responseDto;
        }
        [NonAction]
        public ResponseDto GetOkResponse()
        {
            ResponseDto responseDto = new ResponseDto();
            responseDto.Status = true;
            responseDto.Message = "Ok";
            return responseDto;
        }
    }
}