using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bekhrad_project.Models.MyModel
{
    public class Group
    {
        [Key]
        public int GroupId{ get; set; }
        public string GroupName { get; set; }
        public DateTime createGroupTime { get; set; }
        public virtual UserInformation user{ get; set; }

    }
}