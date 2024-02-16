using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseLib
{
    public interface SqlData
    {
        string CString { get; set; }

        Task<List<T>> UploadData<T, U>(string sql, U parameters);
        Task InsertData<T>(string sql, T parameters);
    }
}
