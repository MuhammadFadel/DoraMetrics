﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220530133132_EnhancementMetricsModule")]
    partial class EnhancementMetricsModule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.AccessInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<int?>("NotificationLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccessInfos");
                });

            modelBuilder.Entity("Data.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefaultBranchProtection")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileTemplateProjectId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GitlabGroupId")
                        .HasColumnType("int");

                    b.Property<bool>("LfsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCreationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequestAccessEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("RequireTwoFactorAuthentication")
                        .HasColumnType("bit");

                    b.Property<bool>("ShareWithGroupLock")
                        .HasColumnType("bit");

                    b.Property<string>("SubgroupCreationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TwoFactorGracePeriod")
                        .HasColumnType("int");

                    b.Property<string>("Visibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Data.Entities.Links", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClusterAgents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Events")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Issues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Labels")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Members")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MergeRequests")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("RepoBranches")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Self")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Data.Entities.Metrics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MetricType")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectType")
                        .HasColumnType("int");

                    b.Property<double?>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("Data.Entities.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupAccessId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectAccessId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupAccessId");

                    b.HasIndex("ProjectAccessId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("DefaultBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ForksCount")
                        .HasColumnType("int");

                    b.Property<int>("GitlabProjectId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("HttpUrlToRepo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActivityAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameWithNamespace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpenIssuesCount")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarCount")
                        .HasColumnType("int");

                    b.Property<string>("Visibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Data.Entities.Links", b =>
                {
                    b.HasOne("Data.Entities.Project", "Project")
                        .WithOne("Links")
                        .HasForeignKey("Data.Entities.Links", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Data.Entities.Metrics", b =>
                {
                    b.HasOne("Data.Entities.Group", null)
                        .WithMany("Metrics")
                        .HasForeignKey("GroupId");

                    b.HasOne("Data.Entities.Project", null)
                        .WithMany("Metrics")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Data.Entities.Permissions", b =>
                {
                    b.HasOne("Data.Entities.AccessInfo", "GroupAccess")
                        .WithMany()
                        .HasForeignKey("GroupAccessId");

                    b.HasOne("Data.Entities.AccessInfo", "ProjectAccess")
                        .WithMany()
                        .HasForeignKey("ProjectAccessId");

                    b.HasOne("Data.Entities.Project", "Project")
                        .WithOne("Permissions")
                        .HasForeignKey("Data.Entities.Permissions", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupAccess");

                    b.Navigation("Project");

                    b.Navigation("ProjectAccess");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.HasOne("Data.Entities.Group", "Group")
                        .WithMany("Projects")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Data.Entities.Group", b =>
                {
                    b.Navigation("Metrics");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Data.Entities.Project", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Metrics");

                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
