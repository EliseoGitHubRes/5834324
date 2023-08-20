using _5834324.Data;
using _5834324.Models;

namespace _5834324.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
    TodoItem item;
    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }
    TodoItemDatabase database;
	public TodoItemPage(TodoItemDatabase todoItemDatabase)
	{
		InitializeComponent();
        database = todoItemDatabase;
	}

    async void OnSave_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name fot the todo item.", "OK");
        }
        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDelete_Clicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}