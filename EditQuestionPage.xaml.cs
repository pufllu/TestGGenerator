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
    /// Логика взаимодействия для EditQuestionPage.xaml
    /// </summary>
    public partial class EditQuestionPage : Page
    {
        MyDbContext context;
        public EditQuestionPage(MyDbContext cont)
        {
            InitializeComponent();
            context = cont;
        }
        Question qst;
        public EditQuestionPage(MyDbContext cont, Question questions)
        {
            InitializeComponent();
            context = cont;
            qst = questions;
            EditQst.Text = questions.question;
            EditAnswer.Text = questions.answer;
        }
        private void saveEdit(object sender, RoutedEventArgs e)
        {
            context.Questions.Find(qst.id).question = EditQst.Text;
            context.Questions.Find(qst.id).answer = EditAnswer.Text;
            context.SaveChanges();
            NavigationService.Navigate(new QuestionPage());
        }
    }
}
