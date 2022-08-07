# RabbitMQDemoAPI
Este projeto foi criado com o objetivo de entender o funcionamento e a implementação da integração do RabbitMQ com serviços desenvolvidos na plataforma .NET 5.<br/>
A ideia aqui é simular um cenário de matricula acadêmica, este conta com dois serviços fictícios, o primeiro sendo o **serviço acadêmico** que, como o próprio nome já diz, lida com as questões acadêmicas do aluno durante a matricula (alocação em turmas, alocação nas disciplinas, dependencias), em determinado momento da matricula será necessário gerar as mensalidades do aluno esta será feita a partir do **serviço financeiro** que teria como responsabilidade neste caso gerar as mensalidades do aluno.<br/>
#### **É claro que estes serviços são apenas cascas, e não vão conter nenhuma implementação complexa, o objetivo deles é apenas entender o funcionamento e a implementação do RabbitMQ.**

## Requisitos
* RabbitMQ Server (Utilizei a versão 3.10.7);
* ErLang (Pré-Requisito para funcionamento do RabbitMQ Server);
* .NET 5 Runtime e ASP.NET Core Runtime (Utilizei a versão 5.0.17 para ambos instaladas a partir do Visual Studio 2019);
* SQL Server.

## Preparando o RabbitMQ Server
1. Inicie o intalador do RabbitMQ Server, caso não tenha a linguagem ErLang em seu computador o instalador do RabbitMQ providenciará uma versão da mesma;
2. Após o término da instalação vá até a pasta do RabbitMQ Server (***C:\Program Files\RabbitMQ Server\rabbitmq_server-<VERSÃO INSTALADA>\sbin***) e execute os seguintes comandos:
```.BAT
rabbitmq-plugins enable rabbitmq_management
net stop RabbitMQ
net start RabbitMQ
```
3. O painel do RabbitMQ pode ser acessado a partir do URL padrão: http://localhost:15672/ informando o **login** e **senha** padrão **guest**;

## Lembretes
1. Lembre-se de iniciar o RabbitMQ Server antes de fazer os testes;
2. Lembre-se também de executar as migrações de ambas as aplicações;
