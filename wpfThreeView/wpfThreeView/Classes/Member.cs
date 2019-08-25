using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfThreeView.Classes
{
    class Member
    {
        public String id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public int age { get; set; }
        public char gender { get; set; }
        public String type { get; set; }
        public String email { get; set; }
        public int noOfBooksBorrowed { get; set; }

        public String FullInfo 
        {
            get 
            { 
                return $"{firstName} {lastName} ({ email })"; 
            }
        }
    }
}
