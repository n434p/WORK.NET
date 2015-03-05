--select sum(Books.Price)/count(Id)
--from Books


--select avg(Books.Price)
--from Books


--select avg(Books.Price)
--from Books
--where Price is not null


--select min(Books.Price), max(Books.Price)
--from Books
--where Price is not null


--select Name, IdCategory, min(Price)
--from Books
--group by Name, IdCategory

--select Name, IdCategory, min(Price)
--from Books
--group by Name, IdCategory
--order by 1


--select Name
--from Books
--where Price = (select min(Price) from Books)


--select Name
--from Books, (select min(Price) as pr from Books) as Temp
--where Price = Temp.pr

--select Category.Name, count(Books.Id) as c
--from Category, Books
--where Category.Id = Books.IdCategory
--group by Category.Name 

--select tre.Name, tre.c
--from 
--(select Category.Name, count(Books.Id) as c
--from Category, Books
--where Category.Id = Books.IdCategory
--group by Category.Name ) as tre
--where tre.c<5


--select Name, min(Price)
--from Books
--where IdCategory <5
--group by Name
--having min(Price) > 40

