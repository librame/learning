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
        数据库：Mysql5.6或以上版本
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
    
    

