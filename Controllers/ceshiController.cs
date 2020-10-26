using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zhuaoyu.Models;

namespace zhuaoyu.Controllers
{
    public class ceshiController : Controller
    {
        // GET: ceshi
        public ActionResult Index()
        {
            return Content("123");
        }
        public ActionResult showinfo()
        {
            ceshiclass new1 = new ceshiclass();
            new1.name = "朱傲宇";
            new1.age = 18;
            return View(new1);
        }
        public ActionResult zhece()
        {
            return View();
        }
        public ActionResult zhanshi(string name,int age)
        {
            ceshiclass new1 = new ceshiclass();
            new1.name = name;
            new1.age = age;
            return View(new1);
        }
    }
}