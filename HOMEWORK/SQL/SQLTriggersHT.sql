--Написать такие триггера:
--Чтобы при взятии определенной книги, ее кол-во уменьшалось на 1.


alter trigger Decrement_Books_Quantity_S
on S_Cards
for Insert
as
Declare @InsBookId int
declare @q int
Select @InsBookId=Id_Book from inserted
select @q = Books.Quantity from Books where Books.Id = @InsBookId
if ( @q <= 0)
begin
print('Books quantity not valid!')
rollback transaction
end
else 
update Books set Books.Quantity -=1 where Books.Id = @InsBookId	

alter trigger Decrement_Books_Quantity_T
on T_Cards
after Insert
as
Declare @InsBookId int
Select @InsBookId=Id_Book from inserted
update Books set Books.Quantity -=1 where Books.Id = @InsBookId	

select Quantity from Books Where Books.Id =1

insert into S_Cards(Id_Student,Id_Book,DateOut,DateIn,Id_Lib) 
values (3,1,'20140313',null,1)

select Quantity from Books Where Books.Id =1

---Чтобы при возврате определенной книги, ее кол-во увеличивалось на 1.

alter trigger Increment_Books_Quantity_S
on S_Cards
after update
as
Declare @InsBookId int, @Date smalldatetime
Select @InsBookId=Id_Book from inserted 
Select @Date=DateIn from inserted
if (@Date is not null)
begin
update Books set Books.Quantity = Books.Quantity + 1 where Books.Id = @InsBookId	
end

alter trigger Increment_Books_Quantity_T
on T_Cards
after update
as
Declare @InsBookId int, @Date smalldatetime
Select @InsBookId=Id_Book from inserted 
Select @Date=DateIn from inserted
if (@Date is not null)
begin
update Books set Books.Quantity = Books.Quantity + 1 where Books.Id = @InsBookId	
end

select Quantity from Books Where Books.Id =1

update S_Cards set DateIn = '20140313'
where Id =12

select Quantity from Books Where Books.Id =1

--Чтобы нельзя было выдать книгу, которой уже нет в библиотеке (по кол-ву).

alter trigger BookQuantityCheck
on S_Cards
for insert
as
Declare @ind int
declare @q int
select @ind = Id_Book from inserted
select @q = Books.Quantity from Books where Books.Id = @ind
if ( @q <= 0)
begin
print('Books quantity not valid!')
rollback transaction
end
else commit transaction

select Books.Quantity from Books where Books.Id =2

insert into S_Cards(Id_Student,Id_Book,DateOut,DateIn,Id_Lib) 
values (3,2,'20140317',null,1)

select Books.Quantity from Books where Books.Id =2

--Чтобы нельзя было выдать более трех книг одному студенту.
--Чтобы при удалении книги, данные о ней копировались в таблицу Удаленные.
--Если книга добавляется в базу, она должна быть удалена из таблицы Удаленные.