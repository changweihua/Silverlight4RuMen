
namespace Ch4_1.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // MetadataTypeAttribute 将 MyFriendsMetadata 标识为类
    //，以携带 MyFriends 类的其他元数据。
    [MetadataTypeAttribute(typeof(MyFriends.MyFriendsMetadata))]
    public partial class MyFriends
    {

        // 通过此类可将自定义特性附加到
        //MyFriends 类的属性。
        //
        // 例如，下面的代码将 Xyz 属性标记为
        //必需属性并指定有效值的格式:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MyFriendsMetadata
        {

            // 元数据类不会实例化。
            private MyFriendsMetadata()
            {
            }

            public string FirstName { get; set; }

            public int id { get; set; }

            public string LastName { get; set; }

            public string Phone { get; set; }
        }
    }
}
