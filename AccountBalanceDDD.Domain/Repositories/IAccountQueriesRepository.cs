﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Repositories
{
    interface IAccountQueriesRepository
    {
        public bool GetAccountStatus(Account account);

    }
}
