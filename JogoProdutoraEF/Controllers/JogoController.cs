using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JogoProdutoraEF.Data;
using JogoProdutoraEF.Models;

namespace JogoProdutoraEF.Controllers
{
    public class JogoController : Controller
    {
        private readonly JogoProdutoraContext _context;

        public JogoController(JogoProdutoraContext context)
        {
            _context = context;
        }

        // GET: Jogo
        public async Task<IActionResult> Index()
        {
            return View(await _context.JogoModel.ToListAsync());
        }

        // GET: Jogo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoModel = await _context.JogoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoModel == null)
            {
                return NotFound();
            }

            return View(jogoModel);
        }

        // GET: Jogo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Lancamento")] JogoModel jogoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogoModel);
        }

        // GET: Jogo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoModel = await _context.JogoModel.FindAsync(id);
            if (jogoModel == null)
            {
                return NotFound();
            }
            return View(jogoModel);
        }

        // POST: Jogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Lancamento")] JogoModel jogoModel)
        {
            if (id != jogoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoModelExists(jogoModel.Id))
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
            return View(jogoModel);
        }

        // GET: Jogo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoModel = await _context.JogoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoModel == null)
            {
                return NotFound();
            }

            return View(jogoModel);
        }

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogoModel = await _context.JogoModel.FindAsync(id);
            _context.JogoModel.Remove(jogoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoModelExists(int id)
        {
            return _context.JogoModel.Any(e => e.Id == id);
        }
    }
}
