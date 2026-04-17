Console.WriteLine("ingrese los datos del paciente");
Console.WriteLine();
Console.Write("ingrese Nombre: ");
string nombre=Console.ReadLine();
Console.Write("numero de DPI: ");
long dpi = long.Parse(Console.ReadLine());
Console.Write("numero de telefono: ");
int telefono=int.Parse(Console.ReadLine());
Console.Write("edad: ");
int edad=int.Parse(Console.ReadLine());

int cantidad=dpi.ToString().Length;
Paciente p1 = new Paciente(nombre,dpi,telefono,edad);

p1.mostrarPaciente();
class Paciente
{
	private string nombre;
	private long dpi;
	private int telefono;
	private int edad;

	public int Edad
	{
		get { return edad; }
		set 
		{
			if (value >= 0) edad = value;
			else Console.WriteLine("edad no valida");
		}
	}


	public int Telefono
	{
		get { return telefono; }
		set 
		{ 
			int cantidad=value.ToString().Length;
			if (cantidad == 8) telefono = value;
			else Console.WriteLine("numero de telefono no valido");
		}
	}

	public long Dpi
	{
		get { return dpi; }
		set 
		{
			int cantidad=value.ToString().Length;
			if (cantidad == 13) dpi = value;
			else Console.WriteLine("el DPI no contiene 13 digitos");
		}
	}

	public string Nombre
	{
		get { return nombre; }
		set 
		{
			if (value.Length > 2) nombre = value;
			else Console.WriteLine("el nombre debe contener al menos 3 caracteres");
		}
	}

	public Paciente(string Nombre, long Dpi, int Telefono, int Edad)
    {
        this.Nombre = Nombre;
        this.Dpi = dpi;
        this.Telefono = Telefono;
        this.Edad = Edad;
    }

	public void mostrarPaciente()
	{
		Console.WriteLine("nombre del paciente: "+Nombre);
		Console.WriteLine("Dpi: "+Dpi);
		Console.WriteLine("Numero de Telefono: "+ Telefono);
		Console.WriteLine("edad del paciente: "+Edad);
	}
}