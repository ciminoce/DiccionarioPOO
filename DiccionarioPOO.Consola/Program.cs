using System;
using System.Collections.Generic;
using System.Linq;
using DiccionarioPOO.Entidades;

namespace DiccionarioPOO.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dictionaries!");
            var agenda = new Dictionary<string, Persona>();
            var persona1 = new Persona() { Nombre = "Jon", Apellido = "Anderson", Telefono = "15416770" };
            var persona2 = new Persona() { Nombre = "Chris", Apellido = "Squire", Telefono = "15444444" };
            var persona3 = new Persona() { Nombre = "Alan", Apellido = "White", Telefono = "15467199" };
            agenda.Add(persona1.Telefono,persona1);
            agenda.Add(persona2.Telefono, persona2);
            agenda.Add(persona3.Telefono,persona3);
            var persona4 = new Persona() { Nombre = "Rick", Apellido = "Wakeman", Telefono = "15467199" };
            if (!agenda.ContainsKey(persona4.Telefono))
            {
                agenda.Add(persona4.Telefono,persona4);
            }
            else
            {
                Console.WriteLine($"Ya existe una persona con la clave {persona4.Telefono}");
            }

            foreach (var contacto in agenda)
            {
                Console.WriteLine($"La persona {contacto.Value.MostrarDatos()} tiene como clave {contacto.Key}");
            }
            

            foreach (var clave in agenda.Keys)
            {
                Console.WriteLine($"Clave={clave}");
            }

            foreach (var persona in agenda.Values)
            {
                Console.WriteLine($"Persona:{persona.MostrarDatos()}");
            }
            var persona5 = new Persona() { Nombre = "Alan", Apellido = "White", Telefono = "422230" };
            if (agenda.ContainsValue(persona5))
            {
                Console.WriteLine($"Ya existe un registo de {persona5.MostrarDatos()}... Desea agregarlo?");
                var resp = Console.ReadLine();
                if (resp=="s")
                {
                    agenda.Add(persona5.Telefono,persona5);
                }
                else
                {
                    Console.WriteLine("Ingreso cancelado por el usuario");
                }
            }

            Console.WriteLine($"Cantidad de registros: {agenda.Count}");

            var personaAConsultar = new Persona() { Nombre = "Alan", Apellido = "White" };

            var listaTelefonos = agenda.Where(c => c.Value.Equals(personaAConsultar)).ToList();
            if (listaTelefonos.Count>0)
            {
                foreach (var dato in listaTelefonos)
                {
                    Console.WriteLine($"Telefono: {dato.Key}");
                }
            }

            var persona7 = new Persona() { Nombre = "Patrick", Apellido = "Moraz" };
            Console.WriteLine("Ingrese el teléfono al que quiere modificarle la persona:");
            var telefonoBuscado = Console.ReadLine();
            if (agenda.TryGetValue(telefonoBuscado, out Persona persona6))
            {
                agenda[telefonoBuscado] = persona7;
                
            }
            else
            {
                Console.WriteLine($"La clave {telefonoBuscado} no existe");
            }

            foreach (var contacto in agenda)
            {
                Console.WriteLine($"La persona {contacto.Value.MostrarDatos()} tiene como clave {contacto.Key}");
            }
            var persona8 = new Persona() { Nombre = "Jon", Apellido = "Anderson", Telefono = "15416770" };

            if (agenda.TryAdd(persona8.Telefono,persona8))
            {
                Console.WriteLine($"Persona agregada");
            }
            else
            {
                Console.WriteLine($"{persona8.MostrarDatos()} no fue agregado a la agenda");
            }

            agenda.Remove("422230");
            Console.WriteLine(agenda.Count);
        }
    }
}
