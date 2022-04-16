
using RentalWebInfrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        
        IAdminUserRepository AdminUserRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        ICartRepository CartRepository { get; }
        IIpAddressRepository IpAddressRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IPhysicalAddressRepository PhysicalAddressRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductReviewRepository ProductReviewRepository { get; }
        IRoleRepository RoleRepository { get; }
        IShippingRepository ShippingRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        IStoreRepository StoreRepository { get; }
        IProcedureRepository ProcedureRepository { get; }
        IProductImagesRepository ProductImagesRepository { get; }
        IDatabaseTransaction BeginTransaction();
        Task SaveChangesAsync();
    }
}
