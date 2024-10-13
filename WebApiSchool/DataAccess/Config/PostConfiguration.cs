using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        void IEntityTypeConfiguration<Post>.Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x=>x.Content)
                .IsRequired();

            builder.Property(x=>x.CreatedAt) .IsRequired();

            builder.Property(x=>x.UpdatedAt) .IsRequired(false);

            builder.HasOne(p=>p.Author)
                .WithMany(p=>p.Posts)
                .HasForeignKey(p=>p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.Title);


        //    builder.HasData(
        //    new Post
        //    {
        //        Id = Guid.NewGuid(), 
        //        Title = "Post1",
        //        Content = "This is the content of the first post.",
        //        CreatedAt = DateTime.Now,
        //        UpdatedAt = null,
        //        AuthorId = Guid.Parse("02F588E5-942D-4DBE-A6AE-046A7F60E9E4") // User 1
        //    },
        //    new Post
        //    {
        //        Id = Guid.NewGuid(), 
        //        Title = "Post2",
        //        Content = "This is the content of the second post.",
        //        CreatedAt = DateTime.Now,
        //        UpdatedAt = null,
        //        AuthorId = Guid.Parse("B1B62BB0-17B6-4401-A0C7-54C8279B8D0D") // User 2
        //    },

        //     new Post
        //     {
        //         Id = Guid.NewGuid(),
        //         Title = "Post3",
        //         Content = "This is the content of the first post.",
        //         CreatedAt = DateTime.Now,
        //         UpdatedAt = null,
        //         AuthorId = Guid.Parse("02F588E5-942D-4DBE-A6AE-046A7F60E9E4") // User 1
        //     },
        //    new Post
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Post4",
        //        Content = "This is the content of the second post.",
        //        CreatedAt = DateTime.Now,
        //        UpdatedAt = null,
        //        AuthorId = Guid.Parse("B1B62BB0-17B6-4401-A0C7-54C8279B8D0D") // User 2
        //    },

        //     new Post
        //     {
        //         Id = Guid.NewGuid(),
        //         Title = "Post5",
        //         Content = "This is the content of the first post.",
        //         CreatedAt = DateTime.Now,
        //         UpdatedAt = null,
        //         AuthorId = Guid.Parse("02F588E5-942D-4DBE-A6AE-046A7F60E9E4") // User 1
        //     },
        //    new Post
        //    {
        //        Id = Guid.NewGuid(),
        //        Title = "Post6",
        //        Content = "This is the content of the second post.",
        //        CreatedAt = DateTime.Now,
        //        UpdatedAt = null,
        //        AuthorId = Guid.Parse("B1B62BB0-17B6-4401-A0C7-54C8279B8D0D") // User 2
        //    }
        //);

        }
    }
}
