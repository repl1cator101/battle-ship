using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages_ShipConfiguration
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DetailsModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public GameShipConfig GameShipConfig { get; set; }  = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameShipConfig = await _context.GameShipConfig
                .Include(g => g.GameConfig).FirstOrDefaultAsync(m => m.GameShipConfigId == id);

            if (GameShipConfig == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
