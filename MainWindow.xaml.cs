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

namespace TestGGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void qustionBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new QuestionPage());
        }

        private void testBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new TestPage());
        }

        private void themeBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new ThemePage());
        }

        private void disciplineBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new DisciplinePage());
        }

        private void aboutTheProgramBtn(object sender, RoutedEventArgs e)
        {
            FramePage.Navigate(new AboutTheProgramPage());
        }
    }
}
