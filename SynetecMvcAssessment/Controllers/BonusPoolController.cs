using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using SynetecMvcAssesment.Business.Tasks;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {

        private MvcInterviewV3Entities1 db = new MvcInterviewV3Entities1();

        // GET: BonusPool
        public ActionResult Index()
        {           
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();

            model.AllEmployees = db.HrEmployees.ToList<HrEmployee>();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            BonusPool newBonusPool = new BonusPool(new MvcInterviewV3Entities1());
            
            BonusPoolCalculatorResultModel result = new BonusPoolCalculatorResultModel();

            result.bonusPoolAllocation = newBonusPool.CalculateByEmployeeId(model.SelectedEmployeeId, model.BonusPoolAmount);
            
            return View(result);
        }
    }
}