using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.TitleNews).IsRequired();
            builder.Property(x => x.TitleNews).HasMaxLength(500);
            builder.HasMany(c => c.Comments)
                .WithOne(x => x.News)
                .HasForeignKey(x => x.NewsId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Pictures)
                .WithOne(x => x.News)
                .HasForeignKey(x => x.NewsId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(t => t.Texts)
            .WithOne(x => x.News)
            .HasForeignKey(x => x.NewsId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
