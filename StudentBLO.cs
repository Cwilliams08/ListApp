using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    class StudentBLO
    {
        StudentMapper _Mapper = new StudentMapper();

        public void AddStudent(string iNameOfStudent)
        {
            StudentDO StudentDataObj = new StudentDO();
            StudentDataObj.StudentName = iNameOfStudent;
            _Mapper.CreateStudent(StudentDataObj);
        }

        public List<Student> ReadAllStudents()
        {
            //Request student data objects from DAL
            List<StudentDO> DataObjects = _Mapper.ReadAllStudents();
            //Create list of student business objects
            List<Student> Students = new List<Student>();
            //Transfer info
            foreach (StudentDO DO in DataObjects)
            {
                Students.Add(new Student()
                {
                    StudentID = DO.PKStudentID,
                    StudentName = DO.StudentName
                });
            }
            return Students;
        }

        internal void UpdateStudent(Student updatedStudent)
        {
            throw new NotImplementedException();
        }
    }
}
