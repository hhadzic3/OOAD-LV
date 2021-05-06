using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApp.Models
{
    public class Predmet
    {
        #region Properties
        
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Naziv predmeta smije imati između 3 i 50 karaktera!")]
        [RegularExpression(@"[0-9| |a-z|A-Z]*", ErrorMessage = "Dozvoljeno je samo korištenje velikih i malih slova,brojeva i razmaka!")]
        [DisplayName("Naziv predmeta:")]
        public string Naziv { get; set; }
        
        [Required]
        [Range(1,10)]
        public double ECTS { get; set; }
        
        [NotMapped]
        public List<string> UpisaniStudenti { get; set; }
        #endregion
        
        #region Konstruktor
        public Predmet() { }

        public Predmet(string name, double points)
        {
            ID = GenerišiID();
            Naziv = name;
            ECTS = points;
            UpisaniStudenti = new List<string>();
        }
        #endregion

        #region Metode
        public int GenerišiID()
        {
            int id = 0;
            Random generator = new Random();
            for (int i = 0; i < 10; i++)
            {
                id += (int)Math.Pow(10, i) * generator.Next(0, 9);
            }
            return id;
        }
        #endregion
    }
}
