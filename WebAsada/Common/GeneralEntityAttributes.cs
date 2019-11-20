namespace WebAsada.Common
{
    public class GeneralEntityAttributes
    { 
        public const string ATTRIBUTES_TO_BIND_DTO_SAVE = "ShortDesc,LongDesc,Nemotecnico,OfficialId,IsActive"; 
        public const string ATTRIBUTES_TO_BIND_DTO_UPDATE = "Id," + ATTRIBUTES_TO_BIND_DTO_SAVE;
    }
}
