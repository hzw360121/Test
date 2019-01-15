using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodLuck
{
    public class Config
    {
        public static string datafile { get; set; }
    }
    public class ConfigHelper
    {
        public static void SetValue(string AppKey, string AppValue)
        {
            #region 
            //System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            //xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            //System.Xml.XmlNode xNode;
            //System.Xml.XmlElement xElem1;
            //System.Xml.XmlElement xElem2;
            //xNode = xDoc.SelectSingleNode("//appSettings");

            //xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            //if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
            //else
            //{
            //    xElem2 = xDoc.CreateElement("add");
            //    xElem2.SetAttribute("key", AppKey);
            //    xElem2.SetAttribute("value", AppValue);
            //    xNode.AppendChild(xElem2);
            //}
            //xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            #endregion

            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            ////根据Key读取元素的Value;
            //string value = config.AppSettings.Settings["Key"].Value
            ////删除元素
            //config.AppSettings.Settings.Remove("name");
            //写入或修改元素的Value
            if (config.AppSettings.Settings[AppKey] != null)
                config.AppSettings.Settings[AppKey].Value = AppValue;//修改
            else
                config.AppSettings.Settings.Add(AppKey, AppValue);//添加节点

            config.Save();//保存修改
            
        }

        public static string GetValue(string AppKey)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            if (config.AppSettings.Settings[AppKey] != null)
                return config.AppSettings.Settings[AppKey].Value;
            else
                return string.Empty;
        }

        /// <summary>
        /// 刷新，否则程序读取的还是之前的值（可能已装入内存）
        /// </summary>
        /// <param name="appSettings">节点名称</param>
        public static void RefreshSection(string appSettings)
        {
            ConfigurationManager.RefreshSection(appSettings);
        }

    }
}
