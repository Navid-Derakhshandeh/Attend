using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseLib
{
    public class Sqlinfo : SqlData
    {
        private readonly IConfiguration _Config;

        public string CString { get; set; } = "DataSource";
        public Sqlinfo(IConfiguration Config)
        {
            _Config = Config;

        }

        public async Task<List<T>> UploadData<T, U>(string sql, U parameters)
        {
            string cstring = _Config.GetConnectionString(CString);

            using (IDbConnection connection = new SqlConnection(cstring))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task InsertData<T>(string sql, T parameters)
        {
            string cstring = _Config.GetConnectionString(CString);

            using (IDbConnection connection = new SqlConnection(cstring))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
