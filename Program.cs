using System;
using System.Data.Common;
using ProjetoGestaoTarefas.Repositories;
using ProjetoGestaoTarefas.Services;

namespace ProjetoGestaoTarefas
{
    class Program
    {
        private static TaskService _taskService;
        static void Main(string[] args){


            ITaskRepository taskRepository = new GuardarITaskRepository();

            _taskService = new TaskService(taskRepository);

            Console.WriteLine("Gerenciador De Tarefas");
            while(true)
            {
                Console.WriteLine("1 - Adicionar Tarefa");
                Console.WriteLine("2 - Remover Tarefa");
                Console.WriteLine("3 - Atualizar Tarefa");
                Console.WriteLine("4 - Listar As Tarefas");
                Console.WriteLine("5 - Sair");
                Console.WriteLine(":");
                var opcao = Console.ReadLine();

                switch(opcao)
                {

                    case "1":
                        AddTask();
                        break;
                    case "2":
                        RemoveTask();
                        break;
                    case "3":
                        UpdateTask();
                        break;
                    case "4":
                        ListTask();
                        break;
                    case "5":
                        return;
                        

                }
            }

        }

        
         private static void AddTask()
        {
            Console.WriteLine("Titulo da tarefa:");
            var title =  Console.ReadLine();
            Console.WriteLine("Descrição da tarefa:");
            var description =  Console.ReadLine();
            Console.WriteLine("Data:");
            var dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Prioridade S/N: ");
            var priority = Console.ReadLine();

            _taskService.Addtask(title,description,dueDate,priority);
            Console.WriteLine("Tarefa Adicionada com sucesso!!!");
        }

        private static void RemoveTask()
        {
            Console.WriteLine("Digite o Id da Tarefa: ");
            var id = int.Parse(Console.ReadLine());
            _taskService.RemoveTask(id);
            Console.WriteLine("Tarefa Removida com Sucesso!!");
        }
        
        private static void UpdateTask()
        {
            Console.WriteLine("Digite o ID da tarefa pra atualizar: ");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Novo Titulo da tarefa:");
            var title =  Console.ReadLine();
            Console.WriteLine("Nova Descrição da tarefa:");
            var description =  Console.ReadLine();
            Console.WriteLine("Nova Data:");
            var dueDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Prioridade S/N: ");
            var priority = Console.ReadLine();

            _taskService.Updatetask(id,title,description,dueDate,priority);
            Console.WriteLine("Tarefa Atualizada com Sucesso!!!");
        }

        private static void ListTask()
        {
            var tasks = _taskService.GetAllTask();
            foreach(var task in tasks){
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title},Descrição: {task.Description}, Data: {task.DueDate.ToShortDateString()},Prioridade: {task.Priority}"); 
            }
        }
        
        
    }
}
