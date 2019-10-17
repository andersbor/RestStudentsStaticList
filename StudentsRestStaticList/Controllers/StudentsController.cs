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
        private static List<Student> _students;
        private static int _nextId;

        static StudentsController()
        {
            Initialize();
        }

        // For testing
        public void ReInitialize()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _students = new List<Student>
            {
                new Student {Id = 1, Name = "Abraham", Address = "Roskilde", Semester = 3},
                new Student { Id = 2, Name = "Benjamin", Address = "Copenhagen", Semester = 3 },
                new Student { Id = 3, Name = "Carl C", Address = "Roskilde", Semester = 2 }
                //new Student { Id = 4, Name = "Dennis", Address = "Roskilde", Semester = 3 }
            };
            _nextId = 4;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _students;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _students.FirstOrDefault(student => student.Id == id);
        }

        // POST: api/Students
        [HttpPost]
        public Student Post([FromBody] Student value)
        {
            value.Id = _nextId;
            _nextId++;
            _students.Add(value);
            return value;
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public Student Put(int id, [FromBody] Student value)
        {
            Student st = _students.FirstOrDefault(student => student.Id == id);
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
            int howMany = _students.RemoveAll(student => student.Id == id);
            return howMany;
        }
    }
}
