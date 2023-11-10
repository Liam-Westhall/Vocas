using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Vocas.Models
{
    public class User : IdentityUser
    {
   
        public virtual ICollection<Word> VocabTerms { get; set; }
    }
}

