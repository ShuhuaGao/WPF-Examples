using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private MySqlConnection conn;
        private MySqlCommand comm;
        private MySqlDataAdapter adapter;


    }
}
