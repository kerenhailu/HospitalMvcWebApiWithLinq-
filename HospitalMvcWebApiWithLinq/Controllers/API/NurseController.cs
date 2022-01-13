using HospitalMvcWebApiWithLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalMvcWebApiWithLinq.Controllers.API
{
    public class NurseController : ApiController
    {
        NurseDataContext DataContext = new NurseDataContext();

        // GET: api/Nurse
        public IHttpActionResult Get()
        {
           List<Nurse> nurses= DataContext.Nurses.ToList();
            return Ok(new { nurses });
        }

        // GET: api/Nurse/5
        public IHttpActionResult Get(int id)
        {
            Nurse nurse= DataContext.Nurses.First(item => item.Id == id);
            return Ok(new { nurse });
        }

        // POST: api/Nurse
        public IHttpActionResult Post([FromBody]Nurse nurse)
        {
            DataContext.Nurses.InsertOnSubmit(nurse);
            DataContext.SubmitChanges();
            List<Nurse> nurses = DataContext.Nurses.ToList();
            return Ok(new { nurses });
        }

        // PUT: api/Nurse/5
        public IHttpActionResult Put(int id, [FromBody]Nurse nurse)
        {
            Nurse nurseToChange = DataContext.Nurses.First(item => item.Id == id);
            if (nurseToChange != null)
            {
                nurseToChange.name = nurse.name;
                nurseToChange.lName = nurse.lName;
                nurseToChange.wage = nurse.wage;
                nurseToChange.hourWork = nurse.hourWork;
                nurseToChange.birthday = nurse.birthday;


            }
            DataContext.SubmitChanges();
            return Ok("Update the object");
        }

        // DELETE: api/Nurse/5
        public IHttpActionResult Delete(int id)
        {
            Nurse nurseToDelete = DataContext.Nurses.First(item => item.Id == id);
            DataContext.Nurses.DeleteOnSubmit(nurseToDelete);
            DataContext.SubmitChanges();
            return Ok("this obj delete");
        }
    }
}
