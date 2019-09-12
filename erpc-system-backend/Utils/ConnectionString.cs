using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erpc_system_backend.Utils
{
    public static class ConnectionString
    {
        /// <summary>
        /// Returns the database´s connectionString taken from 'connection.conn'
        /// </summary>
        /// <returns></returns>
        public static string Get()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connection.conn");

            return System.IO.File.ReadAllText(path, Encoding.UTF8);
        }
    }
}
