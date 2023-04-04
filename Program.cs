List<persona> listaPersonas = new List<persona>();
int num;
do{
num = pedirNumLista();
opciones(num, listaPersonas);
}while (num != 5);


static void opciones(int num, List<persona> lista)
{
    switch(num)
    {
        case 1:
        string DNI = pedirDni(lista);
        string nombre = pedirCadena("Ingrese el nombre de la persona");
        string apellido = pedirCadena("Ingrese el apellido de la persona");
        string mail = pedirMail("Ingrese el mail de la persona");
        DateTime FN = pedirCumple("Ingrese la fecha de nacimiento de la persona");
        persona pers = new persona(DNI,apellido,nombre,mail,FN);
        lista.Add(pers);
        break;
        case 2:
        int totalEdad,personas;
        personas = lista.Count();
        Console.WriteLine("Hay " + personas + " personas");
        totalEdad = datosLista(lista);
        Console.WriteLine("El promedio de edad es de "+(totalEdad/personas));
        break;
        case 3:

        break;
        case 4:

        break;
        case 5:break;
        default:
        Console.WriteLine("Error, no existe esa ocpion. Vuelva a intentar");
        break;
    }
}
static int datosLista(List<persona> lista)
{
    int devolver = 0,votantes = 0;
    foreach(persona pers in lista)
    {
        devolver += pers.obtenerEdad();
        if(pers.puedeVotar())
        {
            votantes++;
        }
    }
    Console.WriteLine("Hay " + votantes + " personas que pueden votar");
    return devolver;
}
static DateTime pedirCumple(string msj)
{
    DateTime devolver;
    string fecha;
    fecha = pedirCadena(msj);
    while(DateTime.TryParse(fecha, out devolver) == false)
    {
        fecha = pedirCadena("Error, ingrese una fecha");
    }
    return devolver;
}
static string pedirCadena(string msj)
{
    string devolver;
    Console.WriteLine(msj);
    devolver = Console.ReadLine();
    return devolver;
}
static string pedirMail(string msj)
{
    string devolver;
    devolver = pedirCadena(msj);
    while(!devolver.Contains("@") || devolver.Contains("..") || !devolver.Contains("."))
    {
        devolver = pedirCadena("Error, el mail debe contener @ y .");
    }
    return devolver;
}
static string pedirDni(List<persona> lista)
{
    string devolver;
    int desecho;
    do{
        devolver = pedirCadena("Ingrese el DNI de la persona (no puede ser igual a uno ya ingresado)");
        while((devolver.Length < 7 || devolver.Length > 8)|| int.TryParse(devolver, out desecho) == false)
        {
            devolver = pedirCadena("Error, el DNI debe tener 8 caracteres y ser solo numerico");
        }
    }while(!igualDNI(devolver, lista));
    return devolver;
}
static bool igualDNI(string dni, List<persona> lista)
{
    bool devolver = true;
    foreach(persona pers in lista){
        if(pers.DNI==dni)devolver = false;
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
