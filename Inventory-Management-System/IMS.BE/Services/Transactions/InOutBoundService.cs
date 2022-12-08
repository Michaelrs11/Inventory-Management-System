using IMS.BE.Models.Transactions;
using IMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.BE.Services.Transactions
{
    public class InOutBoundService
    {
        private readonly IMSDBContext db;
        private readonly UserIdentityService userIdentity;

        public InOutBoundService(IMSDBContext db, UserIdentityService userIdentity)
        {
            this.db = db;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Insert Stock
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>
        public async Task InsertInbound(InboundTransaction insert)
        {
            var tolowerSkuCode = insert.SkuCode.ToLower();

            var tolowerGudangCode = insert.GudangCode.ToLower();

            var userLogin = userIdentity.UserCode ?? "SYSTEM";

            var datetimeOffset = DateTimeOffset.UtcNow;

            var getStockByCode = await this.db.StockTransactions
                .FirstOrDefaultAsync(Q => Q.GudangCode.ToLower() == tolowerGudangCode && Q.SKUID.ToLower() == tolowerSkuCode);

            if (getStockByCode == null)
            {
                this.db.StockTransactions.Add(new StockTransaction
                {
                    SKUID = insert.SkuCode.ToUpper(),
                    GudangCode = insert.GudangCode.ToUpper(),
                    StockBefore = 0,
                    StockIn = insert.StockIn,
                    StockAfter = 0 + insert.StockIn,
                    CreatedAt = datetimeOffset,
                    CreatedBy = userLogin,
                    UpdatedAt = datetimeOffset,
                    UpdatedBy = userLogin
                });
            }
            else
            {
                getStockByCode.StockBefore += getStockByCode.StockAfter;
                getStockByCode.StockIn = insert.StockIn;
                getStockByCode.StockAfter += insert.StockIn;
                getStockByCode.UpdatedAt = datetimeOffset;
                getStockByCode.UpdatedBy = userLogin;
            }
            await db.SaveChangesAsync();

        }

        /// <summary>
        /// Outbound Transaction
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>
        public async Task InsertOutbound(OutbondTransaction insert)
        {
            var tolowerSkuCode = insert.SkuCode.ToLower();

            var tolowerGudangCode = insert.GudangCode.ToLower();

            var userLogin = userIdentity.UserCode ?? "SYSTEM";

            var datetimeOffset = DateTimeOffset.UtcNow;

            var getStockByCode = await this.db.StockTransactions
                .FirstOrDefaultAsync(Q => Q.GudangCode.ToLower() == tolowerGudangCode && Q.SKUID.ToLower() == tolowerSkuCode);

            if (getStockByCode == null)
            {
                this.db.StockTransactions.Add(new StockTransaction
                {
                    SKUID = insert.SkuCode.ToUpper(),
                    GudangCode = insert.GudangCode.ToUpper(),
                    StockBefore = 0,
                    StockOut = insert.StockOut,
                    StockAfter = 0 - insert.StockOut,
                    CreatedAt = datetimeOffset,
                    CreatedBy = userLogin,
                    UpdatedAt = datetimeOffset,
                    UpdatedBy = userLogin
                });
            }
            else
            {
                getStockByCode.StockBefore += getStockByCode.StockAfter;
                getStockByCode.StockOut = insert.StockOut;
                getStockByCode.StockAfter -= insert.StockOut;
                getStockByCode.UpdatedAt = datetimeOffset;
                getStockByCode.UpdatedBy = userLogin;
            }
            await db.SaveChangesAsync();
        }
    }
}
