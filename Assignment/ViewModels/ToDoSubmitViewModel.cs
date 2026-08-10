using Assignment.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class ToDoSubmitViewModel : ViewModelBase
    {
        private readonly Action<string, int> _submitItem;
        private string _itemName;
        private int _selectedPriority;

        public ToDoSubmitViewModel(Action<string, int> submitItem)
        {
            _submitItem = submitItem;
            SubmitCommand = new RelayCommand(SubmitItem);
            Priorities = new List<int> { 1, 2, 3 };
            SelectedPriority = 1;
        }

        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }

        public int SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
            }
        }

        public List<int> Priorities { get; }
        public ICommand SubmitCommand { get; }

        private void SubmitItem(object obj)
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                return;
            }

            _submitItem(ItemName.Trim(), SelectedPriority);
            ItemName = string.Empty;
            SelectedPriority = 1;
        }
    }
}