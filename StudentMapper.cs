using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    class StudentMapper
    {

        string Directory = @"C:\Users\motoc\source\repos\ListApp\ListApp\StudentTable.txt";
        public void CreateStudent(StudentDO studentDataObj)
        {
            string NewContent = studentDataObj.StudentName;
            int StudentCount = 1;
            while (NewContent != "/exit")
            {
                File.AppendAllText(Directory, StudentCount + "|" + NewContent + Environment.NewLine);
                NewContent = Console.ReadLine();
                StudentCount++;
            }
        }

        public List<StudentDO> ReadAllStudents()
        {
            List<StudentDO> DataObjects = new List<StudentDO>();
            using (StreamReader Reader = new StreamReader(Directory))
            {
                while (Reader.Peek() >= 0)
                {
                    string Line = Reader.ReadLine();
                    StudentDO Student = ConvertToDataObject(Line);
                    DataObjects.Add(Student);
                }
            }
            return DataObjects;
        }

        private StudentDO ConvertToDataObject(string iLine)
        {
            StudentDO Student = new StudentDO();
            if (iLine.Length > 0)
            {
                string[] elements = iLine.Split('|');
                Student.PKStudentID = Int32.Parse(elements[0]);
                Student.StudentName = elements[1];
            }
            return Student;
        }
    }
}
