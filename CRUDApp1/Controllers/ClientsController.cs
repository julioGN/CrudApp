using CRUDApp1.Models;
using CRUDApp1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _clientService;
        public ClientsController(ApplicationDbContext context)
        {
            _clientService = context;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return _clientService.Clients.OrderBy(c => c.Id).ToList();
        }
    }
}
