
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Perifericos
{
    class pmtger
    {
        public structs estruturas = new structs();
                
        [DllImport("pmtg.dll", EntryPoint = "mt_startserver")]
        public static extern int mt_startserver(IntPtr hWindow, int conecmsg, int commumsg);

        [DllImport("pmtg.dll", EntryPoint="mt_finishserver")]
        public static extern void mt_finishserver();

        [DllImport("pmtg.dll", EntryPoint = "mt_getkey")]
        public static extern int mt_getkey(int ID,byte[] buf);

        [DllImport("pmtg.dll", EntryPoint = "mt_getserial")]
        public static extern int mt_getserial(int ID, int[] sercom, byte[] buf);

        [DllImport("pmtg.dll", EntryPoint = "mt_setenablekey")]
        public static extern int mt_setenablekey(int ID, string str);

        [DllImport("pmtg.dll", EntryPoint = "mt_connectlist")]
        public static extern int[] mt_connectlist();
        
        [DllImport("pmtg.dll", EntryPoint = "mt_sendlive")]
        public static extern int mt_sendlive(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_dispstr")]
        public static extern int mt_dispstr(int ID, string str);

        [DllImport("pmtg.dll", EntryPoint = "mt_ipfromid")]
        public static extern string mt_ipfromid(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_dispch")]
        public static extern int mt_dispch(int ID, char ch);

        [DllImport("pmtg.dll", EntryPoint = "mt_backspace")]
        public static extern int mt_backspace(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_formfeed")]
        public static extern int mt_formfeed(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_linefeed")]
        public static extern int mt_linefeed(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_carret")]
        public static extern int mt_carret(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_gotoxy")]
        public static extern int mt_gotoxy(int ID, int lin, int col);

        [DllImport("pmtg.dll", EntryPoint = "mt_setenablekey")]
        public static extern int mt_setenablekey( int ID, bool value );

        [DllImport("pmtg.dll", EntryPoint = "mt_getenablekey")]
        public static extern int mt_getenablekey(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_reqconfigserial")]
        public static extern int mt_reqconfigserial(int ID,byte com);

        [DllImport("pmtg.dll", EntryPoint = "mt_sendconfigserial")]
        public static extern int mt_sendconfigserial(int ID, ref structs.Arg_Com_SetupSerial config);

        [DllImport("pmtg.dll", EntryPoint = "mt_getconfigserial")]
        public static extern int mt_getconfigserial(int ID, ref structs.Arg_Com_SetupSerial config);
        
        [DllImport("pmtg.dll", EntryPoint = "mt_restart")]
        public static extern int mt_restart(int ID);

        [DllImport("pmtg.dll", EntryPoint = "mt_setenableserial")]
        public static extern int mt_setenableserial(int ID,byte com, int OnOff);

        [DllImport("pmtg.dll", EntryPoint = "mt_sendbinserial")]
        public static extern int mt_sendbinserial(int ID,byte com, byte[] Bin, byte tam);

        [DllImport("pmtg.dll", EntryPoint = "mt_dispclrln")]
        public static extern int mt_dispclrln(int ID, int lin);

       
        

    }
}
 