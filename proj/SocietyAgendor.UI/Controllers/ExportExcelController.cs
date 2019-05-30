using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace SocietyAgendor.UI.Controllers
{
    public class ExportExcelController : Controller
    {
        private readonly IHostingEnvironment _env;

        public ExportExcelController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ExportFile()
        {
            string webRootFolder = _env.WebRootPath;
            string fileName = "test_vini.xls";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            string local = Path.Combine(webRootFolder, fileName);
            FileInfo file = new FileInfo(local);

            var memoryStream = new MemoryStream();

            using (var fs = new FileStream(local, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Teste_Vinicius");

                var fontStyle = workbook.CreateFont();
                var cellStyle = workbook.CreateCellStyle();
                var cellStyle2 = workbook.CreateCellStyle();

                #region Fonte
                // estilo da fonte
                fontStyle.Color = HSSFColor.Black.Index;
                fontStyle.IsBold = true;
                #endregion

                #region Estilo célula 1
                // borda
                cellStyle.BorderTop = BorderStyle.Thick;
                cellStyle.BorderRight = BorderStyle.Thick;
                cellStyle.BorderBottom = BorderStyle.Thick;
                cellStyle.BorderLeft = BorderStyle.Thick;

                // cor borda
                cellStyle.TopBorderColor = HSSFColor.Green.Index;
                cellStyle.RightBorderColor = HSSFColor.Green.Index;
                cellStyle.BottomBorderColor = HSSFColor.Green.Index;
                cellStyle.LeftBorderColor = HSSFColor.Green.Index;

                // alinhamento
                cellStyle.Alignment = HorizontalAlignment.Center;
                cellStyle.VerticalAlignment = VerticalAlignment.Center;

                // fonte
                cellStyle.SetFont(fontStyle);
                #endregion

                #region Estilo célula 2
                // alinhamento
                cellStyle2.Alignment = HorizontalAlignment.Center;
                cellStyle2.VerticalAlignment = VerticalAlignment.Center;
                cellStyle2.BorderTop = BorderStyle.Thin;
                cellStyle2.BorderRight = BorderStyle.Thin;
                cellStyle2.BorderBottom = BorderStyle.Thin;
                cellStyle2.BorderLeft = BorderStyle.Thin;
                #endregion

                var linha0 = sheet.CreateRow(0);
                var linha1 = sheet.CreateRow(1);
                var linha2 = sheet.CreateRow(2);

                linha0.HeightInPoints = 26;

                // DIA
                var celula00HeaderDia = linha0.CreateCell(0);
                var celula10HeaderDia = linha1.CreateCell(0);
                var celula20HeaderDia = linha2.CreateCell(0);

                // HORA
                var celula01HeaderHora = linha0.CreateCell(1);
                var celula11HeaderHora = linha1.CreateCell(1);
                var celula21HeaderHora = linha2.CreateCell(1);

                // CONTAGEM
                var celula02HeaderContagem = linha0.CreateCell(2);
                var celula03HeaderContagem = linha0.CreateCell(3);
                var celula04HeaderContagem = linha0.CreateCell(4);
                var celula05HeaderContagem = linha0.CreateCell(5);

                // SENTIDO 1
                var celula12HeaderSentido = linha1.CreateCell(2);
                var celula13HeaderSentido = linha1.CreateCell(3);

                // Auto - Sentido 1
                var celula22HeaderSentido = linha2.CreateCell(2);

                // Com - Sentido 1
                var celula23HeaderSentido = linha2.CreateCell(3);

                // SENTIDO 2
                var celula14HeaderSentido = linha1.CreateCell(4);
                var celula15HeaderSentido = linha1.CreateCell(5);

                // Auto - Sentido 2
                var celula24HeaderSentido = linha2.CreateCell(4);

                // Com - Sentido 2
                var celula25HeaderSentido = linha2.CreateCell(5);

                celula00HeaderDia.CellStyle = cellStyle;
                celula10HeaderDia.CellStyle = cellStyle;
                celula20HeaderDia.CellStyle = cellStyle;
                celula01HeaderHora.CellStyle = cellStyle;
                celula11HeaderHora.CellStyle = cellStyle;
                celula21HeaderHora.CellStyle = cellStyle;
                celula02HeaderContagem.CellStyle = cellStyle;
                celula03HeaderContagem.CellStyle = cellStyle;
                celula04HeaderContagem.CellStyle = cellStyle;
                celula05HeaderContagem.CellStyle = cellStyle;
                celula12HeaderSentido.CellStyle = cellStyle;
                celula13HeaderSentido.CellStyle = cellStyle;
                celula14HeaderSentido.CellStyle = cellStyle;
                celula15HeaderSentido.CellStyle = cellStyle;
                celula22HeaderSentido.CellStyle = cellStyle;
                celula23HeaderSentido.CellStyle = cellStyle;
                celula24HeaderSentido.CellStyle = cellStyle;
                celula25HeaderSentido.CellStyle = cellStyle;

                celula00HeaderDia.SetCellValue("DIA");
                celula00HeaderDia.SetCellType(CellType.String);

                celula01HeaderHora.SetCellValue("HORA");
                celula01HeaderHora.SetCellType(CellType.String);

                celula02HeaderContagem.SetCellValue("CONTAGEM");
                celula02HeaderContagem.SetCellType(CellType.String);

                celula12HeaderSentido.SetCellValue("Leste");
                celula12HeaderSentido.SetCellType(CellType.String);

                celula14HeaderSentido.SetCellValue("Oeste");
                celula14HeaderSentido.SetCellType(CellType.String);

                celula22HeaderSentido.SetCellValue("AUTO");
                celula22HeaderSentido.SetCellType(CellType.String);

                celula23HeaderSentido.SetCellValue("COM");
                celula23HeaderSentido.SetCellType(CellType.String);

                celula24HeaderSentido.SetCellValue("AUTO");
                celula24HeaderSentido.SetCellType(CellType.String);

                celula25HeaderSentido.SetCellValue("COM");
                celula25HeaderSentido.SetCellType(CellType.String);

                // Mesclar células - A1:A3 - DIA
                sheet.AddMergedRegion(new CellRangeAddress(0, 2, 0, 0));

                // Mescla células - B1:B3 - HORA
                sheet.AddMergedRegion(new CellRangeAddress(0, 2, 1, 1));

                // Mescla células - C1:D1 - CONTAGEM
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 2, 5));

                // Mescla células - C2:D2 - SENTIDO 1
                sheet.AddMergedRegion(new CellRangeAddress(1, 1, 2, 3));

                // Mescla células - E2:F2 - SENTIDO 1
                sheet.AddMergedRegion(new CellRangeAddress(1, 1, 4, 5));

                IRow rowLoop;
                ICell cellLoop;

                for (int i = 3; i < 10; i++)
                {
                    rowLoop = sheet.CreateRow(i);

                    for (int j = 0; j < 6; j++)
                    {
                        cellLoop = rowLoop.CreateCell(j);
                        cellLoop.CellStyle = cellStyle2;

                        if (j == 0)
                        {
                            cellLoop.SetCellValue(DateTime.Now.ToString("dd/MM/yyyy"));
                            cellLoop.SetCellType(CellType.String);

                        }
                        else if (j == 1)
                        {
                            cellLoop.SetCellValue($"{DateTime.Now.ToString("HH:mm")} - {DateTime.Now.AddMinutes(i).ToString("HH:mm")}");
                            cellLoop.SetCellType(CellType.String);
                        }
                        else
                        {
                            cellLoop.SetCellValue(100 * j);
                            cellLoop.SetCellType(CellType.Numeric);
                        }
                    }
                }


                workbook.Write(fs);
            }

            using (var stream = new FileStream(local, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;

            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}