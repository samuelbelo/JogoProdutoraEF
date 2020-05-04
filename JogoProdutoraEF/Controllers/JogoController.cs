using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JogoProdutoraEF.Data;
using JogoProdutoraEF.Domain.Model.Interfaces.Services;
using JogoProdutoraEF.Models;
using JogoProdutoraEF.Domain.Models;

namespace JogoProdutoraEF.Controllers
{
    public class JogoController : Controller
    {
        private readonly IJogoService _jogoService;
        private readonly JogoProdutoraContext _context;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        // GET: Jogo
        public async Task<IActionResult> Index()
        {
            return View(await _jogoService.GetAllAsync());
        }

        // GET: Jogo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoModel = await _jogoService.GetByIdAsync(id.Value);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Lancamento")] JogoModel jogoModel)
        {
            if (ModelState.IsValid)
            {
                await _jogoService.InsertAsync(jogoModel);
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

            var jogoModel = await _jogoService.GetByIdAsync(id.Value);
            if (jogoModel == null)
            {
                return NotFound();
            }

            return View(jogoModel);
        }

        // POST: Jogo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Lancamento")] JogoModel jogoModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jogoService.UpdateAsync(jogoModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _jogoService.GetByIdAsync(id) == null)
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

            var jogoModel = await _jogoService.GetByIdAsync(id.Value);
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
            await _jogoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool JogoModelExists(int id)
        {
            return _context.Jogos.Any(e => e.Id == id);
        }
    }
}