using Application.Interfaces;
using Application.Wrappers;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryAsync.GetByIdAsync(request.Id);
            if(customer is null)
            {
                throw new KeyNotFoundException($"registro no encontrado con el id {request.Id}");
            }
            else
            {
                customer.Name = request.Name;
                customer.Tel = request.Tel;
                customer.Address = request.Address; 
                customer.City = request.City;
                customer.Email = request.Email;
                
                await _repositoryAsync.UpdateAsync(customer);
                return new Response<int>(customer.Id);
            }

        }
    }
}
