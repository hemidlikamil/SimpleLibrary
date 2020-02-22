using SimpleLibrary.CustomAuth;
using SimpleLibrary.Services;
using SimpleLibrary.ViewModels;
using System.Web.Mvc;

namespace SimpleLibrary.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var vm = new EmployeeViewModel();
            return View("EmployeeForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EmployeeForm", model);
                }

                _employeeService.Create(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EmployeeForm", model);
            }
        }

        public ActionResult Me()
        {
            return Json(SessionProvider.Current, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var vm = new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary,
                Age = employee.Age
            };

            return View("EmployeeForm", vm);
        }
    }
}