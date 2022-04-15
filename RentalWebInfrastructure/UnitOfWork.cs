using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories;

namespace RentalWebInfrastructure.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalWebContext context;
        public IAdminUserRepository AdminUserRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public ICartRepository CartRepository { get; }
        public IIpAddressRepository IpAddressRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IPhysicalAddressRepository PhysicalAddressRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IProductReviewRepository ProductReviewRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IShippingRepository ShippingRepository { get; }
        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IProcedureRepository ProcedureRepository { get; }
        public IProductImagesRepository ProductImagesRepository { get; }
        public UnitOfWork(RentalWebContext context)
        {
            this.context = context;
            StoreRepository = new StoreRepository(context);
            SubCategoryRepository = new SubCategoryRepository(context);
            CategoryRepository = new CategoryRepository(context);
            AdminUserRepository = new AdminUserRepository(context);
            BrandRepository = new BrandRepository(context);
            CartItemRepository = new CartItemRepository(context);
            CartRepository = new CartRepository(context);
            IpAddressRepository = new IpAddressRepository(context);
            OrderRepository = new OrderRepository(context);
            PaymentRepository = new PaymentRepository(context);
            PhysicalAddressRepository = new PhysicalAddressRepository(context);
            ProductRepository = new ProductRepository(context);
            RoleRepository = new RoleRepository(context);
            ShippingRepository = new ShippingRepository(context);
            UserRepository = new UserRepository(context);
            UserRoleRepository = new UserRoleRepository(context);
            ProductReviewRepository = new ProductReviewRepository(context);
            ProcedureRepository = new ProcedureRepository(context);
            ProductImagesRepository = new ProductImagesRepository(context);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(context);
        }
    }
}
