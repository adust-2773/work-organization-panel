using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.Design;
using WorkOrganizationPanel.Shared.Dtos;

namespace WorkOrganizationPanel.Client.Services
{
    public interface IAccountService
    {
        public UserDto User { get; set; }
    }

    public class AccountService : IAccountService
    {
        public UserDto User { get; set; }
    }
}
