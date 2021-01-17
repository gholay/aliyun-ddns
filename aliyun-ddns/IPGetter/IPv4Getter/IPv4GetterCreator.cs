using aliyun_ddns.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace aliyun_ddns.IPGetter.IPv4Getter
{
    public static class IPv4GetterCreator
    {
        private static readonly IEnumerable<IIPv4Getter> _definedGetters = new CommonIPv4Getter[]
            {
                new CommonIPv4Getter("3322接口", "http://ip.3322.net/"),
            };

        public static IEnumerable<IIPv4Getter> Create()
        {
            List<IIPv4Getter> getters = new List<IIPv4Getter>();
            if (Options.Instance.CheckLocalNetworkAdaptor)
            {
                getters.Add(new LocalIPv4Getter());
            }
            else
            {
                getters.AddRange(InstanceCreator.Create<IIPv4Getter>(Ignore.CheckType));
                getters.AddRange(_definedGetters);
            }

            return getters;
        }
    }
}
