using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEComentarios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ComentarioController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Comentario
        [HttpGet]
        //public IEnumerable<Comentario> Get()
        //{
        //    //return new string[] { "value1", "value2" };
        //    try
        //    {
        //        var ListComentarios =  _context.Comentario.ToList();
        //        return ListComentarios;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListComentarios = await _context.Comentario.ToListAsync();
                return Ok(ListComentarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Comentario/5
        [HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);
                if(comentario == null)
                {
                    return NotFound();
                }
                return Ok(comentario);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Comentario
        [HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return Ok(comentario);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Comentario/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if(id != comentario.Id)
                {
                    return BadRequest();
                }
                _context.Update(comentario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comentario Actualizado con Exito !" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _context.Comentario.FindAsync(id);
                if (comentario == null)
                    return NotFound();
                _context.Comentario.Remove(comentario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comentario Eliminado con Exito !" });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
