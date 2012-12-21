using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using FuzzySearch;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private List<string> list = new List<string>
                                        {
                                            "B57EA1EC-0C30-459D-ACB6-A69629C73FDF",
                                            "test",
                                            "foo",
                                            "2F873BC7-1744-40C9-8F0D-5F0951EFD78B",
                                            "foobar",
                                            "foo bar",
                                            "qux"
                                        }; 
        public ActionResult Index()
        {
            return View(list);
        }

        public ActionResult Search(string term)
        {
            var results = list.OrderByDescending(s => s.LCSLength(term));
//            var results = list.Select(x => new {value = x, lcsl = x.LCSLength(term)})
//                              .OrderByDescending(x => x.lcsl)
//                              .Select(x => x.value + " " + x.lcsl);
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}
