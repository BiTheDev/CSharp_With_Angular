using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Combine.Models;
namespace Combine.Controllers
{


    [Route("api/Home")]
    public class HomeController : Controller
    {
        private CombineContext _context;
        public HomeController(CombineContext context)
            {
                _context = context;
            }
        [HttpGet("Allusers")]
        public IEnumerable<Users> Allusers()
        {
            System.Console.WriteLine("getting Users");
           var AllUser =  _context.Users.OrderBy(x=>x.first_name);
           return AllUser;
        }
        [HttpGet("GetOne/{userid}")]
        public Object OneUser(int userid)
        {
            System.Console.WriteLine("Get one User");
            var OneUser = _context.Users.SingleOrDefault(x=>x.id == userid);
            return OneUser;
        }

        [HttpPost("createUser")]
        public void NewUser([FromBody] UserViewModel user){ //formBody is form passing angular form data to ViewModel
            System.Console.WriteLine("=============================================");
            System.Console.WriteLine(" line 48 in home Controller creating User");
            System.Console.WriteLine(" line 49 in home Controller" + user);
            System.Console.WriteLine("=============================================");
            PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
            user.password = Hasher.HashPassword(user, user.password);
            Users newUser = new Users{
                first_name = user.first_name,
                last_name = user.last_name,
                email = user.email,
                password = user.password
            };
            System.Console.WriteLine("=============================================");
            System.Console.WriteLine(newUser.first_name);
            System.Console.WriteLine("line 56 in home Controller " + newUser);
            System.Console.WriteLine("=============================================");
            _context.Add(newUser);
            _context.SaveChanges();
        }
        
        [HttpPatch("updateUser/{userid}")]
        public void UpdateUser([FromBody]UserViewModel update, int userid){
            System.Console.WriteLine("=============");
            System.Console.WriteLine(userid);
            System.Console.WriteLine("=============");
            Users updatuser = _context.Users.SingleOrDefault(x=>x.id == userid);
            updatuser.first_name = update.first_name;
            updatuser.last_name = update.last_name;
            updatuser.email = update.email;
            _context.SaveChanges();
        }
        [HttpDelete("DeleteUser/{id}")] // remember to add {id} to get params id from angular
        public void DeleteUser(int id){ // id should be the same as the api route id = {id}
            System.Console.WriteLine("=======================");
            System.Console.WriteLine(id);
            System.Console.WriteLine("Delete user");
            System.Console.WriteLine("=======================");
            Users getOneUser = _context.Users.Where(x=>x.id == id).FirstOrDefault();
            System.Console.WriteLine(getOneUser);
            _context.Remove(getOneUser);
            _context.SaveChanges();
            System.Console.WriteLine("=======================");            
            System.Console.WriteLine("Delete user successfully");
            System.Console.WriteLine("=======================");            
        }
    }
}
