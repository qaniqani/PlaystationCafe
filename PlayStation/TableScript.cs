using System;

namespace PlayStation
{
    public static class TableScript
    {
        public static string CreateDatabase()
        {
            var dal = new Data.DataAccessLayer();
            if (!Data.DataAccessLayer.ConnectionTest()) return "Create Database - SQL Bağlantısı sağlanamadı.";

            if (
                Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsDatabase("PLAYSTATION"),
                    System.Data.CommandType.Text, null)) != 0) return "";

            string result;
            const string query = "CREATE DATABASE PLAYSTATION CHARACTER SET latin5 COLLATE latin5_turkish_ci";
            dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
            return result;
        }

        public static string CreateTables()
        {
            var dal = new Data.DataAccessLayer();
            if (Data.DataAccessLayer.ConnectionTest())
            {
                var result = string.Empty;
                const string dBname = "PLAYSTATION";

                #region //ADDITIONS
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "additions"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `additions` (
                                  `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                  `MACHINEREF` int(11) DEFAULT NULL,
                                  `MACHINENR` int(11) DEFAULT NULL,
                                  `MACHINENAME` varchar(50) DEFAULT NULL,
                                  `PRODUCTREF` int(11) DEFAULT NULL,
                                  `PRODUCTNAME` varchar(50) DEFAULT NULL,
                                  `PRODUCTUNITS` int(11) DEFAULT NULL,
                                  `PRODUCTSPRICES` decimal(16,2) DEFAULT NULL,
                                  `NOTE` varchar(500) DEFAULT NULL,
                                  `DATETIME` datetime DEFAULT NULL,
                                  `STATUS` int(11) DEFAULT NULL,
                                  PRIMARY KEY (`LREF`)
                                ) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //CALCULATES
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "calculates"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `calculates` (
                                  `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                  `MACHINEREF` int(11) DEFAULT NULL,
                                  `TARRIFSREF` int(11) DEFAULT NULL,
                                  `MACHINENR` int(11) DEFAULT NULL,
                                  `MACHINENAME` varchar(50) DEFAULT NULL,
                                  `STARTDATETIME` datetime DEFAULT NULL,
                                  `STARTENDDATETIME` datetime DEFAULT NULL,
                                  `USEDTIME` datetime DEFAULT NULL,
                                  `DETAILS` varchar(500) DEFAULT NULL,
                                  `MACHINETOTAL` decimal(16,2) DEFAULT NULL,
                                  `ADDITIONNAME` varchar(50) DEFAULT NULL,
                                  `ADDITIONUNIT` int(11) DEFAULT NULL,
                                  `ADDITIONTOTAL` decimal(16,2) DEFAULT NULL,
                                  `CANCELREASON` varchar(1500) DEFAULT NULL,
                                  `MACHINECLOSESTATUS` int(11) DEFAULT NULL,
                                  `STATUS` int(11) DEFAULT NULL,
                                  `DATETIME` datetime DEFAULT NULL,
                                  `CREATEUSER` int(11) DEFAULT NULL,
                                  `MODIFIEDUSER` int(11) DEFAULT NULL,
                                  `MODIFIEDDATETIME` datetime DEFAULT NULL,
                                  PRIMARY KEY (`LREF`)
                                ) ENGINE=InnoDB AUTO_INCREMENT=343 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //DEBTLIST
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "debtlist"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `debtlist` (
                                    `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                    `NAME` varchar(50) DEFAULT NULL,
                                    `GSMNR` varchar(50) DEFAULT NULL,
                                    `DEBTAMOUNT` decimal(16,2) DEFAULT NULL,
                                    `DEBTDATE` datetime DEFAULT NULL,
                                    `CREATEDATE` datetime DEFAULT NULL,
                                    PRIMARY KEY (`LREF`)
                                ) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //LICENCE
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "licence"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `licence` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `PARAMS` text,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //LOGS
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "logs"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `logs` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `TRANSACTIONTYPE` int(11) DEFAULT NULL,
                                      `TRANSACTIONNAME` varchar(50) DEFAULT NULL,
                                      `TRANSACTIONDETAIL` varchar(1500) DEFAULT NULL,
                                      `DATETIME` datetime DEFAULT NULL,
                                      `CREATEUSER` int(11) DEFAULT '0',
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=837 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //MACHINE
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "machine"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `machine` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `NR` int(11) DEFAULT NULL,
                                      `BYTENAME` varchar(10) DEFAULT NULL,
                                      `BYTENR` int(11) DEFAULT NULL,
                                      `NAME` varchar(50) DEFAULT NULL,
                                      `STARTDATETIME` datetime DEFAULT NULL,
                                      `HOLDDATETIME` datetime DEFAULT NULL,
                                      `HOLDENDDATETIME` datetime DEFAULT NULL,
                                      `ENDDATETIME` datetime DEFAULT NULL,
                                      `MACHINESTATUS` int(11) DEFAULT NULL,
                                      `TARRIFSREF` int(11) DEFAULT NULL,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //NOTES
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "notes"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `notes` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `NOTE` text,
                                      `CREATEDATE` datetime DEFAULT NULL,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //PRODUCTS
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "products"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `products` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `NAME` varchar(50) DEFAULT NULL,
                                      `STOCK` int(11) DEFAULT NULL,
                                      `UNITPRICE` decimal(16,2) DEFAULT NULL,
                                      `DATETIME` datetime DEFAULT NULL,
                                      `CREATEUSER` int(11) DEFAULT NULL,
                                      `MODIFIEDUSER` int(11) DEFAULT NULL,
                                      `MODIFIEDDATETIME` datetime DEFAULT NULL,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //SETTINGS
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "settings"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `settings` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `VERSION` int(11) DEFAULT NULL,
                                      `MACHINECOUNT` int(11) DEFAULT NULL,
                                      `MACHINETAGNAME` varchar(50) DEFAULT NULL,
                                      `MACHINESTATUS` bit(1) DEFAULT NULL,
                                      `MINIMUMTIME` datetime DEFAULT NULL,
                                      `MINIMUMTOTAL` decimal(16,2) DEFAULT NULL,
                                      `ROUNDINGPRICE` decimal(16,2) DEFAULT NULL,
                                      `DATETIME` datetime DEFAULT NULL,
                                      `ACTIVE` bit(1) DEFAULT NULL,
                                      `CREATEUSER` int(11) DEFAULT NULL,
                                      `MODIFIEDUSER` int(11) DEFAULT NULL,
                                      `MODIFIEDDATETIME` datetime DEFAULT NULL,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //TARRIFS
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "tarrifs"), System.Data.CommandType.Text, null)) == 0)
                {
                    const string query = @"CREATE TABLE `tarrifs` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `NAME` varchar(50) DEFAULT NULL,
                                      `HOURPRICE` decimal(16,10) DEFAULT NULL,
                                      `MINUTEPRICE` decimal(16,10) DEFAULT NULL,
                                      `SELECTED` bit(1) DEFAULT NULL,
                                      `ACTIVE` bit(1) DEFAULT NULL,
                                      `DATETIME` datetime DEFAULT NULL,
                                      `CREATEUSER` int(11) DEFAULT NULL,
                                      `MODIFIEDUSER` int(11) DEFAULT NULL,
                                      `MODIFIEDDATETIME` datetime DEFAULT NULL,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }

                #endregion

                #region //USERS
                if (Convert.ToInt32(dal.GetCell(Functions.Function.IfExistsTables(dBname, "users"), System.Data.CommandType.Text, null)) == 0)
                {
                    var query = @"CREATE TABLE `users` (
                                      `LREF` int(11) NOT NULL AUTO_INCREMENT,
                                      `TYPE` int(11) DEFAULT '0',
                                      `NAME` varchar(50) DEFAULT NULL,
                                      `SURNAME` varchar(50) DEFAULT NULL,
                                      `USERNAME` varchar(50) DEFAULT NULL,
                                      `PASSWORD` varchar(500) DEFAULT NULL,
                                      `CHANGESTARTTIME` bit(1) DEFAULT NULL,
                                      `DATETIME` datetime DEFAULT NULL,
                                      `ACTIVE` bit(1) DEFAULT NULL,
                                      PRIMARY KEY (`LREF`)
                                    ) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin5;";
                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);

                    query = @"INSERT INTO USERS(TYPE,NAME,SURNAME,USERNAME,PASSWORD,CHANGESTARTTIME,DATETIME,ACTIVE)
                            VALUES ('1','admin','admin','admin','uIsHXDPpOPA=',1,'2014-01-01',1);" + Environment.NewLine;

                    query += @"INSERT INTO TARRIFS(NAME,HOURPRICE,MINUTEPRICE,SELECTED,ACTIVE,DATETIME,CREATEUSER,MODIFIEDUSER, MODIFIEDDATETIME) VALUES ('Hafta İçi Tarifesi',2,0.033333333,1,1,'2014-01-01',0,0,'2014-01-01');" + Environment.NewLine;

                    query += @"INSERT INTO SETTINGS(VERSION,MACHINECOUNT,MACHINETAGNAME,MACHINESTATUS,MINIMUMTIME,MINIMUMTOTAL, ROUNDINGPRICE,DATETIME,ACTIVE, CREATEUSER, MODIFIEDUSER, MODIFIEDDATETIME) VALUES (1,0,'Play Station',0,'2014-01-01',0.25,0.25, '2014-01-01', 1,0,0,'2014-01-01');";

                    dal.FbExecute(query, System.Data.CommandType.Text, null, out result);
                }
                #endregion
                return result;
            }
            else
                return "Tables - SQL Bağlantısı sağlanamadı.";
        }

        public static string AlterTables()
        {
            var dal = new Data.DataAccessLayer();
            var result = string.Empty;
            if (!Data.DataAccessLayer.ConnectionTest()) return result;

            const string dBname = "PLAYSTATION";

            if (
                Convert.ToInt32(
                    dal.GetCell(Functions.Function.IfExistsColumns(dBname, "calculates", "MACHINECLOSESTATUS"),
                        System.Data.CommandType.Text, null)) != 0) return result;

            const string query = @"ALTER TABLE `calculates` ADD `MACHINECLOSESTATUS` int(11) DEFAULT NULL";

            dal.FbExecute(query, System.Data.CommandType.Text, null, out result);

            return result;
        }
    }
}