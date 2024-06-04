using Bekhrad_project.Models.MyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bekhrad_project.Repository.Group
{
    public class GroupUserRepository : IGroupUserRepository
    {
        private readonly DataContext _db;
        public GroupUserRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<bool> AddGroup(GroupUser addGroup)
        {
            _db.Groups.Add(addGroup);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteConfirme(int? id)
        {
            try
            {
                GroupUser user = await _db.Groups.FindAsync(id);
                _db.Groups.Remove(user);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteGroup(int id)
        {
            GroupUser user = await _db.Groups.FindAsync(id);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<List<GroupUser>> getAllGroup()
        {
            var users = await _db.Groups.ToListAsync();
            return users;
        }

        public async Task<GroupUser> getGroupById(int id)
        {
            var dbCharacter = await _db.Groups.FirstOrDefaultAsync(c => c.groupid == id);
            return dbCharacter;
        }

        public async Task<bool> UpdateGroup(GroupUser UpdateGroup)
        {
            _db.Entry(UpdateGroup).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}