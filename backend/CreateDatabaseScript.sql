CREATE USER invoices_user WITH ENCRYPTED PASSWORD 'invoices';

CREATE DATABASE invoices;
GRANT ALL PRIVILEGES ON DATABASE invoices TO invoices_user;

create table RegisterSeller(
	ID uuid PRIMARY KEY,
	SellerID uuid,
	CustomerName varchar(100),
	CompanyName Varchar(100),
	Street Varchar(100),
	City Varchar(100),
	PostalCode varchar(7),
	BankName varchar(100),
	BankAccountNumber varchar(26),
	Bankswift varchar(10),
	ModifyDate Date,
	NIP varchar(10)
);

create table Seller(
	ID uuid PRIMARY KEY,
	CompanyName Varchar(100),
	Street varchar(100),
	City Varchar(100),
	PostalCode varchar(7),
	BankName varchar(100),
	BankAccountNumber varchar(26),
	Bankswift varchar(10),
	ModifyDate Date,
	NIP varchar(10)
);

create table RegisterCustomer(
	ID uuid PRIMARY KEY,
	CustomerID uuid,
	ID_Organization uuid,
	Name varchar(100),
	Surname varchar(100),
	ModifyDate Date
);

create table Customer(
	ID uuid PRIMARY KEY,
	ID_Organization uuid,
	Name varchar(100),
	Surname varchar(100),
	ModifyDate Date
);

create table RegisterCustomerOrganization(
	ID uuid PRIMARY KEY,
	ID_CustomerOrganization uuid,
	Name varchar(100),
	Street varchar(100),
	City varchar(100),
	PostalCode varchar(7),
	Nip varchar(10),
	ModifyDate Date
);

create table CustomerOrganization(
	ID uuid PRIMARY KEY,
	Name varchar(100),
	Street varchar(100),
	City varchar(100),
	PostalCode varchar(7),
	Nip varchar(10),
	ModifyDate Date,
);
create table Product(
	ID uuid PRIMARY KEY,
	InvoiceId uuid,
	Name varchar(100),
	NetPerUnit decimal(9,2),
	GrossPerUnit decimal(9,2),
	NetPrice decimal(9,2),
	VatRate int,
	VatValue decimal(9,2),
	GrossValue decimal(9,2),
	Currency varchar(100),
	Quantity int
);

create table Invoice(
	ID uuid Primary key,
	CustomerID uuid,
	Number int,
	NumberYear int,
	CreationDate Date,
	SaleDate Date,
	PaymentType varchar(100),
	PaymentDeadline Date,
	NetToPay decimal(9),
	GrossToPay decimal(9),
	Paid decimal(9),
	LeftToPay decimal(9),
	Remarks varchar(100),
	Status int,
	SellerId uuid,
	Currency Varchar(100),
	VatRate int
);
create table Jobs(
	ID uuid PRIMARY KEY,
	occurrenceDate Date,
	type varchar(100),
	InvoiceId uuid
);
create table Files(
	ID uuid PRIMARY KEY,
	occuranceDate Date,
	typa varchar(30),
	fileName varchar(100),
	invoiceId varchar(100),
	path varchar(100)
);