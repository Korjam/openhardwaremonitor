using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenHardwareMonitor.Modern.ViewModel;

public partial class ComponentViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name;

    public ObservableCollection<ComponentViewModel> Components { get; } = new ObservableCollection<ComponentViewModel>();

    public ComponentViewModel(string name)
    {
        _name = name;
    }

    public virtual void Update(TimeSpan timestamp)
    {
        foreach (var item in Components)
        {
            item.Update(timestamp);
        }
    }

    public IEnumerable<ComponentViewModel> AllChildsRecursive()
    {
        foreach (var child in Components)
        {
            yield return child;

            foreach (var item2 in child.AllChildsRecursive())
            {
                yield return item2;
            }
        }
    }

    public override string ToString() => Name;
}
