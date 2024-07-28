using System;

namespace ProjetoGestaoTarefas.Repositories
{
    public interface ITaskRepository{
            void Add(Task task);
            void Remove(int id);
            void Update(Task task);

            Task GetById(int id);
            IEnumerable<Task> GetAll();

    }
}