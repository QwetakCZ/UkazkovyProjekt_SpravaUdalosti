using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpravaUdalosti.Models
{
    public class Event
    {
        //Zalození modelu pro událost + tabulka v databázi
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Zadejte název události")]
        [MaxLength(30, ErrorMessage = "Zadejte název max. 30 znaků"),]
        public string NazevUdálosti { get; set; }

        [Required(ErrorMessage = "Zadejte popis události")]
        [MaxLength(100, ErrorMessage = "Zadejte popis max. 100 znaků")]
        public string PopisUdalosti { get; set; }

        [Required(ErrorMessage = "Zadejte datum události")]
        public DateTime DatumUdalosti { get; set; }

        [Required(ErrorMessage = "Zadejte místo konání události")]
        [MaxLength(50, ErrorMessage = "Zadejte místo konání max. 50 znaků")]
        public string MistoKonani { get; set; }

        [Required(ErrorMessage = "Zadejte maximální počet účastníků")]
        public int MaxPocetUcastniku { get; set; }

        public int ZucastniSe { get; set; } = 0;

        [Required(ErrorMessage = "Zadejte vystupujícího interpreta")]
        public int InterpretId { get; set; }

        [ForeignKey("InterpretId")]
        public Interprets? Interpret { get; set; } = null;




    }
}
