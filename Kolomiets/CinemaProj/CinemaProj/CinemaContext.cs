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
    public class CinemaContext: DbContext
    {
        public CinemaContext() : base("CinemaDB") { }
        public DbSet<Film> Films { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public void InitDB()
        {
            this.Database.Initialize(true);
        }
    }

   

    [Table("Films")]
    public class Film
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
    public class Hall
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
    public class Ticket
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
