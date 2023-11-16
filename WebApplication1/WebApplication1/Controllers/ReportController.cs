using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text;
using WebApplication1.Model;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    public ReportController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public ActionResult Print()
    {
        List<Studemt> dataSource = new List<Studemt>();
        dataSource.Add(new Studemt
        {
            StudentRegNo = 1,
            StudentName = "monae",
            StudentEmail = "monae@gmail.com",
            StudentPhone = "01303",
            CreatedAt = DateTime.Now,
            CreatedBy = "m",
            UpdatedAt = DateTime.Now,
            UpdatedBy = "m"
        });
        
        dataSource.Add(new Studemt
        {
            StudentRegNo = 2,
            StudentName = "monae1",
            StudentEmail = "monae1@gmail.com",
            StudentPhone = "013031",
            CreatedAt = DateTime.Now,
            CreatedBy = "m1",
            UpdatedAt = DateTime.Now,
            UpdatedBy = "m1"
        });

        string reportName = "TestReport.pdf"; // report name
        string reportPath = Path.Combine(_environment.ContentRootPath, "Report", "Report1.rdlc"); // get rdlc path

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("utf-8");

        LocalReport report = new LocalReport(reportPath);

        report.AddDataSource("DataSet1", dataSource); // ("DatasetName","DatasetValue")


        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("Name", "Monaem"); // add parameter ("ParameterName","ParameterValue")
        var result = report.Execute(RenderType.Pdf, 2, parameters); // rendertype, no of parameter including dataset

        return File(result.MainStream, MediaTypeNames.Application.Octet, reportName); // process the file as pdf
    }
}
