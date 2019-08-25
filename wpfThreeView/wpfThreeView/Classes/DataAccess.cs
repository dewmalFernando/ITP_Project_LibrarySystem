using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace wpfThreeView.Classes
{
    class DataAccess
    {
        
       
        /// <summary>
        /// Insert member data into database
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Age"></param>
        /// <param name="Gender"></param>
        /// <param name="UserType"></param>
        /// <param name="Email"></param>
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

        /// <summary>
        /// Insert book data into database
        /// </summary>
        internal void InsertBook(String Title, String Author, int NoOfCoppies, int Avilability, int RackNo, String ISBN, String Publisher)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("wpfThreeView.Properties.Settings.LibraryManagementSystemConnectionString")))
            {
                List<Book> book = new List<Book>();
                book.Add(new Book { title = Title, author = Author, noOfCoppies = NoOfCoppies, avilability = Avilability, rackNo = RackNo, isbn = ISBN, publisher = Publisher });
                connection.Execute("dbo.Book_Insert  @Title, @Author, @NoOfCoppies, @Avilability, @RackNo, @ISBN,@Publisher", book);
            }
        }

        /*internal void DeleteBook(int Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("wpfThreeView.Properties.Settings.LibraryManagementSystemConnectionString")))
            {
                List<Book> book = new List<Book>();
                book.Remove(new Book { id = Id });
                connection.Execute("dbo.Book_Delete @DeleteBookByID", book);
            }
        }*/
    }
}
