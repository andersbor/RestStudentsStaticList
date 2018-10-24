using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentsRestStaticList.model;

namespace StudentsRestStaticList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> Students = new List<Student>();
        private static int _nextId = 4;

        static StudentsController()
        {
            Student s1 = new Student { Id=1, Name = "Abraham", Address = "Roskilde", Semester = 3 };
            Student s2 = new Student { Id=2, Name = "Benjamin", Address = "Copenhagen", Semester = 3 };
            Student s3 = new Student { Id=3, Name = "Carl", Address = "Roskilde", Semester = 2 };
            Students.Add(s1);
            Students.Add(s2);
            Students.Add(s3);
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return Students;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return Students.FirstOrDefault(student => student.Id == id);
        }

        // POST: api/Students
        [HttpPost]
        public Student Post([FromBody] Student value)
        {
            value.Id = _nextId;
            _nextId++;
            Students.Add(value);
            return value;
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody] Student value)
        {
            Student st = Students.FirstOrDefault(student => student.Id == id);
            if (st == null) return null;
            st.Name = value.Name;
            st.Address = value.Address;
            st.Semester = value.Semester;
            return st;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int howMany = Students.RemoveAll(student => student.Id == id);
            return howMany;
        }
    }
}
