PRÉ-REQUISITOS
Sql Server 
NET Core 3.1 SDK

PASSO 1
Ajustar arquivo "appsettings.json" com sua configuração de sql server

PASSO 2
Abrir Package Manager Console

PASSO 2.1
Selecionar projeto CoollabTech.Infra.CrossCutting.Identity e rodar comando: Update-Database -Context ApplicationDbContext

PASSO 2.2
Selecionar projeto CoollabTech.Infra.Data e rodar comando: Update-Database -Context CoollabTechContext

PASSO 3
Testar parte web

Passo 4
Abrir Web Api "/swagger/index.html" 
Obs.: Qualquer dúvida olhar print-10 que é exibido como sugerimos que se realize navegação.

Passo 4.1
Realizar criação de usuário e pegar token gerado

Passo 4.2
Inserir no Authorize "Bearer + TokenGerado"

Passo 4.3
Navegar pelas apis