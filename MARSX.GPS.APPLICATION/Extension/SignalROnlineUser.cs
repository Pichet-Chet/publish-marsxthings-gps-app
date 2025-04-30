using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MARSX.GPS.APPLICATION.Extension
{
	public class SignalROnlineUser : Hub
    {
        private static HashSet<string> _onlineUsers = new HashSet<string>();

        public override async Task OnConnectedAsync()
        {
            _onlineUsers.Add(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _onlineUsers.Remove(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task<int> GetOnlineUserCount()
        {
            return _onlineUsers.Count;
        }
    }
}

