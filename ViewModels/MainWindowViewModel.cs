using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToDo_ListApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   public MainWindowViewModel()
    {
        if (Design.IsDesignMode)
        {
            ToDoItems = new ObservableCollection<ItemViewModel>(new[]
            {
                new ItemViewModel() { Content = "Hello" },
                new ItemViewModel() { Content = "Avalonia", IsChecked = true}
            });
        }
    }
   
    public ObservableCollection<ItemViewModel> ToDoItems { get; } = new ObservableCollection<ItemViewModel>();
    
    [RelayCommand (CanExecute = nameof(CanAddItem))]
    private void AddItem()
    {
        // Add a new item to the list
        ToDoItems.Add(new ItemViewModel() {Content = NewItemContent});
        
        // reset the NewItemContent
        NewItemContent = null;
    }

    
    [ObservableProperty] 
    [NotifyCanExecuteChangedFor(nameof(AddItemCommand))] // This attribute will invalidate the command each time this property changes
    private string? _newItemContent;

    
    private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);
    
    [RelayCommand]
    private void RemoveItem(ItemViewModel item)
    {
        // Remove the given item from the list
        ToDoItems.Remove(item);
    }
}