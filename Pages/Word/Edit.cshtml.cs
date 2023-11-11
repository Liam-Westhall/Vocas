using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocas.Models;
using Vocas.Data;
using Microsoft.EntityFrameworkCore;


namespace Vocas.Pages.Word;
public class EditModel : PageModel
{
    private readonly VocasContext _context;

    public EditModel(VocasContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Word).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WordExists(Word.WordID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool WordExists(int id)
    {
        return _context.Words.Any(e => e.WordID == id);
    }
}
