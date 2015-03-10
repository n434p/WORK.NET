/****** Script for SelectTopNRows command from SSMS  ******/

--1.Получить информацию о всех поставщиках, товары которых продавались более 2-х раз.



--2.Вывести самый популярный товар в магазине, то есть тот, который больше всего продавался.

--3.Если общее количество товаров всех категорий считать за 100%, то необходимо посчитать 
--сколько товаров каждой категории(в процентном соотношении) продавалось.


--4.Используя подзапросы вывести название всех товаров, которые поставлялись только 
--опеределнным поставщиком.

--5.Используя подзапрос вывести список товаров, их цены и категории, которые поставлялись 
--только одним поставщиком.

--6.Используя подзапросы вывести название поставщиков, которые не поставляли указанный товар.

--7.Используя подзапросы вывести на экран список производителей, которые находятся в той же 
--стране что и определенный поставщик.

--8.Написать запрос, который выводить на экран список поставщиков одной страны(например, Украины)


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


--11.Вывести на экран название товара, поставщика, который его поставлял, его полный адрес (в одном поле),
-- категория которых "Жесткие диски" и "Ноутбуки". Учитывать при выборке , только те товары которые поставлялись ЧП

select Product.Name+' '+Supplier.Name+' '+Country.Name+' '+Address.Street+' '+Address.Town+' '+Address.ZIP
from Product,Supplier,Country, Address



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




