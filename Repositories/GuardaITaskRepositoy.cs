
using System.Collections.Generic;
using System.Linq;

namespace ProjetoGestaoTarefas.Repositories
{
    public class GuardarITaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks = new();
        private int _nextId =  1;

        public void Add(Task task){
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public void Remove(int id){
            var task = _tasks.SingleOrDefault(t => t.Id == id);
            if(task != null)
            {
                _tasks.Remove(task);
            }
        }   

        public void Update(Task task)
        {
            var taskExistente = _tasks.SingleOrDefault(t => t.Id == task.Id);
            if(taskExistente != null){
                taskExistente.Title = task.Title;
                taskExistente.Description = task.Description;
                taskExistente.DueDate = task.DueDate;
                taskExistente.Priority = task.Priority;
            }
        }

        public Task GetById(int id)
        {
            return _tasks.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<Task> GetAll(){
            return _tasks;
        }

    }
}