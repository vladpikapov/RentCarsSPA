create database RestCarsDB;
use RestCarsDB;
create table Drivers
(
	NumberDriverLicense nvarchar(10) primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	BirthDate date not null
	 
);

create table Cars
(
	RegistrationNumber nvarchar(8) check (RegistrationNumber like N'[1-4][1-4][1-4][1-4][À-ß][À-ß]-[1-7]') primary key,
	Mark nvarchar(20) not null,
	Model nvarchar(10) not null,
	CarClass nvarchar(1) not null,
	YearOfIssue date not null
	
);

create table Orders
(
	Id int identity (1,1) primary key,
	StartDate date not null,
	EndDate date not null,
	Comment nvarchar(200),
	DriverLicense nvarchar(10) foreign key references Drivers(NumberDriverLicense),
	CarId nvarchar(8) foreign key references Cars(RegistrationNumber)
);
alter table Orders add constraint
BadDate check(EndDate>StartDate);