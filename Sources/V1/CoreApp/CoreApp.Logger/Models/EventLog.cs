using System;

namespace CoreApp.Logger.Models
{
    public class EventLog
    {
        public long EventId { get; set; }
        public string Logger { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
