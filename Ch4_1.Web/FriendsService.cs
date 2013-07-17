
namespace Ch4_1.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // 使用 Silverlight4RuMenEntities 上下文实现应用程序逻辑。
    // TODO: 将应用程序逻辑添加到这些方法中或其他方法中。
    // TODO: 连接身份验证(Windows/ASP.NET Forms)并取消注释以下内容，以禁用匿名访问
    //还可考虑添加角色，以根据需要限制访问。
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class FriendsService : LinqToEntitiesDomainService<Silverlight4RuMenEntities>
    {

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“MyFriends”查询添加顺序。
        public IQueryable<MyFriends> GetMyFriends()
        {
            return this.ObjectContext.MyFriends;
        }

        public void InsertMyFriends(MyFriends myFriends)
        {
            if ((myFriends.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(myFriends, EntityState.Added);
            }
            else
            {
                this.ObjectContext.MyFriends.AddObject(myFriends);
            }
        }

        public void UpdateMyFriends(MyFriends currentMyFriends)
        {
            this.ObjectContext.MyFriends.AttachAsModified(currentMyFriends, this.ChangeSet.GetOriginal(currentMyFriends));
        }

        public void DeleteMyFriends(MyFriends myFriends)
        {
            if ((myFriends.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(myFriends, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.MyFriends.Attach(myFriends);
                this.ObjectContext.MyFriends.DeleteObject(myFriends);
            }
        }
    }
}


