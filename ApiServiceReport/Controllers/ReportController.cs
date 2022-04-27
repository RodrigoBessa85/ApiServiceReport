using ApiServiceReport.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ApiServiceReport.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IHostingEnvironment _hostngEnvironment;
        private IServiceReport _serviceReport;

        public ReportController(IServiceReport iServiceReport, IHostingEnvironment hostingEnvironment)
        {
            _serviceReport = iServiceReport;
            _hostngEnvironment = hostingEnvironment;
        }


        [HttpGet]
        [Route("export_PDF")]
        public ActionResult export_PDF()
        {
            var byteRes = new byte[] { };
            string path = _hostngEnvironment.ContentRootPath + "\\Report\\usuario.rdlc";
            byteRes = _serviceReport.CreateReportFile(path);

            return File(byteRes, System.Net.Mime.MediaTypeNames.Application.Octet, "ReportName.pdf");
        }

    }
}
