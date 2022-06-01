# CloudFoundry

### Manifest file
```
applications:
- name: core-webapi
  #random-route: true  //Randomly assigns a route ex: core-webapi-palm-elephant-cm.cfapps.ap21.hana.ondemand.com
  routes:
   - route: apiapp.cfapps.ap21.hana.ondemand.com   // once you create route using cloud cli 
  memory: 512M
  env:
    CACHE_NUGET_PACKAGES: false

```
### Create a route:
```
cf create-route cfapps.ap21.hana.ondemand.com --hostname apiapp
```

