常规项目参考
=========================

## 前端参考

    // 假设有 User 对象
    var user = { id: 0/1, name: "TestName" };
    
    // 序列化为 JSON 字符串形式
    var data = JSON.stringify(user);
    
    // 发起提交异步请求【针对 POST/PUT 方法】
    $.post("/api/Users", data, function(result){
        // 处理回传结果
    });
    
    // 发起查询异步请求【针对 Get 方法】
    $.get("/api/Users", function(result){
        var users = eval(result);
        // each 针对返回的是用户集合
        $.each(users, function(i, user){
            // 处理查询用户结果
        })
        // 如果返回的是单个用户，则直接处理结果
    });

## 后端参考

    // UsersController
    public class UsersController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            var users = ...GetUsers(); // 集合
            return JsonConvert.SerializeObject(users);
        }
        
        [HttpGet]
        public string Get(int id)
        {
            var user = ...GetUser(id); // 单个
            return JsonConvert.SerializeObject(user);
        }
        
        [HttpPost]
        public string Post([FromBody]User user)
        {
            // 验证并新增
            return JsonConvert.SerializeObject(user); // 返回更新 ID 后的实体
        }
        
        [HttpPost]
        public string Put(int id, [FromBody]User user)
        {
            // 修改
            return JsonConvert.SerializeObject(user); // 返回修改后的实体
        }
        
        [HttpGet]
        public void Delete(int id)
        {
            // 删除并返回HTTP状态
        }
    }

## 发布部署

    用 IIS 部署网站：https://www.cnblogs.com/lyong315/p/10009517.html

## 文档模板

    1.2服务器部署
    1.2.1硬件配置
        服务器硬件配置、磁盘阵列等配置
        搭建环境需要的信息
        a. 各种服务器数量
        Web应用服务器：1台
        接口应用服务器：1台
        数据库服务器：1台
        b. 每台服务器需要的CPU颗数、内存大小、存储大小
        服务器要求：2CPU、8G内存、200G存储
        c. 操作系统、数据库、中间件版本、JDK要求？
        操作系统：Windows7 64位
        数据库：sqlserveer2008或以上版本
        .NET 框架：.NET Framework 4.5或以上版本
        d. 数据库字符集？
        utf8 字符集
        e. 数据库信息（端口：1433）
        数据库用户：sa
        数据库用户密码：123456
        数据库实例名：MSSQLSERVER
        f. 描述服务器之间、相关联系统之间的访问关系
        用户通过浏览器访问到web服务器，web服务器将Web服务请求转发到接口服务器，并调用接口服务器，接口服务请求数据服务，从数据库中获取数据，并将数据响应给Web服务器。详见1.1系统部署图。
        
    1.4系统部署
    1.4.1 Web应用服务器部署
    （一）项目发布
    因为采用前后端分离的开发模式，因此前端的发布变得非常简单，因为只有HTML页面和CSS以及JS文件，所以无需任何的配置文件。
    （二）项目部署
    此时将发布的文件夹拷贝到指定的位置，询问发布路径？。设置文件夹的访问权限，然后打开IIS添加网站，网站物理路径指向我们的发布文件夹，端口号固定为？.
    软件环境
    （1） IIS6.0及以上
    （2） Chrome浏览器
    （3） Windows Server 2008 64位/Windows 7 64位皆可
    打开网站无任何错误则部署成功。
    （四）注意事项
    发布文件夹不要包含中文，中文的文件夹有可能会造成IIS发布之后无法访问的故障。
    
   ----加分说明---
1	前后端分离	后台错误不会直接反映到页面，前端JS可以做很大部分的数据处理工作，对服务器的压力减小到最小，前端负责页面跳转，后端负责数据数据处理，前后台各尽其职可以最大程度的减少开发难度。
2	防止sql注入 
SQL注入，就是通过把SQL命令插入到Web表单递交或输入域名或页面请求的查询字符串，最终达到欺骗服务器执行恶意的SQL命令
3	记录系统操作痕迹
当系统数据出现意外情况时，可以根据操作记录，还原数据，以及操作人员对数据违规操作时，可以根据系统操作记录，进行操作人员追责等
## 文档介绍
1.1	文档目的
本文档将从概要设计方面对系统进行综合概述，其中会使用多种不同的概要设计视图来描述系统的各个方面。它用于记录并表述已对系统的概要设计方面的重要决策。详细设计文档、测试方案编写和开发编码都应该遵循本文档的相关规定。
1.2	文档范围
本文档适用于系统设计人员、开发人员和测试人员，系统设计人员通过本文进行详细设计编写，开发人员阅读本文，按照本文的设计方案进行开发编码，测试人员通过阅读本文进行测试方案和测试用例的编写。
1.4缩写语句
CM	
配置管理，Configuration Management
OSMS	
组织架构管理系统，Organization Structure Management System
UML	
统一建模语言，Unified Modeling Language
OO	
面向对象，Object Oriented，

3	设计约束
3.1	需求约束
	本系统应当遵循的标准或规范
1、《OSMS__组织架构管理系统__服务接口使用说明》
	软件、硬件环境（包括运行环境和开发环境）的约束
序号	详细要求
1	操作系统：Windows7
2	应用服务器：Web服务器
3	数据库：SqlSever2008及以上版本
4	运行环境：.NET Framework 4.5或以上版本
	接口/协议的约束
1、内部数据接口
各模块之间采用函数调用、参数传递、返回值的方式进行信息传递。接口传递信息将是以封装好的对象形式数据，以参数传递或返回值的形式在各个模块间传输。
2、外部数据接口
系统采用前后端分离，以接口方式进行信息的传输，接口传递信息将是以协定好的HTTP协议与JSON格式报文形式数据，以网络流的形式进行传输。前端采用Ajax请求，后端返回JSON格式数据。
	软件质量的约束，
正确性、可靠性、易用性、安全性、可扩展性、兼容性、可移植性等等。

3.2	隐含约束
1、由于该文档涉及到本系统的框架，所以本文档只供本项目组及相关人员阅读，必须保密。
2、本项目中数据库方面的设计使用 Power Designer软件来进行开发；用例视图、逻辑视图、部署视图都是用UML语言来表示的。

5	系统总体结构
系统主要采用前后端分离，前端使用.Net搭建的Web服务器，后端使用webapi搭建的的接口服务器。用户通过浏览器访问到Web应用服务，web服务器将Web服务请求转发到接口服务器，并调用接口服务器，接口服务请求数据服务，从数据库中获取数据，如果存在数据，直接将数据返回给Web应用服务，在返回给用户，如果数据不存在，则去查询sqlserver数据库，将查询到的数据返回给Web应用服务，再返回给用户。


1	用户模块
1.1	用户登录
1.1.1	请求协议
字段名称	变量名	数据类型	默认值	值域	说明
接口编码
/userInfo/login
输入参数
UserInfo
登录账号	account	String		M	必填
登录密码	password	String		M	必填
请求方式
POST
请求地址（测试环境）
http://129.204.107.189:8888/userInfo/login
请求示例
{
	"account":"admin",
	"password":"123456"
}

1.1.2	返回协议
字段名称	变量名	数据类型	默认值	值域	说明
输出参数
调用是否成功	isSuccess	Boolean		M	调用服务本身是否成功，不表示业务成功失败类型
返回结果编码	code	String(8)		O	正确返回“0000”
返回信息	msg	String(128)		0	
参数对象	data	*Json		0	响应参数Json格式
业务参数
业务参数字符串，详见：各业务接口定义。
返回示例
{
    "data": {
        "id": 1,
        "account": "12313213",
        "userName": "阿达",
        "password": "123456",
        "isAdmin": 1,
        "gender": null,
        "mobilePhone": null,
        "commpanyId": null,
        "deptId": null,
        "jobId": null,
        "isAllow": null,
        "remark": null,
        "createTime": null,
        "isDelete": 0
    },
    "code": "0000",
    "msg": "登录成功",
    "success": true
}

1.2	用户添加
1.2.1	请求协议
字段名称	变量名	数据类型	默认值	值域	说明
接口编码
/userInfo/insert
输入参数
UserInfo
登录账号	account	String		M	必填
登录密码	password	String		M	必填
请求方式
POST
请求地址（测试环境）
http://129.204.107.189:8888/userInfo/insert
请求示例
{
	"account":"admin",
	"password":"123456",
	"userName":"系统管理员",
	"gender":"男",
	"isAdmin":1,
	"mobilePhone":"10086",
	"commpanyId":1,
	"deptId":1,
	"jobId":1,
	"isAllow":0,
	"remark":"系统管理员"
}

1.2.2	返回协议
字段名称	变量名	数据类型	默认值	值域	说明
输出参数
调用是否成功	isSuccess	Boolean		M	调用服务本身是否成功，不表示业务成功失败类型
返回结果编码	code	String(8)		O	正确返回“0000”
返回信息	msg	String(128)		0	
参数对象	data	*Json		0	响应参数Json格式
业务参数
业务参数字符串，详见：各业务接口定义。
返回示例
{
    "data": {
        "id": 2,
        "account": "admin",
        "userName": "系统管理员",
        "password": "123456",
        "isAdmin": 1,
        "gender": "男",
        "mobilePhone": "10086",
        "commpanyId": 1,
        "deptId": 1,
        "jobId": 1,
        "isAllow": 0,
        "remark": "系统管理员",
        "createTime": 1592116622902,
        "isDelete": 0,
        "commpany": null,
        "dept": null,
        "job": null
    },
    "code": "0000",
    "msg": "保存成功",
    "success": true
}
