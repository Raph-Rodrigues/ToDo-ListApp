using CommunityToolkit.Mvvm.ComponentModel;
using ToDo_ListApp.Models;

namespace ToDo_ListApp.ViewModels;

public partial class ItemViewModel : ViewModelBase
{
    public ItemViewModel()
    {
        //empty
    }

    public ItemViewModel(Item item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
    }
    
    //[ObservableProperty]
    private bool _isChecked;

    public bool IsChecked
    {
        get { return _isChecked; }
        set { SetProperty(ref _isChecked, value); }
    }
    
    [ObservableProperty]
    private string? _content;

    public Item GetItem()
    {
        return new Item()
        {
            IsChecked = this.IsChecked,
            Content = this.Content,
        };
    }
}