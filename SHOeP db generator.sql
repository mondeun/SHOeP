use SHOeP;

create table Customers
(
	CustomerId int identity primary key,
	FirstName nvarchar(64) not null,
	LastName nvarchar(64) not null,
	Email nvarchar(64) not null unique,
	Phone nvarchar(12),
	Address nvarchar(64),
	Zip nvarchar(5),
	City nvarchar(64),
	Password nvarchar(64) not null,
	salt nvarchar(15) not null
)

insert into Customers
values
('Adam', 'White', 'heisenberg@toughguy.com', 077797485631, 'Tr�nggatan 3', '26135', 'Landskrona', 'DElu65PBkvZIi56Tb+rwoT6JhK/hUseFUEUywlXrJ7U=', 'o3tM/AbZTwYX4Q=='),
('Larry', 'Dent', 'goldmemer@tumblrina.com', 069641334154, 'Bakregatan 9', '78451', 'Sundsvall', 'XFOgV0Hs8Q1UYyatdyvaTgOFXT7EPyzo73VFfNWhoR0=', 'd3hog7+ujEYtWw==')

create table Shipping
(
	ShippingId int identity primary key,
	CompanyName nvarchar(64) not null,
	Charge decimal not null
)

insert into Shipping
Values
('PostNord', 0.0),
('UPS', 35),
('DHL', 50)

create table Stock
(
	StockId int identity primary key,
	Quantity int not null,
	QuantityChangedDate datetime not null
)

insert into Stock
values
(10, '2016-09-03 12:13:00'),
(1, '2016-08-29 15:00:00'),
(3, '2016-09-03 14:12:53'),
(0, '2016-05-18 16:38:12')

create table Models
(
	ModelId int identity primary key,
	Brand nvarchar(64) not null,
	ModelName nvarchar(64) not null,
	Material nvarchar(64) not null,
	Category nvarchar(64) not  null,
	ShoeType nvarchar(64) not null,
	Picture nvarchar(128) not null,
	Description nvarchar(256) not null,
	Price decimal not null
)

insert into Models
values
('Nike', 'Air', 'Textile', 'Male', 'Sneakers', 'nike00.png', 'AAABlablablabla', 599),
('Nike', 'Jordan', 'Textile', 'Female', 'Sneakers', 'adidas00.png', 'BBBBlablablabla', 489),
('Ecco', 'Lord', 'Leather', 'Male', 'Boots', 'ecco00.png', 'CCCBlablablabla', 999.99),
('Adidas', 'Russian', 'Textile', 'Male', 'Sneakers', 'ecco00.png', 'DDDBlablablabla', 450)

create table Shoes
(
	ShoeId int identity primary key,
	StockId int not null foreign key references Stock(StockId),
	ModelId int not null foreign key references Models(ModelId),
	Color nvarchar(16) not null,
	Size int not null
)

insert into Shoes
values
(1, 1, 'Green', 42),
(2, 2, 'Black', 40),
(3, 3, 'Black', 45),
(4, 4, 'Red', 42)

create table Orders
(
	OrderId int identity primary key,
	OrderNumber nvarchar(12) not null,
	CustomerId int not null foreign key references Customers(CustomerId),
	ShippingId int not null foreign key references Shipping(ShippingId),
	OrderDate datetime not null,
	DeliveryDate datetime,
	TotalPrice decimal not null,
	Status nvarchar(32) not null
)

insert into Orders
values
('985645128728', 1, 2, '2016-09-21 13:24:00', null, 2599, 'Packaging')

create table OrderLines
(
	OrderId int not null foreign key references Orders(OrderId),
	ShoeId int not null foreign key references Shoes(ShoeId),
	Quantity int not null,
	Amount decimal not null,
	Discount decimal
	primary key(OrderId, ShoeId)
)

insert into OrderLines
values
(1, 3, 2, 0, 20),
(1, 1, 1, 0, 30)
