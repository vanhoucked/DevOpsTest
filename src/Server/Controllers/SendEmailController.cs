using Microsoft.AspNetCore.Mvc;
using Project.Services.Email;
using Project.Shared.Emails;


namespace Project.Server.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ILogger<SendEmailController> _logger;
        private readonly ISendEmailService _sendEmailService;

        public SendEmailController(ILogger<SendEmailController> logger, ISendEmailService sendEmailService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _sendEmailService = sendEmailService ?? throw new ArgumentNullException(nameof(sendEmailService));
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail([FromBody] ContactDto.Detail contact)
        {
            try
            {
                if (string.IsNullOrEmpty(contact.Email) || string.IsNullOrEmpty(contact.Message) || string.IsNullOrEmpty(contact.Naam))
                {
                    _logger.LogDebug("Validation Error");
                    return BadRequest();
                }

                bool response = await _sendEmailService.SendEmail(contact);
                if (response)
                {
                    return Ok();
                }
                else
                {
                    _logger.LogError($"Error in {nameof(_sendEmailService)} service");
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
