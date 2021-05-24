using Microsoft.AspNetCore.Mvc;
using System;

namespace SuppressMapClientErrorsIssue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupressMapClientErrorsController : ControllerBase
    {
        [HttpPost("BadRequest")]
        public IActionResult PostBadRequest()
        {
            return BadRequest();
        }


        [HttpGet("NotFound")]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("InternalServerError")]
        public IActionResult GetInternalServerError()
        {
            throw new InvalidOperationException("Returns non-encapsulated 500");
        }

        [HttpGet("Unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpPost("UnprocessableEntity")]
        public IActionResult PostUnprocessableEntity()
        {
            return UnprocessableEntity();
        }

        [HttpPost("ValidationBadRequest")]
        public IActionResult PostValidationBadRequest()
        {
            ModelState.AddModelError("", "Returns non-ProblemDetails no matter of the SuppressMapClientErrors settings");

            return BadRequest(ModelState);
        }

        [HttpPost("ValidationProblem")]
        public IActionResult PostValidationProblem()
        {
            ModelState.AddModelError("", "Returns non-ProblemDetails no matter of the SuppressMapClientErrors settings");

            return ValidationProblem(ModelState);
        }

        [HttpPost("ValidationUnprocessableEntity")]
        public IActionResult PostValidationUnprocessableEntity()
        {
            ModelState.AddModelError("", "Returns ProblemDetails no matter of the SuppressMapClientErrors settings");

            return UnprocessableEntity(ModelState);
        }
    }
}
