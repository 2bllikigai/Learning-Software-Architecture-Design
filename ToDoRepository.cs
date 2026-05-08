using System;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRepository
    {
        private readonly List<ToDo> _todos = new();
        private string _filePath = "todos.txt";
        private int _nextId = 1;
        public TodoRepository()
        {
            LoadFromFile();
        }
        private void LoadFromFile()
        {
            if (!File.Exists(_filePath)) return;
            
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var todo = ToDo.FromFileString(line);
                _todos.Add(todo);
                if (todo.Id >= _nextId)
                    _nextId = todo.Id++;
            }

        }
        private void SaveChanges()
        {
            var lines = _todos.Select(t => t.ToFileString()).ToArray();
            File.WriteAllLines(_filePath, lines);
        }
        public ToDo CreateTodo(string title)
        {
            var todo = new ToDo()
            {
                Id = _nextId++,
                Title = title,
                IsSuccess = false,
            };
            _todos.Add(todo);
            SaveChanges();
            return todo;
        }
        public bool UpdateTodo(int id, string title)
        {
           var item = _todos.FirstOrDefault(x => x.Id == id);
           if(item != null)
           {
                item.Title = title;
                SaveChanges();
                return true;
           }
           return false;
        }
         public bool DeleteTodo(int id)
        {
           var item = _todos.FirstOrDefault(x => x.Id == id);
           if(item != null)
           {
                _todos.Remove(item);
                SaveChanges();
                return true;
           }
           return false;
        }
        public List<ToDo> GetAll() => _todos;
        public bool ToggleTodo(int id)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                item.IsSuccess = !item.IsSuccess;
                SaveChanges();
                return true;
            }
            return false;
        }

    }
}