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

namespace WpfApp3
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder erors = new StringBuilder();
            using (var db = new kokEntities2())
            {
                var user = db.lols.AsNoTracking().FirstOrDefault(p => p.log == login.Text && p.pass == password.Password);
                var logi = db.lols.AsNoTracking().FirstOrDefault(p => p.log == login.Text);
                if (logi == null)
                {
                    erors.AppendLine("Пользователь не найден");
                }
                if (user == null)
                {
                    erors.AppendLine("Пароль говно");
                }
                if (erors.Length > 0)
                {
                    MessageBox.Show(erors.ToString());
                    return;
                }
                if (erors.Length == 0)
                {
                    if (user.role == true)
                        MessageBox.Show("1");
                    else
                        MessageBox.Show("2");
                }
            }
        }

    }
}