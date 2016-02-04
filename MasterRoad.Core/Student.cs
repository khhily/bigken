using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterRoad.Core
{
    public class Student
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string ClassName { get; set; }

        public string GoodsSKUInfo
        {
            get
            {
                return "[{\"sku\":[{\"name\":\"尺码\",\"id\":\"06181114023992\"},{\"name\":\"颜色\",\"id\":\"06181114024842\"}],\"skuval\":[{\"val\":\"100\",\"key\":\"100\"},{\"val\":\"-cg1ch-1\",\"key\":\"-cg1ch-1\"}]},{\"sku\":[{\"name\":\"尺码\",\"id\":\"06181114025382\"},{\"name\":\"颜色\",\"id\":\"06181114024842\"}],\"skuval\":[{\"val\":\"120\",\"key\":\"120\"},{\"val\":\"-cg1ch-1\",\"key\":\"-cg1ch-1\"}]},{\"sku\":[{\"name\":\"尺码\",\"id\":\"06181114025892\"},{\"name\":\"颜色\",\"id\":\"06181114024842\"}],\"skuval\":[{\"val\":\"130\",\"key\":\"130\"},{\"val\":\"-cg1ch-1\",\"key\":\"-cg1ch-1\"}]},{\"sku\":[{\"name\":\"尺码\",\"id\":\"06181114026412\"},{\"name\":\"颜色\",\"id\":\"06181114024842\"}],\"skuval\":[{\"val\":\"140\",\"key\":\"140\"},{\"val\":\"-cg1ch-1\",\"key\":\"-cg1ch-1\"}]}]";
            }
        }

        public class Sku_Key
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Sku_Value
        {
            public string key { get; set; }
            public string val { get; set; }
        }

        public class Sku_Info
        {
            public Sku_Key[] sku { get; set; }
            public Sku_Value[] skuval { get; set; }
        }

        #region 属性集
        public Sku_Info[] GoodsSkuInfoObject
        {
            get
            {
                if (this.GoodsSKUInfo == null || this.GoodsSKUInfo.Length == 0)
                {
                    return null;
                }
                else
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Sku_Info[]>(this.GoodsSKUInfo);
                }
            }
        }
        #endregion
    }
}
