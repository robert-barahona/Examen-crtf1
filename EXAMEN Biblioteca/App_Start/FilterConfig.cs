﻿using System.Web;
using System.Web.Mvc;

namespace EXAMEN_Biblioteca
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
