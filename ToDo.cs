using System;
namespace TodoApp
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsSuccess { get; set; }
        public override string ToString()
        {
            return $"[{(IsSuccess ? "x" : " ")}]{Id}: {Title}";
        }
        public string ToFileString(){
            return $"{Id};{IsSuccess};{Title}";
        }
        public static ToDo FromFileString(string line){
            var parts = line.Split(';');
            return new ToDo{
                Id = int.Parse(parts[0]),
                IsSuccess = bool.Parse(parts[1]),
                Title = parts[2],
            };
        }
    }
}
