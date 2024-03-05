using Microsoft.AspNetCore.Mvc;
using Prueba.Models.DTOs;

namespace Prueba.Validators
{
    public class CustomValidationErrorDetail
    {
        public static APIErrorResponseDTO response { get; set; } = new APIErrorResponseDTO();
        public static IActionResult MakeValidationResponse(ActionContext context)
        {
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            };
            foreach (var keyModelStatePair in context.ModelState)
            {
                var errors = keyModelStatePair.Value.Errors;

                if (errors.Count > 0 && errors.Last() != null)
                {
                    response.Error = errors.Last().ErrorMessage;
                }
            }

            response.TraceId = context.HttpContext.TraceIdentifier;
            
            var result = new BadRequestObjectResult(response);

            result.ContentTypes.Add("application/problem+json");

            return result;
        }

    }
}
