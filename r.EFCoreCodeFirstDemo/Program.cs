using Microsoft.EntityFrameworkCore;
using r.EFCoreCodeFirstDemo.Entities;
namespace r.EFCoreCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize the DbContext
                using var context = new EFCoreDbContextFactory().CreateDbContext(args);
                {
                    // Define the filtering criteria
                    string branchName = "Computer Science Engineering"; // Branch name filter
                    string gender = "Female"; // Gender filter
                    
                    // LINQ Query Syntax to filter students by branch name and gender with eager loading
                    var filteredStudentsQS = (from student in context.Students
                                             .Include(s => s.Branch) // Eager loading of the Branch property
                                             where student.Branch.BranchName == branchName && student.Gender == gender
                                             select student).ToList();
                    
                    // LINQ Method Syntax to filter students by branch name and gender with eager loading
                    var filteredStudents = context.Students
                                                  .Include(s => s.Branch) // Eager loading of the Branch property
                                                  .Where(s => s.Branch.BranchName == branchName && s.Gender == gender)
                                                  .ToList();
                    
                    // Check if any students match the filtering criteria
                    if (filteredStudentsQS.Any())
                    {
                        // Iterate through the filtered students and display their details
                        foreach (var student in filteredStudentsQS)
                        {
                            Console.WriteLine($"Student Found: {student.FirstName} {student.LastName}, Branch: {student.Branch.BranchName}, Gender: {student.Gender}");
                        }
                    }
                    else
                    {
                        // Output if no students match the filtering criteria
                        Console.WriteLine("No students found matching the given criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Exception handling: log the exception message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}


// using r.EFCoreCodeFirstDemo.Entities;
// namespace r.EFCoreCodeFirstDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             try
//             {
//                 // Initialize the DbContext
//                 using var context = new EFCoreDbContextFactory().CreateDbContext(args);
//                 {
//                     // Define the search criteria (searching for a student with the first name "Alice")
//                     string searchFirstName = "Alice";
                    
//                     // LINQ Query Syntax to search for a student by first name
//                     var searchResultQS = (from student in context.Students
//                                          where student.FirstName == searchFirstName
//                                          select student).ToList();
                    
//                     // LINQ Method Syntax to search for a student by first name
//                     var searchResultMS = context.Students //accesses the Students DbSet
//                                               .Where(s => s.FirstName == searchFirstName) //filters students with the given first name
//                                               .ToList(); //executes the query and returns the result as a list
                    
//                     // Check if any student is found
//                     if (searchResultQS.Any())
//                     {
//                         // Iterate through the result and display the student's details
//                         foreach (var student in searchResultQS)
//                         {
//                             Console.WriteLine($"Student Found: {student.FirstName} {student.LastName}, Email: {student.Email}");
//                         }
//                     }
//                     else
//                     {
//                         // Output if no student is found
//                         Console.WriteLine("No student found with the given first name.");
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Exception handling: log the exception message
//                 Console.WriteLine($"An error occurred: {ex.Message}");
//             }
//         }
//     }
// }

