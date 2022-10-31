using gebzedemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace gebzedemo.Controllers
{
    public class IletisimController : Controller
    {
        IletisimDb dbop = new IletisimDb();


        public IActionResult Index()
        {



            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] IletisimSend iletisimSend)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ///iletisimSend.Name = "anan";
                    ///iletisimSend.Surname = "anan";
                    ///iletisimSend.Phone = 655555;
                    /// iletisimSend.Message = "anan";
                    ///iletisimSend.Email = "";
                    string res = dbop.SaveRecord(iletisimSend);
                    TempData["msg"] = res;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message.ToString();
            }

            return View();
        }
    }
}
