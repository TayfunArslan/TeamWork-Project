using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork.Service.Dto
{
    public class TaskHistoryDto : BaseDto
    {
        public int Id { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> EffectedUserId { get; set; }
        public string Description { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
