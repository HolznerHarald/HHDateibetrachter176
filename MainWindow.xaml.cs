using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;


namespace HHDateibetrachter176
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();

            var result = folderBrowser.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var ordnerInfo = new DirectoryInfo(folderBrowser.SelectedPath);
                if (ordnerInfo.Exists)
                {
                    Dateiliste.Items.Clear();
                    foreach (var dateiInfo in ordnerInfo.
                    GetFiles())
                    {
                        Dateiliste.Items.Add(dateiInfo);
                    }
                }
            }
        }

        private void Dateiliste_SelectionChanged(object sender,
        SelectionChangedEventArgs e)
        {
            try
            {
                Ausgabe.Text = File.ReadAllText(Dateiliste.
                SelectedItem.ToString());
                Datei.Text = Dateiliste.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                Ausgabe.Text = ex.Message;
            }
        }
    }
}
