using Ninject;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using BLL;

namespace ProjectManagementWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private MainWindowViewModel VM;
        public MainWindow()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule("InsuranceContext"));
            IAuthorizationService serv = kernel.Get<IAuthorizationService>();

            VM = new MainWindowViewModel(kernel, this, mainFrame, authFrame, serv);
            DataContext = VM;

            AgileButton.IsChecked = true;
            authFrame.Navigate(new View.AuthorizationPage(authFrame, serv, VM));


        }
        private void DragRecranhle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void ResetToAgile()
        {
            AgileButton.IsChecked = true;
        }

    }


    public class MyConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var realV = (bool)value;

            if (realV)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var realV = (Visibility)value;

            if (realV == Visibility.Collapsed)
                return false;
            else
                return true;
        }
    }

    public class NegateBoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var realV = (bool)value;

            if (!realV)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var realV = (Visibility)value;

            if (realV == Visibility.Visible)
                return false;
            else
                return true;
        }
    }

    public class StringToVisibilityParameter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var realV = (string)value;
            var reqV = (string)parameter;
            if (realV == reqV)
                return true;
            else
                return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }

    public class TagVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tagValue = value as string;
            string reqValue = parameter as string;
            return (tagValue == reqValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NumberVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tagValue = ((int)value).ToString();
            string reqValue = parameter as string;
            return (tagValue != reqValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InvertNumberVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tagValue = ((int)value).ToString();
            string reqValue = parameter as string;
            return (tagValue == reqValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}