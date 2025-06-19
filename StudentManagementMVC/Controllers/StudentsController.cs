using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Data;

namespace StudentManagementMVC.Controllers
{
    public class StudentsController : Controller
    {
        //DI ile veritabanı entegrasyonunu çağırıyoruz.
        private readonly AppDbContext _appDbContext;

        //Constructor metot(yapıcı metot)
        public StudentsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var listAllStudents = await _appDbContext.Students.ToListAsync();
            return View(listAllStudents);
            //return View(await _appDbContext.Students.ToListAsync());
        }

    }
}
