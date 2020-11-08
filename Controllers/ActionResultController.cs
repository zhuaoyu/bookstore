using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zhuaoyu.Controllers
{
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()//展示界面，嵌套了两个分界面
        {
            //第一种跳转方式，通过url进行跳转
            //return new RedirectResult("/store/booklist");
         //第二种跳转方式，通过路由参数跳转
           // return RedirectToAction( "booklist", "store");
            return View();
            // return PartialView();  返回不带母版的视图


        }
        [ChildActionOnly]//预防其他请求直接调用。
        public PartialViewResult booklist1()//创建不返回母版的低于20元的书本列表
        {
            List<db1.Books> list = db1.bll.book.getboos1();
            return PartialView(list);
        }
        [ChildActionOnly]//预防其他请求直接调用。
        public PartialViewResult booklist2()////创建不返回母版的大于等于20元的书本列表
        {
            List<db1.Books> list = db1.bll.book.getboos2();
            return PartialView(list);
        }
        public ContentResult css(string color)//返回不同类型的数据，可根据模板注释代码调用,也可以返回js类型，等各种类型。参考MIME改变要输出的类型
        {
            if (color == "red")
            {
                return Content("body{color:red}", "text/css");
            }
            if (color == "blue")
            {
                return Content("body{color:blue}", "text/css");
            }
            return Content( "body{color:black}", "text/css" );
        }
        public FileResult download()//下载文件，先输入下载文件的路径，在输入类型，类型可百度MIME参考手册找类型对应代码，最后输入别人下载时出现的名称。
        {
            //第一种使用方法是直接在浏览器输入url地址调用
            //第二种使用方法，在别的视图中通过如下代码调用
           // < fieldset >
          //< legend > 在界面调用下载 </ legend >
          // < div >< a href = "/ActionResult/download" > 下载 </ a ></ div >
          //   </ fieldset >
            return File(Server.MapPath("~/text.txt"), "text/plain", "我的文件.txt");
        }
        public JsonResult json1()//把对象转为josn数据返回
        {
            var p = new
            {
                name = "小王",
                age = 12,
                parent = new[]
                {
                    new {name="小王父亲",age=41},
                      new {name="小王母亲",age=40},
                }
            };
            return Json(p, JsonRequestBehavior.AllowGet);//允许get请求
        }
        public JsonResult json2()
        {
            var p= db1.bll.book.getboos();
            return Json(p, JsonRequestBehavior.AllowGet);//通过url可直接获取数据，且类型为json数据的类型。
        }
        public JavaScriptResult js()//提交的类型为js类型的代码
        {
            return JavaScript("alert('123')");
            //使用方法为在html界面输入如下代码
             //  < script type = "text/javascript" >
             //$.getScript("/ActionResult/js");
             // </ script >
        }
    }
}