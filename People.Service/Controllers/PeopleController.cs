using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using People.Service.Models;
using PersonRepository.Interface;

namespace People.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        public IPeopleProvider provider { get; set; }
        private readonly ILogger<PeopleController> logger;

        public PeopleController(IPeopleProvider provider, ILogger<PeopleController> logger)
        {
            this.provider = provider;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return provider.GetPeople();
        }
    }
}
