using System.Collections.Generic;
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
            var selectedItem = SymptomsTable.SelectedItem;
            if (selectedItem is Symptom)
            {
                var symptom = selectedItem as Symptom;
                db.Remove(symptom);
                db.SaveChanges();
            }
        }

        private void OnEditSymptomButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = SymptomsTable.SelectedItem;
            if (selectedItem is Symptom symptom)
            {
                var symptomWindow = new SymptomWindow(new Symptom
                {
                    SymptomId = symptom.SymptomId,
                    Name = symptom.Name,
                    Diseases = new List<Disease>(symptom.Diseases)
                });
                if (symptomWindow.ShowDialog() == true)
                {
                    symptom.Name = symptomWindow.Symptom.Name;
                    symptom.Diseases = symptomWindow.Symptom.Diseases;
                    db.SaveChanges();
                    SymptomsTable.Items.Refresh();
                }
            }
        }
    }
}
