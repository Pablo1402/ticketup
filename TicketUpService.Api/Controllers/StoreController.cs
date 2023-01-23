using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketUpService.Api.Dtos.Stores;
using TicketUpService.Domain.Entities;
using TicketUpService.Domain.Repository;

namespace TicketUpService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "master")]
        public async Task<IActionResult> Create([FromServices] IStoreRepository storeRepository, CreateStoreDto createStoreDto)
        {
            var storeSave = new Store(createStoreDto.Name, createStoreDto.Email);
            await storeRepository.Create(storeSave);
            return Ok(storeSave);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IStoreRepository storeRepository)
        {
            var list = await storeRepository.GetAll();
            return Ok(list);
        }
    }
}
