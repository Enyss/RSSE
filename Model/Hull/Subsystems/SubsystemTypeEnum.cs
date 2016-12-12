using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public enum SubsystemTypeEnum
    {
        AccessoriesManager,
        AttachementsManager,
        BMS,
        CameraManager,
        COMM,
        CSSM,
        ECS,
        FCM,
        Legacy,
        LENR,
        LSS,
        MES,
        MFD,
        MTS,
        NAS,
        RCM,
        RCS,
        RMS,
        TMS,
        VMS,
    }

    public static class SubsystemTypeEnumExtensions
    {
        public static string ToNiceString(this SubsystemTypeEnum me)
        {
            switch (me)
            {
                case SubsystemTypeEnum.AccessoriesManager:
                    return "Accessories manager";
                case SubsystemTypeEnum.AttachementsManager:
                    return "Attachements manager";
                case SubsystemTypeEnum.BMS:
                    return "BMS";
                case SubsystemTypeEnum.CameraManager:
                    return "Camera manager";
                case SubsystemTypeEnum.COMM:
                    return "COMM";
                case SubsystemTypeEnum.CSSM:
                    return "CSSM";
                case SubsystemTypeEnum.ECS:
                    return "ECS";
                case SubsystemTypeEnum.FCM:
                    return "FCM";
                case SubsystemTypeEnum.Legacy:
                    return "Legacy";
                case SubsystemTypeEnum.LENR:
                    return "LENR";
                case SubsystemTypeEnum.LSS:
                    return "LSS";
                case SubsystemTypeEnum.MES:
                    return "MES";
                case SubsystemTypeEnum.MFD:
                    return "MFD";
                case SubsystemTypeEnum.MTS:
                    return "MTS";
                case SubsystemTypeEnum.NAS:
                    return "NAS";
                case SubsystemTypeEnum.RCM:
                    return "RCM";
                case SubsystemTypeEnum.RCS:
                    return "RCS";
                case SubsystemTypeEnum.RMS:
                    return "RMS";
                case SubsystemTypeEnum.TMS:
                    return "RMS";
                case SubsystemTypeEnum.VMS:
                    return "VMS";

                default:
                    return "Unknown type";
            }
        }
    }
}
