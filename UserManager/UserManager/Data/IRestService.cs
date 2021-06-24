using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TodoREST
{
	public interface IRestService
	{
		Task<ObservableCollection<TodoItem>> RefreshDataAsync ();

		Task SaveTodoItemAsync (TodoItem item, bool isNewItem);

		Task DeleteTodoItemAsync (string id);
	}
}
