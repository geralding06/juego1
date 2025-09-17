using System;

class Program
{
    static void Main()
    {
        // 1. Solicitar el número máximo al usuario
        Console.WriteLine("¡Bienvenido al juego de adivinar el número!");
        Console.Write("Por favor, ingresa el número máximo para el rango (debe ser mayor que 0): ");
        
        // Leer el número máximo que ingresa el usuario
        string input = Console.ReadLine();
        int numeroMaximo;
        
        // Verificar si el usuario ingresó un número válido
        bool esNumeroValido = int.TryParse(input, out numeroMaximo);

        // 2. Validar que el número sea mayor que cero
        if (!esNumeroValido || numeroMaximo <= 0)
        {
            Console.WriteLine("Error: El número máximo debe ser mayor que cero. No se puede jugar.");
            return; // Terminar el programa
        }

        // 3. Calcular un número aleatorio entre 0 y el número máximo
        Random random = new Random();
        int numeroSecreto = random.Next(0, numeroMaximo + 1);
        
        Console.WriteLine($"¡He generado un número secreto entre 0 y {numeroMaximo}!");

        // 4. Pedir al usuario que adivine el número
        Console.Write("¿Cuál crees que es el número secreto? ");
        string intentoInput = Console.ReadLine();
        int intentoUsuario;
        
        // Verificar si el intento es un número válido
        bool esIntentoValido = int.TryParse(intentoInput, out intentoUsuario);

        // 5. Mostrar si ganó o perdió
        if (!esIntentoValido)
        {
            Console.WriteLine("Error: Debes ingresar un número válido.");
        }
        else if (intentoUsuario == numeroSecreto)
        {
            Console.WriteLine("¡Felicidades! ¡Has adivinado el número! 🎉");
            Console.WriteLine($"El número secreto era: {numeroSecreto}");
        }
        else
        {
            Console.WriteLine("¡Lo siento! No has adivinado el número. 😢");
            Console.WriteLine($"El número secreto era: {numeroSecreto}");
            Console.WriteLine($"Tu intento fue: {intentoUsuario}");
        }

        Console.WriteLine("¡Gracias por jugar!");
    }
}