using System;

// Definición de la clase base abstracta 'Juego'
public abstract class Juego
{
    // Método abstracto para jugar, cada juego que herede de esta clase debe implementarlo de manera específica.
    public abstract string Jugar();

    // Método abstracto para reiniciar el juego, también debe ser implementado por cada juego concreto.
    public abstract void Reiniciar();
}

// Clase concreta 'JuegoAdivina' que hereda de la clase 'Juego'
public class JuegoAdivina : Juego
{
    private int numeroAdivinanza; // Variable para almacenar el número que se debe adivinar.
    public int intentos { get; set; } // Propiedad para contar los intentos realizados por el jugador.

    // Constructor de la clase 'JuegoAdivina' que recibe el rango máximo para la adivinanza.
    public JuegoAdivina(int rangoMaximo)
    {
        Random random = new Random();
        numeroAdivinanza = random.Next(1, rangoMaximo + 1); // Genera un número aleatorio dentro del rango.
        intentos = 0; // Inicializa el contador de intentos.
    }

    // Implementación del método abstracto 'Jugar' de la clase base 'Juego'
    public override string Jugar()
    {
        intentos++; // Incrementa el contador de intentos.

        Console.Write("Ingresa un número: ");
        if (int.TryParse(Console.ReadLine(), out int numeroIngresado))
        {
            if (numeroIngresado == numeroAdivinanza)
            {
                return "¡Felicitaciones! Has adivinado el número en " + intentos + " intentos.";
            }
            else if (numeroIngresado < numeroAdivinanza)
            {
                return "Intenta con un número mayor.";
            }
            else
            {
                return "Intenta con un número menor.";
            }
        }
        else
        {
            return "Ingresa un número válido.";
        }
    }

    // Implementación del método abstracto 'Reiniciar' de la clase base 'Juego'
    public override void Reiniciar()
    {
        Random random = new Random();
        numeroAdivinanza = random.Next(1, 101); // Genera un nuevo número a adivinar.
        intentos = 0; // Reinicia el contador de intentos.
    }
}

// Clase 'Jugador' para almacenar el nombre del jugador.
public class Jugador
{
    public string Nombre { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido a los Juegos!");

        Console.Write("Ingresa tu nombre: ");
        string nombreJugador = Console.ReadLine();

        Jugador jugador = new Jugador { Nombre = nombreJugador };

        bool juegoTerminado = false;

        while (!juegoTerminado)
        {
            Console.WriteLine("Elige un juego:");
            Console.WriteLine("1. Juego de Adivinanza");
            Console.WriteLine("2. Otro juego (en Desarrollo)");
            Console.WriteLine("0. Salir");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Juego juegoAdivina = new JuegoAdivina(100); // Crea una instancia del juego de adivinanza
                        JugarJuego(juegoAdivina); // Llama a la función para jugar
                        break;
                    case 2:
                        // Puedes agregar más casos para otros juegos aquí
                        Console.WriteLine("Estamos desarrollando mas juegos... ;)");
                        break;
                    case 0:
                        juegoTerminado = true; // Finaliza el programa
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ingresa un número válido.");
            }
        }

        Console.WriteLine("Gracias por jugar, " + jugador.Nombre + ". ¡Hasta la próxima!");
    }

    // Función para jugar un juego específico
    static void JugarJuego(Juego juego)
    {
        bool juegoTerminado = false;

        while (!juegoTerminado)
        {
            string resultado = juego.Jugar(); // Llama al método 'Jugar' del juego
            Console.WriteLine(resultado);

            if (resultado.Contains("¡Felicitaciones!"))
            {
                Console.Write("¿Quieres jugar otra vez? (s/n): ");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "s")
                {
                    juego.Reiniciar(); // Reinicia el juego si el jugador quiere jugar de nuevo
                }
                else
                {
                    juegoTerminado = true; // Finaliza el juego
                }
            }
        }
    }
}
