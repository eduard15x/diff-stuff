# API Gateway with Ocelot Implementation

## NEEDED PACKAGES
* Ocelot
* Ocelot.Cache.CacheManager (optional if you need caching)

## CONFIGURATION

for this example we are using 3 web apis that runs on different ports (we suppose we have a microservices architecture)
ocelotApiGateway - http://localhost:5139
articleApi - http://localhost:5172
writerApi - http://localhost:5174

-install Ocelot package
-create a new json file at the root of the project called "ocelot.json"
-add the json file in the program to configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
-use the middleware provided by ocelot
await app.UseOcelot();

-all magic happens in json file
-you can separate each endpoint or you can combine similars (like we did for articles GET/DELETE by id)