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

## Check Configuration
## ROUTES Section
* for any service that i want to connect to
* we can consider route1 for the service orders (-> new is orderRoute)

## CLUSTERS Section
* match the routes configuration
* create "orders" cluster

## DIAGRAMS
* GOOD EXAMPLE (why yes)
<img width="429" alt="YARP-GOOD-ex-DIAGRAM" src="https://github.com/user-attachments/assets/adacdf6c-2dbe-4cb6-b73b-5200944fd666" />

* BAD EXAMPLE (why no)
<img width="427" alt="YARP-BAD-ex-DIAGRAM" src="https://github.com/user-attachments/assets/de8f38e0-4ae2-4a55-b171-50be7c796bec" />

## REFERENCE

* https://microsoft.github.io/reverse-proxy/articles/getting-started.html
* https://www.youtube.com/watch?v=5vW_z19MlYc&ab_channel=MohamadLawand
