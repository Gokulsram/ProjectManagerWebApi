using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerBusinessLayer
{
    public class TaskModel
    {

        public int TaskId { get; set; }
        public string ParentTaskId { get; set; }
        public int? ProjectId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public string ParentTask { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsParentTask { get; set; }

    }
}
