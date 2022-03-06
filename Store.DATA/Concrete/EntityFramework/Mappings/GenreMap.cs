using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.MODELS.Entities;

namespace Store.DATA.Concrete.EntityFramework.Mappings
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Genres");

            builder.HasData(new Genre
            {
                Id = 1,
                Name = "Drama"
            },

            new Genre
            {
                Id = 2,
                Name = "Action"
            },

            new Genre
            {
                Id = 3,
                Name = "Mystery"
            },

            new Genre
            {
                Id = 4,
                Name = "Horror"
            },

            new Genre
            {
                Id = 5,
                Name = "Comedy"
            },

            new Genre
            {
                Id = 6,
                Name = "Romance"
            });
        }
    }
}
