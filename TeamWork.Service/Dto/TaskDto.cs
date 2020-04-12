using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Service.Dto
{
    public class TaskDto : BaseDto
    {
        public TaskDto()
        {
            this.TaskHistory = new List<TaskHistoryDto>();
        }

        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> TasStatusId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> AssignTo { get; set; }
        public Nullable<int> Estimated { get; set; }
        public Nullable<int> Completed { get; set; }
        public Nullable<int> Remaining { get; set; }
        public bool IsActive { get; set; }

        public virtual ProjectDto Project { get; set; }
        public virtual TaskStatusDto TaskStatus { get; set; }
        public virtual UserDto User { get; set; }
        public virtual List<TaskHistoryDto> TaskHistory { get; set; }
    }
}
