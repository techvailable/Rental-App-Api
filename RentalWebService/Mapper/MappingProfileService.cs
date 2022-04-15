using AutoMapper;
using RentalWebInfrastructure.Entities;
using RentalWebService.DTOs;

namespace RentalWebService.Mapper
{
    public class MappingProfileService : Profile
    {
        public MappingProfileService()
        {
            CreateMap<Store, StoreDto>();
            CreateMap<StoreDto, Store>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<SubCategoryDto, SubCategory>();

            CreateMap<AdminUser, AdminUserDto>();
            CreateMap<AdminUserDto, AdminUser>();

            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();

            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemDto, CartItem>();

            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();

            CreateMap<IpAddress, IpAddressDto>();
            CreateMap<IpAddressDto, IpAddress>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();

            CreateMap<PhysicalAddress, PhysicalAddressDto>();
            CreateMap<PhysicalAddressDto, PhysicalAddress>();

            CreateMap<ProductReview, ProductReviewDto>();
            CreateMap<ProductReviewDto, ProductReview>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Shipping, ShippingDto>();
            CreateMap<ShippingDto, Shipping>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();

            CreateMap<ProductImages, ProductImagesDto>();
            CreateMap<ProductImagesDto, ProductImages>();

            /* Procedure *********************/

            CreateMap<SpGetProductsByStore, SpGetProductsByStoreDtos>();
        }
    }
}
