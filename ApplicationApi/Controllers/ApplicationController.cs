using ApplicationApi.Data;
using ApplicationApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationRepository _repo;
        public readonly IMapper _mapper;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("applications/")]
        public IEnumerable<ApplicationModel> Applications()
        {
            var results = _repo.Applications();
            if (results != null)
            {
                var mapped = results.Select(x => _mapper.Map<ApplicationModel>(x)).ToList();
                return mapped;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Route("applications/{id}")]
        public ApplicationModel Application(int id)
        {
            var result = _repo.Application(id);
            if (result != null)
            {
                var mapped = _mapper.Map<ApplicationModel>(result);
                return mapped;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Route("applications/{category}/{date}")]
        public IEnumerable<ApplicationModel> Applications(string category, DateTime date)
        {
            var results = _repo.Applications(category, date);
            if (results != null && results.Count > 0)
            {
                var mapped = results.Select(x => _mapper.Map<ApplicationModel>(x)).ToList();
                return mapped;
            }
            else
            {
                return null;
            }
        }
    }
}