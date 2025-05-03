# Script PowerShell para configurar git e enviar commits para o GitHub

# Inicializa o repositório git local (se ainda não inicializado)
git init

# Configura o usuário git
git config user.name "j0hnWeider"
git config user.email "johnweider.tj@gmail.com"

# Adiciona o repositório remoto (substitua se já existir)
git remote remove origin
git remote add origin https://github.com/j0hnWeider/OrderFlow.git

# Adiciona todos os arquivos para commit
git add .

# Cria o commit com mensagem
git commit -m "Initial commit: Created microservices projects with basic setup, Dockerfiles, and docker-compose configuration"

# Envia o commit para o branch main (ou master)
git push -u origin main
