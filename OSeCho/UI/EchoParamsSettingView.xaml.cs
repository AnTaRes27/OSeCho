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

using VRCOSC.App.UI.Core;

namespace antares27.osecho.UI
{
    /// <summary>
    /// Interaction logic for EchoParamsSettingView.xaml
    /// </summary>
    public partial class EchoParamsSettingView : UserControl
    {
        private readonly EchoModuleSetting moduleSetting;
        private WindowManager windowManager = null!;

        public EchoParamsSettingView(EchoModule _, EchoModuleSetting moduleSetting)
        {
            this.moduleSetting = moduleSetting;

            InitializeComponent();

            DataContext = moduleSetting;
        }

        private void EchoParamsSettingView_OnLoaded(object sender, RoutedEventArgs e)
        {
            windowManager = new WindowManager(this);
        }

        private void AddInstanceButton_OnClick(object sender, RoutedEventArgs e)
        {
            moduleSetting.Add();
        }

        private void EditInstanceButton_OnClick(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            var echoParamInstance = (EchoParam)element.Tag;

            var editWindow = new EchoParamsInstanceEditWindow(echoParamInstance);

            windowManager.TrySpawnChild(editWindow);
        }

        private void RemoveInstanceButton_OnClick(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            var echoParamInstance = (EchoParam)element.Tag;

            var result = MessageBox.Show("Warning. This will remove the parameter data and remove it. Are you sure?", "Delete parameter?", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            moduleSetting.Remove(echoParamInstance);
        }
    }
}
