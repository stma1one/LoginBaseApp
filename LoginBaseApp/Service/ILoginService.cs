﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBaseApp.Service
{
  public  interface ILoginService
    {
		public bool Login(string username, string password);

	}
}
