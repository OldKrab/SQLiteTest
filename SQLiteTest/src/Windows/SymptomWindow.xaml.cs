using System.Windows;
using SQLiteTest.Objects;

namespace SQLiteTest.src.Windows
{
    /// <summary>
    /// Логика взаимодействия для SymptomWindow.xaml
    /// </summary>
    public partial class SymptomWindow : Window
    {
        public SymptomWindow(Symptom symptom)
        {
            InitializeComponent();
            Symptom = symptom;
            this.DataContext = Symptom;
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public Symptom Symptom { get; private set; }
    }
}
