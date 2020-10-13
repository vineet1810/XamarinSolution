using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Academy.UtilityAndModels
{
    public class Constants
    {
        public static string SYMBOL_AT_THE_RATE => "@";
        public static string URL_CONSTANT_GET_USER => "http://192.168.0.102:2229/GetUser";
        public static string URL_CONSTANT_SAVE_USER => "http://192.168.0.102:2229/SaveUser";
        public static string URL_CONSTANT_LOGIN => "http://192.168.0.102:2229/Login";
        public static string SQLITE_DB_NAME => "academy.db3";
        public static string UserIDPreference => "userID";
        public static string UserRoleIDPreference => "roleID";
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, SQLITE_DB_NAME);
            }
        }
    }
}
