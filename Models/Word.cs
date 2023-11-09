namespace Vocas.Models
{
    public class Word
    {
        public int WordID { get; set; }
        public string Term { get; set; }
        public string PartOfSpeech { get; set; }
        public string Definition { get; set; }
        public string Example { get; set; }
        
        public string Language { get; set; }
        // Foreign key
        public int UserId { get; set; }
        // Navigation property
        public virtual User User { get; set; }
    }

}

