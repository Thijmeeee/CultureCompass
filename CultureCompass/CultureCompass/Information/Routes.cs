using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CultureCompass.Information
{
    public partial class Routes : ObservableObject
    {
        [ObservableProperty]
        public List<Route> routeList; 
    }
}
