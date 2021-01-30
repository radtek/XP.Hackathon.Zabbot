using XP.Hackathon.Zabbot.Infrastructure.Data.Context;
using XP.Hackathon.Zabbot.Interface.Repository.Base;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Extensions;
using XP.Hackathon.Zabbot.Model.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : BaseModel
    {
        private DbContextOptionsBuilder<DatabaseContext> _optionsBuilder;
        protected DatabaseContext databaseContext { get; }
        protected DbSet<T> Table;

        public RepositoryBase()
        {
            _optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            _optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            databaseContext = new DatabaseContext(_optionsBuilder.Options);
            Table = databaseContext.Set<T>();
        }

        public async virtual Task<Result<T>> GetAsync(long id)
        {
            var result = new Result<T>();

            try
            {
                var model = await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                result.Success = true;
                result.Objects.Add(model);
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = sqlEx;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "Exception.";
                result.Error = ex;
            }

            return result;
        }

        public async virtual Task<Result<T>> GetAsync(BaseFilter filter)
        {
            var result = new Result<T>();

            try
            {
                var skip = filter.Offset < 0 ? 0 : filter.Offset;
                var take = filter.Limit <= 0 ? 1000 : filter.Limit;
                var orderBy = string.IsNullOrEmpty(filter.OrderBy) ? "Id" : filter.OrderBy;
                var orderType = string.IsNullOrEmpty(filter.OrderType) ? "asc" : filter.OrderType;
                var item = typeof(T).GetProperty(orderBy);

                var list = new List<T>();
                if (orderType.ToLower() == "desc")
                    list = await Table.AsNoTracking().OrderByDescending(x => item.GetValue(x, null)).Skip(skip).Take(take).ToListAsync();
                else
                    list = await Table.AsNoTracking().OrderBy(x => item.GetValue(x, null)).Skip(skip).Take(take).ToListAsync();

                result.Success = true;
                result.Objects.AddRange(list);
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = sqlEx;
                result.MessageLog = sqlEx.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "Exception.";
                result.Error = ex;
                result.MessageLog = ex.GetInnerMessages();
            }

            return result;
        }

        public async virtual Task<Result<T>> GetAsync()
        {
            var result = new Result<T>();

            try
            {
                var model = await Table.AsNoTracking().ToListAsync();

                result.Success = true;
                result.Objects.AddRange(model);
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = sqlEx;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "Exception.";
                result.Error = ex;
            }

            return result;
        }

        public async Task<IEnumerable<T>> GetAllActive()
        {
            return await Table.AsNoTracking().Where(x => x.Active).ToListAsync();
        }

        public async virtual Task<Result<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var result = new Result<T>();

            try
            {
                var model = expression == null ? await Table.AsNoTracking().ToListAsync() : await Table.Where(expression).AsNoTracking().ToListAsync();

                result.Success = true;
                result.Objects.AddRange(model);
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = sqlEx;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "Exception.";
                result.Error = ex;
            }

            return result;
        }

  public async Task<int> Total(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return await Table.AsNoTracking().CountAsync();

            return await Table.Where(expression).AsNoTracking().CountAsync();
        }

        public async Task<Result<T>> SaveAsync(T model)
        {
            var result = new Result<T>();

            if (model == null)
            {
                result.Success = false;
                result.FriendlyMessage = "Model is null.";

                return result;
            }

            try
            {
                if (model.Id.GetHashCode() == 0)
                {
                    model.Created = DateTimeExtensions.GetBrazilianDate();
                    Table.Add(model);
                }
                else
                {
                    model.Updated = DateTimeExtensions.GetBrazilianDate();
                    Update(model);
                }

                await databaseContext.SaveChangesAsync();

                result.Success = true;
                result.Objects.Add(model);
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = sqlEx;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = ex;
            }

            return result;
        }

        private void Update(T model)
        {
            try
            {
                // We query local context first to see if it's there.
                var modelAlreadyAttach = Table.Local.FirstOrDefault(entry => entry.Id.Equals(model.Id));

                // We have it in the context, need to update.
                if (modelAlreadyAttach == null)
                {
                    // If it's not found locally, we can attach it by setting state to modified.
                    // This would result in a SQL update statement for all fields
                    // when SaveChanges is called. 
                    var entry = databaseContext.Entry(model);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    var attachedEntry = databaseContext.Entry(modelAlreadyAttach);
                    attachedEntry.CurrentValues.SetValues(model);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<ResultBase> Delete(long id)
        {
            var result = new ResultBase();

            try
            {

                var resource = await Table.AsNoTracking().FirstAsync(x => x.Id == id);
                if (resource == null)
                {
                    result.Success = false;
                    result.FriendlyMessage = "Not found.";
                }

                databaseContext.Entry(resource).State = EntityState.Deleted;
                await databaseContext.SaveChangesAsync();

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "An exception occurred while trying to remove the resource.";
                result.Error = ex;
                result.MessageLog = ex.GetInnerMessages();
            }

            return result;
        }

        public void Rollback()
        {
            try
            {
                if (databaseContext != null)
                {
                    databaseContext.ChangeTracker.Entries()
                        .ToList()
                        .ForEach(entry => entry.State = EntityState.Unchanged);
                }
            }
            catch
            {
            }
        }

public void Dispose()
        {
            if (databaseContext != null)
                databaseContext.Dispose();

            GC.SuppressFinalize(this);
        }


        public Task<int> SaveChangesAsync()
        {
            this.ChangeState();
            this.SetModifiedDate();
            return databaseContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            this.SetModifiedDate();
            return databaseContext.SaveChanges();
        }

        private void SetModifiedDate()
        {
            foreach (var item in databaseContext.ChangeTracker.Entries())
            {
                if (item.State == EntityState.Modified)
                {
                    ((BaseModel)item.Entity).Updated = DateTimeExtensions.GetBrazilianDate();
                }
            }
        }

        private void ChangeState()
        {
            foreach (var item in databaseContext.ChangeTracker.Entries())
            {
                item.State = ((BaseModel)item.Entity).IsNew() ? EntityState.Added : EntityState.Modified;
            }
        }
    }
}
