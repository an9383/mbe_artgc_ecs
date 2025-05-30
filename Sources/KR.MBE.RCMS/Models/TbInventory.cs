using System;
using System.Collections.Generic;

namespace KR.MBE.RCMS.Models;

/// <summary>
/// Current Container Inventory 정보
/// </summary>
public partial class TbInventory
{
    /// <summary>
    /// Block ID
    /// </summary>
    public string Blockid { get; set; } = null!;

    /// <summary>
    /// Bay ID
    /// </summary>
    public string Bayid { get; set; } = null!;

    /// <summary>
    /// Row ID
    /// </summary>
    public string Rowid { get; set; } = null!;

    /// <summary>
    /// Tier ID
    /// </summary>
    public string Tierid { get; set; } = null!;

    /// <summary>
    /// 컨테이너 ID
    /// </summary>
    public string? Containerid { get; set; }

    /// <summary>
    /// 컨테이너 ISO (Container Size &amp; Type 규격)
    /// </summary>
    public string? Containeriso { get; set; }

    /// <summary>
    /// 컨테이너 Size [ 20ft | 40ft | 45ft | 48ft ]
    /// </summary>
    public string? Containersize { get; set; }

    /// <summary>
    /// 컨테이너 Height [ 0:Undefined | 1:8&apos;6&apos;&apos; | 2:9&apos;6&apos;&apos; | 3:8&apos; ]
    /// </summary>
    public string? Containerheight { get; set; }

    /// <summary>
    /// 컨테이너 Weight (kg)
    /// </summary>
    public string? Containerweight { get; set; }

    /// <summary>
    /// 컨테이너 Door Direction [ 1:TowardLowerBay | 2:TowardHigherBay ]
    /// </summary>
    public string? Containerdoordir { get; set; }

    /// <summary>
    /// 컨테이너 구분
    /// </summary>
    public string? Containertype { get; set; }

    /// <summary>
    /// 컨테이너 Operator Code
    /// </summary>
    public string? Containeropr { get; set; }

    /// <summary>
    /// 컨테이너 Class
    /// </summary>
    public string? Containerclass { get; set; }

    /// <summary>
    /// 컨테이너 Cargo Type
    /// </summary>
    public string? Containercargotype { get; set; }

    /// <summary>
    /// 컨테이너 Full Empty
    /// </summary>
    public string? Containerfullmty { get; set; }

    /// <summary>
    /// Port of Discharge
    /// </summary>
    public string? Pod { get; set; }

    /// <summary>
    /// Damage Status [ Y | N ]
    /// </summary>
    public string? Damageflag { get; set; }

    /// <summary>
    /// Seal Status [ Y | N ]
    /// </summary>
    public string? Sealflag { get; set; }

    /// <summary>
    /// Hold Status [ Y | N ]
    /// </summary>
    public string? Holdflag { get; set; }

    /// <summary>
    /// 컨테이너 Grade [ G1 | G2 | … ]
    /// </summary>
    public string? Containergrade { get; set; }

    /// <summary>
    /// 컨테이너 Special Type
    /// </summary>
    public string? Containersptype { get; set; }

    /// <summary>
    /// Stack In Date
    /// </summary>
    public string? Stackindate { get; set; }

    /// <summary>
    /// IMDG Class CD
    /// </summary>
    public string? Imdgcd { get; set; }

    /// <summary>
    /// IMDG UN Number
    /// </summary>
    public string? Imdgunno { get; set; }

    /// <summary>
    /// Reefer Work Temp.
    /// </summary>
    public string? Reeferworktemp { get; set; }

    /// <summary>
    /// Reefer Temp.
    /// </summary>
    public string? Reefertemp { get; set; }

    /// <summary>
    /// Reefer Temp. Unit
    /// </summary>
    public string? Reefertempunit { get; set; }

    /// <summary>
    /// Reefer Plug Status
    /// </summary>
    public string? Reeferplugstatus { get; set; }

    /// <summary>
    /// Interface Sequence Number
    /// </summary>
    public string? Sendseqnumber { get; set; }

    /// <summary>
    /// Interface Send Timekey (14자리)
    /// </summary>
    public string? Sendtimekey { get; set; }

    /// <summary>
    /// Interaface InOut Flag
    /// </summary>
    public string? Sendinoutflag { get; set; }

    /// <summary>
    /// 마지막수정일시
    /// </summary>
    public DateTime? Lastupdatetime { get; set; }

    /// <summary>
    /// 마지막수정자
    /// </summary>
    public string? Lastupdateuserid { get; set; }
}
