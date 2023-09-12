using Ef_core_Table_Sharing_Issue_Demo.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef_core_Table_Sharing_Issue_Demo.Configuration;

public class SharedUserConfiguration : IEntityTypeConfiguration<SharedUser>
{
    static readonly internal string TableName = nameof(ExactUser);

    void IEntityTypeConfiguration<SharedUser>.Configure(EntityTypeBuilder<SharedUser> builder)
    {
        builder.ToTable(TableName)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne<ExactUser>()
            .WithOne()
            .HasForeignKey<SharedUser>(x => x.Id)
            .IsRequired();
    }
}
