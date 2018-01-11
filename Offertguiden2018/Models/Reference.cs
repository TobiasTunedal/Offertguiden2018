using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Offertguiden.Models
{
    public class Reference
    {
        [Key]
        
        public int ReferenceId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; set; }

        public string Picture { get; set; }
    }
}
