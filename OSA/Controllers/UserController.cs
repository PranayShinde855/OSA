﻿using Microsoft.AspNetCore.Mvc;
using OSA.Database.DBContext;
using OSA.Database.Infrastructure;
using OSA.DomainEntities.Users;
using OSA.Services.Interfaces;

namespace OSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAsync")]
        public IEnumerable<string> Get()
        {
            var a = _userService.Add(new User()
            {
                FirstName = "Test 1",
                Gender = "Male",
                LastName = "Last Name",
                IsActive = true
            });
            return new string[] { "value1", "value2" };
        }

        //private readonly OSADbContext _context;
        //public UserController(OSADbContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet("GetAsync")]
        //public IEnumerable<string> Get()
        //{
        //    var a = _context.User.Add(new User()
        //    {
        //        FirstName = "Test 1",
        //        Gender = "Male",
        //        LastName = "Last Name",
        //        IsActive = true
        //    });

        //    _context.SaveChanges();
        //    return new string[] { "value1", "value2" };
        //}
    }
}