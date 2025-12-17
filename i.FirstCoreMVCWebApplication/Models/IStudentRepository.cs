namespace i.FirstCoreMVCWebApplication.Models;
public interface IStudentRepository
{
    Student GetStudentById(int StudentId);
}