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
using System.Windows.Shapes;

using VRCOSC.App.SDK.Utils;
using VRCOSC.App.UI.Core;
using VRCOSC.App.Utils;

namespace antares27.osecho.UI
{
    /// <summary>
    /// Interaction logic for EchoParamsInstanceEditWindow.xaml
    /// </summary>
    public partial class EchoParamsInstanceEditWindow : IManagedWindow
    {
        private readonly EchoParam Instance;

        public EchoParamsInstanceEditWindow(EchoParam instance)
        {
            InitializeComponent();

            Instance = instance;
            DataContext = instance;

            instance.Name.Subscribe(newName => Title = $"{newName.Pluralise()} Settings", true);
        }

        //private void AddEchoParam_OnClick(object sender, RoutedEventArgs e)
        //{
        //    Instance.EchoParams.Add(new Observable<EchoParam>(new EchoParam()));
        //}

        //private void RemoveEchoParam_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var element = (FrameworkElement)sender;
        //    var echoParam = (Observable<EchoParam>)element.Tag;

        //    Instance.EchoParams.Remove(echoParam);
        //}

        public object GetComparer() => Instance;
    }
}
