using System.ComponentModel.DataAnnotations;

namespace SpravaUdalosti.Models
{   // Creating an enum for music genre
    public enum MusicGenre : int
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

        // Creating a model for an artist + table in the database
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string NameOfInterpret { get; set; }

        [Required]
        [MaxLength(100)]
        public string DescriptionOfInterpret { get; set; }

        [Required]
        [EnumDataType(typeof(MusicGenre))]
        public MusicGenre MusicGenre { get; set; }

        [Required]
        public string CountryOfOrigin { get; set; }

       

    }
}
