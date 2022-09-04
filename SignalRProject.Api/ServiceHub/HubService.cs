using Microsoft.AspNetCore.SignalR;
using SignalRProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRProject.Api.ServiceHub
{
    public class HubService:Hub
    {
        private static List<Users> UserList { get; set; } = new List<Users>();

        public async Task SendMessage(string msg)
        {
            int id = (UserList.Count == 0 ? 0 : UserList.LastOrDefault().Id)+1;

            UserList.Add(new Users { Id = id, Name = "Admin", Password = "1234" });

            await Clients.All.SendAsync("UserList", UserList);
        }
    }
}
