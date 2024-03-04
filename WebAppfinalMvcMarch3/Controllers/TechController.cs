using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAppfinalMvcMarch3.Models;


namespace WebAppfinalMvcMarch3.Controllers
{
    public class TechController : Controller
    {
        // GET: Tech
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login objLogin)
        {
            if (!this.IsCaptchaValid(errorText: ""))
            {
                ViewBag.ErrorMessage = "Captcha is not valid";
                return View("Index", new WebAppfinalMvcMarch3.Models.Logins());
            }

            return RedirectToAction("ViewPanelMembers");
        }
        public ActionResult ViewPanelMembers()
        {
            var panelMembers = GetPanelMembersFromDatabase();
            return View(panelMembers);
        }
        private List<PanelMembers> GetPanelMembersFromDatabase()
        {
            var panelMembers = new List<PanelMembers>
         {
       new PanelMembers { id = 1, name = "rakesh"},
        new PanelMembers { id = 2, name = "Ramesh" },
        };

            return panelMembers;
        }
    }
   


}

