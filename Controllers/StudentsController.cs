using MKR1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Test.Context;

namespace MKR1.Controllers
{
    public class StudentsController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        [AllowAnonymous]
        [HttpGet]
        [Route("api/students")]
        public List<Student> Get()
        {
            var result = db.Students.ToList();
            return result;
        }


        [Authorize(Roles = "user")]
        [HttpPost]
        [Route("api/students")]
        public IHttpActionResult Add([FromBody]Student student)
        {
            var a = db.Students.Where(stud => stud.NickName == student.NickName).ToList();
            if (!db.Students.Where(stud => stud.NickName == student.NickName).Any())
            {
                db.Students.Add(student);
                db.SaveChanges();
                return Ok("You created a new student with NickName '" + student.NickName + "'.");
            }
            else
            {
                return BadRequest("Student with NickName '" + student.NickName + "' already exists.");
            }
        }


        // GET api/students/"Admin"
        public string Get(string NickName)
        {
            return "value";
        }
    }
}
