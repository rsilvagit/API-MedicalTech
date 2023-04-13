using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalTech.Dto;
using MedicalTech.Models;

namespace MedicalTech.Controllers
{
    public class PessoaController : Controller
    {
        private readonly MedicalTechContext _context;

        public PessoaController(MedicalTechContext context)
        {
            _context = context;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index()
        {
              return _context.PessoaDto != null ? 
                          View(await _context.PessoaDto.ToListAsync()) :
                          Problem("Entity set 'MedicalTechContext.PessoaDto'  is null.");
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PessoaDto == null)
            {
                return NotFound();
            }

            var pessoaDto = await _context.PessoaDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaDto == null)
            {
                return NotFound();
            }

            return View(pessoaDto);
        }

        // GET: Pessoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,DataNascimento,Cpf,Telefone")] PessoaDto pessoaDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaDto);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PessoaDto == null)
            {
                return NotFound();
            }

            var pessoaDto = await _context.PessoaDto.FindAsync(id);
            if (pessoaDto == null)
            {
                return NotFound();
            }
            return View(pessoaDto);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCompleto,DataNascimento,Cpf,Telefone")] PessoaDto pessoaDto)
        {
            if (id != pessoaDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaDtoExists(pessoaDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaDto);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PessoaDto == null)
            {
                return NotFound();
            }

            var pessoaDto = await _context.PessoaDto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaDto == null)
            {
                return NotFound();
            }

            return View(pessoaDto);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PessoaDto == null)
            {
                return Problem("Entity set 'MedicalTechContext.PessoaDto'  is null.");
            }
            var pessoaDto = await _context.PessoaDto.FindAsync(id);
            if (pessoaDto != null)
            {
                _context.PessoaDto.Remove(pessoaDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaDtoExists(int id)
        {
          return (_context.PessoaDto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
