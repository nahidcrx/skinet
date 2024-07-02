﻿using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context) 
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest() 
        {
            return Ok();
        }

        //[HttpGet("notfound")]
        //public ActionResult GetNotFoundRequest()
        //{
        //    return Ok();
        //}

        //[HttpGet("notfound")]
        //public ActionResult GetNotFoundRequest()
        //{
        //    return Ok();
        //}

        //[HttpGet("notfound")]
        //public ActionResult GetNotFoundRequest()
        //{
        //    return Ok();
        //}
    }
}
