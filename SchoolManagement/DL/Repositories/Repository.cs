using ClickWise.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            if (entity == null)
            {
                return null;
            }

            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                return null;
            }

            var properties = typeof(T).GetProperties();
            var keyProperties = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;

            foreach (var property in properties)
            {
                // בודק אם השדה הוא ה-Id (המפתח הראשי) ומדלג עליו
                if (!keyProperties.Any(k => k.Name == property.Name) && property.CanWrite)
                {
                    var newValue = property.GetValue(entity);
                    if (property.Name == "IsActive")
                    {
                        var currentValue = property.GetValue(existingEntity);
                        if (currentValue is bool currentBool && currentBool && !(newValue is bool newBool && newBool) )
                        {
                            continue; 
                        }                     
                    }
                    if (property.Name == "Password")
                    {
                        if (newValue == null || string.IsNullOrWhiteSpace(newValue?.ToString()))
                        {
                            continue;
                        }
                    }
                    property.SetValue(existingEntity, newValue);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("------------------------------------------------ ");
                Console.WriteLine("שגיאה בעדכון הנתונים: " + ex.Message);
                Console.WriteLine("פרטי שגיאה: " + ex.InnerException?.Message);
                foreach (var entry in ex.Entries)
                {
                    Console.WriteLine($"Entity {entry.Entity.GetType().Name} - State: {entry.State}");
                }
                return null;
            }

            return existingEntity;
        }

    }
}

