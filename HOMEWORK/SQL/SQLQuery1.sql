
--- UNION

select Category.Name, sum(Product.Id)
from Category, Product
where Category.Id = Product.CategoryID
group by Category.Name

union

select Supplier.Name, sum(Product.Id)
from Supplier, Product, Delivery
where Supplier.Id = Delivery.SupplierID and Delivery.ProductID = Product.Id
group by Supplier.Name


--- INNER JOIN

select Category.Name, sum(Product.Id)
from Category inner join  Product on  Category.Id = Product.CategoryID
group by Category.Name
union
select Supplier.Name, sum(Product.Id)
from (Supplier inner join Delivery on Supplier.Id = Delivery.SupplierID) inner join Product on Delivery.ProductID = Product.Id
group by Supplier.Name

select Category.Name, sum(Product.Id)
from Category inner join  Product on  Category.Id = Product.CategoryID
group by Category.Name
union
select 'XXXXXXX', sum(Product.Id)
from (Supplier inner join Delivery on Supplier.Id = Delivery.SupplierID) 
		       inner join Product on Delivery.ProductID = Product.Id
group by Supplier.Name


--- UPDATE

--update Category
--set Name = 'Keyboards'
--where Name = 'Клавиатуры'

--update Product
--set Price = Price*2

---  DELETE

--delete from Product
--where Amount =0


--- INSERT

--insert into Supplier(Name,AddressID)
--values('New supplier', 13)

----  Добавление всех Производителей в таблицу Поставщиков

--insert into Supplier(Name, AddressID)
--select Producer.Name, Producer.AddressID
--from Producer