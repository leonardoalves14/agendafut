using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private ICell CreateCell(IRow row, int cellIndex, string cellValue, ICellStyle style)
        {
            ICell cell = row.CreateCell(cellIndex);
            cell.SetCellValue(cellValue);
            cell.SetCellType(CellType.String);
            cell.CellStyle = style;

            return cell;
        }

        private ICell CreateCell(IRow row, int cellIndex, double cellValue, ICellStyle style)
        {
            ICell cell = row.CreateCell(cellIndex);
            cell.SetCellValue(cellValue);
            cell.SetCellType(CellType.Numeric);
            cell.CellStyle = style;

            return cell;
        }

        private void CreateDiaCell(int i, int j, int k, IRow row, ICellStyle cellStyle)
        {
            if (i == 0)
            {
                if (j == 0 && k == 0)
                {
                    CreateCell(row, k, "DIA", cellStyle);
                }
                else if ((j == 1 && k == 0) || (j == 2 && k == 0))
                {
                    CreateCell(row, k, "", cellStyle);
                }
            }
        }

        private void CreateHoraCell(int i, int j, int k, IRow row, ICellStyle cellStyle)
        {
            if (i == 0)
            {
                if (j == 0 && k == 1)
                {
                    CreateCell(row, k, "HORA", cellStyle);
                }
                else if ((j == 1 && k == 1) || (j == 2 && k == 1))
                {
                    CreateCell(row, k, "", cellStyle);
                }
            }
        }

        private void CreateContagemCell(int qtdSentido, int i, int j, int k, IRow row, ICellStyle cellStyle)
        {
            if (i == 0)
            {
                if (j == 0 && k == 2)
                    CreateCell(row, k, "CONTAGEM", cellStyle);

                if (qtdSentido == 1)
                {
                    if (j == 0 && k == 3)
                        CreateCell(row, k, "", cellStyle);
                }
                else
                {
                    if (j == 0 && k >= 3 && k <= 5)
                        CreateCell(row, k, "", cellStyle);
                }
            }
        }

        private void CreateVelocidadeSentidoCell(int qtdSentido, int i, int j, int k, IRow row, ICellStyle cellStyle)
        {
            if (i == 0)
            {
                if (qtdSentido > 1)
                {
                    if (j == 0 && k == 6)
                    {
                        CreateCell(row, k, "VELOCIDADE SENTIDO", cellStyle);
                    }
                    else if (j == 0 && k >= 7 && k <= 11)
                    {
                        CreateCell(row, k, "", cellStyle);
                    }
                }
                else
                {
                    if (j == 0 && k == 4)
                    {
                        CreateCell(row, k, "VELOCIDADE SENTIDO", cellStyle);
                    }
                    else if (j == 0 && k >= 5 && k <= 6)
                    {
                        CreateCell(row, k, "", cellStyle);
                    }
                }
            }
        }

        private void CreateSentidosCell(Dictionary<int, string> sentidos, int i, int j, int k, IRow row, ICellStyle cellStyle)
        {
            string sentidoDesc;

            // se for o primeiro sentido
            if (i == 0)
            {
                sentidoDesc = sentidos.FirstOrDefault(x => x.Key == (i + 1)).Value;

                if (j == 1)
                {
                    if (k == 2)
                        CreateCell(row, k, sentidoDesc, cellStyle);
                    else if (k == 3)
                        CreateCell(row, k, "", cellStyle);

                    if (sentidos.Count > 1)
                    {
                        if (k == 6)
                            CreateCell(row, k, sentidoDesc, cellStyle);
                        else if (k >= 7 && k <= 8)
                            CreateCell(row, k, "", cellStyle);
                    }
                    else
                    {
                        if (k == 4)
                        {
                            CreateCell(row, k, sentidoDesc, cellStyle);
                        }
                        else if (k >= 5 && k <= 6)
                        {
                            CreateCell(row, k, "", cellStyle);
                        }
                    }
                }
            }
            else if (i == 1)
            {
                sentidoDesc = sentidos.FirstOrDefault(x => x.Key == (i + 1)).Value;

                if (j == 1)
                {
                    if (k == 4)
                        CreateCell(row, k, sentidoDesc, cellStyle);
                    else if (k == 5)
                        CreateCell(row, k, "", cellStyle);

                    if (k == 9)
                        CreateCell(row, k, sentidoDesc, cellStyle);
                    else if (k >= 10 && k <= 11)
                        CreateCell(row, k, "", cellStyle);
                }
            }
        }

        public async Task<IActionResult> ExportFile()
        {
            string webRootFolder = _env.WebRootPath;
            string fileName = "test_vini.xls";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);
            string local = Path.Combine(webRootFolder, fileName);
            FileInfo file = new FileInfo(local);

            var sentidos = new Dictionary<int, string>
            {
                { 1, "Norte" },
                { 2, "Sul" }
            };

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
                cellStyle.BorderTop = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
                cellStyle.WrapText = true;

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

                IRow currentRow;

                // Percorro os sentidos
                for (int i = 0; i < sentidos.Count; i++)
                {
                    // Percorre as linhas
                    for (int j = 0; j < 3; j++)
                    {
                        currentRow = sheet.GetRow(j);

                        // Porcorre as células
                        for (int k = 0; k < 12; k++)
                        {
                            CreateDiaCell(i, j, k, currentRow, cellStyle);
                            CreateHoraCell(i, j, k, currentRow, cellStyle);
                            CreateContagemCell(sentidos.Count, i, j, k, currentRow, cellStyle);
                            CreateVelocidadeSentidoCell(sentidos.Count, i, j, k, currentRow, cellStyle);
                            CreateSentidosCell(sentidos, i, j, k, currentRow, cellStyle);
                        }
                    }
                }

                // Mesclagem de células
                // A1:A3 - DIA
                sheet.AddMergedRegion(new CellRangeAddress(0, 2, 0, 0));

                // B1:B3 - HORA
                sheet.AddMergedRegion(new CellRangeAddress(0, 2, 1, 1));

                // C2:D2 - SENTIDO 1 - CONTAGEM
                sheet.AddMergedRegion(new CellRangeAddress(1, 1, 2, 3));

                if (sentidos.Count == 1)
                {
                    // C1:D1 - CONTAGEM
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 2, 3));

                    // E1:G1 - VELOCIDADE SENTIDO
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 4, 6));

                    // E2:G2 - SENTIDO 1 - VELOCIDADE SENTIDO
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 4, 6));
                }
                else
                {
                    // C1:F1 - CONTAGEM
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 2, 5));

                    // G1:L1 - VELOCIDADE SENTIDO
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 6, 11));

                    // E2:F2 - SENTIDO 2 - CONTAGEM
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 4, 5));

                    // G2:I2 - SENTIDO 1 - VELOCIDADE SENTIDO
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 6, 8));

                    // E2:F2 - SENTIDO 2 - VELOCIDADE SENTIDO
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, 9, 11));
                }

                // Auto - Sentido 1
                CreateCell(linha2, 2, "AUTO", cellStyle);

                // Com - Sentido 1
                CreateCell(linha2, 3, "COM", cellStyle);

                // Auto - Sentido 2
                CreateCell(linha2, 4, "AUTO", cellStyle);

                // Com - Sentido 2
                CreateCell(linha2, 5, "COM", cellStyle);


                IRow rowLoop;

                for (int i = 3; i < 10; i++)
                {
                    rowLoop = sheet.CreateRow(i);

                    for (int j = 0; j < 12; j++)
                    {
                        if (j == 0)
                            CreateCell(rowLoop, j, DateTime.Now.ToString("dd/MM/yyyy"), cellStyle2);
                        else if (j == 1)
                            CreateCell(rowLoop, j, $"{DateTime.Now.ToString("HH:mm")} - {DateTime.Now.AddMinutes(i).ToString("HH:mm")}", cellStyle2);
                        else
                            CreateCell(rowLoop, j, 100 * j, cellStyle2);
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