# fundaApiClient
 
This application is an .Net Core console application that builds web host to serve an API. This api consumes funda api to make calculations over the data. 
 
This api's url structure is as same as funda api url structure. For example if you want to get the list of top 10 agents who have most objects listed in Amsterdam you can use the following url;

http://localhost:5000/api/agents/?type=koop&filter=/amsterdam/

if you want to get the list of top 10 agents who have most gardens listed in Amsterdam you can use the following url;

http://localhost:5000/api/agents/?type=koop&filter=/amsterdam/tuin/

Known missing features;

Logging: It has centralized exception handling mechanisim but logging is missing. 

Class and method documentation: Class names, methods and parameter names must be self explanatory, so documentation doesn't seem necessary for now.
