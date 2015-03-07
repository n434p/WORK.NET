
--- 1 Получить всех студентов, которые хоть один раз брали книгу
--- Вариант 1
Select Students.FirstName, Students.LastName
from Students
where exists (select * 
from S_Cards where Students.Id = S_Cards.Id_Student)
--- Вариант 2
Select Students.FirstName, Students.LastName
from Students
where  Students.Id =Any (select Id_Student 
from S_Cards)

--- Выбрать всех авторов написавших книги с количеством страниц
--- большим чем любая книга издательства "Питер"

--- Вариант 1
select Authors.FirstName, Authors.LastName
from Authors, Books
where Authors.Id = Books.Id_Author 
and Books.Pages > all 
(
select Books.Pages
from Books, Press
where Books.Id_Press = Press.Id and Press.Name='Питер'
)

--- Вариант 2
select Authors.FirstName, Authors.LastName
from Authors, Books
where Authors.Id = Books.Id_Author 
and Books.Pages >  
(
select max(Books.Pages)
from Books, Press
where Books.Id_Press = Press.Id and Press.Name='Питер'
)

--- Подзапрос
select Books.Pages
from Books, Press
where Books.Id_Press = Press.Id and Press.Name='Питер'

--- Подзапрос
select * 
from S_Cards
