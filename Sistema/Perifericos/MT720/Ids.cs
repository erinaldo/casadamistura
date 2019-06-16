using System;

namespace Perifericos {
    public class Ids
    {

        public static int IDvLive           = 0x0001;
        public static int IDwGetIndentify   = 0x0003;
        
        //TECLADO
        public static int IDvSetEnableKey   = 0x000F;
        public static int IDbGetEnableKey   = 0x0011;
        public static int IDcGetCharTerm    = 0x001D;
    

        //LCD
        public static int IDvBackSpace      = 0x0021;
        public static int IDvCarRet         = 0x0023;
        public static int IDvLineFeed       = 0x0025;
        public static int IDvFormFeed       = 0x0027;
        public static int IDvGoToXY         = 0x0029;
        public static int IDvDispStr        = 0x0033;
        public static int IDvDispCh         = 0x0035;
        
        //SERIAL
        public static int IDvSetEnableSerial = 0x0039;
        public static int IDbGetBinSerial    = 0x003D;
        public static int IDbSendBinSerial   = 0x003F;
        public static int IDbSetSetupSerial  = 0x0041;
        public static int IDvGetSetupSerial  = 0x0044;
    }
}

