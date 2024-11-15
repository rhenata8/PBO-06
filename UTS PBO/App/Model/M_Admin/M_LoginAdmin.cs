using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO.App.Model.M_Admin
{
    internal class M_LoginAdmin
    {
        [Key]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        
    }
}
