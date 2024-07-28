using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using LotusOrganiser_API.Models.Message;
using LotusOrganiser_Repository.Repositories;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        private readonly IMapper _mapper;

        public MessageController(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateMessage")]
        [SwaggerOperation(OperationId = nameof(CreateMessage))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Message>))]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {
            Message result = await _messageRepository.CreateMessageAsync(message);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllMessages")]
        [SwaggerOperation(OperationId = nameof(GetAllMessagesAsync))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Message>))]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            IEnumerable<Message> result = await _messageRepository.GetAllMessagesAsync();
            //List<MessageViewModel> mappedResult = result.Select(_mapper.Map<MessageViewModel>).ToList();
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteMessage")]
        [SwaggerOperation(OperationId = nameof(DeleteMessage))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Message>))]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            Message? deletedItem = await _messageRepository.DeleteMessageAsync(id);
            return deletedItem == null ? NotFound() : Ok(deletedItem);
        }


        [HttpGet]
        [Route("GetMessageById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetMessageById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<MessageViewModel>))]
        public async Task<IActionResult> GetMessageById([FromRoute] string id)
        {
            Message? message = await _messageRepository.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            MessageViewModel mappedResult = _mapper.Map<MessageViewModel>(message);
            return Ok(mappedResult);
        }
    }

}