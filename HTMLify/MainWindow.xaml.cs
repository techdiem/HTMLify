using System;
using System.Collections.Generic;
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
using System.Diagnostics;

namespace HTMLify
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HTMLGenerator htmlGenerator = new HTMLGenerator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void dockEditTemplate_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", htmlGenerator.templatePath);
        }

        private void dockFileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            string richText, htmlPage;
            TextRange textRange = new TextRange(richtextContent.Document.ContentStart, richtextContent.Document.ContentEnd);
            richText = textRange.Text;
            htmlPage = htmlGenerator.convertText(richText);
            htmlGenerator.saveFile(htmlPage);
        }
    }
}
