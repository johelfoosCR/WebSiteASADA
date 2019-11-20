using System;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Month : BaseEntity
    {
        private Month()
        {

        }

        public Month(int id, string shortDesc, string nemotecnico) 
        {
            Id = id;
            ShortDesc = shortDesc;
            Nemotecnico = nemotecnico;
            UpdateDateTime = new DateTime(2020, 1, 1);
            RegisterDatime = new DateTime(2020, 1, 1);
        }

        public string ShortDesc { get; private set; }

        public string Nemotecnico { get; private set; }

    }
}
