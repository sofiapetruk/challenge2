using challenge2.Data;
using Challenge2.Dtos;
using Challenge2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challenge2.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> ListAll()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new UsuarioResponseDto
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                })
                .ToListAsync();
            

            return usuarios;
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<UsuarioResponseDto>> ListAllById(int idUsuario)
        {
            var usuario = await _context.Usuarios
                .Where(u => u.IdUsuario == idUsuario)
                .Select(u => new UsuarioResponseDto
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPut("{idUsuario}")]
        public async Task<IActionResult> PutUsuario(int idUsuario, UsuarioRequestDto request)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Senha = request.Senha;

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioRequestDto request)
        {
            var usuario = new Usuario()
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ListAllById), new { idUsuario = usuario.IdUsuario }, usuario);
        }


        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteUsuario(int idUsuario)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);

            if (usuario == null)
            {
                return Unauthorized(new { mensagem = "Email ou senha inválidos" });
            }

            return Ok(new
            {
                mensagem = "Login bem-sucedido",
                usuario.IdUsuario,
                usuario.Nome,
                usuario.Email
            });
        }


    }
}
