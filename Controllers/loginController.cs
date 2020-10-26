using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zhuaoyu.Filters;

namespace zhuaoyu.Controllers
{
    [AllowAnonymous]
    [myAction]//引用命名空间
    public class loginController : Controller
    {
        // 登录界面
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(string name, string password)
        {
            if(name=="admin" && password=="123456")
            {//创建登录标识
                Session["islogin"] = true;
                //判断来源
                if (Session["tourl"] != null)
                {
                    return new RedirectResult(Session["tourl"].ToString());
                }

                else
                {
                    return new RedirectResult("/store/booklist");
                }
            }
            else
            {
                ViewData["show"] = "账号或密码不正确";//给View视图传值
                return View();//自己返回自己
            }
           
        }
        public ActionResult error()
        {
            return View();
        }
    }
}