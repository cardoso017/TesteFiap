
Create database Fiap

Use Fiap

Create table Contato(
IdContato int identity primary key,
Nome varchar(50), 
FlAtivo bit 
)

Create Table Email(
IdEmail int identity primary key, 
Email varchar(50), 
FlAtivo bit ,
IdContato int Foreign key  references Contato(IdContato) )

Create table Telefone(
IdTelefone int identity primary key, 
Numero Varchar(20),
FlAtivo bit,
IdContato int Foreign key  references Contato(IdContato) )



