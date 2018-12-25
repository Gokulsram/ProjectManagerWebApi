using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerBusinessLayer
{
   public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public int UserId{ get; set; }
        public int TasksCount { get; set; }
        public int CompletedTask { get; set; }
        public string UserName { get; set; }

    }
}
