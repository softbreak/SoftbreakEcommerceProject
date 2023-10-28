using Microsoft.AspNetCore.Identity;
using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class AppUserRepository:BaseRepository<AppUser>,IAppUserRepository
    {
        UserManager<AppUser> _userManager;

        public AppUserRepository(MyContext db,UserManager<AppUser> userManager):base(db)
        {
            
            _userManager = userManager;
        }

        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);
            
            if (result.Succeeded) return true;
            //List<IdentityError> errors = new List<IdentityError>();
            //foreach (IdentityError error in result.Errors)
            //{
            //    errors.Add(error);
            //}
            return false;

        }


    }
}
