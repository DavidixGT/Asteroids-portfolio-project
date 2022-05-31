using System.Collections.Generic;
using Asteroids;

namespace Asteroids.Utilities
{
    public class EntityLimitChecker
    {
        private List<Entity> _entities = new List<Entity>();
        private int _entityCountLimit;
        public EntityLimitChecker(int limit) => _entityCountLimit = limit;
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.Dead += RemoveEntity;
        }
        private void RemoveEntity(Entity entity) => _entities.Remove(entity);
        public bool IsEntityLimitReached() => _entities.Count == _entityCountLimit;
    }
}
