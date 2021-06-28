using System;
using System.Collections.Generic;

namespace TodoApplicationWebApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public bool IsComplete { get; set; }
        
    }
}
