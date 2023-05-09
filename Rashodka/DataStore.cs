using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rashodka
{
    public class DataStore : DbContext
    {
        //таблица расходных материалов, таблица отделов, таблица с информацией о выдаче расходных материалов тому или иному отделу.

        public DbSet<Consumables> Consumables { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Extradition> Extradition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rashodka.db");
        }

        public DataStore()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Consumables //расходные материалы
    {
        [DisplayName("ID")]
        public int ConsumablesId { get; set; }
        [Required, DisplayName("Наименование")]
        public string ConsumablesName { get; set; }
        [Required, DisplayName("Количество")]
        public int ConsumablesCount { get; set; }

        public List<Extradition> Extraditions { get; set; } 
    }

    //[Index(nameof(RegionName), IsUnique = true)]
    public class Region // регион 
    {
        
        [DisplayName("ID")]
        public int RegionId { get; set; }
        [Required, DisplayName("Регион")]
        public string RegionName { get; set; }
        
        public List<Extradition> Extraditions { get; set;}
    }


    public class Extradition // выдача расходки
    {
        [DisplayName("ID")]
        public int ExtraditionId { get; set;}
        [Required, DisplayName("Id материала")]
        public int ConsumablesId { get;set; }
        [Required, DisplayName("Id региона") ]
        public int RegionId { get; set; }
        [Required, DisplayName("Кол-во материала")]
        public int ConsumablesCount { get; set;}
        [Required, DisplayName("Дата")]
        public DateTime Date { get; set; }

        public Region Region { get; set; }  
        public Consumables Consumables { get; set; } 
    }
}
