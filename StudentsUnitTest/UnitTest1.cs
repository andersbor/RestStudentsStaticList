using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using StudentsRestStaticList.Controllers;
using StudentsRestStaticList.model;

namespace StudentsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly StudentsController _controller = new StudentsController();

        [TestInitialize] // run before each method
        public void Init()
        {
            _controller.ReInitialize();
            // Microsoft.VisualStudio.TestTools.UnitTesting.Logging.Logger.LogMessage("ANBO");
        }

        [TestMethod]
        public void TestPost()
        {
            Student newStudent = new Student
            {
                Name = "Dennis",
                Address = "Copenhagen",
                Semester = 4
            };
            Student stud = _controller.Post(newStudent);
            Assert.AreEqual(4, stud.Id);
        }

        [TestMethod]
        public void TestGet()
        {
            IEnumerable<Student> students = _controller.Get();
            Assert.AreEqual(3, students.Count());

            Student st = _controller.Get(1);
            Assert.AreEqual("Abraham", st.Name);

            st = _controller.Get(100);
            Assert.IsNull(st);
        }

        [TestMethod]
        public void TestDelete()
        {
            int howMany = _controller.Delete(100);
            Assert.AreEqual(0, howMany);

            howMany = _controller.Delete(1);
            Assert.AreEqual(1, howMany);

            IEnumerable<Student> students = _controller.Get();
            Assert.AreEqual(2, students.Count());
        }

        [TestMethod]
        public void TestPut()
        {
            Student newStudent = new Student
            {
                Name = "Dennis",
                Address = "Copenhagen",
                Semester = 4
            };
            Student stud = _controller.Put(2, newStudent);
            Assert.AreEqual("Dennis", stud.Name);
            Student s2 = _controller.Get(2);
            Assert.AreEqual("Dennis", s2.Name);

            Student s = _controller.Put(100, newStudent);
            Assert.IsNull(s);
        }
    }
}
