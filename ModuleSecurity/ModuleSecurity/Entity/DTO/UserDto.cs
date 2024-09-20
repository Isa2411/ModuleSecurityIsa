using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Security;

namespace Entity.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Person IdPerson { get; set; }
        public bool State { get; set; }
    }
}
