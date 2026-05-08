using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class ToDoUI
    {
        private readonly TodoService _service = new();

        public void ShowTodos()
        {
            var todos = _service.GetAll();
            Console.WriteLine("=====Danh sách công việc=====");
            foreach (var todo in todos)
            {
                Console.WriteLine(todo.ToString());
            }
            if(todos.Count <=0)
            {
                Console.WriteLine("Không có công việc nào");
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n=====Menu=====");
            Console.WriteLine("1. Thêm công việc");
            Console.WriteLine("2. Đánh dấu đã hoàn thành");
            Console.WriteLine("3. Sửa công việc");
            Console.WriteLine("4. Xóa công việc");
            Console.WriteLine("0. Thoát");
            }
            private void AddTodo()
            {
                Console.Write("Nhập tiêu đề công việc: ");
                var input = Console.ReadLine();
                var todo = _service.AddTodo(input);
                Console.WriteLine($"Đã thêm công việc: {todo}");
            }
            private void DeleteTodo()
            {
                Console.Write("Nhập ID công việc cần xóa: ");
                int id = int.Parse(Console.ReadLine());
                _service.DeleteTodo(id);
                Console.WriteLine("Đã xóa công việc.");
            }
            private void ToggleTodo()
            {
                Console.Write("Nhập ID công việc cần đánh dấu: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (_service.ToggleTodo(id))
                    {
                        Console.WriteLine("Đã cập nhật trạng thái công việc.");
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy công việc với ID đó.");
                    }
                }
                else
                {
                    Console.WriteLine("ID không hợp lệ.");
                }
        }
        public void UpadteTodo() 
        {
            Console.Write("Nhập Id công việc cần cập nhật: ");
            int id= int.Parse(Console.ReadLine());
            Console.Write("Nhập nội dung mới: ");
            string content = Console.ReadLine();
            _service.UpdateTodo(id,content);
        }
        public void Run()
        {
            while (true)
            {
                ShowTodos();
                ShowMenu();
                Console.WriteLine("Chọn :");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        ToggleTodo();
                        break;
                    case "3":
                        UpadteTodo();
                        break;
                    case "4":
                        DeleteTodo();
                        break;
                    case "0":
                        return;

                }
                Console.WriteLine("Nhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
        }
    }
    
}