namespace ApiServiceReport.Service
{
    public interface IServiceReport
    {
        byte[] CreateReportFile(string pathRdlc);
    }
}
