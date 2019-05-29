using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data.Common;

namespace ConfigPC
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

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Price.Text != "")
            {
                ExSysCore core = new ExSysCore(Price.Text, Purpose.SelectedIndex);
                core.Build();
            }
            else
            {
                label.Text = "Введите бюджет.";
            }
        }

    }
}
