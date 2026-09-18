using StudentCRUD.Services;

GroupService groupService = new GroupService();
StudentService studentService = new StudentService(groupService);

while (true)
{
    Console.Clear();

    Console.WriteLine("===== STUDENT MANAGEMENT SYSTEM =====");
    Console.WriteLine();
    Console.WriteLine("1. Group Operations");
    Console.WriteLine("2. Student Operations");
    Console.WriteLine("0. Exit");
    Console.WriteLine();

    Console.Write("Select: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            GroupMenu();
            break;

        case "2":
            StudentMenu();
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            break;
    }
}


void GroupMenu()
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("===== GROUP OPERATIONS =====");
        Console.WriteLine();
        Console.WriteLine("1. Add Group");
        Console.WriteLine("2. Show All Groups");
        Console.WriteLine("3. Find Group");
        Console.WriteLine("4. Update Group");
        Console.WriteLine("5. Delete Group");
        Console.WriteLine("0. Back");
        Console.WriteLine();

        Console.Write("Select: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Group name: ");
                string groupName = Console.ReadLine();

                if (groupService.AddGroup(groupName))
                    Console.WriteLine("Group added successfully.");
                else
                    Console.WriteLine("Group could not be added.");

                Console.ReadKey();
                break;

            case "2":
                Console.WriteLine();
                var groups = groupService.GetAllGroups();

                if (groups.Count == 0)
                {
                    Console.WriteLine("There are no groups.");
                }
                else
                {
                    foreach (var group1 in groups)
                    {
                        Console.WriteLine($"{group1.Id} - {group1.Name}");
                    }
                }

                Console.ReadKey();
                break;

            case "3":
                Console.Write("Group Id: ");

                if (!int.TryParse(Console.ReadLine(), out int groupId))
                {
                    Console.WriteLine("Invalid Id.");
                    Console.ReadKey();
                    break;
                }

                var group = groupService.GetGroupById(groupId);

                if (group == null)
                {
                    Console.WriteLine("Group not found.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {group.Id}");
                    Console.WriteLine($"Name: {group.Name}");
                }

                Console.ReadKey();
                break;

            case "4":
                Console.Write("Group Id: ");

                if (!int.TryParse(Console.ReadLine(), out int updateId))
                {
                    Console.WriteLine("Invalid Id.");
                    Console.ReadKey();
                    break;
                }

                var groupToUpdate = groupService.GetGroupById(updateId);

                if (groupToUpdate == null)
                {
                    Console.WriteLine("Group not found.");
                    Console.ReadKey();
                    break;
                }

                Console.Write("New group name: ");
                string newGroupName = Console.ReadLine();

                if (groupService.UpdateGroup(updateId, newGroupName))
                    Console.WriteLine("Group updated successfully.");
                else
                    Console.WriteLine("Group could not be updated.");

                Console.ReadKey();
                break;

            case "5":
                Console.Write("Group Id: ");

                if (!int.TryParse(Console.ReadLine(), out int deleteId))
                {
                    Console.WriteLine("Invalid Id.");
                    Console.ReadKey();
                    break;
                }

                if (groupService.DeleteGroup(deleteId, studentService))
                    Console.WriteLine("Group deleted successfully.");
                else
                    Console.WriteLine("Group not found or could not be deleted.");

                Console.ReadKey();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                break;
        }
    }
}


void StudentMenu()
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("===== STUDENT OPERATIONS =====");
        Console.WriteLine();
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Show All Students");
        Console.WriteLine("3. Find Student");
        Console.WriteLine("4. Update Student");
        Console.WriteLine("5. Delete Student");
        Console.WriteLine("6. Show Students By Group");
        Console.WriteLine("0. Back");
        Console.WriteLine();

        Console.Write("Select: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Fullname: ");
                string fullName = Console.ReadLine();

                Console.Write("GPA: ");

                if (!double.TryParse(Console.ReadLine(), out double gpa))
                {
                    Console.WriteLine("Invalid GPA.");
                    Console.ReadKey();
                    break;
                }

                Console.Write("Group Id: ");

                if (!int.TryParse(Console.ReadLine(), out int groupId))
                {
                    Console.WriteLine("Invalid Group Id.");
                    Console.ReadKey();
                    break;
                }

                if (studentService.AddStudent(fullName, gpa, groupId))
                    Console.WriteLine("Student added successfully.");
                else
                    Console.WriteLine("Student could not be added.");

                Console.ReadKey();
                break;

            case "2":
                Console.WriteLine();

                var students = studentService.GetAllStudents();

                if (students.Count == 0)
                {
                    Console.WriteLine("There are no students.");
                }
                else
                {
                    foreach (var student1 in students)
                    {
                        string groupName =
                            studentService.GetGroupName(student1.GroupId);

                        Console.WriteLine(
                            $"{student1.Id} - {student1.FullName} - GPA: {student1.GPA} - Group: {groupName}");
                    }
                }

                Console.ReadKey();
                break;

            case "3":
                Console.Write("Student Id: ");

                if (!int.TryParse(Console.ReadLine(), out int studentId))
                {
                    Console.WriteLine("Invalid Id.");
                    Console.ReadKey();
                    break;
                }

                var student = studentService.GetStudentById(studentId);

                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {student.Id}");
                    Console.WriteLine($"Fullname: {student.FullName}");
                    Console.WriteLine($"GPA: {student.GPA}");
                    Console.WriteLine(
                        $"Group: {studentService.GetGroupName(student.GroupId)}");
                }

                Console.ReadKey();
                break;

            case "4":
                Console.Write("Student Id: ");

                if (!int.TryParse(Console.ReadLine(), out int updateStudentId))
                {
                    Console.WriteLine("Invalid Id.");
                    Console.ReadKey();
                    break;
                }

                var studentToUpdate =
                    studentService.GetStudentById(updateStudentId);

                if (studentToUpdate == null)
                {
                    Console.WriteLine("Student not found.");
                    Console.ReadKey();
                    break;
                }

                Console.Write("New Fullname: ");
                string newFullName = Console.ReadLine();

                Console.Write("New GPA: ");

                if (!double.TryParse(Console.ReadLine(), out double newGpa))
                {
                    Console.WriteLine("Invalid GPA.");
                    Console.ReadKey();
                    break;
                }

                Console.Write("New Group Id: ");

                if (!int.TryParse(Console.ReadLine(), out int newGroupId))
                {
                    Console.WriteLine("Invalid Group Id.");
                    Console.ReadKey();
                    break;
                }

                if (studentService.UpdateStudent(
                        updateStudentId,
                        newFullName,
                        newGpa,
                        newGroupId))
                {
                    Console.WriteLine("Student updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student could not be updated.");
                }

                Console.ReadKey();
                break;

            case "5":
                Console.Write("Student Id: ");

                if (!int.TryParse(Console.ReadLine(), out int deleteStudentId))
                {
                    Console.WriteLine("Invalid Id.");
                    Console.ReadKey();
                    break;
                }

                if (studentService.DeleteStudent(deleteStudentId))
                    Console.WriteLine("Student deleted successfully.");
                else
                    Console.WriteLine("Student not found.");

                Console.ReadKey();
                break;

            case "6":
                Console.Write("Group Id: ");

                if (!int.TryParse(Console.ReadLine(), out int studentsGroupId))
                {
                    Console.WriteLine("Invalid Group Id.");
                    Console.ReadKey();
                    break;
                }

                var selectedGroup =
                    groupService.GetGroupById(studentsGroupId);

                if (selectedGroup == null)
                {
                    Console.WriteLine("Group not found.");
                    Console.ReadKey();
                    break;
                }

                var groupStudents =
                    studentService.GetStudentsByGroup(studentsGroupId);

                Console.WriteLine();
                Console.WriteLine($"Group: {selectedGroup.Name}");
                Console.WriteLine();

                if (groupStudents.Count == 0)
                {
                    Console.WriteLine("There are no students in this group.");
                }
                else
                {
                    foreach (var s in groupStudents)
                    {
                        Console.WriteLine(
                            $"{s.Id} - {s.FullName} - {s.GPA}");
                    }
                }

                Console.ReadKey();
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                break;
        }
    }
}