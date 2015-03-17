--�������� ������������ � ����� ������� �� ������� �� ���.

select Press.Name, sum(Books.Pages)
from Press, Books
where Press.Id = Books.Id_Themes
group by Press.Name

--�������� ����� ���-�� ����, ������ ���������� ���������� '����������������'.

select count(Books.Id)
from Faculties,Groups,S_Cards,Students,Books
where  Faculties.Name = '����������������'
and Faculties.Id = Groups.Id_Faculty
and Groups.Id = Students.Id_Group
and Students.Id = S_Cards.Id_Student
and S_Cards.Id_Book = Books.Id

--������� ���-�� ���� � ����� ������� ���� ���� �� ������� �� ����������� '�����','�����' � '�����-�����'.

select Press.Name, count(Books.Id), SUM(Books.Pages)
from Press, Books
where Press.Id = Books.Id_Press
and Press.Name in ('�����','�����','�����-�����')
group by Press.Name

--������� ���������� � ����� �� ���������������� � ���������� ����������� �������.

select Books.Name,Books.Pages
from Books
where Books.Pages = 
(
select max(Pages) 
from Books, Themes 
where Books.Id_Themes = Themes.Id 
and Themes.Name = '����������������' 
)

--������� �� ����� ���-�� ������ ���� �� ������ �� ������.

select Departments.Name, COUNT(Books.Id)
from T_Cards, Teachers, Books, Departments
where Departments.Id = Teachers.Id_Dep
and Teachers.Id = T_Cards.Id_Teacher
and T_Cards.Id_Book = Books.Id
group by Departments.Name

--�������� ������������ � ����� ������ ����� ��� ������� �� ���.

select distinct Books.Name, Books.YearPress, Press.Name
from Books, Press,
(
select distinct Press.Name as n, min(Books.YearPress) as my
from Press, Books
where Press.Id = Books.Id_Press 
group by Press.Name
) as OldestByPress
where Books.YearPress = OldestByPress.my and Press.Name = OldestByPress.n and Press.Id = Books.Id_Press
order by Books.YearPress

--�������� �����, ������� ����� � ������������� � �������� (��������� ����������).

select distinct Books.Name
from Books, T_Cards, S_Cards
where T_Cards.Id_Book = Books.Id and S_Cards.Id_Book = Books.Id

--�������� �������� ����� � ������������ ���-��� ������� �� ������� �� �����������.(� ������ ����� �������� �� �������������, ����� ���� ������� ���� ������ ������ ������ �� ������)

select distinct Books.Name, Books.Pages, Press.Name
from Books, Press,
(
select distinct Press.Name as n, max(Books.Pages) as mp
from Press, Books
where Press.Id = Books.Id_Press 
group by Press.Name
) as BiggerByPages
where Books.Pages = BiggerByPages.mp and Press.Name = BiggerByPages.n and Press.Id = Books.Id_Press
order by Books.Pages