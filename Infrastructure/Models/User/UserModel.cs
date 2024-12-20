﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.User
{


    public class UserModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public string phoneNumber { get; set; }
    }
}