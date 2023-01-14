using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery:IRequest<PageResponse<List<CustomerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string Name { get; set; }
    }

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PageResponse<List<CustomerDto>>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PageResponse<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repositoryAsync.ListAsync(new PagedCustomerSpacifications(request.PageSize,request.PageNumber,request.Name));
            var clientesDto = _mapper.Map<List<CustomerDto>>(customers);
            return new PageResponse<List<CustomerDto>>(clientesDto,request.PageNumber,request.PageSize);
        }
    }
}
