using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ListApp
{
    class Program
    {
        StudentBLO _StuBLO = new StudentBLO();

        static void Main(string[] args)
        {

            /*string input = Console.ReadLine();
            List<string> StudentList = new List<string>();
            StudentList.Add(input);
            string InputNewStudent = Console.ReadLine();
            StudentList.Add(InputNewStudent);
            foreach (var Student in StudentList)
            {
                Console.WriteLine(Student);
            }
            Console.ReadLine();*/

            Program MyProgram = new Program();
            MyProgram.RunStudentManager();
            Console.ReadLine();
        }

        private void RunStudentManager()
        {
            Console.WriteLine("Greetings, what would you like to do?");
            Console.WriteLine("Press 1 to manage Students\nPress 2 to manage Faculty\nPress 3 to manage Equipments\nPress 4 to manage teams");
            int Selection = GetValidNumber();
            switch (Selection)
            {
                case 1:
                    ManageStudent();
                    break;
                case 2:
                    ManageFaculty();
                    break;
                case 3:
                    ManageEquipment();
                    break;
                case 4:
                    ManageTeams();
                    break;
            }
        }

        private void ManageTeams()
        {
            throw new NotImplementedException();
        }

        private void ManageEquipment()
        {
            throw new NotImplementedException();
        }

        private void ManageFaculty()
        {
            throw new NotImplementedException();
        }

        private void ManageStudent()
        {
            StudentBLO BLO = new StudentBLO();
            Console.WriteLine("Press 1 to add Student\nPress 2 to delete student\nPress 3 to update Student\nPress 4 to see all Students");
            int selection = GetValidNumber();
            switch (selection)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    ViewAllStudents();
                    break;
            }
        }

        private void UpdateStudent()
        {
            ViewAllStudents();
            Console.WriteLine("Which Student Needs updated?");
            Student UpdatedStudent = new Student();
            UpdatedStudent.StudentID = GetValidNumber();
            Console.WriteLine("What is the correct name for this student?");
            UpdatedStudent.StudentName = Console.ReadLine();
            _StuBLO.UpdateStudent(UpdatedStudent);
        }

        private void DeleteStudent()
        {
            throw new NotImplementedException();
        }

        private void AddStudent()
        {
            //clears clutter
            Console.Clear();

                Console.WriteLine("What Student are you adding?");
                string NameOfStudent = Console.ReadLine();

            while (NameOfStudent != string.Empty)
            {
                _StuBLO.AddStudent(NameOfStudent);
            }
            return;

        }

        int GetValidNumber()
        {
            int ValidNumber = 0;
            bool Waiting = true;
            while (Waiting)
            {
                string input = Console.ReadLine();
                bool isValid = false;
                isValid = Int32.TryParse(input, out ValidNumber);
                if (isValid)
                {
                    Waiting = false;
                }
                else
                {
                    Console.WriteLine("Please use only numbers");
                }
            }
            return ValidNumber;
        }

        public void ViewAllStudents()
        {
            List<Student> Students = new List<Student>();
            Students = _StuBLO.ReadAllStudents();
            foreach (Student stu in Students)
            {
                Console.Write(stu.StudentID.ToString());
                Console.Write(" ");
                Console.WriteLine(stu.StudentName);
            }
        }
    }
}
