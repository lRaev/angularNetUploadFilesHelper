using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceResponce<T>
    {
        public string MessageType { get; set; }
        public Guid Request_Id { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
