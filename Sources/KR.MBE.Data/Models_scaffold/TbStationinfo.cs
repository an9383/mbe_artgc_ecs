using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

public partial class TbStationinfo
{
    /// <summary>
    /// 장비ID
    /// </summary>
    public string Equipmentid { get; set; } = null!;

    /// <summary>
    /// Station ID
    /// </summary>
    public string Stationid { get; set; } = null!;

    /// <summary>
    /// 프로토콜 구분 [ MODBUS TCP |LSIS ENET |MSG|  … ]
    /// </summary>
    public string Protocolname { get; set; } = null!;

    /// <summary>
    /// EIS IP
    /// </summary>
    public string? Localip { get; set; }

    /// <summary>
    /// EIS Port Number
    /// </summary>
    public int? Localport { get; set; }

    /// <summary>
    /// Remote IP
    /// </summary>
    public string? Remoteip { get; set; }

    /// <summary>
    /// Remote Port Number
    /// </summary>
    public int? Remoteport { get; set; }

    /// <summary>
    /// Rack Number only in Siemens PLC
    /// </summary>
    public int? Rackno { get; set; }

    /// <summary>
    /// CPU SLOT Number only in Siemens PLC
    /// </summary>
    public int? Cpuslotno { get; set; }

    /// <summary>
    /// Station Number in Melsec PLC
    /// </summary>
    public int? Stationno { get; set; }

    /// <summary>
    /// Communication Interval(Cycle) ( 단위 100ms)
    /// </summary>
    public int? Comminterval { get; set; }

    /// <summary>
    /// Communication Timeout ( 단위 100ms)
    /// </summary>
    public int? Timeout { get; set; }

    /// <summary>
    /// OPC SERVER Name
    /// </summary>
    public string? Opcserver { get; set; }

    /// <summary>
    /// OPC Server PC Name or PC IP
    /// </summary>
    public string? Opclocalremote { get; set; }

    /// <summary>
    /// OPC Server Class ID(CLSID)
    /// </summary>
    public string? Opcclsid { get; set; }

    public bool? Commstatus { get; set; }
}
