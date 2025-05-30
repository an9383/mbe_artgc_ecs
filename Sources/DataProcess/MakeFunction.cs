using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime;
using KR.MBE.CommonLibrary;
using KR.MBE.Message;
using Microsoft.Data.SqlClient;
using static KR.MBE.Data.TableObjects.toTableName;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Microsoft.EntityFrameworkCore;
using AngleSharp.Dom;
using KR.MBE.Data;
using KR.MBE.Data.Models;
using KR.MBE.RCMS.Models;

//using log4net;



namespace DataProcess
{





    //    BLOCKID BAYID   ROWID TROLLEYPOSITION NEXTTROLLEYPOSITION CENTERPOSITION
    //1	1	1	1200	24500	12850





    public static class MakeFunction
    {

        //public MakeFunction()
        //{
        //}


        static double getDistance(long x, long y, long x1, long y1)
        {
            return Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));
            ///* 두 점 사이의 거리를 구하기 위해 피타고라의 직각삼각형 정리를 이용합니다.
            //직각삼각형의 두변 a,b와 빗변 c가 있다면
            //c제곱의 길이는 a제곱 + b제곱이 됩니다. c^2 = a^2+b^2
            //그래서 c는 a제곱과 b제곱의 합의 제곱근이 됩니다.
            //*/
            //Math.sqrt(a)는 a의 제곱근을 구하는 함수입니다.
        }

        static int getDistanceInteger(long x, long y, long x1, long y1)
        {
            double distance = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));
            int iReturn = -1;
            try
            {
                iReturn = int.Parse( Math.Round(distance).ToString() );
            }
            catch (Exception ex)
            {
                Log.ErrorLog("Convert Double to Int Error!!!! : " + (Math.Round(distance).ToString()));
            }
            return iReturn;
            /* 두 점 사이의 거리를 구하기 위해 피타고라의 직각삼각형 정리를 이용합니다.
            직각삼각형의 두변 a,b와 빗변 c가 있다면
            c제곱의 길이는 a제곱 + b제곱이 됩니다. c^2 = a^2+b^2
            그래서 c는 a제곱과 b제곱의 합의 제곱근이 됩니다.
            */
            //Math.sqrt(a)는 a의 제곱근을 구하는 함수입니다.
        }

        public static string? getStepJobID(TbJoborder jobOrder, TbParametercomposition parameterComposition)
        {
            string? sReturn = "";

            using (var dbcontext = new RcmsContext())
            {
                TbStepcomposition? stepComposition = dbcontext.TbStepcompositions
                                                                .Where(e => e.Jobid == jobOrder.Jobid
                                                                && e.Compositionid == parameterComposition.Compositionid)
                                                                .FirstOrDefault();

                if (stepComposition != null)
                {
                    sReturn = stepComposition.Stepjobid;// .STEPJOBID;
                }
            }

            return sReturn;
        }

        public static string? getStepJobShortName(TbJoborder jobOrder, TbParametercomposition parameterComposition)
        {
            string? sReturn = "";

            using (var dbcontext = new RcmsContext())
            {
                //STEPCOMPOSITION stepComposition = new STEPCOMPOSITION();
                //stepComposition.setKeyJOBID(jobOrder.getJOBID());
                //stepComposition.setCOMPOSITIONID(parameterComposition.getKeyCOMPOSITIONID());
                //stepComposition = (STEPCOMPOSITION)stepComposition.excuteDML(SqlConstant.DML_SELECTROW);

                TbStepcomposition? stepComposition = dbcontext.TbStepcompositions
                                                               .Where(e => e.Jobid == jobOrder.Jobid
                                                                        && e.Compositionid == parameterComposition.Compositionid)
                                                               .FirstOrDefault() ;

                if (stepComposition != null)
                {
                    //STEPJOBDEFINITION step = new STEPJOBDEFINITION();
                    //step.setKeySTEPJOBID(stepComposition.getKeySTEPJOBID());
                    //step = (STEPJOBDEFINITION)step.excuteDML(SqlConstant.DML_SELECTROW);
                    TbStepjob? step = dbcontext.TbStepjobs
                                                    .Where(e => e.Stepjobid == stepComposition.Stepjobid)
                                                    .FirstOrDefault();

                    if (step != null)
                    {
                        sReturn = step.Shortname;
                    }
                }
            }

            return sReturn;
        }


        public static string? getFromGantryPosition(TbJoborder jobOrder)
        {
            string sReturn = getGantryPosition(jobOrder.Equipmentid, jobOrder.Fromblock, jobOrder.Frombay);
            Log.InfoLog("Distance       : " + sReturn);
            return sReturn;
        }

        public static string? getToGantryPosition(TbJoborder jobOrder)
        {
            string sReturn = getGantryPosition(jobOrder.Equipmentid, jobOrder.Toblock , jobOrder.Tobay );
            Log.InfoLog("Distance       : " + sReturn);
            return sReturn;
        }

        public static string? getFromTrolleyPosition(TbJoborder jobOrder)
        {
            string sReturn = getTrolleyPosition(jobOrder.Equipmentid, jobOrder.Fromblock, jobOrder.Frombay, jobOrder.Fromrow);
            Log.InfoLog("Distance       : " + sReturn);
            return sReturn;
        }

        public static string? getToTrolleyPosition(TbJoborder jobOrder)
        {
            string sReturn = getTrolleyPosition(jobOrder.Equipmentid, jobOrder.Toblock, jobOrder.Tobay, jobOrder.Torow);
            Log.InfoLog("Distance       : " + sReturn);
            return sReturn;
        }

        public static string? getFromHoistPosition(TbJoborder jobOrder)
        {
            string sReturn = getHoistPosition(jobOrder.Equipmentid, jobOrder.Fromblock, jobOrder.Frombay, jobOrder.Fromrow, jobOrder.Fromtier, jobOrder.Containerheight);
            Log.InfoLog("Distance       : " + sReturn);
            return sReturn;
        }
        public static string? getToHoistPosition(TbJoborder jobOrder)
        {
            string sReturn = getHoistPosition(jobOrder.Equipmentid, jobOrder.Toblock, jobOrder.Tobay, jobOrder.Torow, jobOrder.Totier, jobOrder.Containerheight);
            Log.InfoLog("Distance       : " + sReturn);
            return sReturn;
        }

        public static int getTierIndex(string blockID, string bayID, string rowID, string tierID)
        {
            using (var dbcontext = new RcmsContext())
            {
                var tier = dbcontext.TbTiers.Where(e =>
                    e.Tierid == tierID && e.Bayid == bayID && e.Blockid == blockID && e.Rowid == rowID).FirstOrDefault();


                if (tier != null)
                {
                    return (int)tier.Tierindex;
                }
                else
                {
                    return -1;
                }
            }

        }

        public static bool getRowWorkingLane(string blockID, string bayID, string rowID)
        {
            using (var dbcontext = new RcmsContext())
            {
                var sql = @"SELECT R.WORKINGLANEFLAG
                            FROM   TB_BLOCK BL 
                            INNER JOIN TB_BAY BA ON  BA.BLOCKID = BL.BLOCKID 
                            INNER JOIN TB_ROW R ON  R.BLOCKID = BA.BLOCKID AND R.BAYID = BA.BAYID 
                            WHERE   R.BLOCKID = @BLOCKID 
                            AND    R.BAYID = @BAYID  
                            AND    R.ROWID = @ROWID ";//
                                                      //ORDER BY R.ROWINDEX ";//
                                                      //                    ORDER BY BAYINDEX";
                switch (rowID)
                {
                    case "A":
                        rowID = "R01";
                        break;
                    case "B":
                        rowID = "R02";
                        break;
                    case "C":
                        rowID = "R03";
                        break;
                    case "D":
                        rowID = "R04";
                        break;
                    case "E":
                        rowID = "R05";
                        break;
                    case "F":
                        rowID = "R06";
                        break;
                    case "G":
                        rowID = "R07";
                        break;
                }

                var parameters = new[]
                {
                    new SqlParameter("@BLOCKID", blockID),
                    new SqlParameter("@BAYID", "B"+ bayID),
                    new SqlParameter("@ROWID", rowID)
                };

                var workinglaneflag = dbcontext.TbRows.FromSqlRaw(sql, parameters)
                                              .Select(e => e.Workinglaneflag)
                                              .FirstOrDefault();


                /*
                    public string? BlockId { get; set; }
                    public string? BayId { get; set; }
                    public string? RowId { get; set; }
                    public int? TROLLEYPOSITION { get; set; }
                    public int? NextGantryPosition { get; set; }
                    public int? CENTERPOSITION { get; set; }
                 */


                if (workinglaneflag != null)
                {
                    if (workinglaneflag == "Yes")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static string getHoistPosition(string equipmentID, string blockID, string bayID, string rowID, string tierID, string containerHeight)
        {
            // ContainerHeight Code
            // 0 : ???,  
            // 1 : 8' 6''  (2509.8 mm)  
            // 2 : 9'6''   (2895.6 mm)
            // 3 : 8'      (2438.4 mm)
            // 
            int iContainerHeight = getContainerHeight(containerHeight);

            // 적재 Row의 기준 Position 
            int iHoistPosition = 0;  // 확인필요


            try
            {
                switch (rowID)
                {
                    case "A":
                        rowID = "R01";
                        break;
                    case "B":
                        rowID = "R02";
                        break;
                    case "C":
                        rowID = "R03";
                        break;
                    case "D":
                        rowID = "R04";
                        break;
                    case "E":
                        rowID = "R05";
                        break;
                    case "F":
                        rowID = "R06";
                        break;
                    case "G":
                        rowID = "R07";
                        break;
                }

                if(int.TryParse(tierID, out int iTierID))
                    tierID = string.Format("T{0:D2}", iTierID);

                bayID = "B" + bayID;

                if (getRowWorkingLane(blockID, bayID, rowID))
                {
                    // 작업 Row가 차량 Lane일때 HoistPosition 계산
                    int iVehicleHeight = 1510; // 확인 필요
                    iHoistPosition = iVehicleHeight + iContainerHeight;

                    Log.InfoLog($" iHoistPosition : {iHoistPosition}");
                }
                else
                {
                    var tierIndex = getTierIndex(blockID, bayID, rowID, tierID);

                    if (tierIndex != -1)
                    {
                        // 작업 Row가 차량 Lane 이 아닐때는 INVENTORY의 Conatiner ISO 를 보고  HoistPosition 계산
                        using (var dbcontext = new RcmsContext())
                        {
                            string sql = @"SELECT 
                                TOP (SELECT COUNT(*) FROM TB_INVENTORY) I.*
                                FROM    TB_INVENTORY I
                                LEFT JOIN TB_TIER T ON I.BLOCKID = T.BLOCKID AND I.BAYID = T.BAYID AND I.ROWID = T.ROWID AND I.TIERID = T.TIERID
                                WHERE I.BLOCKID = @BLOCKID
                                      AND I.BAYID = @BAYID
                                      AND I.ROWID = @ROWID
                                      AND T.TIERINDEX <= @TIERINDEX
                                      AND I.CONTAINERID IS NOT NULL
                                      ORDER BY T.TIERINDEX ASC";

                            

                            var parameters = new[]
                            {
                                new SqlParameter("@BLOCKID", blockID),
                                new SqlParameter("@BAYID", bayID),
                                new SqlParameter("@ROWID", rowID),
                                new SqlParameter("@TIERINDEX", tierIndex)
                            };

                            var dataList = dbcontext.TbInventories.FromSqlRaw(sql, parameters).Select(inventory => inventory);

                            var iBaseHeight = 0;

                            if (dataList.Count() > 0)
                            {
                                foreach (var item in dataList)
                                {
                                    if (item.Tierid == tierID)
                                    {
                                        iBaseHeight = -1;
                                        break;
                                    }
                                    else
                                    {
                                        iBaseHeight += getContainerHeight(item.Containeriso);

                                        Log.InfoLog($" dBaseHeight : {iBaseHeight}");
                                    }
                                }
                            }

                            if (iBaseHeight < 0)
                            {
                                throw new Exception("");
                            }
                            else
                            {
                                iHoistPosition = iBaseHeight + iContainerHeight;


                                var equipment = dbcontext.TbEquipments
                                                    .Where(e => e.Equipmentid == equipmentID)
                                                    .FirstOrDefault();
                                if (equipment != null) {
                                    var hoistOffset = equipment.Hoistoffset ?? 0;
                                    var hoistScale = equipment.Hoistscale ?? 1;
                                    iHoistPosition = (int)((iHoistPosition - hoistOffset) * hoistScale);
                                }

                                return iHoistPosition.ToString();
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }
            }
            catch (Exception ex)
            {
                iHoistPosition = -1;
            }

            return string.Empty;
        }

        public static string getGantryPosition(string equipmentID, string blockID, string bayID)
        {
            string sReturn = string.Empty;

            /*     */
            //// BAY의 GantryPosition 은 해당 Bay의 첫 위치 임. 
            //BAY bayInfo = new BAY();
            //bayInfo.setKeySITEID(siteID);
            //bayInfo.setKeyBLOCKID(blockID);
            //bayInfo.setKeyBAYID(bayID);
            //bayInfo = (BAY)bayInfo.excuteDML(SqlConstant.DML_SELECTROW);
            //sReturn = ConvertUtil.Object2string(bayInfo.getGANTRYPOSITION());


            // BAY의 GantryPosition 은 해당 Bay의 첫 위치 임.
            // GantryPosition 의 중간 Position 으로 EIS에 내려줌.


            // TEST S
            using (var dbcontext = new RcmsContext())
            {
                //SELECT BA.BLOCKID,
                //                            BA.BAYID,
                //                            BA.GANTRYPOSITION,
                //                            ISNULL(LEAD(BA.GANTRYPOSITION) OVER (ORDER BY BA.BAYINDEX), BL.MAXGANTRYPOSITION) AS NEXGANTRYPOSITION,
                //                            BA.GANTRYPOSITION + (ISNULL(LEAD(BA.GANTRYPOSITION) OVER (ORDER BY BA.BAYINDEX), BL.MAXGANTRYPOSITION) - BA.GANTRYPOSITION) / 2 AS CENTERPOSITION
                //                     FROM   TB_BLOCK BL
                //                            INNER JOIN TB_BAY BA ON BA.BLOCKID = BL.BLOCKID AND BA.USEFLAG = 'Yes'
                //                     WHERE  BA.BLOCKID = @BLOCKID
                //                     AND    BA.BAYID = @BAYID";
                // //                    ORDER BY BAYINDEX";
                // 
                //var sql = "SELECT * FROM TB_BAY WHERE BLOCKID = @BLOCKID AND BAYID = @BAYID";
                ////var sql = @"SELECT A.*, (GANTRYPOSITION + (NEXTGANTRYPOSITION - GANTRYPOSITION)) / 2 AS CENTERPOSITION FROM 
                ////            (
                ////             SELECT BLOCKID,
                ////               BAYID,
                ////               GANTRYPOSITION,
                ////               LEAD(GANTRYPOSITION, 1, (SELECT MAXGANTRYPOSITION FROM TB_BLOCK WHERE BLOCKID = @BLOCKID)) OVER (ORDER BY BAYINDEX) AS NEXTGANTRYPOSITION
                ////             FROM TB_BAY
                ////             WHERE BLOCKID = @BLOCKID
                ////            ) AS A
                ////            where BAYID = @BAYID";

                //var parameters = new[]
                //{
                //    new SqlParameter("@BLOCKID", blockID),
                //    new SqlParameter("@BAYID", "B" + bayID)
                //};


                //var bayData = dbcontext.TbBays.Where().FromSqlRaw(sql, parameters)
                //                              .Select(ba => new BayData
                //                              {
                //                                  BlockId = ba.BlockId,
                //                                  BayId = ba.BayId,
                //                                  GantryPosition = ba.GantryPosition,
                //                                  //// NEXGANTRYPOSITION 및 CENTERPOSITION은 직접 매핑해야 합니다
                //                                  //// 임시로 0으로 설정합니다. 실제로는 raw SQL 쿼리의 결과를 사용해야 합니다.
                //                                  //NextGantryPosition = ba.NextGantryPosition,
                //                                  //CenterPosition = ba.CenterPosition
                //                              })
                //                              .FirstOrDefault();



                var equipment = dbcontext.TbEquipments
                                                    .Where(e => e.Equipmentid == equipmentID)
                                                    .FirstOrDefault();

                if (equipment != null)
                {
                    var gantryOffset = equipment.Gantryoffset ?? 0;
                    var gantryScale = equipment.Gantryscale ?? 1;

                    var dbbayID = "B" + bayID;
                    var bay = dbcontext.TbBays.FirstOrDefault(b => b.Blockid == blockID && b.Bayid == dbbayID);

                    if (bay != null && bay.Gantryposition != null)
                    {
                        var correctPosition = (int)((bay.Gantryposition - gantryOffset) * gantryScale);
                        sReturn = correctPosition.ToString();
                    }
                }

            }
            // TEST E

            /*
            Dictionary<string, string> bindMap = new Dictionary<string, string>();

            bindMap["BLOCKID"] = blockID;
            bindMap["BAYID"] = bayID;

            string sql = @"SELECT BA.BLOCKID,
                            BA.BAYID,
                            BA.GANTRYPOSITION,
                            ISNULL(LEAD(BA.GANTRYPOSITION) OVER (ORDER BY BA.BAYINDEX), BL.MAXGANTRYPOSITION) AS NEXGANTRYPOSITION,
                            BA.GANTRYPOSITION + (ISNULL(LEAD(BA.GANTRYPOSITION) OVER (ORDER BY BA.BAYINDEX), BL.MAXGANTRYPOSITION) - BA.GANTRYPOSITION) / 2 AS CENTERPOSITION
                    FROM   BLOCK BL
                            INNER JOIN BAY BA ON BA.BLOCKID = BL.BLOCKID AND BA.USEFLAG ='Yes'
                    WHERE  BA.BLOCKID = @BLOCKID
                    AND    BA.BAYID = @BAYID
                    ORDER BY BAYINDEX";

            List<Dictionary<string, object>> dataList = SqlMesTemplate.QueryForList(sql, bindMap);

            if (dataList.Count > 0)
            {

                sReturn = (dataList[0]["CENTERPOSITION"]);

            }

            string sData = $"Center Position Of Bay ({blockID},{bayID}) ";
            Log.InfoLog($"{sData} : {sReturn}");
            long iCheck = 0;
            // 숫자가 아닐때 Exception
            try
            {
                iCheck = long.Parse(sReturn);
            }
            catch (Exception ex)
            {
                ; //throw new CustomException("CM-105", new object[] { sData, sReturn });
            }
            // 음수일때 Exception
            if (iCheck < 0)
            {
                ; //throw new CustomException("CM-105", new object[] { sData, sReturn });
            }*/
            return sReturn;
        }


        public static string getSpreaderRow(TbJoborder jobOrder)
        {
            string sReturn = "";

            //확인필요  (확인후 로직 추가)
            //// FromRow가 존재하는 경우 
            //if (!jobOrder.getFROMROW().isEmpty())
            //{

            //}
            //else
            //{
            //    // EQUIPMENTDEFINITION 에 설정된 SpreaderDefaultRow 값을 가져온다.
            //    EQUIPMENTDEFINITION dataInfo = new EQUIPMENTDEFINITION();
            //    dataInfo.setKeySITEID(jobOrder.getKeySITEID());
            //    dataInfo.setKeyEQUIPMENTID(jobOrder.getEQUIPMENTID());
            //    dataInfo = (EQUIPMENTDEFINITION) dataInfo.excuteDML(SqlConstant.DML_SELECTROW);

            //    ROW row = new ROW();
            //    row.setKeySITEID(jobOrder.getKeySITEID());
            //    row.setKeyBLOCKID(sReturn);
            //    row.setKeyBAYID(jobOrder.getKeySITEID());
            //    row.setROWINDEX(ConvertUtil.Object2Long4Zero(dataInfo.getSPREADERDEFAULTROW()));

            //}


            //// EQUIPMENTDEFINITION 에 설정된 SpreaderDefaultRow 값을 가져온다.
            //EQUIPMENTDEFINITION dataInfo = new EQUIPMENTDEFINITION();
            //dataInfo.setKeySITEID(jobOrder.getKeySITEID());
            //dataInfo.setKeyEQUIPMENTID(jobOrder.getEQUIPMENTID());
            //dataInfo = (EQUIPMENTDEFINITION)dataInfo.excuteDML(SqlConstant.DML_SELECTROW);

            using (var dbcontext = new RcmsContext())
            {
                TbEquipment? equipment = dbcontext.TbEquipments
                                                    .Where(e => e.Equipmentid == jobOrder.Equipmentid)
                                                    .FirstOrDefault();      

                if (equipment != null)
                {
                    sReturn = equipment.Spreaderdefaultrow;
                }

            }

            // 확인필요
            return sReturn;
        }


        public static string getSpreaderRowPosition(TbJoborder jobOrder)
        {
            // 확인필요
            string sRowIndex = getSpreaderRow(jobOrder);
            string sReturn = "";
            using (var dbcontext = new RcmsContext())
            {

                //ROW row = new ROW();
                //row.setKeySITEID(jobOrder.getKeySITEID());
                //row.setKeyBLOCKID(jobOrder.getTOBLOCK());
                //row.setKeyBAYID(jobOrder.getTOBAY());
                //row.setROWINDEX(ConvertUtil.Object2Long(sRowIndex));
                //List<ROW> arrRow = (List<ROW>)row.excuteDML(SqlConstant.DML_SELECTLIST);


                var row = dbcontext.TbRows
                                        .Where(e => e.Blockid == jobOrder.Toblock
                                             && e.Bayid == "B" + jobOrder.Tobay
                                             && e.Rowindex == int.Parse(sRowIndex))
                                        .FirstOrDefault();

                string sRowID = "";
                
                if (row != null)
                {
                    sRowID = row.Rowid;
                }


                // TOBLOCK, TOBAY 로 처리
                sReturn = getTrolleyPosition(jobOrder.Equipmentid, jobOrder.Toblock, jobOrder.Tobay, sRowID);
                Log.InfoLog("Distance       : " + sReturn);
            }

            return sReturn;
        }

        public static int getContainerHeight(string sContainerHeightCode)
        {
            int iHeight = 0;

            switch (sContainerHeightCode)
            {
                case "1":  // 8'6'
                    iHeight = 2510;  // 2509.8
                    break;
                case "2": // 9'6''
                    iHeight = 2896;    // 2895.6
                    break;
                case "3": // 8'
                    iHeight = 2439;  // 2438.4
                    break;
                default:
                    iHeight = 2510;  // 2509.8 " 1번
                    break;
            }

            return iHeight;
        }

        //// ISO 높이 코드에 따른 mm 값 매핑
        //private static readonly Dictionary<char, int> HeightMap = new Dictionary<char, int>
        //{
        //    { '0', 2438 },  // 8'0"
        //    { '2', 2591 },  // 8'6"
        //    { '4', 2743 },  // 9'0"
        //    { '5', 2896 },  // 9'6"
        //    { '6', 3048 },  // 10'0"
        //};

        ///// <summary>
        ///// ISO 6346 컨테이너 코드에서 높이를 mm 단위로 반환합니다.
        ///// </summary>
        ///// <param name="isoCode">예: "45G1", "22G1", "25R1"</param>
        ///// <returns>높이(mm), 실패 시 -1</returns>
        //public static int getContainerHeight(string isoCode)
        //{
        //    if (!string.IsNullOrWhiteSpace(isoCode) && 2 <= isoCode.Length)
        //    {
        //        char heightChar = isoCode[1];

        //        if (HeightMap.TryGetValue(heightChar, out int heightMm))
        //        {
        //            return heightMm;
        //        }
        //    }

        //    return 2591;  // default;
        //}


        public static string getTrolleyPosition(string equipmentID, string blockID, string bayID, string rowID)
        {
            string sReturn = "";





            //ROW rowInfo = new ROW();
            //rowInfo.setKeySITEID(siteID));
            //rowInfo.setKeyBLOCKID(blockID);
            //rowInfo.setKeyBAYID(bayID);
            //rowInfo.setKeyROWID(rowID);
            //rowInfo = (ROW)rowInfo.excuteDML(SqlConstant.DML_SELECTROW);
            //sReturn = ConvertUtil.Object2string(rowInfo.getTROLLEYPOSITION());
            /*
            // Row의 TrolleyPosition 은 해당 Row의 좌측 첫 위치 임.
            // TrolleyPosition 의 중간 Position 으로 EIS에 내려줌.
            HashMap<string, string> bindMap = new HashMap<string, string>();
            bindMap.put("SITEID", siteID);
            bindMap.put("BLOCKID", blockID);
            bindMap.put("BAYID", bayID);
            bindMap.put("ROWID", rowID);

            string Sql = " SELECT R.BLOCKID , \r\n"
                        + "	   R.BAYID , \r\n"
                        + "	   R.BAYID , \r\n"
                        + "	   R.ROWID , \r\n"
                        + "	   R.TROLLEYPOSITION , \r\n"
                        + "	   ISNULL(LEAD(R.TROLLEYPOSITION) OVER (ORDER BY R.ROWINDEX), BL.MAXTROLLEYPOSITION) AS NEXTTROLLEYPOSITION, \r\n"
                        + "	   R.TROLLEYPOSITION + (ISNULL(LEAD(R.TROLLEYPOSITION) OVER (ORDER BY R.ROWINDEX), BL.MAXTROLLEYPOSITION) - R.TROLLEYPOSITION ) / 2 AS CENTERPOSITION \r\n"
                        + "FROM   BLOCK BL \r\n"
                        + "       INNER JOIN BAY BA ON BA.SITEID = BL.SITEID AND BA.BLOCKID = BL.BLOCKID \r\n"
                        + "       INNER JOIN ROW R ON R.SITEID = BA.SITEID AND R.BLOCKID = BA.BLOCKID AND R.BAYID = BA.BAYID \r\n"
                        + "WHERE  R.SITEID = :SITEID \r\n"
                        + "AND    R.BLOCKID = :BLOCKID \r\n"
                        + "AND    R.BAYID = :BAYID  \r\n"
                        + "AND    R.ROWID = :ROWID \r\n"
                        + "ORDER BY R.ROWINDEX \r\n"
                    + "";   q
            */

            // TEST S
            using (var dbcontext = new RcmsContext())
            {

                //var sql = @"SELECT R.BLOCKID , 
                //            R.BAYID , 
                //            R.ROWID , 
                //            R.TROLLEYPOSITION , 
                //            ISNULL(LEAD(R.TROLLEYPOSITION) OVER (ORDER BY R.ROWINDEX), BL.MAXTROLLEYPOSITION) AS POSX, 
                //            R.TROLLEYPOSITION + (ISNULL(LEAD(R.TROLLEYPOSITION) OVER (ORDER BY R.ROWINDEX), BL.MAXTROLLEYPOSITION) - R.TROLLEYPOSITION ) / 2 AS POSY 
                //            FROM   TB_BLOCK BL 
                //            INNER JOIN TB_BAY BA ON  BA.BLOCKID = BL.BLOCKID 
                //            INNER JOIN TB_ROW R ON  R.BLOCKID = BA.BLOCKID AND R.BAYID = BA.BAYID 
                //            WHERE   R.BLOCKID = @BLOCKID 
                //            AND    R.BAYID = @BAYID  
                //            AND    R.ROWID = @ROWID ";//
                //                                      //ORDER BY R.ROWINDEX ";//
                //                                      //                    ORDER BY BAYINDEX";


                var equipment = dbcontext.TbEquipments
                                                    .Where(e => e.Equipmentid == equipmentID)
                                                    .FirstOrDefault();


                if (equipment != null)
                {


                    var sql = @"SELECT R.BLOCKID , 
                            R.BAYID , 
                            R.ROWID , 
                            R.TROLLEYPOSITION
                            FROM TB_ROW R
                            WHERE R.BLOCKID = @BLOCKID 
                            AND   R.BAYID = @BAYID  
                            AND   R.ROWID = @ROWID ";

                    switch (rowID)
                    {
                        case "A":
                            rowID = "R01";
                            break;
                        case "B":
                            rowID = "R02";
                            break;
                        case "C":
                            rowID = "R03";
                            break;
                        case "D":
                            rowID = "R04";
                            break;
                        case "E":
                            rowID = "R05";
                            break;
                        case "F":
                            rowID = "R06";
                            break;
                        case "G":
                            rowID = "R07";
                            break;
                        default:
                            break;
                    }

                    var parameters = new[]
                    {
                    new SqlParameter("@BLOCKID", blockID),
                    new SqlParameter("@BAYID", "B" + bayID),
                    new SqlParameter("@ROWID", rowID)
                };

                    var rowDataList = dbcontext.TbRows.FromSqlRaw(sql, parameters)
                                                  .Select(e => new PosInfo
                                                  {
                                                      BlockId = e.Blockid,
                                                      BayId = e.Bayid,
                                                      RowId = e.Rowid,
                                                      TROLLEYPOSITION = e.Trolleyposition
                                                  })
                                                  //.OrderBy( Rowindex)
                                                  .ToList();


                    /*
                        public string? BlockId { get; set; }
                        public string? BayId { get; set; }
                        public string? RowId { get; set; }
                        public int? TROLLEYPOSITION { get; set; }
                        public int? NextGantryPosition { get; set; }
                        public int? CENTERPOSITION { get; set; }
                     */


                    if (rowDataList.Count() > 0)
                    {
                        var trolleyOffset = equipment.Trolleyoffset ?? 0;
                        var trolleyScale = equipment.Trolleyscale ?? 1;

                        var correctTrolleyPosition = (int)((rowDataList[0].TROLLEYPOSITION - trolleyOffset) * trolleyScale);
                        sReturn = correctTrolleyPosition.ToString();
                    }
                }

            }
            // TEST E


            /*
            List<HashMap<string, Object>> DataList = SqlMesTemplate.queryForList(Sql, bindMap);
            if (DataList.size() > 0)
            {
                sReturn = ConvertUtil.Object2string(DataList.get(0).get("CENTERPOSITION"));
            }

            string sData = "Center Position Of Row (" + blockID + "," + bayID + "," + rowID + ") ";
            Log.InfoLog(sData + " : " + sReturn);
            long iCheck = 0;
            // 숫자가 아닐때 Exception
            try
            {
                iCheck = Long.parseLong(sReturn);
            }
            catch (Exception ex)
            {
                throw new CustomException("CM-105", new Object[] { sData, sReturn });
            }
            // 음수일때 Exception
            if (iCheck < 0)
            {
                throw new CustomException("CM-105", new Object[] { sData, sReturn });
            }
            */

            return sReturn;
        }





        public static string? getSpreaderSafeHeight(TbJoborder jobOrder)
        {
            string? sReturn = "";

            using (var dbcontext = new RcmsContext())
            {
                TbEquipment? equipment = dbcontext.TbEquipments
                                                    .Where(e => e.Equipmentid == jobOrder.Equipmentid)
                                                    .FirstOrDefault();

                if (equipment != null)
                {
                    sReturn = equipment.Spreadersafeheight.ToString();
                }
            }
                return sReturn;
        }


        public static string? getSpreaderSize(TbJoborder jobOrder)
        {
            string? sReturn = "";

            switch(jobOrder.Containersize)
            {
                case "20":
                case "20ft":
                    sReturn = "20";
                    break;
                case "40":
                case "40ft":
                    sReturn = "40";
                    break;
                case "60":
                case "60ft":
                    sReturn = "60";
                    break;
                default :
                    sReturn = "0";
                    break;
            }


            return sReturn;
        }



                /*
                public static string getGantryPosition(string siteID, string blockID, string bayID)
                {
                    string sReturn = "";

                    //// BAY의 GantryPosition 은 해당 Bay의 첫 위치 임. 
                    //BAY bayInfo = new BAY();
                    //bayInfo.setKeySITEID(siteID);
                    //bayInfo.setKeyBLOCKID(blockID);
                    //bayInfo.setKeyBAYID(bayID);
                    //bayInfo = (BAY)bayInfo.excuteDML(SqlConstant.DML_SELECTROW);
                    //sReturn = ConvertUtil.Object2string(bayInfo.getGANTRYPOSITION());

                    // BAY의 GantryPosition 은 해당 Bay의 첫 위치 임.
                    // GantryPosition 의 중간 Position 으로 EIS에 내려줌.
                    HashMap<string, string> bindMap = new HashMap<string, string>();

                    bindMap.put("SITEID", siteID);
                    bindMap.put("BLOCKID", blockID);
                    bindMap.put("BAYID", bayID);

                    string Sql = " SELECT BA.BLOCKID,\r\n"
                                + "		   BA.BAYID ,\r\n"
                                + "		   BA.GANTRYPOSITION ,\r\n"
                                + "		   ISNULL(LEAD(BA.GANTRYPOSITION) OVER (ORDER BY BA.BAYINDEX), BL.MAXGANTRYPOSITION) AS NEXGANTRYPOSITION, \r\n"
                                + "		   BA.GANTRYPOSITION + (ISNULL(LEAD(BA.GANTRYPOSITION) OVER (ORDER BY BA.BAYINDEX), BL.MAXGANTRYPOSITION) - BA.GANTRYPOSITION ) / 2 AS CENTERPOSITION \r\n"
                                + "	FROM   BLOCK BL \r\n"
                                + "	       INNER JOIN BAY BA ON BA.SITEID = BL.SITEID AND BA.BLOCKID = BL.BLOCKID AND BA.USEFLAG ='Yes' \r\n"
                                + "	WHERE  BA.SITEID = :SITEID \r\n"
                                + "	AND    BA.BLOCKID = :BLOCKID \r\n"
                                + "	AND    BA.BAYID = :BAYID \r\n"
                                + "	ORDER BY BAYINDEX\r\n"
                                + "";

                    List<HashMap<string, Object>> DataList = SqlMesTemplate.queryForList(Sql, bindMap);
                    if (DataList.size() > 0)
                    {
                        sReturn = ConvertUtil.Object2string(DataList.get(0).get("CENTERPOSITION"));
                    }
                    string sData = "Center Position Of Bay (" + blockID + "," + bayID + ") ";
                    Log.InfoLog(sData + " : " + sReturn);
                    long iCheck = 0;
                    // 숫자가 아닐때 Exception
                    try
                    {
                        iCheck = Long.parseLong(sReturn);
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException("CM-105", new Object[] { sData, sReturn });
                    }
                    // 음수일때 Exception
                    if (iCheck < 0)
                    {
                        throw new CustomException("CM-105", new Object[] { sData, sReturn });
                    }

                    return sReturn;
                }
                */

                /*


                public static string getFromHoistPosition(TbJoborder jobOrder)
                {
                    ROW rowInfo = new ROW();
                    rowInfo.setKeySITEID(jobOrder.getKeySITEID());
                    rowInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    rowInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    rowInfo.setKeyROWID(jobOrder.getFROMROW());
                    rowInfo = (ROW)rowInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    TIER tierInfo = new TIER();
                    tierInfo.setKeySITEID(jobOrder.getKeySITEID());
                    tierInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    tierInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    tierInfo.setKeyROWID(jobOrder.getFROMROW());
                    tierInfo.setKeyTIERID(jobOrder.getFROMTIER());
                    tierInfo = (TIER)tierInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    string sReturn = getHoistPosition(jobOrder, rowInfo, tierInfo);
                    Log.InfoLog("From tierInfo.getHOISTPOSITION()       : " + sReturn);

                    return sReturn;
                }


                public static string getToHoistPosition(TbJoborder jobOrder)
                {
                    ROW rowInfo = new ROW();
                    rowInfo.setKeySITEID(jobOrder.getKeySITEID());
                    rowInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    rowInfo.setKeyBAYID(jobOrder.getTOBAY());
                    rowInfo.setKeyROWID(jobOrder.getTOROW());
                    rowInfo = (ROW)rowInfo.excuteDML(SqlConstant.DML_SELECTROW);


                    TIER tierInfo = new TIER();
                    tierInfo.setKeySITEID(jobOrder.getKeySITEID());
                    tierInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    tierInfo.setKeyBAYID(jobOrder.getTOBAY());
                    tierInfo.setKeyROWID(jobOrder.getTOROW());
                    tierInfo.setKeyTIERID(jobOrder.getTOTIER());
                    tierInfo = (TIER)tierInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    string sReturn = getHoistPosition(jobOrder, rowInfo, tierInfo);
                    Log.InfoLog("To tierInfo.getHOISTPOSITION()       : " + sReturn);

                    return sReturn;
                }



                public static string getInventoryList(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    HashMap<string, string> bindMap = new HashMap<string, string>();
                    bindMap.put("SITEID", jobOrder.getKeySITEID());
                    bindMap.put("BLOCKID", jobOrder.getTOBLOCK());
                    bindMap.put("BAYID", jobOrder.getTOBAY());

                    string Sql = " SELECT T.SITEID, T.BLOCKID, T.BAYID, T.ROWID, T.TIERID\r\n"
                                + "       , I.CONTAINERID\r\n"
                                + "       , IIF(I.CONTAINERID IS NULL OR I.CONTAINERID = '', 0, 1) AS FLAG \r\n"
                                + " FROM   TIER T\r\n"
                                + "	       INNER JOIN ROW R ON R.SITEID = T.SITEID AND R.BLOCKID = T.BLOCKID AND R.BAYID = T.BAYID AND R.ROWID = T.ROWID \r\n"
                                + "        LEFT OUTER JOIN INVENTORY I ON I.SITEID = T.SITEID AND I.BLOCKID = T.BLOCKID AND I.BAYID = T.BAYID AND I.ROWID = T.ROWID AND I.TIERID = T.TIERID\r\n"
                                + " WHERE  T.SITEID = :SITEID\r\n"
                                + " AND    T.BLOCKID = :BLOCKID\r\n"
                                + " AND    T.BAYID = :BAYID\r\n"
                                + " ORDER BY R.ROWINDEX, T.TIERINDEX";

                    List<HashMap<string, string>> DataList = SqlMesTemplate.queryForList(Sql, bindMap);

                    string sPreRowID = "";
                    for (int i = 0; i < DataList.size(); i++)
                    {
                        HashMap<string, string> oData = DataList.get(i);
                        string sRowID = oData.get("ROWID");
                        string sFlag = ConvertUtil.Object2string(oData.get("FLAG"));
                        if ((sPreRowID.isEmpty()) || (sPreRowID.equals(sRowID)))
                        {
                            sReturn += sFlag;
                        }
                        else
                        {
                            sReturn += "," + sFlag;
                        }
                        sPreRowID = sRowID;
                    }
                    Log.InfoLog(" getInventoryList : " + jobOrder.getTOBLOCK() + ", " + jobOrder.getTOBAY());
                    Log.InfoLog(" getInventoryList : " + sReturn);

                    return sReturn;
                }





                public static string getStackingRow(TbJoborder jobOrder, string sFromTo, int RowSeq)
                {
                    string sReturn = "";

                    // 1. RowID 가져오기
                    ROW dataInfo = new ROW();
                    dataInfo.setKeySITEID(jobOrder.getKeySITEID());
                    if ("FROM".equals(sFromTo))
                    {
                        dataInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                        dataInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    }
                    else
                    {
                        dataInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                        dataInfo.setKeyBAYID(jobOrder.getTOBAY());
                    }
                    List<ROW> arrRow = (List<ROW>)dataInfo.excuteDML(SqlConstant.DML_SELECTLIST, "ORDER BY ROWINDEX");

                    if ((RowSeq > 0) && (arrRow.size() >= RowSeq))
                    {
                        int iBaseHeight = 0;   // 확인필요

                        ROW rowInfo = arrRow.get(RowSeq - 1);

                        if (Constant.FLAG_YESNO_YES.equals(rowInfo.getWORKINGLANEFLAG()))
                        {
                            // 작업 Row가 차량 Lane일때 HoistPosition 계산
                            int iVehicleHeight = 1510;   // 확인 필요
                            iBaseHeight = iVehicleHeight;
                        }
                        else
                        {
                            // 2. 해당 Row에 적재된 Tier 정보 가져오기
                            HashMap<string, string> bindMap = new HashMap<string, string>();
                            bindMap.put("SITEID", rowInfo.getKeySITEID());
                            bindMap.put("BLOCKID", rowInfo.getKeyBLOCKID());
                            bindMap.put("BAYID", rowInfo.getKeyBAYID());
                            bindMap.put("ROWID", rowInfo.getKeyROWID());

                            string Sql = " SELECT T.SITEID, T.BLOCKID, T.BAYID, T.ROWID, T.TIERID\r\n"
                                        + "       , I.CONTAINERID, I.CONTAINERISO, I.CONTAINERHEIGHT\r\n"
                                        + " FROM   TIER T\r\n"
                                        + "	       INNER JOIN ROW R ON R.SITEID = T.SITEID AND R.BLOCKID = T.BLOCKID AND R.BAYID = T.BAYID AND R.ROWID = T.ROWID \r\n"
                                        + "        INNER JOIN INVENTORY I ON I.SITEID = T.SITEID AND I.BLOCKID = T.BLOCKID AND I.BAYID = T.BAYID AND I.ROWID = T.ROWID AND I.TIERID = T.TIERID\r\n"
                                        + " WHERE  T.SITEID = :SITEID\r\n"
                                        + " AND    T.BLOCKID = :BLOCKID\r\n"
                                        + " AND    T.BAYID = :BAYID\r\n"
                                        + " AND    R.ROWID = :ROWID\r\n"
                                        + " ORDER BY T.TIERINDEX";

                            List<HashMap<string, string>> DataList = SqlMesTemplate.queryForList(Sql, bindMap);

                            for (int i = 0; i < DataList.size(); i++)
                            {
                                int iTierHeight = 0;
                                string sCNTRID = ConvertUtil.Object2string(DataList.get(i).get("CONTAINERID"));
                                // ContainerID가 존재할때 
                                if (!sCNTRID.isEmpty())
                                {
                                    string sCNTRHeightCode = DataList.get(i).get("CONTAINERHEIGHT");
                                    iTierHeight = getContainerHeight(sCNTRHeightCode);
                                }

                                iBaseHeight = iBaseHeight + iTierHeight;
                                Log.InfoLog(" dBaseHeight : " + ConvertUtil.Object2string(iBaseHeight));
                            }

                        }

                        // 해당 Row, Tier의 HoistPosition => 해당 Row의 Container 가 적쟈된 Max HoistPosition 
                        sReturn = ConvertUtil.Object2string(iBaseHeight);

                    }


                    Log.InfoLog("getStackingRow  : [" + ConvertUtil.Object2string(RowSeq) + "] " + sReturn);

                    return sReturn;
                }



                public static string getRCS(TbJoborder jobOrder)
                {
                    string sReturn = "";
                    HashMap<string, string> bindMap = new HashMap<string, string>();
                    bindMap.put("SITEID", jobOrder.getKeySITEID());
                    bindMap.put("EQUIPMENTSTATUS", Constant.EQUIPMENTSTATUS_IDLE);
                    bindMap.put("COMMSTATUS", Constant.EQPCOMMSTATUS_ONLINE);

                    string Sql = " SELECT 	EI.EQUIPMENTID, EI.COMMSTATUS, EI.OPERATIONMODE, EI.LASTUPDATETIME\r\n"
                                + " FROM   	EQUIPMENTINFO EI \r\n"
                                + "	 		INNER JOIN EQUIPMENTDEFINITION ED ON ED.SITEID = EI.SITEID AND ED.EQUIPMENTID = EI.EQUIPMENTID \r\n"
                                + "									AND ED.EQUIPMENTTYPE = 'Station' AND ED.EQUIPMENTDETAILTYPE = 'RCS'\r\n"
                                + " WHERE   EI.SITEID = :SITEID\r\n"
                                + " AND     EI.EQUIPMENTSTATUS = :EQUIPMENTSTATUS\r\n"
                                + " AND     EI.COMMSTATUS = :COMMSTATUS \r\n"
                                + " ORDER BY EI.LASTUPDATETIME ";
                    List<HashMap<string, string>> DataList = SqlMesTemplate.queryForList(Sql, bindMap);

                    if (DataList.size() > 0)
                    {
                        HashMap<string, string> oData = DataList.get(0);
                        sReturn = oData.get("EQUIPMENTID");

                        // RCS할당후 Lock을 걸기 위해
                        EQUIPMENTINFO oRCS = new EQUIPMENTINFO();
                        oRCS.setKeySITEID(jobOrder.getKeySITEID());
                        oRCS.setKeyEQUIPMENTID(sReturn);
                        oRCS = (EQUIPMENTINFO)oRCS.excuteDML(SqlConstant.DML_SELECTWITHUDPLOCK);

                    }
                    else
                    {
                        sReturn = Constant.ECS_WAITINGRCSID;

                        // {0}상태의 {1}가 존재하지 않습니다. 잠시후 진행해 주시기 바랍니다.
                        //throw new CustomException("CM-103", new Object[] { Constant.EQUIPMENTSTATUS_IDLE, "RCS" });
                    }

                    Log.InfoLog(" getRCS : " + sReturn);

                    return sReturn;
                }


                public static string getCCTVList(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    // CCTV
                    EQUIPMENTDEFINITION dataInfo = new EQUIPMENTDEFINITION();
                    dataInfo.setKeySITEID(jobOrder.getKeySITEID());
                    dataInfo.setEQUIPMENTTYPE(Constant.EQPTYPE_DEVICE);
                    dataInfo.setEQUIPMENTDETAILTYPE(Constant.EQPDETAILTYPE_CCTV);
                    dataInfo.setSUPEREQUIPMENTID(jobOrder.getEQUIPMENTID());
                    List<EQUIPMENTDEFINITION> listCCTV = (List<EQUIPMENTDEFINITION>)dataInfo.excuteDML(SqlConstant.DML_SELECTLIST, "ORDER BY EQUIPMENTID");
                    for (int i = 0; i < listCCTV.size(); i++)
                    {
                        if (sReturn.isEmpty())
                        {
                            sReturn += listCCTV.get(i).getKeyEQUIPMENTID();
                        }
                        else
                        {
                            sReturn += "," + listCCTV.get(i).getKeyEQUIPMENTID();
                        }
                    }

                    return sReturn;
                }



                public static string getTwistLockCCTVList(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    // CCTV Action Composition
                    CCTVACTIONCOMPOSITION dataInfo = new CCTVACTIONCOMPOSITION();
                    dataInfo.setKeySITEID(jobOrder.getKeySITEID());
                    dataInfo.setKeyEQUIPMENTID(jobOrder.getEQUIPMENTID());
                    dataInfo.setKeyCCTVACTIONID(Constant.CCTVACTION_SPREADERTWISTLOCK);
                    List<CCTVACTIONCOMPOSITION> listCCTV = (List<CCTVACTIONCOMPOSITION>)dataInfo.excuteDML(SqlConstant.DML_SELECTLIST, "ORDER BY ORDERINDEX");
                    for (int i = 0; i < listCCTV.size(); i++)
                    {
                        if (sReturn.isEmpty())
                        {
                            sReturn += listCCTV.get(i).getCCTVID();
                        }
                        else
                        {
                            sReturn += "," + listCCTV.get(i).getCCTVID();
                        }
                    }

                    return sReturn;
                }



                public static string getTwistLockCCTVHttpList(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    // CCTV Action Composition
                    CCTVACTIONCOMPOSITION dataInfo = new CCTVACTIONCOMPOSITION();
                    dataInfo.setKeySITEID(jobOrder.getKeySITEID());
                    dataInfo.setKeyEQUIPMENTID(jobOrder.getEQUIPMENTID());
                    dataInfo.setKeyCCTVACTIONID(Constant.CCTVACTION_SPREADERTWISTLOCK);
                    List<CCTVACTIONCOMPOSITION> listCCTV = (<CCTVACTIONCOMPOSITION>)dataInfo.excuteDML(SqlConstant.DML_SELECTLIST, "ORDER BY ORDERINDEX");
                    for (int i = 0; i < listCCTV.size(); i++)
                    {
                        CCTVACTIONCOMPOSITION oData = listCCTV.get(i);

                        EQUIPMENTDEFINITION eqpInfo = new EQUIPMENTDEFINITION();
                        eqpInfo.setKeySITEID(oData.getKeySITEID());
                        eqpInfo.setKeyEQUIPMENTID(oData.getCCTVID());
                        eqpInfo = (EQUIPMENTDEFINITION)eqpInfo.excuteDML(SqlConstant.DML_SELECTROW);

                        string sURL = "http://" + eqpInfo.getIPADDRESS() + ":" + eqpInfo.getPORT() + "/device/di/" + eqpInfo.getCLIENTID();
                        if (sReturn.isEmpty())
                        {
                            sReturn += sURL;
                        }
                        else
                        {
                            sReturn += "," + sURL;
                        }
                    }

                    return sReturn;
                }






                public static string getClearanceUpdate(TbJoborder jobOrder)
                {
                    string sReturn = "1";

                    // 확인필요


                    return sReturn;
                }


                /// POSX, POSY 좌표 기준으로 Gantry, Trolley, Hoist Position 산출
                //  해당 Bay, Row, Tier의 Gantry, Trolley, Hoist Position 을 리턴하는 로직으로 변경함. 
                //  
                public static string getFromGantryPositionXY(TbJoborder jobOrder)
                {
                    string sReturn = "";
                    BLOCK blockInfo = new BLOCK();
                    blockInfo.setKeySITEID(jobOrder.getKeySITEID());
                    blockInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    blockInfo = (BLOCK)blockInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    BAY bayInfo = new BAY();
                    bayInfo.setKeySITEID(jobOrder.getKeySITEID());
                    bayInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    bayInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    bayInfo = (BAY)bayInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    // Block 좌표 에서 FromBay의 좌표까지의 상대 거리 계산
                    int distance = getDistanceInteger(blockInfo.getPOSX(), blockInfo.getPOSY(), bayInfo.getPOSX(), bayInfo.getPOSY());
                    sReturn = ConvertUtil.Object2string(distance);

                    Log.InfoLog("FromBlock Position : " + blockInfo.getPOSX().tostring() + "," +  blockInfo.getPOSY().tostring());
                    Log.InfoLog("FromBay   Position : " + bayInfo.getPOSX().tostring() + "," +  bayInfo.getPOSY().tostring());
                    Log.InfoLog("Distance       : " + sReturn);

                    return sReturn;
                }

                public static string getFromTrolleyPositionXY(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    BAY bayInfo = new BAY();
                    bayInfo.setKeySITEID(jobOrder.getKeySITEID());
                    bayInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    bayInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    bayInfo = (BAY)bayInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    ROW rowInfo = new ROW();
                    rowInfo.setKeySITEID(jobOrder.getKeySITEID());
                    rowInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    rowInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    rowInfo.setKeyROWID(jobOrder.getFROMROW());
                    rowInfo = (ROW)rowInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    // Bay 좌표 에서 FromRow의 좌표까지의 상대 거리 계산
                    int distance = getDistanceInteger(bayInfo.getPOSX(), bayInfo.getPOSY(), rowInfo.getPOSX(), rowInfo.getPOSY());
                    sReturn = ConvertUtil.Object2string(distance);

                    Log.InfoLog("FromBay Position : " + bayInfo.getPOSX().tostring() + "," +  bayInfo.getPOSY().tostring());
                    Log.InfoLog("FromRow Position : " + rowInfo.getPOSX().tostring() + "," +  rowInfo.getPOSY().tostring());
                    Log.InfoLog("Distance       : " + sReturn);

                    return sReturn;
                }

                public static string getFromHoistPositionXY(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    TIER tierInfo = new TIER();
                    tierInfo.setKeySITEID(jobOrder.getKeySITEID());
                    tierInfo.setKeyBLOCKID(jobOrder.getFROMBLOCK());
                    tierInfo.setKeyBAYID(jobOrder.getFROMBAY());
                    tierInfo.setKeyROWID(jobOrder.getFROMROW());
                    tierInfo.setKeyTIERID(jobOrder.getFROMTIER());
                    tierInfo = (TIER)tierInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    sReturn = ConvertUtil.Object2string(tierInfo.getPOSZ());

                    Log.InfoLog("From tierInfo.getPOSX()       : " + tierInfo.getPOSX());
                    Log.InfoLog("From tierInfo.getPOSY()       : " + tierInfo.getPOSY());
                    Log.InfoLog("From tierInfo.getPOSZ()       : " + sReturn);

                    return sReturn;
                }

                public static string getToGantryPositionXY(TbJoborder jobOrder)
                {
                    string sReturn = "";
                    BLOCK blockInfo = new BLOCK();
                    blockInfo.setKeySITEID(jobOrder.getKeySITEID());
                    blockInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    blockInfo = (BLOCK)blockInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    BAY bayInfo = new BAY();
                    bayInfo.setKeySITEID(jobOrder.getKeySITEID());
                    bayInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    bayInfo.setKeyBAYID(jobOrder.getTOBAY());
                    bayInfo = (BAY)bayInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    // Block 좌표 에서 FromBay의 좌표까지의 상대 거리 계산
                    int distance = getDistanceInteger(blockInfo.getPOSX(), blockInfo.getPOSY(), bayInfo.getPOSX(), bayInfo.getPOSY());
                    sReturn = ConvertUtil.Object2string(distance);

                    Log.InfoLog("ToBlock Position : " + blockInfo.getPOSX().tostring() + "," +  blockInfo.getPOSY().tostring());
                    Log.InfoLog("ToBay   Position : " + bayInfo.getPOSX().tostring() + "," +  bayInfo.getPOSY().tostring());
                    Log.InfoLog("Distance       : " + sReturn);

                    return sReturn;
                }

                public static string getToTrolleyPositionXY(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    BAY bayInfo = new BAY();
                    bayInfo.setKeySITEID(jobOrder.getKeySITEID());
                    bayInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    bayInfo.setKeyBAYID(jobOrder.getTOBAY());
                    bayInfo = (BAY)bayInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    ROW rowInfo = new ROW();
                    rowInfo.setKeySITEID(jobOrder.getKeySITEID());
                    rowInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    rowInfo.setKeyBAYID(jobOrder.getTOBAY());
                    rowInfo.setKeyROWID(jobOrder.getTOROW());
                    rowInfo = (ROW)rowInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    // Bay 좌표 에서 FromRow의 좌표까지의 상대 거리 계산
                    int distance = getDistanceInteger(bayInfo.getPOSX(), bayInfo.getPOSY(), rowInfo.getPOSX(), rowInfo.getPOSY());
                    sReturn = ConvertUtil.Object2string(distance);

                    Log.InfoLog("ToBay Position : " + bayInfo.getPOSX().tostring() + "," +  bayInfo.getPOSY().tostring());
                    Log.InfoLog("ToRow Position : " + rowInfo.getPOSX().tostring() + "," +  rowInfo.getPOSY().tostring());
                    Log.InfoLog("Distance       : " + sReturn);

                    return sReturn;
                }

                public static string getToHoistPositionXY(TbJoborder jobOrder)
                {
                    string sReturn = "";

                    TIER tierInfo = new TIER();
                    tierInfo.setKeySITEID(jobOrder.getKeySITEID());
                    tierInfo.setKeyBLOCKID(jobOrder.getTOBLOCK());
                    tierInfo.setKeyBAYID(jobOrder.getTOBAY());
                    tierInfo.setKeyROWID(jobOrder.getTOROW());
                    tierInfo.setKeyTIERID(jobOrder.getTOTIER());
                    tierInfo = (TIER)tierInfo.excuteDML(SqlConstant.DML_SELECTROW);

                    sReturn = tierInfo.getPOSZ().tostring();

                    Log.InfoLog("To tierInfo.getPOSX()       : " + tierInfo.getPOSX());
                    Log.InfoLog("To tierInfo.getPOSY()       : " + tierInfo.getPOSY());
                    Log.InfoLog("To tierInfo.getPOSZ()       : " + sReturn);

                    return sReturn;
                }
                // 확인 끝   
                */
            }
        }
