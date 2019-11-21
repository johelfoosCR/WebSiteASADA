using System.ComponentModel.DataAnnotations;

namespace WebAsada.BaseObjects
{
    public abstract class GeneralEntity: BaseEntity
    {
        protected GeneralEntity() {

        }

        public GeneralEntity(string shortDesc, string longDesc, string officialId, string nemotecnico, bool isActive)
        { 
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            OfficialId = officialId;
            Nemotecnico = nemotecnico;
            IsActive = isActive;
        }

        protected void Clone(GeneralEntity newEntity)
        {
            LongDesc = newEntity.LongDesc;
            ShortDesc = newEntity.ShortDesc;
            IsActive = newEntity.IsActive;
            OfficialId = newEntity.OfficialId;
            IsActive = newEntity.IsActive;
        }

        [Display(Name = "Descripción Corta")]
        public string ShortDesc { get; protected set; }

        [Display(Name = "Descripción Larga")]
        public string LongDesc { get; protected set; }

        [Display(Name = "Nemotecnico")]
        public string Nemotecnico { get; protected set; }

        [Display(Name = "Código Regulador")]
        public string OfficialId { get; protected set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; protected set; }
    }
}
