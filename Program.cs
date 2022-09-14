using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arstotzka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jailhouse jailhouse = new Jailhouse();
            Console.WriteLine("Заключенные. До амнистии:");
            jailhouse.ShowPrisoners();
            Console.WriteLine("\nЗаключенные. После амнистии:");
            jailhouse.HoldAmnesty("Антиправительственное");
            jailhouse.ShowPrisoners();
        }
    }

    class Jailhouse
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();
        
        public Jailhouse()
        {
            _prisoners.Add(new Prisoner("James Gonzalez", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Eric Jackson", "Уголовное"));
            _prisoners.Add(new Prisoner("Joe Clark", "Экономическое"));
            _prisoners.Add(new Prisoner("William Wells", "Уголовное"));
            _prisoners.Add(new Prisoner("Darrell Johnson", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Glenn McKenzie", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Byron Green", "Уголовное"));
            _prisoners.Add(new Prisoner("Erik Lynch", "Экономическое"));
            _prisoners.Add(new Prisoner("Keith Becker", "Уголовное"));
            _prisoners.Add(new Prisoner("Calvin Scott", "Антиправительственное"));
        }

        public void HoldAmnesty(string amnestyCrime)
        {
            _prisoners = _prisoners.Where(prisoner => prisoner.Crime != amnestyCrime).ToList();
        }

        public void ShowPrisoners()
        {
            SortPrisoners();

            foreach (Prisoner prisoner in _prisoners)
            {
                Console.WriteLine($"{prisoner.Name}. Преступление: {prisoner.Crime}");
            }
        }

        private void SortPrisoners()
        {
            _prisoners = _prisoners.OrderBy(prisoner => prisoner.Crime).ToList();
        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string name, string crime)
        {
            Name = name;
            Crime = crime;  
        }
    }
}
