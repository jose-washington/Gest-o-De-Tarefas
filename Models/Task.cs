using System;

namespace ProjetoGestaoTarefas
{
    public class Task{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }

        public DateTime DueDate{get;set;}

        public string Priority{ get; set; }

    }
}