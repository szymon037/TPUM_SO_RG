using System.ComponentModel;
using Xamarin.Forms;
using TPUM.ViewModels;

namespace TPUM.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}