using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWork.UI.Models
{
    public class TaskSearchModel
    {
        public int ProjectId { get; set; }
        public int TaskStatusId { get; set; }
        public int UserId { get; set; }
    }
}