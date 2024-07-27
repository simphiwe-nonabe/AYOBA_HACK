using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.User;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddUser")]
        [SwaggerOperation(OperationId = nameof(AddUser))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> AddUser([FromBody] UserCreationModel user)
        {
            User mappedUser = _mapper.Map<User>(user);
            User result = await _userRepository.AddUserAsync(mappedUser);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [SwaggerOperation(OperationId = nameof(GetAllUsers))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserViewModel>))]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await _userRepository.GetAllUsersAsync();
            List<UserViewModel> mappedResult = users.Select(_mapper.Map<UserViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdateUser/{id:long}")]
        [SwaggerOperation(OperationId = nameof(UpdateUser))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> UpdateUser([FromRoute] long id, [FromBody] UserCreationModel userToUpdate)
        {
            User mappedUser = _mapper.Map<User>(userToUpdate);

            User? updatedUser = await _userRepository.UpdateUserAsync(id, mappedUser);
            return updatedUser == null ? NotFound() : Ok(updatedUser);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [SwaggerOperation(OperationId = nameof(DeleteUser))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> DeleteUser(long id)
        {
            User? deletedUser = await _userRepository.DeleteUserAsync(id);
            return deletedUser == null ? NotFound() : Ok(deletedUser);
        }

        [HttpGet]
        [Route("GetUserById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetUserById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserViewModel>))]
        public async Task<IActionResult> GetUserById([FromRoute] long id)
        {
            User? user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            UserViewModel mappedResult = _mapper.Map<UserViewModel>(user);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindUsersByName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindUsersByName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserViewModel>))]
        public async Task<IActionResult> FindUsersByName([FromRoute] string name)
        {
            IEnumerable<User> users = await _userRepository.FindUsersByNameAsync(name);
            if (users == null || users.Count() == 0)
            {
                return NotFound();
            }

            List<UserViewModel> mappedResult = users.Select(_mapper.Map<UserViewModel>).ToList();
            return Ok(mappedResult);
        }
    }
}
