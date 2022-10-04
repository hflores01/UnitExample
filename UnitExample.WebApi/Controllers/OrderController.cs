using Microsoft.AspNetCore.Mvc;
using UnitExample.Negocio.Modelo;
using UnitExample.Negocio.Repositorio.Interfaz;
using Microsoft.Reporting.NETCore;

namespace UnitExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            OrderModel order = await _orderService.GetOrderByIdAsync(id);

            return Ok(order);
        }

        [HttpPost]
        [Route("GetR_OrdenesAsync")]
        public async Task<IActionResult> GetR_OrdenesAsync([FromBody] ReporteAgregadoModel modelo)
        {
            try
            {
                string? contentRootPath;

                if (AppDomain.CurrentDomain.GetData("ContentRootPath") != null)
                {
                    contentRootPath = AppDomain.CurrentDomain.GetData("ContentRootPath")?.ToString();
                }
                else
                {
                    //ErrorEntity err = new ErrorEntity();
                    //err.Excepcion = new Exception("No se logro hallar el camino de la publicación");
                    //err.Rutina = "GetR_OrdenesAsync";
                    //err.TipoCapturado = "UnitExample.WebApi";
                    //ErrorEntity.EscribirError(err);
                    throw new Exception("No se logro hallar el camino de la publicación");
                }

                string reportPath = Path.Combine(contentRootPath ?? "", @"Reportes\RptOrdenes.rdlc");
                LocalReport localReport = new LocalReport();

                try
                {

                    using (Stream stream = System.IO.File.OpenRead(reportPath))
                    {
                        localReport.LoadReportDefinition(stream);
                        localReport.DataSources.Add(new ReportDataSource("dsCoreExamen", await _orderService.GetV_OrdenesAsync(modelo)));
                        localReport.SetParameters(new[] { new ReportParameter("fromDate", modelo.fechaRegistroInicial.ToString("dd/MM/yyyy")) });
                        localReport.SetParameters(new[] { new ReportParameter("toDate", modelo.fechaRegistroFinal.ToString("dd/MM/yyyy")) });

                        Warning[] warnings;
                        string[] streamids;
                        string mimeType;
                        string encoding;
                        string filenameExtension;

                        if (modelo.fileType == "PDF")
                        {
                            byte[] pdf = localReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                            return File(pdf, "application/pdf");
                        }
                        else
                        {
                            byte[] xls = localReport.Render("Excel", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                            return File(xls, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ErrorEntity err = new ErrorEntity();
                    //err.Excepcion = ex;
                    //err.Rutina = "GetR_OrdenesAsync";
                    //err.TipoCapturado = "UnitExample.WebApi";
                    //ErrorEntity.EscribirError(err);
                    throw;
                }
                finally
                {
                    localReport.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                //ErrorEntity err = new ErrorEntity();
                //err.Excepcion = ex;
                //err.Rutina = "GetR_OrdenesAsync";
                //err.TipoCapturado = "UnitExample.WebApi";
                //ErrorEntity.EscribirError(err);
                throw;
            }

        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
