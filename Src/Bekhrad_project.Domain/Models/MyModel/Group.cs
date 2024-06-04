using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bekhrad_project.Models.MyModel
{
    public class GroupUser
    {
        [Key]
        public int groupid{ get; set; }
        public string groupname { get; set; }
        public DateTime creategrouptime { get; set; }
        public virtual  List<UserInformation> user{ get; set; }

    }
}