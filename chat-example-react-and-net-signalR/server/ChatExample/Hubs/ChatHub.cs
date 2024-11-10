
using ChatExample.DataService;
using ChatExample.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatExample.Hubs
{
    internal class ChatHub : Hub
    {
        private readonly SharedMemoryDb _sharedMemoryDb;

        // public ChatHub(SharedMemoryDb sharedMemoryDb) => _sharedMemoryDb = sharedMemoryDb;
        public ChatHub(SharedMemoryDb sharedMemoryDb)
        {
            _sharedMemoryDb = sharedMemoryDb;
        }

        public async Task JoinChat(UserConnection connection)
        {
            await Clients.All // client proxy
                .SendAsync("ReceiveMessage", "admin", $"{connection.Username} has joined the chat general.");
        }

        public async Task JoinSpecificChatRoom(UserConnection connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatRoom);

            _sharedMemoryDb.connections[Context.ConnectionId] = connection;

            await Clients
                .Group(connection.ChatRoom)
                .SendAsync("JoinSpecificChatRoom", "admin", $"{connection.Username} has joined the {connection.ChatRoom} chat specifically.");
        }

        public async Task SendMessage(string message)
        {
            if (_sharedMemoryDb.connections.TryGetValue(Context.ConnectionId, out UserConnection conn))
            {
                await Clients.Group(conn.ChatRoom)
                    .SendAsync("ReceiveSpecificMessage", conn.Username, message);
            }
            else
            {
                Console.WriteLine($"Failed to find connection for {Context.ConnectionId}");
            }
        }
    }
}
