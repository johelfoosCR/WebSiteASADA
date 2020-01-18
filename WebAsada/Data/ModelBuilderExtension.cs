using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAsada.Models;

namespace WebAsada.Data
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>().HasData(
                   new Month(1, "Enero", "ENERO"),
                   new Month(2, "Febrero", "FEBRERO"),
                   new Month(3, "Marzo", "MARZO"),
                   new Month(4, "Abril", "ABRIL"),
                   new Month(5, "Mayo", "MAYO"),
                   new Month(6, "Junio", "JUNIO"),
                   new Month(7, "Julio", "JULIO"),
                   new Month(8, "Agosto", "AGOSTO"),
                   new Month(9, "Septiembre", "SEPTIEMBRE"),
                   new Month(10, "Octubre", "OCTUBRE"),
                   new Month(11, "Noviembre", "NOVIEMBRE"),
                   new Month(12, "Diciembre", "DICIEMBRE"));
             
        }
         

        public static void ManyToManyRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonsByEstate>().HasKey(sc => new { sc.EstateId, sc.PersonId });
            modelBuilder.Entity<ReceiptItem>().HasOne(i => i.Receipt).WithMany(c => c.Items).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
