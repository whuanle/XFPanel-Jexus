using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFPanelJexus.Web.Models.JexusModel;

namespace XFPanelJexus.Web.Models.Service
{
    /// <summary>
    /// 使输入的表单内容生成 Shell 内容
    /// </summary>
    public class JexusSH
    {
        List<string> shList = new List<string>();
        private JexusOptions _jexusOptions;
        public JexusSH(JexusOptions jexusOptions)
        {
            _jexusOptions = jexusOptions;
        }

        /// <summary>
        /// 构建 Shell 内容
        /// </summary>
        /// <returns></returns>
        public async Task JexusBuild()
        {
            await Task.Run(() =>
            {
                JexusOneSH();
                JexusWebSH();
                JexusModelSH();
            });


        }
        public void JexusOneSH()
        {
            if (_jexusOptions.JexusOne.hosts == null || _jexusOptions.JexusOne.hosts == string.Empty)
            { }
            else shList.Add("hosts=" + _jexusOptions.JexusOne.hosts);

            shList.Add("ports=" + _jexusOptions.JexusOne.ports);
            shList.Add(@"root=/ " + _jexusOptions.JexusOne.root);
        }
        public void JexusWebSH()
        {
            shList.Add("AppHost={");
            shList.Add(@"CmdLine=dotnet " + _jexusOptions.JexusWeb.CmdLine + ";");
            shList.Add(@"AppRoot=" + _jexusOptions.JexusOne.root + ";");
            shList.Add(@"port=" + _jexusOptions.JexusWeb.Port + ";");
            shList.Add("}");
        }
        public void JexusModelSH()
        {
            if (_jexusOptions.JexusModel.reproxy == null || _jexusOptions.JexusModel.reproxy == string.Empty)
            { }
            else shList.Add("reproxy=" + _jexusOptions.JexusModel.reproxy);

            if (_jexusOptions.JexusModel.rewrite == null || _jexusOptions.JexusModel.rewrite == string.Empty)
            { }
            else shList.Add("rewrite=" + _jexusOptions.JexusModel.rewrite);

            if (_jexusOptions.JexusModel.nolog == null || _jexusOptions.JexusModel.nolog == string.Empty)
            { }
            else shList.Add("nolog=" + _jexusOptions.JexusModel.nolog);

            if (_jexusOptions.JexusModel.usegzip == null || _jexusOptions.JexusModel.usegzip == string.Empty)
            { }
            else shList.Add("usegzip=" + _jexusOptions.JexusModel.usegzip);

            if (_jexusOptions.JexusModel.allowfrom == null || _jexusOptions.JexusModel.allowfrom == string.Empty)
            { }
            else shList.Add("allowfrom=" + _jexusOptions.JexusModel.allowfrom);

            if (_jexusOptions.JexusModel.denyfrom == null || _jexusOptions.JexusModel.denyfrom == string.Empty)
            { }
            else shList.Add("denyfrom=" + _jexusOptions.JexusModel.denyfrom);

            if (_jexusOptions.JexusModel.checkquery == null || _jexusOptions.JexusModel.checkquery == string.Empty)
            { }
            else shList.Add("checkquery=" + _jexusOptions.JexusModel.checkquery);
        }

        public List<string> Re()
        {
            return shList;
        }
    }
}
