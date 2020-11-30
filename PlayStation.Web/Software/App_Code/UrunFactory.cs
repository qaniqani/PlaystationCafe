using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InPlusYonetimModel;

/// <summary>
/// Summary description for UrunFactory
/// </summary>
public class UrunFactory
{
    
    public URUN UrunDetayGetir(YonetimEntities db,int id)
    {
        URUN u = db.URUNs.FirstOrDefault(a => a.URUNID == id);
        return u;
    }

	public UrunFactory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}