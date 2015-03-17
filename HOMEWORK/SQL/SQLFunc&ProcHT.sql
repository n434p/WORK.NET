--�������� ����� �������� ���������:
--�������� �������� ���������, ��������� �� ����� ������ ���������, �� ������� �����.

alter procedure BorrowList as 
(
select Students.FirstName, Students.LastName
from Students, S_Cards
where S_Cards.Id_Student = Students.Id and S_Cards.DateIn is null
)

exec BorrowList

--�������� �������� ���������, ������������ ��� � ������� ������������, ��������� ���������� ���-�� ����.

alter procedure LibFav as
(
select Libs.FirstName+' '+Libs.LastName
from Libs, 
	(select Libs.Id as id
	from Libs, S_Cards, T_Cards
	where Libs.Id = T_Cards.Id_Lib 
	and Libs.Id = S_Cards.Id_Lib
	group by Libs.Id
	having count(Libs.Id) > any
		(
		select count(Libs.Id)
		from Libs, S_Cards, T_Cards
		where Libs.Id = S_Cards.Id_Lib and Libs.Id = T_Cards.Id_Lib group by Libs.Id
		)
	) as T
where Libs.Id = T.id
)

exec LibFav

--�������� �������� ���������, �������������� ��������� �����. (5! = 1*2*3*4*5 = 120) (0! = 1) (���������� �������������� ����� �� ����������).

alter procedure FactNum
@n int
as declare @res int
set @res =1
if (@n < 0) 
begin
raiserror ('It is not exist a factorial of a negative number',0,1)
end
	else
	begin 
		while @n !=1
		begin
			set @res = @res*@n
			set @n= @n-1 
		end
		return @res
	end

declare @nn int
exec @nn = FactNum -1
select @nn

--�������� ����� �������:
--�������, ������������ ���-�� ���������, ������� �� ����� �����.

create function BlankCardStuds()
returns int
as
begin
declare @c int
select @c = count(Students.Id)
from Students
where Students.Id not in
(select Students.Id
from S_Cards, Students
where S_Cards.Id_Student = Students.Id
group by Students.Id)
return @c
end

select dbo.BlankCardStuds()


--�������, ������������ ����������� �� ���� ���������� ����������.

create function MinValue(@a nvarchar(10), @b nvarchar(10), @c nvarchar(10))
returns nvarchar(10)
as
begin
	declare @t table (item nvarchar(10))
	declare @r nvarchar(10)
	insert into @t values (@a),(@b),(@c)
	select @r = min(item) from @t
	return @r
end

select dbo.MinValue(1,2,3)
	

--�������, ������� ��������� � �������� ��������� ������������� ����� � ���������� ����� �� �������� ������, ���� ��� �����. (����������� % - ������� �� ������. ��������: 57%10=7)

alter function BiggerOrderNum ( @n int )
returns nvarchar(30)
as
begin
declare @t nvarchar(20)
if (@n > 0 and @n <= 99)
	begin
	if (@n % 10 > @n / 10)  set @t = 'Last digit is bigger'
	if (@n % 10 < @n / 10) set @t = 'First digit is bigger'
	if (@n % 10 = @n / 10) set @t= 'Digits are equals'
	end
	else set @t ='Bad input format'
	return @t
end

select dbo.BiggerOrderNum(67)




--�������, ������������ ���-�� ������ ���� �� ������ �� ����� � �� ������ �� ������ (departments).

alter function BorrowedBooks()
returns @t table (name nvarchar(30), count int)
as
begin
--declare @t table (name nvarchar(30), count int)
insert @t 
select Groups.Name, count(Books.Id)
from Books, S_Cards, Students, Groups
where Books.Id = S_Cards.Id_Book 
and S_Cards.Id_Student = Students.Id
and Students.Id_Group = Groups.Id
group by Groups.Name
union
select Departments.Name, count(Books.Id)
from Books, T_Cards, Teachers, Departments
where Books.Id = T_Cards.Id_Book 
and T_Cards.Id_Teacher = Teachers.Id
and Teachers.Id_Dep = Departments.Id
group by Departments.Name
return
end

select * from dbo.BorrowedBooks()

--�������, ������������ ������ ����, ���������� ������ ��������� (��������, ��� ������, ������� ������, ��������, ���������), � ��������������� �� ������ ����, ���������� � 5-� ���������, � �����������, ��������� � 6-� ���������.

--�������, ������� ���������� ������ ������������� � ���-�� �������� ������ �� ��� ����.

create function LibsTrend()
returns @t table (name nvarchar(30), count int)
as
begin
insert @t 
select (Libs.FirstName+ ' ' +Libs.LastName), count(Libs.Id)
from Libs, S_Cards, T_Cards
where 
S_Cards.Id_Lib = Libs.Id
and T_Cards.Id_Lib = Libs.Id
group by Libs.FirstName, Libs.LastName
return
end

select * from dbo.LibsTrend()