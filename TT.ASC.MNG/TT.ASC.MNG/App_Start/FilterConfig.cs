﻿using System.Web;
using System.Web.Mvc;

namespace TT.ASC.MNG
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
