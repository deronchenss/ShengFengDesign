using ShengFengDesign.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Resources;

namespace ShengFengDesign.Controllers
{
    [MiddlewareFilter(typeof(CultureMiddleware))]
    public class BaseController : Controller
    {
    }
}
