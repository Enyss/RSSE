using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;



namespace RSSE
{
    public class SubsystemsManagerTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elem = container as FrameworkElement;
            if (elem == null)
            {
                return null;
            }
            if (item == null || !(item is SubsystemViewModel))
            {
                return elem.FindResource("NothingTemplate") as DataTemplate;
            }

            switch ((item as SubsystemViewModel).SystemType)
            {
                case SubsystemTypeEnum.AccessoriesManager:
                    return elem.FindResource("AccessoriesManagerTemplate") as DataTemplate;
                case SubsystemTypeEnum.AttachementsManager:
                    return elem.FindResource("AttachementsManagerTemplate") as DataTemplate;
                case SubsystemTypeEnum.BMS: 
                    return elem.FindResource("BMSTemplate") as DataTemplate;
                case SubsystemTypeEnum.CameraManager:
                    return elem.FindResource("CameraManagerTemplate") as DataTemplate;
                case SubsystemTypeEnum.COMM:
                    return elem.FindResource("COMMTemplate") as DataTemplate;
                case SubsystemTypeEnum.CSSM:
                    return elem.FindResource("CSSMTemplate") as DataTemplate;
                case SubsystemTypeEnum.ECS:
                    return elem.FindResource("ECSTemplate") as DataTemplate;
                case SubsystemTypeEnum.FCM:
                    return elem.FindResource("FCMTemplate") as DataTemplate;
                case SubsystemTypeEnum.LENR:
                    return elem.FindResource("LENRTemplate") as DataTemplate;
                case SubsystemTypeEnum.LSS:
                    return elem.FindResource("LSSTemplate") as DataTemplate;
                case SubsystemTypeEnum.MES:
                    return elem.FindResource("MESTemplate") as DataTemplate;
                case SubsystemTypeEnum.MFD:
                    return elem.FindResource("MFDTemplate") as DataTemplate;
                case SubsystemTypeEnum.MTS:
                    return elem.FindResource("MTSTemplate") as DataTemplate;
                case SubsystemTypeEnum.NAS:
                    return elem.FindResource("NASTemplate") as DataTemplate;
                case SubsystemTypeEnum.RCM:
                    return elem.FindResource("RCMTemplate") as DataTemplate;
                case SubsystemTypeEnum.RCS:
                    return elem.FindResource("RCSTemplate") as DataTemplate;
                case SubsystemTypeEnum.RMS:
                    return elem.FindResource("RMSTemplate") as DataTemplate;
                case SubsystemTypeEnum.TMS:
                    return elem.FindResource("TMSTemplate") as DataTemplate;
                case SubsystemTypeEnum.VMS:
                    return elem.FindResource("VMSTemplate") as DataTemplate;
            }
            throw new ApplicationException();
        }
    }
}
