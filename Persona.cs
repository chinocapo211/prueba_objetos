class persona
{
    public string DNI{get;set;}
    public string apellido{get;set;}
    public string nombre{get;set;}
    public string email{get;set;}
    public DateTime fechaNacimiento{get;set;}
    public persona(string dni, string ap, string nom, string ema, DateTime fn)
    {
        DNI = dni;
        apellido = ap;
        nombre = nom;
        email = ema;
        fechaNacimiento = fn;
    }
    private int obtenerEdad()
    {
        int devolverInt;
        devolverInt = DateTime.Today.Year - fechaNacimiento.Year;
        if(DateTime.Today.Month < fechaNacimiento.Month && DateTime.Today.Day < fechaNacimiento.Day) devolverInt--;
        return devolverInt;
    }
    public bool puedeVotar()
    {
        bool devolverBool = false;
        int edad = obtenerEdad();
        if(edad >= 18)devolverBool = true;
        return devolverBool;
    }
}
