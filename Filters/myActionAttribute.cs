using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zhuaoyu.Filters
{
    public class myActionAttribute : FilterAttribute, IActionFilter,IResultFilter
    {

        private Stopwatch timer;//创建记录时间的变量Stopwatch(需要using命名空间)
        //执行action之后
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }
        //执行action之前
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = new Stopwatch();//创建变量
            timer.Start();//开始计时
        }
        //执行View之后
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();//计时结束
            filterContext.HttpContext.Response.Write
                ("时间：" + timer.ElapsedMilliseconds);//以毫秒的形式输出
        }
        //执行Vie之前
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
             
        }
    }
}