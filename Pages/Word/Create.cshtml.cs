using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vocas.Models;
using Vocas.Data;

public class CreateModel : PageModel
{
    private readonly VocasContext _context;

    public CreateModel(VocasContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Word Word { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Words.Add(Word);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
