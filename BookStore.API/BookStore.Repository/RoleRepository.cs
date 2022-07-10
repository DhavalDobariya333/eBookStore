using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class RoleRepository : BaseRepository
    {
        public List<Role> GetRoles(string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Roles.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            return query.ToList();
        }
        public Role GetRole(int id)
        {
            return _context.Roles.FirstOrDefault(c => c.Id == id);
        }

        public Role AddRole(Role role)
        {
            var entry = _context.Roles.Add(role);
            _context.SaveChanges();
            return entry.Entity;
        }


        public Role UpdateRole(Role role)
        {
            var entry = _context.Roles.Update(role);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(c => c.Id == id);
            if (role == null)
                return false;

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }
    }
}
