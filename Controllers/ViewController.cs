using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zhuaoyu.Controllers
{
    public class ViewController : Controller//表单传递数据
    {
        // GET: View
        public ActionResult Index()
        {
            return View();
        }
        //因为是post请求传过来的数据，所以自己不用视图展示，传递到其他视图（show）进行展示
        //在submint里先接收post传过来的数据(接收名称与Index视图定义的名称一致),
        //接收和传递数据方法有两种，viewdata[]和tempdata[],但是viewdata只能传递给自己的视图，所以submit的viewdata只能传给自己的视图，传递不到show的视图
       // 然后传给show的视图
       //对于多选框传值，需要注意，使用string[]接收，传过来的就是数组
       //使用request[].tostring,取值就是带逗号的字符串(把取得值数组用request转为字符串)
        
        public ActionResult submit(string username,string intro,string password,string sex,string city,string city1,string sex1,string[] love)
        {
            TempData["username"] = username;
            TempData["intro"] = intro;
            TempData["password"] = password;
            TempData["sex"] = sex;
            TempData["city"] = city;
            TempData["city1"] = city1;
            TempData["sex1"] = sex1;
            TempData["love"] = Request["love"].ToString();
            
            return RedirectToAction("show");
        }
        //接收的数据直接在视图里用tempdata[]展示
        public ActionResult show()
        {
            return View();
        }
    }
}