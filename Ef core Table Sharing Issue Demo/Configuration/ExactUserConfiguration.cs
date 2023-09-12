using Ef_core_Table_Sharing_Issue_Demo.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef_core_Table_Sharing_Issue_Demo.Configuration;

public class ExactUserConfiguration : IEntityTypeConfiguration<ExactUser>
{
    static readonly internal string TableName = nameof(ExactUser);

    public void Configure(EntityTypeBuilder<ExactUser> builder)
    {
        builder.ToTable(TableName)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);
    }
}
