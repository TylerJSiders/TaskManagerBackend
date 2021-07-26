using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool isCompleted { get; set; }
    }
}
