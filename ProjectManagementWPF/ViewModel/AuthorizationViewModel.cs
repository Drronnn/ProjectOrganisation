using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using BLL;
using ProjectManagementWPF.Window;

namespace ProjectManagementWPF
{
    public class AuthorizationViewModel
    {

        #region Command

        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ?? (logInCommand = new RelayCommand(obj =>
                {
                    var values = (object[])obj;
                    string login = (string)values[0];
                    PasswordBox password = (PasswordBox)values[1];
                    Authorization(login, password.Password);
                }));
            }
        }




        #endregion



        private Frame authFrame;
        private IAuthorizationService authorizationService;
        private MainWindowViewModel mainWindowViewModel;
        public AuthorizationViewModel(Frame authFrame, IAuthorizationService authorizationService, MainWindowViewModel mainWindowViewModel = null)
        {
            this.authFrame = authFrame;
            this.authorizationService = authorizationService;
            this.mainWindowViewModel = mainWindowViewModel;
            PlayFadeInAnimation();
        }

        public void Authorization(string login, string password)
        {
            if (authorizationService.TryAuthorization(login, password))
            {
                PlayFadeAnimation();
                if (mainWindowViewModel != null)
                    mainWindowViewModel.LogIn();
            }
            else
            {
                NotificationWindow notificationWindow = new NotificationWindow("Неверный логин\nили пароль");
                notificationWindow.ShowDialog();
            }

        }

        private void PlayFadeAnimation()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 0.0;
            animation.From = 1.0;
            animation.Duration = new TimeSpan(0, 0, 0, 0, 400);
            animation.EasingFunction = new SineEase();

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            authFrame.Opacity = 1.0;

            Storyboard.SetTarget(sb, authFrame);
            Storyboard.SetTargetProperty(sb, new PropertyPath(Control.OpacityProperty));


            sb.Completed += delegate (object sender, EventArgs e)
            {
                authFrame.Navigate(null);
            };

            sb.Begin();
        }

        private void PlayFadeInAnimation()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 1.0;
            animation.From = 0.0;
            animation.Duration = new TimeSpan(0, 0, 0, 0, 400);
            animation.EasingFunction = new SineEase();

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            authFrame.Opacity = 01.0;

            Storyboard.SetTarget(sb, authFrame);
            Storyboard.SetTargetProperty(sb, new PropertyPath(Control.OpacityProperty));



            sb.Begin();
        }

    }
}
