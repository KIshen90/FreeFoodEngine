using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace FreeFoodEngine.ViewModels.SampleData
{
    public class OptionsInfoProvider : IGenericListFieldInfoProvider
    {
        public System.Collections.IEnumerable ItemsSource
        {
            get { return new List<string>() { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5" }; }
        }

        public IGenericListValueConverter ValueConverter
        {
            get { return null; }
        }
    }
}
