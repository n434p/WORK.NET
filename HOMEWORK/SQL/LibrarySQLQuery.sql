--Показать издательства и сумму страниц по каждому из них.

--select Press.Name, sum(Books.Pages)
--from Press, Books
--where Press.Id = Books.Id_Themes
--group by Press.Name

--Показать общее кол-во книг, взятых студентами факультета 'Программирования'.

--select count(Books.Id)
--from Faculties,Groups,S_Cards,Students,Books
--where  Faculties.Name = 'Программирования'
--and Faculties.Id = Groups.Id_Faculty
--and Groups.Id = Students.Id_Group
--and Students.Id = S_Cards.Id_Student
--and S_Cards.Id_Book = Books.Id

--Вывести кол-во книг и сумму страниц этих книг по каждому из издательств 'Питер','Наука' и 'Кудиц-Образ'.

--select Press.Name, count(Books.Id), SUM(Books.Pages)
--from Press, Books
--where Press.Id = Books.Id_Press
--and Press.Name in ('Питер','Наука','Кудиц-Образ')
--group by Press.Name


--Вывести информацию о книге по программированию с наибольшим количеством страниц.

--select Books.Name
--from Books
--where Books.Pages = 
--(
--select max(Pages) 
--from Books, Themes 
--where Books.Id_Themes = Themes.Id 
--and Themes.Name = 'Программирование' 
--)

--Вывести на экран кол-во взятых книг по каждой из кафедр.

--select Departments.Name, COUNT(Books.Id)
--from T_Cards, Teachers, Books, Departments
--where Departments.Id = Teachers.Id_Dep
--and Teachers.Id = T_Cards.Id_Teacher
--and T_Cards.Id_Book = Books.Id
--group by Departments.Name

--Показать издательства и самую старую книгу для каждого из них.

select Press.Name, Books.YearPress
from Press, Books
where Books.YearPress = (select min(YearPress) from Books)
and Books.Id_Press = Press.Id
--group by press.Name

--select min(YearPress) 
--from Books, Press
--where Press.Id = Books.Id_Press 

--Показать книги, которые брали и преподаватели и студенты (исключить повторения).
--Показать название книги с максимальным кол-вом страниц по каждому из издательств.(с начала найти максимум по издательствам, после чего вложить этот запрос внутрь поиска по книгам)

