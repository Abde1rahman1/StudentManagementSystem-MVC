using ManagementSystem.DbContexts;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public StudentsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)

        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult GetIndexView(string? search)
        {


            ViewBag.SearchText = search;

            IQueryable<Student> QueryableEmps = _context.Students.AsQueryable();

            if (string.IsNullOrEmpty(search) == false)
            {
                QueryableEmps = QueryableEmps.Where(emp => emp.FullName.Contains(search));

            }



            return View("Index", QueryableEmps.ToList());
        }

        public IActionResult GetDetailsView(int id)

        {
            
            Student student = _context.Students.Include(e => e.Course).FirstOrDefault(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", student);
            }

        }


        [HttpGet]
        public IActionResult GetCreateView()
        {
            ViewBag.AllCourses = _context.Courses.ToList();

            return View("Create");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddNew(Student student)
        {
           

            if (ModelState.IsValid == true)
            {
                if (student.ImageFile == null)
                {
                    student.ImagePath = "\\images\\No_Image.png";
                }
                else
                {
                    // Guid-> Globally Uniqe Identifier  not repeat over the worled
                    Guid imageGuid = Guid.NewGuid();
                    string imageExtension = Path.GetExtension(student.ImageFile.FileName);
                    student.ImagePath = "\\images\\" + imageGuid + imageExtension;

                    string imageUploadPath = _webHostEnvironment.WebRootPath + student.ImagePath;

                    FileStream imageStream = new FileStream(imageUploadPath, FileMode.Create);
                    student.ImageFile.CopyTo(imageStream);
                    imageStream.Dispose();
                }

                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllDepartments = _context.Courses.ToList();
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {

            Student student = _context.Students.FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.AllCourses = _context.Courses.ToList();
                return View("Edit", student);
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EditCurrent(Student student)
        {
           
            if (ModelState.IsValid == true)
            {

                if (student.ImageFile != null)
                {
                    if (student.ImagePath != "\\images\\No_Image.png")
                    {
                        System.IO.File.Delete(_webHostEnvironment.WebRootPath + student.ImagePath);
                    }

                    Guid imageGuid = Guid.NewGuid();
                    string imageExtention = Path.GetExtension(student.ImageFile.FileName);
                    student.ImagePath = "\\images\\" + imageGuid + imageExtention;
                    string imageUploadPath = _webHostEnvironment.WebRootPath + student.ImagePath;

                    FileStream imageStream = new FileStream(imageUploadPath, FileMode.Create);
                    student.ImageFile.CopyTo(imageStream);
                    imageStream.Dispose();
                }

                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {

                return View("Edit");
            }
        }
        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Student student = _context.Students.Include(e => e.Course).FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", student);
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {

            Student student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                if (student.ImagePath != "\\images\\No_Image.png")

                {
                    System.IO.File.Delete(_webHostEnvironment.WebRootPath + student.ImagePath);
                }

                _context.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
        }
    }
}
