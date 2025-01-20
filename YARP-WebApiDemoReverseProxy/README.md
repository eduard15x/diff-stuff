# YARP - Reverse Proxy Implementation
#
#

"ReverseProxy": {
   "Routes": {
     "route1" : {
       "ClusterId": "cluster1",
       "Match": {
         "Path": "{**catch-all}"
       }
     }
   },
   "Clusters": {
     "cluster1": {
       "Destinations": {
         "destination1": {
           "Address": "https://example.com/"
         }
       }
     }
   }
 }

##
##
## Check Configuration
## ROUTES Section
##
-for any service that i want to connect to
-we can consider route1 for the service orders (-> new is orderRoute)
##
## CLUSTERS Section
##
-match the routes configuration
-create "orders" cluster
##
https://microsoft.github.io/reverse-proxy/articles/getting-started.html

https://www.youtube.com/watch?v=5vW_z19MlYc&ab_channel=MohamadLawand