using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestGGenerator
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        MyDbContext context;
        public QuestionPage()
        {
            InitializeComponent();
            context = new MyDbContext();
            QuestionTable.ItemsSource = context.Questions.ToList();
            var disciplineList = context.Discipline.ToList();
            ComboBoxQuestionDis.ItemsSource = disciplineList;

            var themeList = context.Themes.ToList();
            ComboBoxQuestionThe.ItemsSource = themeList;
        }

        private void AddBtnQuestion(object sender, RoutedEventArgs e)
        {
            string questi = textBoxQuestion.Text;
            string question = textBoxQuestion.Text;
            string answer = textBoxAnswer.Text;
            if (context.Questions.Any(x => x.question == questi))
            {
                Question questions1 = context.Questions.ToList().Find(x => x.Equals(question == questi));
                MessageBox.Show("Данный вопрос уже существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Question questions = new Question
                {
                    question = question,
                    answer = answer
                };
                context.Questions.Add(questions);
                context.SaveChanges();
            }
        }

        private void FileAddQuestion(object sender, RoutedEventArgs e)
        {
            string pathFile = "C:\\";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                pathFile = Convert.ToString(openFileDialog.FileName);
            }

            List<Question> questionsList = new List<Question>();
            string[] lines = File.ReadAllLines(pathFile);
            int i = lines.Count();
            string[] vs = new string[i];
            string Question;
            string Answer;
            foreach (var line in lines)
            {

                Question questions = new Question();
                vs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Question = vs[0];
                Answer = vs[1];
                questions.question = Question;
                questions.answer = Answer;
                if (!(context.Questions.Any(x => x.question == Question)))
                {
                    questionsList.Add(questions);
                }
            }
            foreach (var item in questionsList)
            {
                context.Questions.Add(item);
                context.SaveChanges();
            }
        }

        private void DelQuestion(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить вопрос?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Question questions = QuestionTable.SelectedItem as Question;
                    context.Questions.Remove(questions);
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
        }

        private void EditQuestion(object sender, RoutedEventArgs e)
        {
            Question questions = QuestionTable.SelectedItem as Question;
            NavigationService.Navigate(new EditQuestionPage(context, questions));
        }

        Discipline selectedItem = new Discipline();
        private void ChangeDiscipline(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedItem = comboBox.SelectedItem as Discipline;

        }
        Theme themeBox = new Theme();
        private void ChangeTheme(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            themeBox = comboBox.SelectedItem as Theme;
        }
        public void RefreszData()
        {
            var list = context.Questions.ToList();
            if (!string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                list = list.Where(x => x.question.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
            }
            QuestionTable.ItemsSource = list;
        }
        private void ChangeSearch(object sender, TextChangedEventArgs e)
        {
            RefreszData();
        }
    }
}
