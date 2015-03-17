--Показать издательства и сумму страниц по каждому из них.

select Press.Name, sum(Books.Pages)
from Press, Books
where Press.Id = Books.Id_Themes
group by Press.Name

--Показать общее кол-во книг, взятых студентами факультета 'Программирования'.

select count(Books.Id)
from Faculties,Groups,S_Cards,Students,Books
where  Faculties.Name = 'Программирования'
and Faculties.Id = Groups.Id_Faculty
and Groups.Id = Students.Id_Group
and Students.Id = S_Cards.Id_Student
and S_Cards.Id_Book = Books.Id

--Вывести кол-во книг и сумму страниц этих книг по каждому из издательств 'Питер','Наука' и 'Кудиц-Образ'.

select Press.Name, count(Books.Id), SUM(Books.Pages)
from Press, Books
where Press.Id = Books.Id_Press
and Press.Name in ('Питер','Наука','Кудиц-Образ')
group by Press.Name

--Вывести информацию о книге по программированию с наибольшим количеством страниц.

select Books.Name,Books.Pages
from Books
where Books.Pages = 
(
select max(Pages) 
from Books, Themes 
where Books.Id_Themes = Themes.Id 
and Themes.Name = 'Программирование' 
)

--Вывести на экран кол-во взятых книг по каждой из кафедр.

select Departments.Name, COUNT(Books.Id)
from T_Cards, Teachers, Books, Departments
where Departments.Id = Teachers.Id_Dep
and Teachers.Id = T_Cards.Id_Teacher
and T_Cards.Id_Book = Books.Id
group by Departments.Name

--Показать издательства и самую старую книгу для каждого из них.

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

--Показать книги, которые брали и преподаватели и студенты (исключить повторения).

select distinct Books.Name
from Books, T_Cards, S_Cards
where T_Cards.Id_Book = Books.Id and S_Cards.Id_Book = Books.Id

--Показать название книги с максимальным кол-вом страниц по каждому из издательств.(с начала найти максимум по издательствам, после чего вложить этот запрос внутрь поиска по книгам)

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