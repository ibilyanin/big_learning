using System.Windows.Controls;
using Common.Core.Abstractions;
using Elang.Desktop.UI.ViewModels;

namespace Elang.Desktop.UI.Views;
/// <summary>
/// Interaction logic for TopicsView.xaml
/// </summary>
public partial class TopicsView : UserControl, IView<TopicsViewModel>
{
    public TopicsView()
    {
        InitializeComponent();
    }
}
