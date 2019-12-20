create table Seller(
	ID uuid PRIMARY KEY,
	CompanyName Varchar(100),
	Street Varchar(100),
	City Varchar(100),
	PostalCode varchar(7),
	BankName varchar(100),
	BankAccountNumber varchar(26),
	Bankswift varchar(10),
	NIP varchar(10)
);

create table Customer(
ID uuid PRIMARY KEY,
ID_Organization uuid,
Name varchar(100),
Surname varchar(100),

);

create table CustomerOrganization(
ID uuid PRIMARY KEY,
Name varchar(100),
Street varchar(100),
City varchar(100),
PostalCode varchar(7),
Nip varchar(10)
);

create table Product(
ID uuid PRIMARY KEY,
Name varchar(100),
NetPrice decimal(2),
VatRate int(2),
VatValue decimal(2),
GrossValue decimal(2)
);

