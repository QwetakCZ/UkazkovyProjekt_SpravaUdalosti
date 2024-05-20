using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpravaUdalosti.Models
{
    public class Event
    {
        // Creating a model for an event + table in the database
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Zadejte název události")]
        [MaxLength(30, ErrorMessage = "Zadejte název max. 30 znaků"),]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Zadejte popis události")]
        [MaxLength(100, ErrorMessage = "Zadejte popis max. 100 znaků")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Zadejte datum události")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Zadejte místo konání události")]
        [MaxLength(50, ErrorMessage = "Zadejte místo konání max. 50 znaků")]
        public string EventPlace { get; set; }

        [Required(ErrorMessage = "Zadejte maximální počet účastníků")]
        public int MaxNumberOfParticipants { get; set; }

        public int WillParticipate { get; set; } = 0;

        [Required(ErrorMessage = "Zadejte vystupujícího interpreta")]
        public int InterpretId { get; set; }

        [ForeignKey("InterpretId")]
        public Interprets? Interpret { get; set; } = null;




    }
}
