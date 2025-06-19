using Microsoft.AspNetCore.Mvc;

namespace StudentManagementMVC.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
