using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace CoursesModulesTree.Models
{
    public interface IRepository
    {
        List<Course> GetCourses();
        List<Module> GetModules();
    }

    public class Repository : IRepository
    {
        string connectionString = null;
        public Repository(string conn)
        {
            connectionString = conn;
        }
        public List<Module> GetModules()
        {
            string sqlScript = "select m.ParentId, m.Id, m.CourseId, m.Title, m.num from dbo.Modules m";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Module>(sqlScript).ToList();
            }
        }
        public List<Course> GetCourses()
        {
            string sqlScript = "select c.id, c.Title, c.[Subject], c.Grade, c.Genre from dbo.Courses c";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Course>(sqlScript).ToList();
            }
        }
    }
}
