using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocas.Models;
using Vocas.Data;
using Microsoft.EntityFrameworkCore;

namespace Vocas.Pages.Word;
public class DeleteModel : PageModel
{
    private readonly VocasContext _context;

    public DeleteModel(VocasContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Vocas.Models.Word Word { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Word = await _context.Words.FirstOrDefaultAsync(m => m.WordID == id);

        if (Word == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        Word = await _context.Words.FindAsync(id);

        if (Word != null)
        {
            _context.Words.Remove(Word);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
