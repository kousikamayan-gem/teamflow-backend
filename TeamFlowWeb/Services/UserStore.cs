using System;
using System.Collections.Generic;
using System.Text;
using TeamFlowWeb.Models;

namespace TeamFlowWeb.Services
{
    public class UserStore
    {
        public List<User> Users { get; } = new();
        public int NextId { get; set; } = 1;
    }
}
