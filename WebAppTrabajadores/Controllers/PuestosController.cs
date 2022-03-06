using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppTrabajadores.Entidades;

namespace WebAppTrabajadores.Controllers
{
    [ApiController]
    [Route("api/puestos")]
    public class PuestosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PuestosController (ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Puesto>>> GetAll()
        {
            return await dbContext.puestos.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Puesto>> GetById(int id)
        {
            return await dbContext.puestos.FirstOrDefaultAsync(x => x.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult> Post (Puesto puesto)
        {
            var existeTrabajador = await dbContext.Trabajadors.AnyAsync(x => x.Id == puesto.TrabajadorId);

            if(!existeTrabajador)
            {
                return BadRequest($"No existe el alumno con el id: {puesto.TrabajadorId}");
            }

            dbContext.Add(puesto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Puesto puesto, int id)
        {
            var exist = await dbContext.puestos.AnyAsync(x => x.Id == id); 
            
            if(!exist)
            {
                return NotFound("El puesto especificado no existe. ");
            }
            if(puesto.Id != id)
            {
                return BadRequest("El id del puesto no coincide con el establecido  en la url. ");
            }

            dbContext.Update(puesto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.puestos.AnyAsync(x =>x.Id == id);
            if(!exist)
            {
                return NotFound("El Recurso no fue encontrado ");
            }
            dbContext.Remove(new Puesto {Id = id});
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
