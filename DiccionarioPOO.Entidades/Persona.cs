using System;

namespace DiccionarioPOO.Entidades
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string MostrarDatos() => $"{Nombre} {Apellido}";

        public override bool Equals(object obj)
        {
            if (obj==null || !(obj is Persona))
            {
                return false;
            }

            return this.MostrarDatos() == ((Persona)obj).MostrarDatos();
        }

        
    }
}
