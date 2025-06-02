using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return _context.Clients.OrderBy(c => c.Id).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(short id)
        {
            Client? client = _context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            Client? otherClient = _context.Clients.FirstOrDefault(c => c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The email address is already in use");
                ValidationProblemDetails? validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            Client? client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                PhoneNumber = clientDto.PhoneNumber ?? string.Empty,
                Address = clientDto.Address ?? string.Empty,
                Status = clientDto.Status,
                Created = DateTime.Now,
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult EditClient(short id, ClientDto clientDto)
        {
            Client? otherClient = _context.Clients.FirstOrDefault(c => c.Id != id && c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The email address is already in use");
                ValidationProblemDetails validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            Client? client = _context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.PhoneNumber = clientDto.PhoneNumber ?? string.Empty;
            client.Address = clientDto.Address ?? string.Empty;
            client.Status = clientDto.Status;

            _context.SaveChanges();

            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(short id)
        {
            Client? client = _context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return Ok();
        }
    }
}
