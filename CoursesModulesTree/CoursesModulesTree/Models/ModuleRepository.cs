using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace CoursesModulesTree.Models
{
    public interface IModuleRepository
    {
        List<Module> GetModules();
    }

    public class ModuleRepository : IModuleRepository
    {
        string connectionString = null;
        public ModuleRepository(string conn)
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
    }
}
