using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Asphalt_9_Materials.ViewModel.Helpers
{
    public class DatabaseScript
    {
        /// <summary>
        /// Generating Database script from given connection string.
        /// </summary>
        /// <param name="connectionString">SqlServer connection string.</param>
        /// <param name="fileName">Filename</param>
        /// <returns></returns>
        public async Task GenerateDatabaseScript(string connectionString, string fileName)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var server = new Server(new ServerConnection(sql));
                var db = server.Databases[sql.Database];

                var options = new ScriptingOptions()
                {
                    FileName = fileName,
                    EnforceScriptingOptions = true,
                    WithDependencies = false,
                    IncludeHeaders = true,
                    ScriptDrops = false,
                    AppendToFile = true,
                    ScriptSchema = true,
                    ScriptData = true,
                    Indexes = false,
                    ScriptOwner = true,

                };

                await Task.Factory.StartNew(() =>
                {
                    foreach (Table tb in db.Tables)
                    {
                        db.Tables[tb.Name].EnumScript(options);
                    }
                });
            }
        }

    }
}
