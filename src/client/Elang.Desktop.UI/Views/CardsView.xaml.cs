using System.Windows.Controls;
using Common.Core.Abstractions;
using Elang.Desktop.UI.ViewModels;

namespace Elang.Desktop.UI.Views;
/// <summary>
/// Interaction logic for CardsView.xaml
/// </summary>
public partial class CardsView : UserControl, IView<CardsViewModel>
{
    public CardsView()
    {
        InitializeComponent();
    }
}
