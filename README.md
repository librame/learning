常规项目参考
=========================

## 前端参考

    // 假设有 User 对象
    var user = { id: 0/1, name: "TestName" };
    
    // 序列化为 JSON 字符串形式
    var data = JSON.stringify(user);
    
    // 发起提交异步请求【针对 Get 方法】
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
