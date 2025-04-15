using Airlines_Booking.Migrations;
using Airlines_Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airlines_Booking.Controllers
{
    public class UserController : Controller
    {
        private Mycontext _context;
        public UserController(Mycontext con)
        {
            _context = con;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult user_register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult user_register(user myser,string comfirm_password,string user_password)
        {
            var userEmail_existing = _context.tbl_user.FirstOrDefault
                (u => u.user_email == myser.user_email);
            if (userEmail_existing==null)
            {
                if (comfirm_password == user_password)
                {
                    myser.status = 1;
                    myser.status_update = "Active";
                    _context.tbl_user.Add(myser);
                    _context.SaveChanges();
                    TempData["msg1"] = "your account is successfully created ";
                    return RedirectToAction("user_login");
                }
                else
                {
                    TempData["msg1"] = "the confirm password is incorrect";
                    return RedirectToAction("user_register");
                }

            }
            else
            {
               
                TempData["msg1"] = "the email is already registered";
                return RedirectToAction("user_register");
              

            }

        }
        public IActionResult user_login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult user_login(string userEm,string userPass)
        {

            var data = _context.tbl_user.FirstOrDefault(a => a.user_email==userEm);
            if (data != null && data.user_password==userPass)
            {
                if (data.status == 1)
                {
                    HttpContext.Session.SetString("user_session", data.id.ToString());
                    return RedirectToAction("index", "website");
                }
                else
                {
                    return RedirectToAction("waitedpage","admin");
                }

            }
            else
            {
                TempData["errormsg"] = "the email or password is incorrected";
                return View();
            }
        }
    
        public IActionResult user_profile(int id)
        {
            var find_id = _context.tbl_user.Find(id);
        
            mainmodel data = new mainmodel()
            {
            user_data=find_id, 
            };
            return View(data);
                 
        }
        [HttpPost]
        public IActionResult user_profile(user myuser)
        {
            if (myuser.user_password == myuser.comfirm_password)
            {
                _context.tbl_user.Update(myuser);
                _context.SaveChanges();
                return RedirectToAction("index","website");
            }
            else
            {
                TempData["error"] = "The confirm password is not macthed";
                return RedirectToAction("index", "website");
            }
     }
        public IActionResult logout()
        {
            HttpContext.Session.Remove("user_session");
            return RedirectToAction("index", "website");
        }
    }


    }

