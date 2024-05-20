using System.ComponentModel.DataAnnotations;

namespace SpravaUdalosti.Models
{   //Zalození enumu pro zanr hudby
    public enum HudebniZanr : int
    {   
        Techno = 1,
        House = 2,
        Trance = 3,
        Dubstep = 4,
        DrumAndBass = 5,
        HipHop = 6,
        Rap = 7,
        RnB = 8,
        Pop = 9,
        Rock = 10,
        Ostatni = 11

    }
    public class Interprets
    {

        //Zalození modelu pro interpreta + tabulka v databázi
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string NazevInterpreta { get; set; }

        [Required]
        [MaxLength(100)]
        public string PopisInterpreta { get; set; }

        [Required]
        [EnumDataType(typeof(HudebniZanr))]
        public HudebniZanr HudebniZanr { get; set; }

        [Required]
        public string ZemePuvodu { get; set; }

       

    }
}
