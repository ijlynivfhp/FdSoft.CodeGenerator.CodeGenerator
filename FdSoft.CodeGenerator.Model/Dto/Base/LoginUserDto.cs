using FdSoft.CodeGenerator.Model.Models;
using FdSoft.CodeGenerator.Model.System;
using OfficeOpenXml.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Dto.Base
{
    /// <summary>
    /// 用户登录基类
    /// </summary>
    public class LoginBaseDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户名,必须是手机号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 客户端标识 
        /// </summary>
        public Guid ClientId { get; set; }
    }

    /// <summary>
    /// 用户登录前端对象
    /// </summary>
    public class LoginUserDto : LoginBaseDto
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 是否企业
        /// </summary>
        public bool IsCompany { get; set; }
        /// <summary>
        /// 产品分类（1旧版本，2新版本）
        /// </summary>
        public int ProductType { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 登录企业名称
        /// </summary>
        public int CoId { get; set; }
        /// <summary>
        /// 公司项目名称
        /// </summary>
        public string CoName { get; set; }
        /// <summary>
        /// 产品路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 用户登录Token
        /// </summary>
        public string Token { get; set; }
    }

    /// <summary>
    /// 用户登录缓存对象
    /// </summary>
    public class LoginUserExtDto : LoginUserDto
    {
        /// <summary>
        /// 用户产品权限
        /// </summary>

        public List<ProductDto> ProductList { get; set; }

        /// <summary>
        /// 角色集合(数据权限过滤使用)
        /// </summary>
        public List<string> RoleList { get; set; }
        /// <summary>
        /// 登录企业名称
        /// </summary>
        public int RootCoId { get; set; }
        /// <summary>
        /// 公司项目名称
        /// </summary>
        public string RootCoName { get; set; }
        /// <summary>
        /// 项目Ids集合
        /// </summary>
        public List<string> ProIds { get; set; } = new List<string>();
        /// <summary>
        /// 当前登录企业或项目下级集合（单个或多个）
        /// </summary>
        public List<CorpSubDto> CorpSubList { get; set; } = new List<CorpSubDto>();
        /// <summary>
        /// 当前登录用户项目切换列表
        /// </summary>
        public List<CorpDto> CorpList { get; set; } = new List<CorpDto>();
        /// <summary>
        /// 当前登录用户项目切换列表
        /// </summary>
        public List<CorpTreeDto> CorpTreeList { get; set; } = new List<CorpTreeDto>();

        /// <summary>
        /// 当前产品用户菜单
        /// </summary>
        public List<PowerItemDto> PowerItemList { get; set; } = new List<PowerItemDto>();

        /// <summary>
        /// 用户权限（压缩后）
        /// </summary>
        public string PowerCodeZip { get; set; }
        /// <summary>
        /// [路由菜单]
        /// </summary>
        public dynamic MenuRouterList { get; set; }
    }

    /// <summary>
    /// 产品
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// 描述 :产品编码 
        /// 空值 : false  
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 描述 :产品名称 
        /// 空值 : false  
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 描述 :产品分类（1旧版本，2新版本） 
        /// 空值 : false  
        /// </summary>
        public int ProductType { get; set; }
        /// <summary>
        /// 描述 :产品路径 
        /// 空值 : true  
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// 企业树
    /// </summary>
    public class CorpTreeDto : CorpDto
    {
        /// <summary>
        /// 树形下级目录
        /// </summary>
        public List<CorpTreeDto> Children { get; set; }
    }

    public class CorpMemoryDto : CorpDto
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 根企业CoId
        /// </summary>
        public int RootCoId { get; set; }
        /// <summary>
        /// 企业类型
        /// </summary>
        public int OrganizeType { get; set; }
        /// <summary>
        /// 项目竣工状态(1在建 2竣工)
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// 企业
    /// </summary>
    public class CorpDto : CorpSubDto
    {
        /// <summary>
        /// 企业Id
        /// </summary>
        public int CoId { get; set; }
        /// <summary>
        /// 父级企业Id
        /// </summary>
        public int ParentCoId { get; set; }
        /// <summary>
        /// 0组织（公司），1项目部，2子组织（子公司）
        /// </summary>
        public int CoType { get; set; }
        /// <summary>
        /// 企业上下级路径拼接符
        /// </summary>
        public string ItemPath { get; set; }
    }

    /// <summary>
    /// 企业下项目
    /// </summary>
    public class CorpSubDto
    {
        /// <summary>
        /// 如果是项目部，proid对应项目表
        /// </summary>
        public string ProId { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CoName { get; set; }
    }

    /// <summary>
    /// 用户角色权限菜单
    /// </summary>
    public class PowerItemDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 父级主键Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string ItemValue { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 父子关系CODE
        /// </summary>
        public string ItemPath { get; set; }

        /// <summary>
        ///  菜单=1,独元=4,操作=5,数据范围=6
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string ItemIcon1 { get; set; }
    }
    public class CoIdProjectDto
    {
        public string ProId { get; set; }
        public string ProName { get; set; }
    }
}
