using API.Errors;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly ReservationDbContext _reservationDbContext;

        public BugController(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        [HttpGet("NotFound/{id}")]
        public  ActionResult GetNotFound(int id)
        {
            var obj = _reservationDbContext.Tables.Find(id);
            if(obj == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult ServerError(int id)
        {
            var obj = _reservationDbContext.Tables.Find(id);
           
            var  objReturn = obj.ToString();
            return Ok(objReturn);
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult NotFoundRequest(int id)
        {
            return Ok();

        }
    }
}
