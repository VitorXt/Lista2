using Lista2;
using System.Linq.Expressions;

List<Tarefa> listaTarefasPendentes = new List<Tarefa>();

    int opcao = 0;

    while (opcao != 6)
    {
        Console.WriteLine();
        Console.WriteLine("Menu de Opções:");
        Console.WriteLine();
        Console.WriteLine("1) Inserir nova tarefa na lista");
        Console.WriteLine("2) Marcar Tarefa como feita");
        Console.WriteLine("3) Remover uma tarefa da lista");
        Console.WriteLine("4) Imprimir lista de tarefas pendentes");
        Console.WriteLine("   a. Imprimir em ordem alfabética");
        Console.WriteLine("   b. Imprimir em ordem crescente pela propriedade esforço");
        Console.WriteLine("   c. Imprimir em ordem decrescente pela propriedade esforço");
        Console.WriteLine("5) Imprimir lista de tarefas finalizadas");
        Console.WriteLine("   a. Imprimir em ordem alfabética");
        Console.WriteLine("   b. Imprimir em ordem crescente pela propriedade esforço");
        Console.WriteLine("   c. Imprimir em ordem decrescente pela propriedade esforço");
        Console.WriteLine("6) Sair");
        Console.WriteLine();
        Console.Write("Selecione uma opção: ");
        
        opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                InserirTarefa();
                break;
            case 2:
                MarcarTarefaComoFeita();
                break;
            case 3:
                RemoverTarefa();
                break;
            case 4:
                ImprimirTarefasPendentes();
                break;
            case 5:
                ImprimirTarefasFinalizadas();
                break;
            case 6:
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }

        Console.WriteLine();
    }
void InserirTarefa()
{
    Console.Write("Digite o nome da tarefa: ");
    string nome = Console.ReadLine();

    if (listaTarefasPendentes.Exists(t => t.Nome == nome))
    {
        Console.WriteLine("Já existe tarefa com esse mesmo nome na lista, operação não pode ser realizada");
        return;
    }

    Console.Write("Digite o esforço da tarefa (em horas): ");
    int esforco = int.Parse(Console.ReadLine());

    Tarefa tarefa = new Tarefa { Nome = nome, Esforco = esforco };
    listaTarefasPendentes.Add(tarefa);

    Console.WriteLine("Tarefa adicionada com sucesso!");
}

void MarcarTarefaComoFeita()
{
    Console.Write("Digite o nome da tarefa que foi concluída: ");
    string nome = Console.ReadLine();

    Tarefa tarefa = listaTarefasPendentes.Find(t => t.Nome == nome);

    if (tarefa == null)
    {
        Console.WriteLine("Não foi encontrada nenhuma tarefa com esse nome!");
        return;
    }

    tarefa.Finalizado = true;

    Console.WriteLine("Tarefa marcada como feita!");
}

void RemoverTarefa()
{
    Console.Write("Digite o nome da tarefa que quer remover: ");
    string nome = Console.ReadLine();

    Tarefa tarefa = listaTarefasPendentes.Find(t => t.Nome == nome);

    listaTarefasPendentes.Remove(listaTarefasPendentes.Find(t => t.Nome == nome));

    if (tarefa == null)
    {
        Console.WriteLine("Não foi encontrada nenhuma tarefa com esse nome!");
        return;
    }

    Console.WriteLine("Tarefa removida!");

}

void ImprimirTarefasPendentes()
{
    Console.Write("Tarefas na lista: ");
}

void ImprimirTarefasFinalizadas()
{

}
