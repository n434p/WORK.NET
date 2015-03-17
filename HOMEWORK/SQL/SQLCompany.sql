
--drop database Company
--go 

--create database Company
--go 

--use Company
--go

----alter database Company
----modify file(name = Company, size = 5MB, filegrowth = 1MB)
----go

--create table Department
--(
--Id int not null primary key identity(1,1),
--Name nvarchar(20) not null
--)
-- go

-- create table Employee
--(
--Id int not null primary key identity(1,1),
--DepartmentID int not null foreign key references Department(Id),
--Name nvarchar(20) not null,
--Salary int,
--CheefID int not null foreign key references Employee(Id),
-- )
-- go

-- insert into Department
-- Values ('D1'),('D2'),('D3'),('D4'),('D5'),('D6'),('D7')

-- insert into Employee(CheefID,DepartmentID,Name,Salary)
-- values (7,1,'E1',1000),
--	    (7,1,'E2',2000),
--		(4,2,'E3',3000),
--		(4,2,'E4',12000),
--		(1,3,'E5',5000),
--		(1,4,'E6',6000), 
--		(7,7,'E7',8000)

use Company
go

alter trigger CheefCheck
on Employee
for insert
as

declare @InsCheffId int
declare @InsDepId int
declare @InsId int
declare @CurCheffId int
declare @T table (cid int, did int)

Select @InsCheffId=CheefID from inserted
Select @InsDepId=DepartmentID from inserted
Select @InsId=Id from inserted

insert @T
select CheefID,Department.Id
from Employee, Department 
where Employee.DepartmentID = Department.Id
select @CurCheffId = cid from @T where did = @InsDepId and cid = @InsCheffId
if (@CurCheffId is not null)
begin
print('The department already has cheef')
rollback transaction
end

select * from Employee

insert into Employee(CheefID,DepartmentID,Name,Salary)
values (1,7,'E9',7000)

select * from Employee

///////////////////////////////////////////////////////

use Company
go

---ВЫвести список сотрудников с ЗП большей чем у шефа

select Employee.Name
from Employee
where Employee.Salary > Any(
select Salary 
from Employee, Department 
where Employee.Id = Employee.CheefID 
and Department.Id = Employee.DepartmentID)

---- Вывести список сотрудников получающих максимальную ЗП в своем отделе

select Department.Name ,max(Salary)
from Employee, Department
where
Employee.DepartmentID = Department.Id
group by Department.Name

--- Вывести список отделов кол-во сотрудников которого не превышает 3(2) человека

select Department.Name
from Department,
(select Department.Id as did, count(Employee.Id) as c
from Employee, Department 
where Employee.DepartmentID = Department.Id 
group by Department.Id) as T
where Department.Id = T.did and T.c < 2

--- Вывести список сотрудников не имеющих назаначенного начальника, работающего в том же отделе

select Employee.Name
from Employee,Department,
(select CheefID as cid ,Department.Id as did
from Employee, Department 
where Employee.DepartmentID = Department.Id) as T
where Employee.Id != T.cid and Department.Id = T.did and Employee.DepartmentID = Department.Id
group by Employee.Name

---- Найти список Id отделов с максимальной сумарной ЗП сотрудников

select Department.Id
from Department,
( select Department.Id as did
 from Department, Employee
 where Department.Id = Employee.DepartmentID
 group by Department.Id
 having sum(Salary) >= all
 (
 select sum(Salary) 
 from Employee, Department
 where Department.Id = Employee.DepartmentID
 group by Department.Id
 )
) as T
where Department.id = T.did


