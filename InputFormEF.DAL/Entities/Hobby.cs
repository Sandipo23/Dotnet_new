using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL.Entities
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StudentHobby> StudentHobbies { get; set; }
    }
}