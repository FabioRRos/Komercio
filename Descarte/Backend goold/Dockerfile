# Usa uma imagem base leve com Go 1.25
FROM golang:1.25-alpine

# Define diretório de trabalho dentro do container
WORKDIR /app

# Copia todos os arquivos do projeto para dentro da imagem
COPY . .

# Faz download das dependências e compila o binário
RUN go mod download && \
    CGO_ENABLED=0 GOOS=linux go build -ldflags="-s -w" -o main ./cmd

# Expõe a porta que o Heroku usará automaticamente
EXPOSE 8080

# Comando que inicia o backend
CMD ["./main"]
