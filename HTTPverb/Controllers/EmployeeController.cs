using Microsoft.AspNetCore.Mvc;

namespace HTTPverb.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
       static List<Employee>?emplyoees = new List<Employee>();
        Employee? employee;
       
        [HttpGet]
        public ActionResult GetListOfEmployee()
        {
            return Ok(emplyoees);
        } 
        [HttpPut]
        public ActionResult Put()
        {
            emplyoees.Add(new Employee { Id = 1, Name = "Yogesh", Address = "Bhusawal" });
            emplyoees.Add(new Employee { Id = 2, Name = "Akash", Address = "Chaudhari" });
            emplyoees.Add(new Employee { Id = 3, Name = "Vinay", Address = "Mali" });
            return Ok("Inserted");
        } 
        [HttpPost("{Id},{Name},{Address}")]
        public ActionResult AddnewEmployee(int Id,string Name,string Address)
        {
                var emp = emplyoees.Where(e => e.Id == Id).FirstOrDefault();
                if (emp.Equals(null))
                {
                    employee = new Employee { Id = Id, Name = Name, Address = Address };
                    emplyoees.Add(employee);
                    return Ok("Employee Added");
                }
                else
                {
                    return Ok("Employee Id Exist");
                }
        }
           
        [HttpPut("{NewId},{NewName},{NewAddress}")]  //update complete employee obj
        public ActionResult UpdateEmployee(int NewId, string NewName, string NewAddress)
        {
            if (emplyoees != null)
            {
                var emp = emplyoees.Where(e => e.Id == NewId).FirstOrDefault();
                if (emp.Equals(null))
                    return Ok("Employee not Found");
                else
                {
                    emplyoees.Remove(emp);
                    employee = new Employee { Id = NewId, Name = NewName, Address = NewAddress };
                    emplyoees.Add(employee);
                    return Ok("Employee Updated");
                }
            }
            else

                return Ok("Not Updated");
        }

           
        [ HttpDelete("{id}")]
         public ActionResult DeleteByID(int id)
        {
            if (emplyoees != null)
            {
                var emp = emplyoees.Where(e => e.Id == id).FirstOrDefault();
                if (emp.Equals(null))
                    return Ok("Employee not Found");
                else
                {
                    emplyoees.Remove(emp);
                    return Ok("Employee removed");
                }
            }
            else

                return Ok("Not Removed");
        }
        [HttpPatch("{id},{address}")]            //update partial resource
        public ActionResult UpdateAddress(int id, string NewAddress)
        {
            if (emplyoees != null)
            {
                var emp = emplyoees.Where(e => e.Id == id).FirstOrDefault();
                if (emp.Equals(null))
                {
                    return Ok("Employee not Found");
                }
                else
                {
                    var newEmp = emp;
                    newEmp.Address = NewAddress;
                    emplyoees.Remove(emp);
                    emplyoees.Add(newEmp);
                    return Ok("Employee Updated");
                }
            }
            else

                return Ok("Not Updated");
        }
    
    }
}