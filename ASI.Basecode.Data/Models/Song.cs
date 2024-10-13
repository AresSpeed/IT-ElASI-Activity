using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string Album { get; set; }

        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
    }
}
