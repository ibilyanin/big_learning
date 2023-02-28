using System.Collections.Generic;
using Common.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using Elang.Desktop.UI.Models;

namespace Elang.Desktop.UI.ViewModels;

internal partial class TopicsViewModel : ObservableRecipient, IViewModel
{
    [ObservableProperty]
    private List<Topic>? _topics;
}

