using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoTU.Models;

namespace DemoTU.Controllers
{
    /// <summary>
    /// Gestion des diplômes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DiplomesController : ControllerBase
    {
        private readonly AnnuaireContext _context;

        public DiplomesController(AnnuaireContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de tous les diplômes
        /// </summary>
        /// <returns>Liste des diplômes triés par niveau puis nom</returns>
        /// <response code="200">Succès</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Diplome>>> GetDiplomes()
        {
            return await _context.Diplomes.OrderBy(d => d.Niveau).ThenBy(d => d.Nom).ToListAsync();
        }

        /// <summary>
        /// Récupération d'un diplome dont le code est passé en paramètre
        /// </summary>
        /// <param name="code">Code du diplôme à récupérer</param>
        /// <returns>Retourne le diplôme demandé</returns>
        /// <response code="200">Succès</response>
        /// <response code="404">Diplôme non trouvé</response>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Diplome>> GetDiplomes(string code)
        {
            var diplomes = await _context.Diplomes.FindAsync(code);

            if (diplomes == null)
            {
                return NotFound();
            }

            return diplomes;
        }

        /// <summary>
        /// Récupère les promotions liées au diplôme
        /// </summary>
        /// <param name="code">Code du diplôme à récupérer</param>
        /// <returns>Liste des promotions</returns>
        /// <response code="200">Succès</response>
        /// <response code="400">Code vide ou null</response>
        /// <response code="404">Le diplôme n'existe pas</response>
        [HttpGet("{code}/promotions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest();
            }

            Diplome diplome = await _context.Diplomes.Include(d => d.Promotions).Where(d => d.Code.Equals(code)).FirstOrDefaultAsync();
            if (diplome == null)
            {
                return NotFound();
            }
            var promotions = diplome.Promotions.ToList();

            return promotions;
        }

        /// <summary>
        /// Mise à jour d'un diplôme
        /// </summary>
        /// <param name="code">Code du diplôme à mettre à jour</param>
        /// <param name="diplomes">Nouvelles informations de diplôme</param>
        /// <returns></returns>
        /// <response code="204">Diplôme mis à jour</response>
        /// <response code="400">Code différent du code du diplôme envoyé</response>
        /// <response code="404">Le diplôme n'existe pas</response>
        [HttpPut("{code}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutDiplomes(string code, Diplome diplomes)
        {
            if (code != diplomes.Code)
            {
                return BadRequest();
            }

            _context.Entry(diplomes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomesExists(code))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Création d'un diplôme
        /// </summary>
        /// <param name="diplomes">Diplôme à créer</param>
        /// <returns>Retourne le diplôme créé</returns>
        /// <response code="201">Le diplôme a été créé</response>
        /// <response code="409">Le diplôme existe déjà</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Diplome>> PostDiplomes(Diplome diplomes)
        {
            _context.Diplomes.Add(diplomes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiplomesExists(diplomes.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiplomes", new { id = diplomes.Code }, diplomes);
        }

        /// <summary>
        /// Suppression d'un diplôme
        /// </summary>
        /// <param name="code">Code du diplôme à supprimer</param>
        /// <returns>Retourne le diplôme supprimé</returns>
        /// <response code="200">Le diplôme a été supprimé</response>
        /// <response code="404">Le diplôme n'existe pas</response>
        [HttpDelete("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Diplome>> DeleteDiplomes(string code)
        {
            var diplomes = await _context.Diplomes.FindAsync(code);
            if (diplomes == null)
            {
                return NotFound();
            }

            _context.Diplomes.Remove(diplomes);
            await _context.SaveChangesAsync();

            return diplomes;
        }

        private bool DiplomesExists(string id)
        {
            return _context.Diplomes.Any(e => e.Code == id);
        }
    }
}
