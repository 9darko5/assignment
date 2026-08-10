namespace Assignment.ToDo
{
    public class ToDoItem
    {
        public ToDoItem(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public string Name { get; }
        public int Priority { get; }

        public string PriorityColor
        {
            get
            {
                switch (Priority)
                {
                    case 1: return "Red";
                    case 2: return "Yellow";
                    default: return "Green";
                }
            }
        }
    }
}