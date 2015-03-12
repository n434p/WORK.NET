--use libraryForNET14
--go 

--create procedure MyFirstProc

--as
--select *
--from Books

--exec MyFirstProc


--alter procedure MyProc
--@name nvarchar(50)
--as
--select *
--from Books
--where Name like @name

--exec MyProc '%Visual%'


--alter procedure MyProc
--@name nvarchar(50),
--@id int output
--as
--select @id = Id
--from Books
--where Name like @name

--declare @id int
--set @id =0

--exec MyProc '%Visual%', @id output
--select @id 


--alter procedure MyProc
--@name nvarchar(50) output,
--@id int output
--as
--select @id = Id, @name = Name
--from Books
--where Name like @name

--declare @id int, @name nvarchar(50)
--set @id =0
--set @name = '%Vis%'

--exec MyProc @name output, @id output
--select @id, @name 


--create procedure SumNumb
--@a int, @b int as
--declare @c int
--set @c = @a+@b
--return @c

--declare @res int
--exec @res = SumNumb 2,3
--select @res

--create procedure Factorial
--@n int
--as 
--	declare @res int
--	set @res =1
--	while @n !=1
--		begin
--			set @res = @res*@n
--			set @n= @n-1
--		end
--		return @res

--declare @n int
--exec @n = Factorial 5
--select @n

---- FUNCTIONS

--create function MyFunc
--(
--	@n int
--)
--returns nvarchar(20)
--as
--begin
--declare @res nvarchar(20)
--	if @n = 0
--		set @res = 'zero'
--	else
--		if (@n%2) =1
--		set @res =  'not integer'
--		else
--		set @res =  'integer'
--return @res
--end

--declare @r nvarchar(20)
--exec @r = MyFunc 0
--select @r

--select dbo.MyFunc(2


---  Функция принимае Категории и возвращает кол-во книг єтой категории

--create function OtherF
--(
--	@name nvarchar(20)
--)
--returns int
--as
--begin
--	declare @c int
--	set @c=0

--	select @c = count(Books.Id)
--	from Books inner join Categories on Books.Id_Category = Categories.Id
--	where Categories.Name = @name 

--	return @c
--end

--select dbo.OtherF('Visual basic')
--select dbo.OtherF('HTML')

---- Odnoзапросная функция


--create function FuncOneQuerry()
--returns table
--as
--return ( select * from Books)

--select * from FuncOneQuerry()


---- Multiquerry function

create function Test()
returns @tbAuthor table ( name1 nvarchar(50), count1 int)
as
begin

declare @temp table (name2 nvarchar(50), count2 int ) 

insert @temp
select Authors.FirstName + ' ' + Authors.LastName , count(Books.Id)
from (Authors inner join Books on Authors.Id = Books.Id_Author) inner join T_Cards on T_Cards.Id_Book = Books.Id
group by Authors.FirstName, Authors.LastName

insert @temp
select Authors.FirstName + ' ' + Authors.LastName, count(Books.Id)
from (Authors inner join Books on Authors.Id = Books.Id_Author) inner join S_Cards on S_Cards.Id_Book = Books.Id
group by Authors.FirstName, Authors.LastName

insert @tbAuthor
select t.name2, sum(t.count2)
from @temp as t
group by t.name2

 return 
 end

 select *
 from dbo.Test()

