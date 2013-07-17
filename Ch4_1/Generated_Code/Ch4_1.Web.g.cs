//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18034
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ch4_1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    
    
    /// <summary>
    /// RIA 应用程序的上下文。
    /// </summary>
    /// <remarks>
    /// 此上下文对库进行了扩展，使得应用程序服务和类型
    /// 可供代码和 xaml 使用。
    /// </remarks>
    public sealed partial class WebContext : WebContextBase
    {
        
        #region 可扩展性方法定义

        /// <summary>
        /// 一旦初始化完成便从构造函数中调用此方法，
        /// 还可将此方法用于以后的对象设置。
        ///</summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// 初始化 WebContext 类的新实例。
        /// </summary>
        public WebContext()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// 获取向当前应用程序注册为生存期对象的上下文。
        /// </summary>
        /// 如果没有当前的应用程序，没有添加上下文或添加了多个上下文，
        /// 则会引发 <exception cref="InvalidOperationException">。
        /// </exception>
        /// <seealso cref="System.Windows.Application.ApplicationLifetimeObjects"/>
        public new static WebContext Current
        {
            get
            {
                return ((WebContext)(WebContextBase.Current));
            }
        }
    }
}
namespace Ch4_1.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.ServiceModel.Web;
    
    
    /// <summary>
    /// 与“FriendsService”DomainService 相对应的 DomainContext。
    /// </summary>
    public sealed partial class FriendsContext : DomainContext
    {
        
        #region 可扩展性方法定义

        /// <summary>
        /// 一旦初始化完成便从构造函数中调用此方法，
        /// 还可将此方法用于以后的对象设置。
        ///</summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// 初始化 <see cref="FriendsContext"/> 类的新实例。
        /// </summary>
        public FriendsContext() : 
                this(new WebDomainClient<IFriendsServiceContract>(new Uri("Ch4_1-Web-FriendsService.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// 用指定的服务 URI 初始化 <see cref="FriendsContext"/> 类的新实例。
        /// </summary>
        /// <param name="serviceUri">FriendsService 服务 URI。</param>
        public FriendsContext(Uri serviceUri) : 
                this(new WebDomainClient<IFriendsServiceContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// 用指定的 <paramref name="domainClient"/> 初始化 <see cref="FriendsContext"/> 类的新实例。
        /// </summary>
        /// <param name="domainClient">要用于此 DomainContext 的 DomainClient 实例。</param>
        public FriendsContext(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// 获取已加载到此 <see cref="FriendsContext"/> 实例中的 <see cref="MyFriends"/> 实体实例的集合。
        /// </summary>
        public EntitySet<MyFriends> MyFriends
        {
            get
            {
                return base.EntityContainer.GetEntitySet<MyFriends>();
            }
        }
        
        /// <summary>
        /// 获取一个可使用“GetMyFriends”查询加载 <see cref="MyFriends"/> 实体实例的 EntityQuery 实例。
        /// </summary>
        /// <returns>可以加载以检索 <see cref="MyFriends"/> 实体实例的 EntityQuery。</returns>
        public EntityQuery<MyFriends> GetMyFriendsQuery()
        {
            this.ValidateMethod("GetMyFriendsQuery", null);
            return base.CreateQuery<MyFriends>("GetMyFriends", null, false, true);
        }
        
        /// <summary>
        /// 为此 DomainContext 的 EntitySets 创建一个新 EntityContainer。
        /// </summary>
        /// <returns>一个新容器实例。</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new FriendsContextEntityContainer();
        }
        
        /// <summary>
        /// 用于“FriendsService”DomainService 的 Service 协定。　
        /// </summary>
        [ServiceContract()]
        public interface IFriendsServiceContract
        {
            
            /// <summary>
            /// 异步调用“GetMyFriends”操作。
            /// </summary>
            /// <param name="callback">要在完成时调用的回调。</param>
            /// <param name="asyncState">可选的状态对象。</param>
            /// <returns>可用于监视请求的 IAsyncResult。</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/FriendsService/GetMyFriendsDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/FriendsService/GetMyFriends", ReplyAction="http://tempuri.org/FriendsService/GetMyFriendsResponse")]
            [WebGet()]
            IAsyncResult BeginGetMyFriends(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// 完成由“BeginGetMyFriends”开始的异步操作。
            /// </summary>
            /// <param name="result">从“BeginGetMyFriends”返回的 IAsyncResult。</param>
            /// <returns>从“GetMyFriends”操作返回的“QueryResult”。</returns>
            QueryResult<MyFriends> EndGetMyFriends(IAsyncResult result);
            
            /// <summary>
            /// 异步调用“SubmitChanges”操作。
            /// </summary>
            /// <param name="changeSet">要提交的变更集。</param>
            /// <param name="callback">要在完成时调用的回调。</param>
            /// <param name="asyncState">可选的状态对象。</param>
            /// <returns>可用于监视请求的 IAsyncResult。</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/FriendsService/SubmitChangesDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/FriendsService/SubmitChanges", ReplyAction="http://tempuri.org/FriendsService/SubmitChangesResponse")]
            IAsyncResult BeginSubmitChanges(IEnumerable<ChangeSetEntry> changeSet, AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// 完成由“BeginSubmitChanges”开始的异步操作。
            /// </summary>
            /// <param name="result">从“BeginSubmitChanges”返回的 IAsyncResult。</param>
            /// <returns>从“SubmitChanges”返回的变更集入口元素的集合。</returns>
            IEnumerable<ChangeSetEntry> EndSubmitChanges(IAsyncResult result);
        }
        
        internal sealed class FriendsContextEntityContainer : EntityContainer
        {
            
            public FriendsContextEntityContainer()
            {
                this.CreateEntitySet<MyFriends>(EntitySetOperations.All);
            }
        }
    }
    
    /// <summary>
    /// “MyFriends”实体类。
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/Ch4_1.Web")]
    public sealed partial class MyFriends : Entity
    {
        
        private string _firstName;
        
        private int _id;
        
        private string _lastName;
        
        private string _phone;
        
        #region 可扩展性方法定义

        /// <summary>
        /// 一旦初始化完成便从构造函数中调用此方法，
        /// 还可将此方法用于以后的对象设置。
        ///</summary>
        partial void OnCreated();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnidChanging(int value);
        partial void OnidChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();

        #endregion
        
        
        /// <summary>
        /// 初始化 <see cref="MyFriends"/> 类的新实例。
        /// </summary>
        public MyFriends()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// 获取或设置“FirstName”值。
        /// </summary>
        [DataMember()]
        [StringLength(50)]
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                if ((this._firstName != value))
                {
                    this.OnFirstNameChanging(value);
                    this.RaiseDataMemberChanging("FirstName");
                    this.ValidateProperty("FirstName", value);
                    this._firstName = value;
                    this.RaiseDataMemberChanged("FirstName");
                    this.OnFirstNameChanged();
                }
            }
        }
        
        /// <summary>
        /// 获取或设置“id”值。
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnidChanging(value);
                    this.ValidateProperty("id", value);
                    this._id = value;
                    this.RaisePropertyChanged("id");
                    this.OnidChanged();
                }
            }
        }
        
        /// <summary>
        /// 获取或设置“LastName”值。
        /// </summary>
        [DataMember()]
        [StringLength(50)]
        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                if ((this._lastName != value))
                {
                    this.OnLastNameChanging(value);
                    this.RaiseDataMemberChanging("LastName");
                    this.ValidateProperty("LastName", value);
                    this._lastName = value;
                    this.RaiseDataMemberChanged("LastName");
                    this.OnLastNameChanged();
                }
            }
        }
        
        /// <summary>
        /// 获取或设置“Phone”值。
        /// </summary>
        [DataMember()]
        [StringLength(50)]
        public string Phone
        {
            get
            {
                return this._phone;
            }
            set
            {
                if ((this._phone != value))
                {
                    this.OnPhoneChanging(value);
                    this.RaiseDataMemberChanging("Phone");
                    this.ValidateProperty("Phone", value);
                    this._phone = value;
                    this.RaiseDataMemberChanged("Phone");
                    this.OnPhoneChanged();
                }
            }
        }
        
        /// <summary>
        /// 根据密钥字段计算可唯一标识此实体实例的值。
        /// </summary>
        /// <returns>唯一标识此实体实例的对象实例。</returns>
        public override object GetIdentity()
        {
            return this._id;
        }
    }
}
