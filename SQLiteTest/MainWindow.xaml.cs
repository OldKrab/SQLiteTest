using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using SQLiteTest.Objects;
using SQLiteTest.src.Windows;

namespace SQLiteTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestContext db = new TestContext();
        private BindingList<Symptom> bindingList;
        public MainWindow()
        {
            InitializeComponent();
            db.Symptoms.Load();
            SymptomsTable.DataContext = db.Symptoms.Local.ToBindingList();
        }

        private void OnAddSymptomButtonClick(object sender, RoutedEventArgs e)
        {
            var symptomWindow = new SymptomWindow(new Symptom());
            if (symptomWindow.ShowDialog() == true)
            {
                db.Add(symptomWindow.Symptom);
                db.SaveChanges();
            }
        }


        private void OnDeleteSymptomButtonClick(object sender, RoutedEventArgs e)
        {
            var symptom = SymptomsTable.SelectedItem;
            if (symptom is Symptom)
            {
                db.Remove(symptom);
                db.SaveChanges();
            }
        }
    }
}
