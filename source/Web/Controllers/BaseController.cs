using DotNetCore.AspNetCore;
using DotNetCore.Results;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web
{
    public abstract class BaseController : ControllerBase
    {
        public static IActionResult Result(IResult result)
        {
            return ApiResult.Create(result);
        }

        public static IActionResult Result(object data)
        {
            return ApiResult.Create(data);
        }
    }
}
