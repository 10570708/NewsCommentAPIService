# NewsCommentAPIService: Project Creation
# Create a New Project in Visual Studio 2022


- Choose type: ASP.NET Core Web API
- Click Next
- Enter Project **Name**
- Enter Project **Location**
- Tick **Place solution & project in same directory**
- Click **Next**
- Select Framework: **.NET 6.0 (Long term support)**
- Select Authentication Type: **None**
- Keep following defaults checked: 
    - Configure for HTTPS
	- Use Controllers
	- Enable OpenAPI support
- Click **Create**


# Create Model for Rest API
- Create Models folder
- Create new class file in model folder called Repots.cs
- Add new attributes for Report Model
- Add dependencies required in Report model 

- Right Click on Controllers
- Click Add 
- Click New Scaffolded Item
- Select API Controller with Actions, using Entity Framework
- Add Microsoft.EntityFrameworkCore.Design
- Click Add

	- Model Class : Comment.cs
	- Data Context Class -> Click + 
	- Default entered 'NewsCommentAPIService.Data.NewsCommentAPIServiceContext' 
	- Click Add
	- Controller Name default entered : 'CommentsController' 
	- Click Add
	
The bones of the API are now created.
	
	
[Back to Index](index.md)