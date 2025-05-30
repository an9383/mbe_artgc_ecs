using System;
using System.Collections.Generic;

namespace ARTGC.Models_scaffold;

public partial class TbTag
{
    public string Equipmentid { get; set; } = null!;

    public string Tagid { get; set; } = null!;

    public string? Tagname { get; set; }

    public string? Description { get; set; }

    /// <summary>
    /// Use Flag [ Yes | No ]
    /// </summary>
    public string? Useflag { get; set; }

    public string? Tagkind { get; set; }

    public string? Tagtype { get; set; }

    public string? Driverid { get; set; }

    public string? Stationid { get; set; }

    public string? Address { get; set; }

    public string? Datatype { get; set; }

    /// <summary>
    /// Event Flag [ Yes | No ]
    /// </summary>
    public string? Eventflag { get; set; }

    /// <summary>
    /// Parameter Flag [ Yes | No ]
    /// </summary>
    public string? Parameterflag { get; set; }

    public int? Stringlen { get; set; }

    public string? Writeuse { get; set; }

    public string? Scaleuse { get; set; }

    public double? Scalevalue { get; set; }

    public double? Offset { get; set; }

    public double? Plcmin { get; set; }

    public double? Plcmax { get; set; }

    public double? Tagmin { get; set; }

    public double? Tagmax { get; set; }

    public double? Tagvalue { get; set; }

    public double? Setvalue { get; set; }

    public double? Minvalue { get; set; }

    public double? Maxvalue { get; set; }

    public int? Interval { get; set; }

    public string? Unit { get; set; }

    /// <summary>
    /// Alarm Flag [ Yes | No ]
    /// </summary>
    public string? Alarmflag { get; set; }

    /// <summary>
    /// Monitoring Flag [ Yes | No ]
    /// </summary>
    public string? Monitoringflag { get; set; }

    /// <summary>
    /// Change Of Status Flag [ Yes | No ]
    /// </summary>
    public string? Cosflag { get; set; }

    /// <summary>
    /// Change Of Status Message Name
    /// </summary>
    public string? Cosmessagename { get; set; }

    /// <summary>
    /// Change Of Status Parameter Name
    /// </summary>
    public string? Cosparametername { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
