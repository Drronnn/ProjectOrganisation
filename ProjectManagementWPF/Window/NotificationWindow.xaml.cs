using System;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media.Animation;


namespace ProjectManagementWPF.Window
{
    /// <summary>
    /// Логика взаимодействия для NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : System.Windows.Window
    {
        public NotificationWindow(string text)
        {
            InitializeComponent();

            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 1.0;
            animation.From = 0.0;
            animation.Duration = new TimeSpan(0, 0, 0, 0, 200);
            animation.EasingFunction = new SineEase();

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            But.Opacity = 0.0;

            Storyboard.SetTarget(sb, But);
            Storyboard.SetTargetProperty(sb, new PropertyPath(Control.OpacityProperty));

            sb.Begin();

            But.Content = text;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 0.0;
            animation.From = 1.0;
            animation.Duration = new TimeSpan(0, 0, 0, 0, 200);
            animation.EasingFunction = new SineEase();

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            But.Opacity = 1.0;

            Storyboard.SetTarget(sb, But);
            Storyboard.SetTargetProperty(sb, new PropertyPath(Control.OpacityProperty));


            sb.Completed += delegate (object s, EventArgs ev)
            {
                Close();
            };

            sb.Begin();

        }
    }
}
