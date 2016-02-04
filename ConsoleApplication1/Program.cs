/*
 * bigken edit
 *
 *
 */

using System;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("oIYQbt6ArIOlvYbWuCIri9VRVM_M");

            MasterRoad.Core.PerformanceRecorder.Invoke(10000,
                () =>
                {
                    int k = "{rn,Para,:{rn,AId,:7997,rn,Subscribe,:true,rn,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,rn,unionid,:,,,rn,Nickname,:,杨长杰,,rn,Sex,:1,rn,City,:,宿州,,rn,Country,:,中国,,rn,Province,:,安徽,,rn,Language,:,zh_CN,,rn,Mobile,:,,,rn,EMail,:,,,rn,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Subscribe_time,:,2015-05-08T14:41:53+08:00,,rn,Channel,:0,rn,ChannelName,:,,,rn,MarkName,:,,,rn,Mark,:,,,rn,Address,:,,,rn,DAgentId,:0,rn,AgentId,:0,rn,AgentName,:null,rn,EmployeesId,:0,rn,EmployeesName,:null,rn,VId,:0,rn,VOpenid,:null,rn,QrCode,:0,rn,IsSDP,:truern},rn,AId,:0,rn,UId,:nullrn},},返回:{,Data,:{,Id,:11372526,,AId,:7997,,Subscribe,:true,,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,,unionid,:,,,,Nickname,:,杨长杰,,,Sex,:1,,City,:,宿州,,,Country,:,中国,,,Province,:,安徽,,,Language,:,zh_CN,,,Mobile,:,,,,EMail,:,,,,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Subscribe_time,:,2015-05-0814:41:53,,,GUID,:null,,Channel,:0,,ChannelName,:,,,,MarkName,:,,,,Mark,:,,,,Address,:,,,,AgentId,:0,,QrCode,:0,,EmployeesId,:0,,VshopOrderCount,:0,,VshopPaidOrderCount,:0,,VshopAmount,:0.0,,VId,:0,,IdentityType,:0,,IdentityId,:0,,IdentityName,:null,,FromType,:0}".IndexOf("{");
                },
                () =>
                {
                    int k = "{rn,Para,:{rn,AId,:7997,rn,Subscribe,:true,rn,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,rn,unionid,:,,,rn,Nickname,:,杨长杰,,rn,Sex,:1,rn,City,:,宿州,,rn,Country,:,中国,,rn,Province,:,安徽,,rn,Language,:,zh_CN,,rn,Mobile,:,,,rn,EMail,:,,,rn,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Subscribe_time,:,2015-05-08T14:41:53+08:00,,rn,Channel,:0,rn,ChannelName,:,,,rn,MarkName,:,,,rn,Mark,:,,,rn,Address,:,,,rn,DAgentId,:0,rn,AgentId,:0,rn,AgentName,:null,rn,EmployeesId,:0,rn,EmployeesName,:null,rn,VId,:0,rn,VOpenid,:null,rn,QrCode,:0,rn,IsSDP,:truern},rn,AId,:0,rn,UId,:nullrn},},返回:{,Data,:{,Id,:11372526,,AId,:7997,,Subscribe,:true,,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,,unionid,:,,,,Nickname,:,杨长杰,,,Sex,:1,,City,:,宿州,,,Country,:,中国,,,Province,:,安徽,,,Language,:,zh_CN,,,Mobile,:,,,,EMail,:,,,,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Subscribe_time,:,2015-05-0814:41:53,,,GUID,:null,,Channel,:0,,ChannelName,:,,,,MarkName,:,,,,Mark,:,,,,Address,:,,,,AgentId,:0,,QrCode,:0,,EmployeesId,:0,,VshopOrderCount,:0,,VshopPaidOrderCount,:0,,VshopAmount,:0.0,,VId,:0,,IdentityType,:0,,IdentityId,:0,,IdentityName,:null,,FromType,:0}".IndexOf("安徽");
                },
                () =>
                {
                    int k = "{rn,Para,:{rn,AId,:7997,rn,Subscribe,:true,rn,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,rn,unionid,:,,,rn,Nickname,:,杨长杰,,rn,Sex,:1,rn,City,:,宿州,,rn,Country,:,中国,,rn,Province,:,安徽,,rn,Language,:,zh_CN,,rn,Mobile,:,,,rn,EMail,:,,,rn,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Subscribe_time,:,2015-05-08T14:41:53+08:00,,rn,Channel,:0,rn,ChannelName,:,,,rn,MarkName,:,,,rn,Mark,:,,,rn,Address,:,,,rn,DAgentId,:0,rn,AgentId,:0,rn,AgentName,:null,rn,EmployeesId,:0,rn,EmployeesName,:null,rn,VId,:0,rn,VOpenid,:null,rn,QrCode,:0,rn,IsSDP,:truern},rn,AId,:0,rn,UId,:nullrn},},返回:{,Data,:{,Id,:11372526,,AId,:7997,,Subscribe,:true,,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,,unionid,:,,,,Nickname,:,杨长杰,,,Sex,:1,,City,:,宿州,,,Country,:,中国,,,Province,:,安徽,,,Language,:,zh_CN,,,Mobile,:,,,,EMail,:,,,,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Subscribe_time,:,2015-05-0814:41:53,,,GUID,:null,,Channel,:0,,ChannelName,:,,,,MarkName,:,,,,Mark,:,,,,Address,:,,,,AgentId,:0,,QrCode,:0,,EmployeesId,:0,,VshopOrderCount,:0,,VshopPaidOrderCount,:0,,VshopAmount,:0.0,,VId,:0,,IdentityType,:0,,IdentityId,:0,,IdentityName,:null,,FromType,:0}".IndexOf("oIYQbt6ArIOlvYbWuCIri9VRVM_M");
                },
                () =>
                {
                    var ff = r.Match("{rn,Para,:{rn,AId,:7997,rn,Subscribe,:true,rn,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,rn,unionid,:,,,rn,Nickname,:,杨长杰,,rn,Sex,:1,rn,City,:,宿州,,rn,Country,:,中国,,rn,Province,:,安徽,,rn,Language,:,zh_CN,,rn,Mobile,:,,,rn,EMail,:,,,rn,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,rn,Subscribe_time,:,2015-05-08T14:41:53+08:00,,rn,Channel,:0,rn,ChannelName,:,,,rn,MarkName,:,,,rn,Mark,:,,,rn,Address,:,,,rn,DAgentId,:0,rn,AgentId,:0,rn,AgentName,:null,rn,EmployeesId,:0,rn,EmployeesName,:null,rn,VId,:0,rn,VOpenid,:null,rn,QrCode,:0,rn,IsSDP,:truern},rn,AId,:0,rn,UId,:nullrn},},返回:{,Data,:{,Id,:11372526,,AId,:7997,,Subscribe,:true,,Openid,:,oIYQbt6ArIOlvYbWuCIri9VRVM_M,,,unionid,:,,,,Nickname,:,杨长杰,,,Sex,:1,,City,:,宿州,,,Country,:,中国,,,Province,:,安徽,,,Language,:,zh_CN,,,Mobile,:,,,,EMail,:,,,,WeiXinHeadimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Headimgurl,:,http://wx.qlogo.cn/mmopen/4a6RFYw6ryzelDIGkflRH0AE55WrTQicbs3URA7IRUsRB8Uib15KXxoRMLyw1ucqemnlUZ7fUVfkMVTToCY8ve9Ho8evuouyQ1/0,,,Subscribe_time,:,2015-05-0814:41:53,,,GUID,:null,,Channel,:0,,ChannelName,:,,,,MarkName,:,,,,Mark,:,,,,Address,:,,,,AgentId,:0,,QrCode,:0,,EmployeesId,:0,,VshopOrderCount,:0,,VshopPaidOrderCount,:0,,VshopAmount,:0.0,,VId,:0,,IdentityType,:0,,IdentityId,:0,,IdentityName,:null,,FromType,:0}");
                });

            Console.Read();

            LamdaExpressionTest.Test();
            Console.Read();

            DapperTest dapperTest = new DapperTest();
            dapperTest.TestQuery(50000);
            Console.Read();

            string s = "";
            Console.WriteLine(s.Contains(string.Empty));
            Console.Read();

            string[] sa = new string[] { "", "1", "1", "2" };
            var group = sa.Where(x => x != null && x.Length > 0).GroupBy(x => x);
            foreach (var item in group)
            {
                Console.WriteLine(string.Format("{0}\t{1}个", item.Key, item.Count()));
            }
            Console.Read();

            LockTest lt = new LockTest();
            lt.Test(103);
            Console.Read();

            ParallelTest.Test();
            Console.Read();
        }
    }
}