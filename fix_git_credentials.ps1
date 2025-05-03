# Script PowerShell para limpar credenciais antigas do GitHub e configurar usuário correto

# Remove credenciais antigas do GitHub do gerenciador de credenciais do Windows
cmdkey /delete:git:https://github.com

# Configura usuário git localmente no repositório
git config user.name "j0hnWeider"
git config user.email "johnweider.tj@gmail.com"

Write-Host "Credenciais antigas removidas. Usuário git configurado para j0hnWeider."
Write-Host "Agora, ao fazer push, será solicitado autenticação. Use seu token de acesso pessoal (PAT) do GitHub."
