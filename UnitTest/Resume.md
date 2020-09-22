#### 基本信息
 * 姓名: 李晨阳
 * 出生日期: 1995.2.11
 * 毕业院校: 上海理工大学
 * 学历: 本科
 * 居住地: 上海市嘉定区
 * 出生日期: 1995.2.11
 * 邮箱: alucard_invidia@hotmail.com
 * 个⼈博客：http://47.102.128.186/

#### 个⼈技术简介
 * 熟悉C#编程;
 * 了解dotnet core, webapi,aspnet core mvc;
 * 熟悉javascript/nodejs编程,熟悉Express,了解前端开发框架:vue
 * 熟悉RMDB(oracle,sqlserver,sybase) & NoSQL (mongo,redis) & Git;
 * 了解数据库事务机制,存储过程等.具有一定sql调优能力;
 * 了解docker,shell,nginx,pm2;

#### ⼯作经历
* 2020/4-至今 
    * 开源项目
        * 个人博客
            * 开发语言(技术): asp.net webapi(dotnet core) + vue 3.0(typescript)
            * 主要框架: webapi(dotnet core) + vue 3.0+ vuetify(UI)
            * 相关技术: ef core(mysql) + castsle + autofac + automapper + redis + swagger + etc.
            * 技术要点:
               * 后端项目主要基于dotnet core latest 开发,主要使用原生asp .net core框架,采用DDD仓储模式构建
               * 前端项目主要采用基于typescript的vue 3.0框架,UI框架采用Vuetify
               * 项目运行于aliyun ecs,主要基于docker容器部署,通过nginx反向代理
              
* 2019/9-至今 上海捷敏电子
    * 职位: 软件工程师
    * 工作内容
        * 负责MES系统中任务模块开发
            * 开发语言(技术): C#
            * 主要框架: asp.net
            * 相关技术: castsle + Topshelf
            * 技术要点:
            * 主要侧重接口的重构与业务封装.与OMS的交互主要通过消息队列(zeromq)与内部接口.

* 2018/4-2019/6 上海浪沙软件
    * 职位: 后端工程师
    * 工作内容
        * 负责云pos系统中收/发货+盘点+OMS交互模块开发
            * 简介: 实现线下门店的日常销售,会员管理,门店调拨收发货等业务,并与OMS项目有订单,库存,会员等数据的交互.
            * 开发语言(技术): javascript + nodejs.
            * 主要框架:miniui + express.
            * 相关技术: mongodb + redis + sybase + nginx + pm2 + shell + zeromq.
            * 技术要点:
                * 使用技术与OMS的大致相同.主要侧重接口的重构与业务封装.与OMS的交互主要通过消息队列(zeromq)与内部接口.

        * 负责全渠道订单中台(OMS)中订单/售后+商品+发票模块开发
            * 简介: 2B应用,接入各个线上电商平台与公司内部平台的订单数据,实现订单,库存相关业务的统一管理.
            * 开发语言(技术): javascript + nodejs + java(少量).
            * 主要框架:miniui + express
            * 相关技术: mongodb + redis + sybase + nginx + pm2 + shell + zeromq.
            * 技术要点:
                * 对接第三方电商平台api与完成内部系统api,基本的crud业务,存储过程等
                * 底层使用java访问sybase数据库
                * mongodb用于订单同步的中间库与记录日志;
                * redis用于缓存用户session与项目配置数据;
                * 通过消息队列(zeromq)同步中间库至主数据库;
                * 通过pm2+nginx部署应用,shell脚本实现自动部署.