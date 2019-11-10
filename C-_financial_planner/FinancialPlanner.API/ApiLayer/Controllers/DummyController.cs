using FinancialPlanner.API.Data_Access_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlanner.API.Controllers
{
    public class DummyController : Controller
    {
        private FinancialPlannerContext _ctx;

        public DummyController(FinancialPlannerContext ctx)
        {
            _ctx = ctx;
        }
    }
}
