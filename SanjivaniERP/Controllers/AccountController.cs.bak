using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SanjivaniERP.Models;
using SanjivaniModalView;
using SanjivaniBusinessLayer;
using System.IO;
using System.Collections.Generic;
using System.Data;

namespace SanjivaniERP.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userm = UserManager.FindByEmail(model.Email);
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userm.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    DataTable dt = objPartnerBAL.GetLoginDetail(userm.Id);
                    Session["UserId"] = Convert.ToString(dt.Rows[0]["CustId"]);
                    Session["CustName"] = Convert.ToString(dt.Rows[0]["CustName"]);
                    Session["CustCategeory"] = Convert.ToString(dt.Rows[0]["CustCategeory"]);
                    Session["Completemsg"] = "No";
                    Session["Dothis"] = "0";
                    return RedirectToAction("ChannaPartnerList", "Partner");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _PartialCPRegister(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.CustId))
                {
                    var user = new ApplicationUser { UserName = model.UserName, Email = model.EmailID };
                    var result = await UserManager.CreateAsync(user, model.pwd);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        var UserId = user.Id;
                        // if (ModelState.IsValid)
                        {
                            model.AspUserId = UserId;
                            model.ParentId = "1";
                            model.CustCategroryId = "2";
                            var EventsTitleList = objPartnerBAL._partialCPSave(model);
                            if (Convert.ToInt32(EventsTitleList) > 0)
                            {
                                Session["Tab"] = "2";
                                Session["CustId"] = EventsTitleList;
                                return RedirectToAction("ChannelPartner", "CP");
                            }
                        }
                    }
                }
            }
            return RedirectToAction("ChannelPartner", "CP");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _PartialCPCRegister(FormCollection fc, CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                int custid = Convert.ToInt32(model.CustId);
                if (custid > 0)
                {
                    model.ParentId = model.CpCategory;
                    model.CustCategroryId = "3";
                    var CPCSaveList = objPartnerBAL.UpdateCPCRegisterDetails(model, postedFile);
                    if (Convert.ToInt32(CPCSaveList) > 0)
                    {
                        Session["Tab"] = "2";
                        Session["CustId"] = CPCSaveList;
                    }
                }
                else
                {
                    var user = new ApplicationUser { UserName = model.UserId, Email = model.EmailID };
                    var result = await UserManager.CreateAsync(user, model.pwd);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        var UserId = user.Id;
                        // if (ModelState.IsValid)
                        {
                            model.AspUserId = UserId;
                            model.ParentId = model.CpCustomer;
                            model.CustCategroryId = "3";
                            var EventsTitleList = objPartnerBAL._partialCPCSave(model);
                            if (Convert.ToInt32(EventsTitleList) > 0)
                            {
                                Session["Tab"] = "2";
                                Session["CustId"] = EventsTitleList;
                                return RedirectToAction("CPCChennelPartner", "CP", new { CustId = 0 });
                            }
                        }
                    }
                }
            }
            return RedirectToAction("CPCChennelPartner", "CP", new { CustId = 0 });
        }
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.CustId))
                {
                    var user = new ApplicationUser { UserName = model.UserName, Email = model.EmailID };
                    var result = await UserManager.CreateAsync(user, model.pwd);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        var UserId = user.Id;
                        // if (ModelState.IsValid)
                        {
                            model.AspUserId = UserId;
                            model.ParentId = "1";
                            model.CustCategroryId = "2";
                            var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
                            var k = 0;
                            foreach (HttpPostedFileBase file in postedFile)
                            {

                                if (file != null)
                                {
                                    var filename = Path.GetFileName(file.FileName);
                                    if (k == 0)
                                    {
                                        var filename1 = Path.GetFileName(file.FileName);
                                        if (filename1 != null)
                                        {
                                            var Type = 0;
                                            //  var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                                            // file.SaveAs(filePath);
                                            var fileName = Path.GetFileName(file.FileName);
                                            var path = Path.Combine(Server.MapPath("~/Documents/Logo"), fileName);
                                            file.SaveAs(path);
                                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                                        }
                                    }
                                    else if (k == 1)
                                    {
                                        var Type = 1;
                                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                                        file.SaveAs(filePath);
                                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                                    }
                                    else if (k == 2)
                                    {
                                        var Type = 2;
                                        var path = Path.Combine(Server.MapPath("~/Documents/RegDocument"), filename);
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                                    }
                                    else if (k == 3)
                                    {
                                        var Type = 3;
                                        var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto"), filename);
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                                    }
                                    else if (k == 4)
                                    {
                                        var Type = 4;
                                        var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature"), filename);
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                                    }
                                    k++;
                                }
                            }
                            var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
                            ViewBag.ChennelPartnerList = ChennelPartnerList;
                        }
                        //Session["Completemsg"] = "No";
                        //Session["Dothis"] = "1";
                        //Session["Domain"] = model.ObjBusinessDetails.CurrentDomainProvide;
                        //return RedirectToAction("UpL", "Partner");
                        string url = "https://sanjivanitechnology.com";
                        return Redirect("https://sanjivanitechnology.com");
                    }
                    AddErrors(result);
                }
                else
                {
                    // model.AspUserId = UserId;
                    model.ParentId = "1";
                    model.CustCategroryId = "2";
                    var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
                    var k = 0;
                    foreach (HttpPostedFileBase file in postedFile)
                    {

                        if (file != null)
                        {
                            var filename = Path.GetFileName(file.FileName);
                            if (k == 0)
                            {
                                var filename1 = Path.GetFileName(file.FileName);
                                if (filename1 != null)
                                {
                                    var Type = 0;
                                    var path = Path.Combine(Server.MapPath("~/Documents/Logo"), filename);
                                    file.SaveAs(path);
                                    var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                                }
                            }
                            else if (k == 1)
                            {
                                var Type = 1;
                                var path = Path.Combine(Server.MapPath("~/Documents/Pan"), filename);
                                file.SaveAs(path);

                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                            }
                            else if (k == 2)
                            {
                                var Type = 2;
                                var path = Path.Combine(Server.MapPath("~/Documents/RegDocument"), filename);
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                            }
                            else if (k == 3)
                            {
                                var Type = 3;
                                var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto"), filename);
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                            }
                            else if (k == 4)
                            {
                                var Type = 4;
                                var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature"), filename);
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                            }
                            k++;
                        }
                    }
                    //new Thread(() => {
                    //    BackgroundJob.Enqueue(() => UpLoadStoreFront());
                    //}).Start();

                    //UpLoadStoreFront();
                    Session["Completemsg"] = "No";
                    Session["Dothis"] = "1";
                    Session["Domain"] = model.ObjBusinessDetails.CurrentDomainProvide;
                    return RedirectToAction("UpL", "Partner");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CPCRegister(FormCollection fc, CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.CustId))
                {
                    model.ParentId = model.CpCategory;
                    model.CustCategroryId = "3";
                    var CPCSaveList = objPartnerBAL.UpdateCPCRegisterDetails(model, postedFile);
                    var J = 0;
                    foreach (HttpPostedFileBase file in postedFile)
                    {
                        if (file != null)
                        {
                            var filename = Path.GetFileName(file.FileName);
                            if (J == 0)
                            {
                                var filename1 = Path.GetFileName(file.FileName);
                                if (filename1 != null)
                                {
                                    var Type = 0;
                                    var filePath = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto" + filename1));
                                    file.SaveAs(filePath);
                                    var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename1, CPCSaveList, Type);
                                }
                            }
                            else if (J == 1)
                            {
                                var Type = 1;
                                var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                                file.SaveAs(filePath);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                            }
                            else if (J == 2)
                            {
                                var Type = 2;
                                var path = Path.Combine(Server.MapPath("~/Documents/AdhaarCard" + filename));
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                            }
                            else if (J == 3)
                            {
                                var Type = 3;
                                var path = Path.Combine(Server.MapPath("~/Documents/LightBill" + filename));
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                            }
                            else if (J == 4)
                            {
                                var Type = 4;
                                var path = Path.Combine(Server.MapPath("~/Documents/Passport" + filename));
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                            }
                            J++;
                        }
                    }
                }
                else
                {
                    var user = new ApplicationUser { UserName = model.UserId, Email = model.EmailID };
                    var result = await UserManager.CreateAsync(user, model.pwd);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        var UserId = user.Id;
                        // if (ModelState.IsValid)
                        {
                            model.AspUserId = UserId;
                            model.ParentId = model.CpCategory;
                            model.CustCategroryId = "3";
                            var CPCSaveList = objPartnerBAL.SaveCPCRegisterDetails(model, postedFile);
                            var k = 0;
                            foreach (HttpPostedFileBase file in postedFile)
                            {
                                if (file != null)
                                {
                                    var filename = Path.GetFileName(file.FileName);
                                    if (k == 0)
                                    {
                                        var filename1 = Path.GetFileName(file.FileName);
                                        if (filename1 != null)
                                        {
                                            var Type = 0;
                                            var filePath = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto" + filename1));
                                            file.SaveAs(filePath);
                                            var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename1, CPCSaveList, Type);
                                        }
                                    }
                                    else if (k == 1)
                                    {
                                        var Type = 1;
                                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                                        file.SaveAs(filePath);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                                    }
                                    else if (k == 2)
                                    {
                                        var Type = 2;
                                        var path = Path.Combine(Server.MapPath("~/Documents/AdhaarCard/" + filename));
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                                    }
                                    else if (k == 3)
                                    {
                                        var Type = 3;
                                        var path = Path.Combine(Server.MapPath("~/Documents/LightBill" + filename));
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                                    }
                                    else if (k == 4)
                                    {
                                        var Type = 4;
                                        var path = Path.Combine(Server.MapPath("~/Documents/Passport" + filename));
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, CPCSaveList, Type);
                                    }
                                    k++;
                                }
                            }
                        }
                    }
                    AddErrors(result);
                }
                var CPCChennelPartnerList = objPartnerBAL.GetCPCChannelPartnerList();
                ViewBag.CPCChennelPartnerList = CPCChennelPartnerList;
            }
            // If we got this far, something failed, redisplay form
            return RedirectToAction("CPCChennelPartnerList", "CP", new { CustId = 0 });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>_PartialDirectorRegister(FormCollection fc, DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                int custid = Convert.ToInt32(model.CustId);
                if (custid > 0)
                {
                    model.ParentId = "0";
                    model.CustCategroryId = "1";
                    var UpdateDicrectorBusiness = objPartnerBAL.UpdateDirectorBusinessRegister(model, postedFile);
                    if (Convert.ToInt32(UpdateDicrectorBusiness) > 0)
                    {
                        Session["Tab"] = "2";
                        Session["CustId"] = UpdateDicrectorBusiness;
                    }
                }
                else
                {
                    var user = new ApplicationUser { UserName = model.UserId, Email = model.EmailID };
                    var result = await UserManager.CreateAsync(user, model.pwd);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        var UserId = user.Id;
                        // if (ModelState.IsValid)
                        {
                            model.AspUserId = UserId;
                            model.ParentId = "0";
                            model.CustCategroryId = "1";
                            var DirectorBusinessSaveList = objPartnerBAL.SaveDirectorBusinessDetails(model, postedFile);
                            if (Convert.ToInt32(DirectorBusinessSaveList) > 0)
                            {
                                Session["Tab"] = "2";
                                Session["CustId"] = DirectorBusinessSaveList;
                                return RedirectToAction("DirectorBusinessOwners", "CP", new { CustId = 0 });
                            }
                        }
                    }
                }
            }
            return RedirectToAction("DirectorBusinessOwners", "CP", new { CustId = 0 });
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DirectorBusinessRegister(FormCollection fc, DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.CustId))
                {
                    model.ParentId = "0";
                    model.CustCategroryId = "1";
                    var UpdateDicrectorBusiness = objPartnerBAL.UpdateDirectorBusinessRegister(model, postedFile);
                    var k = 0;
                    foreach (HttpPostedFileBase file in postedFile)
                    {
                        if (file != null)
                        {
                            var filename = Path.GetFileName(file.FileName);
                            if (k == 0)
                            {
                                var filename1 = Path.GetFileName(file.FileName);
                                if (filename1 != null)
                                {
                                    var Type = 0;
                                    var filePath = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto" + filename1));
                                    file.SaveAs(filePath);
                                    var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename1, UpdateDicrectorBusiness, Type);
                                }
                            }
                            else if (k == 1)
                            {
                                var Type = 1;
                                var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                                file.SaveAs(filePath);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, UpdateDicrectorBusiness, Type);
                            }
                            else if (k == 2)
                            {
                                var Type = 2;
                                var path = Path.Combine(Server.MapPath("~/Documents/AdhaarCard" + filename));
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, UpdateDicrectorBusiness, Type);
                            }
                            else if (k == 3)
                            {
                                var Type = 3;
                                var path = Path.Combine(Server.MapPath("~/Documents/LightBill" + filename));
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, UpdateDicrectorBusiness, Type);
                            }
                            else if (k == 4)
                            {
                                var Type = 4;
                                var path = Path.Combine(Server.MapPath("~/Documents/Passport" + filename));
                                file.SaveAs(path);
                                var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, UpdateDicrectorBusiness, Type);
                            }
                            k++;
                        }
                    }
                    // string url = "http://bds.pioneersoft.co.in";
                    //return Redirect("http://bds.pioneersoft.co.in");
                }
                else
                {
                    var user = new ApplicationUser { UserName = model.UserId, Email = model.EmailID };
                    var result = await UserManager.CreateAsync(user, model.pwd);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        var UserId = user.Id;
                        // if (ModelState.IsValid)
                        {
                            model.AspUserId = UserId;
                            model.ParentId = "0";
                            model.CustCategroryId = "1";
                            var DirectorBusinessSaveList = objPartnerBAL.SaveDirectorBusinessDetails(model, postedFile);
                            var J = 0;
                            foreach (HttpPostedFileBase file in postedFile)
                            {
                                if (file != null)
                                {
                                    var filename = Path.GetFileName(file.FileName);
                                    if (J == 0)
                                    {
                                        var filename1 = Path.GetFileName(file.FileName);
                                        if (filename1 != null)
                                        {
                                            var Type = 0;
                                            var filePath = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto" + filename1));
                                            file.SaveAs(filePath);
                                            var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename1, DirectorBusinessSaveList, Type);
                                        }
                                    }
                                    else if (J == 1)
                                    {
                                        var Type = 1;
                                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan" + filename));
                                        file.SaveAs(filePath);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, DirectorBusinessSaveList, Type);
                                    }
                                    else if (J == 2)
                                    {
                                        var Type = 2;
                                        var path = Path.Combine(Server.MapPath("~/Documents/AdhaarCard" + filename));
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, DirectorBusinessSaveList, Type);
                                    }
                                    else if (J == 3)
                                    {
                                        var Type = 3;
                                        var path = Path.Combine(Server.MapPath("~/Documents/LightBill" + filename));
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, DirectorBusinessSaveList, Type);
                                    }
                                    else if (J == 4)
                                    {
                                        var Type = 4;
                                        var path = Path.Combine(Server.MapPath("~/Documents/Passport" + filename));
                                        file.SaveAs(path);
                                        var UploadDocument = objPartnerBAL.SaveUploadCPCDoc(filename, DirectorBusinessSaveList, Type);
                                    }
                                    J++;
                                }
                            }
                        }
                    }
                    AddErrors(result);
                }
            }
            // If we got this far, something failed, redisplay form
            return RedirectToAction("DirectorBusinessOwnersList", "CP");
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}