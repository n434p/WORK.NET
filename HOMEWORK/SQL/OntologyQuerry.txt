create database OntologyDB
go 

alter database OntologyDB
modify file(name = OntologyDB, size = 2MB, filegrowth = 1MB)
go

use OntologyDB
go

create table Concept
(
ConceptID int not null primary key identity(1,1),
SourceName nvarchar(20) not null, 
ConceptKey nvarchar(20) not null,
Value nvarchar(10) not null
 )
 go

 create table UserAccount
(
UserAccountID int not null primary key identity(1,1),
UserName nvarchar(20) not null, 
Name nvarchar(20) not null,
Email nvarchar(20),
UserPassword nvarchar(16) not null,
IsAdministrator bit not null,
Affiliation nvarchar(20) not null
 )
 go

  create table Ontology
(
OntologyID int not null primary key identity(1,1),
OntoName nvarchar(20) not null, 
UserAccountID int not null foreign key references UserAccount(UserAccountID),
StatusOntology nvarchar(10) not null,
Documentation nvarchar(20) not null
 )
 go

 create table Context
(
ContextID int not null primary key identity(1,1),
TermLabel nvarchar(20) not null, 
OntologyID int not null foreign key references Ontology(OntologyID),
 )
 go

  create table TermContext
(
TermContextID int not null primary key identity(1,1),
TermLabel nvarchar(20) not null, 
ConceptID int not null foreign key references Concept(ConceptID),
ContextID int not null foreign key references Context(ContextID), 
 )
 go

 create table Lexon
(
LexonID int not null primary key identity(1,1),
TermLabel1 nvarchar(20) not null, 
TermLabel2 nvarchar(20) not null, 
RoleLabel nvarchar(20) not null,
ContextID int not null foreign key references Context(ContextID),
 )
 go

 create table OntoVersion
(
VersionID int not null primary key identity(1,1),
OntologyID int not null foreign key references Ontology(OntologyID),
UserAccountID int not null foreign key references UserAccount(UserAccountID),
CreateDate datetime not null, 
Documentation nvarchar(20) not null,
VersionLabel nvarchar(10) not null
 )
 go
