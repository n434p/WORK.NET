--use master
--go

--create database Company
--on (name = Company_db,
--	filename = 'D:\Company_db.mdf',
--	size = 5MB,
--	filegrowth = 1MB,
--	maxsize = 20MB)
--log on (name = Company_log,
--	    filename = 'D:\Company_log.ldf',
--	    size = 1MB,
--	    filegrowth = 10%,
--	    maxsize = 5MB)
--go


--use Company
--go

--create table Department
--(
--	Id   int          identity,
--	Name nvarchar(50) not null,
--	constraint PK_Department primary key (id) 
--)
--go

--create table Employee
--(
--	Id       int identity, 
--	Id_dep   int,
--	Name     nvarchar(50) not null,
--	Salary   int          not null check(Salary > 0),
--	Cheif_id int,
--	constraint PK_Employee            primary key(id),
--	constraint FK_Employee_Department foreign key(Id_dep) references Department(Id),
--	constraint FK_Employee_Cheif      foreign key(Cheif_id) references Employee(Id)      
--)
--go


----create trigger CheckCheif
----on Employee
----instead of insert
----as 
----begin
----if(exists(select 1
----           from inserted as t1
----		  where (Id_dep = 1 
----		    and Cheif_id is null 
----			and exists (select * 
----			              from Employee as t2
----					     where Id_dep = 1 
----		                   and Cheif_id is null))
----			and (Id_dep != 1
----			    and exists (select * 
----			              from Employee as t2
----						  where t1.Id_dep = t2.Id_dep 
----						    and t2.Cheif_id = 1))))
----    begin 
----	print('Department is has chief already')
----	rollback transaction
----	end
----else
----    begin
----		  commit transaction
----	end
----end


--insert into Department(Name)
--values ('Head'),
--	   ('Development'),
--	   ('Quality control'),
--	   ('HR'),
--	   ('Support')
	   
--go


--insert into Employee(Id_dep,Name,Salary,Cheif_id)
--values (1,'Myron Markevich',4500,null), -- 1
--       (1,'Oleksandra Loboda',3000,1),  -- 2

--	   (2,'Serhey Ivanov',1500,1),      -- 3
--	   (2,'Ilya Novikov',1500,3),       -- 4
--	   (2,'Petro Mogyla',1000,3),       -- 5
--	   (2,'Taras Shevchenko',2500,4),   -- 6
--	   (2,'Eugen Ilf',1200,4),          -- 7

--	   (3,'Pavlo Tychina',1200,1),      -- 8
--	   (3,'Lina Kostenko',800,8),       -- 9
	     
--	   (4,'Serhiy Bubka',1500,1),       -- 10
--	   (4,'Ivan Franko',1800,11),       -- 11
--	   (4,'Kotygoroshko',900,11),       -- 12

--	   (5,'Pavlo Tychina',1200,1),      -- 13
--	   (5,'Lina Kostenko',1500,13),     -- 14
--	   (5,'Oleksandr Oles',800,13),     -- 15
--	   (5,'Ivan Drach',1000,8)          -- 16
--go


-- 1. Вывести сотрудников, получающих ЗП больше руководителя
--select *
--  from Employee as t1
-- where Salary > (select Salary 
--                   from Employee as t2
--				  where t1.Cheif_id = t2.Id)
--go


--select t1.*
--  from Employee as t1
--  join Employee as t2 on t2.Id = t1.Cheif_id
--				     and t2.Salary < t1.Salary
--go

-- 2. Список сотрудников, получающих максимальную зарплату в своём отделе
--select t2.Name as "Department",
--	   t1.Name    as "Employee",
--       t1.Salary  
--  from (
--		 select Name,
--			    Salary,
--				Id_dep,
--				rank() over(partition by Id_dep order by Salary desc ) as "pos"
--		   from Employee  
--	   )          as t1 
--  join Department as t2 on t2.Id = t1.Id_dep
-- where t1.pos = 1
--go

--select t1.*
--  from Employee  as t1
-- where Salary = (select max(Salary)
--				   from Employee as t2
--				  where t2.Id_dep = t1.Id_dep)
--go

---- 3. Вывести список Id отделов, кол-во сотрудников, которых не прев. 3 человек
--select t1.Id_dep
--  from (
--		 select Id_dep,
--			    count(*) as "Qty"
--		   from Employee
--		  group by Id_dep
--		 having count(*) < 4
--	   ) as t1
--go

--select Id_dep  
--  from Employee
-- group by Id_dep
--having count(*) <= 3 

-- 4. Вывести список сотрудников, не имеющих назначенного руководителя в том же отделе
--select Id_dep,
--	   Name,
--	   Cheif_id
--  from Employee as t1
-- where Cheif_id  not in (select Id 
--                           from Employee as t2
--					      where t2.Id_dep = t1.Id_dep)
--go


--select t1.*
--  from Employee as t1
--  left join Employee as t2 on t2.Id = t1.Cheif_id
--						  and t2.Id_dep = t1.Id_dep
-- where t2.Id is null
--   and t1.Cheif_id is not null

-- 5. Вывести Id отделов с максимальной суммарной заработной платой сотрудников
--with temp as 
--(
--  select Id_dep,
--	     sum(Salary)                            as "Total",
--		 rank() over(order by sum(Salary) desc) as "Pos"
--    from Employee
--   group by Id_dep
--)
--select Id_dep
--  from temp
-- where Pos = 1
--go


--select Id_dep  
--  from (
--		 select Id_dep,
--				sum(Salary) as "Salary"
--			from Employee
--		 group by Id_dep  
--	   ) as t1
-- where t1.Salary = (select max(t2.Salary)
--                      from  (
--		                      select Id_dep,
--				                     sum(Salary) as "Salary"
--			                    from Employee
--		                       group by Id_dep  
--	                        ) as t2)