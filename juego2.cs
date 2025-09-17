using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool jugarDeNuevo = true;
        
        while (jugarDeNuevo)
        {
            Console.Clear();
            Console.WriteLine("¡BIENVENIDO AL JUEGO DE ADIVINAR EL NÚMERO - VERSIÓN 2!");
            Console.WriteLine("=============================================================");
            
            // Solicitar número máximo con validación
            int numeroMaximo = SolicitarNumeroMaximo();
            if (numeroMaximo == -1) continue; // Si el usuario quiere salir
            
            // Seleccionar nivel de dificultad
            int maxIntentos = SeleccionarDificultad();
            if (maxIntentos == -1) continue; // Si el usuario quiere salir
            
            // Generar número secreto
            Random random = new Random();
            int numeroSecreto = random.Next(0, numeroMaximo + 1);
            
            Console.WriteLine($"\n¡He generado un número secreto entre 0 y {numeroMaximo}!");
            Console.WriteLine($"Tienes {maxIntentos} intentos. ¡Buena suerte!");
            
            // Lista para guardar los intentos
            List<int> intentos = new List<int>();
            bool haGanado = false;
            
            // Bucle principal del juego
            for (int intento = 1; intento <= maxIntentos; intento++)
            {
                Console.WriteLine($"\n--- Intento {intento} de {maxIntentos} ---");
                
                // Pedir número al usuario
                int numeroUsuario = SolicitarNumeroUsuario(intento, maxIntentos, numeroMaximo);
                if (numeroUsuario == -1) break; // Si el usuario quiere salir
                
                // Agregar a la lista de intentos
                intentos.Add(numeroUsuario);
                
                // Verificar si acertó
                if (numeroUsuario == numeroSecreto)
                {
                    haGanado = true;
                    break;
                }
                else
                {
                    // Dar pista
                    if (numeroUsuario < numeroSecreto)
                    {
                        Console.WriteLine("El número secreto es MAYOR");
                    }
                    else
                    {
                        Console.WriteLine("El número secreto es MENOR");
                    }
                    
                    // Mostrar intentos anteriores
                    if (intentos.Count > 1)
                    {
                        Console.WriteLine("Tus intentos anteriores: " + string.Join(", ", intentos));
                    }
                }
            }
            
            // Mostrar resultado final
            MostrarResultado(haGanado, numeroSecreto, intentos);
            
            // Preguntar si quiere jugar de nuevo
            jugarDeNuevo = PreguntarJugarDeNuevo();
        }
        
        Console.WriteLine("\n¡Gracias por jugar!");
    }
    
    static int SolicitarNumeroMaximo()
    {
        while (true)
        {
            Console.Write("\nIngresa el número máximo (o 'S' para salir): ");
            string input = Console.ReadLine()?.Trim().ToUpper();
            
            if (input == "S")
            {
                return -1; // Código para salir
            }
            
            if (int.TryParse(input, out int numero) && numero > 0)
            {
                return numero;
            }
            
            Console.WriteLine("Error: Debe ser un número entero mayor que 0. Intenta de nuevo.");
        }
    }
    
    static int SeleccionarDificultad()
    {
        Console.WriteLine("\nSelecciona el nivel de dificultad:");
        Console.WriteLine("1️⃣  Nivel 1 - 10 intentos (Fácil)");
        Console.WriteLine("2️⃣  Nivel 2 - 5 intentos (Medio)");
        Console.WriteLine("3️⃣  Nivel 3 - 3 intentos (Difícil)");
        
        while (true)
        {
            Console.Write("Elige (1-3) o 'S' para salir: ");
            string input = Console.ReadLine()?.Trim().ToUpper();
            
            if (input == "S")
            {
                return -1; // Código para salir
            }
            
            switch (input)
            {
                case "1": return 10;
                case "2": return 5;
                case "3": return 3;
                default:
                    Console.WriteLine("Error: Opción no válida. Elige 1, 2, 3 o 'S' para salir.");
                    break;
            }
        }
    }
    
    static int SolicitarNumeroUsuario(int intentoActual, int maxIntentos, int numeroMaximo)
    {
        while (true)
        {
            Console.Write($"Intento {intentoActual}/{maxIntentos} - Adivina el número (0-{numeroMaximo}) o 'S' para salir: ");
            string input = Console.ReadLine()?.Trim().ToUpper();
            
            if (input == "S")
            {
                return -1; // Código para salir
            }
            
            if (int.TryParse(input, out int numero))
            {
                if (numero >= 0 && numero <= numeroMaximo)
                {
                    return numero;
                }
                else
                {
                    Console.WriteLine($"Error: El número debe estar entre 0 y {numeroMaximo}.");
                }
            }
            else
            {
                Console.WriteLine("Error: Debe ser un número válido o 'S' para salir.");
            }
        }
    }
    
    static void MostrarResultado(bool haGanado, int numeroSecreto, List<int> intentos)
    {
        Console.WriteLine("\n" + new string('=', 40));
        
        if (haGanado)
        {
            Console.WriteLine("¡FELICIDADES! ¡HAS GANADO!");
        }
        else
        {
            Console.WriteLine("¡LO SIENTO! HAS PERDIDO ");
        }
        
        Console.WriteLine($"El número secreto era: {numeroSecreto}");
        Console.WriteLine($"Tus intentos: {string.Join(" → ", intentos)}");
        Console.WriteLine($"Total de intentos: {intentos.Count}");
        
        Console.WriteLine(new string('=', 40));
    }
    
    static bool PreguntarJugarDeNuevo()
    {
        while (true)
        {
            Console.Write("\n¿Quieres jugar de nuevo? (S/N): ");
            string respuesta = Console.ReadLine()?.Trim().ToUpper();
            
            if (respuesta == "S") return true;
            if (respuesta == "N") return false;
            
            Console.WriteLine("Error: Responde 'S' para Sí o 'N' para No");
        }
    }
}