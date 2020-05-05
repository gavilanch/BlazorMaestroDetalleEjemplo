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
    public class EstudiantesController: ControllerBase
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

        [HttpPost]
        public async Task<ActionResult<int>> Post(Estudiante estudiante)
        {
            return BadRequest("muy mal");
            context.Add(estudiante);
            await context.SaveChangesAsync();
            return estudiante.Id;
        }
    }
}
