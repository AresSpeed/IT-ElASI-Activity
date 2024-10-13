using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASI.Basecode.Data.Models
{
    public class Contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Number is Required")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        public DateTime DateTimeCreated = DateTime.Now;
    }
}
