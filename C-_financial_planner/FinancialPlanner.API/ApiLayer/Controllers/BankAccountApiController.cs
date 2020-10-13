using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialPlanner.API.Data_Access_Layer;
using FinancialPlanner.API.Models;
using FinancialPlanner.API.Service_Layer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialPlanner.API.Controllers
{
    
    [Route("api/bankAccounts")]
    [ApiController]
    public class BankAccountApiController : Controller
    {
        private readonly BankAccountService Service;

        public BankAccountApiController(BankAccountService service)
        {
            this.Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<BankAccount> GetAllBankAccounts()
        {
            var bankAccounts = this.Service.GetAll();
            return bankAccounts;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public BankAccount Get(int id)
        {
            return this.Service.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void PostBankAccount([FromBody]string value)
        {
            this.Service.CreateNewBankAccount(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}