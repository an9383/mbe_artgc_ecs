using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

public partial class TbTag0614
{
    public string Equipmentid { get; set; } = null!;

    public string Tagid { get; set; } = null!;

    public string? Tagname { get; set; }

    public string? Description { get; set; }

    public string? Useflag { get; set; }

    public string? Tagkind { get; set; }

    public string? Tagtype { get; set; }

    public string? Driverid { get; set; }

    public string? Stationid { get; set; }

    public string? Address { get; set; }

    public string? Datatype { get; set; }

    public string? Eventflag { get; set; }

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

    public string? Alarmflag { get; set; }

    public string? Monitoringflag { get; set; }

    public string? Cosflag { get; set; }

    public string? Cosmessagename { get; set; }

    public string? Cosparametername { get; set; }

    public DateTime? Lastupdatetime { get; set; }

    public string? Lastupdateuserid { get; set; }
}
