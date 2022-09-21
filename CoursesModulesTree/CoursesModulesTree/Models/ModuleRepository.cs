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
        List<Module> GetModules(Tree tree);
    }

    public class Repository : IRepository
    {
        string connectionString = null;
        public Repository(string conn)
        {
            connectionString = conn;
        }
        public List<Module> GetModules(Tree t)
        {
            string sqlScript = @"select m.ParentId, m.Id, m.CourseId, m.Title, m.num from dbo.Modules m 
                            inner join dbo.Courses c on c.Id = m.CourseId 
                                where 
                                    (c.[Subject] = @subject or @subject is null)
                                and (c.[Grade] = @grade or @grade is null)
                                and (c.[Genre] = @genre or @genre is null)";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Module>(sqlScript, new {t.subject, t.grade, t.genre}).ToList();
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
