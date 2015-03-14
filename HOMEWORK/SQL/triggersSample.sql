use library
go
--Create Trigger Show_Upd_Amm

--On Books

--For Update

--As 
--	raiserror('���� �������� %d �������',0,1,@@rowcount) 
--- %d - digital value
--- %s - string value 
--- ������ ��������� ������������ ��� � String.Format("...{%d}...{%s}...",0,1,%d,%s)

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

--Select @InsDate=UDB from inserted/*�������� ���� ������, ������� �����������
--(date_in - ���� ������� shop, � ������� ������������ ������� ������)*/
----- inserted || deleted - ��������� ��������, ������������ ������ �� ������ ������� ��� ��������

--if (@InsDate<=getdate()-30)	/*���������, �� ������ �� 30 ����*/

--Begin

--	raiserror('��� ������� ������ �����',0,1)
--	raiserror('������ � ������ ��������� �� �����',0,1)

--	Rollback transaction -- ����� ������� ���������� (��� ������� ������, ������� ��������� ������� inserted)

--end  

--else

--Begin
--	Print('Insert Ok!!!') -- ������ MessageBox
--end


--- ������ �� �������� ������ ����������� �����

--create trigger Check_cd_delete

--on cd

--for delete

--as

--Declare @SellAmm int,
--@cd_name varchar(25),
--@best_cd varchar(25)

--Select @cd_name=deleted.name from deleted/*�������� �������� ���������� �����.*/

--Declare @Svodka table (imya varchar(25), kolv int)

--insert @Svodka/*���������� ���������� � ��������� ������ � � �� ������������*/

--	select cd.name,count(id_cd) from selling,as cd
--	where selling.id_cd=cd.id
--	group by cd.name


--Select @best_cd=s.imya from @Svodka as s/*������� �������� ������ ����������� ����� �� ��������*/
--where s.kolv=(Select max(kolv) from @Svodka)

--if(@best_cd=@cd_name)/*��������� ���������� ��������.*/
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

--Select @BHV_id=id from press where press.name ='BHV ����'/*
--�������� ������������� ������������ BHV ����*/

--if (exists (select * from deleted where id_press=@BHV_id))/*���������, ���� �� ����� �������������
--� ��������� ������.*/

--	raiserror ('You can not delete BHV ����!!!',0,1)

--else
--	commit transaction




create trigger People_copy

on People

after insert

as

insert into copypeople 
select * from inserted
