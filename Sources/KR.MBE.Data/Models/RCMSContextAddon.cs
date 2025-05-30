using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using KR.MBE.Data.Models;

namespace KR.MBE.Data.Models
{
    //public partial class RCMSContext : DbContext, IRCMSContext
    //{
    //    public DbSet<BayData> BayDatas { get; set; } // TB_BAY BayData Result
    //    public DbSet<RowData> RowDatas { get; set; } // TB_ROW RowData Result

    //    public Dictionary<string, Type> DbSetTypeDictionary = new Dictionary<string, Type>()
    //    {
    //        { "TB_ALARMHISTORY", typeof(TbAlarmhistory)},
    //        { "TB_BAY", typeof(TbBay)},
    //        { "TB_BAYHISTORY", typeof(TbBayhistory)},
    //        { "TB_BLOCK", typeof(TbBlock)},
    //        { "TB_BLOCKHISTORY", typeof(TbBlockhistory)},
    //        { "TB_BLOCKMAP", typeof(TbBlockmap)},
    //        { "TB_BLOCKMAPHISTORY", typeof(TbBlockmaphistory)},
    //        { "TB_CCTVACTION", typeof(TbCctvaction)},
    //        { "TB_CCTVACTIONCOMPOSITION", typeof(TbCctvactioncomposition)},
    //        { "TB_CCTVACTIONCOMPOSITIONHISTORY", typeof(TbCctvactioncompositionhistory)},
    //        { "TB_CCTVACTIONHISTORY", typeof(TbCctvactionhistory)},
    //        { "TB_CODEGENERATION", typeof(TbCodegeneration)},
    //        { "TB_COMMBLOCKINFO", typeof(TbCommblockinfo)},
    //        { "TB_CRANEWORKINGBAY", typeof(TbCraneworkingbay)},
    //        { "TB_CRANEWORKINGBAYHISTORY", typeof(TbCraneworkingbayhistory)},
    //        { "TB_CRANEWORKINGBLOCK", typeof(TbCraneworkingblock)},
    //        { "TB_CRANEWORKINGBLOCKHISTORY", typeof(TbCraneworkingblockhistory)},
    //        { "TB_CUSTOMEXCEPTION", typeof(TbCustomexception)},
    //        { "TB_CUSTOMQUERY", typeof(TbCustomquery)},
    //        { "TB_DISPATCHEVENT", typeof(TbDispatchevent)},
    //        { "TB_DRIVERINFO", typeof(TbDriverinfo)},
    //        { "TB_ENUM", typeof(TbEnum)},
    //        { "TB_ENUMGROUP", typeof(TbEnumgroup)},
    //        { "TB_ENUMVALUE", typeof(TbEnumvalue)},
    //        { "TB_EQUIPMENT", typeof(TbEquipment)},
    //        { "TB_EQUIPMENTHISTORY", typeof(TbEquipmenthistory)},
    //        { "TB_EQUIPMENTINFO", typeof(TbEquipmentinfo)},
    //        { "TB_EQUIPMENTINFOHISTORY", typeof(TbEquipmentinfohistory)},
    //        { "TB_EQUIPMENTTAGCOMPOSITION", typeof(TbEquipmenttagcomposition)},
    //        { "TB_EQUIPMENTTAGCOMPOSITIONHISTORY", typeof(TbEquipmenttagcompositionhistory)},
    //        { "TB_GRID", typeof(TbGrid)},
    //        { "TB_GRIDDETAIL", typeof(TbGriddetail)},
    //        { "TB_ID", typeof(TbId)},
    //        { "TB_IDCLASS", typeof(TbIdclass)},
    //        { "TB_IDCLASSSERIAL", typeof(TbIdclassserial)},
    //        { "TB_INVENTORY", typeof(TbInventory)},
    //        { "TB_JOB", typeof(TbJob)},
    //        { "TB_JOBHISTORY", typeof(TbJobhistory)},
    //        { "TB_JOBORDER", typeof(TbJoborder)},
    //        { "TB_JOBORDERHISTORY", typeof(TbJoborderhistory)},
    //        { "TB_JOBORDERREJECT", typeof(TbJoborderreject)},
    //        { "TB_MENU", typeof(TbMenu)},
    //        { "TB_MENUFAVORITE", typeof(TbMenufavorite)},
    //        { "TB_MENUGROUP", typeof(TbMenugroup)},
    //        { "TB_MENUPRIVILEGE", typeof(TbMenuprivilege)},
    //        { "TB_MONITORINGTAGMAP", typeof(TbMonitoringtagmap)},
    //        { "TB_PARAMETER", typeof(TbParameter)},
    //        { "TB_PARAMETERCOMPOSITION", typeof(TbParametercomposition)},
    //        { "TB_PARAMETERCOMPOSITIONHISTORY", typeof(TbParametercompositionhistory)},
    //        { "TB_PARAMETERHISTORY", typeof(TbParameterhistory)},
    //        { "TB_ROW", typeof(TbRow)},
    //        { "TB_ROWHISTORY", typeof(TbRowhistory)},
    //        { "TB_STATIONINFO", typeof(TbStationinfo)},
    //        { "TB_STEPCOMPOSITION", typeof(TbStepcomposition)},
    //        { "TB_STEPCOMPOSITIONHISTORY", typeof(TbStepcompositionhistory)},
    //        { "TB_STEPJOB", typeof(TbStepjob)},
    //        { "TB_STEPJOBHISTORY", typeof(TbStepjobhistory)},
    //        { "TB_SYSTEMEXCEPTION", typeof(TbSystemexception)},
    //        { "TB_TAG", typeof(TbTag)},
    //        { "TB_TAG0614", typeof(TbTag0614)},
    //        { "TB_TIER", typeof(TbTier)},
    //        { "TB_TIERHISTORY", typeof(TbTierhistory)},
    //        { "TB_USER", typeof(TbUser)},
    //        { "TB_USERHISTORY", typeof(TbUserhistory)},
    //        { "TB_VIEWJOBPARAMETER", typeof(TbViewjobparameter)},
    //        { "TB_VIEWJOBTRACKING", typeof(TbViewjobtracking)}
    //    };

    //    partial void InitializePartial()
    //    {
    //    }

    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.ApplyConfiguration(new TbBayConfigurationForBayDatas());
    //        modelBuilder.ApplyConfiguration(new TbRowConfigurationForRowDatas());
    //    }
    //}

}
