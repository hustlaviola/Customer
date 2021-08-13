using System;
using System.Text.Json;
using System.Threading.Tasks;
using Customer.Core.DTOs;
using Customer.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public UserController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(long userId)
        {
            var user = await _customerService.GetUser(userId);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _customerService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO userDTO)
        {
            await _customerService.AddUser(userDTO);
            return Ok();
        }
    }
}