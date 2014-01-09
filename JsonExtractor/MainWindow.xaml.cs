using DataExtractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JsonExtractor
{
    public partial class MainWindow : Window
    {
        string lastOpenedCSVFile = Properties.Settings.Default.CSVFileName;

        public MainWindow()
        {
            InitializeComponent();
            txtConn.Text = Properties.Settings.Default.OleDbConnStr;
            txtQuery.Text = Properties.Settings.Default.OleDbQuery;
            chbLcasePropNames.IsChecked = Properties.Settings.Default.lcasePropNames;
            providers.ItemsSource = GetProvidersFromSettings();
            providers.SelectedItem = Properties.Settings.Default.LastUsedProvider;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = PullData();

            OleDbConnection conn = new OleDbConnection();
            JSONer.JSONConverter jsc = new JSONer.JSONConverter();
            txtContent.Text = jsc.ConvertValuesInDataTableToJSON(dt, (bool)chbLcasePropNames.IsChecked).ToString();
        }

        private DataTable PullData()
        {
            IDataTableable dataExtractor;
            if (providers.SelectedItem.ToString().ToLower().StartsWith("oledb"))
                dataExtractor = new MSAccessDataProvider();
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("odbc"))
                dataExtractor = new OdbcDataProvider();
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("sql"))
                dataExtractor = new SqlDataProvider();
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("comma-separated"))
                dataExtractor = new CSVDataProvider();
            else
                dataExtractor = new MSAccessDataProvider();

            DataTable dt = new DataTable();

            try
            {
                dt = dataExtractor.GetData(new ProviderSettings { ConnStr = txtConn.Text, Query = txtQuery.Text, CSVFileName = lastOpenedCSVFile });
            }
            catch (Exception ex)
            {
                txtContent.Text = ex.Message;
            }
            return dt;
        }

        private void clearResults_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = string.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            if (providers.SelectedItem.ToString().ToLower().StartsWith("oledb"))
            {
                Properties.Settings.Default.OleDbConnStr = txtConn.Text.Trim();
                Properties.Settings.Default.OleDbQuery = txtQuery.Text.Trim();
            }
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("odbc"))
            {

                Properties.Settings.Default.OdbcConnStr = txtConn.Text.Trim();
                Properties.Settings.Default.OdbcQuery = txtQuery.Text.Trim();
            }
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("sql"))
            {
                Properties.Settings.Default.SqlConnStr = txtConn.Text.Trim();
                Properties.Settings.Default.SqlQuery = txtQuery.Text.Trim();
            }
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("comma-separated"))
            {
                Properties.Settings.Default.CSVFileName = lastOpenedCSVFile;
            }

            Properties.Settings.Default.lcasePropNames = (bool)chbLcasePropNames.IsChecked;
            Properties.Settings.Default.LastUsedProvider = providers.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void RestoreSettings()
        {
            if (providers.SelectedItem.ToString().ToLower().StartsWith("oledb"))
            {
                txtConn.Text = Properties.Settings.Default.OleDbConnStr;
                txtQuery.Text = Properties.Settings.Default.OleDbQuery;
            }
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("odbc"))
            {
                txtConn.Text = Properties.Settings.Default.OdbcConnStr;
                txtQuery.Text = Properties.Settings.Default.OdbcQuery;
            }
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("sql"))
            {

                txtConn.Text = Properties.Settings.Default.SqlConnStr;
                txtQuery.Text = Properties.Settings.Default.SqlQuery;
            }
            else if (providers.SelectedItem.ToString().ToLower().StartsWith("comma-separated"))
            {
                Properties.Settings.Default.CSVFileName = lastOpenedCSVFile;
            }
        }

        private void clearConn_Click(object sender, RoutedEventArgs e)
        {
            txtConn.Text = string.Empty;
        }

        private void clearQuery_Click(object sender, RoutedEventArgs e)
        {
            txtQuery.Text = string.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtContent.Text.Trim().Length > 0)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".js";
                dlg.Filter = "js documents (.js)|*.js|All files(*.*)|*.*";

                bool? result = dlg.ShowDialog();
                if (result == true)
                {
                    System.IO.File.WriteAllText(dlg.FileName, txtContent.Text);
                }
            }
        }

        private void providers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> allProviders = GetProvidersFromSettings();

            if (providers.SelectedItem.ToString().Length == 0)
            {
                csvProviderOptions.Visibility = System.Windows.Visibility.Hidden;
                dbaseConnProviderOptions.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (providers.SelectedItem.ToString().IndexOf("Connection") > 2)
            {
                csvProviderOptions.Visibility = System.Windows.Visibility.Hidden;
                dbaseConnProviderOptions.Visibility = System.Windows.Visibility.Visible;
            }
            else if (providers.SelectedItem.ToString().IndexOf("-separated") > 2)
            {
                csvProviderOptions.Visibility = System.Windows.Visibility.Visible;
                dbaseConnProviderOptions.Visibility = System.Windows.Visibility.Hidden;
            }

            RestoreSettings();
        }

        private void browseForDbase_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = ".csv files |*.csv|.txt files |*.txt|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                lastOpenedCSVFile = dlg.FileName;
                if (lastOpenedCSVFile.Length > 25)
                    dbaseSelectionResult.Text = lastOpenedCSVFile.Substring(0, 5) + "..."
                        + lastOpenedCSVFile.Substring(lastOpenedCSVFile.Length - 20, 20);
                else
                    dbaseSelectionResult.Text = lastOpenedCSVFile;

            }
        }

        private List<string> GetProvidersFromSettings()
        {
            string provs = Properties.Settings.Default.providers.ToString();
            List<string> result = new List<string>();
            result.AddRange(provs.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList().OrderBy(x => x));
            return result;
        }

        private void providers_GotFocus(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }
    }
}
