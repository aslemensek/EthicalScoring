#  Ethical Scoring

## Environment
- Visual Studio Professional 2019 with 
  - ASP.NET and web development workflow
  - Azure development workflow
  - Data storage and processing
  
- If running solution locally, the environment will prompt you to create local certificate, 
  confirm the option so that the certificate can be generated and added to Trusted Root Certificate Authority store. 
  
- Entity Framework Core is used as an ORM for data integration, model was generated similar to the following instructions:
  https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx


## TODO
- In Blazor, DBContext is alive during the whole time of connection with client (as oppose to per HTTP call in Web API/MVC), this means DBConnection 
  will need to be scoped differently (not per session) or something else.
