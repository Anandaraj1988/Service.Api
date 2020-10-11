﻿using System;

namespace ServiceApi.DataAccess.Model
{
    public class LoginResult
    {
        public bool IsAuthenticated { get; set; }
        public Guid UserID { get; set; }
        public Guid AccessToken { get; set; }
        public int UserRole { get; set; }
    }
}
