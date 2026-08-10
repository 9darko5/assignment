using Assignment.ToDo;
using System.Collections.ObjectModel;

namespace Assignment.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ToDoListViewModel()
        {
            ToDoSubmitViewModel = new ToDoSubmitViewModel(AddItem);
        }

        public ToDoSubmitViewModel ToDoSubmitViewModel { get; }
        public ObservableCollection<ToDoItem> Items { get; } = new ObservableCollection<ToDoItem>();

        private void AddItem(string name, int priority)
        {
            var item = new ToDoItem(name, priority);
            var insertIndex = 0;

            while (insertIndex < Items.Count && Items[insertIndex].Priority <= priority)
            {
                insertIndex++;
            }

            Items.Insert(insertIndex, item);
        }
    }
}