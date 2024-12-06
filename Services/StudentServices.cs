namespace Infrostructure.Services;
using Infrostructure.Interface;
using Infrostructure.Models;
using Npgsql;
using Dapper;

public class StudentServices: IStudentServices
{
    private string mainConnection = "Server=localhost;Port=5432;Database=StudentsDb;Username=postgres;Password=12345";
    public bool CreateStudent(Student student)
    {
        using (NpgsqlConnection npgsqlConnection= new NpgsqlConnection(mainConnection))
        {
         var sql = "insert into Students(fullname, age, score)values (@Fullname, @Age, @Score);";
         var res = npgsqlConnection.Execute(sql,student);
         return res > 0;
        }
    }
    public List<Student> GetStudents()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(mainConnection))
        {
            var sql = "select * from Students";
            var res = connection.Query<Student>(sql).ToList();
            return res;
        }
    }
    public Student GetStudentById(int id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(mainConnection))
        {
            var sql = "select * from Students where id=@Id";
            var res = connection.QuerySingle<Student>(sql,new {Id=id});
            return res;
        }
    }
    public bool Update(Student student)
    {
        using (NpgsqlConnection npgsqlConnection= new NpgsqlConnection(mainConnection))
        {
            var sql = "update Students set fullname=@Fullname,age=@Age,score=@Score where id=@Id;";
            var res = npgsqlConnection.Execute(sql,student);
            return res > 0;
        }
    }

    public bool Delete(int id)
    {
        using (NpgsqlConnection npgsqlConnection= new NpgsqlConnection(mainConnection))
        {
            var sql = "delete from Students where id=@Id;";
            var res = npgsqlConnection.Execute(sql,new {Id=id});
            return res > 0;
        }
    }
}