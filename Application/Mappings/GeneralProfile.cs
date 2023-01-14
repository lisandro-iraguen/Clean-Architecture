using Application.DTOs;
using Application.Features.Customers.Commands.CreateCustomerCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile:Profile
    {

        public GeneralProfile() 
        {
            //Dtos
            CreateMap<Customer,CustomerDto>();



            ///commands
            CreateMap<CreateCustomerCommand, Customer>();
        
        }
    }
}
