using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Pages
{
    public class ViccikekListaModel : PageModel
    {
        private readonly ViccAdatbazis.Data.ViccDbContext _context;

        public ViccikekListaModel(ViccAdatbazis.Data.ViccDbContext context)
        {
            _context = context;
        }

        public IList<Vicc> Vicc { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vicc = await _context.Viccek.ToListAsync();
        }
    }
}
