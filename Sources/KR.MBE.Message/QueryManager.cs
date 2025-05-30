using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using KR.MBE.Data.ActiveMQ;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Dynamic.Core;
using KR.MBE.Data.Models;
using KR.MBE.RCMS.Models;

namespace KR.MBE.CommonLibrary
{
    public static class QueryManager
    {

        /*

         <?xml version="1.0" encoding="UTF-8"?>
        <message>
            <header>
               <messagename>GetQueryResult</messagename>
                 <replysubject>PROD.KR.MBE.UI192.168.0.12.TEST</replysubject>
                 <sourcesubject>PROD.KR.MBE.UI192.168.0.12.TEST</sourcesubject>
                 <targetsubject>PROD.KR.MBE.TESTsvr</targetsubject>
            </header>
            <body>
               <SITEID>MBE</SITEID>
               <LANGUAGE>ko</LANGUAGE>
               <QUERYID>TEST1</QUERYID>
               <QUERYVERSION>00001</QUERYVERSION>
            </body>
        </message> 
         */

        public static bool getLoginData(string userId, string userPassword)
        {
            try
            {
                using (var context = new RcmsContext())
                {
                    var queryInfo = context.TbUsers.Where(e => e.Userid == userId && e.Userpassword == userPassword)
                        .FirstOrDefault();

                    if (queryInfo == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static Dictionary<string, Type> DbSetTypeDictionary = new Dictionary<string, Type>()
        {
            { "TB_ALARMHISTORY", typeof(TbAlarmhistory)},
            { "TB_BAY", typeof(TbBay)},
            { "TB_BAYHISTORY", typeof(TbBayhistory)},
            { "TB_BLOCK", typeof(TbBlock)},
            { "TB_BLOCKHISTORY", typeof(TbBlockhistory)},
            { "TB_BLOCKMAP", typeof(TbBlockmap)},
            { "TB_BLOCKMAPHISTORY", typeof(TbBlockmaphistory)},
            { "TB_CCTVACTION", typeof(TbCctvaction)},
            { "TB_CCTVACTIONCOMPOSITION", typeof(TbCctvactioncomposition)},
            { "TB_CCTVACTIONCOMPOSITIONHISTORY", typeof(TbCctvactioncompositionhistory)},
            { "TB_CCTVACTIONHISTORY", typeof(TbCctvactionhistory)},
            { "TB_CODEGENERATION", typeof(TbCodegeneration)},
            { "TB_COMMBLOCKINFO", typeof(TbCommblockinfo)},
            { "TB_CRANEWORKINGBAY", typeof(TbCraneworkingbay)},
            { "TB_CRANEWORKINGBAYHISTORY", typeof(TbCraneworkingbayhistory)},
            { "TB_CRANEWORKINGBLOCK", typeof(TbCraneworkingblock)},
            { "TB_CRANEWORKINGBLOCKHISTORY", typeof(TbCraneworkingblockhistory)},
            { "TB_CUSTOMEXCEPTION", typeof(TbCustomexception)},
            { "TB_CUSTOMQUERY", typeof(TbCustomquery)},
            { "TB_DISPATCHEVENT", typeof(TbDispatchevent)},
            { "TB_DRIVERINFO", typeof(TbDriverinfo)},
            { "TB_ENUM", typeof(TbEnum)},
            { "TB_ENUMGROUP", typeof(TbEnumgroup)},
            { "TB_ENUMVALUE", typeof(TbEnumvalue)},
            { "TB_EQUIPMENT", typeof(TbEquipment)},
            { "TB_EQUIPMENTHISTORY", typeof(TbEquipmenthistory)},
            { "TB_EQUIPMENTINFO", typeof(TbEquipmentinfo)},
            { "TB_EQUIPMENTINFOHISTORY", typeof(TbEquipmentinfohistory)},
            { "TB_EQUIPMENTTAGCOMPOSITION", typeof(TbEquipmenttagcomposition)},
            { "TB_EQUIPMENTTAGCOMPOSITIONHISTORY", typeof(TbEquipmenttagcompositionhistory)},
            { "TB_GRID", typeof(TbGrid)},
            { "TB_GRIDDETAIL", typeof(TbGriddetail)},
            { "TB_ID", typeof(TbId)},
            { "TB_IDCLASS", typeof(TbIdclass)},
            { "TB_IDCLASSSERIAL", typeof(TbIdclassserial)},
            { "TB_INVENTORY", typeof(TbInventory)},
            { "TB_JOB", typeof(TbJob)},
            { "TB_JOBHISTORY", typeof(TbJobhistory)},
            { "TB_JOBORDER", typeof(TbJoborder)},
            { "TB_JOBORDERHISTORY", typeof(TbJoborderhistory)},
            { "TB_JOBORDERREJECT", typeof(TbJoborderreject)},
            { "TB_MENU", typeof(TbMenu)},
            { "TB_MENUFAVORITE", typeof(TbMenufavorite)},
            { "TB_MENUGROUP", typeof(TbMenugroup)},
            { "TB_MENUPRIVILEGE", typeof(TbMenuprivilege)},
            { "TB_MONITORINGTAGMAP", typeof(TbMonitoringtagmap)},
            { "TB_PARAMETER", typeof(TbParameter)},
            { "TB_PARAMETERCOMPOSITION", typeof(TbParametercomposition)},
            { "TB_PARAMETERCOMPOSITIONHISTORY", typeof(TbParametercompositionhistory)},
            { "TB_PARAMETERHISTORY", typeof(TbParameterhistory)},
            { "TB_ROW", typeof(TbRow)},
            { "TB_ROWHISTORY", typeof(TbRowhistory)},
            { "TB_STATIONINFO", typeof(TbStationinfo)},
            { "TB_STEPCOMPOSITION", typeof(TbStepcomposition)},
            { "TB_STEPCOMPOSITIONHISTORY", typeof(TbStepcompositionhistory)},
            { "TB_STEPJOB", typeof(TbStepjob)},
            { "TB_STEPJOBHISTORY", typeof(TbStepjobhistory)},
            { "TB_SYSTEMEXCEPTION", typeof(TbSystemexception)},
            { "TB_TAG", typeof(TbTag)},
            { "TB_TAG0614", typeof(TbTag0614)},
            { "TB_TIER", typeof(TbTier)},
            { "TB_TIERHISTORY", typeof(TbTierhistory)},
            { "TB_USER", typeof(TbUser)},
            { "TB_USERHISTORY", typeof(TbUserhistory)},
            { "TB_VIEWJOBPARAMETER", typeof(TbViewjobparameter)},
            { "TB_VIEWJOBTRACKING", typeof(TbViewjobtracking)}
        };

        public static bool transactionRequestDb(string tableName, TxnRequestBody requestBody)
        {
            try
            {
                using (var context = new RcmsContext())
                {
                    tableName = $"TB_{tableName.Replace("Definition", "").ToUpper().Replace("TXN", "")}";
                    var tableTypeName = tableName.Replace("TB_", "TB");
                    
                    var property = context.GetType()
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .FirstOrDefault(p =>
                            p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                            p.PropertyType.GenericTypeArguments[0].Name.ToUpper() == tableTypeName);

                    dynamic table = property.GetValue(context);
                    DbTransection(table,  requestBody);

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static T DbSelectItem<T>(DbSet<T> dbSet, List<string> pkColumnList, Hashtable dataInfo) where T : class
        {
            try
            {
                var p = Expression.Parameter(typeof(T), "e");
                var expression = new List<string>();

                foreach (var columnName in pkColumnList)
                {
                    var tmpColumnName = $"{columnName.Substring(0, 1)}{columnName.Substring(1).ToLower()}";

                    var value = string.Empty;

                    if (dataInfo.ContainsKey(columnName) && dataInfo.ContainsKey($"OLD{columnName}"))
                    {
                        value = dataInfo[$"OLD{columnName}"].ToString();
                    }
                    else
                    {
                        value = dataInfo[columnName].ToString();
                    }

                    expression.Add($"e.{tmpColumnName} = \"{value}\"");

                }

                var e = DynamicExpressionParser.ParseLambda(new[] { p }, null, string.Join(" AND ", expression));

                var entity = dbSet.AsQueryable().Where("@0(it)", e).FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void DbTransection<T>(DbSet<T> dbSet, TxnRequestBody requestBody) where T : class
        {
            try
            {
                T entity = null;

                foreach (var dataInfo in requestBody.dataList.dataInfos)
                {
                    if (dataInfo.ContainsKey("_ROWSTATUS"))
                    {
                        switch (dataInfo["_ROWSTATUS"])
                        {
                            case "D": // Delete
                                {
                                    entity = DbSelectItem(dbSet, requestBody.pkColumnList, dataInfo);

                                    if (entity != null)
                                    {
                                        dbSet.Remove(entity);
                                    }
                                }
                                break;
                            case "C": // Insert
                                {
                                    Type type = typeof(T);

                                    entity = (T)Activator.CreateInstance(type);

                                    if (entity != null)
                                    {
                                        foreach (DictionaryEntry entry in dataInfo)
                                        {
                                            if (entry.Key.ToString() != "_ROWSTATUS")
                                            {
                                                var tmpColumnName =
                                                    $"{entry.Key.ToString().Substring(0, 1)}{entry.Key.ToString().Substring(1).ToLower()}";

                                                var property = entity.GetType().GetProperty(tmpColumnName);

                                                if (string.IsNullOrEmpty(entry.Value.ToString()))
                                                {
                                                    continue;
                                                }

                                                if (property != null)
                                                {
                                                    switch (true)
                                                    {
                                                        case bool _ when property.PropertyType == typeof(sbyte):
                                                        case bool _ when property.PropertyType == typeof(sbyte?):
                                                            {
                                                                if (sbyte.TryParse(entry.Value.ToString(), out sbyte sbyteVal))
                                                                {
                                                                    if (property.PropertyType == typeof(sbyte?))
                                                                    {
                                                                        property.SetValue(entity, (sbyte?)sbyteVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, sbyteVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(byte):
                                                        case bool _ when property.PropertyType == typeof(byte?):
                                                            {
                                                                if (byte.TryParse(entry.Value.ToString(), out byte byteVal))
                                                                {
                                                                    if (property.PropertyType == typeof(byte?))
                                                                    {
                                                                        property.SetValue(entity, (byte?)byteVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, byteVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(short):
                                                        case bool _ when property.PropertyType == typeof(short?):
                                                            {
                                                                if (short.TryParse(entry.Value.ToString(), out short shortVal))
                                                                {
                                                                    if (property.PropertyType == typeof(short?))
                                                                    {
                                                                        property.SetValue(entity, (short?)shortVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, shortVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(ushort):
                                                        case bool _ when property.PropertyType == typeof(ushort?):
                                                            {
                                                                if (ushort.TryParse(entry.Value.ToString(), out ushort ushortVal))
                                                                {
                                                                    if (property.PropertyType == typeof(ushort?))
                                                                    {
                                                                        property.SetValue(entity, (ushort?)ushortVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, ushortVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(int):
                                                        case bool _ when property.PropertyType == typeof(int?):
                                                            {
                                                                if (int.TryParse(entry.Value.ToString(), out int intVal))
                                                                {
                                                                    if (property.PropertyType == typeof(int?))
                                                                    {
                                                                        property.SetValue(entity, (int?)intVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, intVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(uint):
                                                        case bool _ when property.PropertyType == typeof(uint?):
                                                            {
                                                                if (uint.TryParse(entry.Value.ToString(), out uint uintVal))
                                                                {
                                                                    if (property.PropertyType == typeof(uint?))
                                                                    {
                                                                        property.SetValue(entity, (uint?)uintVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, uintVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(long):
                                                        case bool _ when property.PropertyType == typeof(long?):
                                                            {
                                                                if (long.TryParse(entry.Value.ToString(), out long longVal))
                                                                {
                                                                    if (property.PropertyType == typeof(long?))
                                                                    {
                                                                        property.SetValue(entity, (long?)longVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, longVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(ulong):
                                                        case bool _ when property.PropertyType == typeof(ulong?):
                                                            {
                                                                if (ulong.TryParse(entry.Value.ToString(), out ulong ulongVal))
                                                                {
                                                                    if (property.PropertyType == typeof(ulong?))
                                                                    {
                                                                        property.SetValue(entity, (ulong?)ulongVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, ulongVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(float):
                                                        case bool _ when property.PropertyType == typeof(float?):
                                                            {
                                                                if (float.TryParse(entry.Value.ToString(), out float floatVal))
                                                                {
                                                                    if (property.PropertyType == typeof(float?))
                                                                    {
                                                                        property.SetValue(entity, (float?)floatVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, floatVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(double):
                                                        case bool _ when property.PropertyType == typeof(double?):
                                                            {
                                                                if (double.TryParse(entry.Value.ToString(), out double doubleVal))
                                                                {
                                                                    if (property.PropertyType == typeof(double?))
                                                                    {
                                                                        property.SetValue(entity, (double?)doubleVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, doubleVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(decimal):
                                                        case bool _ when property.PropertyType == typeof(decimal?):
                                                            {
                                                                if (decimal.TryParse(entry.Value.ToString(), out decimal decimalVal))
                                                                {
                                                                    if (property.PropertyType == typeof(decimal?))
                                                                    {
                                                                        property.SetValue(entity, (decimal?)decimalVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, decimalVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(DateTime):
                                                        case bool _ when property.PropertyType == typeof(DateTime?):
                                                            {
                                                                if (DateTime.TryParse(entry.Value.ToString(), out DateTime dateTimeVal))
                                                                {
                                                                    if (property.PropertyType == typeof(DateTime?))
                                                                    {
                                                                        property.SetValue(entity, (DateTime?)dateTimeVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, dateTimeVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        default:
                                                            property.SetValue(entity, entry.Value);
                                                            break;
                                                    }
                                                }
                                            }
                                        }

                                        var lastupdateTimeProperty = entity.GetType().GetProperty("Lastupdatetime");
                                        var lastupdateUseridProperty = entity.GetType().GetProperty("Lastupdateuserid");

                                        if (lastupdateUseridProperty != null)
                                            lastupdateUseridProperty.SetValue(entity, requestBody.eventUser);

                                        if (lastupdateTimeProperty != null)
                                            lastupdateTimeProperty.SetValue(entity, (DateTime?)DateTime.Now);

                                        dbSet.Add(entity);
                                    }
                                }
                                break;
                            case "U": // Update
                                {
                                    if (requestBody.pkColumnList.Count() == 0)
                                    {
                                        var primaryKey = dbSet.EntityType.FindPrimaryKey();
                                        if(primaryKey != null)
                                        {
                                            foreach (var property in primaryKey.Properties)
                                            {
                                                requestBody.pkColumnList.Add(property.Name.ToUpper());
                                            }
                                        }
                                    }

                                    var oldEntity = DbSelectItem(dbSet, requestBody.pkColumnList, dataInfo);


                                    var isPrimaryKeyItemUpdate = IsPrimaryKeyItemUpdating(requestBody.pkColumnList, dataInfo);

                                    if (oldEntity != null)
                                    {
                                        if (isPrimaryKeyItemUpdate)
                                        {
                                            Type type = typeof(T);
                                            entity = (T)Activator.CreateInstance(type);
                                        }
                                        else
                                        {
                                            entity = oldEntity;
                                        }

                                        foreach (DictionaryEntry entry in dataInfo)
                                        {
                                            if (entry.Key.ToString() != "_ROWSTATUS")
                                            {
                                                var tmpColumnName = $"{entry.Key.ToString().Substring(0, 1)}{entry.Key.ToString().Substring(1).ToLower()}";

                                                var property = entity.GetType().GetProperty(tmpColumnName);

                                                if (property != null)
                                                {
                                                    switch (true)
                                                    {
                                                        case bool _ when property.PropertyType == typeof(sbyte):
                                                        case bool _ when property.PropertyType == typeof(sbyte?):
                                                            {
                                                                if (sbyte.TryParse(entry.Value.ToString(), out sbyte sbyteVal))
                                                                {
                                                                    if (property.PropertyType == typeof(sbyte?))
                                                                    {
                                                                        property.SetValue(entity, (sbyte?)sbyteVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, sbyteVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(byte):
                                                        case bool _ when property.PropertyType == typeof(byte?):
                                                            {
                                                                if (byte.TryParse(entry.Value.ToString(), out byte byteVal))
                                                                {
                                                                    if (property.PropertyType == typeof(byte?))
                                                                    {
                                                                        property.SetValue(entity, (byte?)byteVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, byteVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(short):
                                                        case bool _ when property.PropertyType == typeof(short?):
                                                            {
                                                                if (short.TryParse(entry.Value.ToString(), out short shortVal))
                                                                {
                                                                    if (property.PropertyType == typeof(short?))
                                                                    {
                                                                        property.SetValue(entity, (short?)shortVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, shortVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(ushort):
                                                        case bool _ when property.PropertyType == typeof(ushort?):
                                                            {
                                                                if (ushort.TryParse(entry.Value.ToString(), out ushort ushortVal))
                                                                {
                                                                    if (property.PropertyType == typeof(ushort?))
                                                                    {
                                                                        property.SetValue(entity, (ushort?)ushortVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, ushortVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(int):
                                                        case bool _ when property.PropertyType == typeof(int?):
                                                            {
                                                                if (int.TryParse(entry.Value.ToString(), out int intVal))
                                                                {
                                                                    if (property.PropertyType == typeof(int?))
                                                                    {
                                                                        property.SetValue(entity, (int?)intVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, intVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(uint):
                                                        case bool _ when property.PropertyType == typeof(uint?):
                                                            {
                                                                if (uint.TryParse(entry.Value.ToString(), out uint uintVal))
                                                                {
                                                                    if (property.PropertyType == typeof(uint?))
                                                                    {
                                                                        property.SetValue(entity, (uint?)uintVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, uintVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(long):
                                                        case bool _ when property.PropertyType == typeof(long?):
                                                            {
                                                                if (long.TryParse(entry.Value.ToString(), out long longVal))
                                                                {
                                                                    if (property.PropertyType == typeof(long?))
                                                                    {
                                                                        property.SetValue(entity, (long?)longVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, longVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(ulong):
                                                        case bool _ when property.PropertyType == typeof(ulong?):
                                                            {
                                                                if (ulong.TryParse(entry.Value.ToString(), out ulong ulongVal))
                                                                {
                                                                    if (property.PropertyType == typeof(ulong?))
                                                                    {
                                                                        property.SetValue(entity, (ulong?)ulongVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, ulongVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(float):
                                                        case bool _ when property.PropertyType == typeof(float?):
                                                            {
                                                                if (float.TryParse(entry.Value.ToString(), out float floatVal))
                                                                {
                                                                    if (property.PropertyType == typeof(float?))
                                                                    {
                                                                        property.SetValue(entity, (float?)floatVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, floatVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(double):
                                                        case bool _ when property.PropertyType == typeof(double?):
                                                            {
                                                                if (double.TryParse(entry.Value.ToString(), out double doubleVal))
                                                                {
                                                                    if (property.PropertyType == typeof(double?))
                                                                    {
                                                                        property.SetValue(entity, (double?)doubleVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, doubleVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(decimal):
                                                        case bool _ when property.PropertyType == typeof(decimal?):
                                                            {
                                                                if (decimal.TryParse(entry.Value.ToString(), out decimal decimalVal))
                                                                {
                                                                    if (property.PropertyType == typeof(decimal?))
                                                                    {
                                                                        property.SetValue(entity, (decimal?)decimalVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, decimalVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        case bool _ when property.PropertyType == typeof(DateTime):
                                                        case bool _ when property.PropertyType == typeof(DateTime?):
                                                            {
                                                                if (DateTime.TryParse(entry.Value.ToString(), out DateTime dateTimeVal))
                                                                {
                                                                    if (property.PropertyType == typeof(DateTime?))
                                                                    {
                                                                        property.SetValue(entity, (DateTime?)dateTimeVal);
                                                                    }
                                                                    else
                                                                    {
                                                                        property.SetValue(entity, dateTimeVal);

                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        default:
                                                            property.SetValue(entity, entry.Value);
                                                            break;
                                                    }
                                                }
                                            }
                                        }

                                        var lastupdateTimeProperty = entity.GetType().GetProperty("Lastupdatetime");
                                        var lastupdateUseridProperty = entity.GetType().GetProperty("Lastupdateuserid");

                                        if(lastupdateUseridProperty != null)
                                            lastupdateUseridProperty.SetValue(entity, requestBody.eventUser);

                                        if(lastupdateTimeProperty != null)
                                            lastupdateTimeProperty.SetValue(entity, (DateTime?)DateTime.Now);


                                        if (isPrimaryKeyItemUpdate)
                                        {
                                            dbSet.Remove(oldEntity);
                                            dbSet.Add(entity);
                                        }
                                        else
                                        {
                                            dbSet.Update(entity);
                                        }
                                        
                                    }
                                }
                                break;
                        }
                    }
                }
            } catch(Exception ex)
            {

            }
        }

        private static bool IsPrimaryKeyItemUpdating(List<string> pkColumnList, Hashtable dataInfo)
        {
            foreach (var columnName in pkColumnList)
            {
                if (dataInfo.ContainsKey($"OLD{columnName}"))
                {
                    return true;
                }
            }

            return false;
        }

        public static DataTable? getCustomQueryData( string sQueryID, string sQueryVersion, Hashtable htData, string sUseFlag = "Yes")
        {
            using (var context = new RcmsContext())
            {
                var queryInfo = context.TbCustomqueries.Where(e => e.Queryid == sQueryID && e.Queryversion == sQueryVersion)
                    .FirstOrDefault();

                if (queryInfo == null)
                {
                    return null;
                }
                else
                {
                    string queryStr = queryInfo.Querystring;

                    foreach (DictionaryEntry entry in htData)
                    {
                        if (entry.Key.ToString() == "USEFLAG")
                        {
                            sUseFlag = entry.Value.ToString();
                            continue;
                        }

                        queryStr = queryStr.Replace(":" + entry.Key.ToString(), $"'{entry.Value.ToString()}'");
                        
                    }

                    queryStr = queryStr.Replace("'T'", $"'{sUseFlag}'");
                    queryStr = queryStr.Replace(":USEFLAG", $"'{sUseFlag}'");

                    queryStr = Regex.Replace(queryStr, "(:[A-Z])\\w+", "NULL", RegexOptions.IgnoreCase);

                    Log.DebugLog("Custom Query ======================================");
                    Log.DebugLog(queryStr);
                    Log.DebugLog("===================================================");
                    var dataTable = ExecuteQueryToDataTable(context, queryStr);

                    if (dataTable == null)
                        return null;
                    else 
                        return dataTable;
                }
            }
        }

        public static DataTable ExecuteQueryToDataTable(DbContext context, string query)
        {
            var connection = context.Database.GetDbConnection();
            var dataTable = new DataTable();

            try
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
    }
}
