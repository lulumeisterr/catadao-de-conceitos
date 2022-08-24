# Sobre
 Aplicar convenções/padrões de microservicos utilizando
  
# Contexto para estudo
  Pensando na comunicação dos microserviços sera utilizado tecnicas para buscar
  resiliencia, eficiencia e robustez.

# Patterns e conceitos a serem utilizados.
 
 - Service Discovery : Será responsavel por resolver problemas de mapeamento de endereços de rede para
   reconhecer novas instancias de maquinas por meio de ip e porta pois se estamos sendo gerenciado por um provedor cloud as maquinas contem ips dinamicos.
   Caso uma maquina pare de funcionar o service discovery por meio de health-check é responsavel por desregistrar a maquina para que você sempre tenha dados consistentes.
 - Service Register : Sera armazenados todas as maquinas por meio de ip e porta.
 - Load Balance : O balanceamento de carga visa otimizar o uso de recursos, maximizar o throughput, minimizar o tempo de resposta e evitar a sobrecarga de qualquer recurso único

# Ideia de arquitetura

![baguncinha](https://user-images.githubusercontent.com/25963928/186300676-9ab6ee4e-1519-47d9-9ad2-cdc62b0fd649.png)
