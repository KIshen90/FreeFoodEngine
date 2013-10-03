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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.DataForm;
using FreeFoodEngine.ViewModels.SampleData;

namespace FreeFoodEngine.ViewModels.Models
{
    public class MultiPurposeFormDataModel
    {
        [GenericListEditor(typeof(OptionsInfoProvider))]
        public string Option1 
        {
            get;
            set;
        }

        [GenericListEditor(typeof(OptionsInfoProvider))]
        public string Option2 
        {
            get;
            set; 
        }

        public DateTime? Date1 
        {
            get;
            set; 
        }

        public DateTime? Date2 
        {
            get; 
            set; 
        }

        public int NumberField 
        {
            get; 
            set; 
        }

        [GenericListEditor(typeof(OptionsInfoProvider))]
        public string Option3 
        { 
            get; 
            set; 
        }
    }
}
