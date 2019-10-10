using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace erpc_system_backend.Classes
{
    public static class Template 
    {
        public static string GetHTMLString()
        {
            var employees = new List<Models.Employee>();

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>");

            /* 
            foreach (var emp in employees)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.Name, emp.LastName, emp.Age, emp.Gender);
            }

            */
 
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
 
            return sb.ToString();
        }

    }
}