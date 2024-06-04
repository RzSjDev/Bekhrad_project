using Bekhrad_project.Models.MyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Bekhrad_project.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;
        public UserRepository(DataContext db) 
        {
           _db = db;
        } 
        public async Task<List<UserInformation>> getAllUsers()
        {
 
            var users= await _db.UserInformations.Include(u => u.Groups).ToListAsync();
            return users;
        }

        public async Task<UserInformation> getUserById(int id)
        {
            var dbCharacter = await _db.UserInformations.FirstOrDefaultAsync(c => c.userid == id );
            return dbCharacter;
        }

        public async Task<bool> AddUser(UserInformation addUser)
        {
            _db.UserInformations.Add(addUser);
            await _db.SaveChangesAsync();
            return true;
        }

        public void UpdateUser(UserInformation UpdateUser)
        {
            _db.Entry(UpdateUser).State = EntityState.Modified;
            _db.SaveChangesAsync();
           
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserInformation userInformation = await _db.UserInformations.FindAsync(id);
            if (userInformation!=null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteConfirme(int id)
        {
            try
            {
                UserInformation userInformation = await _db.UserInformations.FindAsync(id);
                _db.UserInformations.Remove(userInformation);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Task<bool> DeleteConfirme(int? id)
        {
            throw new NotImplementedException();
        }
    }
}