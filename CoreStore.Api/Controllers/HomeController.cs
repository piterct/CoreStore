﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }

        [HttpGet]
        [Route("error")]
        public string Error()
        {
            throw new Exception("Algum erro ocorreu");
            return "erro";
        }
    }
}
