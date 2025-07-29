using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
// [ApiController]
// [Route("api/[controller]")]
//public class UsersController(DataContext context) : BaseApiController
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    //private readonly DataContext _context = context;

    //[AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();//context.Users.ToListAsync();
        //var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(users);
    }

    //[Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await userRepository.GetUserByIdAsync(id);//context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;

    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);//context.Users.FindAsync(id);
        if (user == null) return NotFound();
        //return mapper.Map<MemberDto>(user);
        return (user);
    }
}
