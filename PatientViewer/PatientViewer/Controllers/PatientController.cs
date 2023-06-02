using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PatientViewer.Interfaces;

namespace PatientViewer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        IPatientProcessor processor;
        public PatientController()
        {
            processor = new GetPatientByAPI();
        }
        //[Authorize]
        [HttpGet("/patients")]
        public async Task<IActionResult> patients()
        {
            var resultContentString = await processor.GetPatients();
            return Ok(resultContentString);
        }
       // [Authorize]
        [HttpGet("/patients/{patientId}")]
        public async Task<IActionResult> patientId(string patientId)
        {
            var resultContentString = await processor.GetPatients();
            var patients = JArray.Parse(resultContentString);
            var result = await processor.GetPatientById(patientId);
            return Ok(result);
        }
    }
}