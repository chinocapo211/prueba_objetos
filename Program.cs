static void opciones(int num)
{
    switch(num)
    {
        case 1:
        string DNI = pedirDni();
        string nombre = pedirCadena("Ingrese el nombre de la persona");
        string apellido = pedirCadena("Ingrese el apellido de la persona");
        
        break;
        case 2:

        break;
        case 3:

        break;
        case 4:

        break;
        case 5:

        break;
    }
}
static string pedirCadena(string msj)
{
    string devolver;
    Console.WriteLine(msj);
    devolver = Console.ReadLine();
    return devolver;
}
static string pedirDni()
{
    string devolver;
    int desecho;
    devolver = pedirCadena("Ingrese el DNI de la persona");
    while((devolver.Length < 7 || devolver.Length > 8)|| int.TryParse(devolver, out desecho) == false)
    {
        devolver = pedirCadena("Error, el DNI debe tener 8 caracteres y ser solo numerico");
    }
    return devolver;
}
static int pedirNumLista()
{
    int devolver;
    Console.WriteLine("1.Cargar nueva persona \n2.Obtener estadisticas \n3.Buscar persona \n4.Modificar mail de una persona \n5.Salir");
    devolver = int.Parse(Console.ReadLine());
    return devolver;
}
List<persona> listaPersonas = new List<persona>();
int num;
do{
num = pedirNumLista();
opciones(num);
}while (num != 5);