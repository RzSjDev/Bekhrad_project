using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bekhrad_project.Models.MyModel
{
    public class UserInformation
    {
        [Key]
        public int UserId{ get; set; }
        [Display(Name="Name",ResourceType = typeof(Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType =typeof(Resorce.TableColumn.column),ErrorMessageResourceName = "RequiredName")]
        [MaxLength(150)]
        public string  Name { get; set; }
        [Display(Name = "Family", ResourceType = typeof(Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType = typeof(Resorce.TableColumn.column), ErrorMessageResourceName = "RequiredFamily")]
        [MaxLength(150)]
        public string Family { get; set; }
        [Display(Name = "Age", ResourceType = typeof(Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType = typeof(Resorce.TableColumn.column), ErrorMessageResourceName = "RequiredAge")]
        public short Age { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType = typeof(Resorce.TableColumn.column), ErrorMessageResourceName = "RequiredEmail")]
        [EmailAddress]
        public string Email{ get; set; }

        public virtual List<Group> Groups { get; set; }
        public int Groupid { get; set; }

    }
}