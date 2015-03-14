use libraryForNET14
go

--create trigger Decrement_Books_Quantity_S
--on S_Cards
--for Insert
--as
--Declare @InsBookId int
--Select @InsBookId=Id_Book from inserted
--update Books set Books.Quantity -=1 where Books.Id = @InsBookId	

alter trigger Increment_Books_Quantity_S
on S_Cards
for update
as
Declare @InsBookId int
Declare @DateIn smalldatetime
Select @InsBookId=Id_Book from inserted 
Select @DateIn=DateIn from inserted
if (@DateIn != null)
begin
raiserror 
update Books set Books.Quantity = Books.Quantity + 1 where Books.Id = @InsBookId	
end

--create trigger Decrement_Books_Quantity_T
--on T_Cards
--for Insert
--as
--Declare @InsBookId int

--Select @InsBookId=Id_Book from inserted

--update Books set Books.Quantity -=1 where Books.Id = @InsBookId	


insert into S_Cards(Id_Student,Id_Book,DateOut,DateIn,Id_Lib) 
values (3,1,'20140313',null,1)

--insert into T_Cards(Id_Teacher,Id_Book,DateOut,DateIn,Id_Lib) 
--values (3,1,'20140313',null,1)

update S_Cards set DateIn = '20140313'
where Id =13

select Quantity from Books Where Books.Id =1

select * from S_Cards Where Id_Book =1