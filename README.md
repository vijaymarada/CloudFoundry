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
### Deploy the app
  In root foder execute below command

```
>cf push
```
Running application

![image](https://user-images.githubusercontent.com/49226342/171393388-73d21ad3-316d-46a7-b79e-81bca6eec3da.png)

```
### Create a route:
```
>cf create-route cfapps.ap21.hana.ondemand.com --hostname apiapp
```

### Unmap existing routes 
```
>cf unmap-route core-webapi cfapps.ap21.hana.ondemand.com --hostname  core-webapi-palm-elephant-cm
```

#### Delete route name
```
>cf delete-route  cfapps.ap21.hana.ondemand.com --hostname core-webapi-palm-elephant-cm
```

