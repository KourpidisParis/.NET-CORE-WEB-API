using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;
    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }

    
    [HttpGet("TestConnection")] 
    public DateTime TestConnection(){
        return _entityFramework.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _entityFramework.Users.ToList<User>();
        return users;    
    }

    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        User? user = _entityFramework.Users
            .Where(u => u.UserId == userId)
            .FirstOrDefault<User>();

        if(user != null){
            return user;
        }

        throw new Exception("Failed to Update User");
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user){
        string sql = @"
        UPDATE TutorialAppSchema.Users
            SET [FirstName] = '" + user.FirstName + 
                "', [LastName] = '" + user.LastName +
                "', [Email] = '" + user.Email + 
                "', [Gender] = '" + user.Gender + 
                "', [Active] = '" + user.Active + 
            "' WHERE UserId = " + user.UserId;

        Console.WriteLine(sql);

        if (_entityFramework.ExecuteSql(sql))
        {
            return Ok();
        } 

        throw new Exception("Failed to Update User");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserToAddDto user){
        string sql = @"INSERT INTO TutorialAppSchema.Users(
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active]
            ) VALUES (" +
                "'" + user.FirstName + 
                "', '" + user.LastName +
                "', '" + user.Email + 
                "', '" + user.Gender + 
                "', '" + user.Active + 
            "')";
        
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } 

        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        string sql = @"
            DELETE FROM TutorialAppSchema.Users 
                WHERE UserId = " + userId.ToString();
        
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } 

        throw new Exception("Failed to Delete User");
    }

}

