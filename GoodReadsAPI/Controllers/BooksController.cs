using Contracts;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoodReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public BooksController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper)
        {
            _logger = loggerManager;
            _repository = repositoryWrapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var books = _repository.Book.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var book = _repository.Book.GetBookById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("search")]
        public ActionResult GetByName(string name = "")
        {
            try
            {
                var books = _repository.Book.GetByName(name);
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }


        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                _repository.Book.Create(book);
                _repository.Book.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
