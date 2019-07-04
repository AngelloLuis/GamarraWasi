using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sales.chatCellUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCell : ViewCell
    {
        public UserCell()
        {
            InitializeComponent();
        }
    }
}