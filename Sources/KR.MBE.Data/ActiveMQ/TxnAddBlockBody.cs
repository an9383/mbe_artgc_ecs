using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KR.MBE.Data.ActiveMQ
{
//<ROWCOUNT>7</ROWCOUNT>
//<SITEID>MBE</SITEID>
//<MAXGANTRYPOSITION>142800</MAXGANTRYPOSITION>
//<ITVDIRECTION>Center</ITVDIRECTION>
//<MAXTROLLEYPOSITION>18200</MAXTROLLEYPOSITION>
//<USEFLAG>Yes</USEFLAG>
//<LANGUAGE>en</LANGUAGE>
//<GPSLONGITUDE></GPSLONGITUDE>
//<GPSLATITUDE></GPSLATITUDE>
//<BAYDIRECTION>Horizontal</BAYDIRECTION>
//<ROWNAMERULE>Numeric10</ROWNAMERULE>
//<EVENTUSER>wpd</EVENTUSER>
//<BLOCKTYPE>Block</BLOCKTYPE>
//<BAYSTART>0</BAYSTART>
//<BAYDISTANCE>6480</BAYDISTANCE>
//<TIERDISTANCE>2591</TIERDISTANCE>
//<ROWDISTANCE>2600</ROWDISTANCE>
//<BASEFLAG>Yes</BASEFLAG>
//<BAYCOUNT>20</BAYCOUNT>
//<TIERCOUNT>7</TIERCOUNT>
//<VEHICLETIER>1510</VEHICLETIER>
//<MAXHOISTPOSITION>23319</MAXHOISTPOSITION>
//<BLOCKID>T01</BLOCKID>
//<BLOCKNAME>T01</BLOCKNAME>
//<ROWDIRECTION>toLandSide</ROWDIRECTION>


    [DataContract]
    public class TxnAddBlockBody
    {
        [DataMember(Name = "SITEID")] public string SiteId { get; set; }
        [DataMember(Name = "EVENTUSER")] public string EventUser { get; set; }
        [DataMember(Name = "BLOCKID")] public string BlockID { get; set; }
        [DataMember(Name = "BLOCKNAME")] public string BlockName { get; set; }
        [DataMember(Name = "BLOCKTYPE")] public string BlockType { get; set; }
        [DataMember(Name = "USEFLAG")] public string UseFlag { get; set; }
        [DataMember(Name = "BAYDIRECTION")] public string BayDirection { get; set; }
        [DataMember(Name = "ITVDIRECTION")] public string ItvDirection { get; set; }
        [DataMember(Name = "ROWDIRECTION")] public string RowDirection { get; set; }


        [DataMember(Name = "BASEFLAG")] public string BaseFlag { get; set; }
        [DataMember(Name = "MAXGANTRYPOSITION")] public int MaxGantryPosition { get; set; }


        [DataMember(Name = "BAYSTART")] public int BayStart { get; set; }
        [DataMember(Name = "BAYDISTANCE")] public int BayDistance { get; set; }
        [DataMember(Name = "BAYCOUNT")] public int BayCount { get; set; }


        [DataMember(Name = "WALKWAYINTERVAL")] public int WalkwayInterval { get; set; }
        [DataMember(Name = "WALKWAYWIDTH")] public int WalkwayWidth { get; set; }



        [DataMember(Name = "ROWCOUNT")] public int RowCount { get; set; }
        [DataMember(Name = "ROWDISTANCE")] public int RowDistance { get; set; }
        [DataMember(Name = "ROWNAMERULE")] public string RowNameRule { get; set; }
        [DataMember(Name = "MAXTROLLEYPOSITION")] public int MaxTrolleyPosition { get; set; }

        // tire

        [DataMember(Name = "TIERCOUNT")] public int TierCount { get; set; }
        [DataMember(Name = "TIERDISTANCE")] public int TierDistance { get; set; }
        [DataMember(Name = "VEHICLETIER")] public int VehicleTier { get; set; }
        [DataMember(Name = "MAXHOISTPOSITION")] public int MaxHoistPosition { get; set; }


        // gps

        [DataMember(Name = "GPSLONGITUDE")] public double? GpsLongitude { get; set; }
        [DataMember(Name = "GPSLATITUDE")] public double? GpsLatitude { get; set; }



    }
}
