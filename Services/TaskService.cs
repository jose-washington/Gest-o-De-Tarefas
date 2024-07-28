using System.Collections.Generic;
using ProjetoGestaoTarefas.Repositories;

namespace ProjetoGestaoTarefas.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Addtask(string title,string description, DateTime dueDate, string Priority)
        {
            var task = new Task
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = Priority
            };

            _taskRepository.Add(task);
        }

        public void RemoveTask(int id)
        {
            _taskRepository.Remove(id);
        }

         public void Updatetask(int id, string title,string description, DateTime dueDate, string Priority)
        {
            var task = new Task
            {
                Id = id,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = Priority
            };

            _taskRepository.Update(task);
        }

        public Task GetTaskById(int id){
            return _taskRepository.GetById(id);
        }

        public IEnumerable<Task> GetAllTask()
        {
            return _taskRepository.GetAll();
        }

    }
}