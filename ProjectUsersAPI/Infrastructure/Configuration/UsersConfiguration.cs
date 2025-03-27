using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectUsersAPI.Infrastructure.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(d => d.Name)
                .IsRequired();

            builder.Property(d => d.Email)
                .IsRequired();

            builder.Property(d => d.Password)
                .IsRequired();

            builder.Property(d => d.Telephone.DDD) 
                .IsRequired();

            builder.Property(d => d.Telephone.PhoneNumber) 
                .IsRequired();

            builder.Property(d => d.CreateAt)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
