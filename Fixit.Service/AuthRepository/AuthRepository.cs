﻿using Fixit.Context.DatabaseContext;
using Fixit.Service.HelperModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixit.Service.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private AuthContext _ctx;
        private UserManager<IdentityUser> _userManager;
        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IList<string>> GetRolesAsync(string userid)
        {
            IList<string> roleList = await _userManager.GetRolesAsync(userid);
            return roleList;
        }
    }
}
