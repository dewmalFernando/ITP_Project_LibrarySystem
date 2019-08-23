using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace wpfThreeView.Classes
{
    class DataAccess
    {
        public List<Member> GetMember(String lastName)
        {
            //Making a new connection
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("wpfThreeView.Properties.Settings.LibraryManagementSystemConnectionString")))
            {
                var output = connection.Query<Member>("dbo.Member_GetByLastName @LastName", new { LastName = lastName }).ToList();
                return output;
            }
        }

        internal void InsertMember(string FirstName, string LastName, int Age, char Gender, string UserType, string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("wpfThreeView.Properties.Settings.LibraryManagementSystemConnectionString")))
            {
                //Member newMember = new Member { firstName = FirstName , lastName = LastName, age = Age, gender = Gender, type = UserType, email = Email};

                List<Member> member = new List<Member>();
                member.Add(new Member { firstName = FirstName, lastName = LastName, age = Age, gender = Gender, type = UserType, email = Email });
                connection.Execute("dbo.Member_Insert @FirstName, @LastName, @Age, @Gender, @Type, @Email", member);
            }
        }
    }
}
