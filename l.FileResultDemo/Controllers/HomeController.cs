using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
namespace l.FileResultDemo.Controllers;

[Route("/[action]")]
public class HomeController : Controller
{
    [Route("")]
    [Route("/")]
    public ActionResult Index()
    {
        return View();
    }

    // Define an action method that returns a FileResult
    public FileResult DownloadFileResult()
    {
        // Get the current directory of the application and construct the file path for the PDF file
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", "goat.pdf");

        // Read all the bytes of the PDF file into a byte array
        var fileBytes = System.IO.File.ReadAllBytes(filePath);

        // Create a FileResult object using the byte array and specify the content type as "application/pdf"
        var fileResult = File(fileBytes, "application/pdf");

        // Set the name of the file to be downloaded by the user
        fileResult.FileDownloadName = "Goat-Via-File-Result.pdf";

        // Set the last modified date of the file
        fileResult.LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTimeUtc(filePath));

        // Set the entity tag (ETag) for the file
        fileResult.EntityTag = new EntityTagHeaderValue("\"fileVersion1\"");

        // Enable range processing for the file
        fileResult.EnableRangeProcessing = true;

        // Return the FileResult object
        return fileResult;
    }

    public FileStreamResult DownloadFileStreamResult()
    {
        // Get the current directory of the application and construct the file path for the PDF file
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", "goat.pdf");
        // Create a FileStream to the PDF file
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        // Create a FileStreamResult object using the file stream and specify the content type as "application/pdf"
        var fileResult = new FileStreamResult(fileStream, "application/pdf")
        {
            // Set the name of the file to be downloaded by the user
            FileDownloadName = "Goat-Via-File-Stream-Result.pdf",
            // Set the last modified date of the file
            LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTimeUtc(filePath)),
            // Set the entity tag (ETag) for the file
            EntityTag = new EntityTagHeaderValue("\"fileVersion1\""),
            // Enable range processing for the file
            EnableRangeProcessing = true
        };
        // Return the FileStreamResult object
        return fileResult;
    }

     public VirtualFileResult DownloadVirtualFileResult()
    {
        // Define the virtual path for the PDF file
        string virtualFilePath = "/pdf/goat.pdf";
        // Create a VirtualFileResult object using the virtual path and specify the content type as "application/pdf"
        var fileResult = new VirtualFileResult(virtualFilePath, "application/pdf")
        {
            // Set the name of the file to be downloaded by the user
            FileDownloadName = "Goat-Via-Virtual-File-Result.pdf",
            // Optionally, set the last modified date of the file
            // LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTimeUtc(filePath)),
            // Optionally, set the entity tag (ETag) for the file
            // EntityTag = new EntityTagHeaderValue("\"fileVersion1\""),
            // Enable range processing for the file
            // EnableRangeProcessing = true
        };
        // Return the VirtualFileResult object
        return fileResult;
    }

    public PhysicalFileResult DownloadPhysicalFileResult()
        {
            // Get the current directory of the application and construct the file path for the PDF file
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdf", "goat.pdf");
            // Create a PhysicalFileResult object using the file path and specify the content type as "application/pdf"
            var fileResult = new PhysicalFileResult(filePath, "application/pdf")
            {
                // Set the name of the file to be downloaded by the user
                FileDownloadName = "Goat-Via-Physical-File-Result.pdf",
            };
            // Return the PhysicalFileResult object
            return fileResult;
        }
}