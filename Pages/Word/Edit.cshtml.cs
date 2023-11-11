using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocas.Models;
using Vocas.Data;
using Microsoft.EntityFrameworkCore;

public class EditModel : PageModel
{
    private readonly VocasContext _context;

    public EditModel(VocasContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Word Word { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Word = await _context.Words.FirstOrDefaultAsync(m => m.WordId == id);

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
            if (!WordExists(Word.WordId))
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
        return _context.Words.Any(e => e.WordId == id);
    }
}
