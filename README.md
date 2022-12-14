# Sobre.
 Aplicar convenções/padrões de microservicos utilizando tecnicas para buscar resiliencia, eficiencia e robustez.

# Patterns e conceitos a serem utilizados.
  - Gateway: sera utilizado como proxy reverso como porta de entrada para se connectar com os microservicos responsavel por centralizar as requisições.
  - Service Discovery: Será responsavel por resolver problemas de mapeamento de endereços de rede para
    reconhecer novas instancias de maquinas por meio de ip e porta pois se estamos sendo gerenciado por um provedor cloud as maquinas contem ips dinamicos.
    Caso uma maquina pare de funcionar o service discovery por meio de health-check é responsavel por desregistrar a maquina para que você sempre tenha dados     consistentes. 
  - Service Register : Sera armazenados todas as maquinas por meio de ip e porta.
  - Clean Architecture 
  
# Tecnologias.
  - .NETCORE 6
    - ORM : EFCore
  - Ocelot 
     - Api Gateway com ocelot
     - Service Discovery utilizando consul
  - Cache Distribuido
    - Redis
  - Docker
     - docker-compose

 # Rodando a imagem da aplicação local :
   - Entre na raiz do projeto
   - execute: <b>docker-compose up --build</b>
     
 # Ideia de arquitetura.
 ![image](https://user-images.githubusercontent.com/25963928/204695372-54afd564-81c8-4512-83b6-23df181cda87.png)
    
 # Links:   
   - http://localhost:8500/ui/dc1/services
   - http://localhost:8080/gateway/negocio

 # Links de apis e referencias
   - https://developer.hashicorp.com/consul/api-docs/agent/service
   - https://ocelot.readthedocs.io/en/latest/features/servicediscovery.html
   - https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot
   - https://www.youtube.com/watch?v=Rx4YXkrAXD0&t=1310s
