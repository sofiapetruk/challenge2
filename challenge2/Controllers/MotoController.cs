
using Challenge2.Models;
using Challenge2.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenge2.Data;
using challenge2.Models;

namespace Challenge2.Controllers
{
    [ApiController]
    [Route("api/motos")]
    public class MotoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MotoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoResponseDto>>> ListAll()
        {
            var motos = await _context.Motos
                .Include(m => m.StatusMoto)
                .Include(m => m.TipoMoto)
                .Select(m => new MotoResponseDto
                {
                    IdMoto = m.IdMoto,
                    NmChassi = m.NmChassi,
                    Placa = m.Placa,
                    Unidade = m.Unidade,
                    Status = m.StatusMoto.Status,
                    Modelo = m.TipoMoto.NmTipo
                })
                .ToListAsync();

            return motos;
        }


        [HttpGet("{idMoto}")]
        public async Task<ActionResult<MotoResponseDto>> ListAllbyId(int idMoto)
        {
            var moto = await _context.Motos
               .Include(m => m.StatusMoto)
               .Include(m => m.TipoMoto)
               .Where(m => m.IdMoto == idMoto)
               .Select(m => new MotoResponseDto
               {
                   IdMoto = m.IdMoto,
                   NmChassi = m.NmChassi,
                   Placa = m.Placa,
                   Unidade = m.Unidade,
                   Status = m.StatusMoto.Status,
                   Modelo = m.TipoMoto.NmTipo
               })
               .FirstOrDefaultAsync();

            if (moto == null)
            {
                return NotFound();
            }

            return moto;
        }


        [HttpPost]
        public async Task<ActionResult<Moto>> PostMoto(MotoRequestDto request)


        {
            var status = await _context.TipoStatus
                .FirstOrDefaultAsync(s => s.Status == request.Status);

            if (status == null)
            {
                status = new TipoStatus
                {
                    Status = request.Status,
                    Data = DateTime.Now
                };
                _context.TipoStatus.Add(status);
                await _context.SaveChangesAsync();
            }

            var tipo = await _context.TipoMotos
                .FirstOrDefaultAsync(t => t.NmTipo == request.Modelo);

            if (tipo == null)
            {
                tipo = new TipoMoto
                {
                    NmTipo = request.Modelo
                };
                _context.TipoMotos.Add(tipo);
                await _context.SaveChangesAsync();

            }

            var moto = new Moto
            {
                NmChassi = request.NmChassi,
                Placa = request.Placa,
                Unidade = request.Unidade,
                StatusMoto = status,
                TipoMoto = tipo
            };
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListAllbyId), new { idMoto = moto.IdMoto }, moto);


        }

        [HttpPut("{idMoto}")]
        public async Task<ActionResult<Moto>> PutMoto(int idMoto, MotoRequestDto request)
        {
            var moto = await _context.Motos
               .Include(m => m.StatusMoto)
               .Include(m => m.TipoMoto)
               .FirstOrDefaultAsync(m => m.IdTipoMoto == idMoto);

            if (moto == null)
            {
                return NotFound();
            }

            var status = await _context.TipoStatus
              .FirstOrDefaultAsync(s => s.Status == request.Status);

            if (status == null)
            {
                status = new TipoStatus
                {
                    Status = request.Status,
                    Data = DateTime.Now
                };
                _context.TipoStatus.Add(status);
                await _context.SaveChangesAsync();
            }

            var tipo = await _context.TipoMotos
               .FirstOrDefaultAsync(t => t.NmTipo == request.Modelo);

            if (tipo == null)
            {
                tipo = new TipoMoto
                {
                    NmTipo = request.Modelo
                };
                _context.TipoMotos.Add(tipo);
                await _context.SaveChangesAsync();

            }

            moto.NmChassi = request.NmChassi;
            moto.Placa = request.Placa;
            moto.Unidade = request.Unidade;
            moto.StatusMoto = status;
            moto.TipoMoto = tipo;

            await _context.SaveChangesAsync();
            return Ok(moto);
        }



        [HttpDelete("{idMoto}")]
        public async Task<IActionResult> Delete(int idMoto)
        {
            var moto = await _context.Motos.FindAsync(idMoto);
            if (moto == null)
            {
                return NotFound();
            }

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
