using NPOI.HPSF;
using NPOI.HSSF.Extractor;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace MISApi.Tools
{

    /// <summary>
    /// NPOI操作excel辅助类
    /// </summary>
    public static class NPOIHelper
    {
        #region 定义与初始化
        /// <summary>
        /// 
        /// </summary>
        public static IWorkbook _workbook;
        /// <summary>
        /// 
        /// </summary>
        public static ICellStyle _cellStyle;
        /// <summary>
        /// 
        /// </summary>
        public static OfficeVersion _officeVersion;
        /// <summary>
        /// 
        /// </summary>
        public enum OfficeVersion
        {
            /// <summary>
            /// 
            /// </summary>
            OFFICE_03,
            /// <summary>
            /// 
            /// </summary>
            OFFICE_07
        }
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum LinkType
        {
            /// <summary>
            /// 网址
            /// </summary>
            WEB_SITE,
            /// <summary>
            /// 文档
            /// </summary>
            DOCUMENT,
            /// <summary>
            /// 邮件
            /// </summary>
            MAIL,
            /// <summary>
            /// 内容
            /// </summary>
            CONTENT
        };
        /// <summary>
        /// 
        /// </summary>
        private static IWorkbook CreateWorkbook()
        {
            if (_workbook == null)
            {
                if (_officeVersion == OfficeVersion.OFFICE_03)
                {
                    _workbook = new HSSFWorkbook();
                    InitializeHSSFWorkbook();
                }
                else
                {
                    _workbook = new XSSFWorkbook();
                    InitializeXSSFWorkbook();
                }
            }
            return _workbook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        private static IWorkbook CreateWorkbook(Stream inputStream)
        {
            if (_officeVersion == OfficeVersion.OFFICE_03)
            {
                inputStream.Position = 0;
                _workbook = new HSSFWorkbook(inputStream);
                InitializeHSSFWorkbook();
            }
            else
            {
                inputStream.Position = 0;
                _workbook = new XSSFWorkbook(inputStream);
                InitializeXSSFWorkbook();
            }
            return _workbook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static IWorkbook CreateWorkbook(FileStream file)
        {
            if (file.Name.IndexOf(".xlsx") > 0)
            {
                _workbook = new XSSFWorkbook(file);
                _officeVersion = OfficeVersion.OFFICE_07;
                InitializeXSSFWorkbook();
            }
            else if (file.Name.IndexOf(".xls") > 0)
            {
                _workbook = new HSSFWorkbook(file);
                _officeVersion = OfficeVersion.OFFICE_03;
                InitializeHSSFWorkbook();
            }
            return _workbook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static void InitializeHSSFWorkbook()
        {
            // DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "上海文竹网络科技有限公司";
            (_workbook as HSSFWorkbook).DocumentSummaryInformation = dsi;
            // SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "上海文竹网络科技有限公司";
            si.Title = "上海文竹网络科技有限公司";
            si.Author = "上海文竹网络科技有限公司";
            si.Comments = "感谢您的使用！";
            (_workbook as HSSFWorkbook).SummaryInformation = si;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static void InitializeXSSFWorkbook()
        {

        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        static NPOIHelper()
        {
            if (_workbook == null)
            {
                _workbook = CreateWorkbook();
            }
            if (_cellStyle == null)
            {
                _cellStyle = _workbook.CreateCellStyle();
            }
        }
        #endregion

        #region 转换
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="ms"></param>
        public static void WriteSteamToFile(string fileUrl, MemoryStream ms)
        {
            RMSHelper.CreateFile(fileUrl, Encoding.GetEncoding("ISO-8859-1").GetBytes(Encoding.GetEncoding("ISO-8859-1").GetString(ms.ToArray())));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="buffer"></param>
        public static void WriteSteamToFile(string fileUrl, byte[] buffer)
        {
            RMSHelper.CreateFile(fileUrl, buffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputWorkBook"></param>
        /// <returns></returns>
        public static Stream WorkBookToStream(HSSFWorkbook inputWorkBook)
        {
            MemoryStream ms = new MemoryStream();
            inputWorkBook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static HSSFWorkbook StreamToWorkBook(Stream inputStream)
        {
            HSSFWorkbook WorkBook = new HSSFWorkbook(inputStream);
            return WorkBook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static HSSFWorkbook MemoryStreamToWorkBook(MemoryStream inputStream)
        {
            HSSFWorkbook WorkBook = new HSSFWorkbook(inputStream as Stream);
            return WorkBook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static MemoryStream WorkBookToMemoryStream(HSSFWorkbook inputStream)
        {
            //Write the stream data of _workbook to the root directory
            MemoryStream file = new MemoryStream();
            inputStream.Write(file);
            return file;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Stream FileToStream(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists == true)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                return fs;
            }
            else return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public static Stream MemoryStreamToStream(MemoryStream ms)
        {
            return ms as Stream;
        }
        #endregion

        #region DataTable与Excel资料格式转换
        /// <summary>
        /// 将DataTable转成Stream输出.
        /// </summary>
        /// <param name="sourceTable">The source table.</param>
        /// <returns></returns>
        public static Stream RenderDataTableToExcel(DataTable sourceTable)
        {
            MemoryStream ms = new MemoryStream();
            ISheet sheet = _workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);
            // 处理标题
            foreach (DataColumn column in sourceTable.Columns)
            {
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }
            // 处理CONTENT
            int rowIndex = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }
            // 写入
            _workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            // 释放
            sheet = null;
            headerRow = null;
            _workbook = null;
            // 返回
            return ms;
        }

        /// <summary>
        /// 将DataTable转成Workbook(自定资料型态)输出.
        /// </summary>
        /// <param name="sourceTable">The source table.</param>
        /// <returns></returns>
        public static IWorkbook RenderDataTableToWorkBook(DataTable sourceTable)
        {
            MemoryStream ms = new MemoryStream();
            ISheet sheet = _workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);
            // 处理标题
            foreach (DataColumn column in sourceTable.Columns)
            {
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }
            // 处理CONTENT
            int rowIndex = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }
            return _workbook;
        }

        /// <summary>
        /// 将DataTable资料输出成DOCUMENT。
        /// </summary>
        /// <param name="sourceTable">The source table.</param>
        /// <param name="fileName">文件保存路径</param>
        public static void RenderDataTableToExcel(DataTable sourceTable, string fileName)
        {
            MemoryStream ms = RenderDataTableToExcel(sourceTable) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }

        /// <summary>
        /// 从流读取资料到DataTable.
        /// </summary>
        /// <param name="excelFileStream">The excel file stream.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="haveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream excelFileStream, string sheetName, bool haveHeader)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheet(sheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (haveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (haveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            excelFileStream.Close();
            _workbook = null;
            sheet = null;
            return table;
        }


        /// <summary>
        /// 從位元流讀取資料到DataTable.
        /// </summary>
        /// <param name="excelFileStream">The excel file stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="haveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream excelFileStream, int sheetIndex, bool haveHeader)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheetAt(sheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (haveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (haveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            excelFileStream.Close();
            _workbook = null;
            sheet = null;
            return table;
        }
        #endregion

        #region List<T>与Excel资料格式转换
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <returns></returns>
        public static Stream RenderListToExcel<T>(List<T> sourceList)
        {
            MemoryStream ms = new MemoryStream();
            ISheet sheet = _workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            PropertyInfo[] properties = typeof(T).GetProperties();

            int columIndex = 0;
            foreach (PropertyInfo column in properties)
            {
                headerRow.CreateCell(columIndex).SetCellValue(column.Name);
                columIndex++;
            }

            int rowIndex = 1;
            foreach (T item in sourceList)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                columIndex = 0;

                foreach (PropertyInfo column in properties)
                {
                    dataRow.CreateCell(columIndex).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                    columIndex++;
                }
                rowIndex++;
            }

            _workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            _workbook = null;

            return ms;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static Stream RenderListToExcel<T>(List<T> sourceList, Dictionary<string, string> head)
        {

            MemoryStream ms = new MemoryStream();
            ISheet sheet = _workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            PropertyInfo[] properties = typeof(T).GetProperties();

            int columIndex = 0;
            foreach (PropertyInfo column in properties)
            {
                headerRow.CreateCell(columIndex).SetCellValue(head[column.Name] == null ? column.Name : head[column.Name].ToString());
                columIndex++;
            }

            int rowIndex = 1;
            foreach (T item in sourceList)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                columIndex = 0;

                foreach (PropertyInfo column in properties)
                {
                    dataRow.CreateCell(columIndex).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                    columIndex++;
                }
                rowIndex++;
            }

            _workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            _workbook = null;

            return ms;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <returns></returns>
        public static IWorkbook RenderListToWorkbook<T>(List<T> sourceList)
        {
            ISheet sheet = _workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            PropertyInfo[] properties = typeof(T).GetProperties();

            int columIndex = 0;
            foreach (PropertyInfo column in properties)
            {
                headerRow.CreateCell(columIndex).SetCellValue(column.Name);
                columIndex++;
            }

            int rowIndex = 1;
            foreach (T item in sourceList)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                columIndex = 0;

                foreach (PropertyInfo column in properties)
                {
                    dataRow.CreateCell(columIndex).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                    columIndex++;
                }
                rowIndex++;
            }

            return _workbook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static IWorkbook RenderListToWorkbook<T>(List<T> sourceList, Dictionary<string, string> head)
        {
            ISheet sheet = _workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            PropertyInfo[] properties = typeof(T).GetProperties();

            int columIndex = 0;
            foreach (PropertyInfo column in properties)
            {
                headerRow.CreateCell(columIndex).SetCellValue(head[column.Name] == null ? column.Name : head[column.Name].ToString());
                columIndex++;
            }

            int rowIndex = 1;
            foreach (T item in sourceList)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                columIndex = 0;

                foreach (PropertyInfo column in properties)
                {
                    dataRow.CreateCell(columIndex).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                    columIndex++;
                }
                rowIndex++;
            }

            return _workbook;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="fileName"></param>
        public static void RenderListToExcel<T>(List<T> sourceList, string fileName)
        {
            MemoryStream ms = RenderListToExcel(sourceList) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <param name="head"></param>
        /// <param name="fileName"></param>
        public static void RenderListToExcel<T>(List<T> sourceList, Dictionary<string, string> head, string fileName)
        {
            MemoryStream ms = RenderListToExcel(sourceList, head) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelFileStream"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static List<T> RenderListFromExcel<T>(Stream excelFileStream, string sheetName)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheet(sheetName);
            IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
            int cellCount = headerRow.LastCellNum;

            List<T> list = new List<T>();

            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach (PropertyInfo column in properties)
                {
                    int j = headerRow.Cells.FindIndex(delegate (ICell c)
                    {
                        return c.StringCellValue == column.Name;
                    });

                    if (j >= 0 && row.GetCell(j) != null)
                    {
                        object value = ToType(column.PropertyType, row.GetCell(j).ToString());
                        column.SetValue(t, value, null);
                    }
                }

                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelFileStream"></param>
        /// <param name="sheetIndex"></param>
        /// <returns></returns>
        public static List<T> RenderListFromExcel<T>(Stream excelFileStream, int sheetIndex)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheetAt(sheetIndex);
            IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
            int cellCount = headerRow.LastCellNum;

            List<T> list = new List<T>();

            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach (PropertyInfo column in properties)
                {
                    int j = headerRow.Cells.FindIndex(delegate (ICell c)
                    {
                        return c.StringCellValue == column.Name;
                    });

                    if (j >= 0 && row.GetCell(j) != null)
                    {
                        object value = ToType(column.PropertyType, row.GetCell(j).ToString());
                        column.SetValue(t, value, null);
                    }
                }

                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelFileStream"></param>
        /// <param name="sheetName"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static List<T> RenderListFromExcel<T>(Stream excelFileStream, string sheetName, Dictionary<string, string> head)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheet(sheetName);
            IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
            int cellCount = headerRow.LastCellNum;

            List<T> list = new List<T>();

            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach (PropertyInfo column in properties)
                {
                    int j = headerRow.Cells.FindIndex(delegate (ICell c)
                    {
                        return c.StringCellValue == (head[column.Name] == null ? column.Name : head[column.Name].ToString());
                    });

                    if (j >= 0 && row.GetCell(j) != null)
                    {
                        object value = ToType(column.PropertyType, row.GetCell(j).ToString());
                        column.SetValue(t, value, null);
                    }
                }

                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelFileStream"></param>
        /// <param name="sheetIndex"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static List<T> RenderListFromExcel<T>(Stream excelFileStream, int sheetIndex, Dictionary<string, string> head)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheetAt(sheetIndex);
            IRow headerRow = sheet.GetRow(sheet.FirstRowNum);
            int cellCount = headerRow.LastCellNum;

            List<T> list = new List<T>();

            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach (PropertyInfo column in properties)
                {
                    int j = headerRow.Cells.FindIndex(delegate (ICell c)
                    {
                        return c.StringCellValue == (head[column.Name] == null ? column.Name : head[column.Name].ToString());
                    });

                    if (j >= 0 && row.GetCell(j) != null)
                    {
                        object value = ToType(column.PropertyType, row.GetCell(j).ToString());
                        column.SetValue(t, value, null);
                    }
                }

                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToType(Type type, string value)
        {
            if (type == typeof(string))
            {
                return value;
            }

            MethodInfo parseMethod = null;

            foreach (MethodInfo mi in type.GetMethods(BindingFlags.Static
                | BindingFlags.Public))
            {
                if (mi.Name == "Parse" && mi.GetParameters().Length == 1)
                {
                    parseMethod = mi;
                    break;
                }
            }

            if (parseMethod == null)
            {
                throw new ArgumentException(string.Format(
                    "Type: {0} has not Parse static method!", type));
            }

            return parseMethod.Invoke(null, new object[] { value });
        }
        #endregion

        #region 字符串阵列与Excel资料格式转换
        /// <summary>
        /// 建立datatable
        /// </summary>
        /// <param name="ColumnName">欄位名用逗號分隔</param>
        /// <param name="value">data陣列 , rowmajor</param>
        /// <returns>DataTable</returns>
        public static DataTable CreateDataTable(string ColumnName, string[,] value)
        {
            /*  輸入範例
            string cname = " name , sex ";
            string[,] aaz = new string[4, 2];
            for (int q = 0; q < 4; q++)
                for (int r = 0; r < 2; r++)
                    aaz[q, r] = "1";
            dataGridView1.DataSource = NewMediaTest1.Model.Utility.DataSetUtil.CreateDataTable(cname, aaz);
            */
            int i, j;
            DataTable ResultTable = new DataTable();
            string[] sep = new string[] { "," };

            string[] TempColName = ColumnName.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            DataColumn[] CName = new DataColumn[TempColName.Length];
            for (i = 0; i < TempColName.Length; i++)
            {
                DataColumn c1 = new DataColumn(TempColName[i].ToString().Trim(), typeof(object));
                ResultTable.Columns.Add(c1);
            }
            if (value != null)
            {
                for (i = 0; i < value.GetLength(0); i++)
                {
                    DataRow newrow = ResultTable.NewRow();
                    for (j = 0; j < TempColName.Length; j++)
                    {
                        newrow[j] = string.Copy(value[i, j].ToString());

                    }
                    ResultTable.Rows.Add(newrow);
                }
            }
            return ResultTable;
        }
        /// <summary>
        /// Creates the string array.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string[,] CreateStringArray(DataTable dt)
        {
            int ColumnNum = dt.Columns.Count;
            int RowNum = dt.Rows.Count;
            string[,] result = new string[RowNum, ColumnNum];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    result[i, j] = string.Copy(dt.Rows[i][j].ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// 將陣列輸出成位元流.
        /// </summary>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="sourceTable">The source table.</param>
        /// <returns></returns>
        public static Stream RenderArrayToExcel(string ColumnName, string[,] sourceTable)
        {
            DataTable dt = CreateDataTable(ColumnName, sourceTable);
            return RenderDataTableToExcel(dt);
        }
        /// <summary>
        /// 將陣列輸出成DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="sourceTable">The source table.</param>
        public static void RenderArrayToExcel(string fileName, string ColumnName, string[,] sourceTable)
        {
            DataTable dt = CreateDataTable(ColumnName, sourceTable);
            RenderDataTableToExcel(dt, fileName);
        }
        /// <summary>
        /// 將陣列輸出成WorkBook(自訂資料型態).
        /// </summary>
        /// <param name="ColumnName">Name of the column.</param>
        /// <param name="sourceTable">The source table.</param>
        /// <returns></returns>
        public static IWorkbook RenderArrayToWorkBook(string ColumnName, string[,] sourceTable)
        {
            DataTable dt = CreateDataTable(ColumnName, sourceTable);
            return RenderDataTableToWorkBook(dt);
        }
        /// <summary>
        /// 將位元流資料輸出成陣列.
        /// </summary>
        /// <param name="excelFileStream">The excel file stream.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="HeaderrowIndex">Index of the header row.</param>
        /// <param name="haveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static string[,] RenderArrayFromExcel(Stream excelFileStream, string sheetName, int HeaderrowIndex, bool haveHeader)
        {
            _workbook = CreateWorkbook(excelFileStream);

            ISheet sheet = _workbook.GetSheet(sheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderrowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (haveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            excelFileStream.Close();
            _workbook = null;
            sheet = null;
            return CreateStringArray(table);
        }
        /// <summary>
        /// 將位元流資料輸出成陣列.
        /// </summary>
        /// <param name="excelFileStream">The excel file stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="HeaderrowIndex">Index of the header row.</param>
        /// <param name="haveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static string[,] RenderArrayFromExcel(Stream excelFileStream, int sheetIndex, int HeaderrowIndex, bool haveHeader)
        {
            _workbook = CreateWorkbook(excelFileStream);
            ISheet sheet = _workbook.GetSheetAt(sheetIndex);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderrowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (haveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            excelFileStream.Close();
            _workbook = null;
            sheet = null;
            return CreateStringArray(table);
        }
        #endregion

        #region 超链接
        /// <summary>
        /// 在位元流储存格中建立超連結.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="linkName">Name of the link.</param>
        /// <param name="linkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cellIndex">Index of the cell.</param>
        /// <returns></returns>
        public static Stream MakeLink(Stream inputStream, string sheetNameOrIndex, string linkName, string linkValueOrIndex, LinkType s1, int rowIndex, int cellIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ICellStyle hlink_style = _workbook.CreateCellStyle();
            IFont hlink_font = _workbook.CreateFont();
            hlink_font.Underline = FontUnderlineType.Single;
            hlink_font.Color = IndexedColors.Blue.Index;
            hlink_style.SetFont(hlink_font);
            string resultLinkValue = string.Empty;
            int ResultSheet;
            ISheet sheet;
            if (int.TryParse(sheetNameOrIndex, out ResultSheet) == true)
                sheet = _workbook.GetSheetAt(ResultSheet);
            else
                sheet = _workbook.GetSheet(sheetNameOrIndex);
            ICell cell = sheet.CreateRow(rowIndex).CreateCell(cellIndex);
            cell.SetCellValue(linkName);
            HSSFHyperlink link;
            switch (s1.ToString())
            {
                case "WEB_SITE":
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    resultLinkValue = string.Copy(linkValueOrIndex);
                    break;
                case "DOCUMENT":
                    link = new HSSFHyperlink(HyperlinkType.File);
                    resultLinkValue = string.Copy(linkValueOrIndex);
                    break;
                case "MAIL":
                    link = new HSSFHyperlink(HyperlinkType.Email);
                    resultLinkValue = "mailto:" + linkValueOrIndex;
                    break;
                case "CONTENT":
                    int result;
                    link = new HSSFHyperlink(HyperlinkType.Document);
                    if (int.TryParse(linkValueOrIndex, out result) == true)
                        resultLinkValue = "'" + _workbook.GetSheetName(result) + "'!A1";
                    else
                        resultLinkValue = "'" + linkValueOrIndex + "'!A1";
                    break;
                default:
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    break;
            }
            link.Address = (resultLinkValue);
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 在DOCUMENT储存格中建立超連結.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="linkName">Name of the link.</param>
        /// <param name="linkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cellIndex">Index of the cell.</param>
        public static void MakeLink(string fileName, Stream inputStream, string sheetNameOrIndex, string linkName, string linkValueOrIndex, LinkType s1, int rowIndex, int cellIndex)
        {
            MemoryStream ms = MakeLink(inputStream, sheetNameOrIndex, linkName, linkValueOrIndex, s1, rowIndex, cellIndex) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 建立新位元流并在储存格中建立超連結.
        /// </summary>
        /// <param name="sheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="linkName">Name of the link.</param>
        /// <param name="linkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cellIndex">Index of the cell.</param>
        /// <returns></returns>
        public static Stream MakeLinkFromEmpty(string sheetNameOrIndex, string linkName, string linkValueOrIndex, LinkType s1, int rowIndex, int cellIndex)
        {
            ISheet sheet1 = _workbook.CreateSheet();

            MemoryStream ms = new MemoryStream();
            ICellStyle hlink_style = _workbook.CreateCellStyle();
            IFont hlink_font = _workbook.CreateFont();
            hlink_font.Underline = FontUnderlineType.Single;
            hlink_font.Color = IndexedColors.Blue.Index;
            hlink_style.SetFont(hlink_font);
            string resultLinkValue = string.Empty;
            int ResultSheet;
            ISheet sheet;
            if (int.TryParse(sheetNameOrIndex, out ResultSheet) == true)
                sheet = _workbook.GetSheetAt(ResultSheet);
            else
                sheet = _workbook.GetSheet(sheetNameOrIndex);
            ICell cell = sheet.CreateRow(rowIndex).CreateCell(cellIndex);
            cell.SetCellValue(linkName);
            HSSFHyperlink link;
            switch (s1.ToString())
            {
                case "WEB_SITE":
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    resultLinkValue = string.Copy(linkValueOrIndex);
                    break;
                case "DOCUMENT":
                    link = new HSSFHyperlink(HyperlinkType.File);
                    resultLinkValue = string.Copy(linkValueOrIndex);
                    break;
                case "MAIL":
                    link = new HSSFHyperlink(HyperlinkType.Email);
                    // resultLinkValue = string.Copy(LinkValue);   
                    resultLinkValue = "mailto:" + linkValueOrIndex;
                    break;
                case "CONTENT":
                    int result;
                    link = new HSSFHyperlink(HyperlinkType.Document);
                    if (int.TryParse(linkValueOrIndex, out result) == true)
                        resultLinkValue = "'" + _workbook.GetSheetName(result) + "'!A1";
                    else
                        resultLinkValue = "'" + linkValueOrIndex + "'!A1";
                    break;
                default:
                    link = new HSSFHyperlink(HyperlinkType.Url);
                    break;
            }
            link.Address = (resultLinkValue);
            cell.Hyperlink = (link);
            cell.CellStyle = (hlink_style);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新DOCUMENT并在储存格中建立超連結.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetNameOrIndex">Index of the sheet name or.</param>
        /// <param name="linkName">Name of the link.</param>
        /// <param name="linkValueOrIndex">Index of the link value or.</param>
        /// <param name="s1">The s1.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cellIndex">Index of the cell.</param>
        public static void MakeLinkFromEmpty(string fileName, string sheetNameOrIndex, string linkName, string linkValueOrIndex, LinkType s1, int rowIndex, int cellIndex)
        {
            MemoryStream ms = MakeLinkFromEmpty(sheetNameOrIndex, linkName, linkValueOrIndex, s1, rowIndex, cellIndex) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 设定默认Cell样式
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICellStyle SetCellDefaultStyle()
        {
            // 定义一个ICellStyle
            ICellStyle style = _workbook.GetCellStyleAt(0);
            // 使用Clone方法避免_workbook.CreateCellStyle 的4000次数量限制
            style.CloneStyleFrom(_cellStyle);
            // 字体
            IFont font = _workbook.GetFontAt(0);
            font.FontName = "微软雅黑";
            font.Color = 0;
            font.IsBold = false;
            font.Boldweight = 400;
            font.IsItalic = false;
            style.SetFont(font);
            // 边框  
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            if (_officeVersion == OfficeVersion.OFFICE_03)
            {
                style.TopBorderColor = HSSFColor.Black.Index;
                style.LeftBorderColor = HSSFColor.Black.Index;
                style.BottomBorderColor = HSSFColor.Black.Index;
                style.RightBorderColor = HSSFColor.Black.Index;
            }
            else
            {
                style.TopBorderColor = (short)new XSSFColor(Color.Black).Tint;
                style.LeftBorderColor = (short)new XSSFColor(Color.Black).Tint;
                style.BottomBorderColor = (short)new XSSFColor(Color.Black).Tint;
                style.RightBorderColor = (short)new XSSFColor(Color.Black).Tint;
            }
            return style;
        }
        #endregion

        #region 设定单元格

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colorIndex">例:NPOI.HSSF.Util.HSSFColor.Red.Index</param>
        /// <param name="isBorder"></param>
        /// <param name="cellStyleIndex"></param>
        /// <returns></returns>
        public static ICellStyle SetCellStyle(short colorIndex, bool isBorder = false, short cellStyleIndex = 0)
        {
            // 定义一个ICellStyle
            ICellStyle style = _workbook.GetCellStyleAt(cellStyleIndex);
            // 使用Clone方法避免_workbook.CreateCellStyle 的4000次数量限制
            style.CloneStyleFrom(_cellStyle);
            style.FillForegroundColor = colorIndex;
            style.FillPattern = FillPattern.SolidForeground;
            if (isBorder)
            {
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;

                if (_officeVersion == OfficeVersion.OFFICE_03)
                {
                    style.TopBorderColor = HSSFColor.Black.Index;
                    style.LeftBorderColor = HSSFColor.Black.Index;
                    style.BottomBorderColor = HSSFColor.Black.Index;
                    style.RightBorderColor = HSSFColor.Black.Index;
                }
                else
                {
                    style.TopBorderColor = (short)new XSSFColor(Color.Black).Tint;
                    style.LeftBorderColor = (short)new XSSFColor(Color.Black).Tint;
                    style.BottomBorderColor = (short)new XSSFColor(Color.Black).Tint;
                    style.RightBorderColor = (short)new XSSFColor(Color.Black).Tint;
                }

                IFont font = _workbook.GetFontAt(cellStyleIndex);
                font.Color = colorIndex == (short)12 ? (short)12 : (short)0;
                style.SetFont(font);
            }
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            return style;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontName"></param>
        /// <param name="color"></param>
        /// <param name="isBold"></param>
        /// <param name="boldWeight"></param>
        /// <param name="isItalic"></param>
        /// <returns></returns>
        public static ICellStyle SetCellStyle(string fontName, short color, bool isBold, short boldWeight, bool isItalic)
        {
            // 定义一个ICellStyle
            ICellStyle style = _workbook.GetCellStyleAt(0);
            // 使用Clone方法避免_workbook.CreateCellStyle 的4000次数量限制
            style.CloneStyleFrom(_cellStyle);
            IFont font = _workbook.GetFontAt(0);
            font.FontName = fontName;
            font.Color = color;
            font.IsBold = isBold;
            font.Boldweight = boldWeight;
            font.IsItalic = isItalic;
            style.SetFont(font);
            return style;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="borderTop"></param>
        /// <param name="borderRight"></param>
        /// <param name="borderBottom"></param>
        /// <param name="borderLeft"></param>
        /// <param name="topBorderColor"></param>
        /// <param name="rightBorderColor"></param>
        /// <param name="bottomBorderColor"></param>
        /// <param name="leftBorderColor"></param>
        /// <returns></returns>
        public static ICellStyle SetCellStyle(BorderStyle borderTop, BorderStyle borderRight, BorderStyle borderBottom, BorderStyle borderLeft, short topBorderColor, short rightBorderColor, short bottomBorderColor, short leftBorderColor)
        {
            // 定义一个ICellStyle
            ICellStyle style = _workbook.GetCellStyleAt(0);
            // 使用Clone方法避免_workbook.CreateCellStyle 的4000次数量限制
            style.CloneStyleFrom(_cellStyle);
            style.BorderTop = borderTop;
            style.BorderRight = borderRight;
            style.BorderBottom = borderBottom;
            style.BorderLeft = borderLeft;
            style.TopBorderColor = topBorderColor;
            style.LeftBorderColor = topBorderColor;
            style.BottomBorderColor = topBorderColor;
            style.RightBorderColor = topBorderColor;
            return style;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InputFont"></param>
        /// <returns></returns>
        public static ICellStyle SetCellStyle(IFont InputFont)
        {
            ICellStyle style1 = _workbook.CreateCellStyle();
            style1.SetFont(InputFont);
            return style1;
        }
        /// <summary>
        /// 设定字體顏色大小到位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="isAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public static Stream ApplyStyleToFile(Stream inputStream, string fontName, short fontSize, bool isAllSheet, params string[] sheetName)
        {
            _workbook = CreateWorkbook(inputStream);

            IFont font = _workbook.CreateFont();
            ICellStyle Style = _workbook.CreateCellStyle();
            font.FontHeightInPoints = fontSize;
            font.FontName = fontName;
            Style.SetFont(font);
            MemoryStream ms = new MemoryStream();
            int i;
            if (isAllSheet == true)
            {
                for (i = 0; i < _workbook.NumberOfSheets; i++)
                {
                    ISheet Sheets = _workbook.GetSheetAt(0);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        IRow row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            ICell Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            else
            {
                for (i = 0; i < sheetName.Length; i++)
                {
                    ISheet Sheets = _workbook.GetSheet(sheetName[i]);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        IRow row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            ICell Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 设定字體顏色大小到位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="isAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <returns></returns>
        public static Stream ApplyStyleToFile(Stream inputStream, string fontName, short fontSize, bool isAllSheet, params int[] sheetIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            IFont font = _workbook.CreateFont();
            ICellStyle Style = _workbook.CreateCellStyle();
            font.FontHeightInPoints = fontSize;
            font.FontName = fontName;
            Style.SetFont(font);
            int i;
            if (isAllSheet == true)
            {
                for (i = 0; i < _workbook.NumberOfSheets; i++)
                {
                    ISheet Sheets = _workbook.GetSheetAt(0);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        IRow row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            ICell Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            else
            {
                for (i = 0; i < sheetIndex.Length; i++)
                {
                    ISheet Sheets = _workbook.GetSheetAt(sheetIndex[i]);
                    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
                    {
                        IRow row = Sheets.GetRow(k);
                        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
                        {
                            ICell Cell = row.GetCell(l);
                            Cell.CellStyle = Style;
                        }
                    }
                }
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 设定字體顏色大小到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="isAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="sheetName">Name of the sheet.</param>
        public static void ApplyStyleToFile(string fileName, Stream inputStream, string fontName, short fontSize, bool isAllSheet, params string[] sheetName)
        {
            MemoryStream ms = ApplyStyleToFile(inputStream, fontName, fontSize, isAllSheet, sheetName) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 设定字體顏色大小到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="fontName">Name of the font.</param>
        /// <param name="fontSize">Size of the font.</param>
        /// <param name="isAllSheet">if set to <c>true</c> [is all sheet].</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        public static void ApplyStyleToFile(string fileName, Stream inputStream, string fontName, short fontSize, bool isAllSheet, params int[] sheetIndex)
        {
            MemoryStream ms = ApplyStyleToFile(inputStream, fontName, fontSize, isAllSheet, sheetIndex) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 建立空白excel档
        /// <summary>
        /// 建立空白excel档到位元流.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public static Stream CreateEmptyFile(params string[] sheetName)
        {
            MemoryStream ms = new MemoryStream();
            if (sheetName == null)
            {
                _workbook.CreateSheet();
            }
            else
            {
                foreach (string temp in sheetName)
                    _workbook.CreateSheet(temp);
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立空白excel档到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        public static void CreateEmptyFile(string fileName, params string[] sheetName)
        {
            MemoryStream ms = CreateEmptyFile(sheetName) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 设定格线
        /// <summary>
        /// 设定格线到位元流.
        /// </summary>
        /// <param name="inputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public static Stream SetGridLine(Stream inputSteam, bool haveGridLine, params string[] sheetName)
        {
            _workbook = new HSSFWorkbook(inputSteam);

            MemoryStream ms = new MemoryStream();
            if (sheetName == null)
            {
                for (int i = 0; i < _workbook.NumberOfSheets; i++)
                {
                    ISheet s1 = _workbook.GetSheetAt(i);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            else
            {
                foreach (string TempSheet in sheetName)
                {
                    ISheet s1 = _workbook.GetSheet(TempSheet);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 设定格线到位元流.
        /// </summary>
        /// <param name="inputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <returns></returns>
        public static Stream SetGridLine(Stream inputSteam, bool haveGridLine, params int[] sheetIndex)
        {
            _workbook = new HSSFWorkbook(inputSteam);

            MemoryStream ms = new MemoryStream();
            if (sheetIndex == null)
            {
                for (int i = 0; i < _workbook.NumberOfSheets; i++)
                {
                    ISheet s1 = _workbook.GetSheetAt(i);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            else
            {
                foreach (int TempSheet in sheetIndex)
                {
                    ISheet s1 = _workbook.GetSheetAt(TempSheet);
                    s1.DisplayGridlines = haveGridLine;
                }
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 设定格线到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        public static void SetGridLine(string fileName, Stream inputSteam, bool haveGridLine, params int[] sheetIndex)
        {
            MemoryStream ms = SetGridLine(inputSteam, haveGridLine, sheetIndex) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 设定格线到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputSteam">The input steam.</param>
        /// <param name="haveGridLine">if set to <c>true</c> [have grid line].</param>
        /// <param name="sheetName">Name of the sheet.</param>
        public static void SetGridLine(string fileName, Stream inputSteam, bool haveGridLine, params string[] sheetName)
        {
            MemoryStream ms = SetGridLine(inputSteam, haveGridLine, sheetName) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 读取字串從excel
        /// <summary>
        /// 從位元流將資料轉成字串輸出
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <returns></returns>
        public static string ExtractStringFromFileStream(Stream inputStream)
        {
            HSSFWorkbook HBook = new HSSFWorkbook(inputStream);
            ExcelExtractor extractor = new ExcelExtractor(HBook);
            return extractor.Text;
        }
        /// <summary>
        /// 從DOCUMENT將資料轉成字串輸出
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string ExtractStringFromFileStream(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists == true)
            {
                using (FileStream fs = fi.Open(FileMode.Open))
                {
                    HSSFWorkbook HBook = new HSSFWorkbook(fs);
                    ExcelExtractor extractor = new ExcelExtractor(HBook);
                    return extractor.Text;
                }
            }
            else return null;
        }
        #endregion

        #region 设定群組

        /// <summary>
        /// 设定群組到位元流.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="IsRow">if set to <c>true</c> [is row].</param>
        /// <param name="From">From.</param>
        /// <param name="End">The end.</param>
        /// <returns></returns>
        public static Stream CreateGroup(string sheetName, bool IsRow, int From, int End)
        {
            MemoryStream ms = new MemoryStream();

            ISheet sh = _workbook.CreateSheet(sheetName);
            for (int i = 0; i <= End; i++)
            {
                sh.CreateRow(i);
            }
            if (IsRow == true)
                sh.GroupRow(From, End);
            else
                sh.GroupColumn((short)From, (short)End);

            _workbook.Write(ms);
            ms.Flush();
            return ms;

        }
        /// <summary>
        /// 建立群組到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="IsRow">if set to <c>true</c> [is row].</param>
        /// <param name="From">From.</param>
        /// <param name="End">The end.</param>
        public static void CreateGroup(string fileName, string sheetName, bool IsRow, int From, int End)
        {
            MemoryStream ms = CreateGroup(sheetName, IsRow, From, End) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 从模板简历DOCUMENT

        /// <summary>
        /// 從樣板建立位元流.
        /// </summary>
        /// <param name="templateFileName">Name of the template file.</param>
        /// <returns></returns>
        public static Stream CreateFileStreamFromTemplate(string templateFileName)
        {
            FileInfo fi = new FileInfo(templateFileName);
            if (fi.Exists == true)
            {
                MemoryStream ms = new MemoryStream();
                FileStream file = new FileStream(templateFileName, FileMode.Open, FileAccess.Read);
                _workbook = CreateWorkbook(file);
                _workbook.Write(ms);
                ms.Flush();
                return ms;
            }
            else return null;
        }

        /// <summary>
        /// 從樣板建立DOCUMENT.
        /// </summary>
        /// <param name="templateFileName">Name of the template file.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public static void CreateFileFromTemplate(string templateFileName, string outputFileName)
        {
            FileInfo fi = new FileInfo(templateFileName);
            if (fi.Exists == true)
            {
                MemoryStream ms = CreateFileStreamFromTemplate(templateFileName) as MemoryStream;
                WriteSteamToFile(outputFileName, ms);
            }
            else
            {

            }
        }
        #endregion

        #region 嵌入图片
        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="wb">The wb.</param>
        /// <returns></returns>
        public static int LoadImage(string path, IWorkbook wb)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, (int)file.Length);
            return wb.AddPicture(buffer, PictureType.JPEG);

        }
        /// <summary>
        /// 嵌入图片到位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="picFileName">Name of the pic file.</param>
        /// <param name="isOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="rowPosition">The row position.</param>
        /// <returns></returns>
        public static Stream EmbedImage(Stream inputStream, int sheetIndex, string picFileName, bool isOriginalSize, int[] rowPosition)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            IDrawing patriarch = sheet1.CreateDrawingPatriarch();
            //create the anchor
            HSSFClientAnchor anchor;
            anchor = new HSSFClientAnchor(0, 0, 0, 0,
                rowPosition[0], rowPosition[1], rowPosition[2], rowPosition[3]);
            anchor.AnchorType = AnchorType.MoveDontResize;
            //load the picture and get the picture index in the _workbook
            IPicture picture = patriarch.CreatePicture(anchor, LoadImage(picFileName, _workbook));
            //Reset the image to the original size.
            if (isOriginalSize == true)
                picture.Resize();
            //Line Style
            //picture.LineStyle = LineStyle.None;
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 嵌入图片到DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="picFileName">Name of the pic file.</param>
        /// <param name="isOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="rowPosition">The row position.</param>
        public static void EmbedImage(string fileName, int sheetIndex, Stream inputStream, string picFileName, bool isOriginalSize, int[] rowPosition)
        {
            MemoryStream ms = EmbedImage(inputStream, sheetIndex, picFileName, isOriginalSize, rowPosition) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 建立新位元流并嵌入图片.
        /// </summary>
        /// <param name="picFileName">Name of the pic file.</param>
        /// <param name="isOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="rowPosition">The row position.</param>
        /// <returns></returns>
        public static Stream EmbedImage(string picFileName, bool isOriginalSize, int[] rowPosition)
        {
            _workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.CreateSheet();
            IDrawing patriarch = sheet1.CreateDrawingPatriarch();
            //create the anchor
            HSSFClientAnchor anchor;
            anchor = new HSSFClientAnchor(0, 0, 0, 0,
                rowPosition[0], rowPosition[1], rowPosition[2], rowPosition[3]);
            anchor.AnchorType = AnchorType.MoveDontResize;
            //load the picture and get the picture index in the _workbook
            IPicture picture = patriarch.CreatePicture(anchor, LoadImage(picFileName, _workbook));
            //Reset the image to the original size.
            if (isOriginalSize == true)
                picture.Resize();
            //Line Style
            //picture.LineStyle = LineStyle.None;
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新DOCUMENT并嵌入图片.
        /// </summary>
        /// <param name="excelfileName">Name of the excel file.</param>
        /// <param name="picFileName">Name of the pic file.</param>
        /// <param name="isOriginalSize">if set to <c>true</c> [is original size].</param>
        /// <param name="rowPosition">The row position.</param>
        public static void EmbedImage(string excelfileName, string picFileName, bool isOriginalSize, int[] rowPosition)
        {
            MemoryStream ms = EmbedImage(picFileName, isOriginalSize, rowPosition) as MemoryStream;
            WriteSteamToFile(excelfileName, ms);
        }
        #endregion

        #region 合并储存格
        /// <summary>
        /// 合并储存格于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="rowFrom">The row from.</param>
        /// <param name="columnFrom">The column from.</param>
        /// <param name="rowTo">The row to.</param>
        /// <param name="columnTo">The column to.</param>
        /// <returns></returns>
        public static Stream MergeCell(Stream inputStream, int sheetIndex, int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            sheet1.AddMergedRegion(new CellRangeAddress(rowFrom, rowTo, columnFrom, columnTo));
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 合并储存格于DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="rowFrom">The row from.</param>
        /// <param name="columnFrom">The column from.</param>
        /// <param name="rowTo">The row to.</param>
        /// <param name="columnTo">The column to.</param>
        public static void MergeCell(string fileName, Stream inputStream, int sheetIndex, int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            MemoryStream ms = MergeCell(inputStream, sheetIndex, rowFrom, columnFrom, rowTo, columnTo) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 建立新位元流并合并储存格.
        /// </summary>
        /// <param name="rowFrom">The row from.</param>
        /// <param name="columnFrom">The column from.</param>
        /// <param name="rowTo">The row to.</param>
        /// <param name="columnTo">The column to.</param>
        /// <returns></returns>
        public static Stream MergeCell(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            _workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.CreateSheet();
            sheet1.AddMergedRegion(new CellRangeAddress(rowFrom, rowTo, columnFrom, columnTo));
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新DOCUMENT并合并储存格.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="rowFrom">The row from.</param>
        /// <param name="columnFrom">The column from.</param>
        /// <param name="rowTo">The row to.</param>
        /// <param name="columnTo">The column to.</param>
        public static void MergeCell(string fileName, int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            MemoryStream ms = MergeCell(rowFrom, columnFrom, rowTo, columnTo) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 设定储存格公式
        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="formula">The formula.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream SetFormula(Stream inputStream, int sheetIndex, string formula, int rowIndex, int columnIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellFormula(formula);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 设定储存格公式于DOCUMENT.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="formula">The formula.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        public static void SetFormula(string fileName, Stream inputStream, int sheetIndex, string formula, int rowIndex, int columnIndex)
        {
            MemoryStream ms = SetFormula(inputStream, sheetIndex, formula, rowIndex, columnIndex) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        /// <summary>
        /// 建立新位元流并设定储存格公式.
        /// </summary>
        /// <param name="formula">The formula.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream Createformula(string formula, int rowIndex, int columnIndex)
        {
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.CreateSheet();
            sheet1.CreateRow(rowIndex).CreateCell(columnIndex).SetCellFormula(formula);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 建立新DOCUMENT并设定储存格公式.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="formula">The formula.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        public static void SetFormula(string fileName, string formula, int rowIndex, int columnIndex)
        {
            MemoryStream ms = Createformula(formula, rowIndex, columnIndex) as MemoryStream;
            WriteSteamToFile(fileName, ms);
        }
        #endregion

        #region 设定单元格

        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="cellValue">The cellValue.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream SetCellValue(Stream inputStream, int sheetIndex, object cellValue, int rowIndex, int columnIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            // Value
            if (cellValue == null)
            {
                sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue("");
            }
            else if (cellValue.GetType().ToString().Equals("System.Double"))
            {
                sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue((double)cellValue);
            }
            else if (cellValue.GetType().ToString().Equals("System.Decimal"))
            {
                sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue(double.Parse(cellValue.ToString()));
            }
            else if (cellValue.GetType().ToString().Equals("System.Int32"))
            {
                sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue((int)cellValue);
            }
            else if (cellValue.GetType().ToString().Equals("System.DateTime"))
            {
                sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue((DateTime)cellValue);
            }
            else
            {
                sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue(cellValue.ToString());
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }

        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="cellValue">The cellValue.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream SetCellValue(Stream inputStream, int sheetIndex, double cellValue, int rowIndex, int columnIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue(cellValue);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }

        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="cellValue">The cellValue.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        public static Stream SetCellValue(Stream inputStream, int sheetIndex, int cellValue, int rowIndex, int columnIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            sheet1.GetRow(rowIndex).GetCell(columnIndex).SetCellValue(cellValue);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="sheetIndex"></param>
        /// <param name="cellValue"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static Stream CreateCell(Stream inputStream, int sheetIndex, string cellValue, int rowIndex, int columnIndex)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            sheet1.CreateRow(rowIndex).CreateCell(columnIndex).SetCellValue(cellValue);
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }

        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="sourceIndex">Index of the row.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cells">Index of the column.</param>
        /// <returns></returns>
        public static Stream CreateRow(Stream inputStream, int sheetIndex, int sourceIndex, int rowIndex, params Cell[] cells)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            var row = sheet1.CopyRow(sourceIndex, rowIndex);
            //var row = sheet1.CreateRow(rowIndex);
            foreach (var cell in cells)
            {
                if (cell.Value == null)
                {
                    row.CreateCell(cell.Index).SetCellValue("");
                }
                else if (cell.Value.GetType().ToString().Equals("System.Double"))
                {
                    row.CreateCell(cell.Index).SetCellValue((double)cell.Value);
                }
                else if (cell.Value.GetType().ToString().Equals("System.Decimal"))
                {
                    row.CreateCell(cell.Index).SetCellValue(double.Parse(cell.Value.ToString()));
                }
                else if (cell.Value.GetType().ToString().Equals("System.Int32"))
                {
                    row.CreateCell(cell.Index).SetCellValue((int)cell.Value);
                }
                else if (cell.Value.GetType().ToString().Equals("System.DateTime"))
                {
                    row.CreateCell(cell.Index).SetCellValue((DateTime)cell.Value);
                }
                else
                {
                    row.CreateCell(cell.Index).SetCellValue(cell.Value.ToString());
                }
                if (!string.IsNullOrEmpty(cell.Formula))
                {
                    row.GetCell(cell.Index).SetCellFormula(cell.Formula);
                }
                //if (cell.ForegroundColor != HSSFColor.Automatic.Index)
                //{
                //    row.GetCell(cell.Index).CellStyle = SetCellStyle(cell.ForegroundColor);
                //}
            }
            SetRowStyle(row, sheet1.GetRow(sourceIndex));
            row.HeightInPoints = 15;
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }

        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="rowStyle">Index of the row.</param>
        /// <param name="cells">Index of the column.</param>
        /// <returns></returns>
        public static Stream CreateRow(Stream inputStream, int sheetIndex, RowStyle rowStyle, params Cell[] cells)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);

            var row = sheet1.CreateRow(rowStyle.Index);
            foreach (var cell in cells)
            {
                // Value
                if (cell.Value == null)
                {
                    row.CreateCell(cell.Index).SetCellValue("");
                }
                else if (cell.Value.GetType().ToString().Equals("System.Double"))
                {
                    row.CreateCell(cell.Index).SetCellValue((double)cell.Value);
                }
                else if (cell.Value.GetType().ToString().Equals("System.Decimal"))
                {
                    row.CreateCell(cell.Index).SetCellValue(double.Parse(cell.Value.ToString()));
                }
                else if (cell.Value.GetType().ToString().Equals("System.Int32"))
                {
                    row.CreateCell(cell.Index).SetCellValue((int)cell.Value);
                }
                else if (cell.Value.GetType().ToString().Equals("System.DateTime"))
                {
                    row.CreateCell(cell.Index).SetCellValue((DateTime)cell.Value);
                }
                else
                {
                    row.CreateCell(cell.Index).SetCellValue(cell.Value.ToString());
                }
                // formula
                if (!string.IsNullOrEmpty(cell.Formula))
                {
                    row.GetCell(cell.Index).SetCellFormula(cell.Formula);
                }
                // Style
                if (cell.IsStyle)
                {
                    row.GetCell(cell.Index).CellStyle = SetCellStyle(cell.ForegroundColor, cell.IsBorder, cell.CellStyleIndex);
                }
                row.HeightInPoints = rowStyle.Height;
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 设定储存格公式于位元流.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="sheetIndex">Index of the sheet.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cells">Index of the column.</param>
        /// <returns></returns>
        public static Stream CreateRow(Stream inputStream, int sheetIndex, int rowIndex, params Cell[] cells)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);

            var row = sheet1.CreateRow(rowIndex);
            foreach (var cell in cells)
            {
                // Value
                if (cell.Value == null)
                {
                    row.CreateCell(cell.Index).SetCellValue("");
                }
                else if (cell.Value.GetType().ToString().Equals("System.Double"))
                {
                    row.CreateCell(cell.Index).SetCellValue((double)cell.Value);
                }
                else if (cell.Value.GetType().ToString().Equals("System.Decimal"))
                {
                    row.CreateCell(cell.Index).SetCellValue(double.Parse(cell.Value.ToString()));
                }
                else if (cell.Value.GetType().ToString().Equals("System.Int32"))
                {
                    row.CreateCell(cell.Index).SetCellValue((int)cell.Value);
                }
                else if (cell.Value.GetType().ToString().Equals("System.DateTime"))
                {
                    row.CreateCell(cell.Index).SetCellValue((DateTime)cell.Value);
                }
                else
                {
                    row.CreateCell(cell.Index).SetCellValue(cell.Value.ToString());
                }
                // formula
                if (!string.IsNullOrEmpty(cell.Formula))
                {
                    row.GetCell(cell.Index).SetCellFormula(cell.Formula);
                }
                // Style
                if (cell.IsStyle)
                {
                    row.GetCell(cell.Index).CellStyle = SetCellStyle(cell.ForegroundColor, cell.IsBorder, cell.CellStyleIndex);
                }
            }
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="heightInPoints"></param>
        public static void SetRowDefaultStyle(IRow row, int heightInPoints)
        {
            row.HeightInPoints = heightInPoints;
            for (var i = 0; i < row.Cells.Count; i++)
            {
                row.Cells[i].CellStyle = SetCellDefaultStyle();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="heightInPoints"></param>
        public static void SetRowDefaultStyle(int sheetIndex, int rowIndex, int heightInPoints)
        {
            SetRowDefaultStyle(_workbook.GetSheetAt(sheetIndex).GetRow(rowIndex), heightInPoints);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="templateRow"></param>
        public static void SetRowStyle(int sheetIndex, int rowIndex, IRow templateRow)
        {
            SetRowStyle(_workbook.GetSheetAt(sheetIndex).GetRow(rowIndex), templateRow);
        }
        /// <summary>
        ///  复制指定行的样式
        /// </summary>
        /// <param name="row"></param>
        /// <param name="templateRow"></param>
        /// <returns></returns>
        public static void SetRowStyle(IRow row, IRow templateRow)
        {
            for (var i = 0; i < row.Cells.Count; i++)
            {
                row.Cells[i].CellStyle = templateRow.Cells[i].CellStyle;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public class Cell
        {
            /// <summary>
            /// 
            /// </summary>
            public int Index { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public object Value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Formula { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public short ForegroundColor { get; set; } = _officeVersion == OfficeVersion.OFFICE_03 ? HSSFColor.White.Index : (short)new XSSFColor(Color.White).Tint;
            /// <summary>
            /// 
            /// </summary>
            public bool IsBorder { get; set; } = false;
            /// <summary>
            /// 
            /// </summary>
            public bool IsStyle { get; set; } = false;
            /// <summary>
            /// 
            /// </summary>
            public short CellStyleIndex { get; set; } = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public class RowStyle
        {
            /// <summary>
            /// 
            /// </summary>
            public int Index { get; set; }
            /// <summary>
            /// /
            /// </summary>
            public float Height { get; set; }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="sheetIndex"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static Stream NumericCellValue(Stream inputStream, int sheetIndex, int rowIndex, int columnIndex, ref double result)
        {
            _workbook = CreateWorkbook(inputStream);
            ISheet sheet1 = _workbook.GetSheetAt(sheetIndex);
            result = sheet1.GetRow(rowIndex).GetCell(columnIndex).NumericCellValue;
            return inputStream;
        }
        #endregion

        #region 公式开关
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="sheetIndex"></param>
        /// <param name="forceFormulaRecalculation"></param>
        /// <returns></returns>
        public static Stream ForceFormulaRecalculation(Stream inputStream, int sheetIndex, bool forceFormulaRecalculation)
        {
            _workbook = CreateWorkbook(inputStream);
            MemoryStream ms = new MemoryStream();
            ISheet sheet = _workbook.GetSheetAt(sheetIndex);
            sheet.ForceFormulaRecalculation = forceFormulaRecalculation;
            _workbook.Write(ms);
            ms.Flush();
            return ms;
        }
        #endregion

    }
}