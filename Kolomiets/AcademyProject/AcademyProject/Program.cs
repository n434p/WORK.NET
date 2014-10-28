using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProject
{
    class Academy
    {
        public string AcademyName { get; private set; }
        public  List<Group> GroupList { get; private set; }

        public Academy(string academyname="NET14/2")
        {
            AcademyName = academyname;
            GroupList = new List<Group>();
            for (int i = 0; i < 3; i++)
            {
                GroupList.Add(new Group("Group "+(i+1)));
            }
        }

        public void Edit(Student stud, string name,string surname)
        {
            stud.Name = name;
            stud.Surname = surname;
        }

        public void Edit(Group group, string name)
        {
            group.GroupName = name;
        }

        public void AddStudent(Group group, string name, string surName)
        {
            group.StudentList.Add(new Student(name, surName));
            Console.WriteLine("Student {0} {1} was added to {2} group", name, surName, group.GroupName);
        }

        public void RemoveStudent(Group group, Student stud)
        {
            group.StudentList.Remove(stud);
            Console.WriteLine("Student {0} {1} was removed from {2} group", stud.Name, stud.Surname, group.GroupName);
        }


        public void MoveStudent(Student stud, Group groupTo)
        {
            foreach (var item in GroupList)
            {
                if (item.StudentList.Contains(stud))
                {
                    Console.WriteLine("Student {0} from {1} replaced in {2} group.", stud,item.GroupName, groupTo);
                    item.StudentList.Remove(stud);

                    groupTo.StudentList.Add(stud);
                }
            }
        }

        public void SearchStud(string str)
        {
            Console.WriteLine("Searching for \"{0}\"...\n\n", str);
            foreach (var item in GroupList)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (item.StudentList[i].Name.Contains(str) || item.StudentList[i].Name.Contains(str))
                        Console.WriteLine("Your student {0} is in the {1} group.",item.StudentList[i],item.GroupName);
                }
            }
        }

        public override string ToString()
        {
            Console.WriteLine(" Academy "+AcademyName);
            foreach (var item in GroupList)
            {
                Console.WriteLine(item);
            }
            return "********";
        }
    }

    class Group
    {
        public string GroupName { get; set; }
        public List<Student> StudentList { get; private set; }

        public Group(string groupname="NET14/2")
        {
            StudentList = new List<Student>();
            GroupName = groupname; 
            for (int i = 0; i < 7; i++)
            {
                StudentList.Add(new Student("Student "+(i+1)));
            }
        }

                
        public override string ToString()
        {
            Console.WriteLine("Group name: {0}", GroupName);
            foreach (var item in StudentList)
	{
		 Console.WriteLine(item);
	}
        	 return "******";
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student(string name="Ivan", string surname="Ivanov")
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return string.Format(" Student: {0} \t{1}",Name,Surname);
        }
    }

    
    class Program
    {
        public static void Menu() 
        {
            Academy someAcademy = new Academy();

            Console.WriteLine("Welcome to our {0} Academy!!!\n\n", someAcademy.AcademyName);
            do
            {
                Console.WriteLine("1. View Academy groups;");
                Console.WriteLine("2. Edit menu;");
                Console.WriteLine("3. Search;");
                Console.WriteLine("4. Add/Remove student;");
                Console.WriteLine("0. Quit;");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine(someAcademy);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Edit menu: \n");
                            Console.WriteLine("1. Edit group;");
                            Console.WriteLine("2. Edit students data;");
                            Console.WriteLine("3. Add new student;");
                            Console.WriteLine("4. Remove student;");

                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Groups:");
                                        foreach (var item in someAcademy.GroupList)
                                        {
                                            Console.WriteLine(item.GroupName);
                                        }
                                        Console.WriteLine("\nEnter group index to edit: ");
                                        int index = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter new name for the group: ");
                                        string newname = Console.ReadLine();
                                        Console.WriteLine("Group {0} renamed to {1}", someAcademy.GroupList[index], newname);
                                        someAcademy.Edit(someAcademy.GroupList[index], newname);
                                        break;
                                    }
                                case ConsoleKey.D2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Students:");
                                        foreach (var item in someAcademy.GroupList)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine("\nEnter group index: ");
                                        int indexGroup = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nEnter grouplist index: ");
                                        int indexList = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter new name for the student: ");
                                        string newname = Console.ReadLine();
                                        Console.WriteLine("Enter new surname for the student: ");
                                        string newSurname = Console.ReadLine();
                                        Console.WriteLine("Student {0} renamed to {1} {2}", someAcademy.GroupList[indexGroup].StudentList[indexList], newname, newSurname);
                                        someAcademy.Edit(someAcademy.GroupList[indexGroup].StudentList[indexList],newname,newSurname);
                                        break;
                                    }
                                case ConsoleKey.D3:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Students:");
                                        foreach (var item in someAcademy.GroupList)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine("\nEnter group index: ");
                                        int indexGroup = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter new name for the student: ");
                                        string newname = Console.ReadLine();
                                        Console.WriteLine("Enter new surname for the student: ");
                                        string newSurname = Console.ReadLine();
                                        someAcademy.AddStudent(someAcademy.GroupList[indexGroup], newname, newSurname);
                                        break;
                                    }
                                case ConsoleKey.D4:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Students:");
                                        foreach (var item in someAcademy.GroupList)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        Console.WriteLine("\nEnter group index: ");
                                        int indexGroup = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("\nEnter grouplist index: ");
                                        int indexList = Convert.ToInt32(Console.ReadLine());
                                        someAcademy.RemoveStudent(someAcademy.GroupList[indexGroup],someAcademy.GroupList[indexGroup].StudentList[indexList]);
                                        break;
                                    }
                                    

                                default: break;
                            }

                        } while (Console.ReadKey().Key != ConsoleKey.A);
                        break;
                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            Console.WriteLine("Enter some data to search: ");
                            string str = Console.ReadLine();
                            someAcademy.SearchStud(str);
                            break;
                        }
                    case ConsoleKey.D4:
                        Console.Clear();
                        break;
                    case ConsoleKey.D0:
                        return;
                        break;

                    default: break;
                }


            } while (true);




            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Menu();

        }
    }
}
