using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ARTGC.Models;

public partial class RcmsContext : DbContext
{
    public RcmsContext()
    {
    }

    public RcmsContext(DbContextOptions<RcmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAlarmhistory> TbAlarmhistories { get; set; }

    public virtual DbSet<TbBay> TbBays { get; set; }

    public virtual DbSet<TbBayhistory> TbBayhistories { get; set; }

    public virtual DbSet<TbBlock> TbBlocks { get; set; }

    public virtual DbSet<TbBlockhistory> TbBlockhistories { get; set; }

    public virtual DbSet<TbBlockmap> TbBlockmaps { get; set; }

    public virtual DbSet<TbBlockmaphistory> TbBlockmaphistories { get; set; }

    public virtual DbSet<TbCctvaction> TbCctvactions { get; set; }

    public virtual DbSet<TbCctvactioncomposition> TbCctvactioncompositions { get; set; }

    public virtual DbSet<TbCctvactioncompositionhistory> TbCctvactioncompositionhistories { get; set; }

    public virtual DbSet<TbCctvactionhistory> TbCctvactionhistories { get; set; }

    public virtual DbSet<TbCodegeneration> TbCodegenerations { get; set; }

    public virtual DbSet<TbCommblockinfo> TbCommblockinfos { get; set; }

    public virtual DbSet<TbCraneworkingbay> TbCraneworkingbays { get; set; }

    public virtual DbSet<TbCraneworkingbayhistory> TbCraneworkingbayhistories { get; set; }

    public virtual DbSet<TbCraneworkingblock> TbCraneworkingblocks { get; set; }

    public virtual DbSet<TbCraneworkingblockhistory> TbCraneworkingblockhistories { get; set; }

    public virtual DbSet<TbCustomexception> TbCustomexceptions { get; set; }

    public virtual DbSet<TbCustomquery> TbCustomqueries { get; set; }

    public virtual DbSet<TbDispatchevent> TbDispatchevents { get; set; }

    public virtual DbSet<TbDriverinfo> TbDriverinfos { get; set; }

    public virtual DbSet<TbEnum> TbEnums { get; set; }

    public virtual DbSet<TbEnumgroup> TbEnumgroups { get; set; }

    public virtual DbSet<TbEnumvalue> TbEnumvalues { get; set; }

    public virtual DbSet<TbEquipment> TbEquipments { get; set; }

    public virtual DbSet<TbEquipmenthistory> TbEquipmenthistories { get; set; }

    public virtual DbSet<TbEquipmentinfo> TbEquipmentinfos { get; set; }

    public virtual DbSet<TbEquipmentinfohistory> TbEquipmentinfohistories { get; set; }

    public virtual DbSet<TbEquipmenttagcomposition> TbEquipmenttagcompositions { get; set; }

    public virtual DbSet<TbEquipmenttagcompositionhistory> TbEquipmenttagcompositionhistories { get; set; }

    public virtual DbSet<TbGrid> TbGrids { get; set; }

    public virtual DbSet<TbGriddetail> TbGriddetails { get; set; }

    public virtual DbSet<TbId> TbIds { get; set; }

    public virtual DbSet<TbIdclass> TbIdclasses { get; set; }

    public virtual DbSet<TbIdclassserial> TbIdclassserials { get; set; }

    public virtual DbSet<TbInventory> TbInventories { get; set; }

    public virtual DbSet<TbJob> TbJobs { get; set; }

    public virtual DbSet<TbJobhistory> TbJobhistories { get; set; }

    public virtual DbSet<TbJoborder> TbJoborders { get; set; }

    public virtual DbSet<TbJoborderhistory> TbJoborderhistories { get; set; }

    public virtual DbSet<TbJoborderreject> TbJoborderrejects { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbMenufavorite> TbMenufavorites { get; set; }

    public virtual DbSet<TbMenugroup> TbMenugroups { get; set; }

    public virtual DbSet<TbMenuprivilege> TbMenuprivileges { get; set; }

    public virtual DbSet<TbMonitoringtagmap> TbMonitoringtagmaps { get; set; }

    public virtual DbSet<TbParameter> TbParameters { get; set; }

    public virtual DbSet<TbParameterBack250109> TbParameterBack250109s { get; set; }

    public virtual DbSet<TbParametercomposition> TbParametercompositions { get; set; }

    public virtual DbSet<TbParametercomposition0712> TbParametercomposition0712s { get; set; }

    public virtual DbSet<TbParametercompositionhistory> TbParametercompositionhistories { get; set; }

    public virtual DbSet<TbParameterhistory> TbParameterhistories { get; set; }

    public virtual DbSet<TbRow> TbRows { get; set; }

    public virtual DbSet<TbRowhistory> TbRowhistories { get; set; }

    public virtual DbSet<TbStationinfo> TbStationinfos { get; set; }

    public virtual DbSet<TbStepcomposition> TbStepcompositions { get; set; }

    public virtual DbSet<TbStepcompositionhistory> TbStepcompositionhistories { get; set; }

    public virtual DbSet<TbStepjob> TbStepjobs { get; set; }

    public virtual DbSet<TbStepjobhistory> TbStepjobhistories { get; set; }

    public virtual DbSet<TbSystemexception> TbSystemexceptions { get; set; }

    public virtual DbSet<TbTag> TbTags { get; set; }

    public virtual DbSet<TbTag0614> TbTag0614s { get; set; }

    public virtual DbSet<TbTag0704> TbTag0704s { get; set; }

    public virtual DbSet<TbTier> TbTiers { get; set; }

    public virtual DbSet<TbTierhistory> TbTierhistories { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserhistory> TbUserhistories { get; set; }

    public virtual DbSet<TbViewjobparameter> TbViewjobparameters { get; set; }

    public virtual DbSet<TbViewjobtracking> TbViewjobtrackings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.30.1.24;Database=RCMS;User Id=sa;Password=mbe123456!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAlarmhistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Alarmtimekey }).HasName("PK_ALARMHISTORY");

            entity.ToTable("TB_ALARMHISTORY", tb => tb.HasComment("RTGC에서 발생한 Alarm 이력 관리"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Crane ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Alarmtimekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Alarm Timekey")
                .HasColumnName("ALARMTIMEKEY");
            entity.Property(e => e.Alarmactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("알람발생시 처리 구분")
                .HasColumnName("ALARMACTIONTYPE");
            entity.Property(e => e.Alarmcode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ALARMCODE");
            entity.Property(e => e.Alarmcomment)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("알람 내용")
                .HasColumnName("ALARMCOMMENT");
            entity.Property(e => e.Alarmlevel)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("알람 수준 [ Info | Warning | Error | Fatal ] ")
                .HasColumnName("ALARMLEVEL");
            entity.Property(e => e.Alarmtim)
                .HasComment("알람일시")
                .HasColumnType("datetime")
                .HasColumnName("ALARMTIM");
            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("발생시점 Job Order ID")
                .HasColumnName("JOBORDERID");
        });

        modelBuilder.Entity<TbBay>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid }).HasName("PK_BAY");

            entity.ToTable("TB_BAY", tb => tb.HasComment("Bay 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Bayheight)
                .HasComment("Bay Height (mm)")
                .HasColumnName("BAYHEIGHT");
            entity.Property(e => e.Bayindex)
                .HasComment("Bay 순서")
                .HasColumnName("BAYINDEX");
            entity.Property(e => e.Bayname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Bay 명")
                .HasColumnName("BAYNAME");
            entity.Property(e => e.Baysize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay Size [ 20ft | 40ft | 45ft | ... ]")
                .HasColumnName("BAYSIZE");
            entity.Property(e => e.Baywidth)
                .HasComment("Bay Width (mm)")
                .HasColumnName("BAYWIDTH");
            entity.Property(e => e.Gantryposition)
                .HasComment("Gantry Position")
                .HasColumnName("GANTRYPOSITION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbBayhistory>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid, e.Timekey }).HasName("PK_BAYHISTORY");

            entity.ToTable("TB_BAYHISTORY", tb => tb.HasComment("Bay 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Bayheight)
                .HasComment("Bay Height (mm)")
                .HasColumnName("BAYHEIGHT");
            entity.Property(e => e.Bayindex)
                .HasComment("Bay 순서")
                .HasColumnName("BAYINDEX");
            entity.Property(e => e.Bayname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Bay 명")
                .HasColumnName("BAYNAME");
            entity.Property(e => e.Baysize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay Size [ 20ft | 40ft | 45ft | ... ]")
                .HasColumnName("BAYSIZE");
            entity.Property(e => e.Baywidth)
                .HasComment("Bay Width (mm)")
                .HasColumnName("BAYWIDTH");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Gantryposition)
                .HasComment("Gantry Position")
                .HasColumnName("GANTRYPOSITION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbBlock>(entity =>
        {
            entity.HasKey(e => e.Blockid).HasName("PK_BLOCK");

            entity.ToTable("TB_BLOCK", tb => tb.HasComment("Block 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Baseflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("기준 좌표 Block 여부 (BlockGroup 기준 한 개만 존재)")
                .HasColumnName("BASEFLAG");
            entity.Property(e => e.Baydirection)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay 순서 증가 방향")
                .HasColumnName("BAYDIRECTION");
            entity.Property(e => e.Blockname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Block 명")
                .HasColumnName("BLOCKNAME");
            entity.Property(e => e.Blocktype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block 유형")
                .HasColumnName("BLOCKTYPE");
            entity.Property(e => e.Gantryposition)
                .HasComment("Gantry Position")
                .HasColumnName("GANTRYPOSITION");
            entity.Property(e => e.Gpslatitude)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("GPS위도")
                .HasColumnName("GPSLATITUDE");
            entity.Property(e => e.Gpslongitude)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("GPS경도")
                .HasColumnName("GPSLONGITUDE");
            entity.Property(e => e.Itvdirection)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ITV의 Block 진입 방향")
                .HasColumnName("ITVDIRECTION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxgantryposition).HasColumnName("MAXGANTRYPOSITION");
            entity.Property(e => e.Maxhoistposition).HasColumnName("MAXHOISTPOSITION");
            entity.Property(e => e.Maxtrolleyposition).HasColumnName("MAXTROLLEYPOSITION");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Rowdirection)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row 순서 증가 방향")
                .HasColumnName("ROWDIRECTION");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbBlockhistory>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Timekey }).HasName("PK_BLOCKHISTORY");

            entity.ToTable("TB_BLOCKHISTORY", tb => tb.HasComment("Block 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Baseflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("기준 좌표 Block 여부 (BlockGroup 기준 한 개만 존재)")
                .HasColumnName("BASEFLAG");
            entity.Property(e => e.Baydirection)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay 순서 증가 방향")
                .HasColumnName("BAYDIRECTION");
            entity.Property(e => e.Blockname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Block 명")
                .HasColumnName("BLOCKNAME");
            entity.Property(e => e.Blocktype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block 유형")
                .HasColumnName("BLOCKTYPE");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Gantryposition)
                .HasComment("Gantry Position")
                .HasColumnName("GANTRYPOSITION");
            entity.Property(e => e.Gpslatitude)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("GPS위도")
                .HasColumnName("GPSLATITUDE");
            entity.Property(e => e.Gpslongitude)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("GPS경도")
                .HasColumnName("GPSLONGITUDE");
            entity.Property(e => e.Itvdirection)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ITV의 Block 진입 방향")
                .HasColumnName("ITVDIRECTION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxgantryposition).HasColumnName("MAXGANTRYPOSITION");
            entity.Property(e => e.Maxhoistposition).HasColumnName("MAXHOISTPOSITION");
            entity.Property(e => e.Maxtrolleyposition).HasColumnName("MAXTROLLEYPOSITION");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Rowdirection)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row 순서 증가 방향")
                .HasColumnName("ROWDIRECTION");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbBlockmap>(entity =>
        {
            entity.HasKey(e => new { e.Blockgroupid, e.Blockid }).HasName("PK_BLOCKMAP");

            entity.ToTable("TB_BLOCKMAP", tb => tb.HasComment("Block Group 정의"));

            entity.Property(e => e.Blockgroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block Group ID")
                .HasColumnName("BLOCKGROUPID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbBlockmaphistory>(entity =>
        {
            entity.HasKey(e => new { e.Blockgroupid, e.Blockid, e.Timekey }).HasName("PK_BLOCKMAPHISTORY");

            entity.ToTable("TB_BLOCKMAPHISTORY", tb => tb.HasComment("Block Group 정의 이력"));

            entity.Property(e => e.Blockgroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block Group ID")
                .HasColumnName("BLOCKGROUPID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCctvaction>(entity =>
        {
            entity.HasKey(e => e.Cctvactionid).HasName("PK_CCTVACTIONDEFINITION");

            entity.ToTable("TB_CCTVACTION");

            entity.Property(e => e.Cctvactionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CCTVACTIONID");
            entity.Property(e => e.Cctvactionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CCTVACTIONNAME");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCctvactioncomposition>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Cctvactionid, e.Orderindex }).HasName("PK_CCTVACTIONCOMPOSITION");

            entity.ToTable("TB_CCTVACTIONCOMPOSITION");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Cctvactionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CCTVACTIONID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Cctvid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CCTVID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCctvactioncompositionhistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Cctvactionid, e.Orderindex, e.Timekey }).HasName("PK_CCTVACTIONCOMPOSITIONHISTORY");

            entity.ToTable("TB_CCTVACTIONCOMPOSITIONHISTORY");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Cctvactionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CCTVACTIONID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Cctvid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CCTVID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCctvactionhistory>(entity =>
        {
            entity.HasKey(e => new { e.Cctvactionid, e.Timekey }).HasName("PK_CCTVACTIONDEFINITIONHISTORY");

            entity.ToTable("TB_CCTVACTIONHISTORY");

            entity.Property(e => e.Cctvactionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CCTVACTIONID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Cctvactionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CCTVACTIONNAME");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCodegeneration>(entity =>
        {
            entity.HasKey(e => new { e.Codegentype, e.Linenumber }).HasName("PK__CODEGENE__E104BD7EEF8A09B8");

            entity.ToTable("TB_CODEGENERATION");

            entity.Property(e => e.Codegentype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CODEGENTYPE");
            entity.Property(e => e.Linenumber).HasColumnName("LINENUMBER");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("DESCRIPTION");
        });

        modelBuilder.Entity<TbCommblockinfo>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Stationid, e.Blockno }).HasName("PK_COMMBLOCKINFO");

            entity.ToTable("TB_COMMBLOCKINFO", tb => tb.HasComment("스테이션에서 Read 할 통신영역 설정"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Equipment ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Stationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Station ID")
                .HasColumnName("STATIONID");
            entity.Property(e => e.Blockno)
                .HasComment("통신블럭 Index")
                .HasColumnName("BLOCKNO");
            entity.Property(e => e.Blocktype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Address Type or 구분자")
                .HasColumnName("BLOCKTYPE");
            entity.Property(e => e.Comminterval)
                .HasDefaultValue(10)
                .HasComment("Communication Interval(Cycle) (단위 100ms)")
                .HasColumnName("COMMINTERVAL");
            entity.Property(e => e.Readdatanumber)
                .HasComment("Read Data Number(읽을 데이터 개수)")
                .HasColumnName("READDATANUMBER");
            entity.Property(e => e.Startaddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Start Address(시작주소)")
                .HasColumnName("STARTADDRESS");
        });

        modelBuilder.Entity<TbCraneworkingbay>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Blockid, e.Bayid }).HasName("PK_CRANEWORKINGBAY");

            entity.ToTable("TB_CRANEWORKINGBAY");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BAYID");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCraneworkingbayhistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Blockid, e.Bayid, e.Timekey }).HasName("PK_CRANEWORKINGBAYHISTORY");

            entity.ToTable("TB_CRANEWORKINGBAYHISTORY");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BAYID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCraneworkingblock>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Blockid }).HasName("PK_CRANEWORKINGBLOCK");

            entity.ToTable("TB_CRANEWORKINGBLOCK", tb => tb.HasComment("크레인의 작업 Block 설정 (동일 Block Group 내 Block만 가능)"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("크레인ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCraneworkingblockhistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Blockid, e.Timekey }).HasName("PK_CRANEWORKINGBLOCKHISTORY");

            entity.ToTable("TB_CRANEWORKINGBLOCKHISTORY", tb => tb.HasComment("크레인의 작업 Block 설정이력 (동일 Block Group 내 Block만 가능)"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("크레인ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
        });

        modelBuilder.Entity<TbCustomexception>(entity =>
        {
            entity.HasKey(e => new { e.Exceptionid, e.Localeid }).HasName("CUSTOMEXCEPTION_pk");

            entity.ToTable("TB_CUSTOMEXCEPTION", tb => tb.HasComment("사용자메시지"));

            entity.Property(e => e.Exceptionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Exception ID")
                .HasColumnName("EXCEPTIONID");
            entity.Property(e => e.Localeid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Locale ID")
                .HasColumnName("LOCALEID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Exception 설명")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Exceptionmessage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Exception 표시")
                .HasColumnName("EXCEPTIONMESSAGE");
            entity.Property(e => e.Exceptiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Exception 구분 [ Info | Warning | Error | … ]")
                .HasColumnName("EXCEPTIONTYPE");
        });

        modelBuilder.Entity<TbCustomquery>(entity =>
        {
            entity.HasKey(e => new { e.Queryid, e.Queryversion }).HasName("PK_CUSTOMQUERY");

            entity.ToTable("TB_CUSTOMQUERY", tb => tb.HasComment("사용자 Query"));

            entity.Property(e => e.Queryid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("쿼리ID")
                .HasColumnName("QUERYID");
            entity.Property(e => e.Queryversion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("쿼리 Version")
                .HasColumnName("QUERYVERSION");
            entity.Property(e => e.Createtime)
                .HasComment("생성일시")
                .HasColumnType("datetime")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("생성자")
                .HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Formid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("사용할 Form ID")
                .HasColumnName("FORMID");
            entity.Property(e => e.Menuid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("사용된 메뉴 ID")
                .HasColumnName("MENUID");
            entity.Property(e => e.Programid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("사용될 프로그램ID")
                .HasColumnName("PROGRAMID");
            entity.Property(e => e.Querystring)
                .IsUnicode(false)
                .HasComment("수행할 쿼리")
                .HasColumnName("QUERYSTRING");
            entity.Property(e => e.Querytype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("쿼리구분")
                .HasColumnName("QUERYTYPE");
        });

        modelBuilder.Entity<TbDispatchevent>(entity =>
        {
            entity.HasKey(e => new { e.Servername, e.Eventname }).HasName("PK_DISPATCHEVENT");

            entity.ToTable("TB_DISPATCHEVENT", tb => tb.HasComment("Dispatch Event (Message) Definition"));

            entity.Property(e => e.Servername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("구동 Server Name")
                .HasColumnName("SERVERNAME");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name ( Message Name )")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Classname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Class Name")
                .HasColumnName("CLASSNAME");
            entity.Property(e => e.Logsaveflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("로그 저장 여부 [ Yes | No ]")
                .HasColumnName("LOGSAVEFLAG");
            entity.Property(e => e.Targetsite)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("수행하는 공장 (옵션)")
                .HasColumnName("TARGETSITE");
            entity.Property(e => e.Targetsubjectname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Send To Subject Name ( ByPass 하는 경우 실제 수행하는 Server )")
                .HasColumnName("TARGETSUBJECTNAME");
        });

        modelBuilder.Entity<TbDriverinfo>(entity =>
        {
            entity.HasKey(e => e.Driverid).HasName("PK_DRIVERINFO");

            entity.ToTable("TB_DRIVERINFO", tb => tb.HasComment("통신 프로토콜 리스트"));

            entity.Property(e => e.Driverid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Driver ID")
                .HasColumnName("DRIVERID");
            entity.Property(e => e.Drivername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Driver Name")
                .HasColumnName("DRIVERNAME");
            entity.Property(e => e.Protocol)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Protocol Name")
                .HasColumnName("PROTOCOL");
        });

        modelBuilder.Entity<TbEnum>(entity =>
        {
            entity.HasKey(e => e.Enumid).HasName("PK_ENUMDEFINITION");

            entity.ToTable("TB_ENUM", tb => tb.HasComment("Enumeration 정의"));

            entity.Property(e => e.Enumid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Enumeration ID (A type name to categonize)")
                .HasColumnName("ENUMID");
            entity.Property(e => e.Accesstype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("An access type.")
                .HasColumnName("ACCESSTYPE");
            entity.Property(e => e.Constantflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Constant Flag [ Yes | No ]")
                .HasColumnName("CONSTANTFLAG");
            entity.Property(e => e.English)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("영문")
                .HasColumnName("ENGLISH");
            entity.Property(e => e.Enumgroup)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Enumeration Group")
                .HasColumnName("ENUMGROUP");
            entity.Property(e => e.Enumname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Enumeration Name (A description)")
                .HasColumnName("ENUMNAME");
            entity.Property(e => e.Korean)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("한글")
                .HasColumnName("KOREAN");
            entity.Property(e => e.Native1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("자국어1")
                .HasColumnName("NATIVE1");
            entity.Property(e => e.Native2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("자국어2")
                .HasColumnName("NATIVE2");
        });

        modelBuilder.Entity<TbEnumgroup>(entity =>
        {
            entity.HasKey(e => e.Enumgroupid).HasName("PK_ENUMGROUPDEFINITION");

            entity.ToTable("TB_ENUMGROUP", tb => tb.HasComment("Enum Group 정의"));

            entity.Property(e => e.Enumgroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Enum Group ID")
                .HasColumnName("ENUMGROUPID");
            entity.Property(e => e.English)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("영문")
                .HasColumnName("ENGLISH");
            entity.Property(e => e.Enumgroupname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Enum Group 명")
                .HasColumnName("ENUMGROUPNAME");
            entity.Property(e => e.Korean)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("한글")
                .HasColumnName("KOREAN");
            entity.Property(e => e.Native1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("자국어1")
                .HasColumnName("NATIVE1");
            entity.Property(e => e.Native2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("자국어2")
                .HasColumnName("NATIVE2");
            entity.Property(e => e.Position)
                .HasComment("위치")
                .HasColumnName("POSITION");
        });

        modelBuilder.Entity<TbEnumvalue>(entity =>
        {
            entity.HasKey(e => new { e.Enumid, e.Enumvalue }).HasName("PK_ENUMVALUE");

            entity.ToTable("TB_ENUMVALUE", tb => tb.HasComment("Enumeration Value Definition (a value of a type)"));

            entity.Property(e => e.Enumid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Enumeration ID (A type name to categonize)")
                .HasColumnName("ENUMID");
            entity.Property(e => e.Enumvalue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Enumeration Value")
                .HasColumnName("ENUMVALUE");
            entity.Property(e => e.Defaultflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("default flag [ Yes | No ]")
                .HasColumnName("DEFAULTFLAG");
            entity.Property(e => e.English)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("영문")
                .HasColumnName("ENGLISH");
            entity.Property(e => e.Enumvaluename)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Enumeration Value Description (a name of Value)")
                .HasColumnName("ENUMVALUENAME");
            entity.Property(e => e.Korean)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("한글")
                .HasColumnName("KOREAN");
            entity.Property(e => e.Native1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("자국어1")
                .HasColumnName("NATIVE1");
            entity.Property(e => e.Native2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("자국어2")
                .HasColumnName("NATIVE2");
            entity.Property(e => e.Position)
                .HasComment("Position (Sort Index)")
                .HasColumnName("POSITION");
        });

        modelBuilder.Entity<TbEquipment>(entity =>
        {
            entity.HasKey(e => e.Equipmentid).HasName("PK_EQUIPMENTDEFINITION");

            entity.ToTable("TB_EQUIPMENT", tb => tb.HasComment("크레인, RCS 등 관리가 필요한 장비"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Autoflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Auto 여부")
                .HasColumnName("AUTOFLAG");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Clientid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Client ID")
                .HasColumnName("CLIENTID");
            entity.Property(e => e.Equipmentdetailtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비상세구분 [ RTGC | RMGC | RCS | CCTV |  … ]")
                .HasColumnName("EQUIPMENTDETAILTYPE");
            entity.Property(e => e.Equipmentname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("장비명")
                .HasColumnName("EQUIPMENTNAME");
            entity.Property(e => e.Equipmenttype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비구분 [ Crane | Station | Device | … ]")
                .HasColumnName("EQUIPMENTTYPE");
            entity.Property(e => e.Ifmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("인터페이스 모드 [ None | TAG | MSG | … ]")
                .HasColumnName("IFMODE");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Local IP Address")
                .HasColumnName("IPADDRESS");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxhoistposition)
                .HasComment("최대 HoistPosition")
                .HasColumnName("MAXHOISTPOSITION");
            entity.Property(e => e.Maxtrolleyposition)
                .HasComment("최대 TrolleyPosition")
                .HasColumnName("MAXTROLLEYPOSITION");
            entity.Property(e => e.Port)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Local Port")
                .HasColumnName("PORT");
            entity.Property(e => e.Spreaderdefaultrow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SPREADERDEFAULTROW");
            entity.Property(e => e.Spreaderoffset).HasColumnName("SPREADEROFFSET");
            entity.Property(e => e.Spreadersafeheight).HasColumnName("SPREADERSAFEHEIGHT");
            entity.Property(e => e.Superequipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("상위 장비ID")
                .HasColumnName("SUPEREQUIPMENTID");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbEquipmenthistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Timekey }).HasName("PK_EQUIPMENTDEFINITIONHISTORY");

            entity.ToTable("TB_EQUIPMENTHISTORY", tb => tb.HasComment("크레인, RCS 등 관리가 필요한 장비"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Autoflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Auto 여부")
                .HasColumnName("AUTOFLAG");
            entity.Property(e => e.Clientid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Client ID")
                .HasColumnName("CLIENTID");
            entity.Property(e => e.Equipmentdetailtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비상세구분 [ RTGC | RMGC | RCS | CCTV |  … ]")
                .HasColumnName("EQUIPMENTDETAILTYPE");
            entity.Property(e => e.Equipmentname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("장비명")
                .HasColumnName("EQUIPMENTNAME");
            entity.Property(e => e.Equipmenttype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비구분 [ Crane | Station | Device | … ]")
                .HasColumnName("EQUIPMENTTYPE");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Ifmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("인터페이스 모드 [ None | TAG | MSG | … ]")
                .HasColumnName("IFMODE");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Local IP Address")
                .HasColumnName("IPADDRESS");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxhoistposition)
                .HasComment("최대 HoistPosition")
                .HasColumnName("MAXHOISTPOSITION");
            entity.Property(e => e.Maxtrolleyposition)
                .HasComment("최대 TrolleyPosition")
                .HasColumnName("MAXTROLLEYPOSITION");
            entity.Property(e => e.Port)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Local Port")
                .HasColumnName("PORT");
            entity.Property(e => e.Spreaderdefaultrow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SPREADERDEFAULTROW");
            entity.Property(e => e.Spreadersafeheight).HasColumnName("SPREADERSAFEHEIGHT");
            entity.Property(e => e.Superequipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("상위 장비ID")
                .HasColumnName("SUPEREQUIPMENTID");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbEquipmentinfo>(entity =>
        {
            entity.HasKey(e => e.Equipmentid).HasName("PK_EQUIPMENTINFO");

            entity.ToTable("TB_EQUIPMENTINFO", tb => tb.HasComment("장비 (크레인/RCS) Current 상태 정보"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("크레인ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Arrivedvehicleflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Vehicle Arrived Flag")
                .HasColumnName("ARRIVEDVEHICLEFLAG");
            entity.Property(e => e.Arrivedvehicleid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Arrived Vehicle ID")
                .HasColumnName("ARRIVEDVEHICLEID");
            entity.Property(e => e.Automaticstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ARTG Status")
                .HasColumnName("AUTOMATICSTATUS");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Crane 장비 현재 Bay 위치")
                .HasColumnName("BAYID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Crane 장비 현재 Block 위치")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Commstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("통신상태 [ Online | Offline ]")
                .HasColumnName("COMMSTATUS");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재 진행중인 Step Job 의 CompositionID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Equipmentstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("상태 [ Idle |  Run | Hold ]")
                .HasColumnName("EQUIPMENTSTATUS");
            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재 진행중인 JOB Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Operationmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("동작모드 [ Auto | Manual ]")
                .HasColumnName("OPERATIONMODE");
            entity.Property(e => e.Pickupflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Container Pickup Flag")
                .HasColumnName("PICKUPFLAG");
        });

        modelBuilder.Entity<TbEquipmentinfohistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Timekey }).HasName("PK_EQUIPMENTINFOHISTORY");

            entity.ToTable("TB_EQUIPMENTINFOHISTORY", tb => tb.HasComment("장비 (크레인/RCS) Current 상태 정보 이력"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Arrivedvehicleflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Vehicle Arrived Flag")
                .HasColumnName("ARRIVEDVEHICLEFLAG");
            entity.Property(e => e.Arrivedvehicleid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Arrived Vehicle ID")
                .HasColumnName("ARRIVEDVEHICLEID");
            entity.Property(e => e.Automaticstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ARTG Status")
                .HasColumnName("AUTOMATICSTATUS");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Crane 장비 현재 Bay 위치")
                .HasColumnName("BAYID");
            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Crane 장비 현재 Block 위치")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Commstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("통신상태 [ Online | Offline ]")
                .HasColumnName("COMMSTATUS");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재 진행중인 Step Job 의 CompositionID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Equipmentstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("상태 [ Idle |  Run | Hold ]")
                .HasColumnName("EQUIPMENTSTATUS");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재 진행중인 JOB Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Operationmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("동작모드 [ Auto | Manual ] ")
                .HasColumnName("OPERATIONMODE");
            entity.Property(e => e.Pickupflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Container Pickup Flag")
                .HasColumnName("PICKUPFLAG");
        });

        modelBuilder.Entity<TbEquipmenttagcomposition>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Parameterid }).HasName("PK_EQUIPMENTTAGCOMPOSITION");

            entity.ToTable("TB_EQUIPMENTTAGCOMPOSITION", tb => tb.HasComment("장비별 Paremeter Tag 설정"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비 ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Parameterid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Tagid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Tag ID")
                .HasColumnName("TAGID");
        });

        modelBuilder.Entity<TbEquipmenttagcompositionhistory>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Parameterid, e.Timekey });

            entity.ToTable("TB_EQUIPMENTTAGCOMPOSITIONHISTORY", tb => tb.HasComment("장비별 Paremeter Tag 설정 이력"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비 ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Tagid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Tag ID")
                .HasColumnName("TAGID");
        });

        modelBuilder.Entity<TbGrid>(entity =>
        {
            entity.HasKey(e => e.Gridid).HasName("PK_GRIDDEFINITION");

            entity.ToTable("TB_GRID", tb => tb.HasComment("그리드정의"));

            entity.Property(e => e.Gridid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid ID")
                .HasColumnName("GRIDID");
            entity.Property(e => e.Checkbox)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Check Box 포함여부")
                .HasColumnName("CHECKBOX");
            entity.Property(e => e.Classname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid가 위치한 Class 명칭")
                .HasColumnName("CLASSNAME");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Gridname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid 명칭")
                .HasColumnName("GRIDNAME");
            entity.Property(e => e.Headercolumnsize)
                .HasComment("Header Column Size")
                .HasColumnName("HEADERCOLUMNSIZE");
            entity.Property(e => e.Headerrowsize)
                .HasComment("Header Row Size")
                .HasColumnName("HEADERROWSIZE");
            entity.Property(e => e.Position)
                .HasComment("Position (Sort Index)")
                .HasColumnName("POSITION");
            entity.Property(e => e.Rowstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("RowStatus 포함여부")
                .HasColumnName("ROWSTATUS");
        });

        modelBuilder.Entity<TbGriddetail>(entity =>
        {
            entity.HasKey(e => new { e.Gridid, e.Gridcolumnid }).HasName("PK_GRIDDETAIL");

            entity.ToTable("TB_GRIDDETAIL", tb => tb.HasComment("그리드상세정의"));

            entity.Property(e => e.Gridid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid ID")
                .HasColumnName("GRIDID");
            entity.Property(e => e.Gridcolumnid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid Column ID")
                .HasColumnName("GRIDCOLUMNID");
            entity.Property(e => e.Align)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("가로정렬 [ Left | Right | Center | ... ]")
                .HasColumnName("ALIGN");
            entity.Property(e => e.Celltype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Cell Type")
                .HasColumnName("CELLTYPE");
            entity.Property(e => e.Classname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid가 위치한 Class 명칭")
                .HasColumnName("CLASSNAME");
            entity.Property(e => e.Comboenumid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Cell Combo EnumID")
                .HasColumnName("COMBOENUMID");
            entity.Property(e => e.Combolist)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("CellType 이 ComboBox인 경우")
                .HasColumnName("COMBOLIST");
            entity.Property(e => e.Defaultvalue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("기본값")
                .HasColumnName("DEFAULTVALUE");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Editflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Edit 처리 Flag")
                .HasColumnName("EDITFLAG");
            entity.Property(e => e.Gridcolumnname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Grid Column 명칭")
                .HasColumnName("GRIDCOLUMNNAME");
            entity.Property(e => e.Gridcolumnsize)
                .HasComment("Columns Width Size")
                .HasColumnName("GRIDCOLUMNSIZE");
            entity.Property(e => e.Notnullflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Nullable 여부")
                .HasColumnName("NOTNULLFLAG");
            entity.Property(e => e.Position)
                .HasComment("Position (Sort Index)")
                .HasColumnName("POSITION");
            entity.Property(e => e.Primarykeyflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("PK 여부")
                .HasColumnName("PRIMARYKEYFLAG");
            entity.Property(e => e.Sortflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Sort 처리 Flag")
                .HasColumnName("SORTFLAG");
            entity.Property(e => e.Visibleflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Visible 처리 Flag")
                .HasColumnName("VISIBLEFLAG");
        });

        modelBuilder.Entity<TbId>(entity =>
        {
            entity.HasKey(e => new { e.Idclassid, e.Sequence }).HasName("PK_IDDEFINITION");

            entity.ToTable("TB_ID", tb => tb.HasComment("ID Create Rule Detail Definition"));

            entity.Property(e => e.Idclassid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Class ID")
                .HasColumnName("IDCLASSID");
            entity.Property(e => e.Sequence)
                .HasComment("Sequence")
                .HasColumnName("SEQUENCE");
            entity.Property(e => e.Createtime)
                .HasComment("생성일시")
                .HasColumnType("datetime")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("생성자")
                .HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("ID Definition Description")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Exceptionchars)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID 제외문자 (콤마로 구분)")
                .HasColumnName("EXCEPTIONCHARS");
            entity.Property(e => e.Format)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("String Format")
                .HasColumnName("FORMAT");
            entity.Property(e => e.Iddefcategory)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Definition Category")
                .HasColumnName("IDDEFCATEGORY");
            entity.Property(e => e.Iddefid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Definition ID")
                .HasColumnName("IDDEFID");
            entity.Property(e => e.Iddefname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Definition Name")
                .HasColumnName("IDDEFNAME");
            entity.Property(e => e.Iddeftype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Definition Type")
                .HasColumnName("IDDEFTYPE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Length)
                .HasComment("Length")
                .HasColumnName("LENGTH");
            entity.Property(e => e.Validstate)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Valid State")
                .HasColumnName("VALIDSTATE");
        });

        modelBuilder.Entity<TbIdclass>(entity =>
        {
            entity.HasKey(e => e.Idclassid).HasName("PK_IDCLASS");

            entity.ToTable("TB_IDCLASS", tb => tb.HasComment("ID Definition"));

            entity.Property(e => e.Idclassid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Class ID")
                .HasColumnName("IDCLASSID");
            entity.Property(e => e.Createtime)
                .HasComment("생성일시")
                .HasColumnType("datetime")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("생성자")
                .HasColumnName("CREATEUSERID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("ID Class Description ")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Idclassname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Class Name")
                .HasColumnName("IDCLASSNAME");
            entity.Property(e => e.Idlength)
                .HasComment("ID Length")
                .HasColumnName("IDLENGTH");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Validstate)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Valid State")
                .HasColumnName("VALIDSTATE");
        });

        modelBuilder.Entity<TbIdclassserial>(entity =>
        {
            entity.HasKey(e => new { e.Idclassid, e.Prefix }).HasName("PK_IDCLASSSERIAL");

            entity.ToTable("TB_IDCLASSSERIAL", tb => tb.HasComment("ID Class Sequence Management"));

            entity.Property(e => e.Idclassid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ID Class ID")
                .HasColumnName("IDCLASSID");
            entity.Property(e => e.Prefix)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Prefix Value")
                .HasColumnName("PREFIX");
            entity.Property(e => e.Createtime)
                .HasComment("생성일시")
                .HasColumnType("datetime")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Createuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("생성자")
                .HasColumnName("CREATEUSERID");
            entity.Property(e => e.Lastserialno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Last Serial No (ID Class Last Sequence)")
                .HasColumnName("LASTSERIALNO");
        });

        modelBuilder.Entity<TbInventory>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid, e.Rowid, e.Tierid }).HasName("PK_INVENTORY");

            entity.ToTable("TB_INVENTORY", tb => tb.HasComment("Current Container Inventory 정보"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Rowid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row ID")
                .HasColumnName("ROWID");
            entity.Property(e => e.Tierid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Tier ID")
                .HasColumnName("TIERID");
            entity.Property(e => e.Containercargotype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Cargo Type")
                .HasColumnName("CONTAINERCARGOTYPE");
            entity.Property(e => e.Containerclass)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Class")
                .HasColumnName("CONTAINERCLASS");
            entity.Property(e => e.Containerdoordir)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Door Direction [ 1:TowardLowerBay | 2:TowardHigherBay ]")
                .HasColumnName("CONTAINERDOORDIR");
            entity.Property(e => e.Containerfullmty)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Full Empty")
                .HasColumnName("CONTAINERFULLMTY");
            entity.Property(e => e.Containergrade)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Grade [ G1 | G2 | … ]")
                .HasColumnName("CONTAINERGRADE");
            entity.Property(e => e.Containerheight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Height [ 0:Undefined | 1:8'6'' | 2:9'6'' | 3:8' ]")
                .HasColumnName("CONTAINERHEIGHT");
            entity.Property(e => e.Containerid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ID")
                .HasColumnName("CONTAINERID");
            entity.Property(e => e.Containeriso)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ISO (Container Size & Type 규격)")
                .HasColumnName("CONTAINERISO");
            entity.Property(e => e.Containeropr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Operator Code")
                .HasColumnName("CONTAINEROPR");
            entity.Property(e => e.Containersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Size [ 20ft | 40ft | 45ft | 48ft ]")
                .HasColumnName("CONTAINERSIZE");
            entity.Property(e => e.Containersptype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Special Type")
                .HasColumnName("CONTAINERSPTYPE");
            entity.Property(e => e.Containertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 구분")
                .HasColumnName("CONTAINERTYPE");
            entity.Property(e => e.Containerweight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Weight (kg)")
                .HasColumnName("CONTAINERWEIGHT");
            entity.Property(e => e.Damageflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Damage Status [ Y | N ]")
                .HasColumnName("DAMAGEFLAG");
            entity.Property(e => e.Holdflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Hold Status [ Y | N ]")
                .HasColumnName("HOLDFLAG");
            entity.Property(e => e.Imdgcd)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("IMDG Class CD")
                .HasColumnName("IMDGCD");
            entity.Property(e => e.Imdgunno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("IMDG UN Number")
                .HasColumnName("IMDGUNNO");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Pod)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Port of Discharge")
                .HasColumnName("POD");
            entity.Property(e => e.Reeferplugstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reefer Plug Status")
                .HasColumnName("REEFERPLUGSTATUS");
            entity.Property(e => e.Reefertemp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reefer Temp.")
                .HasColumnName("REEFERTEMP");
            entity.Property(e => e.Reefertempunit)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reefer Temp. Unit")
                .HasColumnName("REEFERTEMPUNIT");
            entity.Property(e => e.Reeferworktemp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reefer Work Temp.")
                .HasColumnName("REEFERWORKTEMP");
            entity.Property(e => e.Sealflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Seal Status [ Y | N ]")
                .HasColumnName("SEALFLAG");
            entity.Property(e => e.Sendinoutflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interaface InOut Flag")
                .HasColumnName("SENDINOUTFLAG");
            entity.Property(e => e.Sendseqnumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Sequence Number")
                .HasColumnName("SENDSEQNUMBER");
            entity.Property(e => e.Sendtimekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Send Timekey (14자리)")
                .HasColumnName("SENDTIMEKEY");
            entity.Property(e => e.Stackindate)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Stack In Date")
                .HasColumnName("STACKINDATE");
        });

        modelBuilder.Entity<TbJob>(entity =>
        {
            entity.HasKey(e => e.Jobid).HasName("PK_JOBDEFINITION");

            entity.ToTable("TB_JOB", tb => tb.HasComment("TOS에서 지시 내려지는 Job 정의"));

            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Commonyn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("No")
                .HasColumnName("COMMONYN");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Jobname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Job 명")
                .HasColumnName("JOBNAME");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Usechassisupdate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Yes")
                .HasColumnName("USECHASSISUPDATE");
            entity.Property(e => e.Usercs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Yes")
                .HasColumnName("USERCS");
        });

        modelBuilder.Entity<TbJobhistory>(entity =>
        {
            entity.HasKey(e => new { e.Jobid, e.Timekey }).HasName("PK_JOBDEFINITIONHISTORY");

            entity.ToTable("TB_JOBHISTORY", tb => tb.HasComment("TOS에서 지시 내려지는 Job 정의"));

            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Commonyn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COMMONYN");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Jobname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Job 명")
                .HasColumnName("JOBNAME");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Usechassisupdate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USECHASSISUPDATE");
            entity.Property(e => e.Usercs)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USERCS");
        });

        modelBuilder.Entity<TbJoborder>(entity =>
        {
            entity.HasKey(e => e.Joborderid).HasName("PK_JOBORDER");

            entity.ToTable("TB_JOBORDER", tb => tb.HasComment("TOS로부터 수신한 Job Order의 현재 상태 및 진행 관리"));

            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재진행중인 Step Job의 Composition ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Containercargotype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Cargo Type")
                .HasColumnName("CONTAINERCARGOTYPE");
            entity.Property(e => e.Containerclass)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Class")
                .HasColumnName("CONTAINERCLASS");
            entity.Property(e => e.Containerdoordir)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Door Direction [ 1:TowardLowerBay | 2:TowardHigherBay ]")
                .HasColumnName("CONTAINERDOORDIR");
            entity.Property(e => e.Containerfullmty)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Full Empty")
                .HasColumnName("CONTAINERFULLMTY");
            entity.Property(e => e.Containerheight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Height [ 0:Undefined | 1:8'6'' | 2:9'6'' | 3:8' ]")
                .HasColumnName("CONTAINERHEIGHT");
            entity.Property(e => e.Containerid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ID")
                .HasColumnName("CONTAINERID");
            entity.Property(e => e.Containeriso)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ISO (Container Size & Type 규격)")
                .HasColumnName("CONTAINERISO");
            entity.Property(e => e.Containeropr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Operator Code")
                .HasColumnName("CONTAINEROPR");
            entity.Property(e => e.Containersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Size [ 20ft | 40ft | 45ft | 48ft ]")
                .HasColumnName("CONTAINERSIZE");
            entity.Property(e => e.Containertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 구분")
                .HasColumnName("CONTAINERTYPE");
            entity.Property(e => e.Containerweight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Weight (kg)")
                .HasColumnName("CONTAINERWEIGHT");
            entity.Property(e => e.Endtime)
                .HasComment("Job 종료일시")
                .HasColumnType("datetime")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("크레인 ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Frombay)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Bay")
                .HasColumnName("FROMBAY");
            entity.Property(e => e.Fromblock)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Block")
                .HasColumnName("FROMBLOCK");
            entity.Property(e => e.Fromclearlance)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMCLEARLANCE");
            entity.Property(e => e.Fromlandtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMLANDTYPE");
            entity.Property(e => e.Fromlocationtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMLOCATIONTYPE");
            entity.Property(e => e.Fromrow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Row")
                .HasColumnName("FROMROW");
            entity.Property(e => e.Fromtier)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Tier")
                .HasColumnName("FROMTIER");
            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Jobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job 상태 [ Wait | Start | Completed | Deleted | … ] ")
                .HasColumnName("JOBSTATUS");
            entity.Property(e => e.Jobtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job 구분 [ GI | GO | DS | LD | … ]")
                .HasColumnName("JOBTYPE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Recvtime)
                .HasComment("Job 수신일시")
                .HasColumnType("datetime")
                .HasColumnName("RECVTIME");
            entity.Property(e => e.Rejectcode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reject 사유코드")
                .HasColumnName("REJECTCODE");
            entity.Property(e => e.Rejectcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Reject Comment")
                .HasColumnName("REJECTCOMMENT");
            entity.Property(e => e.Remotestationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("원격운전 Station ID")
                .HasColumnName("REMOTESTATIONID");
            entity.Property(e => e.Sendjobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Job Status")
                .HasColumnName("SENDJOBSTATUS");
            entity.Property(e => e.Sendtimekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Send Timekey (14자리)")
                .HasColumnName("SENDTIMEKEY");
            entity.Property(e => e.Sendtopic)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Topic")
                .HasColumnName("SENDTOPIC");
            entity.Property(e => e.Spreadersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Spreader Size [ -1:Undefined | 0:NoSpreader | 1:20ft | 2:40ft | 3:45ft | 19:Moving ]")
                .HasColumnName("SPREADERSIZE");
            entity.Property(e => e.Starttime)
                .HasComment("Job 시작일시")
                .HasColumnType("datetime")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Tobay)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Bay")
                .HasColumnName("TOBAY");
            entity.Property(e => e.Toblock)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Block")
                .HasColumnName("TOBLOCK");
            entity.Property(e => e.Toclearlance)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOCLEARLANCE");
            entity.Property(e => e.Tolandtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOLANDTYPE");
            entity.Property(e => e.Tolocationtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOLOCATIONTYPE");
            entity.Property(e => e.Torow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Row")
                .HasColumnName("TOROW");
            entity.Property(e => e.Totier)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Tier")
                .HasColumnName("TOTIER");
            entity.Property(e => e.Vehicleid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 ID")
                .HasColumnName("VEHICLEID");
            entity.Property(e => e.Vehicleposition)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량위치")
                .HasColumnName("VEHICLEPOSITION");
            entity.Property(e => e.Vehicletype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 Type")
                .HasColumnName("VEHICLETYPE");
        });

        modelBuilder.Entity<TbJoborderhistory>(entity =>
        {
            entity.HasKey(e => new { e.Joborderid, e.Timekey }).HasName("PK_JOBORDERHISTORY");

            entity.ToTable("TB_JOBORDERHISTORY", tb => tb.HasComment("TOS로부터 수신한 Job Order의 현재 상태 및 진행 이력"));

            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재진행중인 Step Job의 Composition ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Containercargotype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Cargo Type")
                .HasColumnName("CONTAINERCARGOTYPE");
            entity.Property(e => e.Containerclass)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Class")
                .HasColumnName("CONTAINERCLASS");
            entity.Property(e => e.Containerdoordir)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Door Direction [ 1:TowardLowerBay | 2:TowardHigherBay ]")
                .HasColumnName("CONTAINERDOORDIR");
            entity.Property(e => e.Containerfullmty)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Full Empty")
                .HasColumnName("CONTAINERFULLMTY");
            entity.Property(e => e.Containerheight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Height [ 0:Undefined | 1:8'6'' | 2:9'6'' | 3:8' ]")
                .HasColumnName("CONTAINERHEIGHT");
            entity.Property(e => e.Containerid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ID")
                .HasColumnName("CONTAINERID");
            entity.Property(e => e.Containeriso)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ISO (Container Size & Type 규격)")
                .HasColumnName("CONTAINERISO");
            entity.Property(e => e.Containeropr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Operator Code")
                .HasColumnName("CONTAINEROPR");
            entity.Property(e => e.Containersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Size [ 20ft | 40ft | 45ft | 48ft ]")
                .HasColumnName("CONTAINERSIZE");
            entity.Property(e => e.Containertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 구분")
                .HasColumnName("CONTAINERTYPE");
            entity.Property(e => e.Containerweight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Weight (kg)")
                .HasColumnName("CONTAINERWEIGHT");
            entity.Property(e => e.Endtime)
                .HasComment("Job 종료일시")
                .HasColumnType("datetime")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("크레인 ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Frombay)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Bay")
                .HasColumnName("FROMBAY");
            entity.Property(e => e.Fromblock)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Block")
                .HasColumnName("FROMBLOCK");
            entity.Property(e => e.Fromclearlance)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMCLEARLANCE");
            entity.Property(e => e.Fromlandtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMLANDTYPE");
            entity.Property(e => e.Fromlocationtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMLOCATIONTYPE");
            entity.Property(e => e.Fromrow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Row")
                .HasColumnName("FROMROW");
            entity.Property(e => e.Fromtier)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Tier")
                .HasColumnName("FROMTIER");
            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Jobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job 상태 [ Wait | Start | Completed | Deleted | … ] ")
                .HasColumnName("JOBSTATUS");
            entity.Property(e => e.Jobtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job 구분 [ GI | GO | DS | LD | … ]")
                .HasColumnName("JOBTYPE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Recvtime)
                .HasComment("Job 수신일시")
                .HasColumnType("datetime")
                .HasColumnName("RECVTIME");
            entity.Property(e => e.Rejectcode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reject 사유코드")
                .HasColumnName("REJECTCODE");
            entity.Property(e => e.Rejectcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Reject Comment")
                .HasColumnName("REJECTCOMMENT");
            entity.Property(e => e.Remotestationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("원격운전 Station ID")
                .HasColumnName("REMOTESTATIONID");
            entity.Property(e => e.Sendjobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Job Status")
                .HasColumnName("SENDJOBSTATUS");
            entity.Property(e => e.Sendtimekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Send Timekey (14자리)")
                .HasColumnName("SENDTIMEKEY");
            entity.Property(e => e.Sendtopic)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Topic")
                .HasColumnName("SENDTOPIC");
            entity.Property(e => e.Spreadersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Spreader Size [ -1:Undefined | 0:NoSpreader | 1:20ft | 2:40ft | 3:45ft | 19:Moving ]")
                .HasColumnName("SPREADERSIZE");
            entity.Property(e => e.Starttime)
                .HasComment("Job 시작일시")
                .HasColumnType("datetime")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Tobay)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Bay")
                .HasColumnName("TOBAY");
            entity.Property(e => e.Toblock)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Block")
                .HasColumnName("TOBLOCK");
            entity.Property(e => e.Toclearlance)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOCLEARLANCE");
            entity.Property(e => e.Tolandtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOLANDTYPE");
            entity.Property(e => e.Tolocationtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOLOCATIONTYPE");
            entity.Property(e => e.Torow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Row")
                .HasColumnName("TOROW");
            entity.Property(e => e.Totier)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Tier")
                .HasColumnName("TOTIER");
            entity.Property(e => e.Vehicleid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 ID")
                .HasColumnName("VEHICLEID");
            entity.Property(e => e.Vehicleposition)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량위치")
                .HasColumnName("VEHICLEPOSITION");
            entity.Property(e => e.Vehicletype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 Type")
                .HasColumnName("VEHICLETYPE");
        });

        modelBuilder.Entity<TbJoborderreject>(entity =>
        {
            entity.HasKey(e => new { e.Timekey, e.Joborderid }).HasName("PK_JOBORDERREJECT");

            entity.ToTable("TB_JOBORDERREJECT", tb => tb.HasComment("Reject된 Job Order의 정보 관리"));

            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Timekey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("현재진행중인 Step Job의 Composition ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Containercargotype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Cargo Type")
                .HasColumnName("CONTAINERCARGOTYPE");
            entity.Property(e => e.Containerclass)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Class")
                .HasColumnName("CONTAINERCLASS");
            entity.Property(e => e.Containerdoordir)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Door Direction [ 1:TowardLowerBay | 2:TowardHigherBay ]")
                .HasColumnName("CONTAINERDOORDIR");
            entity.Property(e => e.Containerfullmty)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Full Empty")
                .HasColumnName("CONTAINERFULLMTY");
            entity.Property(e => e.Containerheight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Height [ 0:Undefined | 1:8'6'' | 2:9'6'' | 3:8' ]")
                .HasColumnName("CONTAINERHEIGHT");
            entity.Property(e => e.Containerid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ID")
                .HasColumnName("CONTAINERID");
            entity.Property(e => e.Containeriso)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 ISO (Container Size & Type 규격)")
                .HasColumnName("CONTAINERISO");
            entity.Property(e => e.Containeropr)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Operator Code")
                .HasColumnName("CONTAINEROPR");
            entity.Property(e => e.Containersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Size [ 20ft | 40ft | 45ft | 48ft ]")
                .HasColumnName("CONTAINERSIZE");
            entity.Property(e => e.Containertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 구분")
                .HasColumnName("CONTAINERTYPE");
            entity.Property(e => e.Containerweight)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("컨테이너 Weight (kg)")
                .HasColumnName("CONTAINERWEIGHT");
            entity.Property(e => e.Endtime)
                .HasComment("Job 종료일시")
                .HasColumnType("datetime")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("크레인 ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Frombay)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Bay")
                .HasColumnName("FROMBAY");
            entity.Property(e => e.Fromblock)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Block")
                .HasColumnName("FROMBLOCK");
            entity.Property(e => e.Fromrow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Row")
                .HasColumnName("FROMROW");
            entity.Property(e => e.Fromtier)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("From Location Tier")
                .HasColumnName("FROMTIER");
            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Jobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job 상태 [ Wait | Start | Completed | Deleted | … ] ")
                .HasColumnName("JOBSTATUS");
            entity.Property(e => e.Jobtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job 구분 [ GI | GO | DS | LD | … ]")
                .HasColumnName("JOBTYPE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Recvtime)
                .HasComment("Job 수신일시")
                .HasColumnType("datetime")
                .HasColumnName("RECVTIME");
            entity.Property(e => e.Rejectcode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Reject 사유코드")
                .HasColumnName("REJECTCODE");
            entity.Property(e => e.Rejectcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Reject Comment")
                .HasColumnName("REJECTCOMMENT");
            entity.Property(e => e.Remotestationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("원격운전 Station ID")
                .HasColumnName("REMOTESTATIONID");
            entity.Property(e => e.Sendjobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Job Status")
                .HasColumnName("SENDJOBSTATUS");
            entity.Property(e => e.Sendtimekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Send Timekey (14자리)")
                .HasColumnName("SENDTIMEKEY");
            entity.Property(e => e.Sendtopic)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Interface Topic")
                .HasColumnName("SENDTOPIC");
            entity.Property(e => e.Spreadersize)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Spreader Size [ -1:Undefined | 0:NoSpreader | 1:20ft | 2:40ft | 3:45ft | 19:Moving ]")
                .HasColumnName("SPREADERSIZE");
            entity.Property(e => e.Starttime)
                .HasComment("Job 시작일시")
                .HasColumnType("datetime")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Tobay)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Bay")
                .HasColumnName("TOBAY");
            entity.Property(e => e.Toblock)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Block")
                .HasColumnName("TOBLOCK");
            entity.Property(e => e.Torow)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Row")
                .HasColumnName("TOROW");
            entity.Property(e => e.Totier)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("To Location Tier")
                .HasColumnName("TOTIER");
            entity.Property(e => e.Vehicleid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 ID")
                .HasColumnName("VEHICLEID");
            entity.Property(e => e.Vehicleposition)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량위치")
                .HasColumnName("VEHICLEPOSITION");
            entity.Property(e => e.Vehicletype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 Type")
                .HasColumnName("VEHICLETYPE");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.Menuid).HasName("PK_MENUDEFINITION");

            entity.ToTable("TB_MENU", tb => tb.HasComment("Menu Definition"));

            entity.Property(e => e.Menuid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Menu ID")
                .HasColumnName("MENUID");
            entity.Property(e => e.Activestate)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("활성상태 [ Active | Inactive ]")
                .HasColumnName("ACTIVESTATE");
            entity.Property(e => e.Classname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Menu Class Name")
                .HasColumnName("CLASSNAME");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Menugroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Menu Group ID")
                .HasColumnName("MENUGROUPID");
            entity.Property(e => e.Menuname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Menu Name (Description)")
                .HasColumnName("MENUNAME");
            entity.Property(e => e.Menutype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Menu Type [ Line | Menu | … ]")
                .HasColumnName("MENUTYPE");
            entity.Property(e => e.Position)
                .HasComment("Position (Sort Index)")
                .HasColumnName("POSITION");
            entity.Property(e => e.Sourcetype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Source Type (User Define)")
                .HasColumnName("SOURCETYPE");
        });

        modelBuilder.Entity<TbMenufavorite>(entity =>
        {
            entity.HasKey(e => new { e.Userid, e.Menuid }).HasName("PK_MENUFAVORITES");

            entity.ToTable("TB_MENUFAVORITES", tb => tb.HasComment("즐겨찾기메뉴관리"));

            entity.Property(e => e.Userid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("유저ID")
                .HasColumnName("USERID");
            entity.Property(e => e.Menuid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Menu ID")
                .HasColumnName("MENUID");
        });

        modelBuilder.Entity<TbMenugroup>(entity =>
        {
            entity.HasKey(e => e.Menugroupid).HasName("PK_MENUGROUPDEFINITION");

            entity.ToTable("TB_MENUGROUP", tb => tb.HasComment("MENU Group Definition"));

            entity.Property(e => e.Menugroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Menu Group ID")
                .HasColumnName("MENUGROUPID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Menugroupname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Menu Group Name (Description)")
                .HasColumnName("MENUGROUPNAME");
            entity.Property(e => e.Menugrouptype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Menu Group Type (User Define)")
                .HasColumnName("MENUGROUPTYPE");
            entity.Property(e => e.Position)
                .HasComment("Position (Sort Index)")
                .HasColumnName("POSITION");
        });

        modelBuilder.Entity<TbMenuprivilege>(entity =>
        {
            entity.HasKey(e => new { e.Userid, e.Menuid }).HasName("PK_MENUPRIVILEGE");

            entity.ToTable("TB_MENUPRIVILEGE", tb => tb.HasComment("메뉴 권한 관리"));

            entity.Property(e => e.Userid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("유저ID")
                .HasColumnName("USERID");
            entity.Property(e => e.Menuid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Menu ID")
                .HasColumnName("MENUID");
            entity.Property(e => e.Clienttype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("클라이언트구분")
                .HasColumnName("CLIENTTYPE");
            entity.Property(e => e.Saveflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("저장여부")
                .HasColumnName("SAVEFLAG");
        });

        modelBuilder.Entity<TbMonitoringtagmap>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Formid, e.Controlid }).HasName("PK_MONITORINGTAGMAP");

            entity.ToTable("TB_MONITORINGTAGMAP", tb => tb.HasComment("Monitoring Tag Mapping"));

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Equipment ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Formid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Form ID")
                .HasColumnName("FORMID");
            entity.Property(e => e.Controlid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Control ID")
                .HasColumnName("CONTROLID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Control 명칭")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Tagid)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("TAGID")
                .HasColumnName("TAGID");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbParameter>(entity =>
        {
            entity.HasKey(e => e.Parameterid).HasName("PK_PARAMETERDEFINITION");

            entity.ToTable("TB_PARAMETER", tb => tb.HasComment("Step Job을 수행할때 필요한 Parameter 정의"));

            entity.Property(e => e.Parameterid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Parametername)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Parameter 명")
                .HasColumnName("PARAMETERNAME");
            entity.Property(e => e.Parametertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERTYPE");
        });

        modelBuilder.Entity<TbParameterBack250109>(entity =>
        {
            entity.HasKey(e => e.Parameterid).HasName("PK_PARAMETERDEFINITIONEEE");

            entity.ToTable("TB_PARAMETER_BACK250109");

            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Parametername)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PARAMETERNAME");
            entity.Property(e => e.Parametertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERTYPE");
        });

        modelBuilder.Entity<TbParametercomposition>(entity =>
        {
            entity.HasKey(e => new { e.Compositionid, e.Actiontype, e.Parameterid }).HasName("PK_PARAMETERCOMPOSITION");

            entity.ToTable("TB_PARAMETERCOMPOSITION", tb => tb.HasComment("Job, StepJob, Parameter 구성을 관리"));

            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("StepComposition 고유 ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Actiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("작업구분 [ Start | End | Execute ]")
                .HasColumnName("ACTIONTYPE");
            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Createdatamethod)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 생성방법 [ FixedValue | InReceived | MakeFunction ]")
                .HasColumnName("CREATEDATAMETHOD");
            entity.Property(e => e.Dataactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 작업구분 [ Set | Get ] ")
                .HasColumnName("DATAACTIONTYPE");
            entity.Property(e => e.Datafailtarget)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATAFAILTARGET");
            entity.Property(e => e.Dataprocesstype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 처리구분 [ Event | Data ]")
                .HasColumnName("DATAPROCESSTYPE");
            entity.Property(e => e.Datatarget)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data를 Set 또는 Get 하기 위한 Device Target")
                .HasColumnName("DATATARGET");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventreplyparametername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTREPLYPARAMETERNAME");
            entity.Property(e => e.Eventreportfunctionname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTREPORTFUNCTIONNAME");
            entity.Property(e => e.Fixedendvalue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FIXEDENDVALUE");
            entity.Property(e => e.Fixedstartvalue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("CreateDataMethod가 FixedValue인 경우 고정값")
                .HasColumnName("FIXEDSTARTVALUE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Makefunctionname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("CreateDataMethod가 MakeFunction인 경우 함수명")
                .HasColumnName("MAKEFUNCTIONNAME");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Parameterlevel)
                .HasComment("Parameter Level")
                .HasColumnName("PARAMETERLEVEL");
            entity.Property(e => e.Receiveid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("CreateDataMethod가 InReceived인 경우 Receive ID 값이 없으면 Parameter ID 로 처리함.")
                .HasColumnName("RECEIVEID");
        });

        modelBuilder.Entity<TbParametercomposition0712>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_PARAMETERCOMPOSITION_0712");

            entity.Property(e => e.Actiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ACTIONTYPE");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Createdatamethod)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CREATEDATAMETHOD");
            entity.Property(e => e.Dataactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATAACTIONTYPE");
            entity.Property(e => e.Dataprocesstype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATAPROCESSTYPE");
            entity.Property(e => e.Datatarget)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATATARGET");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Fixedvalue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FIXEDVALUE");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Makefunctionname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MAKEFUNCTIONNAME");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Parameterlevel).HasColumnName("PARAMETERLEVEL");
            entity.Property(e => e.Receiveid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("RECEIVEID");
        });

        modelBuilder.Entity<TbParametercompositionhistory>(entity =>
        {
            entity.HasKey(e => new { e.Compositionid, e.Actiontype, e.Parameterid, e.Timekey }).HasName("PK_PARAMETERCOMPOSITIONHISTORY");

            entity.ToTable("TB_PARAMETERCOMPOSITIONHISTORY", tb => tb.HasComment("Job, StepJob, Parameter 구성을 관리"));

            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("StepComposition 고유 ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Actiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("작업구분 [ Start | End | Execute ]")
                .HasColumnName("ACTIONTYPE");
            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Createdatamethod)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 생성방법 [ FixedValue | InReceived | MakeFunction ]")
                .HasColumnName("CREATEDATAMETHOD");
            entity.Property(e => e.Dataactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 작업구분 [ Set | Get ] ")
                .HasColumnName("DATAACTIONTYPE");
            entity.Property(e => e.Dataprocesstype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 처리구분 [ Event | Data ]")
                .HasColumnName("DATAPROCESSTYPE");
            entity.Property(e => e.Datatarget)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data를 Set 또는 Get 하기 위한 Device Target")
                .HasColumnName("DATATARGET");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Fixedvalue)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("CreateDataMethod가 FixedValue인 경우 고정값")
                .HasColumnName("FIXEDVALUE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Makefunctionname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("CreateDataMethod가 MakeFunction인 경우 함수명")
                .HasColumnName("MAKEFUNCTIONNAME");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Parameterlevel)
                .HasComment("Parameter Level")
                .HasColumnName("PARAMETERLEVEL");
            entity.Property(e => e.Receiveid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("CreateDataMethod가 InReceived인 경우 Receive ID 값이 없으면 Parameter ID 로 처리함.")
                .HasColumnName("RECEIVEID");
        });

        modelBuilder.Entity<TbParameterhistory>(entity =>
        {
            entity.HasKey(e => new { e.Parameterid, e.Timekey }).HasName("PK_PARAMETERDEFINITIONHISTORY");

            entity.ToTable("TB_PARAMETERHISTORY", tb => tb.HasComment("Step Job을 수행할때 필요한 Parameter 정의"));

            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Parametername)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Parameter 명")
                .HasColumnName("PARAMETERNAME");
            entity.Property(e => e.Parametertype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERTYPE");
        });

        modelBuilder.Entity<TbRow>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid, e.Rowid }).HasName("PK_ROW");

            entity.ToTable("TB_ROW", tb => tb.HasComment("Row 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Rowid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row ID")
                .HasColumnName("ROWID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Rowindex)
                .HasComment("Row 순서")
                .HasColumnName("ROWINDEX");
            entity.Property(e => e.Rowname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Row 명")
                .HasColumnName("ROWNAME");
            entity.Property(e => e.Trolleyposition)
                .HasComment("Trolley Position")
                .HasColumnName("TROLLEYPOSITION");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Workinglaneflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 정차 여부")
                .HasColumnName("WORKINGLANEFLAG");
        });

        modelBuilder.Entity<TbRowhistory>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid, e.Rowid, e.Timekey }).HasName("PK_ROWHISTORY");

            entity.ToTable("TB_ROWHISTORY", tb => tb.HasComment("Row 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Rowid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row ID")
                .HasColumnName("ROWID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Rowindex)
                .HasComment("Row 순서")
                .HasColumnName("ROWINDEX");
            entity.Property(e => e.Rowname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Row 명")
                .HasColumnName("ROWNAME");
            entity.Property(e => e.Trolleyposition)
                .HasComment("Trolley Position")
                .HasColumnName("TROLLEYPOSITION");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Workinglaneflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("차량 정차 여부")
                .HasColumnName("WORKINGLANEFLAG");
        });

        modelBuilder.Entity<TbStationinfo>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Stationid }).HasName("PK_STATIONINFO");

            entity.ToTable("TB_STATIONINFO");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("장비ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Stationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Station ID")
                .HasColumnName("STATIONID");
            entity.Property(e => e.Comminterval)
                .HasDefaultValue(10)
                .HasComment("Communication Interval(Cycle) ( 단위 100ms)")
                .HasColumnName("COMMINTERVAL");
            entity.Property(e => e.Commstatus).HasColumnName("COMMSTATUS");
            entity.Property(e => e.Cpuslotno)
                .HasComment("CPU SLOT Number only in Siemens PLC")
                .HasColumnName("CPUSLOTNO");
            entity.Property(e => e.Cputype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPUTYPE");
            entity.Property(e => e.Localip)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("EIS IP")
                .HasColumnName("LOCALIP");
            entity.Property(e => e.Localport)
                .HasComment("EIS Port Number")
                .HasColumnName("LOCALPORT");
            entity.Property(e => e.Opcclsid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("OPC Server Class ID(CLSID)")
                .HasColumnName("OPCCLSID");
            entity.Property(e => e.Opclocalremote)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("OPC Server PC Name or PC IP")
                .HasColumnName("OPCLOCALREMOTE");
            entity.Property(e => e.Opcserver)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("OPC SERVER Name")
                .HasColumnName("OPCSERVER");
            entity.Property(e => e.Protocolname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("프로토콜 구분 [ MODBUS TCP |LSIS ENET |MSG|  … ]")
                .HasColumnName("PROTOCOLNAME");
            entity.Property(e => e.Rackno)
                .HasComment("Rack Number only in Siemens PLC")
                .HasColumnName("RACKNO");
            entity.Property(e => e.Remoteip)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Remote IP")
                .HasColumnName("REMOTEIP");
            entity.Property(e => e.Remoteport)
                .HasComment("Remote Port Number")
                .HasColumnName("REMOTEPORT");
            entity.Property(e => e.Stationno)
                .HasComment("Station Number in Melsec PLC")
                .HasColumnName("STATIONNO");
            entity.Property(e => e.Timeout)
                .HasDefaultValue(3)
                .HasComment("Communication Timeout ( 단위 100ms)")
                .HasColumnName("TIMEOUT");
        });

        modelBuilder.Entity<TbStepcomposition>(entity =>
        {
            entity.HasKey(e => new { e.Jobid, e.Stepjobid, e.Stepsequence }).HasName("PK_STEPCOMPOSITION");

            entity.ToTable("TB_STEPCOMPOSITION", tb => tb.HasComment("Job, StepJob 구성 관리"));

            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Stepjobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job ID")
                .HasColumnName("STEPJOBID");
            entity.Property(e => e.Stepsequence)
                .HasComment("순서")
                .HasColumnName("STEPSEQUENCE");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("StepComposition 고유 ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Createdatatype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("데이터 생성 구분 [ RealTime | ReceivedTime ]")
                .HasColumnName("CREATEDATATYPE");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Endiffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ENDIFFUNCTIONNAME");
            entity.Property(e => e.Ifactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("인터페이스 구분 [ None | Start | End | Both | Execute ] ")
                .HasColumnName("IFACTIONTYPE");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Operationmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("동작모드 [ Auto | Manual ] ")
                .HasColumnName("OPERATIONMODE");
            entity.Property(e => e.Preiffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PREIFFUNCTIONNAME");
            entity.Property(e => e.Startiffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("인터페이스 실행 함수")
                .HasColumnName("STARTIFFUNCTIONNAME");
        });

        modelBuilder.Entity<TbStepcompositionhistory>(entity =>
        {
            entity.HasKey(e => new { e.Jobid, e.Stepjobid, e.Stepsequence, e.Timekey }).HasName("PK_STEPCOMPOSITIONHISTORY");

            entity.ToTable("TB_STEPCOMPOSITIONHISTORY", tb => tb.HasComment("Job, StepJob 구성 관리"));

            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Stepjobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job ID")
                .HasColumnName("STEPJOBID");
            entity.Property(e => e.Stepsequence)
                .HasComment("순서")
                .HasColumnName("STEPSEQUENCE");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("StepComposition 고유 ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Createdatatype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("데이터 생성 구분 [ RealTime | ReceivedTime ]")
                .HasColumnName("CREATEDATATYPE");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Ifactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("인터페이스 구분 [ None | Start | End | Both | Execute ] ")
                .HasColumnName("IFACTIONTYPE");
            entity.Property(e => e.Iffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("인터페이스 실행 함수")
                .HasColumnName("IFFUNCTIONNAME");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Operationmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("동작모드 [ Auto | Manual ] ")
                .HasColumnName("OPERATIONMODE");
        });

        modelBuilder.Entity<TbStepjob>(entity =>
        {
            entity.HasKey(e => e.Stepjobid).HasName("PK_STEPJOBDEFINITION");

            entity.ToTable("TB_STEPJOB", tb => tb.HasComment("Job을 수행하기 위한 Step Job 정의"));

            entity.Property(e => e.Stepjobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job ID")
                .HasColumnName("STEPJOBID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Shortname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SHORTNAME");
            entity.Property(e => e.Stepjobname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Step Job 명")
                .HasColumnName("STEPJOBNAME");
            entity.Property(e => e.Stepjobtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job 구분 [ StartEnd | Execute ]")
                .HasColumnName("STEPJOBTYPE");
        });

        modelBuilder.Entity<TbStepjobhistory>(entity =>
        {
            entity.HasKey(e => new { e.Stepjobid, e.Timekey }).HasName("PK_STEPJOBDEFINITIONHISTORY");

            entity.ToTable("TB_STEPJOBHISTORY", tb => tb.HasComment("Job을 수행하기 위한 Step Job 정의"));

            entity.Property(e => e.Stepjobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job ID")
                .HasColumnName("STEPJOBID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Orderindex).HasColumnName("ORDERINDEX");
            entity.Property(e => e.Shortname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SHORTNAME");
            entity.Property(e => e.Stepjobname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Step Job 명")
                .HasColumnName("STEPJOBNAME");
            entity.Property(e => e.Stepjobtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job 구분 [ StartEnd | Execute ]")
                .HasColumnName("STEPJOBTYPE");
        });

        modelBuilder.Entity<TbSystemexception>(entity =>
        {
            entity.HasKey(e => new { e.Exceptionid, e.Localeid }).HasName("SYSTEMEXCEPTION_pk");

            entity.ToTable("TB_SYSTEMEXCEPTION", tb => tb.HasComment("System Error Definition"));

            entity.Property(e => e.Exceptionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Exception ID")
                .HasColumnName("EXCEPTIONID");
            entity.Property(e => e.Localeid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Locale ID")
                .HasColumnName("LOCALEID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Exception 설명")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Exceptionmessage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Exception 표시")
                .HasColumnName("EXCEPTIONMESSAGE");
        });

        modelBuilder.Entity<TbTag>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Tagid });

            entity.ToTable("TB_TAG");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Tagid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGID");
            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Alarmflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ALARMFLAG");
            entity.Property(e => e.Cosflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COSFLAG");
            entity.Property(e => e.Cosmessagename)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COSMESSAGENAME");
            entity.Property(e => e.Cosparametername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COSPARAMETERNAME");
            entity.Property(e => e.Datatype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATATYPE");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Driverid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DRIVERID");
            entity.Property(e => e.Eventflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTFLAG");
            entity.Property(e => e.Heartbeatflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("No")
                .HasColumnName("HEARTBEATFLAG");
            entity.Property(e => e.Interval).HasColumnName("INTERVAL");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxvalue).HasColumnName("MAXVALUE");
            entity.Property(e => e.Minvalue).HasColumnName("MINVALUE");
            entity.Property(e => e.Monitoringflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MONITORINGFLAG");
            entity.Property(e => e.Offset).HasColumnName("OFFSET");
            entity.Property(e => e.Parameterflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERFLAG");
            entity.Property(e => e.Plcmax).HasColumnName("PLCMAX");
            entity.Property(e => e.Plcmin).HasColumnName("PLCMIN");
            entity.Property(e => e.Scaleuse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCALEUSE");
            entity.Property(e => e.Scalevalue).HasColumnName("SCALEVALUE");
            entity.Property(e => e.Setvalue).HasColumnName("SETVALUE");
            entity.Property(e => e.Stationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("STATIONID");
            entity.Property(e => e.Stringlen).HasColumnName("STRINGLEN");
            entity.Property(e => e.Tagkind)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGKIND");
            entity.Property(e => e.Tagmax).HasColumnName("TAGMAX");
            entity.Property(e => e.Tagmin).HasColumnName("TAGMIN");
            entity.Property(e => e.Tagname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TAGNAME");
            entity.Property(e => e.Tagtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGTYPE");
            entity.Property(e => e.Tagvalue)
                .IsUnicode(false)
                .HasColumnName("TAGVALUE");
            entity.Property(e => e.Unit)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("UNIT");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Writeuse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WRITEUSE");
        });

        modelBuilder.Entity<TbTag0614>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_TAG_0614");

            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Alarmflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ALARMFLAG");
            entity.Property(e => e.Cosflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COSFLAG");
            entity.Property(e => e.Cosmessagename)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COSMESSAGENAME");
            entity.Property(e => e.Cosparametername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COSPARAMETERNAME");
            entity.Property(e => e.Datatype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATATYPE");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Driverid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DRIVERID");
            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Eventflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EVENTFLAG");
            entity.Property(e => e.Interval).HasColumnName("INTERVAL");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxvalue).HasColumnName("MAXVALUE");
            entity.Property(e => e.Minvalue).HasColumnName("MINVALUE");
            entity.Property(e => e.Monitoringflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MONITORINGFLAG");
            entity.Property(e => e.Offset).HasColumnName("OFFSET");
            entity.Property(e => e.Parameterflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERFLAG");
            entity.Property(e => e.Plcmax).HasColumnName("PLCMAX");
            entity.Property(e => e.Plcmin).HasColumnName("PLCMIN");
            entity.Property(e => e.Scaleuse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCALEUSE");
            entity.Property(e => e.Scalevalue).HasColumnName("SCALEVALUE");
            entity.Property(e => e.Setvalue).HasColumnName("SETVALUE");
            entity.Property(e => e.Stationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("STATIONID");
            entity.Property(e => e.Stringlen).HasColumnName("STRINGLEN");
            entity.Property(e => e.Tagid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGID");
            entity.Property(e => e.Tagkind)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGKIND");
            entity.Property(e => e.Tagmax).HasColumnName("TAGMAX");
            entity.Property(e => e.Tagmin).HasColumnName("TAGMIN");
            entity.Property(e => e.Tagname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TAGNAME");
            entity.Property(e => e.Tagtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGTYPE");
            entity.Property(e => e.Tagvalue).HasColumnName("TAGVALUE");
            entity.Property(e => e.Unit)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("UNIT");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Writeuse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WRITEUSE");
        });

        modelBuilder.Entity<TbTag0704>(entity =>
        {
            entity.HasKey(e => new { e.Equipmentid, e.Tagid }).HasName("TAGDEFINITION_pk");

            entity.ToTable("TB_TAG_0704");

            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Tagid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGID");
            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Alarmflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Alarm Flag [ Yes | No ]")
                .HasColumnName("ALARMFLAG");
            entity.Property(e => e.Cosflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Change Of Status Flag [ Yes | No ]")
                .HasColumnName("COSFLAG");
            entity.Property(e => e.Cosmessagename)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Change Of Status Message Name")
                .HasColumnName("COSMESSAGENAME");
            entity.Property(e => e.Cosparametername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Change Of Status Parameter Name")
                .HasColumnName("COSPARAMETERNAME");
            entity.Property(e => e.Datatype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DATATYPE");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Driverid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("DRIVERID");
            entity.Property(e => e.Eventflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Flag [ Yes | No ]")
                .HasColumnName("EVENTFLAG");
            entity.Property(e => e.Interval).HasColumnName("INTERVAL");
            entity.Property(e => e.Lastupdatetime)
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Maxvalue).HasColumnName("MAXVALUE");
            entity.Property(e => e.Minvalue).HasColumnName("MINVALUE");
            entity.Property(e => e.Monitoringflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Monitoring Flag [ Yes | No ]")
                .HasColumnName("MONITORINGFLAG");
            entity.Property(e => e.Offset).HasColumnName("OFFSET");
            entity.Property(e => e.Parameterflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Parameter Flag [ Yes | No ]")
                .HasColumnName("PARAMETERFLAG");
            entity.Property(e => e.Plcmax).HasColumnName("PLCMAX");
            entity.Property(e => e.Plcmin).HasColumnName("PLCMIN");
            entity.Property(e => e.Scaleuse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SCALEUSE");
            entity.Property(e => e.Scalevalue).HasColumnName("SCALEVALUE");
            entity.Property(e => e.Setvalue).HasColumnName("SETVALUE");
            entity.Property(e => e.Stationid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("STATIONID");
            entity.Property(e => e.Stringlen).HasColumnName("STRINGLEN");
            entity.Property(e => e.Tagkind)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGKIND");
            entity.Property(e => e.Tagmax).HasColumnName("TAGMAX");
            entity.Property(e => e.Tagmin).HasColumnName("TAGMIN");
            entity.Property(e => e.Tagname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TAGNAME");
            entity.Property(e => e.Tagtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TAGTYPE");
            entity.Property(e => e.Tagvalue).HasColumnName("TAGVALUE");
            entity.Property(e => e.Unit)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("UNIT");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Use Flag [ Yes | No ]")
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Writeuse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("WRITEUSE");
        });

        modelBuilder.Entity<TbTier>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid, e.Rowid, e.Tierid }).HasName("PK_TIER");

            entity.ToTable("TB_TIER", tb => tb.HasComment("Tier 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Rowid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row ID")
                .HasColumnName("ROWID");
            entity.Property(e => e.Tierid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Tier ID")
                .HasColumnName("TIERID");
            entity.Property(e => e.Hoistposition)
                .HasComment("Hoist Position (바닥기준, 8ft 6inch 기준)")
                .HasColumnName("HOISTPOSITION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Posz)
                .HasComment("상태좌표 Z")
                .HasColumnName("POSZ");
            entity.Property(e => e.Tierindex)
                .HasComment("Tier 순서")
                .HasColumnName("TIERINDEX");
            entity.Property(e => e.Tiername)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Tier 명")
                .HasColumnName("TIERNAME");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbTierhistory>(entity =>
        {
            entity.HasKey(e => new { e.Blockid, e.Bayid, e.Rowid, e.Tierid, e.Timekey }).HasName("PK_TIERHISTORY");

            entity.ToTable("TB_TIERHISTORY", tb => tb.HasComment("Tier 정의"));

            entity.Property(e => e.Blockid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Block ID")
                .HasColumnName("BLOCKID");
            entity.Property(e => e.Bayid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Bay ID")
                .HasColumnName("BAYID");
            entity.Property(e => e.Rowid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Row ID")
                .HasColumnName("ROWID");
            entity.Property(e => e.Tierid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Tier ID")
                .HasColumnName("TIERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Hoistposition)
                .HasComment("Hoist Position (바닥기준, 8ft 6inch 기준)")
                .HasColumnName("HOISTPOSITION");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Posx)
                .HasComment("상대좌표 X")
                .HasColumnName("POSX");
            entity.Property(e => e.Posy)
                .HasComment("상태좌표 Y")
                .HasColumnName("POSY");
            entity.Property(e => e.Posz)
                .HasComment("상태좌표 Z")
                .HasColumnName("POSZ");
            entity.Property(e => e.Tierindex)
                .HasComment("Tier 순서")
                .HasColumnName("TIERINDEX");
            entity.Property(e => e.Tiername)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Tier 명")
                .HasColumnName("TIERNAME");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("USERDEFINITION_pk");

            entity.ToTable("TB_USER", tb => tb.HasComment("사용자정보"));

            entity.Property(e => e.Userid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("User ID")
                .HasColumnName("USERID");
            entity.Property(e => e.Adminflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("관리자권한")
                .HasColumnName("ADMINFLAG");
            entity.Property(e => e.Department)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("소속부서")
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Email")
                .HasColumnName("EMAIL");
            entity.Property(e => e.Employeenumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사원번호")
                .HasColumnName("EMPLOYEENUMBER");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Usergroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용자그룹")
                .HasColumnName("USERGROUPID");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("User Name")
                .HasColumnName("USERNAME");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("User Password")
                .HasColumnName("USERPASSWORD");
            entity.Property(e => e.Workposition)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("직위")
                .HasColumnName("WORKPOSITION");
        });

        modelBuilder.Entity<TbUserhistory>(entity =>
        {
            entity.HasKey(e => new { e.Userid, e.Timekey }).HasName("USERDEFINITIONHISTORY_pk");

            entity.ToTable("TB_USERHISTORY", tb => tb.HasComment("사용자정보"));

            entity.Property(e => e.Userid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("User ID")
                .HasColumnName("USERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Adminflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("관리자권한")
                .HasColumnName("ADMINFLAG");
            entity.Property(e => e.Department)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("소속부서")
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Email")
                .HasColumnName("EMAIL");
            entity.Property(e => e.Employeenumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사원번호")
                .HasColumnName("EMPLOYEENUMBER");
            entity.Property(e => e.Eventcomment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("Event Description ")
                .HasColumnName("EVENTCOMMENT");
            entity.Property(e => e.Eventname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Name")
                .HasColumnName("EVENTNAME");
            entity.Property(e => e.Eventtime)
                .HasComment("Event Time")
                .HasColumnType("datetime")
                .HasColumnName("EVENTTIME");
            entity.Property(e => e.Eventtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event Type")
                .HasColumnName("EVENTTYPE");
            entity.Property(e => e.Eventuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Event User")
                .HasColumnName("EVENTUSERID");
            entity.Property(e => e.Lastupdatetime)
                .HasComment("마지막수정일시")
                .HasColumnType("datetime")
                .HasColumnName("LASTUPDATETIME");
            entity.Property(e => e.Lastupdateuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("마지막수정자")
                .HasColumnName("LASTUPDATEUSERID");
            entity.Property(e => e.Useflag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용여부")
                .HasColumnName("USEFLAG");
            entity.Property(e => e.Usergroupid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("사용자그룹")
                .HasColumnName("USERGROUPID");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("User Name")
                .HasColumnName("USERNAME");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("User Password")
                .HasColumnName("USERPASSWORD");
            entity.Property(e => e.Workposition)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("직위")
                .HasColumnName("WORKPOSITION");
        });

        modelBuilder.Entity<TbViewjobparameter>(entity =>
        {
            entity.HasKey(e => new { e.Joborderid, e.Timekey, e.Compositionid, e.Actiontype, e.Parameterid }).HasName("PK_VIEWJOBPARAMETER");

            entity.ToTable("TB_VIEWJOBPARAMETER", tb => tb.HasComment("Step Job을 수행하기 위한 Parameter 정보를 생성 관리"));

            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TOS로 부터 내려받은 Job Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("ViewJobTracking의 TimeKey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("StepComposition 고유 ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Actiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("작업구분 [ Start | End | Execute ]")
                .HasColumnName("ACTIONTYPE");
            entity.Property(e => e.Parameterid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Parameter ID")
                .HasColumnName("PARAMETERID");
            entity.Property(e => e.Dataactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 작업구분 [ Set | Get ] ")
                .HasColumnName("DATAACTIONTYPE");
            entity.Property(e => e.Datafailtarget)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DATAFAILTARGET");
            entity.Property(e => e.Dataprocesstype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Data 처리구분 [ Event | Data ]")
                .HasColumnName("DATAPROCESSTYPE");
            entity.Property(e => e.Datatarget)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DATATARGET");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Parameterlevel)
                .HasComment("Parameter Level")
                .HasColumnName("PARAMETERLEVEL");
            entity.Property(e => e.Parameterstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARAMETERSTATUS");
            entity.Property(e => e.Receivedid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("RECEIVEDID");
            entity.Property(e => e.Tagid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Tag ID")
                .HasColumnName("TAGID");
            entity.Property(e => e.Tagvalue)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Tag 값")
                .HasColumnName("TAGVALUE");
        });

        modelBuilder.Entity<TbViewjobtracking>(entity =>
        {
            entity.HasKey(e => new { e.Joborderid, e.Timekey }).HasName("PK_VIEWJOBTRACKING");

            entity.ToTable("TB_VIEWJOBTRACKING", tb => tb.HasComment("Job을 수행하기 위한 Step Job 진행 정보를 생성 관리"));

            entity.Property(e => e.Joborderid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("TOS로 부터 내려받은 Job Order ID")
                .HasColumnName("JOBORDERID");
            entity.Property(e => e.Timekey)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Timekey")
                .HasColumnName("TIMEKEY");
            entity.Property(e => e.Compositionid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("StepComposition 고유 ID")
                .HasColumnName("COMPOSITIONID");
            entity.Property(e => e.Createdatatype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("데이터 생성 구분 [ RealTime | ReceivedTime ]")
                .HasColumnName("CREATEDATATYPE");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("비고")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Endiffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ENDIFFUNCTIONNAME");
            entity.Property(e => e.Endiftime)
                .HasComment("완료 인터페이스 일시")
                .HasColumnType("datetime")
                .HasColumnName("ENDIFTIME");
            entity.Property(e => e.Endmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("완료 작업시스템")
                .HasColumnName("ENDMODE");
            entity.Property(e => e.Endsystem)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("시작 인터페이스 일시")
                .HasColumnName("ENDSYSTEM");
            entity.Property(e => e.Endtime)
                .HasComment("완료 작업자")
                .HasColumnType("datetime")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Enduserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("완료 동작모드 [ Auto | Manual ]")
                .HasColumnName("ENDUSERID");
            entity.Property(e => e.Equipmentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job을 수행할 Crane ID")
                .HasColumnName("EQUIPMENTID");
            entity.Property(e => e.Ifactiontype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("인터페이스 구분 [ None | Start | End | Both | Execute ] ")
                .HasColumnName("IFACTIONTYPE");
            entity.Property(e => e.Jobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Job ID")
                .HasColumnName("JOBID");
            entity.Property(e => e.Operationmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("동작모드 [ Auto | Manual ] ")
                .HasColumnName("OPERATIONMODE");
            entity.Property(e => e.Preiffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PREIFFUNCTIONNAME");
            entity.Property(e => e.Startiffunctionname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment("인터페이스 실행 함수")
                .HasColumnName("STARTIFFUNCTIONNAME");
            entity.Property(e => e.Startiftime)
                .HasComment("완료 일시")
                .HasColumnType("datetime")
                .HasColumnName("STARTIFTIME");
            entity.Property(e => e.Startmode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("시작 동작모드 [ Auto | Manual ]")
                .HasColumnName("STARTMODE");
            entity.Property(e => e.Startsystem)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("시작 작업시스템")
                .HasColumnName("STARTSYSTEM");
            entity.Property(e => e.Starttime)
                .HasComment("시작 일시")
                .HasColumnType("datetime")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Startuserid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("시작 작업자")
                .HasColumnName("STARTUSERID");
            entity.Property(e => e.Stepjobid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job ID")
                .HasColumnName("STEPJOBID");
            entity.Property(e => e.Stepjobstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("상태 [ Wait | StartRequest | Start | Completed ]")
                .HasColumnName("STEPJOBSTATUS");
            entity.Property(e => e.Stepjobtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasComment("Step Job 구분 [ StartEnd | Execute ]")
                .HasColumnName("STEPJOBTYPE");
            entity.Property(e => e.Stepsequence)
                .HasComment("순서")
                .HasColumnName("STEPSEQUENCE");
        });
        modelBuilder.HasSequence<decimal>("TIMEKEYID")
            .HasMin(1L)
            .HasMax(999L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
