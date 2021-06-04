using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.DataAccess.Entity;
using Zhaoxi.CourseManagement.Common;
using System.Diagnostics;

namespace Zhaoxi.CourseManagement.DataAccess
{
    /// <summary>
    /// Simple singleton. Not thread safe.
    /// https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    /// </summary>
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private string connStr;

        private LocalDataAccess() { }

        public static LocalDataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalDataAccess
                    {
                        connStr = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString
                    };
                }
                return instance;
            }
        }


        /// <summary>
        /// Given the user name and the password, fetch the user information if it is valid.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns>A user entity that contains the user information; or <see langword="null"/> if the user fails validation.</returns>
        public UserEntity CheckUserInfo(string userName, string pwd)
        {
            // check whether the user exists and validate the password
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var sql = $"SELECT * FROM dbo_users WHERE user_name = \"{userName}\"";
            using var cmd = new MySqlCommand(sql, conn);
            using MySqlDataReader reader = cmd.ExecuteReader();
            Debug.WriteLine("SQL: " + sql);
            if (reader.HasRows)  // user exists
            {
                Debug.WriteLine($"User {userName} exists.");
                var pwdMD5 = Encrytor.ComputeMD5(userName + pwd);
                reader.Read(); // advance to the first record
                var truePwdMD5 = reader.GetString("password");
                Debug.WriteLine($"Computed MD5: {pwdMD5}");
                if (pwdMD5 == truePwdMD5)  // correct password
                {
                    Debug.WriteLine($"Password '{pwd}' is correct!");
                    var userEntity = new UserEntity()
                    {
                        UserName = userName,
                        RealName = reader.GetString("real_name"),
                        Avatar = reader.GetString("avatar"),
                        Gender = reader.GetInt32("gender")
                    };
                    Debug.WriteLine(userEntity);
                    return userEntity;
                }
            }
            return null;
        }
    }
}
