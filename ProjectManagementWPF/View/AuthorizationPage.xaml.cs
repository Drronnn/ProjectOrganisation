using BLL;
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

namespace ProjectManagementWPF.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private AuthorizationViewModel VM;
        public AuthorizationPage(Frame authFrame, IAuthorizationService authorizationService, MainWindowViewModel mainWindowViewModel = null)
        {
            InitializeComponent();
            VM = new AuthorizationViewModel(authFrame, authorizationService, mainWindowViewModel);
            DataContext = VM;
        }
    }
}
