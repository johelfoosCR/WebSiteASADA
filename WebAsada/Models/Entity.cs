using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Entity: BaseEntity
    {
        public Entity(string name, string description, bool isGeneralTable)
        {
            Name = name;
            Description = description;
            IsGeneralTable = isGeneralTable;
        } 

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsGeneralTable { get; private set; }

        public static Entity SincronizeObject(Entity entity, string name, string description, bool isGeneralTable) {
            entity.IsGeneralTable = isGeneralTable;
            entity.Name = name;
            entity.Description = description;
            return entity;
        }


        public static Entity SincronizeObject(Entity currentEntity, Entity newEntity)
        {
            currentEntity.Description = newEntity.Description;
            currentEntity.IsGeneralTable = newEntity.IsGeneralTable;
            currentEntity.Name = newEntity.Name; 
            return currentEntity;
        }

    }
}
