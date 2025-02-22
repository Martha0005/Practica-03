// See https://aka.ms/new-console-template for more information

using System;

class CuentaBancaria
{
    // Atributos
    public string Titular { get; set; }
    public decimal Saldo { get; private set; }

    // Constructor
    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    // Método para depositar dinero
    public void Depositar(decimal monto)
    {
        if (monto > 0)
        {
            Saldo += monto;
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: RD${Saldo:F2}");
        }
        else
        {
            Console.WriteLine("El monto a depositar debe ser positivo.");
        }
    }

    // Método para retirar dinero
    public void Retirar(decimal monto)
    {
        if (monto > 0)
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro exitoso. Nuevo saldo: RD${Saldo:F2}");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes.");
            }
        }
        else
        {
            Console.WriteLine("El monto a retirar debe ser positivo.");
        }
    }

    // Método para mostrar la información de la cuenta
    public void MostrarInformacion()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo: RD${Saldo:F2}");
        Console.WriteLine("--------------------------");
    }
}

class Program
{
    static void Main()
    {
        // Crear cuentas bancarias
        CuentaBancaria cuenta1 = new CuentaBancaria("Penencio Rodríguez", 3000);
        CuentaBancaria cuenta2 = new CuentaBancaria("María López", 5000);

        // Menú de operaciones
        while (true)
        {
            Console.WriteLine("\nMenú de operaciones:");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Retirar");
            Console.WriteLine("3. Mostrar información");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            CuentaBancaria cuentaSeleccionada = null;
            Console.WriteLine("Seleccione una cuenta: 1 (Penencio) o 2 (María)");
            int seleccionCuenta = int.Parse(Console.ReadLine());
            cuentaSeleccionada = (seleccionCuenta == 1) ? cuenta1 : cuenta2;

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el monto a depositar: ");
                    decimal deposito = decimal.Parse(Console.ReadLine());
                    cuentaSeleccionada.Depositar(deposito);
                    break;
                case 2:
                    Console.Write("Ingrese el monto a retirar: ");
                    decimal retiro = decimal.Parse(Console.ReadLine());
                    cuentaSeleccionada.Retirar(retiro);
                    break;
                case 3:
                    cuentaSeleccionada.MostrarInformacion();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
