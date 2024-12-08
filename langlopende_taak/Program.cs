using langlopende_taak;

class Program
{
    static void Main(string[] args)
    {
        IPokemon pikachu = new Pokemon("Pikachu", 100, 20);
        IPokemon charmander = new Pokemon("Charmander", 80, 15);

        Console.WriteLine($"{pikachu.Name} vs {charmander.Name}");
        Console.WriteLine($"{pikachu.Name}: {pikachu.Health} HP");
        Console.WriteLine($"{charmander.Name}: {charmander.Health} HP");

        Console.WriteLine("\n--- Battle Start! ---\n");

        while (!pikachu.IsFainted && !charmander.IsFainted)
        {
            pikachu.Attack(charmander);
            Console.WriteLine($"{pikachu.Name} attacks {charmander.Name}! {charmander.Name} has {charmander.Health} HP left.");

            if (charmander.IsFainted) break;

            charmander.Attack(pikachu);
            Console.WriteLine($"{charmander.Name} attacks {pikachu.Name}! {pikachu.Name} has {pikachu.Health} HP left.");
        }

        Console.WriteLine("\n--- Battle Over! ---\n");

        if (pikachu.IsFainted)
            Console.WriteLine($"{pikachu.Name} has fainted. {charmander.Name} wins!");
        else
            Console.WriteLine($"{charmander.Name} has fainted. {pikachu.Name} wins!");
    }
}