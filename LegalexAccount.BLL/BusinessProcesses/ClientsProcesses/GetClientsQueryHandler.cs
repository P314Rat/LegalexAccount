﻿using LegalexAccount.BLL.DTO;
using LegalexAccount.DAL;
using LegalexAccount.DAL.Models.UserAggregate;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<UserDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clientsQuery = _unitOfWork.Clients.AsQueryable();

            if (request.Email != null)
            {
                var client = clientsQuery.Where(x => x.Email == request.Email).FirstOrDefault();

                if (client != null)
                {
                    UserDTO? userDTO = client switch
                    {
                        Legal legalClient => legalClient.ToDTO(),
                        Person person => person.ToDTO(),
                        _ => null
                    };

                    var result = userDTO == null ? new List<UserDTO>() : new List<UserDTO>() { userDTO };

                    return result;
                }
                else
                    throw new Exception("Client is not exists");

            }
            else
            {
                var legalEntities = _unitOfWork.LegalEntities.AsQueryable()
                    .Cast<Legal>()
                    .Select(x => x.ToDTO())
                    .ToList();

                var individuals = _unitOfWork.Individuals.AsQueryable()
                    .Cast<Person>()
                    .Select(x => x.ToDTO())
                    .ToList();

                var result = legalEntities.Cast<UserDTO>().Concat(individuals.Cast<UserDTO>()).ToList();

                //if
                //    .Select(x => (Legal)x)
                //    .Select(x => x.ToDTO())
                //    .ToList();

                //var personDTOs = clientsQuery
                //    .Where(x => x != null && x is Person)
                //    .Select(x => (Person)x)
                //    .Select(x => x.ToDTO())
                //    .ToList();
                //var personDTOs = clientsQuery.Where(x => x != null && x is Person)
                //    .Select(x => ((Person)x).ToDTO())
                //    .Cast<UserDTO>();

                return result;
            }
        }
    }
}
