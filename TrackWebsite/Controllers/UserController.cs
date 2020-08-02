using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TrackWebsite.Model;

namespace TrackWebsite.Controllers
{
    public class UserController : Controller
    {
        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        //Registration post action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified, ActivationCode")] User user)
        {
            //
            //Model validation
            if (ModelState.IsValid) 
            {
                #region //Email already exists
                var IsExist = EmailExists(user.GetEmailID());
                if (IsExist) 
                {
                    ModelState.AddModelError("EmailExists", "Email already exists");
                    return View(user);
                }
                #endregion
                #region Generate activation code
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                user.IsEmailVerified = false;
                #endregion

               
            }
           


            //Send email to user 


            return View(user);
        }

       

        //Verify Email


        //Verify Email Link 





        //Login action 


        //Login post action


        //Logout

        [NonAction]
        public bool EmailExists(String emailID)
        {
            using(MyModel dc = new MyModel())
            {
                var v = dc.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null; 
            }
        }
    }
    
}