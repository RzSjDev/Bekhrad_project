using Bekhrad_project.Models.MyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bekhrad_project.Repository
{
    public interface IGroupUserRepository:IDisposable
    { 
        Task<List<GroupUser>> getAllGroup();
        Task<GroupUser> getGroupById(int id);
        Task<bool> AddGroup(GroupUser addGroup);
        Task<bool> UpdateGroup(GroupUser UpdateGroup);
        Task<bool> DeleteGroup(int id);
        Task<bool> DeleteConfirme(int? id);
    }
}
