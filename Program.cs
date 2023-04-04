List<persona> listaPersonas = new List<persona>();
int num;
do{
num = pedirNumLista();
opciones(num, listaPersonas);
}while (num != 5);


static void opciones(int num, List<persona> lista)
{
    bool exists;
    switch(num)
    {
        case 1:
        exists = false;
        string DNI = pedirDni(lista);
        string nombre = pedirCadena("Ingrese el nombre de la persona");
        string apellido = pedirCadena("Ingrese el apellido de la persona");
        string mail = pedirMail("Ingrese el mail de la persona");
        DateTime FN = pedirCumple("Ingrese la fecha de nacimiento de la persona");
        foreach(persona per in lista)
        {
            if(per.DNI == DNI)
            {
                per.DNI = DNI;
                per.nombre = nombre;
                per.email = mail;
                per.apellido = apellido;
                per.fechaNacimiento = FN;
                exists = true;
            }
        }
        if(!exists)
        {
            persona persona = new persona(DNI,apellido,nombre,mail,FN);
            lista.Add(persona);
        }
        
        break;
        case 2:
        int totalEdad=0,personas=lista.Count(),votantes = 0;
        foreach(persona pers in lista){
            totalEdad += pers.obtenerEdad();
            if(pers.puedeVotar()){
                votantes++;
            }
        }
        Console.WriteLine("Hay " + personas + " personas");
        Console.WriteLine("Hay " + votantes + " personas que pueden votar");
        Console.WriteLine("El promedio de edad es de "+(totalEdad/personas));
        break;
        case 3:
        exists=false;
        DNI = pedirCadena("Ingrese un DNI para buscar");
        foreach(persona per in lista){
            if(per.DNI == DNI){
                Console.WriteLine("DNI: "+per.DNI);
                Console.WriteLine("Nombre: "+per.nombre);
                Console.WriteLine("Apellido: "+per.apellido);
                Console.WriteLine("Mail: "+per.email);
                Console.WriteLine("Fecha de nacimiento: "+per.fechaNacimiento);
                Console.WriteLine("Edad: "+per.obtenerEdad());
                Console.WriteLine("Puede votar: "+per.puedeVotar());
                exists=true;
            }
        }
        if(!exists)Console.WriteLine("Error, ese parametro de dni no existe");
        break;
        case 4:
        exists=false;
        DNI = pedirCadena("Ingrese un DNI a buscar");
        foreach(persona per in lista){
            if(per.DNI == DNI)per.email=pedirMail("Ingrese el nuevo mail");
            exists=true;
        }
        if(!exists)Console.WriteLine("Error, ese parametro de dni no existe");
        break;
        case 5:break;
        default:
        Console.WriteLine("Error, no existe esa ocpion. Vuelva a intentar");
        break;
    }
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
    devolver = pedirCadena("Ingrese el DNI de la persona");
    while((devolver.Length < 7 || devolver.Length > 8)|| int.TryParse(devolver, out desecho) == false)
    {
        devolver = pedirCadena("Error, el DNI debe tener 8 caracteres y ser solo numérico");
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