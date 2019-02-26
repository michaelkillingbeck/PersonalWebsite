using PersonalWebsite.Interfaces;
using PersonalWebsite.Repositories;
using System.Web.Mvc;

namespace PersonalWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IWidgetRepository _widgetRepository;

        public ActionResult Index()
        {
            _widgetRepository = new MEFWidgetRepository();

            return View();
        }

        public ActionResult Widget()
        {
            _widgetRepository = new MEFWidgetRepository();
            var widget = _widgetRepository.GetRandomWidget();

            return View(widget);
        }
    }
}