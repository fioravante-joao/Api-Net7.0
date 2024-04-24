# Api-Net7.0

# Tecnologias e recursos utilizados:
  * Projeto em NetCore 7.0
  * EF Core
  * SQLITE LocalDB
  * Migrations Habilitadas
  * Autenticação de usuários com Token JWT
  * Injeção de dependência para DB e Classe tarefas

# Objetivos desse projeto listado abaixo:

# CRUD de Tarefas: 
Crie, leia, atualize e exclua tarefas. 
Cada tarefa deve ter um título, uma descrição, uma data de criação e um status (pendente, em andamento, concluída). 

# Listagem de Tarefas: 
Os usuários devem ser capazes de listar todas as tarefas ou filtrá-las com base em seu status. 

# Autenticação e Autorização: 
A API suporta autenticação de usuários. 
  * Apenas os criadores das tarefas devem poder atualizá-las ou excluí-las. 
  * As tarefas devem ser visíveis para todos os usuários autenticados. 

# Documentação da api: 
Para documentação usei o Swagger pela simplicidade e facilidade.
![API](https://github.com/fioravante-joao/Api-Net7.0/assets/39463582/0e2db34b-d5e3-444e-a929-ce9ed4ffb4cb)

# Primeiros passos:
 * O projeto já vem pronto, basta clonar e em seguida abrir em seu visual studio 2022.
 * Abra a classe settings.cs e coloque uma hash de segurança com 61 caracteres na variável "Secret".
 * Ctrol + Shift + S para salvar a alteração e você está pronto para começar.
 * Ctrol + F5 para Executar o projeto, (se for solicitado certificado ssl, clique em instalar).
 * Você precisa usar o endPoint de (https://localhost:7235/v1/users/create) para criar seu usuário, (Utilizei o Postman para fazer as requisições).
   ![Create](https://github.com/fioravante-joao/Api-Net7.0/assets/39463582/ca861634-abd7-4caf-98c0-e5459cdbfc4d)

 * Em seguida pode usar o endPoint (https://localhost:7235/v1/users/login), (Utilizei o Postman para fazer as requisições).
   ![Login](https://github.com/fioravante-joao/Api-Net7.0/assets/39463582/80d03e4b-d7bf-4d2e-bf73-5cdfa3b846a8)
 * Agora já pode listar, cirar, editar e deletar suas tarefas.

# Obs:
Não coloquei um arquivo .Ignore por motivos de simplicidade desse projeto e para facilitar o uso para qualquer dev.
Também não escondi a chave Secret com o token por se tratar de um projeto que roda apenas localmente, mas se for utilizar esse ou utro projeto em produção altere e esconda o token do arquivo Secret.
