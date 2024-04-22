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
