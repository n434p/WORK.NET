/****** Script for SelectTopNRows command from SSMS  ******/

--1.Получить информацию о всех поставщиках, товары которых продавались более 2-х раз.

select Supplier.Name
from Supplier,
(
select Supplier.Id as id, count(ProductListSale.ProductID) as c
from Supplier, Delivery, Product, ProductListSale
where Supplier.Id = Delivery.SupplierID and Delivery.ProductID = Product.Id and Product.Id = ProductListSale.ProductID group by Supplier.Id) as T
where T.c >2 and Supplier.Id = T.id


--2.Вывести самый популярный товар в магазине, то есть тот, который больше всего продавался.
select Product.Name
from Product
where Product.Id =
(
	select Product.Id as id
	from Product, ProductListSale
	where Product.Id = ProductListSale.ProductID group by Product.Id 

	having count(ProductListSale.ProductID) > any
		(
		select count(ProductListSale.ProductID)
		from Product, ProductListSale
		where Product.Id = ProductListSale.ProductID group by Product.Id
		)
)


--3.Если общее количество товаров всех категорий считать за 100%, то необходимо посчитать 
--сколько товаров каждой категории(в процентном соотношении) продавалось.

 select Category.Name, (sum(ProductListSale.Amount)*100 / (select sum(Product.Amount) from Product))
 from Category, ProductListSale, Product
 where Category.Id = Product.CategoryID and ProductListSale.ProductID = Product.Id
 Group by Category.Name


--4.Используя подзапросы вывести название всех товаров, которые поставлялись только 
--опеределнным поставщиком.
select Product.Name, Supplier.Name
from Supplier, Product, Delivery,
	(select Product.Id as n, Supplier.Id as s
	from Product, Supplier, Delivery
	where Product.Id = Delivery.ProductID and Supplier.Id = Delivery.SupplierID
	group by Product.Id, Supplier.Id
	) as T
where 
not exists 
	(select Product.Id
	from Product, Supplier, Delivery
	where Product.Id = T.n and Supplier.Id != T.s 
	and Product.Id = Delivery.ProductID 
	and Supplier.Id = Delivery.SupplierID
	)
and Product.Id = Delivery.ProductID and Supplier.Id = Delivery.SupplierID and T.n = ProductID and T.s = SupplierID
group by Product.Name, Supplier.Name


--5.Используя подзапрос вывести список товаров, их цены и категории, которые поставлялись 
--только одним поставщиком.
select Product.Name, Supplier.Name
from Supplier, Product, Delivery,
	(select Product.Id as n, Supplier.Id as s
	from Product, Supplier, Delivery
	where Product.Id = Delivery.ProductID and Supplier.Id = Delivery.SupplierID
	group by Product.Id, Supplier.Id
	) as T
where 
not exists 
	(select Product.Id
	from Product, Supplier, Delivery
	where Product.Id = T.n and Supplier.Id != T.s 
	and Product.Id = Delivery.ProductID 
	and Supplier.Id = Delivery.SupplierID
	)
and Product.Id = Delivery.ProductID and Supplier.Id = Delivery.SupplierID and T.n = ProductID and T.s = SupplierID
group by Product.Name, Supplier.Name

--6.Используя подзапросы вывести название поставщиков, которые не поставляли указанный товар.

select Supplier.Name
from Supplier,
	(select Product.Id as n, Supplier.Id as s
	from Product, Supplier, Delivery
	where Product.Id = Delivery.ProductID and Supplier.Id = Delivery.SupplierID
	group by Product.Id, Supplier.Id
	) as T
where 
Supplier.Id not in
	(select Supplier.Id
	from Product, Supplier, Delivery
	where Product.Id = 2 
	and Product.Id = Delivery.ProductID 
	and Supplier.Id = Delivery.SupplierID
	group by Supplier.Id
	)
group by Supplier.Name

--7.Используя подзапросы вывести на экран список производителей, которые находятся в той же 
--стране что и определенный поставщик.

select Producer.Name, Country.Name
from Producer, Address, Country,
	( select Country.Id as cid
	from Country, Address, Supplier
	where Country.Id = Address.CountryID and Address.Id = Supplier.AddressID
	) as T
where Producer.AddressID = Address.Id 
and Address.CountryID in (T.cid) 
and Address.CountryID = Country.Id

--8.Написать запрос, который выводить на экран список поставщиков одной страны(например, Украины)

select Supplier.Name as sid
from Country, Address, Supplier
where Country.Id = Address.CountryID 
and Address.Id = Supplier.AddressID 
and Country.Name ='USA'

--9.Подсчитать количество поставщиков, товары которых поставлялись в период с ... по .... и не 
--были проданы. Используйте для этого EXISTS.

select count(Supplier.Id)
from Supplier, Delivery, Product
where
Product.Id not in 
(select ProductListSale.ProductID
from ProductListSale)
and Product.Id = Delivery.ProductID
and Supplier.Id = Delivery.SupplierID
and Delivery.DeliveryDate between '20140101' and '20140131'


--10.Выведите список производителей, которые находятся не в Украине. Отсортируйте выборку в 
--возрастающем порядке названий производителей. Для данного подзапроса не используйте объединения 
--таблиц, а только подзапросы и оператор EXISTS.

select Supplier.Name
from Supplier, Address, Country
where
Supplier.AddressID = Address.Id
and Country.Id = Address.CountryID
and Country.Name !='Ukraine'
order by Supplier.Name asc


--11.Вывести на экран название товара, поставщика, который его поставлял, его полный адрес (в одном поле),
-- категория которых "Жесткие диски" и "Ноутбуки". Учитывать при выборке , только те товары которые поставлялись ЧП

select Product.Name+' '+Supplier.Name+' '+Country.Name+' '+Address.Street+' '+Address.Town+' '+Address.ZIP
from Product,Supplier,Country, Address, Delivery, Category
where Category.Name in ('Жесткие диски','Ноутбуки') 
and Category.Id = Product.CategoryID
and Product.Id = Delivery.ProductID
and Delivery.SupplierID = Supplier.Id
and Supplier.AddressID = Address.Id
and Address.CountryID = Country.Id

--12.Используя подзапрос найти поставщика, товаров которого нет в продаже. Используйте для поиска оперторы ANY или SOME.

select Supplier.Name
from Supplier
where Supplier.Id = any
(
select Delivery.SupplierID
from Delivery, Product
where Delivery.ProductID = Product.Id and Product.Amount =0
)

--13.Выберите всех производителей, товаров которых в наличии больше, чем любого другого производителя на выбор.

select Producer.Name, sum(Product.Amount)
from Producer, Product
where Product.ProduceID = Producer.Id
group by Producer.Name
having sum(Product.Amount) >any
(
select sum(Product.Amount)
from Product
where Product.ProduceID = 2
)

--///14.Вывести информацию о том, товары каких производителей в базе данных не существует.Для вывода полноценной
-- информации воспользуйтесь внешним объединением.




--///15.Показать все товары, категорий "Материнские платы" и "Мониторы" и название поставщиков, которые 
--их поставляли. Использовать оператор UNION

select Supplier.Name
from Supplier, Delivery, Product
where Supplier.Id = Delivery.SupplierID
and Product.Id = Delivery.ProductID 
and Product.Id = any
(
select Product.Id 
from Product, Category
where Category.Id = Product.CategoryID
and Category.Name in ('Материнские платы','Мониторы')
)
union
select Product.Name 
from Product, Category
where Category.Id = Product.CategoryID
and Category.Name in ('Материнские платы','Мониторы')

--///16.Получить информацию о количестве поставщиков 2-х стран, товары которых присутствуют в базе данных.
-- При этом вывести отдельно полученную информацию и общую сумму всех поставщиков товаров. Воспользуйтесь 
--для этого операторами UNION и UNION ALL.




