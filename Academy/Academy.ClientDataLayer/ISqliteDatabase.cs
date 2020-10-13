using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ClientDataLayer
{
    public interface ISqliteDatabase
    {
        Task<SQLiteAsyncConnection> GetNativeSqlConnectionAsync();
    }
}
