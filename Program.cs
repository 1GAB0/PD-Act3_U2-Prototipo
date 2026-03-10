
using System;

namespace PatronPrototipo
{
    //
    // prototipo examen principal
    public abstract class ExamenPrototype
    {
        // datos comunes
        protected string _materia;
        protected int _cantidadPreguntas;
        protected string _rubrica;
        protected string _tipo;

        // datos especificoos
        protected string _docente;
        protected string _salon;
        protected string _estudiante;

        // propiedades para asignar valores despues de clonar
        public string Docente { set => _docente = value; }
        public string Salon { set => _salon = value; }
        public string Estudiante { set => _estudiante = value; }

        // metodos abstractos requeridos por el patron y el pizarron
        public abstract ExamenPrototype Clone();
        public abstract void Modalidad();
        public abstract void Revision();
        public abstract void Promediar();
        public abstract void VerDetalles();
    }

    //
    // prototipo patrones de Dis soft
    public class ExamenPatrones : ExamenPrototype
    {
        public ExamenPatrones()
        {
            // valores modificados
            _materia = "Patrones de Diseño de Software";
            _cantidadPreguntas = 40;
            _rubrica = "50% ";
            _tipo = "Teorico";
        }

        public override ExamenPrototype Clone()
        {
            return (ExamenPatrones)this.MemberwiseClone(); // clonacion 
        }

        // metodos
        public override void Modalidad() => Console.WriteLine("- Modalidad: Presencial");
        public override void Revision() => Console.WriteLine("- Revisión: Por el docente");
        public override void Promediar() => Console.WriteLine("- Promediar: Calificación sengun los aciertos");

        public override void VerDetalles()
        {
            Console.WriteLine($"\nEXAMEN: {_materia} - Tipo: {_tipo} \nPreguntas: {_cantidadPreguntas} \n Rúbrica: {_rubrica}");
            Console.WriteLine($"\n- Docente: {_docente} - Salón: {_salon} \nEstudiante: {_estudiante}");
        }
    }

    //
    // prototipo 2 Temas Avansados de Desarrollo de Software
    public class ExamenTADS : ExamenPrototype
    {
        public ExamenTADS()
        {
            _materia = "Temas Avanzados de Desarrollo de Software";
            _cantidadPreguntas = 20;
            _rubrica = "70% Examen";
            _tipo = "Formulario En linea";
        }

        public override ExamenPrototype Clone()
        {
            return (ExamenTADS)this.MemberwiseClone();
        }

        public override void Modalidad() => Console.WriteLine("- Modalidad: Semi-presencial");
        public override void Revision() => Console.WriteLine("- Revisión: Automatica por el formalario");
        public override void Promediar() => Console.WriteLine("- Promediar: Suma de aciertos");

        public override void VerDetalles()
        {
            Console.WriteLine($"\nEXAMEN: {_materia} - Tipo: {_tipo} \nPreguntas: {_cantidadPreguntas} \n Rúbrica: {_rubrica}");
            Console.WriteLine($"\n- Docente: {_docente} - Salón: {_salon} \nEstudiante: {_estudiante}");
        }
    }

    //
    // prototipo 3 Desarrollo de Aplicaciones Moviles
    //
    public class ExamenDesAppsM : ExamenPrototype
    {
        public ExamenDesAppsM()
        {
            _materia = "Desarrollo de Aplicaciones Moviles";
            _cantidadPreguntas = 10;
            _rubrica = "80% ";
            _tipo = "Practico";
        }

        public override ExamenPrototype Clone()
        {
            return (ExamenDesAppsM)this.MemberwiseClone();
        }

        public override void Modalidad() => Console.WriteLine("- Modalidad: Presencial, ebtrega en linea");
        public override void Revision() => Console.WriteLine("- Revisión: Repo de Github");
        public override void Promediar() => Console.WriteLine("- Promediar: Suma de aciertos");

        public override void VerDetalles()
        {
            Console.WriteLine($"\nEXAMEN: {_materia} - Tipo: {_tipo} \nPreguntas: {_cantidadPreguntas} \nRúbrica: {_rubrica}");
            Console.WriteLine($"\n-Docente: {_docente} - Salón: {_salon} - Estudiante: {_estudiante}");
        }
    }

    //
    // main
    class Program
    {
        static void Main(string[] args)
        {
            // prototipos prefabricados
            ExamenPrototype moldePatrones = new ExamenPatrones();
            ExamenPrototype moldeTemas = new ExamenTADS();
            ExamenPrototype moldeDesApp = new ExamenDesAppsM();

            Console.WriteLine("// EXÁMENES CON PROTOTYPE //");

            // examenes requeridos mediante clonacion

            // ejemplo 1 mismo Docente dif alumns
            ExamenPrototype ex1 = moldePatrones.Clone();
            ex1.Docente = "Maribel Guerrero"; 
            ex1.Salon = "Aula 9205"; 
            ex1.Estudiante = "Gabriel SanRoman";
            
            ExamenPrototype ex2 = moldePatrones.Clone();
            ex2.Docente = "Maribel Guerrero"; 
            ex2.Salon = "Aula 9205"; 
            ex2.Estudiante = "Alonso Silva";

            // exam des app
            ExamenPrototype ex3 = moldeDesApp.Clone();
            ex3.Docente = "Daniela Sánchez"; 
            ex3.Salon = "91L06"; 
            ex3.Estudiante = "Gabriel SanRoman";

            ExamenPrototype ex4 = moldeDesApp.Clone();
            ex4.Docente = "Daniela Sánchez"; 
            ex4.Salon = "91L06"; 
            ex4.Estudiante = "Miguel Gómez";

            ExamenPrototype ex5 = moldeDesApp.Clone();
            ex5.Docente = "Daniela Sánchez"; 
            ex5.Salon = "9205"; 
            ex5.Estudiante = "Laura Díaz";

            // exam temas
            ExamenPrototype ex6 = moldeTemas.Clone();
            ex6.Docente = "Humberto"; 
            ex6.Salon = "Lab I"; 
            ex6.Estudiante = "Pedro Jiménez";

            ExamenPrototype ex7 = moldeTemas.Clone();
            ex7.Docente = "Diego Vazquez"; 
            ex7.Salon = "Virtual"; 
            ex7.Estudiante = "Elena Moreno";

            // 3. Imprimimos y probamos los métodos de algunos exámenes
            ex1.VerDetalles();
            ex1.Modalidad();
            ex1.Revision();

            ex2.VerDetalles();
          Console.WriteLine("/////////////////////");
          
            ex3.VerDetalles();
            ex4.VerDetalles();
            ex5.VerDetalles();

          Console.WriteLine("/////////////////////");
            ex6.VerDetalles();
            ex6.Promediar();

            ex7.VerDetalles();
            ex7.Revision();

            Console.ReadKey();
        }
    }
}
// unGAB0
