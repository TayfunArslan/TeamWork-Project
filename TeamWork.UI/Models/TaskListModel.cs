using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWork.Service.Dto;

namespace TeamWork.UI.Models
{
    public class TaskListModel
    {
        public List<TaskDto> Tasks { get; set; }

        public List<ProjectDto> Projects { get; set; }

        public List<TaskStatusDto> TasStatuses { get; set; }

        public List<UserDto> Users { get; set; }

        public int ProjectId { get; set; }
        public int TaskStatusId { get; set; }
        public int UserId { get; set; }
    }
}