using ApiServiceReport.Model;
using AspNetCore.Reporting;
using System.Collections.Generic;
using System.Text;

namespace ApiServiceReport.Service
{
    public class ServiceReport : IServiceReport
    {
        public byte[] CreateReportFile(string pathRdlc)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            LocalReport report = new LocalReport(pathRdlc);
            List<Usuario> usuario = new List<Usuario>();

            usuario.Add(new Usuario
            {
                Nome = "Rodrigo",
                Sobrenome = "Bessa",
                Email = "teste@teste.com.br",
                Telefone = "065165156"
            });

            report.AddDataSource("dsPerson", usuario);
            var result = report.Execute(RenderType.Pdf, 1);
            return result.MainStream;
        }
    }
}
