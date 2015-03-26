using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CinemaProj
{
    class CinemaContext: DbContext
    {
        public CinemaContext() : base("CinemaDB") { }
        public DbSet<Films> Films { get; set; }
        public DbSet<Halls> Halls { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
    }

    [Table("Films")]
    class Films
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Name {get; set;}

        public override string ToString()
        {
            return Name;
        }
    }

    [Table("Halls")]
    class Halls
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Name {get; set;}
        public int FilmId { get; set; }
        public string FileSource {get;set;}

        public override string ToString()
        {
            return Name;
        }
    }

    [Table("Tickets")]
    class Tickets
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public int IdFilm {get;set;}
        public int IdHall {get;set;}
        public int place {get; set;}
        public int price { get; set;}
    }
}
