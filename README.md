# README - Sistema de Gerenciamento de Tarefas

## Propósito do Sistema
O sistema tem como propósito fornecer uma API utilizando a arquitetura em camadas para gerenciar tarefas (to-do list) associadas a usuários e categorias. Ele permite que os usuários cadastrem, editem, excluam e listem suas próprias tarefas, mantendo uma separação entre as informações dos usuários, tarefas e categorias.

## Usuários do Sistema
- **Usuários regulares**: Podem criar, editar, excluir e listar suas próprias tarefas e categorias.

## Entidades
1. **Usuário**:
   - Representa os usuários do sistema, incluindo informações como nome de usuário, senha e detalhes de contato.
2. **Tarefa**:
   - Representa as tarefas criadas pelos usuários, incluindo informações como título, descrição, data de vencimento e status.
3. **Categoria**:
   - Representa as categorias às quais as tarefas podem estar associadas. Cada categoria possui um nome único e, opcionalmente, uma descrição.
4. **Histórico de Tarefas**:
   - Registra as alterações realizadas nas tarefas, incluindo informações como data e hora da modificação, tipo de operação realizada e usuário responsável pela alteração.

## Requisitos Funcionais

### RF 0001: Cadastro de Usuários
- **Descrição**: Permitir que novos usuários se cadastrem fornecendo informações como nome de usuário, senha e detalhes de contato.
  
### RF 0002: Autenticação de Usuários
- **Descrição**: Permitir que os usuários se autentiquem utilizando seus nomes de usuário e senhas.

### RF 0003: Cadastro de Tarefas
- **Descrição**: Permitir que os usuários autenticados cadastrem novas tarefas associadas às suas contas.
- **Campos**: Título, Descrição, Data de Vencimento, Status e Categoria.

### RF 0004: Edição de Tarefas
- **Descrição**: Permitir que os usuários editem as informações de suas próprias tarefas.
- **Campos Editáveis**: Título, Descrição, Data de Vencimento, Status e Categoria.

### RF 0005: Exclusão de Tarefas
- **Descrição**: Permitir que os usuários excluam suas próprias tarefas.

### RF 0006: Listagem de Tarefas
- **Descrição**: Permitir que os usuários listem todas as suas próprias tarefas.

### RF 0007: Cadastro de Categorias
- **Descrição**: Permitir que os usuários criem categorias para organizar suas tarefas.

### RF 0008: Edição de Categorias
- **Descrição**: Permitir que os usuários editem as informações de suas categorias.
- **Campos Editáveis**: Nome e Descrição da Categoria.

### RF 0009: Exclusão de Categorias
- **Descrição**: Permitir que os usuários excluam suas categorias, garantindo que nenhuma tarefa esteja associada a ela.

### RF 0010: Histórico de Tarefas
- **Descrição**: Registrar as alterações realizadas nas tarefas.
- **Informações Registradas**: Data e hora da modificação, tipo de operação realizada (criação, edição, exclusão) e usuário responsável pela alteração.
