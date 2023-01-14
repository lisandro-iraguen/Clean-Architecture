using Application.Features.Customers.Commands.CreateCustomerCommand;
using Application.Features.Customers.Commands.DeleteCustomerCommand;
using Application.Features.Customers.Commands.UpdateCustomerCommand;
using Application.Features.Customers.Queries.GetCustomerById;
using Application.Features.Customers.Queries.GetAllCustomers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerParameters filter)
        {

            return Ok(await Mediator.Send(new GetAllCustomersQuery
            {
                PageNumber = filter.PageNumber,
                PageSize= filter.PageSize,
                Name= filter.Name
            }));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await Mediator.Send(new GetCustomerByIdQuery
            {
                Id = id
            }));
        }




        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            

            return Ok(await Mediator.Send(new DeleteCustomerCommand
            {
                Id = id
            }));
        }
    }
}
