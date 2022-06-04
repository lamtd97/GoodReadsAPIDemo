using Contracts;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoodReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public UserBooksController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/<UserBooksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserBooksController>/5
        [HttpGet("{userId}")]
        public ActionResult Get(Guid userId)
        {
            try
            {
                var books = _repository.UserBook.GetListBookRead( userId);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        // POST api/<UserBooksController>
        [HttpPost]
        public ActionResult Post([FromBody] UserBookVM userBook)
        {
            try
            {
                var books = _repository.UserBook.AddReadingBook(userBook);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        // POST api/<UserBooksController>
        [HttpPost("updateReadBook")]
        public ActionResult UpdateReadBook([FromBody] UserBookVM userBook)
        {
            try
            {
                var books = _repository.UserBook.UpdateReadBook(userBook);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
