using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            bool Status = false;
            String message = "";

            //Model validation
            if (ModelState.IsValid) 
            {
                //Email already exists

               


            }
            else
            {
                message = "Invalid Request";
            }
            

            //Generate activation code

            //Password hashing 

            //Save to database 

            //Send email to user 


            return View(user);
        }

        private object EmailExists(object emailID)
        {
            throw new NotImplementedException();
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