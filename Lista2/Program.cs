using Lista2;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

void ImprimirTarefasPendentes(){

    Console.WriteLine("Selecione uma opção de ordenação:");
    Console.WriteLine("a) Ordem alfabética");
    Console.WriteLine("b) Ordem crescente pelo esforço"); 
    Console.WriteLine("c) Ordem decrescente pelo esforço");
    string opcao = Console.ReadLine();
    var tarefasListaPendente = listaTarefasPendentes.Where(t => t.Finalizado == false);

    switch (opcao){
        case "a":
            tarefasListaPendente = tarefasListaPendente.OrderBy(t => t.Nome);
            break;
        case "b":
            tarefasListaPendente = tarefasListaPendente.OrderBy(t => t.Esforco);
            break;
        case "c":
            tarefasListaPendente = tarefasListaPendente.OrderByDescending(t => t.Esforco);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            return;
    }

    Console.Write("Tarefas pendentes na lista: ");
    foreach (var tarefa in tarefasListaPendente){
        Console.WriteLine($"- {tarefa.Nome} (esforço: {tarefa.Esforco})");
    }

}

void ImprimirTarefasFinalizadas(){
    Console.WriteLine("Selecione uma opção de ordenação:");
    Console.WriteLine("a) Ordem alfabética");
    Console.WriteLine("b) Ordem crescente pelo esforço");
    Console.WriteLine("c) Ordem decrescente pelo esforço");
    string opcao = Console.ReadLine();
    var tarefasListaConcluida = listaTarefasPendentes.Where(t => t.Finalizado == true);

    switch (opcao)
    {
        case "a":
            tarefasListaConcluida = tarefasListaConcluida.OrderBy(t => t.Nome);
            break;
        case "b":
            tarefasListaConcluida = tarefasListaConcluida.OrderBy(t => t.Esforco);
            break;
        case "c":
            tarefasListaConcluida = tarefasListaConcluida.OrderByDescending(t => t.Esforco);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            return;
    }

    Console.Write("Tarefas concluídas na lista: ");
    foreach (var tarefa in tarefasListaConcluida)
    {
        Console.WriteLine($"- {tarefa.Nome} (esforço: {tarefa.Esforco})");
    }

}
