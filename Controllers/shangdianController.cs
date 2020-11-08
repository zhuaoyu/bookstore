using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zhuaoyu.Controllers
{
    public class shangdianController : Controller
    {
        // GET: shangdian
        [OutputCache(CacheProfile ="sqlCache")]//应用服务器缓存过滤器
        public ActionResult Index( )
        {
            List<db1.Books> list1 = db1.bll.book.getboos();
            return View(list1);
        }
        [HttpPost]
        public ActionResult xinzeng(db1.Books book1)
        {
            db1.bll.book.insert2(book1);
                return RedirectToAction("Index");
        } 
        [HttpGet]
        public ActionResult xinzeng()
        {
            db1.Books lala = new db1.Books();
            return View(lala);
        }
        [HttpGet]
        public ActionResult xiugai(int id)
        {
           db1.Books books = db1.bll.book.getentry(id);
            return View(books);
        }
        [HttpPost]
        public ActionResult xiugai(int id,string AuthorName, string Title, Nullable<decimal> Price)
        {
            db1.bll.book.xiugai(id, AuthorName, Title, Price);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult xiugai1(int id)
        {
            db1.Books books = db1.bll.book.getentry(id);
            return View(books);
        }
        [HttpPost]
        public ActionResult xiugai1(db1.Books xinbiao)
        {
            db1.bll.book.xiugai2(xinbiao);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult xiugai2(int id)
        {
            db1.Books books = db1.bll.book.getentry(id);
            return View(books);
        }
        [HttpPost]
        public ActionResult xiugai2(db1.Books xinbiao)
        {
            db1.bll.book.xiugai3(xinbiao);
            return RedirectToAction("Index");
        }
        public ActionResult delete(int id)
        {
            db1.bll.book.delete(id);
            return RedirectToAction("Index");
        }

        [OutputCache(CacheProfile ="myCache")]//调用web.config文件里的缓存过滤器
        public ActionResult xiangqing(int id)

        {
       
            db1.Books book1 = db1.bll.book.getentry(id);
            return View(book1);
        }
    }
}