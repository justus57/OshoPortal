﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OshoPortal.Models;
using OshoPortal.Models.Classes;
using OshoPortal.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshoPortal.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            //incomming data from view through model
            var username = login.Username;
            var password = login.Password;
            string UserLoginresponseString = "";
            string Msg = null;
            string status = null;
            string RequirePassChnage = null;

            //hash password
            var hashpassword = Functions.ComputeSha256Hash(password);
     
            ///start session for user
            var profileData = new Login
            {
                Username = username
            };  
            this.Session["UserProfile"] = profileData;

            //confirm details
            try
            {
                UserLoginresponseString = LoginXMLRequests.UserLogin(username, hashpassword);
                LoginResponse json = JsonConvert.DeserializeObject<LoginResponse>(UserLoginresponseString);
                RequirePassChnage = json.RequirePassChange;
                status = json.Status;
                string UserFullName = json.EmployeeName;
                try
                {
                    System.Web.HttpContext.Current.Session["Username"] = username;
                    if (RequirePassChnage == "Yes")
                    {
                        if (ModelState.IsValid)
                        {
                            ModelState.AddModelError("", Msg);
                            ViewBag.Message = Msg;
                            //return RedirectToAction("OneTimePassword", "Account");
                            return RedirectToAction("Dashboard", "Dashboard");
                        }
                    }
                    else
                    {
                        Msg = "You have been successfully authenticated";
                        if (status == "000")
                        {
                            if (ModelState.IsValid)
                            {
                                ModelState.AddModelError("", Msg);
                                ViewBag.Message = Msg;
                                return RedirectToAction("Dashboard", "Dashboard");
                            }
                        }
                        else
                        {
                            Msg = "Authentication failed. Wrong username or password. Kindly contact the administrator";
                            ViewBag.Message = Msg;
                            ModelState.AddModelError("",Msg);
                            return View("Login");
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemLogs.WriteLog(ex.Message.ToString( ));
                }
            }
            catch (Exception ex)
            {
                status = "999";
                Msg = "Authentication failed. Wrong username or password. Kindly contact the administrator";
                Msg = ex.ToString();
                return View("Login");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword forgot)
        {
            string EmployeeNo = forgot.EmployeeNumber;
            string Msg = null;
            string status = null;
            try
            {
                dynamic json = ForgotPasswordXmlRequest.ForgotPassword(EmployeeNo);
                status = json.Status;
                Msg = json.Msg;
                if (status == "000")
                {
                    status = "000";
                    Msg = json.Msg;
                }
                else
                {
                    status = json.Status;
                    Msg = json.Msg;
                }
                ViewBag.Message = Msg;
            }
            catch (Exception es)
            {
                status = "999";
                ViewBag.Message = es.Message;
                Msg = "An error occured. Kindly contact the administrator";
                ViewBag.Message = Msg;
                SystemLogs.WriteLog(es.Message);
            }
            var _RequestResponse = new RequestResponse
            {
                Status = status,
                Message = Msg,
            };
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult OneTimePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OneTimePassword( OneTimePassword password)
        {
            string username = System.Web.HttpContext.Current.Session["Username"].ToString();
            string oldpass = password.OldPassword;
            string newpass = password.NewPassword;
            string Status = "0";
            string Msg = "";
            string Hashdstring = "";
            string OldPasswordHash = "";
            try
            {
                Hashdstring = newpass;
                OldPasswordHash = oldpass;
                string ChangePasswordresponseString = OneTimePassXMLRequests.ChangePassword(username, OldPasswordHash, Hashdstring);
                dynamic json = JObject.Parse(ChangePasswordresponseString);
                Status = json.Status;
                Msg = json.Msg;

                if (Status == "000")
                {
                    Msg = "Password has been changed succesfully";
                    Status = "000";
                    System.Web.HttpContext.Current.Session["RequirePasswordChange"] = "FALSE";
                    ViewBag.Message = Msg;
                    return RedirectToAction("Login", "Account");
                }

            }
            catch (Exception es)
            {
                Console.Write(es);
            }

            var _RequestResponse = new RequestResponse
            {
                Status = Status,
                Message = Msg
            };
            return View();
        }

        public ActionResult LogOut()
        {
            //loging out from the portal
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Account/Login");
            return View();
        }
    }
}