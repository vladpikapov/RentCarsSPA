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
	RegistrationNumber nvarchar(8) check (RegistrationNumber like N'[1-4][1-4][1-4][1-4][¿-ﬂ][¿-ﬂ]-[1-7]') primary key,
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

insert into Drivers
values('4756932612','Ivan','Ivanov','1987-07-23'),
('3583713261','Petr','Petrov','1992-12-21'),
('2364271852','Roman','Butko','1996-02-03'),
('1957328943','Egor','Romashkin','2000-11-17'),
('1230543575','Elena','Bertosh','1975-02-07'),
('7328128496','Maxim','Maximov','1981-11-11');

insert into Cars
values(N'3211¿¬-2','BMW','X6','J','2019-01-01'),
(N'4212 Õ-3','Audi','A8','F','2018-01-01'),
(N'1321ÃÕ-1','Ford','Mondeo','D','2007-01-01'),
(N'1111¿ -7','Mersedes-Bebz','AMG GT','E','2014-01-01'),
(N'3333¿Õ-5','Skoda','Octavia','C','2013-01-01');