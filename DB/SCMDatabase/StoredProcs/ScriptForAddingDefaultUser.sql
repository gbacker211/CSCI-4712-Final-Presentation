---Insert Default Admin User

--NOTE: Can change fields: FirstName, LastName, Password, UserName to what ever you wish, leave AccessGroup value as is

 INSERT INTO dbo.AccessUser(FirstName, LastName, Password, UserName, AccesGroup)
 VALUES('Admin', 'User', '12345', 'admin', 1)