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
    
    [Route("api/accountHolders")]
    [ApiController]
    public class AccountHolderApiController : Controller
    {
        private readonly AccountHolderService Service;

        public AccountHolderApiController(AccountHolderService service)
        {
            this.Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AccountHolder> GetAllAccountHolders()
        {
            return this.Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public AccountHolder Get(int id)
        {
            return this.Service.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void PostAccountHolder([FromBody]string value)
        {
            this.Service.CreateNewAccountHolder(value);
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