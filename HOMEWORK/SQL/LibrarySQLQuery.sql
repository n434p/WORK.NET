--�������� ������������ � ����� ������� �� ������� �� ���.

--select Press.Name, sum(Books.Pages)
--from Press, Books
--where Press.Id = Books.Id_Themes
--group by Press.Name

--�������� ����� ���-�� ����, ������ ���������� ���������� '����������������'.

--select count(Books.Id)
--from Faculties,Groups,S_Cards,Students,Books
--where  Faculties.Name = '����������������'
--and Faculties.Id = Groups.Id_Faculty
--and Groups.Id = Students.Id_Group
--and Students.Id = S_Cards.Id_Student
--and S_Cards.Id_Book = Books.Id

--������� ���-�� ���� � ����� ������� ���� ���� �� ������� �� ����������� '�����','�����' � '�����-�����'.

--select Press.Name, count(Books.Id), SUM(Books.Pages)
--from Press, Books
--where Press.Id = Books.Id_Press
--and Press.Name in ('�����','�����','�����-�����')
--group by Press.Name


--������� ���������� � ����� �� ���������������� � ���������� ����������� �������.

--select Books.Name
--from Books
--where Books.Pages = 
--(
--select max(Pages) 
--from Books, Themes 
--where Books.Id_Themes = Themes.Id 
--and Themes.Name = '����������������' 
--)

--������� �� ����� ���-�� ������ ���� �� ������ �� ������.

--select Departments.Name, COUNT(Books.Id)
--from T_Cards, Teachers, Books, Departments
--where Departments.Id = Teachers.Id_Dep
--and Teachers.Id = T_Cards.Id_Teacher
--and T_Cards.Id_Book = Books.Id
--group by Departments.Name

--�������� ������������ � ����� ������ ����� ��� ������� �� ���.

select Press.Name, Books.YearPress
from Press, Books
where Books.YearPress = (select min(YearPress) from Books)
and Books.Id_Press = Press.Id
--group by press.Name

--select min(YearPress) 
--from Books, Press
--where Press.Id = Books.Id_Press 

--�������� �����, ������� ����� � ������������� � �������� (��������� ����������).
--�������� �������� ����� � ������������ ���-��� ������� �� ������� �� �����������.(� ������ ����� �������� �� �������������, ����� ���� ������� ���� ������ ������ ������ �� ������)

