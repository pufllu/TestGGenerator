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
    /// Логика взаимодействия для ThemePage.xaml
    /// </summary>
    public partial class ThemePage : Page
    {
        MyDbContext context;
        public ThemePage()
        {
            InitializeComponent();
            context = new MyDbContext();
            TableTheme.ItemsSource = context.Themes.ToList();
            var disciplineList = context.Discipline.ToList();
            ComboBoxTheme.ItemsSource = disciplineList;
        }
        public void RefreszData()
        {

        }
        Discipline selectedItem = new Discipline();
        private void ChangeTheme(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedItem = comboBox.SelectedItem as Discipline;
        }

        private void AddTheme(object sender, RoutedEventArgs e)
        {
            string nameTheme = TextBoxTheme.Text;
            Theme theme = new Theme
            {
                nameTheme = nameTheme
            };
            context.Themes.Add(theme);
            context.SaveChanges();

            ThemeDiscipline themeDiscipline = new ThemeDiscipline
            {
                Theme = theme,
                Discipline = selectedItem,
            };

            context.ThemeDisciplines.Add(themeDiscipline);
            context.SaveChanges();

        }
    }
}
