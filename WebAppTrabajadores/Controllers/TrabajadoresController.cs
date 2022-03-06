using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppTrabajadores.Entidades;

namespace WebAppTrabajadores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajadoresController : ControllerBase 
    {
        private readonly ApplicationDbContext dbContext;
        public TrabajadoresController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]//api/trabajadores
        [HttpGet("listado")] //api/trabajadores/listado
        [HttpGet("/listado")]// /listado
        public List<Trabajador> Get()
        {
            return  dbContext.Trabajadors.Include(x => x.Puestos).ToList();
            
            
        }
        [HttpGet("primero")] //api/trabajadores/primero?
        public async Task<ActionResult<Trabajador>> PrimerTrabajador([FromHeader] int valor, [FromQuery] string trabajador)
        {
            return await dbContext.Trabajadors.FirstOrDefaultAsync();
        }
        [HttpGet("{id:int}/{param=Alfredo}")]
        public ActionResult<Trabajador> Get(int id, string param)
        {
            var trabajador =  dbContext.Trabajadors.FirstOrDefault(x => x.Id == id); 
            if(trabajador == null)
            {
                return NotFound();
            }
            return trabajador;
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Trabajador>> Get([FromRoute]string nombre)
        {
           var trabajador =  await dbContext.Trabajadors.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
            if (trabajador == null)
            {
                return NotFound();
            }
            return trabajador;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Trabajador trabajador)
        {
            dbContext.Add(trabajador);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]// api/trabajadors/1
        public async Task<ActionResult> Put(Trabajador trabajador, int id)
        {
            if(trabajador.Id != id)
            {
                return BadRequest("El id del trabajador no coincide con el establecido en la url");
            }
            dbContext.Update(trabajador);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Trabajadors.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Trabajador()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
