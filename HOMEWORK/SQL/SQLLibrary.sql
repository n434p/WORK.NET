---- 1. �������� ������������ � ����� ������� �� ������� �� ���.

--select Press.Name, sum(Books.Pages)
--from Press, Books
--where Books.Id_Press = Press.Id
--group by Press.Name

---- 2. �������� ����� ���-�� ����, ������ ���������� ���������� '����������������'.

--select  count(Books.Id)
--from Books, Faculties, Groups, Students, S_Cards
--where 
--Groups.Id = Students.Id_Group
--and S_Cards.Id_Student = Students.Id
--and S_Cards.Id_Book = Books.Id
--and Groups.Id_Faculty = Faculties.Id
--and Faculties.Name = '����������������'

---- 3. ������� ���-�� ���� � ����� ������� ���� ���� �� ������� �� ����������� '�����','�����' � '�����-�����'.

--select count(Books.Id), SUM(Books.Pages)
--from Press, Books
--where Press.Id in (select Press.Id
--from Press
--where Press.Name in ('�����','�����','�����-�����'))


--select count(*)
--from Books

