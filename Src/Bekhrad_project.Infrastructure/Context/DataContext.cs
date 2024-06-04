using Bekhrad_project.Models.MyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class DataContext : DbContext
{
    public DataContext() : base("name=DataContext")
    {
    }

    public DbSet<UserInformation> UserInformations { get; set; }

    public DbSet<GroupUser> Groups { get; set; }
}
