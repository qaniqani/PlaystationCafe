using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenelIslem
/// </summary>
public static class GenelIslem
{
    public static int ToInt32(this object sayi)
    {
        try
        {
            if (sayi == null) throw new Exception();
            int x = Convert.ToInt32(sayi);
            return x;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static string NullControl(this object kelime)
    {
        string deger = "";
        try
        {
            deger = kelime.ToString();
        }
        catch (Exception)
        {
            return deger;
        }
        return deger;
    }
    public static string ToMultiLineString(this string str, int adet)
    {
        string yeni = "";
        for (int i = 0; i < str.Length; i += adet)
        {
            if (i > 0)
                yeni += "<br/>";
            if (i + adet < str.Length)
                yeni += str.Substring(i, adet);
            else
                yeni += str.Substring(i);
        }
        return yeni;
    }
    public static string SubstringGetir(this string metin, int uzunluk)
    {
        if (metin.Length < uzunluk)
            return metin;
        else
            return metin.Substring(0, uzunluk) + "..";
    }
    public static string ReplaceYap(this string metin, string kelime1, string kelime2, string kelime3, string kelime4)
    {
        return metin.Replace(kelime1, "").Replace(kelime2, "").Replace(kelime3, "").Replace(kelime4, "").ToString();
    }
    public static bool IsDate(this string tarih)
    {
        try
        {
            if (tarih == null) throw new Exception();
            Convert.ToDateTime(tarih);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}