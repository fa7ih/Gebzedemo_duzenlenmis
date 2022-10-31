using gebzedemo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gebzedemo.Controllers
{

    public class AdminController : Controller
    {
        ///authentication
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4JD2R8F\\TEW_SQLEXPRESS;Database=gezgebze; User ID=sa;Password=enesusta; Integrated Security=True");
        DataSet ds = new DataSet();
        private List<Models.AdminGetData> messages = new List<Models.AdminGetData>();





        public IActionResult Login()
        {


            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminCred adminCredits)
        {

            if (adminCredits.Username == "admin" && adminCredits.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, adminCredits.Username)
                };
                var userIdentity = new ClaimsIdentity(claims, "Admin");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Admin");


            }
            else
            {
                TempData["msg"] = "Kullanici Adi veya Sifre Yanlis";
            }
            return View();


        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Admin");
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            { /// sql bağlan veri çek

                SqlCommand com = new SqlCommand("SELECT COUNT(*) FROM iletisim", con);
                con.Open();
                TempData["MesajSayisi"] = com.ExecuteScalar();


                con.Close();

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Bir hata oluştu hata kodu:" + ex.Message;


            }


            return View();

        }



        [Authorize]
        public ActionResult Messages()
        {
            SqlCommand com = new SqlCommand("SELECT COUNT(*) FROM iletisim", con);



            con.Open();
            int count = (int)com.ExecuteScalar();
            SqlDataAdapter da = new SqlDataAdapter("select * from iletisim", con);
            da.Fill(ds);


            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                messages.Add(new Models.AdminGetData() { Id = int.Parse(dr[0].ToString()), Name = dr[1].ToString(), Surname = dr[2].ToString(), Phone = dr[3].ToString(), Message = dr[4].ToString(), Email = dr[5].ToString() });

            }



            return View(messages);
        }

        public List<Models.AdminGetData> GetData()
        {
            List<Models.AdminGetData> adminGetDatas = new List<Models.AdminGetData>();
            for (int i = 0; i <= 20; i++)
            {
                Models.AdminGetData adminGetData = new Models.AdminGetData();
                adminGetData.Email = "Email" + i;
                adminGetData.Id = i;
                adminGetData.Message = "Message" + i;
                adminGetData.Name = "Name" + i;
                adminGetData.Phone = "Phone" + i;
                adminGetData.Surname = "Surname" + i;
                adminGetDatas.Add(adminGetData);


            }
            return adminGetDatas;
        }
        public void DeleteEmployee(int id)
        {


            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-4JD2R8F\\TEW_SQLEXPRESS;Database=gezgebze; User ID=sa;Password=enesusta; Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("spDeleteMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            DeleteEmployee(id);
            return RedirectToAction("Messages", "Admin");
        }












    }
}
