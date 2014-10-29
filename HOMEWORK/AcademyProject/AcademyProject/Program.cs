using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.WriteLine("Student \"{0}\" renamed to \"{1} {2}\"", stud, name, surname);
            stud.RenameStud(name, surname);
            
        }

        public void Edit(Group group, string name)
        {
            Console.WriteLine("\nGroup \"{0}\" renamed to \"{1}\"\n", group.GroupName, name);
            group.RenameGroup(name);
            
        }

        public void AddStudent(Group group, string name, string surName)
        {
            group.StudentList.Add(new Student(name, surName));
            Console.WriteLine("\n\nStudent \"{0} {1}\" was added to \"{2}\"", name, surName, group.GroupName);
        }

        public void RemoveStudent(Group group, Student stud)
        {
            group.StudentList.Remove(stud);
            Console.WriteLine("\n\nStudent \"{0} {1}\" was removed from \"{2}\"", stud.Name, stud.Surname, group.GroupName);
        }

        public void MoveStudent(Student stud, Group groupFrom,Group groupTo)
        {
             Console.WriteLine("Student \"{0}\" from \"{1}\" replaced in \"{2}\"", stud,groupFrom.GroupName, groupTo.GroupName);
                    groupFrom.StudentList.Remove(stud);
                    groupTo.StudentList.Add(stud);       
            
        }

        public void SearchStud(string str)
        {
            Console.WriteLine("Searching for \"{0}\"...\n\n", str);
            str = str.ToLower();
            foreach (var item in GroupList)
            {
                for (int i = 0; i < item.StudentList.Count; i++)
                {
                    if (item.StudentList[i].Name.ToLower().Contains(str) || item.StudentList[i].Surname.ToLower().Contains(str))
                        Console.WriteLine("Your student \"{0}\" is in the \"{1}\"",item.StudentList[i],item.GroupName);
                }
            }
            Console.WriteLine("\n****************\n");
        }

        public override string ToString()
        {
            Console.WriteLine(" Academy {0}\n",AcademyName);

            int ind = 1;
            foreach (var item in GroupList)
            {
                Console.WriteLine("\nIndex #{0}: \n", ind);
                Console.WriteLine(item);
                ind++;
            }
            return "";
        }
    }

    class Group
    {
        public string GroupName { get; private set; }
        public List<Student> StudentList { get; private set; }

        // some names and surnames to make various combinations as initial data of student.
        string[] names = { "Gerby","Alex","Max","Genry","John","Bill","Steve","George","Garry"};
        string[] surnames = { "Shildt", "Troelsen", "Richter", "Gates", "Truman", "Skeet", "Nixon" }; 

        public Group(string groupname="NET14/2")
        {
            Random r = new Random();
            StudentList = new List<Student>();
            GroupName = groupname; 
            for (int i = 0; i < 7; i++)
            {
                
               Thread.Sleep(25);
               StudentList.Add(new Student(names[r.Next(names.Length)],surnames[r.Next(surnames.Length)]));
            }
        }

        public void RenameGroup(string newname)
        {
            GroupName = newname;
        }
         
        public override string ToString()
        {
            Console.WriteLine(" Group: {0}\n", GroupName);
            int ind = 1;
            foreach (var item in StudentList)
	        {
		    Console.WriteLine("{0}.\t{1}",ind,item);
            ind++;
         	}
        	 return "\n******";
        }
    }

    class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Student(string name="Ivan", string surname="Ivanov")
        {
            Name = name;
            Surname = surname;
        }

        public void RenameStud(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",Name,Surname);
        }
    }

    
    class Program
    {
        public static void Menu()  
        {
            Academy someAcademy = new Academy();
            // sets windows parameters to better fit.
            Console.WindowHeight = 50;
            Console.WindowWidth = 50;

            do
            {   // flag for the exit from inner menu.
                bool innerMenu = true;
                try
                {
                    Console.WriteLine("\tWelcome to our {0} Academy!!!\n\n", someAcademy.AcademyName);
                    Console.WriteLine("\t1. View Academy groups");
                    Console.WriteLine("\t2. Edit menu");// has inner menu
                    Console.WriteLine("\t3. Search");
                    Console.WriteLine("\t0. Quit");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:// View Academy groups;
                            Console.Clear();
                            Console.WriteLine(someAcademy);
                            break;
                        case ConsoleKey.D2:// Edit menu
                            Console.Clear();                       
                            do
                            {
                                Console.WriteLine("Edit menu: \n\n");
                                Console.WriteLine("1. Edit group");
                                Console.WriteLine("2. Edit student's data");
                                Console.WriteLine("3. Add new student");
                                Console.WriteLine("4. Remove student");
                                Console.WriteLine("5. Change student's group");
                                Console.WriteLine("\n0. Previous menu");

                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.D1:// Edits group
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Groups:");
                                            int ind = 1;
                                            foreach (var item in someAcademy.GroupList)
                                            {
                                                Console.WriteLine("{0}. {1}", ind, item.GroupName);
                                                ind++;
                                            }
                                            Console.WriteLine("\nEnter group index to edit: ");
                                            int index = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("Enter new name for the \"{0}\": ", someAcademy.GroupList[index].GroupName);
                                            string newname = Console.ReadLine();
                                            someAcademy.Edit(someAcademy.GroupList[index], newname);
                                            innerMenu = false;
                                            break;
                                        }
                                    case ConsoleKey.D2: // Edits student's data
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Students:");
                                            Console.WriteLine(someAcademy);
                                            Console.WriteLine("\nEnter group index: ");
                                            int indexGroup = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("\nEnter grouplist index: ");
                                            int indexList = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("Enter new name for the \"{0}\": ", someAcademy.GroupList[indexGroup].StudentList[indexList].Name);
                                            string newname = Console.ReadLine();
                                            Console.WriteLine("Enter new surname for the \"{0}\": ", someAcademy.GroupList[indexGroup].StudentList[indexList].Surname);
                                            string newSurname = Console.ReadLine();
                                            someAcademy.Edit(someAcademy.GroupList[indexGroup].StudentList[indexList], newname, newSurname);
                                            
                                            innerMenu = false;
                                            break;
                                        }
                                    case ConsoleKey.D3: // Adds new student
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Students:");
                                            Console.WriteLine(someAcademy);
                                            Console.WriteLine("\nEnter group index: ");
                                            int indexGroup = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("Enter Name for the new student: ");
                                            string newname = Console.ReadLine();
                                            Console.WriteLine("Enter Surname for the new student: ");
                                            string newSurname = Console.ReadLine();
                                            someAcademy.AddStudent(someAcademy.GroupList[indexGroup], newname, newSurname);
                                            
                                            innerMenu = false;
                                            break;
                                        }
                                    case ConsoleKey.D4: // Removes student.
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Students:");
                                            Console.WriteLine(someAcademy);
                                            Console.WriteLine("\nEnter group index: ");
                                            int indexGroup = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("\nEnter grouplist index: ");
                                            int indexList = Convert.ToInt32(Console.ReadLine()) - 1;
                                            someAcademy.RemoveStudent(someAcademy.GroupList[indexGroup], someAcademy.GroupList[indexGroup].StudentList[indexList]);
                                            
                                            innerMenu = false;
                                            break;
                                        }
                                    case ConsoleKey.D5: //Changes student's group
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Students:");
                                            Console.WriteLine(someAcademy);
                                            Console.WriteLine("\nEnter group(from) index: ");
                                            int indexFrom = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("\nEnter grouplist index: ");
                                            int indexList = Convert.ToInt32(Console.ReadLine()) - 1;
                                            Console.WriteLine("\nEnter group(to) index: ");
                                            int indexTo = Convert.ToInt32(Console.ReadLine()) - 1;
                                            someAcademy.MoveStudent(someAcademy.GroupList[indexFrom].StudentList[indexList], someAcademy.GroupList[indexFrom], someAcademy.GroupList[indexTo]);
                                            
                                            innerMenu = false;
                                            break;
                                        }
                                    case ConsoleKey.D0: //Goes to main menu
                                        Console.Clear();
                                        innerMenu = false;
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                            } while (innerMenu);
                           break;
                           
                        case ConsoleKey.D3: // Search 
                            {
                                Console.Clear();
                                Console.WriteLine("Enter some data to search: ");
                                string str = Console.ReadLine();
                                someAcademy.SearchStud(str);
                                break;
                            }
                        case ConsoleKey.D0: // Exit
                            return;


                        default:
                            Console.Clear();
                            break;

                    }
                }
                catch 
                {   // for any exception events in menu
                    Console.Clear();
                    Console.WriteLine("Sorry! Your entry has mistakes.\n");
 
                }
                    // displays result before it goes to main menu.
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
               
                Console.Clear();


            } while (true);

        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
