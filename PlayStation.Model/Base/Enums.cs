namespace PlayStation.Model.Base
{
    public enum Active
    {
        Aktif = 1,
        Pasif = 0
    }

    public enum Status
    {
        Acik = 1,
        Kapali = 0
    }

    public enum TimeChange
    {
        SureliyeCevir = 2,
        SureVer = 1,
        SureliAc = 0
    }

    public enum AdditionStatus
    {
        Odenmedi = 0,
        Odendi = 1,
        IptalEdildi = 2,
        BaskaHesabaAktarildi = 3,
        HesapKapatildi = 4
    }

    public enum TransactionType
    {
        Ekle = 0,
        Duzenle = 1,
        Goruntule = 2,
        Sil = 3
    }

    public enum MachineType
    {
        SureliAcik = 2,
        SuresizAcik = 1,
        OzelAcik = 3,
        Kapali = 0,
        Durduruldu = 4,
        IptalEdildi = 5
    }

    public enum AdminAuth
    {
        Admin = 0,
        AdminDegil = 1
    }

    public enum MachineConvertTime
    {
        Sureli = 0,
        Suresiz = 1
    }

    public enum AdditionFormType
    {
        MakineAdisyonlari = 0,
        HesapAdisyonlari = 1
    }
}