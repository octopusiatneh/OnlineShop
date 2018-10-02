﻿namespace OnlineShop.Data.Infrastructure
{
    public class DbFactory : Dispoable, IDbFactory
    {
        private OnlineShopDbContext dbContext;

        public OnlineShopDbContext Init()
        {
            return dbContext ?? (dbContext = new OnlineShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}