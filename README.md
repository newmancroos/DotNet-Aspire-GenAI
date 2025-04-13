# DotNet-Aspire-GenAI

## .NET Aspire

### What is .NET Aspire?
- Cloud-native development framework built on top of .NET platform to streamline and standardize the process of creating distrubuted, microservices-based apps.
- It's adding scaffolding, orachestration and preconfigured integrations for common cloud-backed sevices.
- Collection of templates, libraries that simplify the process of building microservices and orchestrating them in containerized environments.

![image](https://github.com/user-attachments/assets/0cd41ef6-d538-4bf5-845f-c8e5b89fee55)


.NET Aspire is a cloud-ready stack and set of tools, templates, and NuGet packages designed to simplify the development of observable, production-ready, and distributed applications, particularly those with cloud-native architectures. 

<b>Purpose:</b><br/>
.NET Aspire aims to make it easier for developers to build and manage complex, distributed applications by providing a streamlined approach to common cloud-native challenges. <br/>
<b>Key Features:</b><br/>
* Orchestration: Simplifies the configuration and interconnection of application components, including databases, messaging systems, and caching services. 
* Components: Offers NuGet packages for integrating with various cloud services, providing standardized configurations and automatic injection for efficient service communication. 
* Tooling: Includes Visual Studio and .NET CLI integrations with standardized project templates and pre-configured components, streamlining development and scaling. 
* Cloud-Native Focus: Designed to support the creation of production-ready, observable distributed applications, leveraging microservices architecture. 
* Integrations: Provides integrations for common cloud services, such as databases, messaging systems, and caching services, packaged into NuGet packages. <br />

<b>Benefits:</b><br />
* Simplified Development: Streamlines the development of cloud-native applications by leveraging microservices architecture. 
* Improved Observability: Enables easier monitoring and debugging of distributed applications. 
* Enhanced Productivity: Provides tools and templates to accelerate the development process. 
* Focus on Code: Allows developers to focus on application logic rather than infrastructure complexities. 

### What is Distributed Architecture?
* Functionality is spread across multiple independent services that communicate over a network
* Each services can be developed, deployed and scaled independently
* If one service fails, others can continue oerating, reducing system-wide downtime
* Services handling heavy loads can be scaled up (or down) without affecting others

### Cloud-Native Distributed Architecture

![image](https://github.com/user-attachments/assets/a9fbc351-90fd-4841-b1e6-aca0ea9aec8e)

![image](https://github.com/user-attachments/assets/ba5c5605-4810-41fe-99ba-6a202a38dc44)


## .NET Aspire - Distributed App Development Framework

* .NET Aspire concepts:
     - Orchestration
     - Integration
     - Service Discovery

![image](https://github.com/user-attachments/assets/158a0521-0670-4ba5-b5ba-f3bfd406d329)


### Orchestration
- <b>Automating Container management</b></br>
   Automate container-based deployment without requireing manual dockerfiles or complex docker-compose setups for each microservices <br/>
- <b>Environment Awareness</b><br/>
   Uses environment configuration (local, test, production) to decide what services to start and how to configure them. <br/>
- <b>Service Dependencies</b><br/>
   If a microservice needs to wait for a database to spin up, Aspire can coordinate that. <br/>
- <b>Scalable Infrastructure</b><br/>
  Strightforward to scale indivitual microservices, whether your're using Docker, Kubernetes or ACA, Aspire manges the foundational scripts and tooling<br/>


### Integration in .NET Aspire
- <b>Build-in Connectors</b> <br/>
   Prebuild integrations with common cloud and on-premises services, such as databases (PostgreSQL, MongoDB), Caches (Redis), Message brockers (RabbitMQ, Azure Service Bus) and Identity Providers (Keycloak) without any boiler plate code.<br/>
- <b> Cross-Cutting Feature</b><br/>
   Provides default setups for logging, monitoring and telemetry, saving time and promoting consistent patterns across different microservices.<br/>
- <b>Modular & Extensible</b> <br/>
   Adding a new service like AI-based feature or a vector database requires minimal adjustments, thanks to Aspire's pluggable design<br/>

### Service Discovery in .NET Aspire
- <b>Dynamic Routing</b><br/>
  Service end-points can change dynamically, for instance, when scaling up or down, keep tracking of microservices locations, avoiding the need for hard-coded URLs or IP addresses<br/>
- <b>Automatic Registrations</b><br/>
  When each microservice starts, it registers itself in Aspire's service registry (or a backing service registry), making it discoverable to other services.
- <b>Resilience & Scaling</b><br/>
  Service discover also enables Load balancing and fail over, If one instance of a service becomes unavailable, calls are routed to another instance automatically, increase resiliency and ensureing uninterrupted service
    
## Terms of Orchestration in .NET Aspire

<b>App Model : </b> The heart of your distributed application <br/>
<b>App Host / Orchestrator : </b> Project responsible for running all resources <br/>
<b>Resoiurces : </b> Any piece of you app (database, Microsevices, Containers) <br/>
<b> Integration : </b> NuGet packages that model or configure services <br/>
<b>Reference : </b> Declares dependencies between resources <br/>

![image](https://github.com/user-attachments/assets/633fd3a2-8834-4d1f-b94b-3b49c8ded288)

![image](https://github.com/user-attachments/assets/ce8f8599-df3f-4852-8bba-7f17f3f4646f)


![image](https://github.com/user-attachments/assets/60391bbc-86ed-45db-a493-b5c97f2aa262)


![image](https://github.com/user-attachments/assets/0df72725-e95a-49fb-b546-91f4fad75c30)


### Service Discovery

- Discovering service without hardcoding the service path.
- ex.
   ![image](https://github.com/user-attachments/assets/229bcc01-cf48-436c-871f-3241af2b2cda)


  <br/>There are different resource types.:

  ![image](https://github.com/user-attachments/assets/30417bd3-f80a-4711-a17f-71c4b1213992)
  

  ![image](https://github.com/user-attachments/assets/3b09ce8b-6412-40e1-ac82-6845cd85e113)


![image](https://github.com/user-attachments/assets/b4e5bf38-8c1c-41a9-a508-0ea63ef4ae04)


## How does Hosting integration and Client Integration works?

We install Aspire.Hosting packages and regester in the Aspire hosting project. Since Each projects refer Aspire host, Host inject the environment variable to the service project.
In Service side we need to install relevent Aspire packages, so it uses the environment variable injected by Aspire host and started working.

![image](https://github.com/user-attachments/assets/9bebec35-646d-40e3-985c-0abad8be0821)


## How hosting side regestration work?


![image](https://github.com/user-attachments/assets/a8f666b8-181d-48fc-b1d2-25b7cf6e13bb)

- Once we install Aspire.Host.Postgres Nuget packager. We created a container with PGAdmin and Named it "postgres"
- Created a connection to the postgres database which in container
- Inject database connection environment config to the project


![image](https://github.com/user-attachments/assets/62ee5d33-fc53-4399-8897-6fec91aa5a16)


* After install and configure Aspire.Host packages now we need to install Aspire clien packages in the service ans configure that to read injected Environment variable for PostgresD database.
* Then we can configure aspire host project progam.cs to configure postgres and api service.
* Run the solution as AppHost as startup project and copy catalog service https url and replce it in the catalog project catalog.http file
* Add products in the url so the url looks like https://localhost:7063/products here products is the endpoint root.

  ![image](https://github.com/user-attachments/assets/be7eac9e-e3d5-40c0-a42d-be7ba623b187)

  ### Catalog.http file content
<pre>
     @Catalog_HostAddress = https://localhost:7063/products
     
     GET {{Catalog_HostAddress}}/
     Accept: application/json
     
     ###
     
     
     GET {{Catalog_HostAddress}}/1
     Accept: application/json
     
     ###
     
     
     POST {{Catalog_HostAddress}}/
     Content-Type: application/json
     {
         "id": 10,
         "name": "NEW Swn Flashlight",
         "description": "A NEW swn product for outdoor enthusiasts",
         "price": 59.99,
         "imageUrl": "product10.png"
     }
     
     ###
     
     
     PUT {{Catalog_HostAddress}}/10
     Content-Type: application/json
     {    
         "name": "UPDATED Swn Flashlight",
         "description": "An UPDATED swn product for outdoor enthusiasts",
         "price": 19.99,
         "imageUrl": "product10.png"
     }
     
     ###
     
     
     DELETE {{Catalog_HostAddress}}/10
     Accept: application/json
</pre>
