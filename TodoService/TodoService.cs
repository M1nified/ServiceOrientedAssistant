using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NTodoService
{
    public class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public Todo(string t)
        {
            Text = t;
            Done = false;
        }
    }
    public class TodoService : ITodoService
    {
        public void RememberTodo(string todo)
        {
            using (var db = new LiteDatabase(@"Todo.db"))
            {
                var t = db.GetCollection<Todo>("todo");
                t.Insert(new Todo(todo));
            }
        }

       public string GetTodo()
       {
            string res = "";
            using (var db = new LiteDatabase(@"Todo.db"))
            {
                var t = db.GetCollection<Todo>("todo");
                foreach(var todo in t.FindAll())
                {
                    res += todo.Text + " [" + (todo.Done ? "niezrobione" : "zrobione") + "]\n";
                }
            }
            return res;
        }

        public void MarkDone(int index)
        {
            using (var db = new LiteDatabase(@"Todo.db"))
            {
                var t = db.GetCollection<Todo>("todo");
                Todo x = t.FindById(index);
                x.Done = true;
                t.Update(x);
            }
        }
    }
}
