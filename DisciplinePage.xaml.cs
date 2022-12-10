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
    /// Логика взаимодействия для DisciplinePage.xaml
    /// </summary>
    public partial class DisciplinePage : Page
    {
        MyDbContext context;
        public DisciplinePage()
        {
            InitializeComponent();
            context = new MyDbContext();
            TableDiscipline.ItemsSource = context.Discipline.ToList();
        }

        private void AddDiscipline(object sender, RoutedEventArgs e)
        {
            string nameDiscipline = nameDisc.Text;
            Discipline discipline = new Discipline
            {
                nameDiscipline = nameDiscipline
            };
            context.Discipline.Add(discipline);
            context.SaveChanges();
        }
    }
}
