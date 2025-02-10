﻿// <auto-generated />
using System;
using BeerParty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeerParty.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241029082022_UpdateRole")]
    partial class UpdateRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BeerParty.Data.Entities.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("FriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProfileId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Interest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ProfileId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Meeting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<long?>("CoAuthorId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("MeetingTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<short?>("ParticipantLimit")
                        .HasColumnType("smallint");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Radius")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CoAuthorId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingLike", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("MeetingId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("UserId");

                    b.ToTable("MeetingLikes");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingParticipant", b =>
                {
                    b.Property<long>("MeetingId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.HasKey("MeetingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MeetingParticipants");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<long>("MeetingId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MeetingId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.HasIndex("MeetingId1");

                    b.HasIndex("UserId");

                    b.ToTable("MeetingReviews");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingReviewLike", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("MeetingReviewId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MeetingReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("MeetingReviewLikes");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MessageEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<long>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<double?>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int?>("LookingFor")
                        .HasColumnType("integer");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.UserInterest", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("UserInterests");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Friend", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.User", "FriendUser")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.Profile", null)
                        .WithMany("Friends")
                        .HasForeignKey("ProfileId");

                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FriendUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Interest", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.Profile", null)
                        .WithMany("Interests")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Meeting", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.User", "CoAuthor")
                        .WithMany()
                        .HasForeignKey("CoAuthorId");

                    b.HasOne("BeerParty.Data.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoAuthor");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingLike", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.Meeting", "Meeting")
                        .WithMany("MeetingLikes")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithMany("MeetingLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingParticipant", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.Meeting", "Meeting")
                        .WithMany("Participants")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingReview", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.Meeting", "Meeting")
                        .WithMany("Reviews")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.Meeting", null)
                        .WithMany("MeetingReviews")
                        .HasForeignKey("MeetingId1");

                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithMany("MeetingReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingReviewLike", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.MeetingReview", "MeetingReview")
                        .WithMany("MeetingReviewLikes")
                        .HasForeignKey("MeetingReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithMany("MeetingReviewLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeetingReview");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MessageEntity", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Profile", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("BeerParty.Data.Entities.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.UserInterest", b =>
                {
                    b.HasOne("BeerParty.Data.Entities.Interest", "Interest")
                        .WithMany("UserInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerParty.Data.Entities.User", "User")
                        .WithMany("UserInterests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Interest", b =>
                {
                    b.Navigation("UserInterests");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Meeting", b =>
                {
                    b.Navigation("MeetingLikes");

                    b.Navigation("MeetingReviews");

                    b.Navigation("Participants");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.MeetingReview", b =>
                {
                    b.Navigation("MeetingReviewLikes");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.Profile", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("BeerParty.Data.Entities.User", b =>
                {
                    b.Navigation("MeetingLikes");

                    b.Navigation("MeetingReviewLikes");

                    b.Navigation("MeetingReviews");

                    b.Navigation("Profile")
                        .IsRequired();

                    b.Navigation("UserInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
