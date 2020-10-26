using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zhuaoyu.Filters;

namespace zhuaoyu.Controllers
{
    [diyAuth]
    public class storeController : Controller
    {
        // GET: store
  
        public ActionResult booklist()
        {
            List<db1.Books> list1 = db1.bll.book.getboos();
            return View(list1);
        }
        [HttpGet]
        public ActionResult mingxi(int id)
        {
            db1.Books en1 = db1.bll.book.getentry(id);
            return View(en1);
        }
        [HttpPost]
        public ActionResult mingxi(int name,int? id,string xiangqing)
        {
            db1.bll.orders.insert(name, id, xiangqing);
            return RedirectToAction("bookjieguo");
        }
        public ActionResult bookjieguo()
        {
         
            List<db1.cha> list1 = db1.bll.orders.getorder();
            return View(list1);
           
        }
    }
}