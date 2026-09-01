# 📨 Notificações Multicanais API

API REST para envio de notificações em múltiplos canais, desenvolvida em .NET 10 com Clean Architecture.

## ✅ Canais Suportados

| Canal | Provedor | Status |
|-------|----------|--------|
| Email | SendGrid | ✅ |
| WhatsApp | Z-API | ✅ |
| SMS | Twilio | ✅ |

## 🚀 Como Usar

### Base URL
https://notficacoesmultcanais.onrender.com/scalar/#tag/notificacao


### Endpoints

#### POST /api/notificacao/enviar
Envia uma notificação para o canal especificado.

**Request Email:**
```json
{
    "destinatario": "email@exemplo.com",
    "mensagem": "Sua mensagem aqui",
    "assunto": "Assunto do email",
    "tipo": 0
}
```

**Request WhatsApp:**
```json
{
    "destinatario": "5511999999999",
    "mensagem": "Sua mensagem aqui",
    "assunto": "",
    "tipo": 2
}
```

**Request SMS:**
```json
{
    "destinatario": "+5511999999999",
    "mensagem": "Sua mensagem aqui",
    "assunto": "",
    "tipo": 1
}
```

**Tipos:**
| Valor | Canal |
|-------|-------|
| 0 | Email |
| 1 | SMS |
| 2 | WhatsApp |

**Response:**
```json
{
    "id": "guid",
    "destinatario": "email@exemplo.com",
    "mensagem": "Sua mensagem aqui",
    "assunto": "Assunto do email",
    "tipo": "Email",
    "status": "Enviado",
    "dataCriacao": "2026-08-29T10:00:00Z",
    "dataEnvio": null,
    "sucesso": true,
    "mensagemErro": null
}
```

#### GET /api/notificacao/status/{id}
Retorna o status de uma notificação pelo ID.

## 🏗️ Tecnologias

- .NET 10
- Clean Architecture
- Entity Framework Core
- PostgreSQL
- SendGrid (Email)
- Twilio (SMS)
- Z-API (WhatsApp)
- Docker
- Render

## 📁 Estrutura do Projeto

NotficacoesMultcanais/
├── NotficacoesMultcanais/ # API
├── NotficacoesMultcanais.Application/ # UseCases, DTOs, Interfaces
├── NotficacoesMultcanais.Domain/ # Entities, Validators, Exceptions
└── NotficacoesMulticanais.Infraestructure/ # Repositórios, DbContext, Services

## 💰 Planos — RapidAPI

| Plano | Preço | Requests |
|-------|-------|----------|
| Básico | Grátis | 100/mês |
| Pró | $9/mês | 5.000/mês |
| Ultra | $29/mês | 20.000/mês |

👉 [Acessar no RapidAPI](#)

## 📜 Licença

MIT License

---

Desenvolvido por [Welinton Batista](https://github.com/welinton19) 🇧🇷
