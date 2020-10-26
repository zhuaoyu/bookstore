using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zhuaoyu.Filters
{
    public class myErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext fc)
        {//自定义一个接受异常的过滤器
            string msg = "";
            if (fc.Exception != null)
                msg += fc.Exception.Message;
            if (fc.Exception.InnerException != null)
                msg += fc.Exception.InnerException.Message;
            fc.HttpContext.Session["erroMsg"] = msg;
            //代表异常被处理了
            fc.ExceptionHandled = true;
            fc.Result = new RedirectResult("/login/error");
          
        }
    }
}