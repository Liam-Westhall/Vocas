namespace Vocas.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // In a real app, ensure this is securely managed
                                                 // Navigation property
        public virtual ICollection<Word> VocabTerms { get; set; }
    }
}
}
