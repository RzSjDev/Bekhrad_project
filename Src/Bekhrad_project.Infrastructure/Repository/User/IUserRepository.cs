using Bekhrad_project.Models.MyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bekhrad_project.Repository
{
    public interface IUserRepository:IDisposable
    {
         Task<List<UserInformation>> getAllUsers();
         Task<UserInformation> getUserById(int id);
         Task<bool> AddUser(UserInformation addUser);
         void UpdateUser(UserInformation UpdateUser);
         Task<bool> DeleteUser(int id);
         Task<bool> DeleteConfirme(int? id);
    }
}
