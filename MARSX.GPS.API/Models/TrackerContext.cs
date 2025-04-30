using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MARSX.GPS.API.Models;

public partial class TrackerContext : DbContext
{
    public TrackerContext()
    {
    }

    public TrackerContext(DbContextOptions<TrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aggregatedcounter> Aggregatedcounters { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Databasechangelog> Databasechangelogs { get; set; }

    public virtual DbSet<Databasechangeloglock> Databasechangeloglocks { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Jobparameter> Jobparameters { get; set; }

    public virtual DbSet<Jobqueue> Jobqueues { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Lock> Locks { get; set; }

    public virtual DbSet<MasterCompany> MasterCompanies { get; set; }

    public virtual DbSet<MasterCountry> MasterCountries { get; set; }

    public virtual DbSet<MasterDepartment> MasterDepartments { get; set; }

    public virtual DbSet<MasterDevice> MasterDevices { get; set; }

    public virtual DbSet<MasterDeviceCategory> MasterDeviceCategories { get; set; }

    public virtual DbSet<MasterDeviceGroup> MasterDeviceGroups { get; set; }

    public virtual DbSet<MasterDeviceStatus> MasterDeviceStatuses { get; set; }

    public virtual DbSet<MasterGpsProvider> MasterGpsProviders { get; set; }

    public virtual DbSet<MasterGpsStatus> MasterGpsStatuses { get; set; }

    public virtual DbSet<MasterPhoto> MasterPhotos { get; set; }

    public virtual DbSet<MasterPosition> MasterPositions { get; set; }

    public virtual DbSet<MasterThaiDistrict> MasterThaiDistricts { get; set; }

    public virtual DbSet<MasterThaiGeography> MasterThaiGeographies { get; set; }

    public virtual DbSet<MasterThaiProvince> MasterThaiProvinces { get; set; }

    public virtual DbSet<MasterThaiSubdistrict> MasterThaiSubdistricts { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<SysApplication> SysApplications { get; set; }

    public virtual DbSet<SysDeviceFavorite> SysDeviceFavorites { get; set; }

    public virtual DbSet<SysGroup> SysGroups { get; set; }

    public virtual DbSet<SysLog> SysLogs { get; set; }

    public virtual DbSet<SysLogApi> SysLogApis { get; set; }

    public virtual DbSet<SysMenu> SysMenus { get; set; }

    public virtual DbSet<SysMenuGroup> SysMenuGroups { get; set; }

    public virtual DbSet<SysPermission> SysPermissions { get; set; }

    public virtual DbSet<SysPermissionGroup> SysPermissionGroups { get; set; }

    public virtual DbSet<SysUser> SysUsers { get; set; }

    public virtual DbSet<TcAttribute> TcAttributes { get; set; }

    public virtual DbSet<TcCalendar> TcCalendars { get; set; }

    public virtual DbSet<TcCommand> TcCommands { get; set; }

    public virtual DbSet<TcCommandsQueue> TcCommandsQueues { get; set; }

    public virtual DbSet<TcDevice> TcDevices { get; set; }

    public virtual DbSet<TcDeviceAttribute> TcDeviceAttributes { get; set; }

    public virtual DbSet<TcDeviceCommand> TcDeviceCommands { get; set; }

    public virtual DbSet<TcDeviceDriver> TcDeviceDrivers { get; set; }

    public virtual DbSet<TcDeviceGeofence> TcDeviceGeofences { get; set; }

    public virtual DbSet<TcDeviceMaintenance> TcDeviceMaintenances { get; set; }

    public virtual DbSet<TcDeviceNotification> TcDeviceNotifications { get; set; }

    public virtual DbSet<TcDeviceOrder> TcDeviceOrders { get; set; }

    public virtual DbSet<TcDeviceReport> TcDeviceReports { get; set; }

    public virtual DbSet<TcDriver> TcDrivers { get; set; }

    public virtual DbSet<TcEvent> TcEvents { get; set; }

    public virtual DbSet<TcGeofence> TcGeofences { get; set; }

    public virtual DbSet<TcGroup> TcGroups { get; set; }

    public virtual DbSet<TcGroupAttribute> TcGroupAttributes { get; set; }

    public virtual DbSet<TcGroupCommand> TcGroupCommands { get; set; }

    public virtual DbSet<TcGroupDriver> TcGroupDrivers { get; set; }

    public virtual DbSet<TcGroupGeofence> TcGroupGeofences { get; set; }

    public virtual DbSet<TcGroupMaintenance> TcGroupMaintenances { get; set; }

    public virtual DbSet<TcGroupNotification> TcGroupNotifications { get; set; }

    public virtual DbSet<TcGroupOrder> TcGroupOrders { get; set; }

    public virtual DbSet<TcGroupReport> TcGroupReports { get; set; }

    public virtual DbSet<TcKeystore> TcKeystores { get; set; }

    public virtual DbSet<TcMaintenance> TcMaintenances { get; set; }

    public virtual DbSet<TcNotification> TcNotifications { get; set; }

    public virtual DbSet<TcOrder> TcOrders { get; set; }

    public virtual DbSet<TcPosition> TcPositions { get; set; }

    public virtual DbSet<TcReport> TcReports { get; set; }

    public virtual DbSet<TcServer> TcServers { get; set; }

    public virtual DbSet<TcStatistic> TcStatistics { get; set; }

    public virtual DbSet<TcUser> TcUsers { get; set; }

    public virtual DbSet<TcUserAttribute> TcUserAttributes { get; set; }

    public virtual DbSet<TcUserCalendar> TcUserCalendars { get; set; }

    public virtual DbSet<TcUserCommand> TcUserCommands { get; set; }

    public virtual DbSet<TcUserDevice> TcUserDevices { get; set; }

    public virtual DbSet<TcUserDriver> TcUserDrivers { get; set; }

    public virtual DbSet<TcUserGeofence> TcUserGeofences { get; set; }

    public virtual DbSet<TcUserGroup> TcUserGroups { get; set; }

    public virtual DbSet<TcUserMaintenance> TcUserMaintenances { get; set; }

    public virtual DbSet<TcUserNotification> TcUserNotifications { get; set; }

    public virtual DbSet<TcUserOrder> TcUserOrders { get; set; }

    public virtual DbSet<TcUserReport> TcUserReports { get; set; }

    public virtual DbSet<TcUserUser> TcUserUsers { get; set; }

    public virtual DbSet<WatchdogLog> WatchdogLogs { get; set; }

    public virtual DbSet<WatchdogWatchexceptionlog> WatchdogWatchexceptionlogs { get; set; }

    public virtual DbSet<WatchdogWatchlog> WatchdogWatchlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

        var connectionString = configuration.GetConnectionString("ConnectionStr");

        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseNpgsql(connectionString);

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aggregatedcounter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aggregatedcounter_pkey");

            entity.ToTable("aggregatedcounter", "hangfire");

            entity.HasIndex(e => e.Key, "aggregatedcounter_key_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("counter_pkey");

            entity.ToTable("counter", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_counter_expireat");

            entity.HasIndex(e => e.Key, "ix_hangfire_counter_key");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Databasechangelog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("databasechangelog");

            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.Contexts)
                .HasMaxLength(255)
                .HasColumnName("contexts");
            entity.Property(e => e.Dateexecuted)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateexecuted");
            entity.Property(e => e.DeploymentId)
                .HasMaxLength(10)
                .HasColumnName("deployment_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Exectype)
                .HasMaxLength(10)
                .HasColumnName("exectype");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasColumnName("filename");
            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.Labels)
                .HasMaxLength(255)
                .HasColumnName("labels");
            entity.Property(e => e.Liquibase)
                .HasMaxLength(20)
                .HasColumnName("liquibase");
            entity.Property(e => e.Md5sum)
                .HasMaxLength(35)
                .HasColumnName("md5sum");
            entity.Property(e => e.Orderexecuted).HasColumnName("orderexecuted");
            entity.Property(e => e.Tag)
                .HasMaxLength(255)
                .HasColumnName("tag");
        });

        modelBuilder.Entity<Databasechangeloglock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("databasechangeloglock_pkey");

            entity.ToTable("databasechangeloglock");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Locked).HasColumnName("locked");
            entity.Property(e => e.Lockedby)
                .HasMaxLength(255)
                .HasColumnName("lockedby");
            entity.Property(e => e.Lockgranted)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lockgranted");
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hash_pkey");

            entity.ToTable("hash", "hangfire");

            entity.HasIndex(e => new { e.Key, e.Field }, "hash_key_field_key").IsUnique();

            entity.HasIndex(e => e.Expireat, "ix_hangfire_hash_expireat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Field).HasColumnName("field");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("job_pkey");

            entity.ToTable("job", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_job_expireat");

            entity.HasIndex(e => e.Statename, "ix_hangfire_job_statename");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Arguments)
                .HasColumnType("jsonb")
                .HasColumnName("arguments");
            entity.Property(e => e.Createdat).HasColumnName("createdat");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Invocationdata)
                .HasColumnType("jsonb")
                .HasColumnName("invocationdata");
            entity.Property(e => e.Stateid).HasColumnName("stateid");
            entity.Property(e => e.Statename).HasColumnName("statename");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<Jobparameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobparameter_pkey");

            entity.ToTable("jobparameter", "hangfire");

            entity.HasIndex(e => new { e.Jobid, e.Name }, "ix_hangfire_jobparameter_jobidandname");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Job).WithMany(p => p.Jobparameters)
                .HasForeignKey(d => d.Jobid)
                .HasConstraintName("jobparameter_jobid_fkey");
        });

        modelBuilder.Entity<Jobqueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobqueue_pkey");

            entity.ToTable("jobqueue", "hangfire");

            entity.HasIndex(e => new { e.Jobid, e.Queue }, "ix_hangfire_jobqueue_jobidandqueue");

            entity.HasIndex(e => new { e.Queue, e.Fetchedat }, "ix_hangfire_jobqueue_queueandfetchedat");

            entity.HasIndex(e => new { e.Queue, e.Fetchedat, e.Jobid }, "jobqueue_queue_fetchat_jobid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fetchedat).HasColumnName("fetchedat");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Queue).HasColumnName("queue");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_pkey");

            entity.ToTable("list", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_list_expireat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Lock>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lock", "hangfire");

            entity.HasIndex(e => e.Resource, "lock_resource_key").IsUnique();

            entity.Property(e => e.Acquired).HasColumnName("acquired");
            entity.Property(e => e.Resource).HasColumnName("resource");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<MasterCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_company_pk");

            entity.ToTable("master_company");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressEn)
                .HasColumnType("character varying")
                .HasColumnName("address_en");
            entity.Property(e => e.AddressTh)
                .HasColumnType("character varying")
                .HasColumnName("address_th");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.ContactEmail)
                .HasColumnType("character varying")
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactName)
                .HasColumnType("character varying")
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactTel)
                .HasColumnType("character varying")
                .HasColumnName("contact_tel");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.SubDistrictId)
                .HasColumnType("character varying")
                .HasColumnName("sub_district_id");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.ZipCode).HasColumnName("zip_code");
        });

        modelBuilder.Entity<MasterCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_country_pk");

            entity.ToTable("master_country");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('country_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .HasColumnName("currency_code");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasMaxLength(150)
                .HasColumnName("name_th");
        });

        modelBuilder.Entity<MasterDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_department_pk");

            entity.ToTable("master_department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MasterCompanyId).HasColumnName("master_company_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_device_pk");

            entity.ToTable("master_device");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarNo)
                .HasColumnType("character varying")
                .HasColumnName("car_no");
            entity.Property(e => e.Chassis)
                .HasColumnType("character varying")
                .HasColumnName("chassis");
            entity.Property(e => e.CompanyOwnerName)
                .HasColumnType("character varying")
                .HasColumnName("company_owner_name");
            entity.Property(e => e.Contact)
                .HasColumnType("character varying")
                .HasColumnName("contact");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.Manufacturer)
                .HasColumnType("character varying")
                .HasColumnName("manufacturer");
            entity.Property(e => e.MasterDeviceCategoryId).HasColumnName("master_device_category_id");
            entity.Property(e => e.MasterDeviceGroupId).HasColumnName("master_device_group_id");
            entity.Property(e => e.MasterDeviceStatusId).HasColumnName("master_device_status_id");
            entity.Property(e => e.MasterGpsProviderId).HasColumnName("master_gps_provider_id");
            entity.Property(e => e.Model)
                .HasColumnType("character varying")
                .HasColumnName("model");
            entity.Property(e => e.ModelYear)
                .HasColumnType("character varying")
                .HasColumnName("model_year");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.RefTrackingId)
                .HasColumnType("character varying")
                .HasColumnName("ref_tracking_id");
            entity.Property(e => e.SerialNo)
                .HasColumnType("character varying")
                .HasColumnName("serial_no");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterDeviceCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_device_category_pk");

            entity.ToTable("master_device_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterDeviceGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_device_group_pk");

            entity.ToTable("master_device_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterDeviceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_device_status_pk");

            entity.ToTable("master_device_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterGpsProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_gps_provider_pk");

            entity.ToTable("master_gps_provider");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterGpsStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_gps_status_pk");

            entity.ToTable("master_gps_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_photo_pk");

            entity.ToTable("master_photo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categery)
                .HasColumnType("character varying")
                .HasColumnName("categery");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.Label)
                .HasColumnType("character varying")
                .HasColumnName("label");
            entity.Property(e => e.Location)
                .HasColumnType("character varying")
                .HasColumnName("location");
            entity.Property(e => e.MasterDeviceId).HasColumnName("master_device_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Size)
                .HasColumnType("character varying")
                .HasColumnName("size");
            entity.Property(e => e.SizeUnit)
                .HasColumnType("character varying")
                .HasColumnName("size_unit");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("master_position_pk");

            entity.ToTable("master_position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.MasterDepartmentId).HasColumnName("master_department_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<MasterThaiDistrict>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("master_thai_districts");

            entity.Property(e => e.CreatedAt)
                .HasMaxLength(50)
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasMaxLength(50)
                .HasColumnName("deleted_at");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasMaxLength(50)
                .HasColumnName("name_th");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(50)
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MasterThaiGeography>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("master_thai_geographies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MasterThaiProvince>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("master_thai_provinces");

            entity.Property(e => e.CreatedAt)
                .HasMaxLength(50)
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasMaxLength(50)
                .HasColumnName("deleted_at");
            entity.Property(e => e.GeographyId).HasColumnName("geography_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasMaxLength(50)
                .HasColumnName("name_th");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(50)
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<MasterThaiSubdistrict>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("master_thai_subdistricts");

            entity.Property(e => e.CreatedAt)
                .HasMaxLength(50)
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasMaxLength(50)
                .HasColumnName("deleted_at");
            entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasMaxLength(50)
                .HasColumnName("name_th");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(50)
                .HasColumnName("updated_at");
            entity.Property(e => e.ZipCode).HasColumnName("zip_code");
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("schema_pkey");

            entity.ToTable("schema", "hangfire");

            entity.Property(e => e.Version)
                .ValueGeneratedNever()
                .HasColumnName("version");
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("server_pkey");

            entity.ToTable("server", "hangfire");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Lastheartbeat).HasColumnName("lastheartbeat");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("set_pkey");

            entity.ToTable("set", "hangfire");

            entity.HasIndex(e => e.Expireat, "ix_hangfire_set_expireat");

            entity.HasIndex(e => new { e.Key, e.Score }, "ix_hangfire_set_key_score");

            entity.HasIndex(e => new { e.Key, e.Value }, "set_key_value_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expireat).HasColumnName("expireat");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("state_pkey");

            entity.ToTable("state", "hangfire");

            entity.HasIndex(e => e.Jobid, "ix_hangfire_state_jobid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat).HasColumnName("createdat");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Jobid).HasColumnName("jobid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Updatecount)
                .HasDefaultValue(0)
                .HasColumnName("updatecount");

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.Jobid)
                .HasConstraintName("state_jobid_fkey");
        });

        modelBuilder.Entity<SysApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_application_pk");

            entity.ToTable("sys_application");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<SysDeviceFavorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_device_favorite_pk");

            entity.ToTable("sys_device_favorite");

            entity.HasIndex(e => e.DeviceId, "sys_device_favorite_device_id_idx");

            entity.HasIndex(e => e.UserName, "sys_device_favorite_user_name_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<SysGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_group_pk");

            entity.ToTable("sys_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.NameEn)
                .HasColumnType("character varying")
                .HasColumnName("name_en");
            entity.Property(e => e.NameTh)
                .HasColumnType("character varying")
                .HasColumnName("name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<SysLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_logs_pk");

            entity.ToTable("sys_logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientAddress)
                .HasColumnType("character varying")
                .HasColumnName("client_address");
            entity.Property(e => e.ClientAgent)
                .HasColumnType("character varying")
                .HasColumnName("client_agent");
            entity.Property(e => e.ClientBrowser)
                .HasColumnType("character varying")
                .HasColumnName("client_browser");
            entity.Property(e => e.ClientDatetime)
                .HasColumnType("character varying")
                .HasColumnName("client_datetime");
            entity.Property(e => e.ClientDevice)
                .HasColumnType("character varying")
                .HasColumnName("client_device");
            entity.Property(e => e.ClientIp)
                .HasColumnType("character varying")
                .HasColumnName("client_ip");
            entity.Property(e => e.ClientLanguage)
                .HasColumnType("character varying")
                .HasColumnName("client_language");
            entity.Property(e => e.ClientLatitude)
                .HasColumnType("character varying")
                .HasColumnName("client_latitude");
            entity.Property(e => e.ClientLongitude)
                .HasColumnType("character varying")
                .HasColumnName("client_longitude");
            entity.Property(e => e.ClientPlatform)
                .HasColumnType("character varying")
                .HasColumnName("client_platform");
            entity.Property(e => e.IspCountry)
                .HasColumnType("character varying")
                .HasColumnName("isp_country");
            entity.Property(e => e.IspName)
                .HasColumnType("character varying")
                .HasColumnName("isp_name");
            entity.Property(e => e.ServerDatetime)
                .HasColumnType("character varying")
                .HasColumnName("server_datetime");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<SysLogApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_log_api_pk");

            entity.ToTable("sys_log_api");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ControllerName)
                .HasColumnType("character varying")
                .HasColumnName("controller_name");
            entity.Property(e => e.EstimateTime)
                .HasColumnType("character varying")
                .HasColumnName("estimate_time");
            entity.Property(e => e.MethodName)
                .HasColumnType("character varying")
                .HasColumnName("method_name");
            entity.Property(e => e.ServerDatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("server_datetime");
            entity.Property(e => e.ServiceName)
                .HasColumnType("character varying")
                .HasColumnName("service_name");
            entity.Property(e => e.UnitOfTime)
                .HasColumnType("character varying")
                .HasColumnName("unit_of_time");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<SysMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_menu_pk");

            entity.ToTable("sys_menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("character varying")
                .HasColumnName("action");
            entity.Property(e => e.Controller)
                .HasColumnType("character varying")
                .HasColumnName("controller");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MenuCode)
                .HasColumnType("character varying")
                .HasColumnName("menu_code");
            entity.Property(e => e.MenuDesription)
                .HasColumnType("character varying")
                .HasColumnName("menu_desription");
            entity.Property(e => e.MenuGroup)
                .HasColumnType("character varying")
                .HasColumnName("menu_group");
            entity.Property(e => e.MenuGroupIcon)
                .HasColumnType("character varying")
                .HasColumnName("menu_group_icon");
            entity.Property(e => e.MenuGroupName)
                .HasColumnType("character varying")
                .HasColumnName("menu_group_name");
            entity.Property(e => e.MenuGroupSeq)
                .HasColumnType("character varying")
                .HasColumnName("menu_group_seq");
            entity.Property(e => e.MenuIcon)
                .HasColumnType("character varying")
                .HasColumnName("menu_icon");
            entity.Property(e => e.MenuName)
                .HasColumnType("character varying")
                .HasColumnName("menu_name");
            entity.Property(e => e.MenuSequence).HasColumnName("menu_sequence");
            entity.Property(e => e.SysApplicationId).HasColumnName("sys_application_id");
        });

        modelBuilder.Entity<SysMenuGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_menu_group_pk");

            entity.ToTable("sys_menu_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowAccess)
                .HasDefaultValue(true)
                .HasColumnName("allow_access");
            entity.Property(e => e.SysMenuId).HasColumnName("sys_menu_id");
            entity.Property(e => e.SysPermissionGroupId).HasColumnName("sys_permission_group_id");
        });

        modelBuilder.Entity<SysPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_pk");

            entity.ToTable("sys_permission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowAccess)
                .HasDefaultValue(true)
                .HasColumnName("allow_access");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<SysPermissionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_permission_group_pk");

            entity.ToTable("sys_permission_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowAccess)
                .HasDefaultValue(true)
                .HasColumnName("allow_access");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<SysUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sys_users_pk");

            entity.ToTable("sys_users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreateBy)
                .HasColumnType("character varying")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstNameEn)
                .HasColumnType("character varying")
                .HasColumnName("first_name_en");
            entity.Property(e => e.FirstNameTh)
                .HasColumnType("character varying")
                .HasColumnName("first_name_th");
            entity.Property(e => e.Gender)
                .HasColumnType("character varying")
                .HasColumnName("gender");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(false)
                .HasColumnName("is_active");
            entity.Property(e => e.LastNameEn)
                .HasColumnType("character varying")
                .HasColumnName("last_name_en");
            entity.Property(e => e.LastNameTh)
                .HasColumnType("character varying")
                .HasColumnName("last_name_th");
            entity.Property(e => e.MasterCompanyId).HasColumnName("master_company_id");
            entity.Property(e => e.MasterDepartmentId).HasColumnName("master_department_id");
            entity.Property(e => e.MasterPositionId).HasColumnName("master_position_id");
            entity.Property(e => e.PassCode).HasColumnName("pass_code");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.PrefixNameEn)
                .HasColumnType("character varying")
                .HasColumnName("prefix_name_en");
            entity.Property(e => e.PrefixNameTh)
                .HasColumnType("character varying")
                .HasColumnName("prefix_name_th");
            entity.Property(e => e.UpdateBy)
                .HasColumnType("character varying")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<TcAttribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_attributes_pkey");

            entity.ToTable("tc_attributes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attribute)
                .HasMaxLength(128)
                .HasColumnName("attribute");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasColumnName("description");
            entity.Property(e => e.Expression)
                .HasMaxLength(4000)
                .HasColumnName("expression");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .HasColumnName("type");
        });

        modelBuilder.Entity<TcCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_calendars_pkey");

            entity.ToTable("tc_calendars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TcCommand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_commands_pkey");

            entity.ToTable("tc_commands");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasColumnName("description");
            entity.Property(e => e.Textchannel)
                .HasDefaultValue(false)
                .HasColumnName("textchannel");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .HasColumnName("type");
        });

        modelBuilder.Entity<TcCommandsQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_commands_queue_pkey");

            entity.ToTable("tc_commands_queue");

            entity.HasIndex(e => e.Deviceid, "idx_commands_queue_deviceid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Textchannel)
                .HasDefaultValue(false)
                .HasColumnName("textchannel");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .HasColumnName("type");

            entity.HasOne(d => d.Device).WithMany(p => p.TcCommandsQueues)
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_commands_queue_deviceid");
        });

        modelBuilder.Entity<TcDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_devices_pkey");

            entity.ToTable("tc_devices");

            entity.HasIndex(e => e.Uniqueid, "idx_devices_uniqueid");

            entity.HasIndex(e => e.Uniqueid, "tc_devices_uniqueid_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Calendarid).HasColumnName("calendarid");
            entity.Property(e => e.Category)
                .HasMaxLength(128)
                .HasColumnName("category");
            entity.Property(e => e.Contact)
                .HasMaxLength(512)
                .HasColumnName("contact");
            entity.Property(e => e.Disabled)
                .HasDefaultValue(false)
                .HasColumnName("disabled");
            entity.Property(e => e.Expirationtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expirationtime");
            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Lastupdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdate");
            entity.Property(e => e.Model)
                .HasMaxLength(128)
                .HasColumnName("model");
            entity.Property(e => e.Motiondistance)
                .HasDefaultValueSql("0")
                .HasColumnName("motiondistance");
            entity.Property(e => e.Motionstate)
                .HasDefaultValue(false)
                .HasColumnName("motionstate");
            entity.Property(e => e.Motionstreak)
                .HasDefaultValue(false)
                .HasColumnName("motionstreak");
            entity.Property(e => e.Motiontime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("motiontime");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Overspeedgeofenceid)
                .HasDefaultValue(0)
                .HasColumnName("overspeedgeofenceid");
            entity.Property(e => e.Overspeedstate)
                .HasDefaultValue(false)
                .HasColumnName("overspeedstate");
            entity.Property(e => e.Overspeedtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("overspeedtime");
            entity.Property(e => e.Phone)
                .HasMaxLength(128)
                .HasColumnName("phone");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Status)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Uniqueid)
                .HasMaxLength(128)
                .HasColumnName("uniqueid");

            entity.HasOne(d => d.Calendar).WithMany(p => p.TcDevices)
                .HasForeignKey(d => d.Calendarid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_devices_calendarid");

            entity.HasOne(d => d.Group).WithMany(p => p.TcDevices)
                .HasForeignKey(d => d.Groupid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_devices_groupid");
        });

        modelBuilder.Entity<TcDeviceAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_attribute");

            entity.Property(e => e.Attributeid).HasColumnName("attributeid");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");

            entity.HasOne(d => d.Attribute).WithMany()
                .HasForeignKey(d => d.Attributeid)
                .HasConstraintName("fk_user_device_attribute_attributeid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_user_device_attribute_deviceid");
        });

        modelBuilder.Entity<TcDeviceCommand>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_command");

            entity.Property(e => e.Commandid).HasColumnName("commandid");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");

            entity.HasOne(d => d.Command).WithMany()
                .HasForeignKey(d => d.Commandid)
                .HasConstraintName("fk_device_command_commandid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_command_deviceid");
        });

        modelBuilder.Entity<TcDeviceDriver>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_driver");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Driverid).HasColumnName("driverid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_driver_deviceid");

            entity.HasOne(d => d.Driver).WithMany()
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("fk_device_driver_driverid");
        });

        modelBuilder.Entity<TcDeviceGeofence>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_geofence");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Geofenceid).HasColumnName("geofenceid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_geofence_deviceid");

            entity.HasOne(d => d.Geofence).WithMany()
                .HasForeignKey(d => d.Geofenceid)
                .HasConstraintName("fk_device_geofence_geofenceid");
        });

        modelBuilder.Entity<TcDeviceMaintenance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_maintenance");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Maintenanceid).HasColumnName("maintenanceid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_maintenance_deviceid");

            entity.HasOne(d => d.Maintenance).WithMany()
                .HasForeignKey(d => d.Maintenanceid)
                .HasConstraintName("fk_device_maintenance_maintenanceid");
        });

        modelBuilder.Entity<TcDeviceNotification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_notification");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Notificationid).HasColumnName("notificationid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_notification_deviceid");

            entity.HasOne(d => d.Notification).WithMany()
                .HasForeignKey(d => d.Notificationid)
                .HasConstraintName("fk_device_notification_notificationid");
        });

        modelBuilder.Entity<TcDeviceOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_order");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_order_deviceid");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("fk_device_order_orderid");
        });

        modelBuilder.Entity<TcDeviceReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_device_report");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Reportid).HasColumnName("reportid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_device_report_deviceid");

            entity.HasOne(d => d.Report).WithMany()
                .HasForeignKey(d => d.Reportid)
                .HasConstraintName("fk_device_report_reportid");
        });

        modelBuilder.Entity<TcDriver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_drivers_pkey");

            entity.ToTable("tc_drivers");

            entity.HasIndex(e => e.Uniqueid, "idx_drivers_uniqueid");

            entity.HasIndex(e => e.Uniqueid, "tc_drivers_uniqueid_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Uniqueid)
                .HasMaxLength(128)
                .HasColumnName("uniqueid");
        });

        modelBuilder.Entity<TcEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_events_pkey");

            entity.ToTable("tc_events");

            entity.HasIndex(e => new { e.Deviceid, e.Eventtime }, "event_deviceid_servertime");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Eventtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("eventtime");
            entity.Property(e => e.Geofenceid).HasColumnName("geofenceid");
            entity.Property(e => e.Maintenanceid).HasColumnName("maintenanceid");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .HasColumnName("type");

            entity.HasOne(d => d.Device).WithMany(p => p.TcEvents)
                .HasForeignKey(d => d.Deviceid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_events_deviceid");
        });

        modelBuilder.Entity<TcGeofence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_geofences_pkey");

            entity.ToTable("tc_geofences");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(4096)
                .HasColumnName("area");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Calendarid).HasColumnName("calendarid");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");

            entity.HasOne(d => d.Calendar).WithMany(p => p.TcGeofences)
                .HasForeignKey(d => d.Calendarid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_geofence_calendar_calendarid");
        });

        modelBuilder.Entity<TcGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_groups_pkey");

            entity.ToTable("tc_groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");

            entity.HasOne(d => d.Group).WithMany(p => p.InverseGroup)
                .HasForeignKey(d => d.Groupid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_groups_groupid");
        });

        modelBuilder.Entity<TcGroupAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_attribute");

            entity.Property(e => e.Attributeid).HasColumnName("attributeid");
            entity.Property(e => e.Groupid).HasColumnName("groupid");

            entity.HasOne(d => d.Attribute).WithMany()
                .HasForeignKey(d => d.Attributeid)
                .HasConstraintName("fk_group_attribute_attributeid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_attribute_groupid");
        });

        modelBuilder.Entity<TcGroupCommand>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_command");

            entity.Property(e => e.Commandid).HasColumnName("commandid");
            entity.Property(e => e.Groupid).HasColumnName("groupid");

            entity.HasOne(d => d.Command).WithMany()
                .HasForeignKey(d => d.Commandid)
                .HasConstraintName("fk_group_command_commandid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_command_groupid");
        });

        modelBuilder.Entity<TcGroupDriver>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_driver");

            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Groupid).HasColumnName("groupid");

            entity.HasOne(d => d.Driver).WithMany()
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("fk_group_driver_driverid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_driver_groupid");
        });

        modelBuilder.Entity<TcGroupGeofence>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_geofence");

            entity.Property(e => e.Geofenceid).HasColumnName("geofenceid");
            entity.Property(e => e.Groupid).HasColumnName("groupid");

            entity.HasOne(d => d.Geofence).WithMany()
                .HasForeignKey(d => d.Geofenceid)
                .HasConstraintName("fk_group_geofence_geofenceid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_geofence_groupid");
        });

        modelBuilder.Entity<TcGroupMaintenance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_maintenance");

            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Maintenanceid).HasColumnName("maintenanceid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_maintenance_groupid");

            entity.HasOne(d => d.Maintenance).WithMany()
                .HasForeignKey(d => d.Maintenanceid)
                .HasConstraintName("fk_group_maintenance_maintenanceid");
        });

        modelBuilder.Entity<TcGroupNotification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_notification");

            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Notificationid).HasColumnName("notificationid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_notification_groupid");

            entity.HasOne(d => d.Notification).WithMany()
                .HasForeignKey(d => d.Notificationid)
                .HasConstraintName("fk_group_notification_notificationid");
        });

        modelBuilder.Entity<TcGroupOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_order");

            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_order_groupid");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("fk_group_order_orderid");
        });

        modelBuilder.Entity<TcGroupReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_group_report");

            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Reportid).HasColumnName("reportid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_group_report_groupid");

            entity.HasOne(d => d.Report).WithMany()
                .HasForeignKey(d => d.Reportid)
                .HasConstraintName("fk_group_report_reportid");
        });

        modelBuilder.Entity<TcKeystore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_keystore_pkey");

            entity.ToTable("tc_keystore");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Privatekey).HasColumnName("privatekey");
            entity.Property(e => e.Publickey).HasColumnName("publickey");
        });

        modelBuilder.Entity<TcMaintenance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_maintenances_pkey");

            entity.ToTable("tc_maintenances");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Name)
                .HasMaxLength(4000)
                .HasColumnName("name");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.Start).HasColumnName("start");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .HasColumnName("type");
        });

        modelBuilder.Entity<TcNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_notifications_pkey");

            entity.ToTable("tc_notifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Always)
                .HasDefaultValue(false)
                .HasColumnName("always");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Calendarid).HasColumnName("calendarid");
            entity.Property(e => e.Commandid).HasColumnName("commandid");
            entity.Property(e => e.Notificators)
                .HasMaxLength(128)
                .HasColumnName("notificators");
            entity.Property(e => e.Type)
                .HasMaxLength(128)
                .HasColumnName("type");

            entity.HasOne(d => d.Calendar).WithMany(p => p.TcNotifications)
                .HasForeignKey(d => d.Calendarid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_notification_calendar_calendarid");

            entity.HasOne(d => d.Command).WithMany(p => p.TcNotifications)
                .HasForeignKey(d => d.Commandid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_notifications_commandid");
        });

        modelBuilder.Entity<TcOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_orders_pkey");

            entity.ToTable("tc_orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .HasColumnName("description");
            entity.Property(e => e.Fromaddress)
                .HasMaxLength(512)
                .HasColumnName("fromaddress");
            entity.Property(e => e.Toaddress)
                .HasMaxLength(512)
                .HasColumnName("toaddress");
            entity.Property(e => e.Uniqueid)
                .HasMaxLength(128)
                .HasColumnName("uniqueid");
        });

        modelBuilder.Entity<TcPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_positions_pkey");

            entity.ToTable("tc_positions");

            entity.HasIndex(e => new { e.Deviceid, e.Fixtime }, "position_deviceid_fixtime");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accuracy).HasColumnName("accuracy");
            entity.Property(e => e.Address)
                .HasMaxLength(512)
                .HasColumnName("address");
            entity.Property(e => e.Altitude).HasColumnName("altitude");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Devicetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("devicetime");
            entity.Property(e => e.Fixtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fixtime");
            entity.Property(e => e.Geofenceids)
                .HasMaxLength(128)
                .HasColumnName("geofenceids");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Network)
                .HasMaxLength(4000)
                .HasColumnName("network");
            entity.Property(e => e.Protocol)
                .HasMaxLength(128)
                .HasColumnName("protocol");
            entity.Property(e => e.Servertime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("servertime");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Valid).HasColumnName("valid");

            entity.HasOne(d => d.Device).WithMany(p => p.TcPositions)
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_positions_deviceid");
        });

        modelBuilder.Entity<TcReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_reports_pkey");

            entity.ToTable("tc_reports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Calendarid).HasColumnName("calendarid");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(32)
                .HasColumnName("type");

            entity.HasOne(d => d.Calendar).WithMany(p => p.TcReports)
                .HasForeignKey(d => d.Calendarid)
                .HasConstraintName("fk_reports_calendarid");
        });

        modelBuilder.Entity<TcServer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_servers_pkey");

            entity.ToTable("tc_servers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Announcement)
                .HasMaxLength(4000)
                .HasColumnName("announcement");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Bingkey)
                .HasMaxLength(128)
                .HasColumnName("bingkey");
            entity.Property(e => e.Coordinateformat)
                .HasMaxLength(128)
                .HasColumnName("coordinateformat");
            entity.Property(e => e.Devicereadonly)
                .HasDefaultValue(false)
                .HasColumnName("devicereadonly");
            entity.Property(e => e.Disablereports)
                .HasDefaultValue(false)
                .HasColumnName("disablereports");
            entity.Property(e => e.Fixedemail)
                .HasDefaultValue(false)
                .HasColumnName("fixedemail");
            entity.Property(e => e.Forcesettings)
                .HasDefaultValue(false)
                .HasColumnName("forcesettings");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Limitcommands)
                .HasDefaultValue(false)
                .HasColumnName("limitcommands");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Map)
                .HasMaxLength(128)
                .HasColumnName("map");
            entity.Property(e => e.Mapurl)
                .HasMaxLength(512)
                .HasColumnName("mapurl");
            entity.Property(e => e.Overlayurl)
                .HasMaxLength(512)
                .HasColumnName("overlayurl");
            entity.Property(e => e.Poilayer)
                .HasMaxLength(512)
                .HasColumnName("poilayer");
            entity.Property(e => e.Readonly)
                .HasDefaultValue(false)
                .HasColumnName("readonly");
            entity.Property(e => e.Registration)
                .HasDefaultValue(true)
                .HasColumnName("registration");
            entity.Property(e => e.Twelvehourformat)
                .HasDefaultValue(false)
                .HasColumnName("twelvehourformat");
            entity.Property(e => e.Zoom)
                .HasDefaultValue(0)
                .HasColumnName("zoom");
        });

        modelBuilder.Entity<TcStatistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_statistics_pkey");

            entity.ToTable("tc_statistics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activedevices)
                .HasDefaultValue(0)
                .HasColumnName("activedevices");
            entity.Property(e => e.Activeusers)
                .HasDefaultValue(0)
                .HasColumnName("activeusers");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4096)
                .HasColumnName("attributes");
            entity.Property(e => e.Capturetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("capturetime");
            entity.Property(e => e.Geocoderrequests)
                .HasDefaultValue(0)
                .HasColumnName("geocoderrequests");
            entity.Property(e => e.Geolocationrequests)
                .HasDefaultValue(0)
                .HasColumnName("geolocationrequests");
            entity.Property(e => e.Mailsent)
                .HasDefaultValue(0)
                .HasColumnName("mailsent");
            entity.Property(e => e.Messagesreceived)
                .HasDefaultValue(0)
                .HasColumnName("messagesreceived");
            entity.Property(e => e.Messagesstored)
                .HasDefaultValue(0)
                .HasColumnName("messagesstored");
            entity.Property(e => e.Protocols)
                .HasMaxLength(4096)
                .HasColumnName("protocols");
            entity.Property(e => e.Requests)
                .HasDefaultValue(0)
                .HasColumnName("requests");
            entity.Property(e => e.Smssent)
                .HasDefaultValue(0)
                .HasColumnName("smssent");
        });

        modelBuilder.Entity<TcUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tc_users_pkey");

            entity.ToTable("tc_users");

            entity.HasIndex(e => e.Email, "idx_users_email");

            entity.HasIndex(e => e.Login, "idx_users_login");

            entity.HasIndex(e => e.Email, "tc_users_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Administrator).HasColumnName("administrator");
            entity.Property(e => e.Attributes)
                .HasMaxLength(4000)
                .HasColumnName("attributes");
            entity.Property(e => e.Coordinateformat)
                .HasMaxLength(128)
                .HasColumnName("coordinateformat");
            entity.Property(e => e.Devicelimit)
                .HasDefaultValueSql("'-1'::integer")
                .HasColumnName("devicelimit");
            entity.Property(e => e.Devicereadonly)
                .HasDefaultValue(false)
                .HasColumnName("devicereadonly");
            entity.Property(e => e.Disabled)
                .HasDefaultValue(false)
                .HasColumnName("disabled");
            entity.Property(e => e.Disablereports)
                .HasDefaultValue(false)
                .HasColumnName("disablereports");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.Expirationtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expirationtime");
            entity.Property(e => e.Fixedemail)
                .HasDefaultValue(false)
                .HasColumnName("fixedemail");
            entity.Property(e => e.Hashedpassword)
                .HasMaxLength(128)
                .HasColumnName("hashedpassword");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Limitcommands)
                .HasDefaultValue(false)
                .HasColumnName("limitcommands");
            entity.Property(e => e.Login)
                .HasMaxLength(128)
                .HasColumnName("login");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.Map)
                .HasMaxLength(128)
                .HasColumnName("map");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(128)
                .HasColumnName("phone");
            entity.Property(e => e.Poilayer)
                .HasMaxLength(512)
                .HasColumnName("poilayer");
            entity.Property(e => e.Readonly)
                .HasDefaultValue(false)
                .HasColumnName("readonly");
            entity.Property(e => e.Salt)
                .HasMaxLength(128)
                .HasColumnName("salt");
            entity.Property(e => e.Temporary)
                .HasDefaultValue(false)
                .HasColumnName("temporary");
            entity.Property(e => e.Totpkey)
                .HasMaxLength(64)
                .HasColumnName("totpkey");
            entity.Property(e => e.Twelvehourformat)
                .HasDefaultValue(false)
                .HasColumnName("twelvehourformat");
            entity.Property(e => e.Userlimit)
                .HasDefaultValue(0)
                .HasColumnName("userlimit");
            entity.Property(e => e.Zoom)
                .HasDefaultValue(0)
                .HasColumnName("zoom");
        });

        modelBuilder.Entity<TcUserAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_attribute");

            entity.Property(e => e.Attributeid).HasColumnName("attributeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Attribute).WithMany()
                .HasForeignKey(d => d.Attributeid)
                .HasConstraintName("fk_user_attribute_attributeid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_attribute_userid");
        });

        modelBuilder.Entity<TcUserCalendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_calendar");

            entity.Property(e => e.Calendarid).HasColumnName("calendarid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Calendar).WithMany()
                .HasForeignKey(d => d.Calendarid)
                .HasConstraintName("fk_user_calendar_calendarid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_calendar_userid");
        });

        modelBuilder.Entity<TcUserCommand>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_command");

            entity.Property(e => e.Commandid).HasColumnName("commandid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Command).WithMany()
                .HasForeignKey(d => d.Commandid)
                .HasConstraintName("fk_user_command_commandid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_command_userid");
        });

        modelBuilder.Entity<TcUserDevice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_device");

            entity.HasIndex(e => e.Userid, "user_device_user_id");

            entity.Property(e => e.Deviceid).HasColumnName("deviceid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Device).WithMany()
                .HasForeignKey(d => d.Deviceid)
                .HasConstraintName("fk_user_device_deviceid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_device_userid");
        });

        modelBuilder.Entity<TcUserDriver>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_driver");

            entity.Property(e => e.Driverid).HasColumnName("driverid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Driver).WithMany()
                .HasForeignKey(d => d.Driverid)
                .HasConstraintName("fk_user_driver_driverid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_driver_userid");
        });

        modelBuilder.Entity<TcUserGeofence>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_geofence");

            entity.Property(e => e.Geofenceid).HasColumnName("geofenceid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Geofence).WithMany()
                .HasForeignKey(d => d.Geofenceid)
                .HasConstraintName("fk_user_geofence_geofenceid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_geofence_userid");
        });

        modelBuilder.Entity<TcUserGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_group");

            entity.Property(e => e.Groupid).HasColumnName("groupid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.Groupid)
                .HasConstraintName("fk_user_group_groupid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_group_userid");
        });

        modelBuilder.Entity<TcUserMaintenance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_maintenance");

            entity.Property(e => e.Maintenanceid).HasColumnName("maintenanceid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Maintenance).WithMany()
                .HasForeignKey(d => d.Maintenanceid)
                .HasConstraintName("fk_user_maintenance_maintenanceid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_maintenance_userid");
        });

        modelBuilder.Entity<TcUserNotification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_notification");

            entity.Property(e => e.Notificationid).HasColumnName("notificationid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Notification).WithMany()
                .HasForeignKey(d => d.Notificationid)
                .HasConstraintName("fk_user_notification_notificationid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_notification_userid");
        });

        modelBuilder.Entity<TcUserOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_order");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("fk_user_order_orderid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_order_userid");
        });

        modelBuilder.Entity<TcUserReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_report");

            entity.Property(e => e.Reportid).HasColumnName("reportid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Report).WithMany()
                .HasForeignKey(d => d.Reportid)
                .HasConstraintName("fk_user_report_reportid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_report_userid");
        });

        modelBuilder.Entity<TcUserUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tc_user_user");

            entity.Property(e => e.Manageduserid).HasColumnName("manageduserid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Manageduser).WithMany()
                .HasForeignKey(d => d.Manageduserid)
                .HasConstraintName("fk_user_user_manageduserid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("fk_user_user_userid");
        });

        modelBuilder.Entity<WatchdogLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("watchdog_logs_pkey");

            entity.ToTable("watchdog_logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Callingfrom)
                .HasColumnType("character varying")
                .HasColumnName("callingfrom");
            entity.Property(e => e.Callingmethod)
                .HasMaxLength(100)
                .HasColumnName("callingmethod");
            entity.Property(e => e.Eventid)
                .HasMaxLength(100)
                .HasColumnName("eventid");
            entity.Property(e => e.Linenumber).HasColumnName("linenumber");
            entity.Property(e => e.Loglevel)
                .HasMaxLength(30)
                .HasColumnName("loglevel");
            entity.Property(e => e.Message)
                .HasColumnType("character varying")
                .HasColumnName("message");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
        });

        modelBuilder.Entity<WatchdogWatchexceptionlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("watchdog_watchexceptionlog_pkey");

            entity.ToTable("watchdog_watchexceptionlog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Encounteredat).HasColumnName("encounteredat");
            entity.Property(e => e.Message)
                .HasColumnType("character varying")
                .HasColumnName("message");
            entity.Property(e => e.Method)
                .HasMaxLength(30)
                .HasColumnName("method");
            entity.Property(e => e.Path)
                .HasColumnType("character varying")
                .HasColumnName("path");
            entity.Property(e => e.Querystring)
                .HasColumnType("character varying")
                .HasColumnName("querystring");
            entity.Property(e => e.Requestbody)
                .HasColumnType("character varying")
                .HasColumnName("requestbody");
            entity.Property(e => e.Source)
                .HasColumnType("character varying")
                .HasColumnName("source");
            entity.Property(e => e.Stacktrace)
                .HasColumnType("character varying")
                .HasColumnName("stacktrace");
            entity.Property(e => e.Typeof)
                .HasColumnType("character varying")
                .HasColumnName("typeof");
        });

        modelBuilder.Entity<WatchdogWatchlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("watchdog_watchlog_pkey");

            entity.ToTable("watchdog_watchlog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Host)
                .HasColumnType("character varying")
                .HasColumnName("host");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(30)
                .HasColumnName("ipaddress");
            entity.Property(e => e.Method)
                .HasMaxLength(30)
                .HasColumnName("method");
            entity.Property(e => e.Path)
                .HasColumnType("character varying")
                .HasColumnName("path");
            entity.Property(e => e.Querystring)
                .HasColumnType("character varying")
                .HasColumnName("querystring");
            entity.Property(e => e.Requestbody)
                .HasColumnType("character varying")
                .HasColumnName("requestbody");
            entity.Property(e => e.Requestheaders)
                .HasColumnType("character varying")
                .HasColumnName("requestheaders");
            entity.Property(e => e.Responsebody)
                .HasColumnType("character varying")
                .HasColumnName("responsebody");
            entity.Property(e => e.Responseheaders)
                .HasColumnType("character varying")
                .HasColumnName("responseheaders");
            entity.Property(e => e.Responsestatus).HasColumnName("responsestatus");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
            entity.Property(e => e.Timespent)
                .HasColumnType("character varying")
                .HasColumnName("timespent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
