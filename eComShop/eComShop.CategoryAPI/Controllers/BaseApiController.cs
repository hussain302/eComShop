using eComShop.Infrastructure.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace eComShop.CategoryAPI.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase, IActionFilter
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ILogger _logger;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseApiController(IHttpContextAccessor httpContextAccessor, ILogger logger, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is Exception exception)
            {
                _logger.LogError($"Exception Message: {exception.Message}\n Inner Exception: {exception.InnerException}\n Stack Trace: {exception.StackTrace}");
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                context.ExceptionHandled = true;
                return;
            }
            string method = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            _logger.LogInformation($"{method} executed.");
            _unitOfWork.Dispose();
        }
    }
}