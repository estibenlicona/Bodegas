using System.Reflection;

namespace Bodegas.Domain.Helpers
{
    public static class PatchEntity
    {
        public static T Patch<T>(T entity, T patch)
        {
            if (entity == null) return entity;
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                IEnumerable<Attribute> attributes = property.GetCustomAttributes();
                if (attributes.Where(x => x.GetType().Name.Equals("NotUpdateAttribute")).FirstOrDefault() != null)
                {
                    PropertyInfo? entityPropertyInfo = entity.GetType().GetProperty(property.Name);
                    PropertyInfo? patchPropertyInfo = entity.GetType().GetProperty(property.Name);
                    if (entityPropertyInfo != null && patchPropertyInfo != null)
                    {
                        entityPropertyInfo.SetValue(entity, patchPropertyInfo.GetValue(patch));
                    }
                }
            }

            return entity;

        }
    }
}
