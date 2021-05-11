using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace MarauderMap.Data
{
    public class ConnectionStringInvalidException : AbpException
    {
        public ConnectionStringInvalidException()
            : base("The Data Source should be a sqlite db file name with an extension! (E.g: example.db)")
        {

        }
    }
}
