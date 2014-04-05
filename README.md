AdAuth
======

Sample program of the AD authentication.

C#でAD認証を行うサンプルプログラムです。

======
##使用例
Ad adAuth = new Ad();  
adAuth.ConnDestination = "aaaa";  
adAuth.Domain = "@aaaa.co.jp";  
if (adAuth.Auth("ID", "パスワード"))  
{  
	// 認証OKの処理  
}  
else  
{  
	// 認証NGの処理  
}  

