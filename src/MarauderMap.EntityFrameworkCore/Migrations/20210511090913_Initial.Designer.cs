// <auto-generated />
using System;
using MarauderMap.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

namespace MarauderMap.Migrations
{
    [DbContext(typeof(MarauderMapDbContext))]
    [Migration("20210511090913_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.Sqlite)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("MarauderMap.Solutions.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AbsolutePath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SolutionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SolutionId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MarauderMap.Solutions.Solution", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AbsolutePath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("TEXT")
                        .HasColumnName("ExtraProperties");

                    b.HasKey("Id");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("MarauderMap.Solutions.Project", b =>
                {
                    b.HasOne("MarauderMap.Solutions.Solution", "Solution")
                        .WithMany("Projects")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("MarauderMap.Solutions.Solution", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
