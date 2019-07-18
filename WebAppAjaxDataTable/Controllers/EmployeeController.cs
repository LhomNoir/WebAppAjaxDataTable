using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAjaxDataTable.Models;
using WebAppAjaxDataTable.Repositories;

namespace WebAppAjaxDataTable.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee  
        public ActionResult Index()
        {
            return View();
        }

        private EmployeeRepository EmployeeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchVale = Request["search[valie]"];
            string srotColumnName = Request["cloumn[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];


            EmployeeRepository = new EmployeeRepository();
            var employeeList = EmployeeRepository.PopulateEmployeeList();

            return Json(new { data = employeeList }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                return null;
            }
        }
    }
}