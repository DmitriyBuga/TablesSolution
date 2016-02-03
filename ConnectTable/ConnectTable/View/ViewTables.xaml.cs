using ConnectTable.Helpers;
using ConnectTable.Model;
using ConnectTable.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using IPluginsConnect;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConnectTable.View
{
    /// <summary>
    /// Interaction logic for ViewTables.xaml
    /// </summary>
    class TableTabControlItem:TabItem
    {
        public ListTablesItem listTable { get; set; }
    }
    public partial class ViewTables : Window
    {
        private ViewModelTables modelMain;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            modelMain.SaveConnectTablePars2File();
            foreach (TableTabControlItem item in tabControl.Items)
            {
                item.listTable.SelectedPlugin.CloseConnection();// item.listTable.sqlConnection);
            }
            
        }
        public ViewTables()
        {

            InitializeComponent();
            //this.Form.
            _setStateTableButttons(false);
            modelMain = new ViewModelTables();
            DataContext = modelMain;
            Messenger.Default.Register<string>(this, "ClearFilter", x =>
            {
                TableTabControlItem tabItem;
                tabItem = (TableTabControlItem)tabControl.SelectedItem;
                tabItem.listTable.SelectedPlugin.SetFilter(tabItem.listTable.tableName, "SELECT * FROM " + tabItem.listTable.tableName);
                //tabControl.Items.Add(tabItem);
                DataGrid dataGrid = new DataGrid();
                dataGrid.ItemsSource = modelMain.SelectedPlugin.table.DefaultView;
                tabItem.Content = dataGrid;
            }
            );
            Messenger.Default.Register<string>(this, "OpenSetFilterView", x =>
            {
                List<string> listFields = new List<string>();
                TableTabControlItem item = (TableTabControlItem)tabControl.SelectedItem;
                foreach (var column in item.listTable.fields)//dt.Columns)
                    listFields.Add(column.ToString());
                
                
                ViewFilter filterWnd = new ViewFilter(listFields);
                filterWnd.ShowDialog();
                ObservableCollection<RowFilterTable> filterTable = filterWnd.table;
                if (filterTable != null)
                {
                    string query = "";
                    foreach (RowFilterTable row in filterTable)
                    {
                        if (row.Operator.Length != 0)

                            query += (row.fieldName + row.Operator + row.textValue + " AND ");
                    }
                    TableTabControlItem tabItem;
                    if (query.Length != 0)
                    {
                        tabItem = (TableTabControlItem)tabControl.SelectedItem;
                        query = query.Substring(0, query.Length - 5);
                        query = "SELECT * FROM " + tabItem.listTable.tableName + " WHERE " + query;
                        tabItem.listTable.SelectedPlugin.SetFilter(tabItem.listTable.tableName, query);//, tabItem.listTable.sqlConnection);
                        //tabControl.Items.Add(tabItem);
                        DataGrid dataGrid = new DataGrid();
                        dataGrid.ItemsSource = modelMain.SelectedPlugin.table.DefaultView;
                        tabItem.Content = dataGrid;
                        
                    }
                }

            }
            );
            Messenger.Default.Register<string>(this, "CloseSelectedTable", x =>
            {
                TableTabControlItem item = (TableTabControlItem)tabControl.SelectedItem;
                item.listTable.SelectedPlugin.CloseConnection();//item.listTable.sqlConnection);
                modelMain.listTables.Remove(item.listTable);
                tabControl.Items.Remove(item);
                if(tabControl.Items.Count == 0)
                    _setStateTableButttons(false);
            }
            );
            Messenger.Default.Register<string>(this, "Export2Csv", x =>
            {

                Export2Csv();
            }
            );
            Messenger.Default.Register<string>(this, "Export2Pdf", x =>
            {

                Export2Pdf();
            }
            );
            Messenger.Default.Register<string>(this, "Export2Xls", x =>
            {

                Export2Xls();
            }
            );
            Messenger.Default.Register<string>(this, "CloseViewTables", x =>
            {
                Close();
            }
            );
            Messenger.Default.Register<ListTablesItem>(this, "AppendTabItem", x =>
            {
                TableTabControlItem tabItem = new TableTabControlItem();
                DataGrid dataGrid = new DataGrid();
                dataGrid.ItemsSource = modelMain.SelectedPlugin.table.DefaultView;
                tabItem.Header = x.serverName + @"\" + x.database + @"\" + modelMain.SelectedPlugin.table.TableName;
                tabControl.Items.Add(tabItem);
                tabItem.listTable = x;
                tabItem.listTable.dataGrid = dataGrid;
                tabItem.listTable.fields = new List<string>();
                foreach (DataColumn col in modelMain.SelectedPlugin.table.Columns)
                    tabItem.listTable.fields.Add(col.ColumnName);
                Grid grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition());

                Grid.SetRow(dataGrid, 1);
                Grid.SetColumn(dataGrid, 0);
                grid.Children.Add(dataGrid);
                tabItem.Content = grid;//dataGrid;

                tabControl.SelectedItem = tabItem;
                _setStateTableButttons(true);
            }
            );
            modelMain.OpenTables();
            // modelMain = new ViewModelTables();
            //lvConnectedTables.ItemsSource = modelMain.listTables;
            //modelMain.listTables.Add(new ListTablesItem { tableName = "aaa", serverName = "bbb" });

        }
        private void _setStateTableButttons(bool lEnable)
        {
            if (btnClearFilter.IsEnabled != lEnable)
            {
                btnClearFilter.IsEnabled = lEnable;
                btnCSV.IsEnabled = lEnable;
                btnFilter.IsEnabled = lEnable;
                btnPDF.IsEnabled = lEnable;
                btnXLS.IsEnabled = lEnable;
                btnDelete.IsEnabled = lEnable;
            }
        }
        private void Export2Csv()
        {
        //    string CsvFpath = AppDomain.CurrentDomain.BaseDirectory + @"\Document.csv";

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            saveDlg.Filter = "CSV files (*.csv)|*.csv";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Export csv File To";
            if (saveDlg.ShowDialog() == true)
            {
                string csvFpath = saveDlg.FileName;
                try
                {
                    System.IO.StreamWriter csvFileWriter = new StreamWriter(csvFpath, false);
                    string csvText = "";
                    DataGrid dg = GetCurrentDataGrid();
                    DataView dv = (DataView)dg.ItemsSource;
                    DataTable dt = dv.Table;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        csvText += dt.Columns[i].ColumnName + ';';
                    }


                    csvFileWriter.WriteLine(csvText.Substring(0, csvText.Length - 1));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        csvText = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            csvText += dt.Rows[i][j].ToString() + ";";
                        }
                        csvFileWriter.WriteLine(csvText.Substring(0, csvText.Length - 1));
                    }
                    csvFileWriter.Flush();
                    csvFileWriter.Close();
                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                    return;
                }
                Process.Start(csvFpath);
            }

        }
        private void Export2Pdf()
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = @"C:\";
            saveDlg.Filter = "PDF files (*.pdf)|*.pdf";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "Export PDF File To";
            if (saveDlg.ShowDialog() == true)
            {
                string csvFpath = saveDlg.FileName;
                try
                {
                    DataGrid dg = GetCurrentDataGrid();
                    DataView dv = (DataView)dg.ItemsSource;
                    DataTable dt = dv.Table;
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(csvFpath, FileMode.Create));
                    doc.Open();
                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        table.AddCell(dt.Columns[i].ColumnName);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            table.AddCell(dt.Rows[i][j].ToString());// Cells[j].Value;
                        }
                    }
                    doc.Add(table);
                    doc.Close();
                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                    return;
                }
                MessageBoxResult mbr = MessageBox.Show("Open file?", "Open", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mbr == MessageBoxResult.Yes)
                {
                    Process.Start(csvFpath);
                }
            }
        }
        private DataGrid GetCurrentDataGrid()
        {
            TableTabControlItem item = (TableTabControlItem)tabControl.SelectedItem;
            return item.listTable.dataGrid;
        }
        private void Export2Xls()
        {
            DataGrid dg = GetCurrentDataGrid();
            DataView dv = (DataView)dg.ItemsSource;
            DataTable dt = dv.Table;
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ExcelApp.Cells[1, (i + 1)] = dt.Columns[i].ColumnName;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dt.Rows[i][j];// Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
