using System;
using System.Collections.Generic;
using System.Text;
using TeamFlowWeb.Models;

namespace TeamFlowWeb.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
