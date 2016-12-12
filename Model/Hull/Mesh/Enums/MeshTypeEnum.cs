using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE
{
    public enum MeshTypeEnum
    {
        NONE,
        SWITCH,
        HULLexterior,
        HULLinterior,
        INSTALL,
        PICKUP,
        CARRYABLE,
        LANDINGGEAR,
        LANDINGPAD,
        DECAL,
        PIVOT,
        TRIGGER,
        LIGHT,
        ELEVATOR,
        GANGWAY,
        HATCH,
        SEAT,
        EQUIPexterior,
        LADDERinterior,
        SEATrestraint,
        SEATconsole,
    }

    public static class MeshTypeEnumExtensions
    {
        static Bictionary<MeshTypeEnum, string> table = new Bictionary<MeshTypeEnum, string>()
        {
            { MeshTypeEnum.NONE, "NONE" },
            { MeshTypeEnum.SWITCH, "SWITCH" },
            { MeshTypeEnum.HULLexterior, "HULLexterior" },
            { MeshTypeEnum.HULLinterior, "HULLinterior" },
            { MeshTypeEnum.INSTALL, "INSTALL" },
            { MeshTypeEnum.PICKUP, "PICKUP" },
            { MeshTypeEnum.CARRYABLE,"CARRYABLE" },
            { MeshTypeEnum.LANDINGGEAR,"LANDINGGEAR" },
            { MeshTypeEnum.LANDINGPAD,"LANDINGPAD" },
            { MeshTypeEnum.DECAL,"DECAL" },
            { MeshTypeEnum.PIVOT,"PIVOT" },
            { MeshTypeEnum.TRIGGER,"TRIGGER" },
            { MeshTypeEnum.LIGHT,"LIGHT" },
            { MeshTypeEnum.ELEVATOR,"ELEVATOR" },
            { MeshTypeEnum.GANGWAY,"GANGWAY" },
            { MeshTypeEnum.HATCH,"HATCH" },
            { MeshTypeEnum.SEAT,"SEAT" },
            { MeshTypeEnum.EQUIPexterior,"EQUIPexterior" },
            { MeshTypeEnum.LADDERinterior,"LADDERinterior" },
            { MeshTypeEnum.SEATrestraint,"SEATrestraint" },
            { MeshTypeEnum.SEATconsole,"SEATconsole" },
        };

        public static MeshTypeEnum TypeFromString(this string key)
        {
            return table[key];
        }

        public static string StringFromType(this MeshTypeEnum key)
        {
            return table[key];
        }
    }
}
