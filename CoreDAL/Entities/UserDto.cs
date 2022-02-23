using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreDAL.Entities
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
