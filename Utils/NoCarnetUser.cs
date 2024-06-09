namespace Biblioteca.Utils;

public static partial class NoCarnetUser
{

    public static string GenerarCode()
    {
        Random rnd = new Random();
        string numeros = "";
        for (int i = 0; i < 6; i++)
        {
            numeros += rnd.Next(0, 10); // Genera un número aleatorio entre 0 y 9
        }
        int añoActual = DateTime.Now.Year;
        return $"A{numeros}-{añoActual}";
    }

}


