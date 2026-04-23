using System;
using System.IO;

bool error=false; long dpi; int telefono,edad; string nombre,respuesta;

string ruta = Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
          "pacientes.txt"
      );

do
{

	do
	{
		Console.WriteLine("ingrese los datos del paciente");
		Console.WriteLine();
		Console.Write("ingrese Nombre: ");
		nombre = Console.ReadLine();

		do
		{
			Console.Write("numero de DPI: ");
			error = long.TryParse(Console.ReadLine(), out dpi);
		} while (!error);

		do
		{
			Console.Write("numero de telefono: ");
			error = int.TryParse(Console.ReadLine(), out telefono);
		} while (!error);

		do
		{
			Console.Write("edad: ");
			error = int.TryParse(Console.ReadLine(), out edad);
		} while (!error);
		try
		{
			Paciente p1 = new Paciente(nombre, dpi, telefono, edad);
			Console.WriteLine();
			p1.GuardarEnArchivo(ruta);
			p1.mostrarPaciente();
			error = true;
		}
		catch (Exception ex)
		{
			Console.WriteLine();
			Console.WriteLine(ex.Message);
			Console.WriteLine("presione Enter para continuar");
			Console.ReadLine();
			Console.Clear();
			error = false;
		}
	} while (!error);

	Console.WriteLine();
	do
	{
		Console.WriteLine("desea ingresar otro Paciente: ");
		respuesta= Console.ReadLine();
	} while (respuesta!="si" && respuesta!="no");

	if (respuesta == "si") Console.Clear();

} while (respuesta=="si");

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
			else throw new Exception("edad no valida");

		}
	}


	public int Telefono
	{
		get { return telefono; }
		set 
		{ 
			int cantidad=value.ToString().Length;
			if (cantidad == 8) telefono = value;
			else throw new Exception("numero de telefono no valido");
		}
	}

	public long Dpi
	{
		get { return dpi; }
		set 
		{
			int cantidad = value.ToString().Length;
			if (cantidad==13) dpi = value;
			else throw new Exception("el DPI no contiene 13 digitos ");
		}
	}

	public string Nombre
	{
		get { return nombre; }
		set 
		{
			if (value.Length > 2) nombre = value;
			else if(value.Length<2 || string.IsNullOrEmpty(value)) throw new Exception("el nombre debe contener al menos 3 caracteres");
		}
	}

	public Paciente(string Nombre, long Dpi, int Telefono, int Edad)
    {
        this.Nombre = Nombre;
        this.Dpi = Dpi;
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

	public string ObtenerDatos()
	{
		return "Nombre: " + Nombre + Environment.NewLine +
			   "DPI: " + Dpi + Environment.NewLine +
			   "Telefono: " + Telefono + Environment.NewLine +
			   "edad: " + edad + Environment.NewLine+
			   "____________________________________"+Environment.NewLine;
	}
    public void GuardarEnArchivo(string ruta)
    {
        File.AppendAllText(ruta, ObtenerDatos());
    }
}