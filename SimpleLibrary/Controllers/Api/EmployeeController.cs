using SimpleLibrary.Uow;
using System.Web.Http;

namespace SimpleLibrary.Controllers.Api
{
    public class EmployeeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetEmployees(string query = null)
        {
            return Ok(_unitOfWork.EmployeeRepo.GetAll(query));
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeRepo.Delete(employee);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
