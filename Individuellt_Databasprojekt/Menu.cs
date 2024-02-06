using Individuellt_Databasprojekt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_Databasprojekt
{
    internal class Menu
    {
        public static void RunMenu()
        {
            using SchoolDbContext dbContext = new SchoolDbContext();

            bool isRunning = true;

            do
            {
                Console.WriteLine("    See all students\n" +
                   "    See students sorted by class\n" +
                   "    Show all ongoing courses\n" +
                   "    Show number of teachers per department\n" +
                   "    Logg out");

                int userOption = CursorMenu(0, 0, 4);

                Console.Clear();

                switch (userOption)
                {
                    case 0:
                        Console.WriteLine("    Sort student by first name\n    Sort student by last name");
                        int nameSorting = CursorMenu(0, 0, 1);
                        Console.Clear();

                        Console.WriteLine("    Ascending\n    Descending");
                        int sortingOrder = CursorMenu(0, 0, 1);
                        Console.Clear();

                        // Sorting by first name ascending
                        if (nameSorting == 0 && sortingOrder == 0)
                        {
                            var students = dbContext.TblStudents.Include(s => s.Class).OrderBy(s => s.StudentFname);
                            
                            Console.WriteLine("First name          Last Name           Personal Number  Class");
                            
                            foreach (var student in students)
                            {
                                Console.WriteLine($"{student.StudentFname, -20}{student.StudentLname, -20}" +
                                    $"{student.PersonalNumber, -17}{student.Class.ClassName} \n");
                            }
                        }

                        // Sorting by first name descending
                        else if (nameSorting == 0 && sortingOrder == 1)
                        {
                            var students = dbContext.TblStudents.Include(s => s.Class).OrderByDescending(s => s.StudentFname);

                            Console.WriteLine("First name          Last Name           Personal Number  Class");

                            foreach (var student in students)
                            {
                                Console.WriteLine($"{student.StudentFname,-20}{student.StudentLname,-20}" +
                                    $"{student.PersonalNumber,-17}{student.Class.ClassName} \n");
                            }
                        }

                        // Sorting by last name ascending
                        else if (nameSorting == 1 && sortingOrder == 0)
                        {
                            var students = dbContext.TblStudents.Include(s => s.Class).OrderBy(s => s.StudentLname);

                            Console.WriteLine("Last name           First Name          Personal Number  Class");

                            foreach (var student in students)
                            {
                                Console.WriteLine($"{student.StudentLname,-20}{student.StudentFname,-20}" +
                                    $"{student.PersonalNumber,-17}{student.Class.ClassName} \n");
                            }
                        }

                        // Sorting by last name descending
                        else
                        {
                            var students = dbContext.TblStudents.Include(s => s.Class).OrderByDescending(s => s.StudentLname);

                            Console.WriteLine("Last name           First Name          Personal Number  Class");

                            foreach (var student in students)
                            {
                                Console.WriteLine($"{student.StudentLname,-20}{student.StudentFname,-20}" +
                                    $"{student.PersonalNumber,-17}{student.Class.ClassName} \n");
                            }
                        }
                        Console.ReadLine();
                        Console.Clear();
                        ; break;

                    case 1:
                        var classes = dbContext.TblClasses;
                        Console.WriteLine("Select class:");
                        foreach (var item in classes)
                        {
                            Console.WriteLine("    " + item.ClassName);
                        }

                        int selectedClass = CursorMenu(1, 1, classes.Count());
                        Console.Clear();

                        var studentsByClass = dbContext.TblStudents.Where(s => s.ClassId == selectedClass);

                        foreach (var student in studentsByClass)
                        {
                            Console.WriteLine($"{student.StudentFname} {student.StudentLname} {student.Class.ClassName}");
                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
                        var ongoingSubjects = dbContext.TblSubjects.Where(s => s.EndDate > todaysDate && s.StartDate <= todaysDate);

                        foreach (var subject in ongoingSubjects)
                        {
                            Console.WriteLine($"{subject.SubjectName} \nStart date: {subject.StartDate} \nEnd date: {subject.EndDate}\n");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        var teachersByDepartment = dbContext.TblTeachers.GroupBy(t => t.Department.DepartmentName);
                        foreach (var teacherGroup in teachersByDepartment)
                        {
                            Console.WriteLine($"{teacherGroup.Key}: {teacherGroup.Count()} teachers");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        isRunning = false;
                        break;
                }
            } while (isRunning == true);
        }

        public static int CursorMenu(int cursorPosition, int firstRow, int lastRow)
        {
            Console.SetCursorPosition(0, cursorPosition);
            Console.CursorVisible = false;
            Console.Write("-->");
            ConsoleKeyInfo navigator;

            do
            {
                navigator = Console.ReadKey();
                Console.SetCursorPosition(0, cursorPosition);
                Console.Write("   ");

                if (navigator.Key == ConsoleKey.UpArrow && cursorPosition > firstRow)
                {
                    cursorPosition--;
                }

                else if (navigator.Key == ConsoleKey.DownArrow && cursorPosition < lastRow)
                {
                    cursorPosition++;
                }

                Console.SetCursorPosition(0, cursorPosition);
                Console.Write("-->");
            } while (navigator.Key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            return cursorPosition;
        }
    }
}
