using System.Web;
using System.Web.Mvc;
using zhuaoyu.Filters;

namespace zhuaoyu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           //filters.Add(new myErrorAttribute());//自己创建的异常过滤器,给用户时启用
          filters.Add(new HandleErrorAttribute());//系统自带的错误过滤器，自己开发时用
            //filters.Add(new diyAuthAttribute());//用于登录验证
            //filters.Add(new myActionAttribute());// 用于计算action和view使用时间



        }
    }
}
