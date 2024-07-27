using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Subscription;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddSubscription")]
        [SwaggerOperation(OperationId = nameof(AddSubscription))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Subscription>))]
        public async Task<IActionResult> AddSubscription([FromBody] SubscriptionCreationModel subscription)
        {
            Subscription mappedSubscription = _mapper.Map<Subscription>(subscription);
            Subscription  mappedResult = await _subscriptionRepository.AddSubscriptionAsync(mappedSubscription);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("GetAllSubscriptions")]
        [SwaggerOperation(OperationId = nameof(GetAllSubscriptions))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubscriptionViewModel>))]
        public async Task<IActionResult> GetAllSubscriptions()
        {
            IEnumerable<Subscription> subscriptions = await _subscriptionRepository.GetAllSubscriptionsAsync();
            List<SubscriptionViewModel> mappedResult = subscriptions.Select(_mapper.Map<SubscriptionViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdateSubscription")]
        [SwaggerOperation(OperationId = nameof(UpdateSubscription))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Subscription>))]
        public async Task<IActionResult> UpdateSubscription([FromRoute] long id, [FromBody] SubscriptionCreationModel subscription)
        {
            Subscription subscriptionToUpdate = _mapper.Map<Subscription>(subscription);
            Subscription result = await _subscriptionRepository.UpdateSubscriptionAsync(id, subscriptionToUpdate);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete]
        [Route("DeleteSubscription")]
        [SwaggerOperation(OperationId = nameof(DeleteSubscription))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Subscription>))]
        public async Task<IActionResult> DeleteSubscription(long id)
        {
            Subscription? deletedSubscription = await _subscriptionRepository.DeleteSubscriptionAsync(id);
            return deletedSubscription == null ? NotFound() : Ok(deletedSubscription);
        }

        [HttpGet]
        [Route("GetSubscriptionsByBusinessId/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetSubscriptionsByBusinessId))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubscriptionViewModel>))]
        public async Task<IActionResult> GetSubscriptionsByBusinessId([FromRoute] long id)
        {
            IEnumerable<Subscription> subscriptions = await _subscriptionRepository.GetSubscriptionsByBusinessIdAsync(id);
            if (subscriptions == null || subscriptions.Count() == 0)
            {
                return NotFound();
            }
            List<SubscriptionViewModel> mappedResult = subscriptions.Select(_mapper.Map<SubscriptionViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindBusinessesMemberBelongsToByName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindBusinessesMemberBelongsToByName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubscriptionViewModel>))]
        public async Task<IActionResult> FindBusinessesMemberBelongsToByName([FromRoute] string name)
        {
            IEnumerable<Subscription> subscriptions = await _subscriptionRepository.FindBusinessesMemberBelongsToByNameAsync(name);

            if (subscriptions == null || subscriptions.Count() == 0)
            {
                return NotFound();
            }
            List<SubscriptionViewModel> mappedResult = subscriptions.Select(_mapper.Map<SubscriptionViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindSubscriptionsByBusinessName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindSubscriptionsByBusinessName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubscriptionViewModel>))]
        public async Task<IActionResult> FindSubscriptionsByBusinessName([FromRoute] string name)
        {
            IEnumerable<Subscription> subscriptions = await _subscriptionRepository.FindSubscriptionsByBusinessNameAsync(name);

            if (subscriptions == null || subscriptions.Count() == 0)
            {
                return NotFound();
            }
            List<SubscriptionViewModel> mappedResult = subscriptions.Select(_mapper.Map<SubscriptionViewModel>).ToList();
            return Ok(mappedResult);
        }

    }
}
