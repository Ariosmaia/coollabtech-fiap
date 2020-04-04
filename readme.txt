PASSO 1
Ajustar arquivo "appsettings.json" com sua configuração de sql server

PASSO 2
Abrir Package Manager Console

PASSO 2.1
Selecionar projeto CoollabTech.Infra.CrossCutting.Identity e rodar comando: Update-Database -Context ApplicationDbContext

PASSO 2.2
Selecionar projeto CoollabTech.Infra.Data e rodar comando: Update-Database -Context CoollabTechContext