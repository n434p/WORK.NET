use library
go
--Create Trigger Show_Upd_Amm

--On Books

--For Update

--As 
--	raiserror('Ѕыло изменено %d записей',0,1,@@rowcount) 
--- %d - digital value
--- %s - string value 
--- данные параметры используютс€ как в String.Format("...{%d}...{%s}...",0,1,%d,%s)

--Update books

--Set books.quantity=books.quantity+5

--From press

--Where books.id_press=press.id

--and press.name like '%BHV%'

--//////////////////////////////////////////

--use Shop
--go

--Create Trigger Check_Date_trigger

--On Product

--for insert

--as
 
--Declare @InsDate date

--Select @InsDate=UDB from inserted/*получаем дату товара, который добавл€етс€
--(date_in - поле таблицы shop, в которую производитс€ вставка данных)*/
----- inserted || deleted - временные таблички, существующие только на момент вставки или удалени€

--if (@InsDate<=getdate()-30)	/*ѕровер€ем, не прошло ли 30 дней*/

--Begin

--	raiserror('Ёто слишком старый товар',0,1)
--	raiserror('ƒанные о товаре сохранены не будут',0,1)

--	Rollback transaction -- откат текушей транзакции (без вставки данных, очистка временной таблицы inserted)

--end  

--else

--Begin
--	Print('Insert Ok!!!') -- аналог MessageBox
--end


--- запрет на удаление самого попкл€рного диска

--create trigger Check_cd_delete

--on cd

--for delete

--as

--Declare @SellAmm int,
--@cd_name varchar(25),
--@best_cd varchar(25)

--Select @cd_name=deleted.name from deleted/*ѕолучаем название удал€емого диска.*/

--Declare @Svodka table (imya varchar(25), kolv int)

--insert @Svodka/*¬ычитываем информацию о названи€х дисков и о их попул€рности*/

--	select cd.name,count(id_cd) from selling,as cd
--	where selling.id_cd=cd.id
--	group by cd.name


--Select @best_cd=s.imya from @Svodka as s/*Ќаходим название самого попул€рного диска по продажам*/
--where s.kolv=(Select max(kolv) from @Svodka)

--if(@best_cd=@cd_name)/*ѕровер€ем совпадение названий.*/
--begin
--	raiserror('You can not delete this cd!!!',0,1)
--	rollback transaction
--end

--else

--begin
--	print ('deleting query was successfull!!')
--end



--Create Trigger Not_BHV

--On books 

--Instead of Delete

--As

--Declare @BHV_id int

--Select @BHV_id=id from press where press.name ='BHV  иев'/*
--ѕолучаем идентификатор издательства BHV  иев*/

--if (exists (select * from deleted where id_press=@BHV_id))/*ѕровер€ем, есть ли такой идентификатор
--в удал€емых книгах.*/

--	raiserror ('You can not delete BHV  иев!!!',0,1)

--else
--	commit transaction




create trigger People_copy

on People

after insert

as

insert into copypeople 
select * from inserted
