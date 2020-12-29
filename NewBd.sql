
CREATE TABLE Сотрудник(
 id_Сотрудника int PRIMARY KEY NOT NULL,
 Фамилия nvarchar(30) NOT NULL,
 Имя nvarchar(30) NOT NULL,
 Отчество nvarchar(30) NOT NULL,
)
GO

CREATE TABLE ТИП_Товара(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[type_name] nvarchar(30) NOT NULL,
)
GO
CREATE TABLE Приставки(
	id int PRIMARY KEY NOT NULL,
	[Type] nvarchar(20),
	Nositeli nvarchar(90) NOT NULL,
	Wifi nvarchar(10) NOT NULL
)
GO
CREATE TABLE Ноутбуки(
	id int PRIMARY KEY NOT NULL,
	Seria nvarchar(40) NOT NULL,
	Seria_Proc nvarchar(40) NOT NULL,
	TypeSystem nvarchar(20),
	VideoKart_Type nvarchar(30) NOT NULL,
	HardMemory int NOT NULL,
	HardDrive nvarchar(10) NOT NULL
)
GO
CREATE TABLE Телефоны(
	id int PRIMARY KEY NOT NULL,
	[Ruler] nvarchar(20) NOT NULL,
	Memory int NOT NULL,
	HardMemory int NOT NULL,
	Diagonal float NOT NULL,
	Тechnology nvarchar(20) NOT NULL
)
GO
CREATE TABLE Планшеты(
	id int PRIMARY KEY ,
	System_Type nvarchar(20) NOT NULL,
	Memory int NOT NULL,
	HardMemory int NOT NULL,
	Diagonal float NOT NULL,
	Matrix nvarchar(20) NOT NULL
)
GO
CREATE TABLE Телевизоры(
	id int PRIMARY KEY NOT NULL,
	Diagonal float NOT NULL,
	Razreshenie nvarchar(20) NOT NULL,
	Smart_TV nvarchar(10) NOT NULL
)
GO
CREATE TABLE Наушники(
	id int  PRIMARY KEY NOT NULL,
	Device_Type nvarchar(30) NOT NULL,
	Connection_Type nvarchar(30) NOT NULL,
	Device_Construction nvarchar(30) NOT NULL
)
GO
CREATE TABLE Видеотехника(
	id int PRIMARY KEY NOT NULL,
	[Power] nvarchar(30) NOT NULL,
	USB nvarchar(10) NOT NULL,
	Bluetooth nvarchar(10) NOT NULL
)
GO
CREATE TABLE Товар(
	id_Товара int Identity(1,1) PRIMARY KEY NOT Null,
	[name] nvarchar(70) NOT NULL,
	price float NOT NULL,
	[Image] nvarchar(70) NOT NULL
)
GO

CREATE TABLE Иметь(
	id int Identity(1,1) PRIMARY KEY NOT Null,
	id_Заказа int NOT NULL,
	id_Сотрудника int NOT NULL,
)
GO

CREATE TABLE Заказ(
	id_Заказа int Identity(1, 354) PRIMARY KEY NOT NULL,
	[Date] datetime NOT NULL
)
GO
CREATE TABLE Покупатель(
	id_Покупателя int Identity(1,1) PRIMARY KEY NOT Null,
	Фамилия nvarchar(30) NOT NULL,
	Имя nvarchar(30) NOT NULL,
	Отчество nvarchar(30) NOT NULL,
	[Login] nvarchar(30) NOT NULL,
	[Password] nvarchar(30) NOT NULL
)
GO

CREATE TABLE Korzina(
	id int IDENTITY (1,1),
	[Image] nvarchar(70) NOT NULL,
	[Name] nvarchar(70) NOT NULL,
	Price nvarchar(30) NOT NULL
)
GO




ALTER TABLE Иметь
WITH CHECK ADD CONSTRAINT FK_Иметь_id_Сотрудника FOREIGN KEY (id_Сотрудника)
REFERENCES Сотрудник(id_Сотрудника)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Иметь
WITH CHECK ADD CONSTRAINT FK_Иметь_id_Заказа FOREIGN KEY (id_Заказа)
REFERENCES Заказ (id_Заказа)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Заказ
ADD id_Покупателя int
GO


ALTER TABLE Заказ
WITH CHECK ADD CONSTRAINT FK_Заказ_id_Покупателя FOREIGN KEY(id_Покупателя)
REFERENCES Покупатель(id_Покупателя)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Товар 
ADD id_Type int NOT NULL
GO

ALTER TABLE Товар
WITH CHECK ADD CONSTRAINT FK_Товар_id_Type FOREIGN KEY(id_Type)
REFERENCES ТИП_Товара(id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE ТИП_Товара
ADD id_Телефона int 
GO
ALTER TABLE ТИП_Товара
ADD id_Наушников int 
GO
ALTER TABLE ТИП_Товара
ADD id_Телевизора int 
GO
ALTER TABLE ТИП_Товара
ADD id_Видеотехники int 
GO
ALTER TABLE ТИП_Товара
ADD id_Ноутбука int 
GO
ALTER TABLE ТИП_Товара
ADD id_Планшета int 
GO
ALTER TABLE ТИП_Товара
ADD id_Приставки int 
GO


ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Телефона FOREIGN KEY(id_Телефона)
REFERENCES Телефоны(id)
ON UPDATE CASCADE
GO

ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Планшета FOREIGN KEY(id_Планшета)
REFERENCES Планшеты(id)
ON UPDATE CASCADE
GO

ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Телевизора FOREIGN KEY(id_Телевизора)
REFERENCES Телевизоры(id)
ON UPDATE CASCADE
GO

ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Приставки FOREIGN KEY(id_Приставки)
REFERENCES Приставки(id)
ON UPDATE CASCADE
GO

ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Ноутбука FOREIGN KEY(id_Ноутбука)
REFERENCES Ноутбуки(id)
ON UPDATE CASCADE
GO

ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Наушников FOREIGN KEY(id_Наушников)
REFERENCES Наушники(id)
ON UPDATE CASCADE
GO

ALTER TABLE ТИП_Товара
WITH CHECK ADD CONSTRAINT FK_ТИП_Товара_id_Видеотехники FOREIGN KEY(id_Видеотехники)
REFERENCES Видеотехника(id)
ON UPDATE CASCADE
GO




INSERT INTO Планшеты(id, System_Type, Memory, HardMemory, Diagonal, Matrix) VALUES
(10,'Android', 16, 4, 10.4,N'Эквилибрированная'),
(11,'Mac OS', 64, 8, 11.4,N'Плазменная'),
(12,'Android', 12, 5, 9.4,N'Синегренная')
GO
INSERT INTO Ноутбуки(id, Seria,TypeSystem, Seria_Proc, VideoKart_Type, HardMemory, HardDrive) VALUES
(7,'Apple MacBook Air 13 (2020)', 'Mac OS', 'Core-i3',N'Встроенная', 8, 'SSD'),
(8,'HP EliteBook 850 G3 (2020)', 'Windows', 'Core-i5',N'Встроенная', 8, 'HDD+SSD'),
(9,'Lenovo Yoga 720', 'Windows', 'Core-i5',N'Дискретная', 8, 'SSD')
GO
INSERT INTO Телевизоры(id, Diagonal, Razreshenie, Smart_TV) VALUES
(19, 55 , '3840x2160',N'Есть'),
(20, 50 , '3840x2160',N'Есть'),
(21, 32 , '1366x768',N'Нет')
GO

INSERT INTO Видеотехника(id, Power, Bluetooth, USB) VALUES
(4,N'300 Вт', N'Есть',N'Есть'),
(5,N'300 Вт', N'Нет', N'Есть'),
(6,N'300 Вт',N'Есть',N'Нет')
GO
INSERT INTO Телефоны(id, Ruler, Diagonal,Memory, HardMemory, Тechnology) VALUES
(1,'iPhone 7 Plus',  5.5 , 32, 3,'IPS'),
(2,'Samsung Galaxy A30',  6.4 , 32, 3,'AMOLED'),
(3,'Huawei P30',   6.1 , 128, 6,'OLED')
GO

INSERT INTO Приставки(id, Nositeli, Type, Wifi) VALUES
(16,'microSD, USB', N'Медиаплеер', N'Есть'),
(17,'APE, BMP, FLAC, JPEG, PNG, WMA, MKV, MP3, WMV, MOV', N'Медиаплеер', 'Есть'),
(18,'SD, USB', N'Медиаплеер', N'Есть')
GO

INSERT INTO Наушники(id, Device_Type, Device_Construction, Connection_Type) VALUES
(13,N'Наушники с микрофоном', N'Внутриканальные', N'Беспроводное '),
(14, N'Наушники с микрофоном', N'Внутриканальные', N'Беспроводное '),
(15,N'Наушники с микрофоном', N'Вставные', N'Беспроводное ')
GO
INSERT INTO ТИП_Товара(type_name,id_Видеотехники, id_Наушников, id_Ноутбука, id_Планшета, id_Приставки, id_Телевизора , id_Телефона) VALUES
(N'Телефон1', NUll, NULL,NULL, NULL, NULL, NULL, 1 ),
(N'Телефон2', NUll, NULL,NULL, NULL, NULL, NULL, 2 ),
(N'Телефон3', NUll, NULL,NULL, NULL, NULL, NULL, 3 ),
(N'Видеотехника1', 4, NULL,NULL, NULL, NULL, NULL, NULL ),
(N'Видеотехника2',5, NULL,NULL, NULL, NULL, NULL,NULL ),
(N'Видеотехника3', 6, NULL,NULL, NULL, NULL, NULL, NULL),
(N'Ноутбук1', NUll, NULL, 7, NULL, NULL, NULL, NULL ),
(N'Ноутбук2', NUll, NULL, 8, NULL, NULL, NULL, NULL),
(N'Ноутбук3', NUll, NULL, 9, NULL, NULL, NULL, NULL ),
(N'Планшет1', NUll, NULL,NULL, 10, NULL, NULL,NULL),
(N'Планшет2', NUll, NULL,NULL, 11, NULL, NULL, NULL ),
(N'Планшет3', NUll, NULL,NULL, 12, NULL, NULL, NULL ),
(N'Наушники1', NUll, 13,NULL, NULL, NULL, NULL, NULL ),
(N'Наушники2', NUll, 14,NULL, NULL, NULL, NULL,NULL ),
(N'Наушники3', NUll, 15,NULL, NULL, NULL, NULL, NULL ),
(N'Приставка1', NUll, NULL,NULL, NULL, 16, NULL,NULL ),
(N'Приставка2', NUll, NULL,NULL, NULL, 17, NULL, NULL ),
(N'Приставка3', NUll, NULL,NULL, NULL, 18, NULL, NULL ),
(N'Телевизор1', NUll, NULL,NULL, NULL, NULL, 19,NULL),
(N'Телевизор2', NUll, NULL,NULL, NULL, NULL, 20,NULL),
(N'Телевизор3', NUll, NULL,NULL, NULL,NULL , 21, NULL )

GO

INSERT INTO Товар(name, price , Image, id_Type) VALUES 
(N'Смартфон APPLE iPhone 7 Plus 32GB Silver A1784', 1349.10, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Phone1.png', 1),
(N'Смартфон SAMSUNG Galaxy A30 (SM-A305F) 3GB/32GB синий', 539.5, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Phone2.png', 2),
(N'Смартфон HUAWEI P30 (ELE-L29) светло-голубой', 1259.20, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Phone3.png', 3),
(N'Планшет SAMSUNG Galaxy Tab S4 LTE 64GB (черный)', 1759.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Pad1.png', 10),
(N'Планшет SAMSUNG Galaxy Tab S4 LTE 64GB (серебристый)', 1759.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Pad2.png', 11),
(N'Планшет Lenovo Yoga Tab 3 10 X50M 2G 16GBL-UA (ZA0K0025UA)', 449.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Pad3.png', 12),
(N'Наушники SAMSUNG Galaxy Buds SM-R170NZKASER', 269.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\HearPod1.png', 13),
(N'Наушники XIAOMI AirDots White (ZBW4420GL)', 89.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\HearPod2.png', 14),
(N'Наушники JBL ENDURPEAK BLU', 199.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\HearPod3.png', 15),
(N'Телевизор SAMSUNG UE50NU7097UXRU', 1080.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Tv1.png', 19),
(N'Телевизор TCL 32ES560', 539.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Tv2.png', 20),
(N'Телевизор SAMSUNG UE50RU7200UXRU', 1299.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Tv3.png', 21),
(N'Ноутбук Apple MacBook Air 13" A2179 (MWTJ2RU/A)', 3699.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\NootBook1.png', 7),
(N'Ноутбук HP EliteBook 850 G3 W5A00AW', 2888.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\NootBook2.png', 8),
(N'Ноутбук Lenovo Yoga 720-15IKB 80X70015RU', 3499.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\NootBook3.png', 9),
(N'Медиаплеер INVIN IPC002 1G/8Gb', 139.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Pristavka1.png', 16),
(N'Смарт приставка MECOOL M8S PRO W', 133.9, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Pristavka2.png', 17),
(N'Медиаплеер Rombica Smart Stick Quad v001 SSQ-A0400', 133.0, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\Pristavka3.png', 18),
(N'Звуковая панель LG SJ3', 649.99, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\VidTech1.png', 4),
(N'Звуковая панель SONY HT-CT290', 759.99, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\VidTech2.png', 5),
(N'Звуковая панель SONY HT-CT291', 759.99, N'C:\Users\hachimon\Desktop\KPIAP курсач\Images\VidTech3.png', 6)
GO

INSERT INTO Сотрудник(Фамилия, Имя, Отчество, id_Сотрудника) VALUES 
(N'Петренко',N'Михаил',N'Генадьевич',1),
(N'Романенко',N'Кириил',N'Анатольевич',2),
(N'Cмирнов',N'Абигель',N'Семенович',3),
(N'Лобанов',N'Алексей',N'Никитич',4),
(N'Ростовцев',N'Кириил',N'Артемович',5),
(N'Ляшкевич',N'Агнет',N'Петров',6)
GO
INSERT INTO Покупатель(Фамилия, Имя, Отчество, Login, Password) VALUES
(N'Агафонов',N'Денис',N'Семенович','Sayonara' ,'534ahuAkbar'),
(N'Косаренко',N'Григой',N'Александрович','Sayonara2' ,'534a4324kbar'),
(N'Белый',N'Парсихат',N'Сергеевич','Sayonara3' ,'5654fwe'),
(N'Мазут',N'Игорь',N'Анатольевич','Sayonara4' ,'345ger'),
(N'Сесилион',N'Евгений',N'Антович','Sayonara5' ,'23463htkbar'),
(N'Кудрявцева',N'Эсмеральда',N'Григорьевна','Sayonara6' ,'5461fh5'),
(N'Абаденков',N'Никита',N'Анатольевич','Sayonara7' ,'53562rf'),
(N'Абакулин',N'Кириил',N'Константинович','Sayonara8' ,'hgfj43'),
(N'Илышев',N'Сергей',N'Денисович','Koir' ,'ghrw53'),
(N'Ильвохин',N'Максим',N'Анатольевич','Hameed' ,'423gey5'),
(N'Нещеретова',N'Абрамия',N'Анатольевич','Jojil' ,'746g3fs'),
(N'Нещенко',N'Генадий',N'Анатольевич','Nurik' ,'55f3r'),
(N'Нижанская',N'Ольга','Яновна','Sanchez' ,'234kbar'),
(N'Сиволан',N'Шрэк',N'Анатольевич', 'Romil',  '535tghuAkbar'),
(N'Сиволоцкая',N'Анна',N'Анатольевна','Youre', '453kbar'),
(N'Торбаев',N'Кириил',N'Анатольевич','Retuzin', 'Aeyr'),
(N'Торбахов',N'Кириил',N'Анатольевич','Lorut','yeAkbar'),
(N'Капля',N'Кириил',N'Анатольевич', 'Jutinop', 'wtbar,48.5'),
(N'Зуев',N'Кириил',N'Анатольевич','Nikaragua', 'Aerrtar'),
(N'Рыков',N'Кириил',N'Анатольевич','Bender', 'AgsuAkbar');
GO

