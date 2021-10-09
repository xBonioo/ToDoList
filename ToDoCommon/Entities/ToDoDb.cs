using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCommon.Entities
{
    public class ToDoDb
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Filed name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
