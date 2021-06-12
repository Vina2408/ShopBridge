# ShopBridge

ShopBridge is an API for e-Commerce Test Application

Steps to be followed to run the application.

Step 1 : After Cloned the repository - Open the solution in VS 2019

Step 2 : Under the ShopBridge application you able to find the folder called "Table Scripts" , just get it the scripts from the file and run your MSSQL Server. (Note : There will be DB creation Query & 2 Tables creation scripts)

Step 3 : Go to appsettings.json - Change the below information in the connectionstrings. Just replace the value for {YourServer},{YouId},{YouPassword}

Step 4 : Run the application

Step 5 : In the browser swagger UI will be opened, In that there you able to find the API called "GetToken" under Security. Just click on "Try It" and click the "Execute". Note : In the input area RoleType will be asking you. It suppose to pass either (1 - Admin, 1 > n Others )

Step 6 : In the result box, you will be getting the Token(just copy it)

Step 7 : Run your API testing tool(anything). In the Header Key - Authorization & Value (paste the Copied token) , Then provide the details of URL & Http Method & Body/Parameters and observe the result for the below API's All API's under the "Products" controller will be work for "Admin" tokens. if any other role type token then it will throw "UnAuthorized" error.
