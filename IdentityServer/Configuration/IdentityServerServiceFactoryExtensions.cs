﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MapHive.Identity.MembershipReboot;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;

namespace MapHive.Identity.IdentityServer.Configuration
{
    public static class IdentityServerServiceFactoryExtensions
    {
        //Note: the whole stuff for user related services / repos comes from the MR config!

        public static void ConfigureCustomUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, CustomMembershipRebootUserService>();
            factory.Register(new Registration<CustomUserAccountService>());
            factory.Register(new Registration<CustomConfig>(CustomConfig.Get()));
            factory.Register(new Registration<CustomUserAccountRepository>());
            factory.Register(new Registration<CustomDbContext>(resolver => new CustomDbContext(connString)));
        }
    }
}