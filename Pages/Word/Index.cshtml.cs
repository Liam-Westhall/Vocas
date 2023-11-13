using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocas.Models;
using Vocas.Data;
using Microsoft.EntityFrameworkCore;

namespace Vocas.Pages.Word;
public class IndexModel : PageModel
{
    private readonly VocasContext _context;

    public IndexModel(VocasContext context)
    {
        _context = context;
    }

    public IList<Vocas.Models.Word>? Word { get; set; }

    public async Task OnGetAsync()
    {
        Word = await _context.Words.ToListAsync();
    }
}
