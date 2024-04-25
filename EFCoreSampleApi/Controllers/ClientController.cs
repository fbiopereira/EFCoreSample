using Core.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreSampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("six-month-orders/{id:int}")]
        public IActionResult ClientAndSixMonthOrders([FromRoute] int id)
        {
            try
            {
                var client = _clientRepository.GetSixMonthOrders(id);

                return Ok(client) ;
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }


    }
}
