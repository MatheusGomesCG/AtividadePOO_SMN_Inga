# Prova - POO (6 horas)

## 1- Sistema Bancário

### Objetivo

Garantir a integridade financeira da conta e a segurança das informações do cliente através do princípio de encapsulamento de dados.

### Regras de Negócio do Sistema

#### 🔒 Integridade do Saldo

- O saldo da conta bancária é um dado protegido e não pode ser alterado diretamente por qualquer usuário ou sistema externo.
- A alteração do saldo só pode ocorrer por meio de operações válidas: `Depósito` ou `Saque`.

#### 🧾 Dados Obrigatórios da Conta

Toda conta deve obrigatoriamente possuir:

- Titular (Nome)
- CPF válido

#### ➕ Processamento de Crédito (Depósito)

- Ao efetuar um depósito válido, o valor deve ser somado ao saldo atual.
- A operação deve ser registrada imediatamente no histórico da conta.

#### 💰 Verificação de Fundos

- Caso o saldo seja insuficiente, a operação deve ser negada, retornando uma mensagem de erro adequada.

#### ➖ Processamento de Débito (Saque)

- Só deverá ser efetuado se o saldo for suficiente e o valor for válido.
- A operação deve ser registrada imediatamente no histórico.

#### 📊 Extrato Bancário

- O sistema deve manter um histórico privado e completo de todas as operações, incluindo sucessos e falhas.
- O cliente deve poder visualizar um extrato, contendo:
  - Tipo da operação
  - Valor
  - Ordenação por valor em ordem decrescente
- Deve existir também um extrato consolidado agrupado por tipo de movimentação.

## 2- Sistema de Funcionários

### Contexto

Uma empresa tem diferentes tipos de funcionários com comportamentos distintos para cálculo de bônus e férias.

### Requisitos

- Tipos de funcionário: `Gerente`, `Desenvolvedor` e `Estagiário`
- Cada tipo tem cálculo de bônus **diferente**
- Implementar método CalcularsalarioLiquido()
- Criar método para gerar relatório de folha de pagamento
- Salário base R$1.518,00

### Regras de Negócio do Sistema

#### 💰 Cálculo de Bônus por Tipo de Funcionário

- Gerente:

  - Bônus = Salário base × 20%

- Desenvolvedor:

  - Bônus = Salário base × 15%

- Estagiário:
  - Bônus = Salário base × 5% (apenas se período probatório concluído)
  - Sem bônus durante os primeiros 3 meses

### 📊 Cálculo de Salário Líquido

- Salário Líquido = Salário Base + Bônus - INSS (8%)
- O sistema deve calcular de forma que cada tipo de funcionário implemente sua própria lógica se necessário.

### 📋 Relatório de Folha de Pagamento

**O sistema deve gerar um relatório contendo:**

- Nome, CPF e cargo do funcionário
- Salário bruto
- Descontos (INSS)
- Salário líquido
- Mês e ano de referência
- Data de geração do relatório

O relatório deve estar **ordenado por salário líquido em ordem decrescente** quando múltiplos funcionários forem listados.

#### ✅ Validações Obrigatórias

- Salário base não pode ser menor que o salário mínimo vigente
- Tipo de funcionário deve ser um dos tipos válidos
- Data de admissão não pode ser posterior à data atual
- Bônus não pode ser negativo

## 3- Sistema de Pagamentos

### Objetivo 🎯

Permitir que a loja online aceite múltiplas formas de pagamento de maneira flexível e extensível, sem a necessidade de modificar o código central da compra para cada novo método, utilizando o princípio de **Polimorfismo**.

### Contexto/Requisitos

- Utilizar interface.
- Serão aceitos os seguinte métodos de pagamento: **Cartão de Crédito**, **PIX**, **Boleto** e **Transferência Bancária**.
- Cada método de pagamento deve ter regras distintas para **taxa** e **tempo de processamento**.
- O pedido aceita qualquer método de pagamento.
- Ao finalizar compra do pedido, o uso de método de pagamento deve funcionar para todos os tipos.

### Regras de Negócio do Sistema

#### ⚙️ Processamento e Taxas

| Forma de Pagamento    | Taxa Aplicada                            | Tempo Estimado de Processamento |
| :-------------------- | :--------------------------------------- | :------------------------------ |
| **Cartão de Crédito** | **2.5%** sobre o valor total.            | **24 horas** úteis.             |
| **PIX**               | **0.5%** sobre o valor total (desconto). | **10 segundos**.                |
| **Boleto**            | **1.0%** sobre o valor total.            | **48 horas** úteis.             |
| **Transferência**     | Nenhuma.                                 | **1 hora** útil.                |

- O `CalcularValorComTaxa` deve ser implementado por cada forma de pagamento.
- Deve existir um método que retorna o tempo de processamento para cada tipo de pagamento.

#### 🛒 Finalização da Compra

- O pedido deve possuir um método para finalizar o pagamento, exibindo as informações resultantes: valor final com taxas aplicadas, tempo estimado de processamento e o status atual da transação..

## 4- Sistema de Veículos

### Objetivo 🛣️

Gerenciar diferentes tipos de veículos com características e comportamentos únicos, simplificando a complexidade para o sistema principal através do princípio de **Abstração**.

### Contexto/Requisitos

- Serão aceitos veículos como: **Carro**, **Moto** e **Caminhão**.
- Cada tipo de veículo deve ter um comportamento único para: `CalcularConsumoCombustivel()`.
- Implementar propriedades específicas por tipo de veículo:
  - Número de portas para carro
  - Cilindrada para moto
  - Carga máxima em quilos para caminhão.
- Criar um método genérico, à sua escolha, que funcione com **qualquer veículo** sem conhecer seus detalhes internos.

### Regras de Negócio do Sistema

#### ⛽ Consumo de Combustível

- Deve existir um método para `CalcularConsumoCombustivel()` que possui uma lógica **diferente** para cada tipo de veículo.
  - **Carro:** 16 - Número de portas (km/L).
  - **Caminhão:** 5 / ( Carga máxima / 1000 ) (km/L).
  - **Moto:** 40.000 / Cilindradas (km/L).

#### 📃 Relatório Unificado de Frotas

- O sistema deve conseguir gerar um relatório de frotas, listando todos os veículos (Carro, Moto, Caminhão) e exibindo suas características específicas através de um **único método genérico**.
