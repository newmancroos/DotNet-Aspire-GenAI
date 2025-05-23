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

### by arranging Catalog.http  we can easiy debug the application while running by hitting the Send resuest button as shown below


![image](https://github.com/user-attachments/assets/5264754c-42fe-4847-a2e4-0de0c5724f94)



## Calling http call from Basket Api to Catalog api via http call using Asp.Net Aspire <b>Service Discovery</b> feature without hard coding the service url

![image](https://github.com/user-attachments/assets/b2645ec7-89f9-4aa8-bbb0-082f040a7813)

- With resource like Redis cache, database, .NEt aspire inject the environment variable with resource path. but with Service reference .Net aspire inject the service Url to the destination services. <br/>

## Securing microservice using Keycloak
Keycloak is an open-source Identity and Access Management (IAM) solution that provides authentication and authorization services for ASP.NET Core applications. It acts as an identity provider, allowing users to log in, manage their accounts, and access resources in your application. Keycloak is particularly useful for scenarios where you need single sign-on (SSO) and want to leverage the capabilities of OAuth 2.0 and OpenID Connect protocols. 

### Authentication:
Keycloak handles verifying user identities, ensuring that only authorized users can access your application. 

### Authorization:
Keycloak enforces access control, determining which users have permission to access specific resources or functionalities within your application. 

### Single Sign-On (SSO):
Users can log in once and access multiple applications using the same credentials, thanks to Keycloak's SSO capabilities. 

### Identity Management:
Keycloak provides tools for managing users, roles, groups, and other identity-related aspects of your application. 

### OpenID Connect and OAuth 2.0 Compliant:
Keycloak is built on these popular protocols, making it easy to integrate with many modern web applications. 
<br/><br/>
### <u>Benefits of Using Keycloak in ASP.NET Core:</u>

### Simplified Security:
By offloading authentication and authorization, you can focus on developing your application's core features, rather than managing security complexities. 

### Scalability and Robustness:
Keycloak is a mature and robust solution, capable of handling large numbers of users and applications. 

### Centralized Management:
Keycloak provides a central admin console for managing users, roles, and configurations for all of your applications. 

### Social Login and User Federation:
Keycloak supports various social login providers and user federation options, making it easier for users to log in and manage their accounts. 

![image](https://github.com/user-attachments/assets/d86056c8-8be6-40a1-9214-dd9b6de656d4)

![image](https://github.com/user-attachments/assets/70f474f4-4fbb-475a-b4ed-98e98bf4f164)


### Configuraing Keycloak

- First configuration is create Realm definition
- Under Realm definition (eshop) we can create Client, Roles and Users
- Create Client and give client name (eshop-clinet) and leave other setting as it is.
- Create User 
![image](https://github.com/user-attachments/assets/ea4e91d4-a836-455c-b87a-2a9249fa5a52)

![image](https://github.com/user-attachments/assets/810aca19-b75c-4d2e-98a6-21201fdd5d8b)

![image](https://github.com/user-attachments/assets/aa1cb62e-4a2f-4ea8-a395-1650a28d7d8d)

Now we can get the token using the Keycloak end-point

- Toekn End-point : http://your-Keycloak-server/realms/your-realm-name/protocol/openid-connect/token <br/>
- Our End-point for token:  http://localhost:8080/realms/eshop/protocol/openid-connect/token <br/>
- grant-type = password
- client-id : eshop-client
- scope = email openid
- username= test
- password = 1234

- We can use Basket service basket.http debugging tool to get the token
  ![image](https://github.com/user-attachments/assets/388adf3b-c9ba-4f87-b660-a2301a67aec5)
  


![image](https://github.com/user-attachments/assets/917b151a-e382-469a-912d-cdb2f8ecb715)

  
![image](https://github.com/user-attachments/assets/65f6ea89-c5a9-4fd9-948e-d284e2ce3dae)


### Note: For me calling end-point with authorization bearer token did not work on the bask.http but of I call it from Postmen it is working.


## Deploying Aspire applications to Azure Container App (ACA)

### What is Azure Container Apps?
- Azure container Apps is Microsoft's managed container hosting for microservices
- Simplifies running containers in a serverless fashion
- Perfect for .Net aspire solutions needing easy scale & integrate logs

### What is the Key benefits of Azure Container Apps
- Automatic scaling and revision management
- Dapr integration (optional) for sidecar patterns
- ACA uses KEDA for event-based scaling for queue messages
- Simple container-based deployment from the command line using "azd" command. Easy deployment from local development or CICD pipeline. No complicated Yaml or manual orchested config file.

### Deploying a .NET Aspire project to ACA
- Containerize each microservices automatically with .NET aspire
- Just use Azure developer CLI and Azd commands to setup environment files
- azd up to provision Azure resources
- azd down to tear them down

###  Detailed Azure command

azd init 
- Create .azure folder or config files for naming & region choices
- optionally picks an existing subscription
- Typically done once per solution

azd up
- This will build your .net aspire project containers locally or in the azure (Builds containers, pushes to Azure container Registry
- Provision containers Apps environment, secrets and logs
- Deploys each microservices in your .NET Aspire solution to the Azure container Apps

azd Down
- Frees up resource usage in your subscription
- Removes container apps, registry, loggs and secrets
- This keeps our Azure subscription and limit the useage so we'll not be billed

<b>Notes:</b><br/>
Data valume doesn;t work on Azure Container App. We know when we create docker container we use Valume that helps to save the data permanantly in the container eventhough we restart the container the data will be there.
This feature doesn;t work on ACA.<br/>
Especially Volumes don;t work woith Postgres database on ACA. It is an Azure storage limitation with how the volume is mounted and incompatibility with somer linux containers.<br/>

![image](https://github.com/user-attachments/assets/17b12d7e-deb7-40e1-b7f1-a7e265fe904b)


## Deploye Aspire application using azd command to Azure Container Application (ACA)

- Step1 : Install Azd using <pre> winget install microsoft.azd</pre>
- Step2: Check <pre>azd version</pre> to confirm the azd installation
- Step3: <pre>azd auth login</pre> to login to azure portal
- Stpe4: Goto Application root folder where the solution file exist and run <pre>azd init</pre> This will identify the project and ask to enter Environment name "myaspire"
       End of stpe4, created  azure.yaml and next-setp.md files
- Step5: Run azd up . In this step it will ask you to select Azure subscroiption, we have only one so just enter. and Location "East Us 2".
    It will automatically create "rg-myaspire" resource group and all resource under it.

  ![image](https://github.com/user-attachments/assets/ea81fac5-37b8-4bc6-b462-dc25b7963524)
  

- Step6: Once we deploy, run and test we need to clean up the azure resources so that we can avoid charging.
    <pre>
         azd down
    </pre>
This will ask confirmation to delete all respources. select Y <br/>
This will delete all resources uner resource group and resource group.



## GEN AI Symantic Searach

What is Ollama and LLama?

Ollama is a plateform that simplifies the process of running Large Language Model (LLM) locally on your machine. While LLama is the family of open source LLMs developed by Meta. Think of Ollama as a tool to run Llama models, making them more accessible for local use.
<br/>
<b>Ollama:</b> <br/>
<u>Definition:</u> <br/>
Ollama is a tool designed to run LLMs locally, providing a user-friendly interface for downloading, managing, and interacting with these models. <br/><br/>
Functionality:<br/>
It simplifies the process of setting up and running LLMs by handling tasks like model downloads, managing the environment, and providing an API for interacting with the model. <br/><br/>
Key Features:<br/>
Local Execution: Allows users to run LLMs on their own computers, without relying on cloud services. 
Simplified Model Management: Provides a user-friendly way to download, manage, and update different LLMs. 
Open Source: Ollama is an open-source project, allowing for community contributions and customization. <br/><br/>
Under the Hood:<br/>
Ollama often uses llama.cpp, a C++ implementation, to handle the actual inference and generation of text from the LLMs. <br/><br/>
<b>Llama:</b><br/>
<u>Definition:</u><br/>
Llama is a family of open-source LLMs developed by Meta AI. These models are designed for various natural language processing tasks, such as text generation, translation, and question answering.<br/><br/>
Types of Llama Models:<br/>
Llama models come in different sizes (e.g., 7B, 13B, 65B parameters) and with different training approaches (e.g., foundation models, instruction-tuned models).<br/><br/>
Accessibility:<br/>
Llama models are made available to researchers and developers under a license that promotes responsible AI practices.<br/><br/>
Use Cases:<br/>
Llama models can be used in various applications, including:<br/>
- Chatbots and conversational AI.
- Text summarization and generation.
- Code generation. 

In essence: Ollama provides a way to easily run Llama models (or other supported LLMs) on your local machine, making it easier to experiment with and integrate these models into your own applications without relying on cloud infrastructure. 
<br/>

![image](https://github.com/user-attachments/assets/88d40111-1359-4d38-992c-e17995f83266)


![image](https://github.com/user-attachments/assets/ee80689a-0f5c-4b94-988d-866f484ffe0f)

This is how we register our OLLama container and Llama, this will download Ollama container and then install Llama 3.2 model inside of the Ollama container. <br/>

Ollama, Lamma with Ollama's open web UI we can  easily implement a AI search functionality, but it is Aspire side, we need to implement it in the Web api for that we use Microsoft.Extension.AI and Microsoft.Extension.AI.Abstractions, thease a abstract layer that communicate with Ollama/Lamma. 

![image](https://github.com/user-attachments/assets/56473952-f07e-4198-a635-a85aa29e1709)


When we use Microsoft.Extension.AI.Abstractions, which will communicate various LLM Clients and AI services such as Semantic Kernal, Open AI, LLM Communitoity Packages, Azure AI interface, Ollama and Github Models. We can now use Ollama for local development and then without changing anuy code we can change it to use Azure Open Ai.

![image](https://github.com/user-attachments/assets/520a10bb-f18a-4c6b-9ed7-9efca721e5cc)

![image](https://github.com/user-attachments/assets/eb763cb2-c12f-45d9-9c5f-86da6ce1898a)


## Semantic Product Search with Vector Embedding and Vector DB

 ### What is a Vector Database?
 A vector database is a specialized database that stores and manages data represented as high-dimensional vectors (numerical representations). It's designed for efficient similarity searches, allowing you to find data points that are semantically similar to a given query vector. Veactor are numerical representation that capture the semantic meaning of data.<br/>

<b> Vector Embeddings:</b><br/>
Unstructured data like text, images, or audio is first converted into numerical vectors (embeddings) that capture its semantic meaning. <br/><br/>
<b>Similarity Search:</b><br/>
Vector databases use algorithms like k-nearest neighbors (kNN) to find the most similar vectors to a query vector. <br/><br/>
<b>High-Dimensionality:</b><br/>
These databases are optimized to handle large amounts of data in high-dimensional spaces. <br/><br/>

<b>Applications:</b><br/>
Vector databases are widely used in applications like: <br/>

<b>Semantic Search:</b> Finding documents or content that are semantically related to a query. <br/>
<b>Recommender Systems:</b> Suggesting similar products, movies, or music based on user preferences.<br/> 
<b>Image and Text Retrieval:</b> Searching for images or text that match a given query. <br/>
<b>Retrieval-Augmented Generation (RAG):</b> Improving large language model (LLM) responses by providing them with relevant context from external data. <br/>


![image](https://github.com/user-attachments/assets/ffb09353-d0bf-4bf1-8dbd-fb447a63bff0)

![image](https://github.com/user-attachments/assets/60967843-8d26-422e-8552-c0b68c403613)


### What is a Vector?
A vector is a methematical object that has both Mahnitude and direction, represented as a list of numbers: [1.2,3.4,-0.8]. Vectors are used to represent complex data in a way that AI models can process, nunbericalsummaries of information. Instead of saying "It's round, orange andsweet"  encode these feature numbercally in a vector : [roundess:0.9, color:0.8, sweetness: o.7]

### What is Vector Embeddings?

Dense numberical representations of data, capture the sematic meaning of text, image, audio or other data type.

 Step1 :Input Data -->  Start with raw data like a sentance, an image or a sound file <br/>
 Step2 : Use an AI Embedding Model --> Pass the data through an AI model, like a Trasformer model <br/>
 Step3 : Outpur Embedding  --> Transfors the input into a vecor embedding list of numbers <br/>

 ![image](https://github.com/user-attachments/assets/aae0c67b-df16-4edb-b550-ebf0e830d604)

 ![image](https://github.com/user-attachments/assets/33dc6bf6-6cec-4c82-9bc7-b909f12245ee)

 ![image](https://github.com/user-attachments/assets/90a5fca4-56ba-4551-b75e-c75c45dabfe7)
 

![image](https://github.com/user-attachments/assets/f076397f-6d12-4cc7-abb0-8772b5026d90)

![image](https://github.com/user-attachments/assets/85f84459-ea0f-4646-821c-da1320785fae)

![image](https://github.com/user-attachments/assets/3732b1bd-a20c-4a21-8e56-5e12f6a2ff67)




