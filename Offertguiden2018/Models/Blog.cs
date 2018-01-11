using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Offertguiden.Models
{
        public class Blog
        {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }

            [Required(ErrorMessage = "Title is required.")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Text is required.")]
            public string Text { get; set; }

            [Required(ErrorMessage = "Date is required.")]
            public string Date { get; set; }

            public string Picture { get; set; }
        }
}
