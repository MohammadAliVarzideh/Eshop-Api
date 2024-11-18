﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Sevices
{
    public interface IDomainUserService
    {
        bool IsEmailExist(string email);

        bool PhoneNumberIsExist(string phoneNumber);
    }
}