using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Model.Extensions;
using XP.Hackathon.Zabbot.Model.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Infrastructure.Data.SqlSever.Repositories
{
    public class EscalationGroupRepository : RepositoryBase<EscalationGroup>, IEscalationGroupRepository
    {
	 public async Task<Result<EscalationGroup>> GetDetailAsync(BaseFilter filter)
        {
            var result = new Result<EscalationGroup>();

            try
            {
                var skip = filter.Offset < 0 ? 0 : filter.Offset;
                var take = filter.Limit <= 0 ? 1000 : filter.Limit;
                var orderBy = string.IsNullOrEmpty(filter.OrderBy) ? "Id" : filter.OrderBy;
                var item = typeof(EscalationGroup).GetProperty(orderBy);

                var list = new List<EscalationGroup>();
                if (filter.OrderType?.ToLower() == "desc")
                    list = await databaseContext.EscalationGroup
					.AsNoTracking().OrderByDescending(x => item.GetValue(x, null)).Skip(skip).Take(take).ToListAsync();
                else if (filter.OrderType?.ToLower() == "asc")
                    list = await databaseContext.EscalationGroup
					.AsNoTracking().OrderBy(x => item.GetValue(x, null)).Skip(skip).Take(take).ToListAsync();
                else
                    list = await databaseContext.EscalationGroup
					.AsNoTracking().OrderBy(x => item.GetValue(x, null)).Skip(skip).Take(take).ToListAsync();

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
    }    
}