using Dapper;
using IMS.BE.Models.Transactions;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace IMS.BE.Services.Transactions
{
    public class RekapTransactionService
    {
        private readonly IMSDBContext db;

        public RekapTransactionService(IMSDBContext db)
        {
            this.db = db;
        }

        public string GenerateInitialQuery()
        {
            _ = nameof(StockTransaction.SKUID);
            _ = nameof(StockTransaction.GudangCode);
            _ = nameof(StockTransaction.StockIn);
            _ = nameof(StockTransaction.StockOut);
            _ = nameof(MasterBarang.Name);

            return @"SELECT
	                    st.SKUID AS [SkuId], 
	                    mb.Name AS [Name],
	                    SUM(CAST(st.StockIn AS NUMERIC)) - SUM(CAST(st.StockOut AS NUMERIC)) AS [Stock]
                    FROM StockTransaction st
                    JOIN MasterBarang mb ON st.SKUID = mb.SKUID";
        }

        public string GenerateFilterQuery(string? gudangCode, DateTime? dateFrom,
            DateTime? dateTo)
        {
            var filterQuery = new StringBuilder();
            filterQuery.Append("WHERE ");

            if (!string.IsNullOrEmpty(gudangCode))
            {
                filterQuery.AppendLine("st.GudangCode = @gudangCode AND");
            }

            if (dateFrom != null)
            {
                filterQuery.AppendLine("CONVERT(DATE, st.CreatedAt) >= @dateFrom AND");
            }

            if (dateTo != null)
            {
                filterQuery.AppendLine("CONVERT(DATE, st.CreatedAt) <= @dateTo AND");
            }

            return filterQuery.Length > 6 ? filterQuery.Remove(filterQuery.Length - 5, 5).ToString() : string.Empty;
        }

        public string GenerateGroupbyQuery()
        {
            var groupbyQuery = "GROUP BY st.SKUID, mb.Name";

            return groupbyQuery;
        }

        public async Task<List<RekapTransaction>> GetRekapTransaction(string? gudangCode, DateTime? dateFrom,
            DateTime? dateTo)
        {
            var query = new StringBuilder();

            query.AppendLine(GenerateInitialQuery());
            query.AppendLine(GenerateFilterQuery(gudangCode, dateFrom, dateTo));
            query.Append(GenerateGroupbyQuery());

            var filterQuery = new
            {
                gudangCode = $@"{gudangCode}",
                dateFrom = dateFrom?.ToString("yyyy-MM-dd"),
                dateTo = dateTo?.ToString("yyyy-MM-dd"),
            };

            var gridData = (await db.Database.GetDbConnection().QueryAsync<RekapTransaction>(query.ToString(), filterQuery)).ToList();

            return gridData;
        }
    }
}
