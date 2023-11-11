using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocas.Models;
using Vocas.Data;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly VocasContext _context;

    public IndexModel(VocasContext context)
    {
        _context = context;
    }

    public IList<Word> Word { get; set; }

    public async Task OnGetAsync()
    {
        Word = await _context.Words.ToListAsync();
    }
}
