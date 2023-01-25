using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketUpService.Api.Dtos.Stores;
using TicketUpService.Domain.Entities;
using TicketUpService.Domain.Repository;
using TicketUpService.Domain.Services;

namespace TicketUpService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
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
        [Authorize(Roles = "master")]
        public async Task<IActionResult> GetAll([FromServices] IStoreRepository storeRepository)
        {
            var list = await storeRepository.GetAll();
            return Ok(list);
        }
    }
}
