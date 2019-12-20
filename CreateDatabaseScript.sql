CREATE USER invoices_user WITH ENCRYPTED PASSWORD 'invoices';

CREATE DATABASE invoices;
GRANT ALL PRIVILEGES ON DATABASE invoices TO invoices_user;



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

create table Invoice(
	ID uuid Primary key,
	CustomerID uuid,
	Number int(10),
	CreationDate DateTime,
	SaleDate DateTime,
	PaymentType varchar(100),
	PaymentDeadline varchar(100),
	ToPay decimal(2),
	Paid decimal(2),
	LeftToPay decimal(2),
	Remarks varchar(100),
	Status int(2),
	SellerId uuid
);
