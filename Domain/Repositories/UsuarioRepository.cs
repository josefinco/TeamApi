using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UsuarioRepository
    {
        public static Usuario Get(string username, string password)
        {
            var users = new List<Usuario>();
            users.Add(new Usuario { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new Usuario { Id = 2, Username = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
