using System.ServiceModel;

namespace NTodoService
{
     [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        void RememberTodo(string todo);

        [OperationContract]
        string GetTodo();

        [OperationContract]
        void MarkDone(int index);
    }

}
