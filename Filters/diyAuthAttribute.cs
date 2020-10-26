using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zhuaoyu.Filters
{
    public class diyAuthAttribute : FilterAttribute, IAuthorizationFilter
    {     //完成登录检测
        public void OnAuthorization(AuthorizationContext ac)
        {
            //解决所有控制器都添加过滤器导致无法进入登录action的问题
            //方法1：获取控制器和action的名称
            // string controllername = ac.Controller.ToString();
            //string actionname = ac.ActionDescriptor.ActionName;
            // if (controllername == "zhuaoyu.Controllers.loginController")
            //     return;//下面代码就需要要处理了
            //未登录
            //方法2:判断控制器或action是否有AllowAnonymous特性
            var actionAnony = ac.ActionDescriptor.
                GetCustomAttributes(typeof(AllowAnonymousAttribute), true) 
                as IEnumerable<AllowAnonymousAttribute>;
            //把当前运行的action的特性取出来赋值

            var controllerAnony = ac.Controller.GetType()
                .GetCustomAttributes(typeof(AllowAnonymousAttribute), true) 
                as IEnumerable<AllowAnonymousAttribute>;
            ////把当前运行的控制器的特性取出来赋值


            if ((actionAnony != null && actionAnony.Any()) 
                || (controllerAnony != null && controllerAnony.Any()))
                return;
            //判断运行的控制器或action是否有AllowAnonymous属性。如果有，结束，
            //不进行后面的跳转语句。


            if (ac.HttpContext.Session["islogin"] == null)//用户未登录
            {
                string url = ac.HttpContext.Request.RawUrl;//接收当前网页的地址
                ac.HttpContext.Session["tourl"] = url;//把地址传的session变量里
                ac.Result = new RedirectResult("/login/Index");//当前网页转到新网页：控制器名、action名
            }
            
        }
    }
}

