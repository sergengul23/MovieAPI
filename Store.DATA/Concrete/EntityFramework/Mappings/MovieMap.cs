using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.MODELS.Entities;

namespace Store.DATA.Concrete.EntityFramework.Mappings
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.ReleasedYear).IsRequired();
            builder.Property(x => x.ImdbRating).IsRequired().HasColumnType("decimal(2,1)");
            builder.Property(x => x.HasAnOscar).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Director).WithMany(x => x.Movies).HasForeignKey(x => x.DirectorId);

            builder.ToTable("Movies");
        }
    }
}
