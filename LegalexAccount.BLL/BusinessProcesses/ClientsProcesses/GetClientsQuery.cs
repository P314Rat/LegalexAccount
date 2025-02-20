﻿using LegalexAccount.BLL.DTO;
using MediatR;


namespace LegalexAccount.BLL.BusinessProcesses.ClientsProcesses
{
    public class GetClientsQuery : IRequest<List<UserDTO>>
    {
        public string? Email { get; set; } = null;
        public string? OrganizationName { get; set; } = string.Empty;

        public GetClientsQuery(string? email = null, string? organizationName = null)
        {
            Email = email;
            OrganizationName = organizationName;
        }
    }
}
