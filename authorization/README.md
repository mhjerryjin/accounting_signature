###明道企业授权签名算法

* 打开企业管理账户 - 设置 - 开发者选项，获取企业授权开放接口密钥对信息
* 获取当前UTC时间戳（精度为毫秒），此时间戳在调用数据接口过程中需要传递
* 将密钥对当中的AppKey、SecretKey和此UTC时间戳进行按照键值对参数的方式拼接为字符串，如：AppKey=value1&SecretKey=value2&Timestamp=value3，各个参数以&拼接
将拼接的字符串用SHA256+BASE64算法进行签名

***
此项目包含C#、JAVA的签名写法，请详见文件查看

***

关于企业授权开放接口，详见《[企业授权开放接口说明](https://www.showdoc.cc/mingdao?page_id=15519621)》
