using Bekhrad_project.Domain.Resorce;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bekhrad_project.Models.MyModel
{
    public class UserInformation
    {
        [Key]
        public int userid{ get; set; }
        
        [Display(Name="Name",ResourceType = typeof(Domain.Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType =typeof(Domain.Resorce.TableColumn.column),ErrorMessageResourceName = "RequiredName")]
        [MaxLength(150)]
        public string  name { get; set; }
        [Display(Name = "Family", ResourceType = typeof(Domain.Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType = typeof(Domain.Resorce.TableColumn.column), ErrorMessageResourceName = "RequiredFamily")]
        [MaxLength(150)]
        public string family { get; set; }
        [Display(Name = "Age", ResourceType = typeof(Domain.Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType = typeof(Domain.Resorce.TableColumn.column), ErrorMessageResourceName = "RequiredAge")]
        public short age { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Domain.Resorce.TableColumn.column))]
        [Required(ErrorMessageResourceType = typeof(Domain.Resorce.TableColumn.column), ErrorMessageResourceName = "RequiredEmail")]
        [EmailAddress]
        public string email{ get; set; }
     
        public int groupid { get; set; }
        public virtual GroupUser Groups { get; set; }
        

    }
}