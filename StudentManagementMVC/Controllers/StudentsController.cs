using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Data;

namespace StudentManagementMVC.Controllers
{
    public class StudentsController : Controller
    {
        //DI ile veritabanı entegrasyonunu çağırıyoruz.
        private readonly AppDbContext _appDbContext;// Veritabanı bağlamını (DbContext) tutan özel ve sadece okunabilir bir alan tanımlar.

        //Constructor metot(yapıcı metot)
        public StudentsController(AppDbContext appDbContext)// StudentsController'ın yapıcı (constructor) metodu.
        {
            _appDbContext = appDbContext;// Dependency Injection ile sağlanan AppDbContext örneğini _context alanına atar.
        }

        public async Task<IActionResult> Index()
        {
            // _context.Students.ToListAsync() ile veritabanındaki tüm öğrenci kayıtlarını asenkron olarak çeker.
            var listAllStudents = await _appDbContext.Students.ToListAsync();
            return View(listAllStudents);
            //return View(await _appDbContext.Students.ToListAsync());
        }

    }
}
