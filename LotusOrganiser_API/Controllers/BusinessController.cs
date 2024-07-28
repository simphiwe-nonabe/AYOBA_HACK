using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using LotusOrganiser_API.Models.Business;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepository;

        private readonly IMapper _mapper;

        public BusinessController(IBusinessRepository businessRepository, IMapper mapper)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateBusiness")]
        [SwaggerOperation(OperationId = nameof(CreateBusiness))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Business>))]
        public async Task<IActionResult> CreateBusiness([FromBody] Business business)
        {
            //Business mappedBusiness = _mapper.Map<Business>(business);
            Business result = await _businessRepository.CreateBusinessAsync(business);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllBusinesses")]
        [SwaggerOperation(OperationId = nameof(GetAllBusinesses))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Business>))]
        public async Task<IActionResult> GetAllBusinesses()
        {
            IEnumerable<Business> result = await _businessRepository.GetAllBusinessesAsync();
            //List<BusinessViewModel> mappedResult = result.Select(_mapper.Map<BusinessViewModel>).ToList();
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateBusiness/{id:long}")]
        [SwaggerOperation(OperationId = nameof(UpdateBusiness))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Business>))]
        public async Task<IActionResult> UpdateBusiness([FromRoute] long id, [FromBody] BusinessCreationModel businessToUpdate)
        {
            Business mappedBusiness = _mapper.Map<Business>(businessToUpdate);
            Business? updatedBusiness = await _businessRepository.UpdateBusinessAsync(id, mappedBusiness);
            return updatedBusiness == null ? NotFound() : Ok(updatedBusiness);
        }

        [HttpDelete]
        [Route("DeleteBusiness")]
        [SwaggerOperation(OperationId = nameof(DeleteBusiness))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Business>))]
        public async Task<IActionResult> DeleteBusiness(long id)
        {
            Business? deletedBusiness = await _businessRepository.DeleteBusinessAsync(id);
            return deletedBusiness == null ? NotFound() : Ok(deletedBusiness);
        }

        [HttpGet]
        [Route("GetBusinessById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetBusinessById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<BusinessViewModel>))]
        public async Task<IActionResult> GetBusinessById([FromRoute] long id)
        {
            Business? business = await _businessRepository.GetBusinessByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            BusinessViewModel mappedResult = _mapper.Map<BusinessViewModel>(business);
            return Ok(mappedResult);
        }
    }

}