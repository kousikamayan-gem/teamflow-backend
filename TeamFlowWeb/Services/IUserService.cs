using System;
using System.Collections.Generic;
using System.Text;
using TeamFlowWeb.DTOs;
using TeamFlowWeb.Models;

namespace TeamFlowWeb.Services
{
    public interface IUserService
    {
        User RegisterUserService(User request, string password);
        User Login(string email, string password);
    }
}
