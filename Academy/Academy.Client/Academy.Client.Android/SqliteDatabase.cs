using Academy.ClientDataLayer;
using Academy.UtilityAndModels;
using SQLite;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class SqliteDatabase: ISqliteDatabase
{
    public async Task<SQLiteAsyncConnection> GetNativeSqlConnectionAsync()
    {
        SQLiteAsyncConnection database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Constants.SQLITE_DB_NAME));
        //await database.SetKeyAsync(Encoding.ASCII.GetBytes(await new SecureStorageService().Retrieve(PreferencesAndSecureStorageConstants.SS_ENC_KEY_KEY)));
        return database;
    }
}