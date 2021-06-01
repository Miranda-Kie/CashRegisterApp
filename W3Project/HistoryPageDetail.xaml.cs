using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace W3Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPageDetail : ContentPage
    {
        History historyD;
        public HistoryPageDetail(History historyDC)
        {
            InitializeComponent();
            historyD = historyDC;
            BindingContext = historyD;
        }
    }
}