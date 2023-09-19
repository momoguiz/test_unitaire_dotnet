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
    public class ElevesController : ControllerBase
    {
        private readonly AnnuaireContext _context;

        public ElevesController(AnnuaireContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupération de la liste des élèves
        /// </summary>
        /// <returns>Liste des élèves</returns>
        /// <response code="200">Liste des élèves</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Eleve>>> GetEleves()
        {
            return await _context.Eleves.ToListAsync();
        }

        /// <summary>
        /// Récupération d'un élève 
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Retourne un élève</returns>
        /// <response code="200">Élève trouvé</response>
        /// <response code="404">Élève non trouvé</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Eleve>> GetEleves(int id)
        {
            var eleves = await _context.Eleves.FindAsync(id);

            if (eleves == null)
            {
                return NotFound();
            }

            return eleves;
        }

        /// <summary>
        /// Mise à jour d'un élève
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <param name="eleves">Informations de l'élève</param>
        /// <returns></returns>
        /// <response code="204">Élève mis à jour</response>
        /// <response code="400">L'id ne correspond pas à l'id de l'élève</response>
        /// <response code="404">Élève non trouvé</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutEleves(int id, Eleve eleves)
        {
            if (id != eleves.Id)
            {
                return BadRequest();
            }

            _context.Entry(eleves).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevesExists(id))
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
        /// Création d'un élève
        /// </summary>
        /// <param name="eleves">Élève à créer</param>
        /// <returns>Élève créé</returns>
        /// <response code="201">Élève créé</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Eleve>> PostEleves(Eleve eleves)
        {
            _context.Eleves.Add(eleves);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleves", new { id = eleves.Id }, eleves);
        }

        /// <summary>
        /// Suppression d'un élève
        /// </summary>
        /// <param name="id">Identifiant de l'élève</param>
        /// <returns>Élève supprimé</returns>
        /// <response code="200">Élève supprimé</response>
        /// <response code="404">Élève non trouvé</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Eleve>> DeleteEleves(int id)
        {
            var eleves = await _context.Eleves.FindAsync(id);
            if (eleves == null)
            {
                return NotFound();
            }

            _context.Eleves.Remove(eleves);
            await _context.SaveChangesAsync();

            return eleves;
        }

        private bool ElevesExists(int id)
        {
            return _context.Eleves.Any(e => e.Id == id);
        }
    }
}
