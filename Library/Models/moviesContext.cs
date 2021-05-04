using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace lib.Library.Models
{
    public partial class moviesContext : DbContext
    {
        public moviesContext()
        {
        }

        public moviesContext(DbContextOptions<moviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenreMovie> GenreMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieRole> MovieRoles { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<ShopCustomer> ShopCustomers { get; set; }
        public virtual DbSet<ShopMoviePrice> ShopMoviePrices { get; set; }
        public virtual DbSet<ShopOrder> ShopOrders { get; set; }
        public virtual DbSet<ShopOrderDetail> ShopOrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=movies;Username=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImdbName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("imdb_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GenreMovie>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId })
                    .HasName("genre_movie_pkey");

                entity.ToTable("genre_movie");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CoverUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cover_url");

                entity.Property(e => e.ImdbId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("imdb_id");

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("kind");

                entity.Property(e => e.OriginalAirDate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("original_air_date");

                entity.Property(e => e.Plot)
                    .IsRequired()
                    .HasColumnName("plot");

                entity.Property(e => e.Rating)
                    .HasPrecision(4, 2)
                    .HasColumnName("rating");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Top250Rank).HasColumnName("top_250_rank");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<MovieRole>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.PersonId, e.Role })
                    .HasName("movie_role_pkey");

                entity.ToTable("movie_role");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Role)
                    .HasMaxLength(255)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("persons");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Biography)
                    .IsRequired()
                    .HasColumnName("biography");

                entity.Property(e => e.ImdbId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("imdb_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ShopCustomer>(entity =>
            {
                entity.ToTable("shop_customers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Street)
                    .HasMaxLength(60)
                    .HasColumnName("street");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<ShopMoviePrice>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .HasName("shop_movie_price_pkey");

                entity.ToTable("shop_movie_prices");

                entity.Property(e => e.MovieId)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_id");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(8, 2)
                    .HasColumnName("unit_price");
            });

            modelBuilder.Entity<ShopOrder>(entity =>
            {
                entity.ToTable("shop_orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(15)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Street)
                    .HasMaxLength(60)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<ShopOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.MovieId })
                    .HasName("shop_order_detail_pkey");

                entity.ToTable("shop_order_details");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(8, 2)
                    .HasColumnName("unit_price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
