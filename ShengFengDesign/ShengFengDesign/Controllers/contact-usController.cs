using ShengFengDesign.Models;
using ShengFengDesign.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ShengFengDesign.Controllers
{
    [Route("{culture?}/ContactUs")]
    [Route("{culture?}/contact-us")]
    public class ContactUsController : BaseController
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [Route("{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            return View();
        }

        [Route("SaveContact")]
        [HttpPost]
        public async Task<JsonResult> SaveContact([FromBody] ContactUs request)
        {
            var result = await _contactUsService.SaveContact(request);
            return Json(result);
        }
    }
}
