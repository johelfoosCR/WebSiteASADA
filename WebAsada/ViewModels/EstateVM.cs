using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class EstateVM
    {
        public EstateVM()
        {
        }

        public int Id { get; set; }

        [Display(Name = "Folio Real")]
        public string RealFolio { get; set; }

        [Display(Name = "Plano Catastro")]
        public string CadastralPlans { get; set; }

        [Display(Name = "Area m2")]
        public double Area { get; set; }

        [Display(Name = "Comentario")]
        public string Comments { get; set; }

        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Display(Name = "Dirección Exacta")]
        public string ExactAddress { get; set; }
            
        [Display(Name = "Dueño")]
        public int PersonId { get; set; } 

        public Person Person { get; set; }

        public List<PersonItemVM> Owners { get; set; } 
    } 
}

