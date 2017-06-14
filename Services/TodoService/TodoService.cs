using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NTodoService
{
    public class TodoService : ITodoService
    {
        private string _connection = @"C:\tmp\Todo";
        public void RememberTodo(string todo)
        {
            using (var db = new LiteDatabase(_connection))
            {
                var t = db.GetCollection<Todo>("todo");
                t.Insert(new Todo() {
                    Text = todo,
                    Done = false
                });
            }
        }

       public string GetTodo()
       {
            string res = "";
            using (var db = new LiteDatabase(_connection))
            {
                var t = db.GetCollection<Todo>("todo");
                var all = t.FindAll().ToList();
                foreach(var todo in all)
                {
                    res += todo.Text + " [" + (todo.Done ? "zrobione" : "niezrobione") + "]\n";
                }
            }
            return res;
        }

        public void MarkDone(int index)
        {
            using (var db = new LiteDatabase(_connection))
            {
                var t = db.GetCollection<Todo>("todo");
                Todo x = t.FindById(index);
                x.Done = true;
                t.Update(x);
            }
        }
    }
}
