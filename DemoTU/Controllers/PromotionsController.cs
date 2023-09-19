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
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly AnnuaireContext _context;

        public PromotionsController(AnnuaireContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de toutes les promotions
        /// </summary>
        /// <returns>Liste des promotions</returns>
        /// <response code="200">Liste des promotions</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
        {
            return await _context.Promotions.OrderByDescending(p => p.Debut).ThenByDescending(p => p.Fin).ToListAsync();
        }

        /// <summary>
        /// Récupération d'une promotion
        /// </summary>
        /// <param name="id">Identifiant de la promotion</param>
        /// <returns>Retourne la promotion</returns>
        /// <response code="200">Promotion demandée</response>
        /// <response code="404">Promotion non trouvée</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Promotion>> GetPromotions(int id)
        {
            var promotions = await _context.Promotions.FindAsync(id);

            if (promotions == null)
            {
                return NotFound();
            }

            return promotions;
        }

        /// <summary>
        /// Récupère la liste des élèves d'une promotion
        /// </summary>
        /// <param name="id">Identifiant de la promotion</param>
        /// <returns>Liste des élèves</returns>
        /// <response code="200">Liste des élèves</response>
        /// <response code="404">La promotion n'existe pas</response>
        [HttpGet("{id}/eleves")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleves(int id)
        {
            Promotion promotion = await _context.Promotions.Include(p => p.Eleves).Where(p => p.Id == id).FirstOrDefaultAsync();
            if (promotion == null)
                return NotFound();
            var eleves = promotion.Eleves.OrderBy(e => e.Nom).ThenBy(e => e.Prenom).ToList();

            return eleves;
        }

        /// <summary>
        /// Met à jour une promotion
        /// </summary>
        /// <param name="id">Identifiant de la promotion</param>
        /// <param name="promotions">Informations de la promotion</param>
        /// <returns></returns>
        /// <response code="204">Promotion mise à jour</response>
        /// <response code="400">Id différent de l'id de la promotion envoyée</response>
        /// <response code="404">La promotion n'existe pas</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPromotions(int id, Promotion promotions)
        {
            if (id != promotions.Id)
            {
                return BadRequest();
            }

            _context.Entry(promotions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionsExists(id))
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
        /// Création d'une promotion
        /// </summary>
        /// <param name="promotions">Promotion à créer</param>
        /// <returns>Promotion créée</returns>
        /// <response code="201">Promotion créée</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Promotion>> PostPromotions(Promotion promotions)
        {
            _context.Promotions.Add(promotions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotions", new { id = promotions.Id }, promotions);
        }

        /// <summary>
        /// Suppression d'une promotion
        /// </summary>
        /// <param name="id">Identifiant de la promotion à supprimer</param>
        /// <returns>Promotion supprimée</returns>
        /// <response code="200">Promotion supprimée</response>
        /// <response code="404">Promotion non trouvée</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Promotion>> DeletePromotions(int id)
        {
            var promotions = await _context.Promotions.FindAsync(id);
            if (promotions == null)
            {
                return NotFound();
            }

            _context.Promotions.Remove(promotions);
            await _context.SaveChangesAsync();

            return promotions;
        }

        private bool PromotionsExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}
