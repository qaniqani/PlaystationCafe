using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Licence
/// </summary>
public class LicenceDetail
{
    //public string FirmCount { get; set; }
    //public string UserCount { get; set; }
    //public string LogoEntegrationFirmCount { get; set; }
    //public string LicenceDayCount { get; set; }
    //public string HashCode { get; set; }
    //public string Date_ { get; set; }
    //public string ExpiredDate { get; set; }
    //public string LicenceEndDate { get; set; }
    //public string ResultMessage { get; set; }
    //public bool ReturnResult { get; set; }

    public string LicenceKey { get; set; }
    public int UserCount { get; set; }
    public DateTime LicenceStartDate { get; set; }
    public DateTime LicenceEndDate { get; set; }
    public DateTime BeforeCheckDate { get; set; }
    public int UpdateDayCount { get; set; }
    public bool Demo { get; set; }
    public bool Active { get; set; }
    public string ResultMessage { get; set; }
    public bool ResultCode { get; set; }

    public LicenceDetail()
	{
        this.Active = false;
        this.BeforeCheckDate = DateTime.Now;
        this.Demo = false;
        this.LicenceEndDate = DateTime.Now;
        this.LicenceStartDate = DateTime.Now;
        this.ResultCode = false;
        this.ResultMessage = string.Empty;
        this.UpdateDayCount = 1;
        this.UserCount = 1;
	}
}