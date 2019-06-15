/************************  in�cio cria��o tabelas ************************/

CREATE TABLE Cargo (
  Cargo_Id   INT          NOT NULL,
  Cargo_Desc VARCHAR(255) NOT NULL,
  CONSTRAINT PK_Cargo PRIMARY KEY CLUSTERED (Cargo_Id)
);
GO

-- ENCRIPTAR COLUNA SENHA
CREATE TABLE Usuario (
  Usuario_Id    INT          NOT NULL,
  Usuario_Login VARCHAR(50)  NOT NULL,
  Usuario_Senha VARCHAR(255) NOT NULL,
  CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED (Usuario_Id)
);
GO

CREATE TABLE EstabelecimentoEndereco (
  EstabelecimentoEndereco_Id          INT          NOT NULL,
  EstabelecimentoEndereco_Logradouro  VARCHAR(100) NOT NULL,
  EstabelecimentoEndereco_Numero      VARCHAR(10)  NOT NULL,
  EstabelecimentoEndereco_Bairro      VARCHAR(50)  NOT NULL,
  EstabelecimentoEndereco_Cidade      VARCHAR(100) NOT NULL,
  EstabelecimentoEndereco_Estado      CHAR(2)      NOT NULL,
  EstabelecimentoEndereco_Complemento VARCHAR(255) NOT NULL,
  EstabelecimentoEndereco_CEP         VARCHAR(20)  NOT NULL,
  CONSTRAINT PK_EstabelecimentoEndereco PRIMARY KEY CLUSTERED (EstabelecimentoEndereco_Id)
);
GO

-- COLOCAR CNPJ �NICO
CREATE TABLE Estabelecimento (
  Estabelecimento_Id         INT          NOT NULL,
  Estabelecimento_Nome       VARCHAR(200) NOT NULL,
  Estabelecimento_CNPJ       VARCHAR(20)  NOT NULL,
  Estabelecimento_Telefone   VARCHAR(20)  NOT NULL,
  Estabelecimento_Celular    VARCHAR(20)  NOT NULL,
  Estabelecimento_Email      VARCHAR(300) NOT NULL,
  EstabelecimentoEndereco_Id INT NOT NULL,
  CONSTRAINT PK_Estabelecimento PRIMARY KEY CLUSTERED (Estabelecimento_Id)
);
GO

CREATE TABLE FuncionarioEndereco (
  FuncionarioEndereco_Id          INT          NOT NULL,
  FuncionarioEndereco_Logradouro  VARCHAR(100) NOT NULL,
  FuncionarioEndereco_Numero      VARCHAR(10)  NOT NULL,
  FuncionarioEndereco_Bairro      VARCHAR(50)  NOT NULL,
  FuncionarioEndereco_Cidade      VARCHAR(100) NOT NULL,
  FuncionarioEndereco_Estado      CHAR(2)      NOT NULL,
  FuncionarioEndereco_Complemento VARCHAR(255) NOT NULL,
  FuncionarioEndereco_CEP         VARCHAR(20)  NOT NULL,
  CONSTRAINT PK_FuncionarioEndereco PRIMARY KEY CLUSTERED (FuncionarioEndereco_Id)
);
GO

-- COLOCAR CPF �NICO
CREATE TABLE Funcionario (
  Funcionario_Id            INT          NOT NULL,
  Funcionario_Nome          VARCHAR(255) NOT NULL,
  Funcionario_CPF           VARCHAR(20)  NOT NULL,
  Funcionario_RG            VARCHAR(20)  NOT NULL,
  Funcionario_DtNascimento  DATE         NOT NULL,
  Funcionario_Telefone      VARCHAR(20)  NOT NULL,
  Funcionario_Celular       VARCHAR(20)  NOT NULL,
  Funcionario_Email         VARCHAR(300) NOT NULL,
  FuncionarioEndereco_Id    INT          NOT NULL,
  CONSTRAINT PK_Funcionario PRIMARY KEY CLUSTERED (Funcionario_Id)
);
GO

CREATE TABLE FuncionarioEstabelecimento (
  Funcionario_Id      INT NOT NULL,
  Estabelecimento_Id  INT NOT NULL,
  CONSTRAINT PK_FuncionarioEstabelecimento PRIMARY KEY CLUSTERED (Funcionario_Id, Estabelecimento_Id)
);
GO

CREATE TABLE UsuarioFuncionario (
  Usuario_Id     INT NOT NULL,
  Funcionario_Id INT NOT NULL,  
  CONSTRAINT PK_UsuarioFuncionario PRIMARY KEY CLUSTERED (Usuario_Id, Funcionario_Id)
);
GO

CREATE TABLE FuncionarioCargo (
  Funcionario_Id              INT  NOT NULL,
  Cargo_Id                    INT  NOT NULL,
  FuncionarioCargo_DtAdmissao DATE NOT NULL
  CONSTRAINT PK_FuncionarioCargo PRIMARY KEY CLUSTERED (Funcionario_Id, Cargo_Id)
);
GO

CREATE TABLE ClienteEndereco (
  ClienteEndereco_Id          INT          NOT NULL,
  ClienteEndereco_Logradouro  VARCHAR(100) NOT NULL,
  ClienteEndereco_Numero      VARCHAR(10)  NOT NULL,
  ClienteEndereco_Bairro      VARCHAR(50)  NOT NULL,
  ClienteEndereco_Cidade      VARCHAR(100) NOT NULL,
  ClienteEndereco_Estado      CHAR(2)      NOT NULL,
  ClienteEndereco_Complemento VARCHAR(255) NOT NULL,
  ClienteEndereco_CEP         VARCHAR(20)  NOT NULL,
  CONSTRAINT PK_ClienteEndereco PRIMARY KEY CLUSTERED (ClienteEndereco_Id)
);
GO

-- COLOCAR CPF �NICO
CREATE TABLE Cliente (
  Cliente_Id            INT          NOT NULL,
  Cliente_Nome          VARCHAR(255) NOT NULL,
  Cliente_CPF           VARCHAR(20)  NOT NULL,
  Cliente_RG            VARCHAR(20)  NOT NULL,
  Cliente_DtNascimento  DATE         NOT NULL,
  Cliente_Telefone      VARCHAR(20)  NOT NULL,
  Cliente_Celular       VARCHAR(20)  NOT NULL,
  Cliente_Email         VARCHAR(300) NOT NULL,
  ClienteEndereco_Id    INT          NOT NULL,
  CONSTRAINT PK_Cliente PRIMARY KEY CLUSTERED (Cliente_Id)
);
GO

CREATE TABLE DiaSemana (
  DiaSemana_Id   INT         NOT NULL,
  DiaSemana_Desc VARCHAR(13) NOT NULL,
  CONSTRAINT PK_DiaSemana PRIMARY KEY CLUSTERED (DiaSemana_Id)
);
GO

CREATE TABLE Horario (
  Horario_Id  INT     NOT NULL,
  Horario_De  TIME(0) NOT NULL,
  Horario_Ate TIME(0) NOT NULL,
  CONSTRAINT PK_Horario PRIMARY KEY CLUSTERED (Horario_Id)
);
GO

CREATE TABLE DiaSemanaHorario (
  DiaSemana_Id INT NOT NULL,
  Horario_Id   INT NOT NULL,
  CONSTRAINT PK_DiaSemanaHorario PRIMARY KEY CLUSTERED (DiaSemana_Id, Horario_Id)
);
GO

CREATE TABLE Agendamento (
  Agendamento_Id           INT          NOT NULL,
  Agendamento_Desc         VARCHAR(200) NOT NULL,
  Agendamento_DataCadastro DATETIME     NOT NULL,
  CONSTRAINT PK_Agendamento PRIMARY KEY CLUSTERED (Agendamento_Id)
);
GO

CREATE TABLE AgendamentoCliente (
  Agendamento_Id  INT NOT NULL,
  Cliente_Id      INT NOT NULL,
  CONSTRAINT PK_AgendamentoCliente PRIMARY KEY CLUSTERED (Agendamento_Id, Cliente_Id)
);
GO

CREATE TABLE AgendaEstabelecimento (
  Agendamento_Id     INT NOT NULL,
  Estabelecimento_Id INT NOT NULL,
  CONSTRAINT PK_AgendaEstabelecimento PRIMARY KEY CLUSTERED (Agendamento_Id, Estabelecimento_Id)
);
GO

CREATE TABLE AgendamentoDiaSemanaHorario (
  Agendamento_Id                   INT      NOT NULL,
  DiaSemana_Id                     INT      NOT NULL,
  Horario_Id                       INT      NOT NULL,
  AgendamentoDiaSemanaHorario_Data DATETIME NOT NULL,
  CONSTRAINT PK_AgendamentoDiaSemanaHorario PRIMARY KEY CLUSTERED (Agendamento_Id, DiaSemana_Id, Horario_Id)
);
GO

/************************  fim cria��o tabelas ************************/

/************************  in�cio cria��o fk's tabelas ************************/

ALTER TABLE Estabelecimento
  ADD CONSTRAINT FK_Estabelecimento_EstabelecimentoEndereco
FOREIGN KEY (EstabelecimentoEndereco_Id) REFERENCES EstabelecimentoEndereco (EstabelecimentoEndereco_Id);
GO

ALTER TABLE Funcionario
  ADD CONSTRAINT FK_Funcionario_FuncionarioEndereco
FOREIGN KEY (FuncionarioEndereco_Id) REFERENCES FuncionarioEndereco (FuncionarioEndereco_Id);
GO

ALTER TABLE FuncionarioEstabelecimento
  ADD CONSTRAINT FK_FuncionarioEstabelecimento_Funcionario
FOREIGN KEY (Funcionario_Id) REFERENCES Funcionario (Funcionario_Id),
      CONSTRAINT FK_FuncionarioEstabelecimento_Estabelecimento
FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id);
GO

ALTER TABLE UsuarioFuncionario
  ADD CONSTRAINT FK_UsuarioFuncionario_Usuario
FOREIGN KEY (Usuario_Id) REFERENCES Usuario (Usuario_Id),
      CONSTRAINT FK_UsuarioFuncionario_Funcionario
FOREIGN KEY (Funcionario_Id) REFERENCES Funcionario (Funcionario_Id);
GO

ALTER TABLE FuncionarioCargo
  ADD CONSTRAINT FK_FuncionarioCargo_Funcionario
FOREIGN KEY (Funcionario_Id) REFERENCES Funcionario (Funcionario_Id),
      CONSTRAINT FK_FuncionarioCargo_Cargo
FOREIGN KEY (Cargo_Id) REFERENCES Cargo (Cargo_Id);
GO

ALTER TABLE Cliente
  ADD CONSTRAINT FK_Cliente_ClienteEndereco 
FOREIGN KEY (ClienteEndereco_Id) REFERENCES ClienteEndereco (ClienteEndereco_Id);
GO

ALTER TABLE DiaSemanaHorario
  ADD CONSTRAINT FK_DiaSemanaHorario_DiaSemana
FOREIGN KEY (DiaSemana_Id) REFERENCES DiaSemana (DiaSemana_Id),
      CONSTRAINT FK_DiaSemanaHorario_Horario
FOREIGN KEY (Horario_Id) REFERENCES Horario (Horario_Id);
GO

ALTER TABLE AgendamentoCliente
  ADD CONSTRAINT FK_AgendamentoCliente_Agendamento
FOREIGN KEY (Agendamento_Id) REFERENCES Agendamento (Agendamento_Id),
      CONSTRAINT FK_AgendamentoCliente_Cliente
FOREIGN KEY (Cliente_Id) REFERENCES Cliente (Cliente_Id);
GO

ALTER TABLE AgendaEstabelecimento
  ADD CONSTRAINT FK_AgendaEstabelecimento_Agendamento
FOREIGN KEY (Agendamento_Id) REFERENCES Agendamento (Agendamento_Id),
      CONSTRAINT FK_AgendaEstabelecimento_Estabelecimento
FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id);
GO

ALTER TABLE AgendamentoDiaSemanaHorario
  ADD CONSTRAINT FK_AgendamentoDiaSemanaHorario_Agendamento
FOREIGN KEY (Agendamento_Id) REFERENCES Agendamento (Agendamento_Id),
      CONSTRAINT FK_AgendamentoDiaSemanaHorario_DiaSemana
FOREIGN KEY (DiaSemana_Id) REFERENCES DiaSemana (DiaSemana_Id),
      CONSTRAINT FK_AgendamentoDiaSemanaHorario_Horario
FOREIGN KEY (Horario_Id) REFERENCES Horario (Horario_Id);
GO

/************************  fim cria��o fk's tabelas ************************/