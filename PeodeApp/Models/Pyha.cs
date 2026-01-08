using System.ComponentModel.DataAnnotations;

namespace PeodeApp.Models
{
    public class Pyha
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nimetus on kohustlik")]
        public string Nimi { get; set; }

        [DataType(DataType.Date)]
        public DateTime Kuupaev { get; set; }
    }
}
