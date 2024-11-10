using System.Collections.Concurrent;
using ChatExample.Models;

namespace ChatExample.DataService
{
    class SharedMemoryDb
    {
        private readonly ConcurrentDictionary<string, UserConnection> _connections = new();

        public ConcurrentDictionary<string, UserConnection> connections => _connections;
    }
}