using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Data;
using StudentManagementMVC.Models;

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
        //GET: Students/Details/3 id'si 3 olanın detaylarını getir
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // 404 (bulunamadı hatası kodu), kullanıcıya HTTP üzerinden bulunamadı mesajı döndürecek.
            }
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s=>s.Id == id);
            if (student == null) //eğer öğrenci yoksa
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Students.Add(student);
                //kullanıcıdan gelen değeri kaydederken savchange uygula
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _appDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Update(student);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
