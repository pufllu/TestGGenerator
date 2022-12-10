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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestGGenerator
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        MyDbContext context;
        public TestPage()
        {
            InitializeComponent();
            context = new MyDbContext();
            var disciplineList = context.Themes.ToList();
            ComboBoxTheme.ItemsSource = disciplineList;
        }

        private void CreateTests(object sender, RoutedEventArgs e)
        {
            int count = Convert.ToInt32(CountQuest.Text);
            string pathQuest = "c:\\";
            string pathAnsw = "c:\\";
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Выберите директорию";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pathQuest = dlg.SelectedPath + "\\quest.txt";
                    pathAnsw = dlg.SelectedPath + "\\answer.txt";
                }

            }

            Test test = new Test
            {
                nameTest = NameTest.Text,
                dateCreation = DateTime.Now
            };
            context.Tests.Add(test);

            int MaxIdQues = context.Questions.Max(x => x.id);
            int MinIdQues = context.Questions.Min(x => x.id);

            List<int> idQuestRondomList = new List<int>();

            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i <= count; i++)
            {

                idQuestRondomList.Add(random.Next(MinIdQues, MaxIdQues));
            }
            List<Question> a = new List<Question>();
            using (StreamWriter writer = new StreamWriter(pathQuest, true))
            {

                foreach (var item in idQuestRondomList)
                {
                    int j = 1;

                    Question lins = context.Questions.FirstOrDefault(x => x.id == item);
                    if (lins == null)
                    {
                        continue;
                    }

                    TestQuestion testQuestion = new TestQuestion()
                    {
                        Questions = lins,
                        Test = test
                    };

                    context.TestQuestions.Add(testQuestion);

                    var temp = context.Questions.FirstOrDefault(x => x.id == item).question;
                    a.Add(context.Questions.FirstOrDefault(x => x.id == item));
                    writer.WriteLine(j.ToString() + temp.ToString());
                    j++;
                }
            }
            using (StreamWriter writer = new StreamWriter(pathAnsw, true))
            {

                foreach (var item in a)
                {
                    int j = 1;

                    Question lins = context.Questions.FirstOrDefault(x => x.id == item.id);
                    if (lins == null)
                    {
                        continue;
                    }

                    var temp = context.Questions.FirstOrDefault(x => x.id == item.id).answer;

                    writer.WriteLine(j.ToString() + temp.ToString());
                    j++;
                }
            }
            context.SaveChanges();
        }
        Theme selectedItem = new Theme();
        private void ChangeTheme(object senderTemp, SelectionChangedEventArgs eTemp)
        {
            System.Windows.Controls.ComboBox comboBox = (System.Windows.Controls.ComboBox)senderTemp;
            selectedItem = comboBox.SelectedItem as Theme;
        }
    }
}
