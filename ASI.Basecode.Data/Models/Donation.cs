using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASI.Basecode.Data.Models
{
    public class Donation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Donator Name is Required")]
        public string Donator { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        public DateTime DateTimeCreated { get; set; } = DateTime.Now;

    }
}
