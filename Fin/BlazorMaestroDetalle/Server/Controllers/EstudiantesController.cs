using BlazorMaestroDetalle.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMaestroDetalle.Server.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EstudiantesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> Get()
        {
            return await context.Estudiantes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> Get(int id)
        {
            var estudiante = await context.Estudiantes
                .Include(x => x.Direcciones)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (estudiante == null) { return NotFound(); }
            return estudiante;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Estudiante estudiante)
        {
            context.Add(estudiante);
            await context.SaveChangesAsync();
            return estudiante.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Estudiante estudiante)
        {
            context.Entry(estudiante).State = EntityState.Modified;

            foreach (var direccion in estudiante.Direcciones)
            {
                if (direccion.Id != 0)
                {
                    context.Entry(direccion).State = EntityState.Modified;
                }
                else
                {
                    context.Entry(direccion).State = EntityState.Added;
                }
            }

            var listadoDireccionesIds = estudiante.Direcciones.Select(x => x.Id).ToList();
            var direccionesABorrar = await context
                .Direcciones
                .Where(x => !listadoDireccionesIds.Contains(x.Id) && x.EstudianteId == estudiante.Id)
                .ToListAsync();

            context.RemoveRange(direccionesABorrar);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
