using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibreriaBlog.Models
{
    public partial class ZEMOGA_TESTContext : DbContext
    {
        public ZEMOGA_TESTContext()
        {
        }

        public ZEMOGA_TESTContext(DbContextOptions<ZEMOGA_TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentType> CommentTypes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostState> PostStates { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E8PDK5G; Database=ZEMOGA_TEST; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__COMMENT__7E14AC85A1A46160");

                entity.ToTable("COMMENT");

                entity.Property(e => e.IdComment).HasColumnName("id_comment");

                entity.Property(e => e.CommentType).HasColumnName("comment_type");

                entity.Property(e => e.IdPost).HasColumnName("id_post");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.TextComment)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("text_comment");

                entity.HasOne(d => d.CommentTypeNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentType");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdPost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMMENT__id_post__5DCAEF64");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMMENT__id_user__5EBF139D");
            });

            modelBuilder.Entity<CommentType>(entity =>
            {
                entity.HasKey(e => e.IdCommentType)
                    .HasName("PK__COMMENT___828F1C78ABDFB8DF");

                entity.ToTable("COMMENT_TYPE");

                entity.Property(e => e.IdCommentType).HasColumnName("id_comment_type");

                entity.Property(e => e.TypeDescription)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("type_description");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__POST__3840C79DC520B802");

                entity.ToTable("POST");

                entity.Property(e => e.IdPost).HasColumnName("id_post");

                entity.Property(e => e.ContentText)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("content_text");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publication_date");

                entity.Property(e => e.StatePost).HasColumnName("state_post");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POST__id_user__59063A47");

                entity.HasOne(d => d.StatePostNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.StatePost)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POST__state_post__59FA5E80");
            });

            modelBuilder.Entity<PostState>(entity =>
            {
                entity.HasKey(e => e.IdState);

                entity.ToTable("POST_STATE");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("ROL");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.NameRol)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_rol");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__USER__D2D146374808BDD3");

                entity.ToTable("USER");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER__id_rol__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
